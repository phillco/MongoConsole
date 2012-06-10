using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using MongoDB.Driver;

namespace MongoConsole.Interop
{
    /// <summary>
    /// Represents a mongo administration session.
    /// </summary>
    public class MongoSession
    {
        public ProcessWrapper Client { get; private set; }

        public MongoServer Server { get; private set; }

        public MongoSession( )
        {
            Client = ProcessWrapper.Start( "mongo.exe", "" );
            Server = MongoServer.Create( );
        }

        public void Start( )
        {
            Client.Start( );
            Server.Ping( );
        }
    }
}
