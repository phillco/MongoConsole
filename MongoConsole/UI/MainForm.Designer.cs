namespace MongoConsole.UI
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
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sessionsStatusImages = new System.Windows.Forms.ImageList(this.components);
            this.tabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCloneTab = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseTab = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sessionTabs = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewSession = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloneCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabContextMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sessionsStatusImages
            // 
            this.sessionsStatusImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sessionsStatusImages.ImageStream")));
            this.sessionsStatusImages.TransparentColor = System.Drawing.Color.Transparent;
            this.sessionsStatusImages.Images.SetKeyName(0, "status-offline.png");
            this.sessionsStatusImages.Images.SetKeyName(1, "status-away.png");
            this.sessionsStatusImages.Images.SetKeyName(2, "status.png");
            // 
            // tabContextMenu
            // 
            this.tabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCloneTab,
            this.mnuCloseTab});
            this.tabContextMenu.Name = "tabContextMenu";
            this.tabContextMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // mnuCloneTab
            // 
            this.mnuCloneTab.Image = global::MongoConsole.Properties.Resources.document_copy;
            this.mnuCloneTab.Name = "mnuCloneTab";
            this.mnuCloneTab.Size = new System.Drawing.Size(152, 22);
            this.mnuCloneTab.Text = "Clone session";
            // 
            // mnuCloseTab
            // 
            this.mnuCloseTab.Image = global::MongoConsole.Properties.Resources.cross_octagon;
            this.mnuCloseTab.Name = "mnuCloseTab";
            this.mnuCloseTab.Size = new System.Drawing.Size(152, 22);
            this.mnuCloseTab.Text = "Close";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sessionTabs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 24, 0, 0);
            this.panel2.Size = new System.Drawing.Size(750, 469);
            this.panel2.TabIndex = 1;
            // 
            // sessionTabs
            // 
            this.sessionTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionTabs.ImageList = this.sessionsStatusImages;
            this.sessionTabs.Location = new System.Drawing.Point(0, 24);
            this.sessionTabs.Name = "sessionTabs";
            this.sessionTabs.SelectedIndex = 0;
            this.sessionTabs.Size = new System.Drawing.Size(750, 445);
            this.sessionTabs.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(750, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewSession,
            this.mnuCloneCurrent,
            this.toolStripSeparator2,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuNewSession
            // 
            this.mnuNewSession.Image = global::MongoConsole.Properties.Resources._new;
            this.mnuNewSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNewSession.Name = "mnuNewSession";
            this.mnuNewSession.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNewSession.Size = new System.Drawing.Size(191, 22);
            this.mnuNewSession.Text = "&New session...";
            // 
            // mnuCloneCurrent
            // 
            this.mnuCloneCurrent.Image = global::MongoConsole.Properties.Resources.document_copy;
            this.mnuCloneCurrent.Name = "mnuCloneCurrent";
            this.mnuCloneCurrent.Size = new System.Drawing.Size(191, 22);
            this.mnuCloneCurrent.Text = "&Clone current session";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(191, 22);
            this.mnuExit.Text = "E&xit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(152, 22);
            this.mnuAbout.Text = "&About...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 469);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MongoConsole";
            this.tabContextMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList sessionsStatusImages;
        private System.Windows.Forms.ContextMenuStrip tabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuCloneTab;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseTab;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl sessionTabs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNewSession;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuCloneCurrent;
    }
}

