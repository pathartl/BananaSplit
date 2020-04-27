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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BlackFrameDurationInput = new System.Windows.Forms.TextBox();
            this.BlackFrameDurationLabel = new System.Windows.Forms.Label();
            this.BlackFrameThresholdInput = new System.Windows.Forms.TextBox();
            this.BlackFrameThresholdLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BlackFrameThresholdLabel);
            this.tabPage1.Controls.Add(this.BlackFrameThresholdInput);
            this.tabPage1.Controls.Add(this.BlackFrameDurationLabel);
            this.tabPage1.Controls.Add(this.BlackFrameDurationInput);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BlackFrameDurationInput
            // 
            this.BlackFrameDurationInput.Location = new System.Drawing.Point(6, 6);
            this.BlackFrameDurationInput.Name = "BlackFrameDurationInput";
            this.BlackFrameDurationInput.Size = new System.Drawing.Size(100, 20);
            this.BlackFrameDurationInput.TabIndex = 0;
            // 
            // BlackFrameDurationLabel
            // 
            this.BlackFrameDurationLabel.AutoSize = true;
            this.BlackFrameDurationLabel.Location = new System.Drawing.Point(113, 10);
            this.BlackFrameDurationLabel.Name = "BlackFrameDurationLabel";
            this.BlackFrameDurationLabel.Size = new System.Drawing.Size(123, 13);
            this.BlackFrameDurationLabel.TabIndex = 1;
            this.BlackFrameDurationLabel.Text = "Black Frame Duration (s)";
            // 
            // BlackFrameThresholdInput
            // 
            this.BlackFrameThresholdInput.Location = new System.Drawing.Point(6, 32);
            this.BlackFrameThresholdInput.Name = "BlackFrameThresholdInput";
            this.BlackFrameThresholdInput.Size = new System.Drawing.Size(100, 20);
            this.BlackFrameThresholdInput.TabIndex = 2;
            // 
            // BlackFrameThresholdLabel
            // 
            this.BlackFrameThresholdLabel.AutoSize = true;
            this.BlackFrameThresholdLabel.Location = new System.Drawing.Point(113, 35);
            this.BlackFrameThresholdLabel.Name = "BlackFrameThresholdLabel";
            this.BlackFrameThresholdLabel.Size = new System.Drawing.Size(116, 13);
            this.BlackFrameThresholdLabel.TabIndex = 3;
            this.BlackFrameThresholdLabel.Text = "Black Frame Threshold";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label BlackFrameThresholdLabel;
        private System.Windows.Forms.TextBox BlackFrameThresholdInput;
        private System.Windows.Forms.Label BlackFrameDurationLabel;
        private System.Windows.Forms.TextBox BlackFrameDurationInput;
    }
}