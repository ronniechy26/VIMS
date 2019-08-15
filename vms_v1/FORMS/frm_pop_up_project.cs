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
    public partial class frm_pop_up_project : Form
    {
        private string org = "";

        public string Org
        {
            get { return org; }
            set { org = value; }
        }

        public frm_pop_up_project()
        {
            InitializeComponent();
            dgv_proj.DataSource = DBAccess.dataTableLoad("sp_load_proj_pop_up", frm_request.Host_id);
        }

        private void dgv_proj_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_proj.CurrentRow.Index;
            string vol_org = dgv_proj.Rows[i].Cells[1].Value.ToString();
            Org = vol_org;
           //frm_request f = new frm_request();
           // f.txtHostOrg.Text = Org;
            this.Close();
        }

        private void bunifuCustomLabel17_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frm_pop_up_project_Load(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != String.Empty)
            {
                dgv_proj.DataSource = DBAccess.search("SELECT project_id AS 'ID', proj_title AS 'Project Description/Name' " +
                "FROM `t_project` " +
                "where host_org_id = " + frm_request.Host_id + " HAVING project_id LIKE '" + txtSearch.Text + "%' or " +
                "proj_title LIKE '%" + txtSearch.Text + "_%'  ", "t_project");
            }
            else
            {
                dgv_proj.DataSource = DBAccess.dataTableLoad("`sp_load_proj_pop_up`", frm_request.Host_id);
            }
        }
    }
}
