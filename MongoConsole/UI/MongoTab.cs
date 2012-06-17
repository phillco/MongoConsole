using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoConsole.Interop;

namespace MongoConsole.UI
{
    /// <summary>
    /// A TabPage that holds a MongoSession and its corresponding SessionPanel.
    /// </summary>
    public class MongoTab : TabPage
    {
        public MongoSession Session { get; private set; }

        public SessionPanel Panel { get; private set; }

        public MongoTab( MongoSession session ) : base( session.ToString() )
        {
            Session = session;
            ImageIndex = (int) Session.CurrentState;
            Controls.Add( new SessionPanel( this ) );
        }
    }
}
