using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoConsole.Interop
{
    public class ConnectionStatus
    {
        //=================================================================================
        //
        //  PROPERTIES
        //
        //=================================================================================

        public enum State { DISCONNECTED, CONNECTING, CONNECTED, FAILED }

        /// <summary>
        /// The string the user specified to connect to.
        /// </summary>
        public string OriginalConnectionString { get; set; }

        // public string StatusString { get; set; }

        public string FailureString { get; set; }

        public State CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                currentState = value;
                if ( StateChanged != null ) // Fire the event!
                    StateChanged( );
            }
        }


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

    }
}
