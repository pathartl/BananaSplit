
namespace BananaSplit
{
    partial class RenameForm
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
            this.NewTextTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PrefixRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuffixRadioButton = new System.Windows.Forms.RadioButton();
            this.AppendAfterRadioButton = new System.Windows.Forms.RadioButton();
            this.ReplaceRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewTextTextBox
            // 
            this.NewTextTextBox.Location = new System.Drawing.Point(33, 0);
            this.NewTextTextBox.Name = "NewTextTextBox";
            this.NewTextTextBox.Size = new System.Drawing.Size(382, 39);
            this.NewTextTextBox.TabIndex = 1;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(1273, 550);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(150, 46);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // PrefixRadioButton
            // 
            this.PrefixRadioButton.AutoSize = true;
            this.PrefixRadioButton.Location = new System.Drawing.Point(33, 68);
            this.PrefixRadioButton.Name = "PrefixRadioButton";
            this.PrefixRadioButton.Size = new System.Drawing.Size(104, 36);
            this.PrefixRadioButton.TabIndex = 5;
            this.PrefixRadioButton.TabStop = true;
            this.PrefixRadioButton.Text = "Prefix";
            this.PrefixRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReplaceRadioButton);
            this.groupBox1.Controls.Add(this.AppendAfterRadioButton);
            this.groupBox1.Controls.Add(this.SuffixRadioButton);
            this.groupBox1.Controls.Add(this.NewTextTextBox);
            this.groupBox1.Controls.Add(this.PrefixRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(50, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 280);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // SuffixRadioButton
            // 
            this.SuffixRadioButton.AutoSize = true;
            this.SuffixRadioButton.Location = new System.Drawing.Point(33, 123);
            this.SuffixRadioButton.Name = "SuffixRadioButton";
            this.SuffixRadioButton.Size = new System.Drawing.Size(105, 36);
            this.SuffixRadioButton.TabIndex = 6;
            this.SuffixRadioButton.TabStop = true;
            this.SuffixRadioButton.Text = "Suffix";
            this.SuffixRadioButton.UseVisualStyleBackColor = true;
            // 
            // AppendAfterRadioButton
            // 
            this.AppendAfterRadioButton.AutoSize = true;
            this.AppendAfterRadioButton.Location = new System.Drawing.Point(33, 182);
            this.AppendAfterRadioButton.Name = "AppendAfterRadioButton";
            this.AppendAfterRadioButton.Size = new System.Drawing.Size(185, 36);
            this.AppendAfterRadioButton.TabIndex = 7;
            this.AppendAfterRadioButton.TabStop = true;
            this.AppendAfterRadioButton.Text = "Append after";
            this.AppendAfterRadioButton.UseVisualStyleBackColor = true;
            // 
            // ReplaceRadioButton
            // 
            this.ReplaceRadioButton.AutoSize = true;
            this.ReplaceRadioButton.Location = new System.Drawing.Point(33, 238);
            this.ReplaceRadioButton.Name = "ReplaceRadioButton";
            this.ReplaceRadioButton.Size = new System.Drawing.Size(127, 36);
            this.ReplaceRadioButton.TabIndex = 8;
            this.ReplaceRadioButton.TabStop = true;
            this.ReplaceRadioButton.Text = "Replace";
            this.ReplaceRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ResultLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(83, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 137);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filename.mp4";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "After:";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(167, 88);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(161, 32);
            this.ResultLabel.TabIndex = 3;
            this.ResultLabel.Text = "Filename.mkv";
            // 
            // FindTextBox
            // 
            this.FindTextBox.Location = new System.Drawing.Point(83, 40);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(382, 39);
            this.FindTextBox.TabIndex = 9;
            // 
            // RenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 608);
            this.Controls.Add(this.FindTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveButton);
            this.Name = "RenameForm";
            this.ShowIcon = false;
            this.Text = "Rename";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox NewTextTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.RadioButton PrefixRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ReplaceRadioButton;
        private System.Windows.Forms.RadioButton AppendAfterRadioButton;
        private System.Windows.Forms.RadioButton SuffixRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FindTextBox;
    }
}