using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MongoConsole.UI.Component
{
    class AutoCompleteMaker
    {
        private HistoryTextBox tbInput;

        private ListBox lbAutoComplete;

        private string AutoCompleteTextEntered = "";

        private int CurrentTagStart = 0;

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
            tbInput = textBox;
            lbAutoComplete = autocompleteBox;
            this.parent = parent;

            tbInput.KeyDown += tbInput_KeyDown;
            lbAutoComplete.KeyPress += lbAutoComplete_KeyPress;
            lbAutoComplete.KeyUp += lbAutoComplete_KeyUp;
        }

        private void StartAutoComplete( )
        {
            CurrentTagStart = tbInput.SelectionStart;

            // Position the autocomplete box apropriately.
            Point p = tbInput.GetPositionFromCharIndex( tbInput.SelectionStart );
            p.X += tbInput.Left += 15;
            p.Y += parent.tbConsoleBox.Height - ( lbAutoComplete.Height + tbInput.Height );

            tbInput.HistoryEnabled = false;
            lbAutoComplete.SelectedIndex = 0;
            lbAutoComplete.Location = p;
            lbAutoComplete.Show( );

            parent.ActiveControl = lbAutoComplete;
        }

        private void StopAutoComplete( )
        {
            AutoCompleteTextEntered = "";
            lbAutoComplete.Hide( );
            tbInput.Select( );
            tbInput.HistoryEnabled = true;
        }

        void tbInput_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.OemPeriod && !e.Shift )
                StartAutoComplete( );
        }

        private void lbAutoComplete_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( e.KeyChar == 27 )
                return;

            if ( e.KeyChar == 8 )
            {
                tbInput.Text = tbInput.Text.Remove( tbInput.Text.Length - 1, 1 );
                return;
            }

            tbInput.SelectedText = e.KeyChar.ToString( );
        }

        private void lbAutoComplete_KeyUp( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Down || e.KeyCode == Keys.Up )
                return;

            if ( e.KeyCode == Keys.Escape ) // ESC -> Exit autocomplete
            {
                StopAutoComplete( );
                return;
            }
            else if ( e.KeyCode == Keys.Back ) // Backspace
            {
                tbInput.Text.Remove( tbInput.Text.Length - 1, 1 );
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if ( e.KeyCode == Keys.Return )
            {
                // Command submitted!
                tbInput.Select( CurrentTagStart + 1, tbInput.SelectionStart );
                tbInput.SelectedText = lbAutoComplete.SelectedItem.ToString( );
                StopAutoComplete( );
                e.SuppressKeyPress = true;
            }
            else if ( e.KeyCode != Keys.OemPeriod )
            {
                AutoCompleteTextEntered += e.KeyCode;

                // Match what the user has typed to a 
                var matched = GetMatchingString( AutoCompleteTextEntered, lbAutoComplete.Items );

                if ( matched == null )
                    StopAutoComplete( );
                else
                    lbAutoComplete.SelectedItem = matched;
            }
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
    }
}
