namespace BananaSplit
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ShowLogCheckbox = new System.Windows.Forms.CheckBox();
            this.FFMPEGArgumentsLegend = new System.Windows.Forms.Label();
            this.FFMPEGArgumentsInput = new System.Windows.Forms.TextBox();
            this.ReferenceFrameOffsetLabel = new System.Windows.Forms.Label();
            this.ReferenceFrameOffsetInput = new System.Windows.Forms.NumericUpDown();
            this.DeleteOriginalCheckbox = new System.Windows.Forms.CheckBox();
            this.ProcessTypeLabel = new System.Windows.Forms.Label();
            this.ProcessTypeComboBox = new System.Windows.Forms.ComboBox();
            this.BlackFrameDurationInput = new System.Windows.Forms.NumericUpDown();
            this.BlackFrameThresholdInput = new System.Windows.Forms.NumericUpDown();
            this.BlackFrameThresholdLabel = new System.Windows.Forms.Label();
            this.BlackFrameDurationLabel = new System.Windows.Forms.Label();
            this.FFMPEGArgumentsGroupBox = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RenameOriginalCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RenameTypeComboBox = new System.Windows.Forms.ComboBox();
            this.RenameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OriginalLabel = new System.Windows.Forms.Label();
            this.NewTextTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.startIndexNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReferenceFrameOffsetInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameDurationInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameThresholdInput)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startIndexNumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(26, 30);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(911, 999);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ShowLogCheckbox);
            this.tabPage1.Controls.Add(this.FFMPEGArgumentsLegend);
            this.tabPage1.Controls.Add(this.FFMPEGArgumentsInput);
            this.tabPage1.Controls.Add(this.ReferenceFrameOffsetLabel);
            this.tabPage1.Controls.Add(this.ReferenceFrameOffsetInput);
            this.tabPage1.Controls.Add(this.DeleteOriginalCheckbox);
            this.tabPage1.Controls.Add(this.ProcessTypeLabel);
            this.tabPage1.Controls.Add(this.ProcessTypeComboBox);
            this.tabPage1.Controls.Add(this.BlackFrameDurationInput);
            this.tabPage1.Controls.Add(this.BlackFrameThresholdInput);
            this.tabPage1.Controls.Add(this.BlackFrameThresholdLabel);
            this.tabPage1.Controls.Add(this.BlackFrameDurationLabel);
            this.tabPage1.Controls.Add(this.FFMPEGArgumentsGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(8, 46);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Size = new System.Drawing.Size(895, 945);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ShowLogCheckbox
            // 
            this.ShowLogCheckbox.AutoSize = true;
            this.ShowLogCheckbox.Location = new System.Drawing.Point(13, 265);
            this.ShowLogCheckbox.Name = "ShowLogCheckbox";
            this.ShowLogCheckbox.Size = new System.Drawing.Size(150, 36);
            this.ShowLogCheckbox.TabIndex = 7;
            this.ShowLogCheckbox.Text = "Show Log";
            this.ShowLogCheckbox.UseVisualStyleBackColor = true;
            // 
            // FFMPEGArgumentsLegend
            // 
            this.FFMPEGArgumentsLegend.AutoSize = true;
            this.FFMPEGArgumentsLegend.Location = new System.Drawing.Point(708, 434);
            this.FFMPEGArgumentsLegend.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.FFMPEGArgumentsLegend.Name = "FFMPEGArgumentsLegend";
            this.FFMPEGArgumentsLegend.Size = new System.Drawing.Size(147, 192);
            this.FFMPEGArgumentsLegend.TabIndex = 11;
            this.FFMPEGArgumentsLegend.Text = "Legend:\r\n{source}\r\n{destination}\r\n{start}\r\n{end}\r\n{duration}";
            // 
            // FFMPEGArgumentsInput
            // 
            this.FFMPEGArgumentsInput.Location = new System.Drawing.Point(30, 427);
            this.FFMPEGArgumentsInput.Margin = new System.Windows.Forms.Padding(6);
            this.FFMPEGArgumentsInput.Multiline = true;
            this.FFMPEGArgumentsInput.Name = "FFMPEGArgumentsInput";
            this.FFMPEGArgumentsInput.Size = new System.Drawing.Size(663, 458);
            this.FFMPEGArgumentsInput.TabIndex = 9;
            // 
            // ReferenceFrameOffsetLabel
            // 
            this.ReferenceFrameOffsetLabel.AutoSize = true;
            this.ReferenceFrameOffsetLabel.Location = new System.Drawing.Point(290, 147);
            this.ReferenceFrameOffsetLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.ReferenceFrameOffsetLabel.Name = "ReferenceFrameOffsetLabel";
            this.ReferenceFrameOffsetLabel.Size = new System.Drawing.Size(296, 32);
            this.ReferenceFrameOffsetLabel.TabIndex = 3;
            this.ReferenceFrameOffsetLabel.Text = "Reference Frame Offset (s)";
            // 
            // ReferenceFrameOffsetInput
            // 
            this.ReferenceFrameOffsetInput.DecimalPlaces = 1;
            this.ReferenceFrameOffsetInput.Location = new System.Drawing.Point(13, 141);
            this.ReferenceFrameOffsetInput.Margin = new System.Windows.Forms.Padding(6);
            this.ReferenceFrameOffsetInput.Name = "ReferenceFrameOffsetInput";
            this.ReferenceFrameOffsetInput.Size = new System.Drawing.Size(260, 39);
            this.ReferenceFrameOffsetInput.TabIndex = 5;
            this.ReferenceFrameOffsetInput.Tag = "Settings.BlackFrameDuration";
            this.ReferenceFrameOffsetInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DeleteOriginalCheckbox
            // 
            this.DeleteOriginalCheckbox.AutoSize = true;
            this.DeleteOriginalCheckbox.Location = new System.Drawing.Point(13, 323);
            this.DeleteOriginalCheckbox.Margin = new System.Windows.Forms.Padding(6);
            this.DeleteOriginalCheckbox.Name = "DeleteOriginalCheckbox";
            this.DeleteOriginalCheckbox.Size = new System.Drawing.Size(308, 36);
            this.DeleteOriginalCheckbox.TabIndex = 8;
            this.DeleteOriginalCheckbox.Text = "Delete/Replace Originals";
            this.DeleteOriginalCheckbox.UseVisualStyleBackColor = true;
            // 
            // ProcessTypeLabel
            // 
            this.ProcessTypeLabel.AutoSize = true;
            this.ProcessTypeLabel.Location = new System.Drawing.Point(290, 207);
            this.ProcessTypeLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.ProcessTypeLabel.Name = "ProcessTypeLabel";
            this.ProcessTypeLabel.Size = new System.Drawing.Size(219, 32);
            this.ProcessTypeLabel.TabIndex = 3;
            this.ProcessTypeLabel.Text = "Processing Method";
            // 
            // ProcessTypeComboBox
            // 
            this.ProcessTypeComboBox.FormattingEnabled = true;
            this.ProcessTypeComboBox.Location = new System.Drawing.Point(13, 203);
            this.ProcessTypeComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.ProcessTypeComboBox.Name = "ProcessTypeComboBox";
            this.ProcessTypeComboBox.Size = new System.Drawing.Size(257, 40);
            this.ProcessTypeComboBox.TabIndex = 6;
            this.ProcessTypeComboBox.Tag = "Settings.ProcessType";
            // 
            // BlackFrameDurationInput
            // 
            this.BlackFrameDurationInput.DecimalPlaces = 1;
            this.BlackFrameDurationInput.Location = new System.Drawing.Point(13, 15);
            this.BlackFrameDurationInput.Margin = new System.Windows.Forms.Padding(6);
            this.BlackFrameDurationInput.Name = "BlackFrameDurationInput";
            this.BlackFrameDurationInput.Size = new System.Drawing.Size(260, 39);
            this.BlackFrameDurationInput.TabIndex = 5;
            this.BlackFrameDurationInput.Tag = "Settings.BlackFrameDuration";
            this.BlackFrameDurationInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BlackFrameThresholdInput
            // 
            this.BlackFrameThresholdInput.DecimalPlaces = 1;
            this.BlackFrameThresholdInput.Location = new System.Drawing.Point(13, 79);
            this.BlackFrameThresholdInput.Margin = new System.Windows.Forms.Padding(6);
            this.BlackFrameThresholdInput.Name = "BlackFrameThresholdInput";
            this.BlackFrameThresholdInput.Size = new System.Drawing.Size(260, 39);
            this.BlackFrameThresholdInput.TabIndex = 4;
            this.BlackFrameThresholdInput.Tag = "BlackFrameThreshold";
            this.BlackFrameThresholdInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BlackFrameThresholdLabel
            // 
            this.BlackFrameThresholdLabel.AutoSize = true;
            this.BlackFrameThresholdLabel.Location = new System.Drawing.Point(290, 85);
            this.BlackFrameThresholdLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.BlackFrameThresholdLabel.Name = "BlackFrameThresholdLabel";
            this.BlackFrameThresholdLabel.Size = new System.Drawing.Size(255, 32);
            this.BlackFrameThresholdLabel.TabIndex = 3;
            this.BlackFrameThresholdLabel.Text = "Black Frame Threshold";
            // 
            // BlackFrameDurationLabel
            // 
            this.BlackFrameDurationLabel.AutoSize = true;
            this.BlackFrameDurationLabel.Location = new System.Drawing.Point(290, 26);
            this.BlackFrameDurationLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.BlackFrameDurationLabel.Name = "BlackFrameDurationLabel";
            this.BlackFrameDurationLabel.Size = new System.Drawing.Size(273, 32);
            this.BlackFrameDurationLabel.TabIndex = 1;
            this.BlackFrameDurationLabel.Text = "Black Frame Duration (s)";
            // 
            // FFMPEGArgumentsGroupBox
            // 
            this.FFMPEGArgumentsGroupBox.Location = new System.Drawing.Point(13, 387);
            this.FFMPEGArgumentsGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this.FFMPEGArgumentsGroupBox.Name = "FFMPEGArgumentsGroupBox";
            this.FFMPEGArgumentsGroupBox.Padding = new System.Windows.Forms.Padding(6);
            this.FFMPEGArgumentsGroupBox.Size = new System.Drawing.Size(861, 525);
            this.FFMPEGArgumentsGroupBox.TabIndex = 10;
            this.FFMPEGArgumentsGroupBox.TabStop = false;
            this.FFMPEGArgumentsGroupBox.Text = "FFMPEG Arguments";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.startIndexNumericUpDown1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.RenameOriginalCheckBox);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.RenameTypeComboBox);
            this.tabPage2.Controls.Add(this.RenameLabel);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.FindTextBox);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.NewTextTextBox);
            this.tabPage2.Location = new System.Drawing.Point(8, 46);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(895, 945);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rename";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RenameOriginalCheckBox
            // 
            this.RenameOriginalCheckBox.AutoSize = true;
            this.RenameOriginalCheckBox.Location = new System.Drawing.Point(19, 213);
            this.RenameOriginalCheckBox.Name = "RenameOriginalCheckBox";
            this.RenameOriginalCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RenameOriginalCheckBox.Size = new System.Drawing.Size(223, 36);
            this.RenameOriginalCheckBox.TabIndex = 19;
            this.RenameOriginalCheckBox.Text = "Rename Original";
            this.RenameOriginalCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RenameOriginalCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "Type";
            // 
            // RenameTypeComboBox
            // 
            this.RenameTypeComboBox.FormattingEnabled = true;
            this.RenameTypeComboBox.Location = new System.Drawing.Point(214, 151);
            this.RenameTypeComboBox.Name = "RenameTypeComboBox";
            this.RenameTypeComboBox.Size = new System.Drawing.Size(250, 40);
            this.RenameTypeComboBox.TabIndex = 16;
            // 
            // RenameLabel
            // 
            this.RenameLabel.AutoSize = true;
            this.RenameLabel.Location = new System.Drawing.Point(18, 90);
            this.RenameLabel.Name = "RenameLabel";
            this.RenameLabel.Size = new System.Drawing.Size(96, 32);
            this.RenameLabel.TabIndex = 15;
            this.RenameLabel.Text = "Replace";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "Find";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(18, 428);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 283);
            this.panel2.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(848, 281);
            this.label5.TabIndex = 2;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // FindTextBox
            // 
            this.FindTextBox.Location = new System.Drawing.Point(214, 21);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(653, 39);
            this.FindTextBox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ResultLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.OriginalLabel);
            this.panel1.Location = new System.Drawing.Point(18, 752);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 137);
            this.panel1.TabIndex = 11;
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(167, 88);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(250, 32);
            this.ResultLabel.TabIndex = 3;
            this.ResultLabel.Text = "ExampleFilename.mkv";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "After:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Before:";
            // 
            // OriginalLabel
            // 
            this.OriginalLabel.AutoSize = true;
            this.OriginalLabel.Location = new System.Drawing.Point(167, 21);
            this.OriginalLabel.Name = "OriginalLabel";
            this.OriginalLabel.Size = new System.Drawing.Size(253, 32);
            this.OriginalLabel.TabIndex = 0;
            this.OriginalLabel.Text = "ExampleFilename.mp4";
            // 
            // NewTextTextBox
            // 
            this.NewTextTextBox.Location = new System.Drawing.Point(214, 87);
            this.NewTextTextBox.Name = "NewTextTextBox";
            this.NewTextTextBox.Size = new System.Drawing.Size(653, 39);
            this.NewTextTextBox.TabIndex = 2;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(790, 1054);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(6);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(139, 49);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 32);
            this.label6.TabIndex = 20;
            this.label6.Text = "Start Index";
            // 
            // startIndexNumericUpDown1
            // 
            this.startIndexNumericUpDown1.Location = new System.Drawing.Point(214, 276);
            this.startIndexNumericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.startIndexNumericUpDown1.Name = "startIndexNumericUpDown1";
            this.startIndexNumericUpDown1.Size = new System.Drawing.Size(131, 39);
            this.startIndexNumericUpDown1.TabIndex = 21;
            this.startIndexNumericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(953, 1127);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReferenceFrameOffsetInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameDurationInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameThresholdInput)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startIndexNumericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label BlackFrameThresholdLabel;
        private System.Windows.Forms.Label BlackFrameDurationLabel;
        private System.Windows.Forms.NumericUpDown BlackFrameDurationInput;
        private System.Windows.Forms.NumericUpDown BlackFrameThresholdInput;
        private System.Windows.Forms.Label ProcessTypeLabel;
        private System.Windows.Forms.ComboBox ProcessTypeComboBox;
        private System.Windows.Forms.Label FFMPEGArgumentsLegend;
        private System.Windows.Forms.TextBox FFMPEGArgumentsInput;
        private System.Windows.Forms.Label ReferenceFrameOffsetLabel;
        private System.Windows.Forms.NumericUpDown ReferenceFrameOffsetInput;
        private System.Windows.Forms.CheckBox DeleteOriginalCheckbox;
        private System.Windows.Forms.GroupBox FFMPEGArgumentsGroupBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox ShowLogCheckbox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FindTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label OriginalLabel;
        private System.Windows.Forms.TextBox NewTextTextBox;
        private System.Windows.Forms.Label RenameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RenameTypeComboBox;
        private System.Windows.Forms.CheckBox RenameOriginalCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown startIndexNumericUpDown1;
    }
}