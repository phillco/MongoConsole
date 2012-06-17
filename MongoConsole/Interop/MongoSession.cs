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
        //=================================================================================
        //
        //  PROPERTIES
        //
        //=================================================================================

        public enum State { DISCONNECTED, CONNECTING, CONNECTED }

        public State CurrentState
        {
            get
            { 
                return currentState;
            }
            private set
            {
                currentState = value;
                if ( StateChanged != null ) // Fire the event!
                    StateChanged( );
            }
        }

        /// <summary>
        /// The address of the server we're connected to.
        /// </summary>
        public RemoteHost Address { get; private set; }

        /// <summary>
        /// The local mongo.exe connection to the serer.
        /// </summary>
        public ProcessWrapper Client { get; private set; }

        /// <summary>
        /// The driver connection to the server.
        /// </summary>
        public MongoServer Server { get; private set; }

        public AutoCache Cache { get; private set; }

        //=================================================================================
        //
        //  EVENTS
        //
        //=================================================================================

        public event VoidDelegate StateChanged;

        public delegate void VoidDelegate( );

        //=================================================================================
        //
        //  PRIVATE VARIABLES
        //
        //=================================================================================

        private State currentState = State.DISCONNECTED;

        //=================================================================================
        //
        //  CONSTRUCTORS
        //
        //=================================================================================

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
            Cache = new AutoCache( Server );
        }

        //=================================================================================
        //
        //  PUBLIC METHODS
        //
        //=================================================================================

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

        public void Stop( )
        {
            this.CurrentState = State.DISCONNECTED;
            Server.Disconnect( );
            Client.Stop( );
        }

        public override string ToString( )
        {
            if ( Address.EndPoint.Port == Constants.DefaultMongoServerPort )
                return Address.HostName;
            else
                return Address.HostName + ":" + Address.EndPoint.Port;
        }
    }
}
