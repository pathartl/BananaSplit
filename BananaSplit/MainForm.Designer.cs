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
            components = new System.ComponentModel.Container();
            Menu = new System.Windows.Forms.MenuStrip();
            FileMenuDropdown = new System.Windows.Forms.ToolStripMenuItem();
            AddFilesToQueueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            AddFolderToQueueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            OptionsMenuDropdown = new System.Windows.Forms.ToolStripMenuItem();
            SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            FileBrowserSplitContainer = new System.Windows.Forms.SplitContainer();
            QueueList = new System.Windows.Forms.ListView();
            FileName = new System.Windows.Forms.ColumnHeader();
            ReferenceImageListView = new System.Windows.Forms.ListView();
            ReferenceImageList = new System.Windows.Forms.ImageList(components);
            StatusBar = new System.Windows.Forms.StatusStrip();
            StatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            StatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ContainerPanel = new System.Windows.Forms.Panel();
            MainPanel = new System.Windows.Forms.Panel();
            ActionBarPanel = new System.Windows.Forms.Panel();
            ProcessQueueButton = new System.Windows.Forms.Button();
            QueueItemContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            QueueItemContextMenuProcess = new System.Windows.Forms.ToolStripMenuItem();
            QueueItemContextMenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            QueueListContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            QueueListContextMenuRemove = new System.Windows.Forms.ToolStripMenuItem();
            QueueListContextMenuProcess = new System.Windows.Forms.ToolStripMenuItem();
            Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FileBrowserSplitContainer).BeginInit();
            FileBrowserSplitContainer.Panel1.SuspendLayout();
            FileBrowserSplitContainer.Panel2.SuspendLayout();
            FileBrowserSplitContainer.SuspendLayout();
            StatusBar.SuspendLayout();
            ContainerPanel.SuspendLayout();
            MainPanel.SuspendLayout();
            ActionBarPanel.SuspendLayout();
            QueueItemContextMenu.SuspendLayout();
            QueueListContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // Menu
            // 
            Menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { FileMenuDropdown, OptionsMenuDropdown });
            Menu.Location = new System.Drawing.Point(0, 0);
            Menu.Name = "Menu";
            Menu.Padding = new System.Windows.Forms.Padding(13, 4, 0, 4);
            Menu.Size = new System.Drawing.Size(1733, 44);
            Menu.TabIndex = 0;
            Menu.Text = "menuStrip1";
            // 
            // FileMenuDropdown
            // 
            FileMenuDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { AddFilesToQueueMenuItem, AddFolderToQueueMenuItem });
            FileMenuDropdown.Name = "FileMenuDropdown";
            FileMenuDropdown.Size = new System.Drawing.Size(71, 36);
            FileMenuDropdown.Text = "File";
            // 
            // AddFilesToQueueMenuItem
            // 
            AddFilesToQueueMenuItem.Name = "AddFilesToQueueMenuItem";
            AddFilesToQueueMenuItem.Size = new System.Drawing.Size(372, 44);
            AddFilesToQueueMenuItem.Text = "Add File(s) to Queue";
            // 
            // AddFolderToQueueMenuItem
            // 
            AddFolderToQueueMenuItem.Name = "AddFolderToQueueMenuItem";
            AddFolderToQueueMenuItem.Size = new System.Drawing.Size(372, 44);
            AddFolderToQueueMenuItem.Text = "Add Folder to Queue";
            // 
            // OptionsMenuDropdown
            // 
            OptionsMenuDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { SettingsMenuItem, AboutMenuItem });
            OptionsMenuDropdown.Name = "OptionsMenuDropdown";
            OptionsMenuDropdown.Size = new System.Drawing.Size(118, 36);
            OptionsMenuDropdown.Text = "Options";
            // 
            // SettingsMenuItem
            // 
            SettingsMenuItem.Name = "SettingsMenuItem";
            SettingsMenuItem.Size = new System.Drawing.Size(359, 44);
            SettingsMenuItem.Text = "Settings";
            // 
            // AboutMenuItem
            // 
            AboutMenuItem.Name = "AboutMenuItem";
            AboutMenuItem.Size = new System.Drawing.Size(359, 44);
            AboutMenuItem.Text = "About";
            // 
            // FileBrowserSplitContainer
            // 
            FileBrowserSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            FileBrowserSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            FileBrowserSplitContainer.Location = new System.Drawing.Point(7, 6);
            FileBrowserSplitContainer.Margin = new System.Windows.Forms.Padding(7, 6, 7, 124);
            FileBrowserSplitContainer.Name = "FileBrowserSplitContainer";
            // 
            // FileBrowserSplitContainer.Panel1
            // 
            FileBrowserSplitContainer.Panel1.Controls.Add(QueueList);
            // 
            // FileBrowserSplitContainer.Panel2
            // 
            FileBrowserSplitContainer.Panel2.Controls.Add(ReferenceImageListView);
            FileBrowserSplitContainer.Size = new System.Drawing.Size(1719, 724);
            FileBrowserSplitContainer.SplitterDistance = 264;
            FileBrowserSplitContainer.SplitterWidth = 9;
            FileBrowserSplitContainer.TabIndex = 1;
            // 
            // QueueList
            // 
            QueueList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { FileName });
            QueueList.Dock = System.Windows.Forms.DockStyle.Fill;
            QueueList.HideSelection = false;
            QueueList.Location = new System.Drawing.Point(0, 0);
            QueueList.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            QueueList.Name = "QueueList";
            QueueList.ShowItemToolTips = true;
            QueueList.Size = new System.Drawing.Size(264, 724);
            QueueList.TabIndex = 0;
            QueueList.UseCompatibleStateImageBehavior = false;
            QueueList.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            FileName.Text = "Filename";
            FileName.Width = 260;
            // 
            // ReferenceImageListView
            // 
            ReferenceImageListView.CheckBoxes = true;
            ReferenceImageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            ReferenceImageListView.HideSelection = false;
            ReferenceImageListView.LargeImageList = ReferenceImageList;
            ReferenceImageListView.Location = new System.Drawing.Point(0, 0);
            ReferenceImageListView.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            ReferenceImageListView.Name = "ReferenceImageListView";
            ReferenceImageListView.Size = new System.Drawing.Size(1446, 724);
            ReferenceImageListView.SmallImageList = ReferenceImageList;
            ReferenceImageListView.TabIndex = 0;
            ReferenceImageListView.UseCompatibleStateImageBehavior = false;
            ReferenceImageListView.ItemChecked += ReferenceImageListView_SelectedIndexChanged;
            ReferenceImageListView.SelectedIndexChanged += ReferenceImageListView_SelectedIndexChanged;
            // 
            // ReferenceImageList
            // 
            ReferenceImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ReferenceImageList.ImageSize = new System.Drawing.Size(256, 256);
            ReferenceImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // StatusBar
            // 
            StatusBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { StatusBarProgressBar, StatusBarLabel });
            StatusBar.Location = new System.Drawing.Point(0, 852);
            StatusBar.Name = "StatusBar";
            StatusBar.Padding = new System.Windows.Forms.Padding(2, 0, 30, 0);
            StatusBar.Size = new System.Drawing.Size(1733, 38);
            StatusBar.TabIndex = 2;
            StatusBar.Text = "StatusBar";
            // 
            // StatusBarProgressBar
            // 
            StatusBarProgressBar.Name = "StatusBarProgressBar";
            StatusBarProgressBar.Size = new System.Drawing.Size(217, 26);
            // 
            // StatusBarLabel
            // 
            StatusBarLabel.Name = "StatusBarLabel";
            StatusBarLabel.Size = new System.Drawing.Size(0, 28);
            // 
            // ContainerPanel
            // 
            ContainerPanel.Controls.Add(MainPanel);
            ContainerPanel.Controls.Add(ActionBarPanel);
            ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            ContainerPanel.Location = new System.Drawing.Point(0, 0);
            ContainerPanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            ContainerPanel.Name = "ContainerPanel";
            ContainerPanel.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            ContainerPanel.Size = new System.Drawing.Size(1733, 852);
            ContainerPanel.TabIndex = 4;
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(FileBrowserSplitContainer);
            MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPanel.Location = new System.Drawing.Point(0, 50);
            MainPanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            MainPanel.Name = "MainPanel";
            MainPanel.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            MainPanel.Size = new System.Drawing.Size(1733, 736);
            MainPanel.TabIndex = 1;
            // 
            // ActionBarPanel
            // 
            ActionBarPanel.Controls.Add(ProcessQueueButton);
            ActionBarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            ActionBarPanel.Location = new System.Drawing.Point(0, 786);
            ActionBarPanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            ActionBarPanel.Name = "ActionBarPanel";
            ActionBarPanel.Size = new System.Drawing.Size(1733, 66);
            ActionBarPanel.TabIndex = 5;
            // 
            // ProcessQueueButton
            // 
            ProcessQueueButton.AutoSize = true;
            ProcessQueueButton.Dock = System.Windows.Forms.DockStyle.Right;
            ProcessQueueButton.Location = new System.Drawing.Point(1395, 0);
            ProcessQueueButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            ProcessQueueButton.Name = "ProcessQueueButton";
            ProcessQueueButton.Size = new System.Drawing.Size(338, 66);
            ProcessQueueButton.TabIndex = 0;
            ProcessQueueButton.Text = "Process Queue";
            ProcessQueueButton.UseVisualStyleBackColor = true;
            // 
            // QueueItemContextMenu
            // 
            QueueItemContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            QueueItemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { QueueItemContextMenuProcess, QueueItemContextMenuRemove });
            QueueItemContextMenu.Name = "QueueItemContextMenu";
            QueueItemContextMenu.Size = new System.Drawing.Size(175, 80);
            // 
            // QueueItemContextMenuProcess
            // 
            QueueItemContextMenuProcess.Name = "QueueItemContextMenuProcess";
            QueueItemContextMenuProcess.Size = new System.Drawing.Size(174, 38);
            QueueItemContextMenuProcess.Text = "Process";
            // 
            // QueueItemContextMenuRemove
            // 
            QueueItemContextMenuRemove.Name = "QueueItemContextMenuRemove";
            QueueItemContextMenuRemove.Size = new System.Drawing.Size(174, 38);
            QueueItemContextMenuRemove.Text = "Remove";
            // 
            // QueueListContextMenu
            // 
            QueueListContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            QueueListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { QueueListContextMenuRemove, QueueListContextMenuProcess });
            QueueListContextMenu.Name = "QueueListContextMenu";
            QueueListContextMenu.Size = new System.Drawing.Size(247, 80);
            // 
            // QueueListContextMenuRemove
            // 
            QueueListContextMenuRemove.Name = "QueueListContextMenuRemove";
            QueueListContextMenuRemove.Size = new System.Drawing.Size(246, 38);
            QueueListContextMenuRemove.Text = "Remove All";
            // 
            // QueueListContextMenuProcess
            // 
            QueueListContextMenuProcess.Name = "QueueListContextMenuProcess";
            QueueListContextMenuProcess.Size = new System.Drawing.Size(246, 38);
            QueueListContextMenuProcess.Text = "Process Queue";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1733, 890);
            Controls.Add(Menu);
            Controls.Add(ContainerPanel);
            Controls.Add(StatusBar);
            MainMenuStrip = Menu;
            Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            Name = "MainForm";
            Text = "BananaSplit";
            Load += MainForm_Load;
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            FileBrowserSplitContainer.Panel1.ResumeLayout(false);
            FileBrowserSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FileBrowserSplitContainer).EndInit();
            FileBrowserSplitContainer.ResumeLayout(false);
            StatusBar.ResumeLayout(false);
            StatusBar.PerformLayout();
            ContainerPanel.ResumeLayout(false);
            MainPanel.ResumeLayout(false);
            ActionBarPanel.ResumeLayout(false);
            ActionBarPanel.PerformLayout();
            QueueItemContextMenu.ResumeLayout(false);
            QueueListContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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

