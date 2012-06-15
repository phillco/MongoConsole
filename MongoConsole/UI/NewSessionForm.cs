using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MongoConsole.UI
{
    /// <summary>
    /// Asks the user for the address of the server to connect to.
    /// </summary>
    public partial class NewSessionForm : Form
    {
        public NewSessionForm( )
        {
            InitializeComponent( );
        }

        /// <summary>
        /// Shows the form modally and returns the address selected, or null if cancelled.
        /// </summary>
        public static string ShowAndGetAddress( IWin32Window parent )
        {
            var form = new NewSessionForm( );

            if ( form.ShowDialog( parent ) == DialogResult.OK )
                return form.tbServerAddress.Text;
            else
                return null;
        }

        private void btnConnect_Click( object sender, EventArgs e )
        {
            DialogResult = DialogResult.OK;
            Close( );
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close( );
        }
    }
}
