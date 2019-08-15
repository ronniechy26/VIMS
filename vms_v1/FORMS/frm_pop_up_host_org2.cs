using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;



namespace vms_v1.FORMS
{
    public partial class frm_pop_up_host_org2 : Form
    {
        frm_request frm_req = new frm_request();
        private string org = "";

        public string Org
        {
            get { return org; }
            set { org = value; }
        }
        public frm_pop_up_host_org2()
        {
            InitializeComponent();
            dgv_hstorg.DataSource = DBAccess.dataTableLoad("sp_load_host_org_pop_up");
        }

        private void dgv_hstorg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_hstorg.CurrentRow.Index;
            string vol_org = dgv_hstorg.Rows[i].Cells[1].Value.ToString();
            Org = vol_org;
            this.Close();
        }

       private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                dgv_hstorg.DataSource = DBAccess.search("SELECT host_org_id AS 'ID',host_org AS 'LPI' from `t_host_org` " +
                    " WHERE host_org_id LIKE  '%" + txtSearch.Text + "%' or " +
                    " host_org LIKE  '%" + txtSearch.Text + "_%' ORDER BY host_org_id", "t_host_org");
            }
            else
            {
                dgv_hstorg.DataSource = DBAccess.dataTableLoad("`sp_load_host_org_pop_up`");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
