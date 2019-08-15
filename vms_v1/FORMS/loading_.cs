using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace vms_v1.FORMS
{
    public partial class loading_ : Form
    {
        int i;
        frm_dashboard db = new frm_dashboard();

        public loading_()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void loading__Shown(object sender, EventArgs e)
        {
            for (i = 0; i < 100; i++)
            {
                Thread.Sleep(3);
                progressBar1.Value = i;
            }
            if (i == 100)
            {
                this.Hide();
            }
        }

        private void loading__Load(object sender, EventArgs e)
        {

        }
    }
}
