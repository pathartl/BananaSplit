using BananaSplit.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BananaSplit
{
    public partial class SettingsForm : Form
    {
        public Settings Settings { get; set; }

        public SettingsForm()
        {

            InitializeComponent();
            Settings = new Settings();
            Settings.Load();

            BlackFrameDurationInput.Increment = (decimal)0.01;
            BlackFrameThresholdInput.Increment = (decimal)0.01;
            ReferenceFrameOffsetInput.Increment = (decimal)0.1;

            BlackFrameDurationInput.DecimalPlaces = 2;
            BlackFrameThresholdInput.DecimalPlaces = 2;
            ReferenceFrameOffsetInput.DecimalPlaces = 1;

            ProcessTypeComboBox.Items.Clear();
            ProcessTypeComboBox.Items.AddRange(typeof(ProcessingType).GetDisplayNames().ToArray());

            SaveButton.Click += SaveButton_Click;
            FormClosing += SettingsForm_FormClosing;

            BlackFrameDurationInput.Value = (decimal)Settings.BlackFrameDuration;
            BlackFrameThresholdInput.Value = (decimal)Settings.BlackFrameThreshold;
            ReferenceFrameOffsetInput.Value = (decimal)Settings.ReferenceFrameOffset;
            ShowLogCheckbox.Checked = Settings.ShowLog;
            DeleteOriginalCheckbox.Checked = Settings.DeleteOriginal;
            FFMPEGArgumentsInput.Text = Settings.FFMPEGArguments;
            ProcessTypeComboBox.SelectedItem = Settings.ProcessType.GetDisplayName();
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            Settings.BlackFrameDuration = (double)BlackFrameDurationInput.Value;
            Settings.BlackFrameThreshold = (double)BlackFrameThresholdInput.Value;
            Settings.ReferenceFrameOffset = (double)ReferenceFrameOffsetInput.Value;
            Settings.ShowLog = ShowLogCheckbox.Checked;
            Settings.DeleteOriginal = DeleteOriginalCheckbox.Checked;
            Settings.FFMPEGArguments = FFMPEGArgumentsInput.Text;
            
            foreach (ProcessingType type in (ProcessingType[])Enum.GetValues(typeof(ProcessingType)))
            {
                if (type.GetDisplayName() == (string)ProcessTypeComboBox.SelectedItem)
                {
                    Settings.ProcessType = type;
                }
            }

            Settings.Save();
            Hide();
        }

        public void PopulateInputs()
        {
            BlackFrameDurationInput.Text = Settings.BlackFrameDuration.ToString();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
