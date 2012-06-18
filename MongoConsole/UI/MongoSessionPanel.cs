using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoConsole.Interop;
using MongoConsole.UI.Component;

namespace MongoConsole.UI
{
    /// <summary>
    /// The actual mongo administration panel (for one session) with the console, input box, etc.
    /// Contained by a SessionTab. (Why not merge them? Because then you lose the form editor).
    /// </summary>
    public partial class MongoSessionPanel : UserControl
    {
        public MongoSession Session { get { return ParentTab.Session; } }

        private MongoTab ParentTab;

        public string AutoCompleteTextEntered = "";

        public int CurrentTagStart = 0;

        public MongoSessionPanel( MongoTab parent )
        {
            InitializeComponent( );
            ParentTab = parent;
            Dock = DockStyle.Fill;
            statusPanel.Dock = DockStyle.Fill;
            tbInput.KeyDown += tbInput_KeyDown;
        }

        void tbInput_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.OemPeriod && !e.Shift )
                StartAutoComplete( );
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

        private void StartAutoComplete( )
        {
            CurrentTagStart = tbInput.SelectionStart;

            // Position the autocomplete box apropriately.
            Point p = tbInput.GetPositionFromCharIndex( tbInput.SelectionStart );
            p.X += tbInput.Left += 15;
            p.Y += tbConsoleBox.Height - ( lbAutoComplete.Height + tbInput.Height );

            tbInput.HistoryEnabled = false;
            lbAutoComplete.SelectedIndex = 0;
            lbAutoComplete.Location = p;
            lbAutoComplete.Show( );

            ActiveControl = lbAutoComplete;
        }

        private void StopAutoComplete( )
        {
            AutoCompleteTextEntered = "";
            lbAutoComplete.Hide( );
            tbInput.Select( );
            tbInput.HistoryEnabled = true;
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

        private void SessionTab_Load( object sender, EventArgs e )
        {
            Session.StateChanged += UpdateState;
            Session.Client.InputReceived += AddToLog;
            Session.Start( );
            Session.Cache.CacheUpdated += UpdateState;
            tbInput.Submitted += SubmitCommand;
            tbInput.Select( );
            UpdateState( );
        }

        public void UpdateState( )
        {
            if ( this.InvokeRequired )
            {
                this.Invoke( (MethodInvoker) UpdateState );
                return;
            }

            ParentTab.ImageIndex = (int) Session.CurrentState;
            if ( Session.CurrentState == MongoSession.State.CONNECTING )
            {
                statusPanel.Show( );
                lblStatusHeader.Text = "Connecting...";
            }
            else
                statusPanel.Hide( );

            cbSelectedDatabase.Items.Clear( );
            cbSelectedDatabase.Items.AddRange( Session.Cache.Databases.ToArray( ) );

            if ( cbSelectedDatabase.Text != Session.Cache.CurrentDatabase )
                cbSelectedDatabase.Text = Session.Cache.CurrentDatabase;
        }

        private void AddToLog( string text )
        {
            if ( Session.CurrentState == MongoSession.State.CONNECTED )
                Session.Cache.UpdateCache( );
            tbConsoleBox.Append( text );
        }

        private void SubmitCommand( string command )
        {
            if ( !command.EndsWith( Environment.NewLine ) )
                command += Environment.NewLine;

            tbConsoleBox.Append( "> " + command );
            Session.Client.Send( command );
        }

        private void SwitchDatabase( string newDatabase )
        {
            if ( newDatabase == Session.Cache.CurrentDatabase )
                return;

            Session.Cache.CurrentDatabase = newDatabase;
            tbInput.Submit( "use " + newDatabase );
            tbInput.Select( );
        }

        private void SessionPanel_Resize( object sender, EventArgs e )
        {
            statusInsidePanel.Left = Width / 2 - statusInsidePanel.Width / 2;
        }

        private void cbSelectedDatabase_SelectedIndexChanged( object sender, EventArgs e )
        {
            SwitchDatabase( cbSelectedDatabase.Text );
        }

        private void cbSelectedDatabase_Leave( object sender, EventArgs e )
        {
            SwitchDatabase( cbSelectedDatabase.Text );
        }
    }
}
