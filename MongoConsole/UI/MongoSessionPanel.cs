using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoConsole.Interop;
using MongoConsole.UI.Component;

namespace MongoConsole.UI
{
    /// <summary>
    /// The actual mongo administration panel (for one session) with the console, input box, etc.
    /// Contained by a SessionTab. (Why not merge them? Because then you lose the form editor).
    /// </summary>
    public partial class MongoSessionPanel : UserControl
    {
        public MongoSession Session { get { return ParentTab.Session; } }

        private MongoTab ParentTab;

        public MongoSessionPanel( MongoTab parent )
        {
            InitializeComponent( );
            ParentTab = parent;
            Dock = DockStyle.Fill;
            statusPanel.Dock = DockStyle.Fill;
            AutoCompleteMaker.Initialize( this );
        }

        private void SessionTab_Load( object sender, EventArgs e )
        {
            Session.Status.StateChanged += UpdateState;
            UpdateState( );
        }

        public void UpdateState( )
        {
            // Run this on the UI thread.
            if ( this.InvokeRequired )
            {
                this.Invoke( (MethodInvoker) UpdateState );
                return;
            }

            switch ( Session.Status.CurrentState )
            {
                case ConnectionStatus.State.CONNECTED:
                    OnConnected( );    
                    break;

                case ConnectionStatus.State.CONNECTING:
                    lblStatusHeader.Text = "Connecting...";
                    break;     

                case ConnectionStatus.State.FAILED:                                        
                    lblStatusHeader.Text = "Failure";

                    // Show the subheader instead of the progress bar.
                    lblStatusSubHeader.Text = Session.Status.FailureReason;
                    lblStatusSubHeader.Show( );                    
                    pbConnecting.Hide( );                    
                    break;
            }

            // Show the "connecting..." info panel while connecting (or after a failure).
            statusPanel.Visible = ( Session.Status.CurrentState == ConnectionStatus.State.CONNECTING || Session.Status.CurrentState == ConnectionStatus.State.FAILED );

            // Enable input only while connected.
            tbInput.Enabled = cbSelectedDatabase.Enabled = tbConsoleBox.Enabled = ( Session.Status.CurrentState == ConnectionStatus.State.CONNECTED );

            // Make the status icon in the tab represent the connection state.
            ParentTab.ImageIndex = (int) Session.Status.CurrentState;

            // Rebuild the dropdown of available databases.
            cbSelectedDatabase.Items.Clear( );
            cbSelectedDatabase.Items.AddRange( Session.Cache.Databases.ToArray( ) );

            // Select the current database (if needed).
            if ( cbSelectedDatabase.Text != Session.Cache.CurrentDatabase )
                cbSelectedDatabase.Text = Session.Cache.CurrentDatabase;
        }

        private void OnConnected( )
        {
            Session.Client.InputReceived += AddToLog;
            Session.Cache.CacheUpdated += UpdateState;
            tbInput.Submitted += SubmitCommand;

            // Show some useful startup text.
            tbConsoleBox.Text = "Connected to " + Session.Address.HostName + Environment.NewLine;            

            tbInput.Select( );
        }

        private void AddToLog( string text )
        {
            if ( Session.Status.CurrentState == ConnectionStatus.State.CONNECTED )
                Session.Cache.UpdateCache( );
            tbConsoleBox.Append( text );
        }

        private void SubmitCommand( string command )
        {
            if ( !command.EndsWith( Environment.NewLine ) )
                command += Environment.NewLine;

            tbConsoleBox.Append( "> " + command );
            Session.Client.Send( command );
        }

        private void SwitchDatabase( string newDatabase )
        {
            if ( newDatabase == Session.Cache.CurrentDatabase )
                return;

            Session.Cache.CurrentDatabase = newDatabase;
            tbInput.Submit( "use " + newDatabase );
            tbInput.Select( );
        }

        private void SessionPanel_Resize( object sender, EventArgs e )
        {
            statusInsidePanel.Left = Width / 2 - statusInsidePanel.Width / 2;
        }

        private void cbSelectedDatabase_SelectedIndexChanged( object sender, EventArgs e )
        {
            SwitchDatabase( cbSelectedDatabase.Text );
        }

        private void cbSelectedDatabase_Leave( object sender, EventArgs e )
        {
            SwitchDatabase( cbSelectedDatabase.Text );
        }
    }
}
