using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoConsole.UI.Component
{
	partial class MongoTabControl
	{
        private System.Windows.Forms.ToolStripMenuItem mnuDuplicateTab, mnuCloseTab;
        private System.Windows.Forms.ContextMenuStrip tabContextMenu;

        /// <summary>Form stuff...</summary>
        private void InitializeComponent( )
        {
            this.mnuDuplicateTab = new System.Windows.Forms.ToolStripMenuItem( );
            this.mnuCloseTab = new System.Windows.Forms.ToolStripMenuItem( );
            this.tabContextMenu = new System.Windows.Forms.ContextMenuStrip( );
            this.SuspendLayout( );
            // 
            // mnuDuplicateTab
            // 
            this.mnuDuplicateTab.Image = global::MongoConsole.Properties.Resources.document_copy;
            this.mnuDuplicateTab.Name = "mnuDuplicateTab";
            this.mnuDuplicateTab.Size = new System.Drawing.Size( 152, 22 );
            this.mnuDuplicateTab.Text = "Duplicate";
            // 
            // mnuCloseTab
            // 
            this.mnuCloseTab.Image = global::MongoConsole.Properties.Resources.cross_octagon;
            this.mnuCloseTab.Name = "mnuCloseTab";
            this.mnuCloseTab.Size = new System.Drawing.Size( 152, 22 );
            this.mnuCloseTab.Text = "Close";
            this.ResumeLayout( false );
            //
            // tabContextMenu
            // 
            this.tabContextMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.mnuDuplicateTab,
            this.mnuCloseTab} );
            this.tabContextMenu.Name = "tabContextMenu";
            this.tabContextMenu.Size = new System.Drawing.Size( 153, 70 );
        }
	}
}
