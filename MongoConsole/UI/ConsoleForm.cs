using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using MongoConsole.Interop;

namespace MongoConsole.UI
{
    /// <summary>
    /// Shows the mongo console.
    /// </summary>
    public partial class ConsoleForm : Form
    {
        public ConsoleForm()
        {
            InitializeComponent( );
        }

        public void Add( MongoSession newSession )
        {
            var pane = new SessionTab( newSession );
            sessionTabs.TabPages.Add( pane.ToTabPage() );
        }
    }
}
