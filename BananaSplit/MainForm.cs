using BananaSplit.Extensions;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BananaSplit
{
    public partial class MainForm : Form
    {
        private SettingsForm SettingsForm;
        private LogForm LogForm;

        private List<QueueItem> QueueItems { get; set; }
        private Thread ScanningThread;
        private Thread ProcessingThread;
        private FFMPEG FFMPEG;
        private MKVToolNix MKVToolNix;

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
            // Menu Items
            AddFilesToQueueMenuItem.Click += AddFilesToQueueDialog;
            AddFolderToQueueMenuItem.Click += AddFolderToQueueDialog;
            SettingsMenuItem.Click += OpenSettingsForm;

            // Queue List
            QueueList.SelectedIndexChanged += RenderReferenceImagesListView;
            QueueList.MouseUp += OpenQueueItemContextMenu;
            QueueList.KeyDown += QueueListKeyDownHandler;
            QueueItemContextMenuProcess.Click += ProcessQueueItem;
            QueueItemContextMenuRemove.Click += RemoveQueueItem;
            QueueListContextMenuProcess.Click += ProcessQueue;
            QueueListContextMenuRemove.Click += RemoveQueueList;

            // Other
            ProcessQueueButton.Click += ProcessQueue;
            QueueList.Resize += AutoSizeQueueList;

            // Drag and Drop
            this.AllowDrop = true;
            this.DragOver += AddDragOverItemToQueueDialog;
            this.DragDrop += AddDragDropItemToQueueDialog;

            SettingsForm = new SettingsForm();
            LogForm = new LogForm();

            FFMPEG = new FFMPEG();
            MKVToolNix = new MKVToolNix();
        }

        private void AutoSizeQueueList(object sender, EventArgs e)
        {
            QueueList.Columns[0].Width = QueueList.Width - 4;
        }

        private void OpenQueueItemContextMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && QueueList.FocusedItem != null && QueueList.FocusedItem.Bounds.Contains(e.Location))
            {
                QueueItemContextMenu.Tag = QueueList.FocusedItem.Tag;
                QueueItemContextMenu.Show(Cursor.Position);
            }
            else if (e.Button == MouseButtons.Right)
            {
                QueueListContextMenu.Show(Cursor.Position);
            }
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

                    ScanningThread = new Thread(() =>
                    {
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

                    ScanningThread = new Thread(() =>
                    {
                        ScanQueueItems();
                    });

                    ScanningThread.Start();
                }
            }
        }

        private void AddDragOverItemToQueueDialog(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void AddDragDropItemToQueueDialog(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null && files.Any())
            {
                QueueItems.AddRange(files.Select(fn => new QueueItem(fn)));

                ScanningThread = new Thread(() =>
                {
                    ScanQueueItems();
                });

                ScanningThread.Start();
            }
        }

        private void ShowLog()
        {
            Invoke(new MethodInvoker(
               delegate ()
               {
                   if (!LogForm.Visible)
                   {
                       LogForm.Show();
                   }
               })
           );
        }

        private void Log(string text)
        {
            Invoke(new MethodInvoker(
               delegate ()
               {
                   if (LogForm.Visible)
                   {
                       LogForm.Log(text);
                   }
               })
           );
        }

        private void ScanQueueItems()
        {
            if (SettingsForm.Settings.ShowLog)
            {
                ShowLog();
            }

            SetStatusBarProgressBarValue(0, QueueItems.Count);

            var i = 0;
            int totalNumFrames = 0;
            int countedFrames = 0;

            // Get all video durations and fps for a better progress bar
            foreach (var item in QueueItems.Where(qi => !qi.Scanned))
            {
                item.Duration = FFMPEG.GetDuration(item.FileName, (s, e) =>
                {
                    string logMsg = e.Data;
                    Log(logMsg);
                    if (logMsg == null)
                    {
                        return;
                    }
                    
                    if (item.Fps == 0)
                    {
                        string fpsPattern = @"(?'fps'[.\d]+) fps,";
                        Regex regex = new Regex(fpsPattern, RegexOptions.Singleline);

                        Match m = regex.Match(logMsg);
                        if (m.Success && float.TryParse(m.Groups["fps"].Value, out float fps))
                        {
                            item.Fps = fps;
                        }
                    }
                });

                item.NumFrames = (int)Math.Ceiling(item.Duration.TotalSeconds * item.Fps);
                totalNumFrames += item.NumFrames;
            }

            // Parse items
            foreach (var item in QueueItems.Where(qi => !qi.Scanned))
            {
                i++;

                SetStatusBarLabelValue($"Detecting frames for {Path.GetFileName(item.FileName)}");
                item.Scanned = true;
                item.LastScanned = DateTime.Now;
                item.BlackFrames = FFMPEG.DetectBlackFrames(item.FileName, (s, e) =>
                {
                    string logMsg = e.Data;
                    Log(logMsg);
                    if (logMsg == null)
                    {
                        return;
                    }

                    string framePattern = @"(\sframe:|frame=\s+)(?'frame'\d+)";
                    Regex regex = new Regex(framePattern, RegexOptions.Singleline);

                    Match m = regex.Match(logMsg);
                    if (m.Success && int.TryParse(m.Groups["frame"].Value, out int frame))
                    {
                        SetStatusBarProgressBarValue(countedFrames + frame, totalNumFrames);
                    }
                });
                countedFrames += item.NumFrames;
                SetStatusBarProgressBarValue(countedFrames, totalNumFrames);

                var frameNum = 1;
                foreach (var frame in item.BlackFrames)
                {
                    long offset = (long)(SettingsForm.Settings.ReferenceFrameOffset * TimeSpan.TicksPerSecond);
                    TimeSpan referenceFramePosition = frame.End.Add(new TimeSpan(offset));

                    SetStatusBarLabelValue($"Generating frame {frameNum} of {item.BlackFrames.Count} at {referenceFramePosition}");
                    frame.ReferenceFrame = new ReferenceFrame();
                    frame.ReferenceFrame.Data = FFMPEG.ExtractFrame(item.FileName, referenceFramePosition, FFMPEGLog);
                    frameNum++;
                }

                AddItemToQueue(item);
            }

            SetStatusBarLabelValue("Done!");
            ClearStatusBarProgressBarValue();
        }

        private void FFMPEGLog(object sender, DataReceivedEventArgs e)
        {
            if (SettingsForm.Settings.ShowLog)
            {
                LogForm.Invoke(
                                new MethodInvoker(
                                delegate ()
                                {
                                    LogForm.Log(e.Data);
                                }
                            )
                        );
            }
        }

        private void SetStatusBarProgressBarValue(int value, int maximum)
        {
            StatusBar.Invoke(
                new MethodInvoker(
                    delegate ()
                    {
                        StatusBarProgressBar.Maximum = maximum;
                        StatusBarProgressBar.Value = value;
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                        TaskbarManager.Instance.SetProgressValue(value, maximum);
                    }
                )
            );
        }

        private void ClearStatusBarProgressBarValue()
        {
            StatusBar.Invoke(
                new MethodInvoker(
                    delegate ()
                    {
                        StatusBarProgressBar.Maximum = 1;
                        StatusBarProgressBar.Value = 0;
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                        TaskbarManager.Instance.SetProgressValue(0, 1);
                    }
                )
            );
        }

        private void SetStatusBarLabelValue(string value)
        {
            StatusBar.Invoke(
                new MethodInvoker(
                    delegate ()
                    {
                        StatusBarLabel.Text = value;
                    }
                )
            );
        }

        private void LockControls()
        {
            Invoke(
                new MethodInvoker(
                    delegate ()
                    {
                        ProcessQueueButton.Enabled = false;
                        QueueListContextMenuProcess.Enabled = false;
                        QueueItemContextMenuProcess.Enabled = false;
                        QueueListContextMenuRemove.Enabled = false;
                        QueueItemContextMenuRemove.Enabled = false;
                        AddFilesToQueueMenuItem.Enabled = false;
                        AddFolderToQueueMenuItem.Enabled = false;
                        Cursor.Current = Cursors.WaitCursor;
                        Cursor = Cursors.WaitCursor;
                    }
                )
            );
        }

        private void UnlockControls()
        {
            Invoke(
                new MethodInvoker(
                    delegate ()
                    {
                        ProcessQueueButton.Enabled = true;
                        QueueListContextMenuProcess.Enabled = true;
                        QueueItemContextMenuProcess.Enabled = true;
                        QueueListContextMenuRemove.Enabled = true;
                        QueueItemContextMenuRemove.Enabled = true;
                        AddFilesToQueueMenuItem.Enabled = true;
                        AddFolderToQueueMenuItem.Enabled = true;
                        Cursor.Current = Cursors.Default;
                        Cursor = Cursors.Default;
                    }
                )
            );
        }

        private void AddItemToQueue(QueueItem item)
        {
            QueueList.Invoke(
                new MethodInvoker(
                    delegate ()
                    {
                        QueueList.Items.Add(new ListViewItem()
                        {
                            Text = Path.GetFileName(item.FileName),
                            ToolTipText = item.FileName,
                            Name = item.Id.ToString(),
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

        private void OpenSettingsForm(object sender, EventArgs e)
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

        private void RemoveQueueItem(object sender, EventArgs e)
        {
            QueueItem queueItem = (QueueItem)QueueItemContextMenu.Tag;

            QueueList.Items.RemoveByKey(queueItem.Id.ToString());
            QueueItems.Remove(queueItem);
        }

        private void RemoveQueueList(object sender, EventArgs e)
        {
            foreach (var queueItem in QueueItems)
            {
                QueueList.Items.RemoveByKey(queueItem.Id.ToString());
            }

            QueueItems.Clear();
        }

        private void ProcessQueue(object sender, EventArgs e)
        {
            if (SettingsForm.Settings.ShowLog)
            {
                ShowLog();
            }

            ProcessingThread = new Thread(() =>
            {
                LockControls();

                SetStatusBarProgressBarValue(0, QueueItems.Count);

                var i = 0;

                switch (SettingsForm.Settings.ProcessType)
                {
                    case ProcessingType.MatroskaChapters:
                        foreach (var queueItem in QueueItems)
                        {
                            i++;

                            SetStatusBarProgressBarValue(i, QueueItems.Count);
                            SetStatusBarLabelValue($"Adding chapters for {Path.GetFileName(queueItem.FileName)}");

                            ProcessMatroskaChapters(queueItem);
                        }

                        SetStatusBarLabelValue("Done adding chapters!");
                        break;

                    case ProcessingType.SplitAndEncode:
                        foreach (var queueItem in QueueItems)
                        {
                            i++;

                            SetStatusBarProgressBarValue(i, QueueItems.Count);
                            SetStatusBarLabelValue($"Encoding for {Path.GetFileName(queueItem.FileName)}");

                            ProcessSplitAndEncode(queueItem);
                        }

                        SetStatusBarLabelValue("Done encoding!");
                        break;
                }

                UnlockControls();

                ClearStatusBarProgressBarValue();
            });

            ProcessingThread.Start();
        }

        private void ProcessQueueItem(object sender, EventArgs e)
        {
            ProcessingThread = new Thread(() =>
            {
                QueueItem queueItem = (QueueItem)QueueItemContextMenu.Tag;

                LockControls();

                SetStatusBarProgressBarValue(1, 1);

                switch (SettingsForm.Settings.ProcessType)
                {
                    case ProcessingType.MatroskaChapters:
                        SetStatusBarLabelValue($"Adding chapters for {Path.GetFileName(queueItem.FileName)}");
                        ProcessMatroskaChapters(queueItem);
                        SetStatusBarLabelValue("Done adding chapters!");
                        break;

                    case ProcessingType.SplitAndEncode:
                        SetStatusBarLabelValue($"Encoding for {Path.GetFileName(queueItem.FileName)}");
                        ProcessSplitAndEncode(queueItem);
                        SetStatusBarLabelValue("Done encoding!");
                        break;
                }

                UnlockControls();

                ClearStatusBarProgressBarValue();
            });

            ProcessingThread.Start();
        }

        private void ProcessMatroskaChapters(QueueItem queueItem)
        {
            List<TimeSpan> chapterTimeSpans = new List<TimeSpan>();

            // Always add the beginning as a chapter
            chapterTimeSpans.Add(new TimeSpan(0, 0, 0));

            foreach (var frame in queueItem.BlackFrames.Where(bf => bf.Selected))
            {
                var halfDuration = new TimeSpan(frame.Duration.Ticks / 2);

                chapterTimeSpans.Add(frame.End.Subtract(halfDuration));
            }

            if (!FFMPEG.IsMatroska(queueItem.FileName, FFMPEGLog))
            {
                var matroskaPath = MKVToolNix.RemuxToMatroska(queueItem.FileName);

                queueItem.FileName = matroskaPath;
            }

            var chapters = MKVToolNix.GenerateChapters(chapterTimeSpans);

            MKVToolNix.InjectChapters(queueItem.FileName, chapters);
        }

        private void ProcessSplitAndEncode(QueueItem queueItem)
        {
            var segments = queueItem.GetSegments();
            var index = 1;

            // Rename original file if user wants it
            var encodingFileName = queueItem.FileName;
            if(SettingsForm.Settings.RenameOriginal)
            {
                var fi = new FileInfo(encodingFileName);
                var path = Path.GetDirectoryName(encodingFileName);
                var name = Path.GetFileNameWithoutExtension(encodingFileName);
                var ext = Path.GetExtension(encodingFileName);
                encodingFileName = Path.Combine(path, name + "_original" + ext);
                fi.MoveTo(encodingFileName);
            }

            foreach (var segment in segments)
            {
                //var newName = Path.Combine(Path.GetDirectoryName(queueItem.FileName), Path.GetFileNameWithoutExtension(queueItem.FileName) + "-" + index + ".mkv");
                var newName = GetNewName(queueItem.FileName, index);

                FFMPEG.EncodeSegments(encodingFileName, newName, SettingsForm.Settings.FFMPEGArguments.Replace("\r\n", " "), segment, FFMPEGLog);

                index++;
            }
        }

        private string GetNewName(string fileName, int index)
        {
            var path = Path.GetDirectoryName(fileName);
            var name = Path.GetFileNameWithoutExtension(fileName);
            var original = name;

            var oldText = SettingsForm.Settings.RenameFindText;
            var newText = SettingsForm.Settings.RenameNewText;
            
            switch(SettingsForm.Settings.RenameType)
            {
                case RenameType.Prefix:
                    name = newText + name;
                    break;
                case RenameType.Suffix:
                    name += newText;
                    break;
                case RenameType.AppendAfter:
                    var ind = name.IndexOf(oldText);
                    name = name.Substring(0, ind + oldText.Length) + newText + name.Substring(ind + oldText.Length);
                    break;
                case RenameType.Replace:
                    name = name.Replace(oldText, newText);
                    break;
                case RenameType.Increment:
                    string numPattern = @"(S\d{2}E)(?'num'\d{2})";
                    name = Regex.Replace(
                        name,
                        numPattern,
                        m => m.Groups[1].Value + (int.Parse(m.Groups["num"].Value) + index - 1).ToString("D2")
                    );
                    break;
            }

            // Add the index if necessary
            switch (SettingsForm.Settings.RenameType)
            {
                case RenameType.Prefix:
                case RenameType.Suffix:
                case RenameType.AppendAfter:
                case RenameType.Replace:
                    if (name.Contains("{i}"))
                    {
                        name.Replace("{i}", "" + index);
                    }
                    else
                    {
                        name += "-" + index;
                    }
                    break;
            }
             
            // Make sure the name is different if we didn't rename the original file
            if(name == original && !SettingsForm.Settings.RenameOriginal)
            {
                name += "-" + index;
            }

            var newName = Path.Combine(path, name + ".mkv");
            return newName;
        }


        private void QueueListKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem eachItem in QueueList.SelectedItems)
                {
                    QueueItem queueItem = eachItem.Tag as QueueItem;

                    QueueList.Items.Remove(eachItem);
                    QueueItems.Remove(queueItem);
                }
            }
        }
    }
}
