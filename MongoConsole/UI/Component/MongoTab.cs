using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoConsole.Interop;

namespace MongoConsole.UI.Component
{
    /// <summary>
    /// A TabPage that holds a MongoSession and its corresponding SessionPanel.
    /// </summary>
    public class MongoTab : TabPage
    {
        public MongoSession Session { get; private set; }

        public MongoSessionPanel Panel { get; private set; }

        public MongoTab( MongoSession session ) : base( session.ToString() )
        {
            Session = session;
            ImageIndex = (int) Session.Status.CurrentState;
            Controls.Add( new MongoSessionPanel( this ) );
            session.Status.StateChanged += ( ) => Invoke( (MethodInvoker) delegate
            {
                this.Text = session.ToString( );
            } );
        }
    }
}
