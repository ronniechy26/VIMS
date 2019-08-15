using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vms_v1.FORMS
{
    public partial class frm_rptviewer : Form
    {
        public frm_rptviewer()
        {
            InitializeComponent();
        }

        private void frm_rptviewer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
