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
        private MongoSession session;

        public SessionPanel( MongoSession session )
        {
            this.session = session;
            InitializeComponent( );
        }

        /// <summary>
        /// Wraps the panel in a TabPage, so it can easily be added to a tab control.
        /// </summary>
        public TabPage WrapInTabPage( )
        {
            var tab = new TabPage( session.Address.HostName );
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
