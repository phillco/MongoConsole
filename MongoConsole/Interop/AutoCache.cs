using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using System.Threading;

namespace MongoConsole.Interop
{
    /// <summary>
    /// Maintains a constantly-updated cache of information about the server to support autocompletion in the UI.
    /// </summary>
    public class AutoCache
    {
        //=================================================================================
        //
        //  PROPERTIES
        //
        //=================================================================================

        public List<string> Databases { get; private set; }

        public Dictionary<string, List<string>> Collections { get; private set; }

        public string CurrentDatabase { get; set; }

        //=================================================================================
        //
        //  EVENTS
        //
        //=================================================================================

        public event CacheUpdatedDelegate CacheUpdated;

        public delegate void CacheUpdatedDelegate( );

        //=================================================================================
        //
        //  PRIVATE VARIABLES
        //
        //=================================================================================

        private MongoServer server;

        //=================================================================================
        //
        //  CONSTRUCTORS
        //
        //=================================================================================

        public AutoCache( MongoServer server, string currentDatabase = "test" )
        {
            this.server = server;
            Databases = new List<string>( );
            CurrentDatabase = currentDatabase;
            Collections = new Dictionary<string, List<string>>( );
        }

        //=================================================================================
        //
        //  PUBLIC METHODS
        //
        //=================================================================================

        public void UpdateCache( )
        {
            Databases = server.GetDatabaseNames( ).ToList( );
            if ( CacheUpdated != null )
                CacheUpdated( );
        }
    }
}
