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
    /// The main form with tabs and a menu.
    /// </summary>
    public partial class MainForm : Form
    {
        //=================================================================================
        //
        //  CONSTRUCTORS
        //
        //=================================================================================

        public MainForm( )
        {
            InitializeComponent( );
            sessionTabs.MouseClick += sessionTabs_MouseClick;

            // Hook up menu actions.
            closeToolStripMenuItem.Click += ( target, e ) => CloseTab( (SessionTab) tabContextMenu.Tag );
            cloneToolStripMenuItem.Click += ( target, e ) => Clone( (SessionTab) tabContextMenu.Tag );
            exitToolStripMenuItem.Click += ( target, e ) => Application.Exit( );
            aboutToolStripMenuItem.Click += ( target, e ) => new AboutForm( ).ShowDialog( this );
            cloneCurrentSessionToolStripMenuItem.Click += ( target, e ) => Clone( (SessionTab) sessionTabs.SelectedTab );
            newToolStripMenuItem.Click += ( target, e ) => PromptForNewSession();
        }

        //=================================================================================
        //
        //  PUBLIC METHODS
        //
        //=================================================================================

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

        //=================================================================================
        //
        //  PRIVATE METHODS
        //
        //=================================================================================

        private void sessionTabs_MouseClick( object sender, MouseEventArgs e )
        {
            // Extract selected tab.
            SessionTab tab = GetSelectedTabIndex( e.Location );
            if ( tab == null )
                return;

            switch ( e.Button )
            {
                case MouseButtons.Middle: // Middle-click to close tabs, like Chrome.
                    CloseTab( tab );
                    break;
                case MouseButtons.Right:
                    tabContextMenu.Tag = tab;
                    tabContextMenu.Show( sessionTabs, e.Location );
                    break;
            }
        }

        /// <summary>Finds which tab was clicked at the specific point.</summary>
        private SessionTab GetSelectedTabIndex( Point clickLocation )
        {
            for ( int i = 0; i < sessionTabs.TabCount; i++ )
            {
                // Does the tab area contain the mouse pointer?
                Rectangle r = sessionTabs.GetTabRect( i );
                if ( r.Contains( clickLocation ) )
                    return (SessionTab) sessionTabs.TabPages[i];
            }

            return null;
        }

        /// <summary>Prompts the user to enter an address, then creates a tab.</summary>
        private void PromptForNewSession( )
        {
            var address = NewSessionForm.ShowAndGetAddress( this );
            if ( !string.IsNullOrEmpty( address ) )
                Add( new MongoSession( address ) );
        }
    }
}
