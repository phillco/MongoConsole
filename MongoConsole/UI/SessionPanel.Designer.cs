namespace MongoConsole.UI
{
    partial class SessionPanel
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
            this.tbConsoleBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbConsoleBox
            // 
            this.tbConsoleBox.BackColor = System.Drawing.Color.Black;
            this.tbConsoleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConsoleBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConsoleBox.ForeColor = System.Drawing.Color.GreenYellow;
            this.tbConsoleBox.Location = new System.Drawing.Point(0, 0);
            this.tbConsoleBox.Multiline = true;
            this.tbConsoleBox.Name = "tbConsoleBox";
            this.tbConsoleBox.ReadOnly = true;
            this.tbConsoleBox.Size = new System.Drawing.Size(468, 296);
            this.tbConsoleBox.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbInput);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 272);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 24);
            this.panel2.TabIndex = 3;
            // 
            // tbInput
            // 
            this.tbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInput.Location = new System.Drawing.Point(0, 0);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(468, 20);
            this.tbInput.TabIndex = 0;
            this.tbInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyUp);
            // 
            // SessionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tbConsoleBox);
            this.Name = "SessionPanel";
            this.Size = new System.Drawing.Size(468, 296);
            this.Load += new System.EventHandler(this.SessionTab_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbConsoleBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbInput;
    }
}
