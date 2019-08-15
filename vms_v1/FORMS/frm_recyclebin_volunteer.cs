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
    public partial class frm_recyclebin_volunteer : Form
    {
        auditTrail logs = null;

        int i2 = 0;
        string id2 = "";

        public frm_recyclebin_volunteer()
        {
            InitializeComponent();
        }

        private void frm_recyclebin_volunteer_Load(object sender, EventArgs e)
        {
            dgv_bin_vol.DataSource = DBAccess.dataTableLoad("sp_load_volunteer", 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (dgv_bin_vol.RowCount == 0)
            {
                MessageBox.Show("Nothing to delete!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if(!DBAccess.findAcct("SELECT * FROM `t_volunteer` WHERE isActive = 0 and ref_no = '" + id2 + "'  "))
                {
                    MessageBox.Show("Nothing to delete! Please select in the table !", "", MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this record ID ("
                     + id2 + ")", "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_delete_volunteer_by_ref_no", id2);
                        dgv_bin_vol.DataSource = DBAccess.dataTableLoad("`sp_load_volunteer`", 0);

                        logs = new auditTrail(frm_login.UserName, "Deleted Volunteer permanently ID  " + id2);
                        DBAccess.insert_logs(logs);

                        MessageBox.Show("Successfully deleted!", "Successful!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void dgv_bin_vol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i2 = dgv_bin_vol.CurrentRow.Index;
            id2 = dgv_bin_vol.Rows[i2].Cells["ID"].Value.ToString();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (dgv_bin_vol.RowCount == 0)
            {
                MessageBox.Show("Nothing to restore!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!DBAccess.findAcct("SELECT * FROM `t_volunteer` WHERE isActive = 0 and ref_no = '" + id2 + "'  "))
                {
                    MessageBox.Show("Nothing to restore! Please select in the table !", "", MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to restore this record ID ("
                     + id2 + ")", "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_recycle_volunteer_0", id2);
                        dgv_bin_vol.DataSource = DBAccess.dataTableLoad("`sp_load_volunteer`", 0);
                        
                        logs = new auditTrail(frm_login.UserName, "Restore Volunteer ID  " + id2);
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

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != String.Empty)
            {
                dgv_bin_vol.DataSource = DBAccess.search("SELECT vol.ref_no AS 'ID',vol.vol_name AS 'Volunteer Name',vol.sex AS 'Sex', " +
                "vol_org.vol_org_dsc AS 'Volunteer Organization',CONCAT(vol.add_no, ' ', vol.add_st, ' ', vol.mun_city) AS 'Address' " +
                "FROM `t_volunteer` AS vol JOIN `t_vol_org` AS vol_org ON vol_org.vol_org_id = vol.vol_org " +
                "where vol.isActive = 0 having vol.ref_no LIKE '" + txtSearch.Text + "%' or " +
                "vol.vol_name LIKE '%" + txtSearch.Text + "_%' or " +
                "Address LIKE '%" + txtSearch.Text + "_%' or " +
                "vol_org.vol_org_dsc LIKE '%" + txtSearch.Text + "%'  ", "`t_volunteer");
            }
            else
            {
                dgv_bin_vol.DataSource = DBAccess.dataTableLoad("`sp_load_volunteer`", 0);
            }
        }
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    }//////
}
