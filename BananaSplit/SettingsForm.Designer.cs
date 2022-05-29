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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BlackFramePixelThresholdInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowLogCheckbox = new System.Windows.Forms.CheckBox();
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
            this.FFMPEGArgumentsInput = new System.Windows.Forms.TextBox();
            this.FFMPEGArgumentsLegend = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFramePixelThresholdInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReferenceFrameOffsetInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameDurationInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameThresholdInput)).BeginInit();
            this.FFMPEGArgumentsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(912, 862);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BlackFramePixelThresholdInput);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ShowLogCheckbox);
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
            this.tabPage1.Size = new System.Drawing.Size(896, 808);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BlackFramePixelThresholdInput
            // 
            this.BlackFramePixelThresholdInput.DecimalPlaces = 1;
            this.BlackFramePixelThresholdInput.Location = new System.Drawing.Point(13, 117);
            this.BlackFramePixelThresholdInput.Margin = new System.Windows.Forms.Padding(6);
            this.BlackFramePixelThresholdInput.Name = "BlackFramePixelThresholdInput";
            this.BlackFramePixelThresholdInput.Size = new System.Drawing.Size(260, 39);
            this.BlackFramePixelThresholdInput.TabIndex = 12;
            this.BlackFramePixelThresholdInput.Tag = "BlackFramePixelThreshold";
            this.BlackFramePixelThresholdInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "Black Pixel Threshold";
            // 
            // ShowLogCheckbox
            // 
            this.ShowLogCheckbox.AutoSize = true;
            this.ShowLogCheckbox.Location = new System.Drawing.Point(13, 268);
            this.ShowLogCheckbox.Name = "ShowLogCheckbox";
            this.ShowLogCheckbox.Size = new System.Drawing.Size(150, 36);
            this.ShowLogCheckbox.TabIndex = 7;
            this.ShowLogCheckbox.Text = "Show Log";
            this.ShowLogCheckbox.UseVisualStyleBackColor = true;
            // 
            // ReferenceFrameOffsetLabel
            // 
            this.ReferenceFrameOffsetLabel.AutoSize = true;
            this.ReferenceFrameOffsetLabel.Location = new System.Drawing.Point(290, 170);
            this.ReferenceFrameOffsetLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.ReferenceFrameOffsetLabel.Name = "ReferenceFrameOffsetLabel";
            this.ReferenceFrameOffsetLabel.Size = new System.Drawing.Size(296, 32);
            this.ReferenceFrameOffsetLabel.TabIndex = 3;
            this.ReferenceFrameOffsetLabel.Text = "Reference Frame Offset (s)";
            // 
            // ReferenceFrameOffsetInput
            // 
            this.ReferenceFrameOffsetInput.DecimalPlaces = 1;
            this.ReferenceFrameOffsetInput.Location = new System.Drawing.Point(13, 168);
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
            this.DeleteOriginalCheckbox.Location = new System.Drawing.Point(13, 313);
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
            this.ProcessTypeLabel.Location = new System.Drawing.Point(290, 222);
            this.ProcessTypeLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.ProcessTypeLabel.Name = "ProcessTypeLabel";
            this.ProcessTypeLabel.Size = new System.Drawing.Size(219, 32);
            this.ProcessTypeLabel.TabIndex = 3;
            this.ProcessTypeLabel.Text = "Processing Method";
            // 
            // ProcessTypeComboBox
            // 
            this.ProcessTypeComboBox.FormattingEnabled = true;
            this.ProcessTypeComboBox.Location = new System.Drawing.Point(13, 219);
            this.ProcessTypeComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.ProcessTypeComboBox.Name = "ProcessTypeComboBox";
            this.ProcessTypeComboBox.Size = new System.Drawing.Size(260, 40);
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
            this.BlackFrameThresholdInput.Location = new System.Drawing.Point(13, 66);
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
            this.BlackFrameThresholdLabel.Location = new System.Drawing.Point(290, 68);
            this.BlackFrameThresholdLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.BlackFrameThresholdLabel.Name = "BlackFrameThresholdLabel";
            this.BlackFrameThresholdLabel.Size = new System.Drawing.Size(255, 32);
            this.BlackFrameThresholdLabel.TabIndex = 3;
            this.BlackFrameThresholdLabel.Text = "Black Frame Threshold";
            // 
            // BlackFrameDurationLabel
            // 
            this.BlackFrameDurationLabel.AutoSize = true;
            this.BlackFrameDurationLabel.Location = new System.Drawing.Point(290, 17);
            this.BlackFrameDurationLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.BlackFrameDurationLabel.Name = "BlackFrameDurationLabel";
            this.BlackFrameDurationLabel.Size = new System.Drawing.Size(273, 32);
            this.BlackFrameDurationLabel.TabIndex = 1;
            this.BlackFrameDurationLabel.Text = "Black Frame Duration (s)";
            // 
            // FFMPEGArgumentsGroupBox
            // 
            this.FFMPEGArgumentsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FFMPEGArgumentsGroupBox.Controls.Add(this.FFMPEGArgumentsInput);
            this.FFMPEGArgumentsGroupBox.Controls.Add(this.FFMPEGArgumentsLegend);
            this.FFMPEGArgumentsGroupBox.Location = new System.Drawing.Point(13, 361);
            this.FFMPEGArgumentsGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this.FFMPEGArgumentsGroupBox.Name = "FFMPEGArgumentsGroupBox";
            this.FFMPEGArgumentsGroupBox.Padding = new System.Windows.Forms.Padding(6);
            this.FFMPEGArgumentsGroupBox.Size = new System.Drawing.Size(862, 435);
            this.FFMPEGArgumentsGroupBox.TabIndex = 10;
            this.FFMPEGArgumentsGroupBox.TabStop = false;
            this.FFMPEGArgumentsGroupBox.Text = "FFMPEG Arguments";
            // 
            // FFMPEGArgumentsInput
            // 
            this.FFMPEGArgumentsInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FFMPEGArgumentsInput.Location = new System.Drawing.Point(12, 44);
            this.FFMPEGArgumentsInput.Margin = new System.Windows.Forms.Padding(6);
            this.FFMPEGArgumentsInput.Multiline = true;
            this.FFMPEGArgumentsInput.Name = "FFMPEGArgumentsInput";
            this.FFMPEGArgumentsInput.Size = new System.Drawing.Size(664, 379);
            this.FFMPEGArgumentsInput.TabIndex = 9;
            // 
            // FFMPEGArgumentsLegend
            // 
            this.FFMPEGArgumentsLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FFMPEGArgumentsLegend.AutoSize = true;
            this.FFMPEGArgumentsLegend.Location = new System.Drawing.Point(688, 47);
            this.FFMPEGArgumentsLegend.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.FFMPEGArgumentsLegend.Name = "FFMPEGArgumentsLegend";
            this.FFMPEGArgumentsLegend.Size = new System.Drawing.Size(147, 192);
            this.FFMPEGArgumentsLegend.TabIndex = 11;
            this.FFMPEGArgumentsLegend.Text = "Legend:\r\n{source}\r\n{destination}\r\n{start}\r\n{end}\r\n{duration}";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(790, 889);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(6);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(139, 49);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(944, 953);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFramePixelThresholdInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReferenceFrameOffsetInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameDurationInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlackFrameThresholdInput)).EndInit();
            this.FFMPEGArgumentsGroupBox.ResumeLayout(false);
            this.FFMPEGArgumentsGroupBox.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown BlackFramePixelThresholdInput;
        private System.Windows.Forms.Label label1;
    }
}