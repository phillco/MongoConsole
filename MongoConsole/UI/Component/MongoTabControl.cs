using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoConsole.Interop;
using System.Drawing;

namespace MongoConsole.UI.Component
{
    /// <summary>
    /// The main tab control that holds the MongoTabs.
    /// </summary>
    public class MongoTabControl : TabControl
    {
        private ToolStripMenuItem mnuDuplicateTab, mnuCloseTab;
        private ContextMenuStrip tabContextMenu;

        public MongoTabControl( )
        {
            InitializeComponent( );
            MouseClick += sessionTabs_MouseClick;
            mnuCloseTab.Click += ( target, e ) => CloseTab( (MongoTab) tabContextMenu.Tag );
            mnuDuplicateTab.Click += ( target, e ) => DuplicateTab( (MongoTab) tabContextMenu.Tag );
        }

        public void Add( MongoSession newSession )
        {
            var tab = new MongoTab( newSession );
            TabPages.Add( tab );
            SelectTab( (TabPage) tab );
        }

        public void CloseTab( MongoTab tab )
        {
            tab.Session.Stop( );
            TabPages.Remove( tab );
        }

        public void DuplicateTab( MongoTab tab )
        {
            Add( new MongoSession( tab.Session.Address ) );
        }

        /// <summary>Finds which tab was clicked at the specific point.</summary>
        public MongoTab GetSelectedTabIndex( Point clickLocation )
        {
            for ( int i = 0; i < TabCount; i++ )
            {
                // Does the tab area contain the mouse pointer?
                Rectangle r = GetTabRect( i );
                if ( r.Contains( clickLocation ) )
                    return (MongoTab) TabPages[i];
            }

            return null;
        }

        private void sessionTabs_MouseClick( object sender, MouseEventArgs e )
        {
            // Extract selected tab.
            MongoTab tab = GetSelectedTabIndex( e.Location );
            if ( tab == null )
                return;

            switch ( e.Button )
            {
                case MouseButtons.Middle: // Middle-click to close tabs, like Chrome.
                    CloseTab( tab );
                    break;
                case MouseButtons.Right:
                    tabContextMenu.Tag = tab;
                    tabContextMenu.Show( this, e.Location );
                    break;
            }
        }

        private void InitializeComponent( )
        {
            this.mnuDuplicateTab = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseTab = new System.Windows.Forms.ToolStripMenuItem();
            this.tabContextMenu = new ContextMenuStrip( );
            this.SuspendLayout();
            // 
            // mnuDuplicateTab
            // 
            this.mnuDuplicateTab.Image = global::MongoConsole.Properties.Resources.document_copy;
            this.mnuDuplicateTab.Name = "mnuDuplicateTab";
            this.mnuDuplicateTab.Size = new System.Drawing.Size(152, 22);
            this.mnuDuplicateTab.Text = "Duplicate";
            // 
            // mnuCloseTab
            // 
            this.mnuCloseTab.Image = global::MongoConsole.Properties.Resources.cross_octagon;
            this.mnuCloseTab.Name = "mnuCloseTab";
            this.mnuCloseTab.Size = new System.Drawing.Size(152, 22);
            this.mnuCloseTab.Text = "Close";
            this.ResumeLayout(false);
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
