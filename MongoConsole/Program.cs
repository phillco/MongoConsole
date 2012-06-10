using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MongoDB.Driver;
using System.Diagnostics;
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

            // Create the mongo console process.
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "mongo.exe",
                    ErrorDialog = false,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                }
            };

            process.Start( );
            var session = new MongoSession( process );
            Application.Run( new ConsoleForm( session ) );
        }
    }
}
