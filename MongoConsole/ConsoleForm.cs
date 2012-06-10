using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace MongoConsole
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ConsoleForm : Form
    {
        private MongoSession session;

        public ConsoleForm( MongoSession session )
        {
            InitializeComponent( );
            this.session = session;
        }

        private void ConsoleForm_Load( object sender, EventArgs e )
        {
            session.InputReceived += AddToLog;
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
                var command =  tbInput.Text + Environment.NewLine;
                tbConsoleBox.Text += "> " + command;
                session.Send( command );
                tbInput.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
