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
            this.QueueItemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.QueueItemContextMenuProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.QueueItemContextMenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.QueueListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.QueueListContextMenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.QueueListContextMenuProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileBrowserSplitContainer)).BeginInit();
            this.FileBrowserSplitContainer.Panel1.SuspendLayout();
            this.FileBrowserSplitContainer.Panel2.SuspendLayout();
            this.FileBrowserSplitContainer.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.ContainerPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.ActionBarPanel.SuspendLayout();
            this.QueueItemContextMenu.SuspendLayout();
            this.QueueListContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuDropdown,
            this.OptionsMenuDropdown});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(13, 4, 0, 4);
            this.Menu.Size = new System.Drawing.Size(1733, 44);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // FileMenuDropdown
            // 
            this.FileMenuDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFilesToQueueMenuItem,
            this.AddFolderToQueueMenuItem});
            this.FileMenuDropdown.Name = "FileMenuDropdown";
            this.FileMenuDropdown.Size = new System.Drawing.Size(71, 36);
            this.FileMenuDropdown.Text = "File";
            // 
            // AddFilesToQueueMenuItem
            // 
            this.AddFilesToQueueMenuItem.Name = "AddFilesToQueueMenuItem";
            this.AddFilesToQueueMenuItem.Size = new System.Drawing.Size(372, 44);
            this.AddFilesToQueueMenuItem.Text = "Add File(s) to Queue";
            // 
            // AddFolderToQueueMenuItem
            // 
            this.AddFolderToQueueMenuItem.Name = "AddFolderToQueueMenuItem";
            this.AddFolderToQueueMenuItem.Size = new System.Drawing.Size(372, 44);
            this.AddFolderToQueueMenuItem.Text = "Add Folder to Queue";
            // 
            // OptionsMenuDropdown
            // 
            this.OptionsMenuDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenuItem,
            this.AboutMenuItem});
            this.OptionsMenuDropdown.Name = "OptionsMenuDropdown";
            this.OptionsMenuDropdown.Size = new System.Drawing.Size(118, 36);
            this.OptionsMenuDropdown.Text = "Options";
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(233, 44);
            this.SettingsMenuItem.Text = "Settings";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(233, 44);
            this.AboutMenuItem.Text = "About";
            // 
            // FileBrowserSplitContainer
            // 
            this.FileBrowserSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileBrowserSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.FileBrowserSplitContainer.Location = new System.Drawing.Point(7, 6);
            this.FileBrowserSplitContainer.Margin = new System.Windows.Forms.Padding(7, 6, 7, 124);
            this.FileBrowserSplitContainer.Name = "FileBrowserSplitContainer";
            // 
            // FileBrowserSplitContainer.Panel1
            // 
            this.FileBrowserSplitContainer.Panel1.Controls.Add(this.QueueList);
            // 
            // FileBrowserSplitContainer.Panel2
            // 
            this.FileBrowserSplitContainer.Panel2.Controls.Add(this.ReferenceImageListView);
            this.FileBrowserSplitContainer.Size = new System.Drawing.Size(1719, 712);
            this.FileBrowserSplitContainer.SplitterDistance = 264;
            this.FileBrowserSplitContainer.SplitterWidth = 9;
            this.FileBrowserSplitContainer.TabIndex = 1;
            // 
            // QueueList
            // 
            this.QueueList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName});
            this.QueueList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueueList.HideSelection = false;
            this.QueueList.Location = new System.Drawing.Point(0, 0);
            this.QueueList.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.QueueList.Name = "QueueList";
            this.QueueList.ShowItemToolTips = true;
            this.QueueList.Size = new System.Drawing.Size(264, 712);
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
            this.ReferenceImageListView.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ReferenceImageListView.Name = "ReferenceImageListView";
            this.ReferenceImageListView.Size = new System.Drawing.Size(1446, 712);
            this.ReferenceImageListView.SmallImageList = this.ReferenceImageList;
            this.ReferenceImageListView.TabIndex = 0;
            this.ReferenceImageListView.UseCompatibleStateImageBehavior = false;
            this.ReferenceImageListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ReferenceImageListView_SelectedIndexChanged);
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
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarProgressBar,
            this.StatusBarLabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 852);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(2, 0, 30, 0);
            this.StatusBar.Size = new System.Drawing.Size(1733, 38);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "StatusBar";
            // 
            // StatusBarProgressBar
            // 
            this.StatusBarProgressBar.Name = "StatusBarProgressBar";
            this.StatusBarProgressBar.Size = new System.Drawing.Size(217, 26);
            // 
            // StatusBarLabel
            // 
            this.StatusBarLabel.Name = "StatusBarLabel";
            this.StatusBarLabel.Size = new System.Drawing.Size(0, 28);
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Controls.Add(this.MainPanel);
            this.ContainerPanel.Controls.Add(this.ActionBarPanel);
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.ContainerPanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Padding = new System.Windows.Forms.Padding(0, 62, 0, 0);
            this.ContainerPanel.Size = new System.Drawing.Size(1733, 852);
            this.ContainerPanel.TabIndex = 4;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.FileBrowserSplitContainer);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 62);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MainPanel.Size = new System.Drawing.Size(1733, 724);
            this.MainPanel.TabIndex = 1;
            // 
            // ActionBarPanel
            // 
            this.ActionBarPanel.Controls.Add(this.ProcessQueueButton);
            this.ActionBarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ActionBarPanel.Location = new System.Drawing.Point(0, 786);
            this.ActionBarPanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ActionBarPanel.Name = "ActionBarPanel";
            this.ActionBarPanel.Size = new System.Drawing.Size(1733, 66);
            this.ActionBarPanel.TabIndex = 5;
            // 
            // ProcessQueueButton
            // 
            this.ProcessQueueButton.AutoSize = true;
            this.ProcessQueueButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ProcessQueueButton.Location = new System.Drawing.Point(1395, 0);
            this.ProcessQueueButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ProcessQueueButton.Name = "ProcessQueueButton";
            this.ProcessQueueButton.Size = new System.Drawing.Size(338, 66);
            this.ProcessQueueButton.TabIndex = 0;
            this.ProcessQueueButton.Text = "Process Queue";
            this.ProcessQueueButton.UseVisualStyleBackColor = true;
            // 
            // QueueItemContextMenu
            // 
            this.QueueItemContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.QueueItemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QueueItemContextMenuProcess,
            this.QueueItemContextMenuRemove});
            this.QueueItemContextMenu.Name = "QueueItemContextMenu";
            this.QueueItemContextMenu.Size = new System.Drawing.Size(175, 80);
            // 
            // QueueItemContextMenuProcess
            // 
            this.QueueItemContextMenuProcess.Name = "QueueItemContextMenuProcess";
            this.QueueItemContextMenuProcess.Size = new System.Drawing.Size(174, 38);
            this.QueueItemContextMenuProcess.Text = "Process";
            // 
            // QueueItemContextMenuRemove
            // 
            this.QueueItemContextMenuRemove.Name = "QueueItemContextMenuRemove";
            this.QueueItemContextMenuRemove.Size = new System.Drawing.Size(174, 38);
            this.QueueItemContextMenuRemove.Text = "Remove";
            // 
            // QueueListContextMenu
            // 
            this.QueueListContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.QueueListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QueueListContextMenuRemove,
            this.QueueListContextMenuProcess});
            this.QueueListContextMenu.Name = "QueueListContextMenu";
            this.QueueListContextMenu.Size = new System.Drawing.Size(247, 80);
            // 
            // QueueListContextMenuRemove
            // 
            this.QueueListContextMenuRemove.Name = "QueueListContextMenuRemove";
            this.QueueListContextMenuRemove.Size = new System.Drawing.Size(246, 38);
            this.QueueListContextMenuRemove.Text = "Remove All";
            // 
            // QueueListContextMenuProcess
            // 
            this.QueueListContextMenuProcess.Name = "QueueListContextMenuProcess";
            this.QueueListContextMenuProcess.Size = new System.Drawing.Size(246, 38);
            this.QueueListContextMenuProcess.Text = "Process Queue";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1733, 890);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.ContainerPanel);
            this.Controls.Add(this.StatusBar);
            this.MainMenuStrip = this.Menu;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
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
            this.QueueItemContextMenu.ResumeLayout(false);
            this.QueueListContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip QueueItemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem QueueItemContextMenuRemove;
        private System.Windows.Forms.ToolStripMenuItem QueueItemContextMenuProcess;
        private System.Windows.Forms.ContextMenuStrip QueueListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem QueueListContextMenuRemove;
        private System.Windows.Forms.ToolStripMenuItem QueueListContextMenuProcess;
    }
}

