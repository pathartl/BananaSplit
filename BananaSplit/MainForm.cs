using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BananaSplit
{
    public partial class MainForm : Form
    {
        private SettingsForm SettingsForm;
        private List<QueueItem> QueueItems { get; set; }

        public MainForm()
        {
            InitializeComponent();
            QueueItems = new List<QueueItem>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            addFilesToQueueToolStripMenuItem1.Click += AddFilesToQueueToolStripMenuItem1_Click;
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

                    FFMPEG ffmpeg = new FFMPEG();

                    foreach (var item in QueueItems)
                    {
                        ffmpeg.DetectBlackFrames(item.FileName);
                    }
                }
            }

            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm = new SettingsForm();
            SettingsForm.Show();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
