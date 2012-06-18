using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MongoConsole.UI.Component
{
    /// <summary>
    /// Handles the UI side of autocompletion for MongoSessionPanel.
    /// </summary>
    class AutoCompleteMaker
    {
        private HistoryTextBox inputTextBox;

        private ListBox popUpList;

        private string filterTextTyped = "";

        private int originalTextPosition;

        private MongoSessionPanel parent;

        //=================================================================================
        //
        //  CONSTRUCTORS
        //
        //=================================================================================

        public static void Initialize( MongoSessionPanel parent )
        {
            new AutoCompleteMaker( parent, parent.tbInput, parent.lbAutoComplete );
        }

        private AutoCompleteMaker( MongoSessionPanel parent, HistoryTextBox textBox, ListBox autocompleteBox )
        {
            inputTextBox = textBox;
            popUpList = autocompleteBox;
            this.parent = parent;

            inputTextBox.KeyDown += InputBox_KeyDown;
            popUpList.KeyPress += PopUpList_KeyPress;
            popUpList.KeyUp += PopUpList_KeyUp;
        }

        //=================================================================================
        //
        //  PRIVATE METHODS
        //
        //=================================================================================

        private void StartAutoComplete( )
        {
            originalTextPosition = inputTextBox.SelectionStart;

            // Position the autocomplete box apropriately.
            Point p = inputTextBox.GetPositionFromCharIndex( inputTextBox.SelectionStart );
            p.X += inputTextBox.Left += 15;
            p.Y += parent.tbConsoleBox.Height - ( popUpList.Height + inputTextBox.Height );

            inputTextBox.HistoryEnabled = false;
            popUpList.SelectedIndex = 0;
            popUpList.Location = p;
            popUpList.Show( );

            parent.ActiveControl = popUpList;
        }

        private void StopAutoComplete( )
        {
            filterTextTyped = "";
            popUpList.Hide( );
            inputTextBox.Select( );
            inputTextBox.HistoryEnabled = true;
        }

        private object GetMatchingString( string prefix, ListBox.ObjectCollection items )
        {
            foreach ( object o in items )
            {
                var s = o.ToString( );
                if ( !string.IsNullOrEmpty( s ) && s.StartsWith( prefix, StringComparison.CurrentCultureIgnoreCase ) )
                    return o;
            }

            return null;
        }

        //=================================================================================
        //
        //  InputBox Events
        //
        //=================================================================================

        private void InputBox_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.OemPeriod && !e.Shift )
                StartAutoComplete( );
        }

        //=================================================================================
        //
        //  PopUpList Events
        //
        //=================================================================================

        private void PopUpList_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( e.KeyChar == 27 ) // Escape - don't process.
                return;

            if ( e.KeyChar == 8 ) // Backspace - handle specially.
                inputTextBox.Text = inputTextBox.Text.Remove( inputTextBox.Text.Length - 1, 1 );
            else
                inputTextBox.SelectedText = e.KeyChar.ToString( );
        }

        private void PopUpList_KeyUp( object sender, KeyEventArgs e )
        {
            // Don't handle up or down keys. Pass these on to the control.
            if ( e.KeyCode == Keys.Down || e.KeyCode == Keys.Up )
                return;

            switch ( e.KeyCode )
            {
                case Keys.Escape:
                    StopAutoComplete( );
                    break;

                case Keys.Back: // Backspace
                    inputTextBox.Text.Remove( inputTextBox.Text.Length - 1, 1 );
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Return: // Enter or Return
                    inputTextBox.Select( originalTextPosition + 1, inputTextBox.SelectionStart );
                    inputTextBox.SelectedText = popUpList.SelectedItem.ToString( );
                    StopAutoComplete( );
                    e.SuppressKeyPress = true;
                    break;

                case Keys.OemPeriod:
                    break;

                default:
                    filterTextTyped += e.KeyCode;

                    // Match what the user has typed to a 
                    var matched = GetMatchingString( filterTextTyped, popUpList.Items );

                    if ( matched == null )
                        StopAutoComplete( );
                    else
                        popUpList.SelectedItem = matched;
                    break;
            }
        }
    }
}
