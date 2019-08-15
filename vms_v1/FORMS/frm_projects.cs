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
    public partial class frm_projects : Form
    {
        auditTrail logs = null;

        hostProjects hostProj = null;
        public int id = 0;
       
        int i2 = 0;//para sa cell index ng dgv
        int id2 = 0;//

        public frm_projects()
        {
            InitializeComponent();
            cmbRegion.DataSource = DBAccess.populatecmb("`sp_populate_cmb_region`", "region_desc");
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frm_projects_Load(object sender, EventArgs e)
        {
            enabled(false);
            txtID.Text = "(Auto generated)";
            btnCancel.Visible = false;
            btnSave.Enabled = false;
            dgv_proj.DataSource = DBAccess.dtProject("sp_load_project",id);
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enabled(true);
            dgv_proj.Enabled = false;
            clear();
            btnAdd.Visible = false;
            txtID.Text = "(Auto generated)";
            txtID.Enabled = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDel.Enabled = false;
            btnCancel.Visible = true;
            this.ActiveControl = txtTitle;
            txtTitle.Focus();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            dgv_proj.DataSource = DBAccess.dtProject("sp_load_project", id);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgv_proj_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
            enabled(true);

            int i = dgv_proj.CurrentRow.Index;
            string id = dgv_proj.Rows[i].Cells["Project ID"].Value.ToString();
                  
           hostProj = DBAccess.get_host_project(int.Parse(id));

           if (hostProj != null)
            {
                try
                {
                    txtID.Text = hostProj.Project_id.ToString();
                    txtTitle.Text = hostProj.Proj_title;
                    txtMgr.Text = hostProj.Proj_mgr;
                    txtDuration.Text = hostProj.Proj_duration;
                    txtAddressNo.Text = hostProj.Proj_address_no;
                    txtAddressStreet.Text = hostProj.Proj_address_street;
                    txtAddressCity.Text = hostProj.Mun_city;
                    txtBudget.Text = hostProj.Bugdet;
                    txtSourceFund.Text = hostProj.Source_fund;
                    txtTargetBeneficiaries.Text = hostProj.Target_benificiaries;
                    txtStart.Text = hostProj.Date_start;
                   
                    cmbProvince.Text = hostProj.Prov_id;
                    cmbRegion.Text = hostProj.Region_id;
                    txtprv.Text = hostProj.Prov_id;
                    txtReg.Text = hostProj.Region_id;
                    rtbObjective.Text = hostProj.Objective;
                    txtPosition.Text = hostProj.Coordinator_position;
                    txtContactNo.Text = hostProj.ContactNo;

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
        public void enabled(bool foo) 
        {
            if (!foo)
            {
                txtTargetBeneficiaries.Enabled = false;
                txtID.Enabled = false;
                txtTitle.Enabled = false;
                txtMgr.Enabled = false;
                txtDuration.Enabled = false;
                txtAddressNo.Enabled = false;
                txtAddressStreet.Enabled = false;
                txtAddressCity.Enabled = false;
                txtBudget.Enabled = false;
                txtSourceFund.Enabled = false;
                txtStart.Enabled = false;
                txtPosition.Enabled = false;
                txtContactNo.Enabled = false;
                cmbProvince.Enabled = false;
                cmbRegion.Enabled = false;
                rtbObjective.Enabled = false;
            } 
            else
            {
                txtTargetBeneficiaries.Enabled = true;
               // txtID.Enabled = true;
                txtTitle.Enabled = true;
                txtMgr.Enabled = true;
                txtDuration.Enabled = true;
                txtAddressNo.Enabled = true;
                txtAddressStreet.Enabled = true;
                txtAddressCity.Enabled = true;
                txtBudget.Enabled = true;
                txtSourceFund.Enabled = true;
                txtStart.Enabled = true;
                cmbProvince.Enabled = true;
                cmbRegion.Enabled = true;
                rtbObjective.Enabled = true;
                txtPosition.Enabled = true;
                txtContactNo.Enabled = true;


            }

        }
        public void clear()
        {
            DateTime dt = DateTime.Now;
            txtTargetBeneficiaries.Text = "";
            txtID.Text = "";
            txtTitle.Text = "";
            txtMgr.Text = "";
            txtDuration.Text = "";
            txtAddressNo.Text = "";
            txtAddressStreet.Text = "";
            txtAddressCity.Text = "";
            txtBudget.Text = "";
            txtSourceFund.Text = "";
            txtStart.Text = "" ;
            
            cmbProvince.Text = "";
            cmbRegion.Text = "";
            rtbObjective.Text = "";
            txtprv.Text = "";
            txtReg.Text = "";
            txtContactNo.Text = "";
            txtPosition.Text = "";
        }
        public bool check()
        {
            if (Functions.checkSpace(txtTitle.Text,txtReg.Text,txtprv.Text))
            {
                return true;
            }
            else
            { return false; }

        }
        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            cmbProvince.DataSource = DBAccess.populatecmb(cmbRegion.Text, "sp_populate_cmb_province", "prov_dsc");
            txtReg.Text = cmbRegion.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty || txtID.Text == "(Auto generated)") 
            {
                MessageBox.Show("Please Select Project ID !", "Error!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else if (check()) 
            {
                MessageBox.Show("Please complete the fields(if not applicable please indicate n/a)",
                    "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int prov = DBAccess.get_cmb_data(txtprv.Text,
                        "sp_get_cmb_province",
                        "prov_id");
                    int reg = DBAccess.get_cmb_data(txtReg.Text,
                        "sp_get_cmb_region",
                        "region_id");
                    hostProj = new hostProjects(
                            int.Parse(txtID.Text),
                            txtTitle.Text.Trim(),
                            txtMgr.Text.Trim(),
                            txtDuration.Text.Trim(),
                            txtAddressNo.Text.Trim(),
                            txtAddressStreet.Text.Trim(),
                            txtAddressCity.Text.Trim(),
                            prov.ToString(),
                            reg.ToString(),
                            txtBudget.Text.Trim(),
                            txtSourceFund.Text.Trim(),
                            rtbObjective.Text.Trim(),
                            txtStart.Text.Trim(),
                            txtTargetBeneficiaries.Text.Trim(),
                            txtPosition.Text, txtContactNo.Text
                            );

                    DBAccess.update_host_proj(hostProj);

                    logs = new auditTrail(frm_login.UserName, "Updated Project id " + txtID.Text);
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully updated!", "", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);

                    clear();
                    txtID.Text = "(Auto generated)";
                    dgv_proj.DataSource = DBAccess.dtProject("sp_load_project", id);
                    enabled(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }
            }
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            
            if (id2 == 0 || dgv_proj.RowCount == 0)
            {
                MessageBox.Show("Please select Project ID!",
                     "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (DBAccess.find("sp_check_project", id2))
            {
                MessageBox.Show("Project is Active! currently being use!",
                     "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!DBAccess.findAcct("SELECT * FROM t_project WHERE project_id = '" + id2 + "'  "))
                {
                    MessageBox.Show("Please select Project ID!",
                        "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this Project ID "
                     + id2, "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_delete_host_proj", id2);
                        dgv_proj.DataSource = DBAccess.dtProject("sp_load_project", id);

                        logs = new auditTrail(frm_login.UserName, "Deleted Project ID " + id2);
                        DBAccess.insert_logs(logs);

                        clear();
                        txtID.Text = "(Auto generated)";
                        enabled(false);
                        MessageBox.Show("Successfully deleted!", "Successful!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            if(check())
            {
                MessageBox.Show("Please complete the fields(if not applicable please indicate n/a)",
                     "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int prov = DBAccess.get_cmb_data(cmbProvince.Text,
                        "sp_get_cmb_province",
                        "prov_id");
                    int reg = DBAccess.get_cmb_data(cmbRegion.Text,
                        "sp_get_cmb_region",
                        "region_id");
                    hostProj = new hostProjects(
                            id.ToString(),
                            txtTitle.Text.Trim(),
                            txtMgr.Text.Trim(),
                            txtDuration.Text.Trim(),
                            txtAddressNo.Text.Trim(),
                            txtAddressStreet.Text.Trim(),
                            txtAddressCity.Text.Trim(),
                            prov.ToString(),
                            reg.ToString(),
                            txtBudget.Text.Trim(),
                            txtSourceFund.Text.Trim(),
                            rtbObjective.Text.Trim(),
                            txtStart.Text.Trim(),
                            txtTargetBeneficiaries.Text.Trim(),
                            txtPosition.Text,txtContactNo.Text
                            );
                    DBAccess.insert_host_proj(hostProj);
                    
                    dgv_proj.DataSource = DBAccess.dtProject("sp_load_project", id);

                    logs = new auditTrail(frm_login.UserName, "Added a Project for LPI ID " + id);
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    clear();
                    dgv_proj.Enabled = true;
                    btnDel.Enabled = true;
                    btnUpdate.Enabled = true;
                    txtID.Text = "(Auto generated)";
                    enabled(false);
                    btnAdd.Visible = true;
                    btnCancel.Visible = false;
                    btnSave.Enabled = false;

                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }

            }//if
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            enabled(false);
            dgv_proj.Enabled = true;
            clear();
            txtID.Text = "(Auto generated)";
            btnSave.Enabled = false;
            btnAdd.Visible = true;
            btnDel.Enabled = true;
            btnUpdate.Enabled = true;
            btnCancel.Visible = false;
        }

        private void txtTitle_OnValueChanged(object sender, EventArgs e)
        {
            BunifuMetroTextbox txt = (BunifuMetroTextbox)sender;
            Functions.noSpace(txt);
        }

        private void rtbObjective_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace((string)rtbObjective.Text))
                rtbObjective.Text = string.Empty;
        }

        private void cmbRegion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace((string)cmbRegion.Text))
                cmbRegion.Text = string.Empty;
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtprv.Text = cmbProvince.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dgv_proj_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i2 = dgv_proj.CurrentRow.Index;
            id2 = int.Parse(dgv_proj.Rows[i2].Cells["Project ID"].Value.ToString());
        }

        private void txtTitle_Leave(object sender, EventArgs e)
        {
            BunifuMetroTextbox txt = (BunifuMetroTextbox)sender;
            txt.Text = Functions.toTitleCase(txt);
        }

        private void txtSearch_OnValueChanged_1(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                dgv_proj.DataSource = DBAccess.search("SELECT project_id AS 'Project ID', proj_title AS 'Title',proj_duration AS 'Duration' , " +
                    "bugdet AS 'Budget' FROM `t_project` WHERE host_org_id = " + id + " HAVING " +
                    "project_id LIKE '%" + txtSearch.Text + "%' or " +
                    "proj_title  LIKE '%" + txtSearch.Text + "%' or " +
                    "proj_duration LIKE '%" + txtSearch.Text + "%' or " +
                    "bugdet LIKE  '%" + txtSearch.Text + "%'  ", "t_project");
            }
            else
            {
                dgv_proj.DataSource = DBAccess.dtProject("sp_load_project", id);
            }
        }


       

 

      

    }
}
