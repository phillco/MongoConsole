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
            newSessionSplitButton.Click += newToolStripMenuItem_Click;
            cloneCurrentSessionToolStripMenuItem1.Click += cloneCurrentSessionToolStripMenuItem_Click;
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
            var tab = new SessionTab( newSession );
            sessionTabs.TabPages.Add( tab );
            sessionTabs.SelectTab( (TabPage) tab );
        }

        public void CloseTab( SessionTab tab )
        {
            tab.Session.Stop( );
            sessionTabs.TabPages.Remove( tab );
        }

        public void Clone( SessionTab tab )
        {
            Add( new MongoSession( tab.Session.Address ) );
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
            CloseTab( (SessionTab) tabContextMenu.Tag );
        }

        private void cloneToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Clone( (SessionTab) tabContextMenu.Tag );
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
            Clone( (SessionTab) sessionTabs.SelectedTab );
        }

        private void newToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var address = NewSessionForm.ShowAndGetAddress( this );
            if ( !string.IsNullOrEmpty( address ) )
                Add( new MongoSession( address ) );
        }
    }
}
