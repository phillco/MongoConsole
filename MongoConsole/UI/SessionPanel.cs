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
    /// Represents ONE mongo administration session; provides a console, input box, etc.
    /// </summary>
    public partial class SessionPanel : UserControl
    {
        public TabPage TabPage
        {
            get
            {
                if ( tab == null )
                {
                    tab = new TabPage( session.Address.HostName );
                    tab.ImageIndex = (int) session.CurrentState;
                    tab.Controls.Add( this );
                }

                return tab;
            }
        }

        private MongoSession session;

        private TabPage tab;

        public SessionPanel( MongoSession session )
        {
            this.session = session;
            Dock = DockStyle.Fill;
            InitializeComponent( );
        }

        private void SessionTab_Load( object sender, EventArgs e )
        {
            session.StateChanged += UpdateState;
            session.Client.InputReceived += AddToLog;
            session.Start( );

            UpdateState( );
        }

        public void UpdateState( )
        {
            if ( this.InvokeRequired )
            {
                this.Invoke( (MethodInvoker) UpdateState );
                return;
            }

            tab.ImageIndex = (int) session.CurrentState;
            if ( session.CurrentState == MongoSession.State.CONNECTING )
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
                session.Client.Send( command );
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
