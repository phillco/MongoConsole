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
            this.emptyTabArea = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewSession = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDuplicateCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewSession2 = new System.Windows.Forms.ToolStripMenuItem();
            this.noTabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.noTabsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewSession = new System.Windows.Forms.Button();
            this.mongoTabs = new MongoConsole.UI.Component.MongoTabControl();
            this.emptyTabArea.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.noTabContextMenu.SuspendLayout();
            this.noTabsPanel.SuspendLayout();
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
            // emptyTabArea
            // 
            this.emptyTabArea.Controls.Add(this.mongoTabs);
            this.emptyTabArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emptyTabArea.Location = new System.Drawing.Point(0, 0);
            this.emptyTabArea.Name = "emptyTabArea";
            this.emptyTabArea.Padding = new System.Windows.Forms.Padding(0, 24, 0, 0);
            this.emptyTabArea.Size = new System.Drawing.Size(750, 469);
            this.emptyTabArea.TabIndex = 1;
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
            this.mnuDuplicateCurrent,
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
            this.mnuNewSession.Size = new System.Drawing.Size(206, 22);
            this.mnuNewSession.Text = "&New session...";
            // 
            // mnuDuplicateCurrent
            // 
            this.mnuDuplicateCurrent.Image = global::MongoConsole.Properties.Resources.document_copy;
            this.mnuDuplicateCurrent.Name = "mnuDuplicateCurrent";
            this.mnuDuplicateCurrent.Size = new System.Drawing.Size(206, 22);
            this.mnuDuplicateCurrent.Text = "&Duplicate current session";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(203, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(206, 22);
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
            this.mnuAbout.Size = new System.Drawing.Size(116, 22);
            this.mnuAbout.Text = "&About...";
            // 
            // mnuNewSession2
            // 
            this.mnuNewSession2.Image = global::MongoConsole.Properties.Resources._new;
            this.mnuNewSession2.Name = "mnuNewSession2";
            this.mnuNewSession2.Size = new System.Drawing.Size(148, 22);
            this.mnuNewSession2.Text = "New session...";
            // 
            // noTabContextMenu
            // 
            this.noTabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewSession2});
            this.noTabContextMenu.Name = "noTabContextMenu";
            this.noTabContextMenu.Size = new System.Drawing.Size(149, 26);
            // 
            // noTabsPanel
            // 
            this.noTabsPanel.BackColor = System.Drawing.Color.White;
            this.noTabsPanel.Controls.Add(this.btnNewSession);
            this.noTabsPanel.Controls.Add(this.label1);
            this.noTabsPanel.Location = new System.Drawing.Point(269, 196);
            this.noTabsPanel.Name = "noTabsPanel";
            this.noTabsPanel.Size = new System.Drawing.Size(212, 77);
            this.noTabsPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "You don\'t have any open tabs!";
            // 
            // btnNewSession
            // 
            this.btnNewSession.Image = global::MongoConsole.Properties.Resources._new;
            this.btnNewSession.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewSession.Location = new System.Drawing.Point(22, 37);
            this.btnNewSession.Name = "btnNewSession";
            this.btnNewSession.Size = new System.Drawing.Size(116, 23);
            this.btnNewSession.TabIndex = 1;
            this.btnNewSession.Text = "New session...";
            this.btnNewSession.UseVisualStyleBackColor = true;
            // 
            // mongoTabs
            // 
            this.mongoTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mongoTabs.ImageList = this.sessionsStatusImages;
            this.mongoTabs.Location = new System.Drawing.Point(0, 24);
            this.mongoTabs.Name = "mongoTabs";
            this.mongoTabs.SelectedIndex = 0;
            this.mongoTabs.SelectedTab = null;
            this.mongoTabs.Size = new System.Drawing.Size(750, 445);
            this.mongoTabs.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 469);
            this.Controls.Add(this.noTabsPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.emptyTabArea);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.Text = "MongoConsole";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.emptyTabArea.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.noTabContextMenu.ResumeLayout(false);
            this.noTabsPanel.ResumeLayout(false);
            this.noTabsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList sessionsStatusImages;
        private System.Windows.Forms.Panel emptyTabArea;
        private MongoConsole.UI.Component.MongoTabControl mongoTabs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNewSession;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuDuplicateCurrent;
        private System.Windows.Forms.ToolStripMenuItem mnuNewSession2;
        private System.Windows.Forms.ContextMenuStrip noTabContextMenu;
        private System.Windows.Forms.Panel noTabsPanel;
        private System.Windows.Forms.Button btnNewSession;
        private System.Windows.Forms.Label label1;
    }
}

