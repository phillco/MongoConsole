using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using MongoConsole.Interop;

namespace MongoConsole.UI
{
    /// <summary>
    /// Shows the mongo console.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent( );
            sessionTabs.MouseClick += new MouseEventHandler( sessionTabs_MouseClick );
        }

        void sessionTabs_MouseClick( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Right )
            {
                TabPage tab = GetSelectedTabIndex( e.Location );
                if ( tab != null )
                {
                    tabContextMenu.Tag = tab;
                    tabContextMenu.Show( sessionTabs, e.Location );
                }
            }
        }

        public void Add( MongoSession newSession )
        {
            var pane = new SessionPanel( newSession );
            sessionTabs.TabPages.Add( pane.TabPage );
            sessionTabs.SelectTab( pane.TabPage );
        }

        public void CloseTab( TabPage tab )
        {
            var session = ( (SessionPanel) tab.Tag ).Session;
            session.Stop( );
            sessionTabs.TabPages.Remove( tab );
        }

        public void Clone( TabPage tab )
        {
            var session = ( (SessionPanel) tab.Tag ).Session;
            Add( new MongoSession( session.Address ) );
        }

        /// <summary>
        /// Finds which tab was clicked at the specific point.
        /// </summary>
        private TabPage GetSelectedTabIndex( Point clickLocation )
        {
            for ( int i = 0; i < sessionTabs.TabCount; i++ )
            {
                // Does the tab area contain the mouse pointer?
                Rectangle r = sessionTabs.GetTabRect( i );
                if ( r.Contains( clickLocation ) )
                    return sessionTabs.TabPages[i];
            }

            return null;
        }

        private void closeToolStripMenuItem_Click( object sender, EventArgs e )
        {
            CloseTab( (TabPage) tabContextMenu.Tag );
        }

        private void cloneToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Clone( (TabPage) tabContextMenu.Tag );
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Application.Exit( );
        }

        private void aboutToolStripMenuItem_Click( object sender, EventArgs e )
        {
            new AboutForm( ).ShowDialog( this );
        }

        private void cloneCurrentSessionToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Clone( sessionTabs.SelectedTab );
        }
    }
}
