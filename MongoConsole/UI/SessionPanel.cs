using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoConsole.Interop;

namespace MongoConsole.UI
{
    /// <summary>
    /// The actual mongo administration panel (for one session) with the console, input box, etc.
    /// Contained by a SessionTab. (Why not merge them? Because then you lose the form editor).
    /// </summary>
    public partial class SessionPanel : UserControl
    {
        public MongoSession Session { get { return ParentTab.Session; } }

        private SessionTab ParentTab;

        public SessionPanel( SessionTab parent )
        {
            ParentTab = parent;
            Dock = DockStyle.Fill;
            InitializeComponent( );
        }

        private void SessionTab_Load( object sender, EventArgs e )
        {
            Session.StateChanged += UpdateState;
            Session.Client.InputReceived += AddToLog;
            Session.Start( );

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
        }

        private void AddToLog( string text )
        {
            this.Invoke( (MethodInvoker) delegate
            {
                tbConsoleBox.Text += text;
            } );
        }

        private void tbInput_KeyUp( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                var command = tbInput.Text + Environment.NewLine;
                tbConsoleBox.Text += "> " + command;
                Session.Client.Send( command );
                tbInput.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SessionPanel_Resize( object sender, EventArgs e )
        {
            statusInsidePanel.Left = Width / 2 - statusInsidePanel.Width / 2;
        }
    }
}
