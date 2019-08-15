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
    public partial class frm_recyclebin_req_sub : Form
    {

        int i = 0;
        int id = 0;

        auditTrail logs = null;

        public frm_recyclebin_req_sub()
        {
            InitializeComponent();
        }

        private void frm_recyclebin_req_sub_Load(object sender, EventArgs e)
        {
            dgv_req_sub.DataSource = DBAccess.dataTableLoad("sp_load_req_sub_volunteerinfo_recyclebin", 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_req_sub_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = dgv_req_sub.CurrentRow.Index;
            id = int.Parse(dgv_req_sub.Rows[i].Cells["Sub ID"].Value.ToString());
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            if (dgv_req_sub.RowCount == 0)
            {
                MessageBox.Show("Nothing to delete!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!DBAccess.findAcct("SELECT * FROM `t_request_sub` WHERE isActive = 0 and request_sub_id = '" + id + "'  "))
                {
                    MessageBox.Show("Nothing to delete! Please select in the table !",
                        "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this record ID "
                     + id, "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_delete_request_sub_vol_info", Convert.ToInt32(id));
                        dgv_req_sub.DataSource = DBAccess.dataTableLoad("sp_load_req_sub_volunteerinfo_recyclebin", 0);
                    
                        logs = new auditTrail(frm_login.UserName, "Deleted Request sub permanently ID  " + id);
                        DBAccess.insert_logs(logs);

                        MessageBox.Show("Successfully deleted!", "Successful!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (dgv_req_sub.RowCount == 0)
            {
                MessageBox.Show("Nothing to restore!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!DBAccess.findAcct("SELECT * FROM `t_request_sub` WHERE isActive = 0 and request_sub_id = '" + id + "'  "))
                {
                    MessageBox.Show("Nothing to restore! Please select in the table !",
                        "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to restore this record ID "
                     + id, "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_recycle_req_sub_0", Convert.ToInt32(id));
                        dgv_req_sub.DataSource = DBAccess.dataTableLoad("sp_load_req_sub_volunteerinfo_recyclebin", 0);

                        logs = new auditTrail(frm_login.UserName, "Restored Request sub ID  " + id);
                        DBAccess.insert_logs(logs);

                        MessageBox.Show("Successfully restored!", "Successful!",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

      }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {

        }










        //
    }
}
