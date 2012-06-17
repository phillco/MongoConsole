using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace MongoConsole.UI.Component
{
    /// <summary>
    /// A textbox that saves all the commands previously entered, allowing the user to easily re-enter or correct them.
    /// Up and Down scrolls through the command history; Enter submits.
    /// </summary>
    class HistoryTextBox : TextBox
    {
        //=================================================================================
        //
        //  PROPERTIES
        //
        //=================================================================================

        public const int DefaultMaxEntries = 1024;

        /// <summary>
        /// The actual history of commands. Most recent commands are at the front; oldest ones at the end.
        /// Position 0 is reserved for scratch.
        /// </summary>
        public List<string> History { get; private set; }

        /// <summary>
        /// The maximum number of entries remembered. Excess entries are trimmed on Submit().
        /// </summary>
        [Description( "The maximum number of entries remembered. Excess entries are trimmed on Submit()." ), DefaultValue( DefaultMaxEntries )]
        public int MaxEntries { get; set; }

        //=================================================================================
        //
        //  EVENTS
        //
        //=================================================================================

        /// <summary>Occurs when a new command has been submitted with the "Enter" key.</summary>
        public event SubmitDelegate Submitted;

        public delegate void SubmitDelegate( string text );

        //=================================================================================
        //
        //  PRIVATE VARIABLES
        //
        //=================================================================================

        /// <summary>
        /// Where we are in the History[] array.
        /// </summary>
        private int PositionInHistory = 0;

        //=================================================================================
        //
        //  CONSTRUCTORS
        //
        //=================================================================================

        public HistoryTextBox( ) : this( DefaultMaxEntries )
        {
        }

        public HistoryTextBox( int maxEntries )
        {
            MaxEntries = Math.Min( maxEntries, 1 ); // Always need at least 1.
            History = new List<string>( new string[] { "" } );
            this.KeyDown += HistoryTextBox_KeyUp;
        }

        //=================================================================================
        //
        //  PUBLIC METHODS
        //
        //=================================================================================

        /// <summary>
        /// Scrolls the history "up" towards older commands (forward through the History[] array).
        /// </summary>
        public void ScrollHistoryUp( )
        {
            if ( PositionInHistory < History.Count - 1 )
            {
                // Back up the unsubmitted command before scrolling.
                if ( PositionInHistory == 0 )
                    History[0] = Text;

                PositionInHistory++;
                Text = History[PositionInHistory];
                Select( Text.Length, 0 );
            }

            Trace.WriteLine( "At: " + PositionInHistory );
        }

        /// <summary>
        /// Scrolls the history "down" towards newer commands (backwards through the History[] array).
        /// </summary>
        public void ScrollHistoryDown( )
        {
            if ( PositionInHistory > 0 )
            {
                PositionInHistory--;
                Text = History[PositionInHistory];
                Select( Text.Length, 0 );
            }
            else
            {
                // Potentially allow the user to scroll down to -1 if they are on level 0.
                // This is an easy way to save your work and get a fresh prompt.
                if ( PositionInHistory == 0 && !string.IsNullOrEmpty( Text ) )
                {
                    // Back up the unsubmitted command before scrolling.
                    if ( PositionInHistory == 0 )
                        History[0] = Text;

                    Text = "";
                    PositionInHistory = -1;
                }
            }

            Trace.WriteLine( "At: " + PositionInHistory );
        }

        /// <summary>
        /// Submits the given command to the history. (Also fires Submitted).
        /// </summary>
        public void Submit( string text )
        {
            // Back up the scratch command first.
            if ( !string.IsNullOrEmpty( History[0] ) )
                History.Insert( 1, History[0] );

            History.Insert( 1, text );
            PositionInHistory = 0;
            Text = "";
            History[0] = ""; // Wipe scratch.

            // Remove excess entries.
            if ( History.Count > MaxEntries + 1 )
                History.RemoveRange( MaxEntries + 1, History.Count - ( MaxEntries + 1 ) );

            if ( Submitted != null )
                Submitted( text );
        }

        //=================================================================================
        //
        //  PRIVATE METHODS
        //
        //=================================================================================

        private void HistoryTextBox_KeyUp( object sender, KeyEventArgs e )
        {
            switch ( e.KeyCode )
            {
                case Keys.Up:
                    ScrollHistoryUp( );
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Down:
                    ScrollHistoryDown( );
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Enter:
                    Submit( Text );
                    e.SuppressKeyPress = true;
                    break;
            }
        }
    }
}
