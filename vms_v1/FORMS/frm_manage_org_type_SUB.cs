using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using Bunifu.Framework.UI;


namespace vms_v1.FORMS
{
    public partial class frm_manage_org_type_SUB : Form
    {
        auditTrail logs = null;

        institutionTypeSUB iSub = null;
        string temp_name = "";

        public frm_manage_org_type_SUB()
        {
            InitializeComponent();
            cmbOrgtype.DataSource = DBAccess.populatecmb("`sp_populate_cmb_host`", "host_org_type");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_manage_org_type_SUB_Load(object sender, EventArgs e)
        {
            dgv_orgTypeSUB.DataSource = DBAccess.dataTableLoad("sp_load_institution_type_Sub");
           // dgv_orgTypeSUB.Columns[0].Visible = false;
        }

        private void cmbOrgtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOrgtype.Text = cmbOrgtype.Text;
        }

        private void dgv_orgTypeSUB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_orgTypeSUB.CurrentRow.Index;
            int id = int.Parse(dgv_orgTypeSUB.Rows[i].Cells["ID"].Value.ToString());

            iSub = DBAccess.get_institutionTypeSUB(id);

            if (iSub != null)
            {
                try
                {
                    txtID.Text = iSub.Id.ToString();
                    txtTitle.Text = iSub.SubType;
                    txtOrgtype.Text = iSub.MainType;
                    cmbOrgtype.Text = iSub.MainType;
                    if (iSub.IsNGO == 1)
                    {
                        chbisNGO.Checked = true;
                    }
                    else { chbisNGO.Checked = false; }

                    txtTitle.Enabled = true;
                    lblerror1.Visible = false;
                    temp_name = txtTitle.Text.Trim();

                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message, "Incomplete Data!", MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Null");
            }
        }

        public void clear()
        {
            txtTitle.Enabled = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            dgv_orgTypeSUB.Enabled = true;
            chbisNGO.Checked = false;
            dgv_orgTypeSUB.Enabled = true;
            txtOrgtype.Clear();
            txtTitle.Text = "";
            // txtUsername.Enabled = false;
            txtID.Text = "(Auto Generated)";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTitle.Enabled = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            dgv_orgTypeSUB.Enabled = true;
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clear();
            txtTitle.Enabled = true;
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            dgv_orgTypeSUB.Enabled = false;
            this.ActiveControl = txtTitle;
            txtTitle.Focus();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == string.Empty || txtID.Text == "(Auto Generated)")
                {
                    MessageBox.Show("Please select user to update!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else if (txtTitle.Text == string.Empty)
                {
                    MessageBox.Show("Please input Institution Main type!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else

                {
                    int host_main = DBAccess.get_cmb_data(txtOrgtype.Text,
                        "sp_get_cmb_institution_Main",
                        "host_org_type_id");

                    iSub = new institutionTypeSUB(int.Parse(txtID.Text), host_main.ToString(),txtTitle.Text, chbisNGO.Checked ? 1:0);
                    DBAccess.update_institution_Sub(iSub);
                   
                    dgv_orgTypeSUB.DataSource = DBAccess.dataTableLoad("sp_load_institution_type_Sub");

                    logs = new auditTrail(frm_login.UserName, "Updated Organization sub type id " + txtID.Text);
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Updated!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);

                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }


          //  clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblerror1.Visible == true)
                {
                    MessageBox.Show("Institution sub type is already in use!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else if (txtTitle.Text == string.Empty)
                {
                    MessageBox.Show("Please complete the required data!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else
                {
                    int host_main = DBAccess.get_cmb_data(txtOrgtype.Text,
                       "sp_get_cmb_institution_Main",
                       "host_org_type_id");

                    iSub = new institutionTypeSUB(host_main.ToString(), txtTitle.Text, chbisNGO.Checked ? 1 : 0);

                    DBAccess.insert_institution_Sub(iSub);

                    logs = new auditTrail(frm_login.UserName, "Added a Organization sub type");
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    dgv_orgTypeSUB.DataSource = DBAccess.dataTableLoad("sp_load_institution_type_Sub");
                    btnUpdate.Visible = true;
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                    dgv_orgTypeSUB.Enabled = true;

                    clear();

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void txtTitle_OnValueChanged(object sender, EventArgs e)
        {
            if (temp_name == txtTitle.Text.Trim())
            {
                lblerror1.Visible = false;
            }
            else if (DBAccess.find("sp_check_institution_sub", txtTitle.Text))
            {
                lblerror1.Visible = true;
            }
            else
            {
                lblerror1.Visible = false;
            }

            BunifuMetroTextbox txt = (BunifuMetroTextbox)sender;
            Functions.noSpace(txt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }









    }
}
