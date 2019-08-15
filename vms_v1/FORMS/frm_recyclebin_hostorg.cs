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
    public partial class frm_recyclebin_hostorg : Form
    {
        int id = 0;
        int i = 0;

        auditTrail logs = null;


        public frm_recyclebin_hostorg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_recyclebin_hostorg_Load(object sender, EventArgs e)
        {
            dgv_bin_hstOrg.DataSource = DBAccess.dataTableLoad("`sp_load_host_org`", 0);
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dgv_bin_hstOrg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = dgv_bin_hstOrg.CurrentRow.Index;
            id = int.Parse(dgv_bin_hstOrg.Rows[i].Cells["ID"].Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgv_bin_hstOrg.RowCount == 0)
            {
                MessageBox.Show("Nothing to delete!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!DBAccess.findAcct("SELECT * FROM `t_host_org` WHERE isActive = 0 and host_org_id = '" + id + "'  "))
                {
                    MessageBox.Show("Nothing to delete! Please select in the table!",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this record ID "
                     + id, "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_delete_host_org", Convert.ToInt32(id));
                        dgv_bin_hstOrg.DataSource = DBAccess.dataTableLoad("`sp_load_host_org`", 0);

                        logs = new auditTrail(frm_login.UserName, "Deleted permanently LPI ID  " + id);
                        DBAccess.insert_logs(logs);

                        MessageBox.Show("Successfully deleted!", "Successful!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void btnRestre_Click(object sender, EventArgs e)
        {
            if (dgv_bin_hstOrg.RowCount == 0)
            {
                MessageBox.Show("Nothing to restore! Please select in the table !", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!DBAccess.findAcct("SELECT * FROM `t_host_org` WHERE isActive = 0 and host_org_id = '" + id + "'  "))
                {
                    MessageBox.Show("Nothing to restore! Please select in the table !!",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to restore this record ID "
                     + id, "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_recycle_hostOrg_0", Convert.ToInt32(id));
                        dgv_bin_hstOrg.DataSource = DBAccess.dataTableLoad("`sp_load_host_org`", 0);

                        logs = new auditTrail(frm_login.UserName, "Restored LPI ID " + id);
                        DBAccess.insert_logs(logs);

                        MessageBox.Show("Successfully restored!", "Successful!",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
            }
        }

        private void txtSearch_OnValueChanged_1(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                dgv_bin_hstOrg.DataSource = DBAccess.search("SELECT host_org_id AS 'ID', host_org AS 'Organization Name',head_name AS 'Head Coordinator', " +
                    "CONCAT(address1,' ',address2,' ',mun_city) AS 'Address' from t_host_org WHERE isActive = 0 having " +
                    "host_org_id LIKE '%" + txtSearch.Text + "%' or " +
                    "host_org  LIKE '%" + txtSearch.Text + "%' or " +
                    "head_name LIKE '%" + txtSearch.Text + "_%' or " +
                    "Address LIKE  '%" + txtSearch.Text + "%'  ", "t_host_org");
            }
            else
            {
                dgv_bin_hstOrg.DataSource = DBAccess.dataTableLoad("`sp_load_host_org`", 0);
            }
        }

     
    
    
    
    
    
    
    }/////
}
