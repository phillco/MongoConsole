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

        private MongoSession session;
        private MongoServer server { get { return session.Server; } }

        //=================================================================================
        //
        //  CONSTRUCTORS
        //
        //=================================================================================

        public AutoCache( MongoSession session, string currentDatabase = "test" )
        {
            this.session = session;
            Databases = new List<string>( );
            CurrentDatabase = currentDatabase;
            Collections = new Dictionary<string, List<string>>( );
            session.Status.StateChanged += UpdateCache;
        }

        //=================================================================================
        //
        //  PUBLIC METHODS
        //
        //=================================================================================

        public void UpdateCache( )
        {
            if ( session.Status.CurrentState != ConnectionStatus.State.CONNECTED )
                return;

            Databases = server.GetDatabaseNames( ).ToList( );
            if ( CacheUpdated != null )
                CacheUpdated( );
        }
    }
}
