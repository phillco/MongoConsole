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
using MongoConsole.UI.Component;

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

            emptyTabArea.MouseClick += emptyTabArea_MouseClick;
            emptyTabArea.MouseDoubleClick += emptyTabArea_MouseDoubleClick;
            mongoTabs.NumTabsChanged += UpdateState;
            btnNewSession.Click += ( target, e ) => PromptForNewSession( );

            // Hook up menu actions.
            mnuNewSession.Click += ( target, e ) => PromptForNewSession( );
            mnuNewSession2.Click += ( target, e ) => PromptForNewSession( );
            mnuExit.Click += ( target, e ) => Application.Exit( );
            mnuAbout.Click += ( target, e ) => new AboutForm( ).ShowDialog( this );
            mnuDuplicateCurrent.Click += ( target, e ) => mongoTabs.DuplicateTab( mongoTabs.SelectedTab );

            MainForm_Resize( null, null );
            UpdateState( );
        }

        //=================================================================================
        //
        //  PUBLIC METHODS
        //
        //=================================================================================

        public void UpdateState( )
        {
            mnuDuplicateCurrent.Enabled = ( mongoTabs.TabCount > 0 );
            noTabsPanel.Visible = ( mongoTabs.TabCount == 0 );
        }

        public void Add( MongoSession newSession )
        {
            mongoTabs.Add( newSession );
        }

        //=================================================================================
        //
        //  PRIVATE METHODS
        //
        //=================================================================================

        /// <summary>Prompts the user to enter an address, then creates a tab.</summary>
        private void PromptForNewSession( )
        {
            var address = NewSessionForm.ShowAndGetAddress( this );
            if ( !string.IsNullOrEmpty( address ) )
                Add( new MongoSession( address ) );
        }

        private void emptyTabArea_MouseClick( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Right )
                noTabContextMenu.Show( emptyTabArea, e.Location );
        }

        private void emptyTabArea_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            PromptForNewSession( );
        }

        private void MainForm_Resize( object sender, EventArgs e )
        {
            noTabsPanel.Left = Width / 2 - noTabsPanel.Width / 2;
            noTabsPanel.Top = Height / 3 - noTabsPanel.Height / 2;
        }
    }
}
