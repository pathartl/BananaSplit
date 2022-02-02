
namespace BananaSplit
{
    partial class LogForm
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
            this.LogRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogRichTextBox
            // 
            this.LogRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogRichTextBox.BackColor = System.Drawing.Color.Black;
            this.LogRichTextBox.ForeColor = System.Drawing.Color.White;
            this.LogRichTextBox.HideSelection = false;
            this.LogRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.LogRichTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 43, 23);
            this.LogRichTextBox.Name = "LogRichTextBox";
            this.LogRichTextBox.ReadOnly = true;
            this.LogRichTextBox.Size = new System.Drawing.Size(1366, 813);
            this.LogRichTextBox.TabIndex = 0;
            this.LogRichTextBox.Text = "";
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(1206, 839);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(150, 46);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 897);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.LogRichTextBox);
            this.Name = "LogForm";
            this.ShowIcon = false;
            this.Text = "Log";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox LogRichTextBox;
        private System.Windows.Forms.Button ClearButton;
    }
}