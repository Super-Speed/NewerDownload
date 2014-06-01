using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewerDownload
{
    public partial class NSMBWii_Init : Form
    {
        public NSMBWii_Init()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NSMBWii_Installer_Blarg install = new NSMBWii_Installer_Blarg();
            install.ShowDialog();

            NSMBWii_Init init = new NSMBWii_Init();
            init.Close();
        }
    }
}
