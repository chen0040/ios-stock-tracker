using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinI2Spider.WinForm
{
    public partial class frmI2Spider : Form
    {
        public frmI2Spider()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonMonitor_Click(object sender, EventArgs e)
        {
            frmMonitor frm = new frmMonitor();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
