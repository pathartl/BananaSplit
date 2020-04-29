using BananaSplit.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BananaSplit
{
    public partial class MainForm : Form
    {
        private SettingsForm SettingsForm;
        private List<QueueItem> QueueItems { get; set; }
        private Thread ScanningThread;

        public MainForm()
        {
            InitializeComponent();
            QueueItems = new List<QueueItem>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            addFilesToQueueToolStripMenuItem1.Click += AddFilesToQueueToolStripMenuItem1_Click;
            QueueList.SelectedIndexChanged += RenderReferenceImagesListView;
        }

        private void AddFilesToQueueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
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

        private void ScanQueueItems()
        {
            FFMPEG ffmpeg = new FFMPEG();

            SetStatusBarProgressBarValue(0, QueueItems.Count);

            var i = 0;

            foreach (var item in QueueItems)
            {
                i++;

                SetStatusBarProgressBarValue(i, QueueItems.Count);
                SetStatusBarLabelValue($"Detecting frames for {Path.GetFileName(item.FileName)}");
                item.Scanned = true;
                item.LastScanned = DateTime.Now;
                item.BlackFrames = ffmpeg.DetectBlackFrames(item.FileName);

                foreach (var frame in item.BlackFrames)
                {
                    var referenceFramePosition = frame.End.Add(new TimeSpan(0, 0, 2));
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
                            Name = frame.Id.ToString()
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
            SettingsForm = new SettingsForm();
            SettingsForm.Show();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
