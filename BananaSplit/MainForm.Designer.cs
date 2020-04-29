namespace BananaSplit
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addFilesToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToQueueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileBrowserSplitContainer = new System.Windows.Forms.SplitContainer();
            this.QueueList = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReferenceImageListView = new System.Windows.Forms.ListView();
            this.ReferenceImageList = new System.Windows.Forms.ImageList(this.components);
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileBrowserSplitContainer)).BeginInit();
            this.FileBrowserSplitContainer.Panel1.SuspendLayout();
            this.FileBrowserSplitContainer.Panel2.SuspendLayout();
            this.FileBrowserSplitContainer.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToQueueToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addFilesToQueueToolStripMenuItem
            // 
            this.addFilesToQueueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToQueueToolStripMenuItem1,
            this.addFolderToQueueToolStripMenuItem});
            this.addFilesToQueueToolStripMenuItem.Name = "addFilesToQueueToolStripMenuItem";
            this.addFilesToQueueToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.addFilesToQueueToolStripMenuItem.Text = "File";
            // 
            // addFilesToQueueToolStripMenuItem1
            // 
            this.addFilesToQueueToolStripMenuItem1.Name = "addFilesToQueueToolStripMenuItem1";
            this.addFilesToQueueToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.addFilesToQueueToolStripMenuItem1.Text = "Add File(s) to Queue";
            // 
            // addFolderToQueueToolStripMenuItem
            // 
            this.addFolderToQueueToolStripMenuItem.Name = "addFolderToQueueToolStripMenuItem";
            this.addFolderToQueueToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addFolderToQueueToolStripMenuItem.Text = "Add Folder to Queue";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // FileBrowserSplitContainer
            // 
            this.FileBrowserSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileBrowserSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.FileBrowserSplitContainer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.FileBrowserSplitContainer.Name = "FileBrowserSplitContainer";
            // 
            // FileBrowserSplitContainer.Panel1
            // 
            this.FileBrowserSplitContainer.Panel1.Controls.Add(this.QueueList);
            this.FileBrowserSplitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // FileBrowserSplitContainer.Panel2
            // 
            this.FileBrowserSplitContainer.Panel2.Controls.Add(this.ReferenceImageListView);
            this.FileBrowserSplitContainer.Size = new System.Drawing.Size(800, 315);
            this.FileBrowserSplitContainer.SplitterDistance = 266;
            this.FileBrowserSplitContainer.TabIndex = 1;
            // 
            // QueueList
            // 
            this.QueueList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName});
            this.QueueList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueueList.HideSelection = false;
            this.QueueList.Location = new System.Drawing.Point(0, 0);
            this.QueueList.Name = "QueueList";
            this.QueueList.ShowItemToolTips = true;
            this.QueueList.Size = new System.Drawing.Size(266, 315);
            this.QueueList.TabIndex = 0;
            this.QueueList.UseCompatibleStateImageBehavior = false;
            this.QueueList.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "Filename";
            this.FileName.Width = 260;
            // 
            // ReferenceImageListView
            // 
            this.ReferenceImageListView.CheckBoxes = true;
            this.ReferenceImageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReferenceImageListView.HideSelection = false;
            this.ReferenceImageListView.LargeImageList = this.ReferenceImageList;
            this.ReferenceImageListView.Location = new System.Drawing.Point(0, 0);
            this.ReferenceImageListView.Name = "ReferenceImageListView";
            this.ReferenceImageListView.Size = new System.Drawing.Size(530, 315);
            this.ReferenceImageListView.SmallImageList = this.ReferenceImageList;
            this.ReferenceImageListView.TabIndex = 0;
            this.ReferenceImageListView.UseCompatibleStateImageBehavior = false;
            // 
            // ReferenceImageList
            // 
            this.ReferenceImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ReferenceImageList.ImageSize = new System.Drawing.Size(256, 256);
            this.ReferenceImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarProgressBar,
            this.StatusBarLabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 339);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(800, 22);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "StatusBar";
            // 
            // StatusBarProgressBar
            // 
            this.StatusBarProgressBar.Name = "StatusBarProgressBar";
            this.StatusBarProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // StatusBarLabel
            // 
            this.StatusBarLabel.Name = "StatusBarLabel";
            this.StatusBarLabel.Size = new System.Drawing.Size(84, 17);
            this.StatusBarLabel.Text = "StatusBarLabel";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 361);
            this.Controls.Add(this.FileBrowserSplitContainer);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.StatusBar);
            this.Name = "MainForm";
            this.Text = "BananaSplit";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.FileBrowserSplitContainer.Panel1.ResumeLayout(false);
            this.FileBrowserSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileBrowserSplitContainer)).EndInit();
            this.FileBrowserSplitContainer.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer FileBrowserSplitContainer;
        private System.Windows.Forms.ImageList ReferenceImageList;
        private System.Windows.Forms.ListView QueueList;
        private System.Windows.Forms.ToolStripMenuItem addFilesToQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesToQueueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addFolderToQueueToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ListView ReferenceImageListView;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripProgressBar StatusBarProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel;
    }
}

