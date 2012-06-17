using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MongoConsole.UI.Component
{
    /// <summary>
    /// The big textbox that holds the console history.
    /// </summary>
    public class ConsoleLogBox : TextBox
    {
        public ConsoleLogBox( )
        {
        }

        public void Append( string newText )
        {
            if ( InvokeRequired )
                Invoke( (MethodInvoker) delegate { Append( newText ); } );
            else
               AppendText( newText );
        }
    }
}
