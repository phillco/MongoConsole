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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sessionTabs = new System.Windows.Forms.TabControl();
            this.sessionsStatusImages = new System.Windows.Forms.ImageList(this.components);
            this.tabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 79);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sessionTabs
            // 
            this.sessionTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionTabs.ImageList = this.sessionsStatusImages;
            this.sessionTabs.Location = new System.Drawing.Point(0, 79);
            this.sessionTabs.Name = "sessionTabs";
            this.sessionTabs.SelectedIndex = 0;
            this.sessionTabs.Size = new System.Drawing.Size(750, 390);
            this.sessionTabs.TabIndex = 1;
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
            this.cloneToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.tabContextMenu.Name = "tabContextMenu";
            this.tabContextMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            this.cloneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cloneToolStripMenuItem.Text = "Clone session";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 469);
            this.Controls.Add(this.sessionTabs);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "MongoDB console";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl sessionTabs;
        private System.Windows.Forms.ImageList sessionsStatusImages;
        private System.Windows.Forms.ContextMenuStrip tabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

