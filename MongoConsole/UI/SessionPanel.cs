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
    public partial class SessionPanel : UserControl
    {
        public MongoSession Session { get { return ParentTab.Session; } }

        private MongoTab ParentTab;

        public SessionPanel( MongoTab parent )
        {
            InitializeComponent( );
            ParentTab = parent;
            Dock = DockStyle.Fill;
            statusPanel.Dock = DockStyle.Fill;
        }

        private void SessionTab_Load( object sender, EventArgs e )
        {
            Session.StateChanged += UpdateState;
            Session.Client.InputReceived += AddToLog;
            Session.Start( );
            Session.Cache.CacheUpdated += UpdateState;
            tbInput.Submitted += SubmitCommand;
            tbInput.Select( );
            UpdateState( );
        }

        public void UpdateState( )
        {
            if ( this.InvokeRequired )
            {
                this.Invoke( (MethodInvoker) UpdateState );
                return;
            }

            ParentTab.ImageIndex = (int) Session.CurrentState;
            if ( Session.CurrentState == MongoSession.State.CONNECTING )
            {
                statusPanel.Show( );
                lblStatusHeader.Text = "Connecting...";
            }
            else
                statusPanel.Hide( );

            cbSelectedDatabase.Items.Clear( );
            cbSelectedDatabase.Items.AddRange( Session.Cache.Databases.ToArray( ) );

            if ( cbSelectedDatabase.Text != Session.Cache.CurrentDatabase )
            cbSelectedDatabase.Text = Session.Cache.CurrentDatabase;
        }

        private void AddToLog( string text )
        {
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
