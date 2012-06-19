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

        public bool Initialized { get; private set; }

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
            if ( this.InvokeRequired )
            {
                this.Invoke( (MethodInvoker) UpdateState );
                return;
            }

            switch ( Session.Status.CurrentState )
            {
                case ConnectionStatus.State.CONNECTED:
                    if ( !Initialized )
                    {
                        statusPanel.Hide( );
                        Session.Client.InputReceived += AddToLog;
                        Session.Cache.CacheUpdated += UpdateState;
                        tbConsoleBox.Text = "Connected to " + Session.Address.HostName + Environment.NewLine;
                        tbInput.Submitted += SubmitCommand;
                        tbInput.Select( );                        
                        Initialized = true;                        
                    }
                    break;

                case ConnectionStatus.State.CONNECTING:
                    statusPanel.Show( );
                    lblStatusHeader.Text = "Connecting...";
                    break;

                case ConnectionStatus.State.DISCONNECTED:
                    break;

                case ConnectionStatus.State.FAILED:
                    statusPanel.Show( );
                    pbConnecting.Hide( );
                    lblStatusSubHeader.Show( );
                    lblStatusHeader.Text = "Failure";
                    lblStatusSubHeader.Text = Session.Status.FailureReason;
                    break;
            }

            ParentTab.ImageIndex = (int) Session.Status.CurrentState;
            tbInput.Enabled = cbSelectedDatabase.Enabled = tbConsoleBox.Enabled = ( Session.Status.CurrentState == ConnectionStatus.State.CONNECTED );
            cbSelectedDatabase.Items.Clear( );
            cbSelectedDatabase.Items.AddRange( Session.Cache.Databases.ToArray( ) );

            if ( cbSelectedDatabase.Text != Session.Cache.CurrentDatabase )
                cbSelectedDatabase.Text = Session.Cache.CurrentDatabase;
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
