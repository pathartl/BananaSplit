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

        private const string SampleOriginalP1Text = "Example";
        private const string SampleOriginalP2Text = "Filename";
        private const string SampleOriginalText = SampleOriginalP1Text + SampleOriginalP2Text;
        private const string SampleExtensionText = ".mkv";
        private const string SampleIncrementText = "S02E0";

        public SettingsForm()
        {

            InitializeComponent();
            Settings = new Settings();
            Settings.Load();

            // Default values / settings
            BlackFrameDurationInput.Increment = (decimal)0.01;
            BlackFrameThresholdInput.Increment = (decimal)0.01;
            ReferenceFrameOffsetInput.Increment = (decimal)0.1;

            BlackFrameDurationInput.DecimalPlaces = 2;
            BlackFrameThresholdInput.DecimalPlaces = 2;
            ReferenceFrameOffsetInput.DecimalPlaces = 1;

            Settings.RenameFindText = FindTextBox.Text;
            Settings.RenameNewText = NewTextTextBox.Text;

            ProcessTypeComboBox.Items.Clear();
            ProcessTypeComboBox.Items.AddRange(typeof(ProcessingType).GetDisplayNames().ToArray());

            RenameTypeComboBox.Items.Clear();
            RenameTypeComboBox.Items.AddRange(typeof(RenameType).GetDisplayNames().ToArray());

            RenameOriginalCheckBox.Checked = true;

            // Restore load values
            BlackFrameDurationInput.Value = (decimal)Settings.BlackFrameDuration;
            BlackFrameThresholdInput.Value = (decimal)Settings.BlackFrameThreshold;
            ReferenceFrameOffsetInput.Value = (decimal)Settings.ReferenceFrameOffset;
            ShowLogCheckbox.Checked = Settings.ShowLog;
            DeleteOriginalCheckbox.Checked = Settings.DeleteOriginal;
            FFMPEGArgumentsInput.Text = Settings.FFMPEGArguments;
            ProcessTypeComboBox.SelectedItem = Settings.ProcessType.GetDisplayName();
            FindTextBox.Text = Settings.RenameFindText;
            NewTextTextBox.Text = Settings.RenameNewText;
            // Make sure the event handler is set before we set the value of the combo to update the fields
            RenameTypeComboBox.SelectedIndexChanged += RenameTypeComboBox_SelectedIndexChanged;
            RenameTypeComboBox.SelectedItem = Settings.RenameType.GetDisplayName();
            RenameOriginalCheckBox.Checked = Settings.RenameOriginal;

            UpdateExample();

            // Event handlers
            SaveButton.Click += SaveButton_Click;
            FormClosing += SettingsForm_FormClosing;

            FindTextBox.TextChanged += FindTextBox_TextChanged;
            NewTextTextBox.TextChanged += NewTextTextBox_TextChanged;
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            Settings.BlackFrameDuration = (double)BlackFrameDurationInput.Value;
            Settings.BlackFrameThreshold = (double)BlackFrameThresholdInput.Value;
            Settings.ReferenceFrameOffset = (double)ReferenceFrameOffsetInput.Value;
            Settings.ShowLog = ShowLogCheckbox.Checked;
            Settings.DeleteOriginal = DeleteOriginalCheckbox.Checked;
            Settings.FFMPEGArguments = FFMPEGArgumentsInput.Text;
            Settings.RenameFindText = FindTextBox.Text;
            Settings.RenameNewText = NewTextTextBox.Text;
            Settings.RenameOriginal = RenameOriginalCheckBox.Checked;

            foreach (ProcessingType type in (ProcessingType[])Enum.GetValues(typeof(ProcessingType)))
            {
                if (type.GetDisplayName() == (string)ProcessTypeComboBox.SelectedItem)
                {
                    Settings.ProcessType = type;
                }
            }

            foreach (RenameType type in (RenameType[])Enum.GetValues(typeof(RenameType)))
            {
                if (type.GetDisplayName() == (string)RenameTypeComboBox.SelectedItem)
                {
                    Settings.RenameType = type;
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

        private void RenameTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(RenameTypeComboBox.SelectedItem as string, out RenameType type);
            switch (type)
            {
                case RenameType.Prefix:
                    FindTextBox.Enabled = false;
                    RenameLabel.Text = "Suffix";
                    break;
                case RenameType.Suffix:
                    FindTextBox.Enabled = false;
                    RenameLabel.Text = "Prefix";
                    break;
                case RenameType.AppendAfter:
                    FindTextBox.Enabled = true;
                    RenameLabel.Text = "Append After";
                    break;
                case RenameType.Replace:
                    FindTextBox.Enabled = true;
                    RenameLabel.Text = "Replace";
                    break;
                case RenameType.Increment:
                    FindTextBox.Enabled = false;
                    NewTextTextBox.Enabled = false;
                    break;
            }

            UpdateExample();
        }

        private void PrefixRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FindTextBox.Enabled = false;
            RenameLabel.Text = "Suffix";
            UpdateExample();
        }

        private void SuffixRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FindTextBox.Enabled = false;
            RenameLabel.Text = "Prefix";
            UpdateExample();
        }

        private void AppendAfterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FindTextBox.Enabled = true;
            RenameLabel.Text = "Append After";
            UpdateExample();
        }

        private void ReplaceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FindTextBox.Enabled = true;
            RenameLabel.Text = "Replace";
            UpdateExample();
        }

        private void IncrementRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FindTextBox.Enabled = false;
            NewTextTextBox.Enabled = false;
            UpdateExample();
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateExample();
        }

        private void NewTextTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateExample();
        }

        private void UpdateExample()
        {
            Enum.TryParse(RenameTypeComboBox.SelectedItem as string, out RenameType type);
            switch (type)
            {
                case RenameType.Prefix:
                    ResultLabel.Text = NewTextTextBox.Text + SampleOriginalText + SampleExtensionText;
                    break;
                case RenameType.Suffix:
                    ResultLabel.Text = SampleOriginalText + NewTextTextBox.Text + SampleExtensionText;
                    break;
                case RenameType.AppendAfter:
                    OriginalLabel.Text = SampleOriginalP1Text + FindTextBox.Text + SampleOriginalP2Text + SampleExtensionText;
                    ResultLabel.Text = SampleOriginalP1Text + FindTextBox.Text + NewTextTextBox.Text + SampleOriginalP2Text + SampleExtensionText;
                    break;
                case RenameType.Replace:
                    OriginalLabel.Text = SampleOriginalP1Text + FindTextBox.Text + SampleOriginalP2Text + SampleExtensionText;
                    ResultLabel.Text = OriginalLabel.Text.Replace(FindTextBox.Text, NewTextTextBox.Text);
                    break;
                case RenameType.Increment:
                    OriginalLabel.Text = SampleOriginalP1Text + SampleIncrementText + "2" + SampleOriginalP2Text + SampleExtensionText;
                    ResultLabel.Text = SampleOriginalP1Text + SampleIncrementText + "3" + SampleOriginalP2Text + SampleExtensionText;
                    break;
            }

            switch (type)
            {
                case RenameType.Prefix:
                case RenameType.Suffix:
                case RenameType.AppendAfter:
                case RenameType.Replace:
                    if(ResultLabel.Text.Contains("{i}"))
                    {
                        OriginalLabel.Text.Replace("{i}", "2");
                        ResultLabel.Text.Replace("{i}", "3");
                    }
                    else
                    {
                        OriginalLabel.Text.Replace(".mkv", "-2.mkv");
                        ResultLabel.Text.Replace(".mkv", "-3.mkv");
                    }
                    break;
            }
        }
    }
}
