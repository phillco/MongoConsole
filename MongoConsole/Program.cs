using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MongoConsole.UI;
using MongoConsole.Interop;

namespace MongoConsole
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main( )
        {
            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );

            var session = new MongoSession( );
            Application.Run( new ConsoleForm( session ) );
        }
    }
}
