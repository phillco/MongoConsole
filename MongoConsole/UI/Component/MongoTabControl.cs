using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoConsole.Interop;
using System.Drawing;

namespace MongoConsole.UI.Component
{
    /// <summary>
    /// The main tab control that holds the MongoTabs.
    /// </summary>
    public partial class MongoTabControl : TabControl
    {
        //=================================================================================
        //
        //  PROPERTIES
        //
        //=================================================================================

        public new MongoTab SelectedTab
        {
            get
            {
                return (MongoTab) base.SelectedTab;
            }
            set
            {
                base.SelectedTab = value;
            }
        }

        //=================================================================================
        //
        //  EVENTS
        //
        //=================================================================================

        public event VoidDelegate NumTabsChanged;

        public delegate void VoidDelegate( );

        //=================================================================================
        //
        //  PRIVATE VARIABLES
        //
        //=================================================================================

        /// <summary>The tab that the current context menu is opening for.</summary>
        private MongoTab contextTab;

        //=================================================================================
        //
        //  CONSTRUCTORS
        //
        //=================================================================================

        public MongoTabControl( )
        {
            InitializeComponent( );
            MouseClick += event_MouseClick;
            mnuCloseTab.Click += ( target, e ) => CloseTab( contextTab );
            mnuDuplicateTab.Click += ( target, e ) => DuplicateTab( contextTab );
        }

        //=================================================================================
        //
        //  PUBLIC METHODS
        //
        //=================================================================================

        public void Add( MongoSession newSession )
        {
            var tab = new MongoTab( newSession );
            TabPages.Add( tab );
            SelectTab( tab );

            if ( NumTabsChanged != null )
                NumTabsChanged( );
        }

        public void CloseTab( MongoTab tab )
        {
            tab.Session.Stop( );
            TabPages.Remove( tab );

            if ( NumTabsChanged != null )
                NumTabsChanged( );
        }

        public void DuplicateTab( MongoTab tab )
        {
            Add( new MongoSession( tab.Session.Address ) );
        }

        //=================================================================================
        //
        //  PRIVATE METHODS
        //
        //=================================================================================

        private void event_MouseClick( object sender, MouseEventArgs e )
        {
            // Extract selected tab.
            MongoTab tab = GetSelectedTabIndex( e.Location );
            if ( tab == null )
                return;

            switch ( e.Button )
            {
                case MouseButtons.Middle: // Middle-click to close tabs, like Chrome.
                    CloseTab( tab );
                    break;
                case MouseButtons.Right:
                    contextTab = tab;
                    tabContextMenu.Show( this, e.Location );
                    break;
            }
        }

        /// <summary>
        /// Finds which tab was clicked at the specific point.
        /// </summary>
        private MongoTab GetSelectedTabIndex( Point clickLocation )
        {
            for ( int i = 0; i < TabCount; i++ )
            {
                // Does the tab area contain the mouse pointer?
                Rectangle r = GetTabRect( i );
                if ( r.Contains( clickLocation ) )
                    return (MongoTab) TabPages[i];
            }

            return null;
        }
    }
}
