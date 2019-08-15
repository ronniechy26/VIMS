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
    public partial class frm_recyclebin_request : Form
    {

       auditTrail logs = null;

        int i = 0;
        string id = "";

        public frm_recyclebin_request()
        {
            InitializeComponent();
        }

        private void frm_recyclebin_request_Load(object sender, EventArgs e)
        {
            dgv_rfv.DataSource = DBAccess.dataTableLoad("sp_load_request", 0);
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

            if (dgv_rfv.RowCount == 0)
            {
                MessageBox.Show("Nothing to delete!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!DBAccess.findAcct("SELECT * FROM `t_request` WHERE isActive = 0 and ref_no = '" + id + "'  "))
                {
                    MessageBox.Show("Nothing to restore! Please select in the table !",
                        "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to restore this record ID ("
                     + id + ")", "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_recycle_request_0", id);
                        dgv_rfv.DataSource = DBAccess.dataTableLoad("`sp_load_request`", 0);

                        logs = new auditTrail(frm_login.UserName, "Restore Request ID  " + id);
                        DBAccess.insert_logs(logs);

                        MessageBox.Show("Successfully restored!", "Successful!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void dgv_rfv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = dgv_rfv.CurrentRow.Index;
            id = dgv_rfv.Rows[i].Cells["Reference_No"].Value.ToString();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            if (dgv_rfv.RowCount == 0)
            {
                MessageBox.Show("Nothing to delete!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!DBAccess.findAcct("SELECT * FROM `t_request` WHERE isActive = 0 and ref_no = '" + id + "'  "))
                {
                    MessageBox.Show("Nothing to delete! Please select in the table !",
                        "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this record ID ("
                     + id + ")", "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_delete_request", id);
                        dgv_rfv.DataSource = DBAccess.dataTableLoad("`sp_load_request`",0);

                        logs = new auditTrail(frm_login.UserName, "Deleted Request permanently ID  " + id);
                        DBAccess.insert_logs(logs);

                        MessageBox.Show("Successfully deleted!", "Successful!",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != String.Empty)
            {
                dgv_rfv.DataSource = DBAccess.search("SELECT req.ref_no AS 'Reference_No', " +
                    "org.host_org AS 'Host_Organization'," +
                    "proj.proj_title AS 'Project_Title'," +
                    "vso.vol_org_dsc AS 'Volunteer_Organization'," +
                    "req.`assessed_by`, " +
                    "req_stat.request_status AS 'Request_Status'  " +
                    "FROM " +
                    "`t_request` AS req  " +
                    "JOIN `t_host_org` AS org " +
                    "ON req.`host_org_id` = org.host_org_id " +
                    "JOIN `t_project` AS proj " +
                    "ON req.`project_id` = proj.project_id " +
                    "JOIN `t_vol_org` AS vso " +
                    "ON req.`vol_org_id` = vso.vol_org_id " +
                    "JOIN `t_request_status` AS req_stat " +
                    "ON req.`request_status_id` = req_stat.request_status_ID " +
                    "where req.isActive = 0 HAVING req.ref_no LIKE '" + txtSearch.Text + "%' or " +
                    "org.host_org LIKE '%" + txtSearch.Text + "_%' or " +
                    "proj.proj_title LIKE '%" + txtSearch.Text + "_%' or " +
                    "vso.vol_org_dsc LIKE '%" + txtSearch.Text + "%' ORDER BY date_received DESC");
            }
            else
            {
                dgv_rfv.DataSource = DBAccess.dataTableLoad("sp_load_request", 0);
            }

            //if (string.IsNullOrEmpty(txtSearch.Text))
            //{
            //    (dgv_rfv.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            //}
            //else
            //{
            //    (dgv_rfv.DataSource as DataTable).DefaultView.RowFilter =
            //        string.Format("Reference_No LIKE'{0}%' or Host_Organization LIKE'{0}%' or Volunteer_Organization LIKE'{0}%' or Project_Title LIKE'{0}%' or Request_Status LIKE'{0}%'  ",
            //        txtSearch.Text);

            //}
        }







    }//
}
