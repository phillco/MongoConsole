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

            // Hook up menu actions.
            mnuNewSession.Click += ( target, e ) => PromptForNewSession( );
            mnuNewSession2.Click += ( target, e ) => PromptForNewSession( );
            mnuExit.Click += ( target, e ) => Application.Exit( );
            mnuAbout.Click += ( target, e ) => new AboutForm( ).ShowDialog( this );
            mnuDuplicateCurrent.Click += ( target, e ) => sessionTabs.DuplicateTab( (MongoTab) sessionTabs.SelectedTab );
        }

        //=================================================================================
        //
        //  PUBLIC METHODS
        //
        //=================================================================================

        public void Add( MongoSession newSession )
        {
            var tab = new MongoTab( newSession );
            sessionTabs.TabPages.Add( tab );
            sessionTabs.SelectTab( (TabPage) tab );
        }


        //=================================================================================
        //
        //  PRIVATE METHODS
        //
        //=================================================================================


        private void emptyTabArea_MouseClick( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Right )
                noTabContextMenu.Show( emptyTabArea, e.Location );
        }

        private void emptyTabArea_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            PromptForNewSession( );
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
