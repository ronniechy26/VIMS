using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using vms_v1.FORMS;
using System.Threading;

namespace vms_v1.USERCONTROLS
{
    public partial class HstOrgnztnInfo : UserControl
    {
        auditTrail logs = null;

        int i = 0;
        int id = 0;

        hostOrg hst_org = null;
        public HstOrgnztnInfo()
        {
            InitializeComponent();
            dgv_hstorg.DataSource = DBAccess.dataTableLoad("`sp_load_host_org`",1);
        }
        private void HstOrgnztnInfo_Load(object sender, EventArgs e)
        {
        }

        private void dgv_hstorg_DoubleClick(object sender, EventArgs e)
        {
            int i = dgv_hstorg.CurrentRow.Index;
            string id = dgv_hstorg.Rows[i].Cells["ID"].Value.ToString();
            frm_HstOrgnztnInfo h = new frm_HstOrgnztnInfo();
            h.txtclear();
            hst_org =  DBAccess.get_host_org(int.Parse(id));

            if (hst_org != null)
            {
                try
                {
                    h.txtid.Text = hst_org.Host_id.ToString();
                    h.txtName.Text = hst_org.Host_org_name;
                    h.txtHeadName.Text = hst_org.Head_name;
                    h.txtPosition.Text = hst_org.Title;
                    h.txtAddressNo.Text = hst_org.Address1;
                    h.txtAddressStreet.Text = hst_org.Address2;
                    h.txtAddressCity.Text = hst_org.City;
                    h.txtTelNumber1.Text = hst_org.Tel_number1;
                    h.txtTelNumber2.Text = hst_org.Tel_number2;
                    h.txtFaxNumber.Text = hst_org.Fax_number;
                    h.txtEmail.Text = hst_org.Email;
                    h.txtWebsite.Text = hst_org.Website;
                    h.rtbMandate.Text = hst_org.Mandate;
                    h.cmbProvince.Text = hst_org.Province;
                    h.cmbOrgtypeSub.Text = hst_org.Host_org_type_sub;
                    h.cmbOrgtype.Text = hst_org.Host_org_type;
                    h.cmbRegion.Text = hst_org.Region;
                    h.h_sub = hst_org.Host_org_type_sub;

                    h.txtOrgtypeSub.Text = hst_org.Host_org_type_sub;
                    h.txtOrgtype.Text = hst_org.Host_org_type;
                    h.txtReg.Text= hst_org.Region;
                    h.txtProv.Text = hst_org.Province;

                    h.prov = hst_org.Province;
                    h.btnSave.Visible = false;
                    h.txtid.Enabled = false;
                    h.ShowDialog();

                   
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message, "Incomplete Data!", MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("Please click refresh!");
            }
                
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            dgv_hstorg.DataSource = DBAccess.dataTableLoad("`sp_load_host_org`",1);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            frm_HstOrgnztnInfo h2 = new frm_HstOrgnztnInfo();
            h2.txtid.Text = "(Auto Generated)";
            h2.txtid.Enabled = false;
            h2.txtName.Focus();
            h2.btnReq.Visible = false;
            h2.btnUpdate.Visible = false;
            h2.btnHistory.Visible = false;
            h2.btnProj.Visible = false;
            h2.ActiveControl = h2.txtName;
            h2.txtName.Focus();
            h2.ShowDialog();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
           

            if (dgv_hstorg.RowCount == 0)
            {
                MessageBox.Show("Nothing to delete!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!DBAccess.findAcct("SELECT * FROM `t_host_org` WHERE isActive = 1 and host_org_id = '" + id + "'  "))
                {
                    MessageBox.Show("ID not found!\nPlease check the record's ID!",
                        "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this record ID "
                     + id, "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_recycle_hostOrg_1", Convert.ToInt32(id));
                        dgv_hstorg.DataSource = DBAccess.dataTableLoad("`sp_load_host_org`",1);
                        MessageBox.Show("Successfully deleted!", "Successful!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        logs = new auditTrail(frm_login.UserName, "Deleted LPI id " + id);
                        DBAccess.insert_logs(logs);

                    }
                }
            }
        }

        private void dgv_hstorg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = dgv_hstorg.CurrentRow.Index;
            id = int.Parse(dgv_hstorg.Rows[i].Cells["ID"].Value.ToString());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                dgv_hstorg.DataSource = DBAccess.search("SELECT host_org_id AS 'ID', host_org AS 'Organization Name',head_name AS 'Head Coordinator', " +
                    "CONCAT(address1,' ',address2,' ',mun_city) AS 'Address' from t_host_org WHERE isActive = 1 having " +
                    "host_org_id LIKE '%" + txtSearch.Text.Trim() + "%' or " +
                    "host_org  LIKE '%" + txtSearch.Text.Trim() + "%' or " +
                    "head_name LIKE '%" + txtSearch.Text.Trim() + "%' or " +
                    "Address LIKE  '%" + txtSearch.Text.Trim() + "%'  ");
            }
            else
            {
                dgv_hstorg.DataSource = DBAccess.dataTableLoad("`sp_load_host_org`", 1);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender,e);
            }
        }

        private void bunifuMetroTextbox1_OnValueChanged_1(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                dgv_hstorg.DataSource = DBAccess.dataTableLoad("`sp_load_host_org`", 1);
            }
        }

 




    }//close
}
