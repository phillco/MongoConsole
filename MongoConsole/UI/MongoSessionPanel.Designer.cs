using MongoConsole.UI.Component;
namespace MongoConsole.UI
{
    partial class MongoSessionPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSelectedDatabase = new System.Windows.Forms.ComboBox();
            this.statusInsidePanel = new System.Windows.Forms.Panel();
            this.pbConnecting = new System.Windows.Forms.ProgressBar();
            this.lblStatusHeader = new System.Windows.Forms.Label();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.lbAutoComplete = new System.Windows.Forms.ListBox();
            this.lblStatusSubHeader = new System.Windows.Forms.Label();
            this.tbInput = new MongoConsole.UI.Component.HistoryTextBox();
            this.tbConsoleBox = new MongoConsole.UI.Component.ConsoleLogBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusInsidePanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 361);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.panel2.Size = new System.Drawing.Size(698, 34);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbSelectedDatabase);
            this.panel1.Controls.Add(this.tbInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(125, 0, 5, 0);
            this.panel1.Size = new System.Drawing.Size(698, 28);
            this.panel1.TabIndex = 5;
            // 
            // cbSelectedDatabase
            // 
            this.cbSelectedDatabase.FormattingEnabled = true;
            this.cbSelectedDatabase.Location = new System.Drawing.Point(6, 0);
            this.cbSelectedDatabase.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.cbSelectedDatabase.Name = "cbSelectedDatabase";
            this.cbSelectedDatabase.Size = new System.Drawing.Size(109, 25);
            this.cbSelectedDatabase.TabIndex = 1;
            this.cbSelectedDatabase.SelectedIndexChanged += new System.EventHandler(this.cbSelectedDatabase_SelectedIndexChanged);
            this.cbSelectedDatabase.Leave += new System.EventHandler(this.cbSelectedDatabase_Leave);
            // 
            // statusInsidePanel
            // 
            this.statusInsidePanel.BackColor = System.Drawing.Color.White;
            this.statusInsidePanel.Controls.Add(this.lblStatusSubHeader);
            this.statusInsidePanel.Controls.Add(this.pbConnecting);
            this.statusInsidePanel.Controls.Add(this.lblStatusHeader);
            this.statusInsidePanel.Location = new System.Drawing.Point(17, 54);
            this.statusInsidePanel.Name = "statusInsidePanel";
            this.statusInsidePanel.Size = new System.Drawing.Size(414, 85);
            this.statusInsidePanel.TabIndex = 4;
            // 
            // pbConnecting
            // 
            this.pbConnecting.Location = new System.Drawing.Point(150, 40);
            this.pbConnecting.MarqueeAnimationSpeed = 25;
            this.pbConnecting.Name = "pbConnecting";
            this.pbConnecting.Size = new System.Drawing.Size(118, 14);
            this.pbConnecting.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbConnecting.TabIndex = 2;
            // 
            // lblStatusHeader
            // 
            this.lblStatusHeader.AutoSize = true;
            this.lblStatusHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusHeader.Location = new System.Drawing.Point(147, 20);
            this.lblStatusHeader.Name = "lblStatusHeader";
            this.lblStatusHeader.Size = new System.Drawing.Size(92, 16);
            this.lblStatusHeader.TabIndex = 0;
            this.lblStatusHeader.Text = "Connecting...";
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.White;
            this.statusPanel.Controls.Add(this.statusInsidePanel);
            this.statusPanel.Location = new System.Drawing.Point(108, 69);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(468, 192);
            this.statusPanel.TabIndex = 3;
            // 
            // lbAutoComplete
            // 
            this.lbAutoComplete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAutoComplete.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lbAutoComplete.FormattingEnabled = true;
            this.lbAutoComplete.ItemHeight = 17;
            this.lbAutoComplete.Items.AddRange(new object[] {
            "runCommand()",
            "adminCommand()",
            "commandHelp()",
            "getProfilingLevel()"});
            this.lbAutoComplete.Location = new System.Drawing.Point(186, 314);
            this.lbAutoComplete.Name = "lbAutoComplete";
            this.lbAutoComplete.Size = new System.Drawing.Size(120, 72);
            this.lbAutoComplete.TabIndex = 5;
            this.lbAutoComplete.Visible = false;
            // 
            // lblStatusSubHeader
            // 
            this.lblStatusSubHeader.AutoSize = true;
            this.lblStatusSubHeader.Location = new System.Drawing.Point(147, 40);
            this.lblStatusSubHeader.Name = "lblStatusSubHeader";
            this.lblStatusSubHeader.Size = new System.Drawing.Size(101, 13);
            this.lblStatusSubHeader.TabIndex = 3;
            this.lblStatusSubHeader.Text = "Status goes here...";
            this.lblStatusSubHeader.Visible = false;
            // 
            // tbInput
            // 
            this.tbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInput.Location = new System.Drawing.Point(125, 0);
            this.tbInput.MaxEntries = 1;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(568, 25);
            this.tbInput.TabIndex = 1;
            // 
            // tbConsoleBox
            // 
            this.tbConsoleBox.BackColor = System.Drawing.Color.White;
            this.tbConsoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConsoleBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsoleBox.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.tbConsoleBox.Location = new System.Drawing.Point(0, 0);
            this.tbConsoleBox.Multiline = true;
            this.tbConsoleBox.Name = "tbConsoleBox";
            this.tbConsoleBox.ReadOnly = true;
            this.tbConsoleBox.Size = new System.Drawing.Size(698, 395);
            this.tbConsoleBox.TabIndex = 2;
            // 
            // MongoSessionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbAutoComplete);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tbConsoleBox);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MongoSessionPanel";
            this.Size = new System.Drawing.Size(698, 395);
            this.Load += new System.EventHandler(this.SessionTab_Load);
            this.Resize += new System.EventHandler(this.SessionPanel_Resize);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusInsidePanel.ResumeLayout(false);
            this.statusInsidePanel.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel statusInsidePanel;
        private System.Windows.Forms.Label lblStatusHeader;
        private System.Windows.Forms.ProgressBar pbConnecting;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.ComboBox cbSelectedDatabase;
        private System.Windows.Forms.Panel panel1;
        public HistoryTextBox tbInput;
        public ConsoleLogBox tbConsoleBox;
        public System.Windows.Forms.ListBox lbAutoComplete;
        private System.Windows.Forms.Label lblStatusSubHeader;
    }
}
