﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using MongoDB.Driver;
using System.Net;

namespace MongoConsole.Interop
{
    /// <summary>
    /// Represents a mongo administration session.
    /// </summary>
    public class MongoSession
    {
        public RemoteHost Address { get; private set; }

        public ProcessWrapper Client { get; private set; }

        public MongoServer Server { get; private set; }

        public MongoSession( )
            : this( "localhost" )
        {}

        public MongoSession( string address )
            : this( Util.Resolve( address, 27017 ))
        { }

        public MongoSession( RemoteHost address )
        {
            this.Address = address;
            Client = ProcessWrapper.Start( "mongo.exe", address.ToString() );
            Server = MongoServer.Create( new MongoServerSettings { Server = new MongoServerAddress( address.HostName, address.EndPoint.Port ) } );
        }

        public void Start( )
        {
            Client.Start( );
            Server.Ping( );
        }
    }
}
