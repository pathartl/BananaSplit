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
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.FileMenuDropdown = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFilesToQueueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFolderToQueueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenuDropdown = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileBrowserSplitContainer = new System.Windows.Forms.SplitContainer();
            this.QueueList = new System.Windows.Forms.ListView();
            this.FileName = new System.Windows.Forms.ColumnHeader();
            this.ReferenceImageListView = new System.Windows.Forms.ListView();
            this.ReferenceImageList = new System.Windows.Forms.ImageList(this.components);
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ActionBarPanel = new System.Windows.Forms.Panel();
            this.ProcessQueueButton = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileBrowserSplitContainer)).BeginInit();
            this.FileBrowserSplitContainer.Panel1.SuspendLayout();
            this.FileBrowserSplitContainer.Panel2.SuspendLayout();
            this.FileBrowserSplitContainer.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.ContainerPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.ActionBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuDropdown,
            this.OptionsMenuDropdown});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.Menu.Size = new System.Drawing.Size(933, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // FileMenuDropdown
            // 
            this.FileMenuDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFilesToQueueMenuItem,
            this.AddFolderToQueueMenuItem});
            this.FileMenuDropdown.Name = "FileMenuDropdown";
            this.FileMenuDropdown.Size = new System.Drawing.Size(37, 20);
            this.FileMenuDropdown.Text = "File";
            // 
            // AddFilesToQueueMenuItem
            // 
            this.AddFilesToQueueMenuItem.Name = "AddFilesToQueueMenuItem";
            this.AddFilesToQueueMenuItem.Size = new System.Drawing.Size(184, 22);
            this.AddFilesToQueueMenuItem.Text = "Add File(s) to Queue";
            // 
            // AddFolderToQueueMenuItem
            // 
            this.AddFolderToQueueMenuItem.Name = "AddFolderToQueueMenuItem";
            this.AddFolderToQueueMenuItem.Size = new System.Drawing.Size(184, 22);
            this.AddFolderToQueueMenuItem.Text = "Add Folder to Queue";
            // 
            // OptionsMenuDropdown
            // 
            this.OptionsMenuDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenuItem,
            this.AboutMenuItem});
            this.OptionsMenuDropdown.Name = "OptionsMenuDropdown";
            this.OptionsMenuDropdown.Size = new System.Drawing.Size(61, 20);
            this.OptionsMenuDropdown.Text = "Options";
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(116, 22);
            this.SettingsMenuItem.Text = "Settings";
            this.SettingsMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(116, 22);
            this.AboutMenuItem.Text = "About";
            // 
            // FileBrowserSplitContainer
            // 
            this.FileBrowserSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileBrowserSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.FileBrowserSplitContainer.Location = new System.Drawing.Point(4, 3);
            this.FileBrowserSplitContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 58);
            this.FileBrowserSplitContainer.Name = "FileBrowserSplitContainer";
            // 
            // FileBrowserSplitContainer.Panel1
            // 
            this.FileBrowserSplitContainer.Panel1.Controls.Add(this.QueueList);
            // 
            // FileBrowserSplitContainer.Panel2
            // 
            this.FileBrowserSplitContainer.Panel2.Controls.Add(this.ReferenceImageListView);
            this.FileBrowserSplitContainer.Size = new System.Drawing.Size(925, 327);
            this.FileBrowserSplitContainer.SplitterDistance = 264;
            this.FileBrowserSplitContainer.SplitterWidth = 5;
            this.FileBrowserSplitContainer.TabIndex = 1;
            // 
            // QueueList
            // 
            this.QueueList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName});
            this.QueueList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueueList.HideSelection = false;
            this.QueueList.Location = new System.Drawing.Point(0, 0);
            this.QueueList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.QueueList.Name = "QueueList";
            this.QueueList.ShowItemToolTips = true;
            this.QueueList.Size = new System.Drawing.Size(264, 327);
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
            this.ReferenceImageListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ReferenceImageListView.Name = "ReferenceImageListView";
            this.ReferenceImageListView.Size = new System.Drawing.Size(656, 327);
            this.ReferenceImageListView.SmallImageList = this.ReferenceImageList;
            this.ReferenceImageListView.TabIndex = 0;
            this.ReferenceImageListView.UseCompatibleStateImageBehavior = false;
            this.ReferenceImageListView.SelectedIndexChanged += new System.EventHandler(this.ReferenceImageListView_SelectedIndexChanged);
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
            this.StatusBar.Location = new System.Drawing.Point(0, 393);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusBar.Size = new System.Drawing.Size(933, 24);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "StatusBar";
            // 
            // StatusBarProgressBar
            // 
            this.StatusBarProgressBar.Name = "StatusBarProgressBar";
            this.StatusBarProgressBar.Size = new System.Drawing.Size(117, 18);
            // 
            // StatusBarLabel
            // 
            this.StatusBarLabel.Name = "StatusBarLabel";
            this.StatusBarLabel.Size = new System.Drawing.Size(0, 19);
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Controls.Add(this.MainPanel);
            this.ContainerPanel.Controls.Add(this.ActionBarPanel);
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.ContainerPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Padding = new System.Windows.Forms.Padding(0, 29, 0, 0);
            this.ContainerPanel.Size = new System.Drawing.Size(933, 393);
            this.ContainerPanel.TabIndex = 4;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.FileBrowserSplitContainer);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 29);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MainPanel.Size = new System.Drawing.Size(933, 333);
            this.MainPanel.TabIndex = 1;
            // 
            // ActionBarPanel
            // 
            this.ActionBarPanel.Controls.Add(this.ProcessQueueButton);
            this.ActionBarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ActionBarPanel.Location = new System.Drawing.Point(0, 362);
            this.ActionBarPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ActionBarPanel.Name = "ActionBarPanel";
            this.ActionBarPanel.Size = new System.Drawing.Size(933, 31);
            this.ActionBarPanel.TabIndex = 5;
            // 
            // ProcessQueueButton
            // 
            this.ProcessQueueButton.AutoSize = true;
            this.ProcessQueueButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ProcessQueueButton.Location = new System.Drawing.Point(822, 0);
            this.ProcessQueueButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ProcessQueueButton.Name = "ProcessQueueButton";
            this.ProcessQueueButton.Size = new System.Drawing.Size(111, 31);
            this.ProcessQueueButton.TabIndex = 0;
            this.ProcessQueueButton.Text = "Process Queue";
            this.ProcessQueueButton.UseVisualStyleBackColor = true;
            this.ProcessQueueButton.Click += new System.EventHandler(this.ProcessQueueButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 417);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.ContainerPanel);
            this.Controls.Add(this.StatusBar);
            this.MainMenuStrip = this.Menu;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "BananaSplit";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.FileBrowserSplitContainer.Panel1.ResumeLayout(false);
            this.FileBrowserSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileBrowserSplitContainer)).EndInit();
            this.FileBrowserSplitContainer.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ContainerPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.ActionBarPanel.ResumeLayout(false);
            this.ActionBarPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenuDropdown;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.SplitContainer FileBrowserSplitContainer;
        private System.Windows.Forms.ImageList ReferenceImageList;
        private System.Windows.Forms.ListView QueueList;
        private System.Windows.Forms.ToolStripMenuItem FileMenuDropdown;
        private System.Windows.Forms.ToolStripMenuItem AddFilesToQueueMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddFolderToQueueMenuItem;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ListView ReferenceImageListView;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripProgressBar StatusBarProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel;
        private System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.Panel ActionBarPanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button ProcessQueueButton;
    }
}

