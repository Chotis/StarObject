using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StarObject
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCreateObj_Click(object sender, EventArgs e)
        {
            MakeObject obj = new MakeObject();
            obj.Show();
           
        }

        private void btnCreateFrame_Click(object sender, EventArgs e)
        {
            MakeFrame frm = new MakeFrame();
            frm.Show();
             
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            abtBox about = new abtBox();
            about.Show();
        }
    }
}
