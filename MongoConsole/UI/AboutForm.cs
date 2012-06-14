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
    public partial class AboutForm : Form
    {
        public AboutForm( )
        {
            InitializeComponent( );
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            Close( );
        }
    }
}
