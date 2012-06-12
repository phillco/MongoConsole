using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using MongoDB.Driver;
using System.Net;
using System.Net.Sockets;

namespace MongoConsole.Interop
{
    /// <summary>
    /// Represents a mongo administration session.
    /// </summary>
    public class MongoSession
    {
        public enum State { DISCONNECTED, CONNECTING, CONNECTED }

        public State CurrentState
        {
            get { return currentState; }
            private set
            {
                currentState = value;
                if ( StateChanged != null )
                    StateChanged( );
            }
        }

        public RemoteHost Address { get; private set; }

        public ProcessWrapper Client { get; private set; }

        public MongoServer Server { get; private set; } 

        public event VoidDelegate StateChanged;

        public delegate void VoidDelegate( );

        private State currentState = State.DISCONNECTED;

        public MongoSession( )
            : this( "localhost" )
        {}

        public MongoSession( string address )
            : this( Util.Resolve( address, 27017 ))
        { }

        public MongoSession( RemoteHost address )
        {
            this.Address = address;
            this.CurrentState = State.DISCONNECTED;
            Client = ProcessWrapper.Start( "mongo.exe", address.EndPoint.ToString() );
            Server = MongoServer.Create( new MongoServerSettings { Server = new MongoServerAddress( address.HostName, address.EndPoint.Port ) } );
        }

        public void Start( )
        {
            this.CurrentState = State.CONNECTING;
            ThreadPool.QueueUserWorkItem( delegate
            {
                Client.Start( );
                try
                {
                    Server.Ping( );
                    this.CurrentState = State.CONNECTED;
                }
                catch ( SocketException )
                {
                    this.CurrentState = State.DISCONNECTED;
                }
            } );
        }
    }
}
