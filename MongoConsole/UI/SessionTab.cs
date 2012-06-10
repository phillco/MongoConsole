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
    public partial class SessionTab : UserControl
    {
        private MongoSession session;

        public SessionTab( MongoSession session )
        {
            this.session = session;
            InitializeComponent( );
        }

        public TabPage ToTabPage( )
        {
            var tab = new TabPage( "Local session" );
            tab.Controls.Add( this );
            Dock = DockStyle.Fill;
            return tab;
        }

        private void SessionTab_Load( object sender, EventArgs e )
        {
            session.Client.InputReceived += AddToLog;
            session.Start( );
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
    }
}
