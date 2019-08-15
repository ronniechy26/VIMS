using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using MySql.Data.MySqlClient;


namespace vms_v1.FORMS
{
    public partial class frm_auditTrail : Form
    {
        public frm_auditTrail()
        {
            InitializeComponent();
        }

        private void frm_auditTrail_Load(object sender, EventArgs e)
        {
            dgv_logs.DataSource = DBAccess.dataTableLoad("sp_load_logs");
            dgv_logs.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            txtTo.Text = dtTo.Value.ToString();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            txtFrom.Text = dtFrom.Value.ToString();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {

            if (txtFrom.Text == "" || txtTo.Text == "")
            {
                MessageBox.Show("Please input dates");
            }
            else if(dtFrom.Value > dtTo.Value)
            {
                MessageBox.Show("Incorrect dates");
            }
            else { dgv_logs.DataSource = DBAccess.logs(Convert.ToDateTime(txtFrom.Text), Convert.ToDateTime(txtTo.Text)); }
          
        

        }
        private void btnRealtime_Click(object sender, EventArgs e)
        {
            btnRealtime.Visible = false;
            btnStop.Visible = true;
            btnSort.Enabled = false;
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dgv_logs.DataSource = DBAccess.dataTableLoad("sp_load_logs");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnRealtime.Visible = true;
            btnStop.Visible = false;
            btnSort.Enabled = true;
            timer1.Stop();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            if (this.WindowState == FormWindowState.Minimized)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    frm.WindowState = FormWindowState.Minimized;
                }
            }
        }

    }
}
