﻿using System;
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
    /// Shows information about the application...surprise surprise!
    /// </summary>
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
