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
    public partial class frm_pop_up_vol_org : Form
    {
        private string org = "";

        public string Org
        {
            get { return org; }
            set { org = value; }
        }

        public frm_pop_up_vol_org()
        {
            InitializeComponent();
            dgv_vol.DataSource = DBAccess.dataTableLoad("sp_load_vol_org_pop_up");
        }

        private void bunifuCustomLabel17_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgv_vol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_vol.CurrentRow.Index;
            string vol_org = dgv_vol.Rows[i].Cells[1].Value.ToString();
            Org = vol_org;
            this.Close();


        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != String.Empty)
            {
                dgv_vol.DataSource = DBAccess.search("SELECT vol_org_id as 'ID', vol_org_dsc AS 'VSO' " +
                "FROM `t_vol_org` " +
                "where vol_org_id LIKE '" + txtSearch.Text + "%' or " +
                "vol_org_dsc LIKE '%" + txtSearch.Text + "_%'  ORDER BY vol_org_id ", "t_vol_org");
            }
            else
            {
                dgv_vol.DataSource = DBAccess.dataTableLoad("`sp_load_vol_org_pop_up`");
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

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != String.Empty)
            {
                dgv_vol.DataSource = DBAccess.search("SELECT vol_org_id as 'ID', vol_org_dsc AS 'VSO' " +
                "FROM `t_vol_org` " +
                "where vol_org_id LIKE '" + txtSearch.Text + "%' or " +
                "vol_org_dsc LIKE '%" + txtSearch.Text + "_%'  ORDER BY vol_org_id ", "t_vol_org");
            }
            else
            {
                dgv_vol.DataSource = DBAccess.dataTableLoad("`sp_load_vol_org_pop_up`");
            }
        }
    }
}
