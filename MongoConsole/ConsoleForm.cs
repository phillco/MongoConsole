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
        private StreamReader input;
        private StreamWriter output;

        public ConsoleForm( StreamReader input, StreamWriter output )
        {
            InitializeComponent( );

            this.input = input;
            this.output = output;

            var t = new Thread( InputInLoop );
            t.IsBackground = true;
            t.Start( );
        }

        private void InputInLoop( )
        {
            while ( true )
            {
                string line = input.ReadLine( );
                if ( !string.IsNullOrEmpty( line ) )
                    this.Invoke( (MethodInvoker) delegate( ) { tbConsoleBox.Text += line + Environment.NewLine; } );
                else
                    Thread.Sleep( 5 );
            }
        }

        private void tbInput_KeyUp( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                tbConsoleBox.Text += "> " + tbInput.Text + Environment.NewLine;
                output.WriteLine( tbInput.Text + Environment.NewLine );
                tbInput.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
