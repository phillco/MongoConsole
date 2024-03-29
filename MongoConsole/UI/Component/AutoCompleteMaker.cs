﻿using System;
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
        private MongoSessionPanel parent;

        private HistoryTextBox inputTextBox;

        private ListBox popUpList;

        /// <summary>
        /// What the user has typed since autocomplete has appeared.
        /// </summary>
        private string filterTextTyped = "";

        /// <summary>
        /// The original cursor location when the autocomplete started.
        /// </summary>
        private int originalTextPosition;

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
            this.inputTextBox = textBox;
            this.popUpList = autocompleteBox;
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

        /// <summary>
        /// Shows the autocomplete UI.
        /// </summary>
        private void StartAutoComplete( )
        {
            filterTextTyped = "";
            originalTextPosition = inputTextBox.SelectionStart;

            // Position the autocomplete box correctly.
            Point p = inputTextBox.GetPositionFromCharIndex( inputTextBox.SelectionStart );
            p.X += inputTextBox.Left + 15;
            p.Y += parent.tbConsoleBox.Height - ( popUpList.Height + inputTextBox.Height );

            popUpList.SelectedIndex = 0;
            popUpList.Location = p;
            popUpList.Show( );

            parent.ActiveControl = popUpList;
        }

        /// <summary>
        /// Hides the autocomplete UI.
        /// </summary>
        private void StopAutoComplete( )
        {            
            popUpList.Hide( );
            inputTextBox.Select( );            
        }

        /// <summary>
        /// Returns the first item from the collection that starts with prefix.
        /// </summary>
        private object GetMatchingString( string prefix, ListBox.ObjectCollection items )
        {
            foreach ( object item in items )
            {
                var stringVersion = item.ToString( );
                if ( !string.IsNullOrEmpty( stringVersion ) && stringVersion.StartsWith( prefix, StringComparison.CurrentCultureIgnoreCase ) )
                    return item;
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

                    // Match what the user has typed to an existing object.
                    var matched = GetMatchingString( filterTextTyped, popUpList.Items );

                    if ( matched == null )
                        StopAutoComplete( );
                    else
                        popUpList.SelectedItem = matched;
                    break;
            }
        }

        private void PopUpList_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( e.KeyChar == 27 ) // Escape - don't process.
                return;

            if ( e.KeyChar == 8 ) // Backspace - handle specially.
                inputTextBox.Text = inputTextBox.Text.Remove( inputTextBox.Text.Length - 1, 1 );
            else
                inputTextBox.SelectedText = e.KeyChar.ToString( );
        }
    }
}
