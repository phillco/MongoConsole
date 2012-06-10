using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using MongoDB.Driver;

namespace MongoConsole
{
    /// <summary>
    /// Represents a connection to a local mongo session.
    /// </summary>
    public class MongoSession
    {
        //=================================================================================
        //
        //  EVENTS
        //
        //=================================================================================

        /// <summary>
        /// Occurs when a new line of input has been received.
        /// </summary>
        public event InputReceivedDelegate InputReceived;

        public delegate void InputReceivedDelegate( string text );

        //=================================================================================
        //
        //  PRIVATE VARIABLES
        //
        //=================================================================================

        private MongoServer server;
        private StreamReader input;
        private StreamWriter output;

        //=================================================================================
        //
        //  CONSTRUCTORS
        //
        //=================================================================================

        public MongoSession( Process process ) : this( process.StandardOutput, process.StandardInput ) // Their output = our input
        {
        }

        public MongoSession( StreamReader input, StreamWriter output )
        {
            this.input = input;
            this.output = output;
        }

        //=================================================================================
        //
        //  METHODS
        //
        //=================================================================================

        public void Start( )
        {
            // Create the polling thread.
            var thread = new Thread( InputThreadLoop );
            thread.IsBackground = true;
            thread.Start( );

            server = MongoServer.Create( );
            server.Ping( );
        }

        /// <summary>
        /// Sends the given command to the console.
        /// </summary>
        /// <param name="command"></param>
        public void Send( string command )
        {
            output.WriteLine( command );
        }

        /// <summary>
        /// Loops forever, polling for input.
        /// </summary>
        private void InputThreadLoop( )
        {
            while ( true )
            {
                string line = input.ReadLine( ); // Does not block; returns null if no input.
                if ( !string.IsNullOrEmpty( line ) )
                {
                    if ( InputReceived != null )
                        InputReceived( line + Environment.NewLine );
                }
                else
                    Thread.Sleep( 15 );
            }
        }
    }
}
