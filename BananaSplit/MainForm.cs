using BananaSplit.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BananaSplit
{
    public partial class MainForm : Form
    {
        private SettingsForm SettingsForm;

        private List<QueueItem> QueueItems { get; set; }
        private Thread ScanningThread;

        private string[] SupportedExtensions =
        {
            ".avi",
            ".flv",
            ".m4p",
            ".m4v",
            ".mkv",
            ".mov",
            ".mp2",
            ".mp4",
            ".mpe",
            ".mpeg",
            ".mpg",
            ".mpv",
            ".ogg",
            ".ts",
            ".webm",
            ".wmv"
        };

        public MainForm()
        {
            InitializeComponent();
            QueueItems = new List<QueueItem>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AddFilesToQueueMenuItem.Click += AddFilesToQueueDialog;
            AddFolderToQueueMenuItem.Click += AddFolderToQueueDialog;
            QueueList.SelectedIndexChanged += RenderReferenceImagesListView;

            SettingsForm = new SettingsForm();
        }

        private void AddFilesToQueueDialog(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = $"Video Files (*{String.Join(",*", SupportedExtensions)})|*{String.Join(";*", SupportedExtensions)}";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    QueueItems.AddRange(openFileDialog.FileNames.Select(fn => new QueueItem(fn)));

                    ScanningThread = new Thread(() => {
                        ScanQueueItems();
                    });

                    ScanningThread.Start();
                }
            }
        }

        private void AddFolderToQueueDialog(object sender, EventArgs e)
        {
            using (FolderBrowserDialog openFolderDialog = new FolderBrowserDialog())
            {
                var result = openFolderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFolderDialog.SelectedPath))
                {
                    string[] files = Directory.GetFiles(openFolderDialog.SelectedPath);

                    foreach (var file in files)
                    {
                        if (SupportedExtensions.Contains(Path.GetExtension(file)))
                        {
                            QueueItems.Add(new QueueItem(file));
                        }
                    }

                    ScanningThread = new Thread(() => {
                        ScanQueueItems();
                    });

                    ScanningThread.Start();
                }
            }
        }

        private void ScanQueueItems()
        {
            FFMPEG ffmpeg = new FFMPEG();

            SetStatusBarProgressBarValue(0, QueueItems.Count);

            var i = 0;

            foreach (var item in QueueItems.Where(qi => !qi.Scanned))
            {
                i++;

                SetStatusBarProgressBarValue(i, QueueItems.Count);
                SetStatusBarLabelValue($"Detecting frames for {Path.GetFileName(item.FileName)}");
                item.Scanned = true;
                item.LastScanned = DateTime.Now;
                item.BlackFrames = ffmpeg.DetectBlackFrames(item.FileName, SettingsForm.Settings.BlackFrameDuration, SettingsForm.Settings.BlackFrameThreshold);

                foreach (var frame in item.BlackFrames)
                {
                    long offset = (long)(SettingsForm.Settings.ReferenceFrameOffset * TimeSpan.TicksPerSecond);
                    TimeSpan referenceFramePosition = frame.End.Add(new TimeSpan(offset));

                    SetStatusBarLabelValue($"Generating frame at {referenceFramePosition}");
                    frame.ReferenceFrame = new ReferenceFrame();
                    frame.ReferenceFrame.Data = ffmpeg.ExtractFrame(item.FileName, referenceFramePosition);
                }

                AddItemToQueue(item);
            }

            SetStatusBarLabelValue("Done!");
        }

        private void SetStatusBarProgressBarValue(int value, int maximum)
        {
            StatusBar.Invoke(
                new MethodInvoker(
                    delegate () {
                        StatusBarProgressBar.Value = value;
                        StatusBarProgressBar.Maximum = maximum;
                    }
                )
            );
        }

        private void SetStatusBarLabelValue(string value)
        {
            StatusBar.Invoke(
                new MethodInvoker(
                    delegate () {
                        StatusBarLabel.Text = value;
                    }
                )
            );
        }

        private void AddItemToQueue(QueueItem item)
        {
            QueueList.Invoke(
                new MethodInvoker(
                    delegate () {
                        QueueList.Items.Add(new ListViewItem()
                        {
                            Text = Path.GetFileName(item.FileName),
                            ToolTipText = item.FileName,
                            Tag = item
                        });
                    }
                )
            );
        }

        private void RenderReferenceImagesListView(object sender, EventArgs e)
        {
            if (QueueList.SelectedItems.Count > 0)
            {
                var selectedItem = (QueueItem)QueueList.SelectedItems[0].Tag;

                foreach (var frame in selectedItem.BlackFrames)
                {
                    if (frame.ReferenceFrame.Data.Length > 0)
                    {
                        var bmp = Utilities.BytesToImage(frame.ReferenceFrame.Data);

                        ReferenceImageList.Add(bmp, frame.Id.ToString());

                        ReferenceImageListView.Items.Add(new ListViewItem()
                        {
                            ImageKey = frame.Id.ToString(),
                            Tag = frame,
                            Name = frame.Id.ToString(),
                            Text = frame.End.ToString(),
                            Checked = frame.Selected
                        });
                    }
                }
            }
            else
            {
                ReferenceImageListView.Clear();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm.Show();
        }

        private void ReferenceImageListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ReferenceImageListView.Items)
            {
                if (item.Selected)
                {
                    item.Selected = false;
                    item.Checked = !item.Checked;

                    ((BlackFrame)item.Tag).Selected = item.Checked;
                }
            }
        }

        private void ProcessQueueButton_Click(object sender, EventArgs e)
        {
            ProcessQueueButton.Enabled = false;

            var ffmpeg = new FFMPEG();
            var mkvtoolnix = new MKVToolNix();

            foreach (var item in QueueItems)
            {
                List<TimeSpan> chapterTimeSpans = new List<TimeSpan>();

                // Always add the beginning as a chapter
                chapterTimeSpans.Add(new TimeSpan(0, 0, 0));

                foreach (var frame in item.BlackFrames.Where(bf => bf.Selected))
                {
                    var halfDuration = new TimeSpan(frame.Duration.Ticks / 2);

                    chapterTimeSpans.Add(frame.End.Subtract(halfDuration));
                }

                if (!ffmpeg.IsMatroska(item.FileName))
                {
                    var matroskaPath = mkvtoolnix.RemuxToMatroska(item.FileName);

                    item.FileName = matroskaPath;
                }

                var chapters = mkvtoolnix.GenerateChapters(chapterTimeSpans);

                mkvtoolnix.InjectChapters(item.FileName, chapters);
            }

            MessageBox.Show("Done!");

            ProcessQueueButton.Enabled = true;
        }
    }
}
