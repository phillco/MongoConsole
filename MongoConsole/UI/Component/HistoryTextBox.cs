using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MongoConsole.UI.Component
{
    /// <summary>
    /// A textbox that saves all the commands previously entered, allowing the user to easily re-enter or correct them.
    /// Up and Down scrolls through the command history; Enter submits.
    /// </summary>
    class HistoryTextBox : TextBox
    {
        /// <summary>
        /// The actual history of commands. Most recent commands are at the front; oldest ones at the end.
        /// </summary>
        private List<string> History = new List<string>( );

        /// <summary>
        /// Where we are in the History[] array.
        /// </summary>
        private int PositionInHistory = -1;

        /// <summary>
        /// A command the user was entering but hadn't submitted yet -- we back this up if they start scrolling.
        /// </summary>
        private string SavedCommand = "";

        public HistoryTextBox( )
        {
            History = new string[] { "one", "two", "three", "four" }.ToList( );
            this.KeyDown += HistoryTextBox_KeyUp;
        }

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
                    break;
            }
        }

        public void ScrollHistoryUp( )
        {
            if ( PositionInHistory + 1 < History.Count )
            {
                // Back up the unsubmitted command before scrolling.
                if ( PositionInHistory == -1 )
                    SavedCommand = Text;

                PositionInHistory++;
                Text = History[PositionInHistory];
                Select( Text.Length, 0 );
            }
        }

        public void ScrollHistoryDown( )
        {
            if ( PositionInHistory > 0 )
            {
                PositionInHistory--;
                Text = History[PositionInHistory];
                Select( Text.Length, 0 );
            }
            else
                Text = SavedCommand; // At level -1; restore the unsubmitted command.
        }

        public void Submit( string text )
        {
            PositionInHistory = -1;
            SavedCommand = "";
            History.Insert( 0, text );
        }
    }
}
