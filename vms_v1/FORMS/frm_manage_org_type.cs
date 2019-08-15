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
    public partial class frm_manage_org_type : Form
    {
         auditTrail logs = null;

        institutionTypeMain iMain = null;
        string temp_name = "";
        public frm_manage_org_type()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_manage_org_type_Load(object sender, EventArgs e)
        {
            dgv_orgType.DataSource = DBAccess.dataTableLoad("sp_load_institution_type");
           // dgv_orgType.Columns[0].Visible = false;
        }

        private void dgv_orgType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = dgv_orgType.CurrentRow.Index;
            int id = int.Parse(dgv_orgType.Rows[i].Cells["ID"].Value.ToString());

            iMain = DBAccess.get_institutinMain(id);

            if (iMain != null)
            {
                try
                {
                    txtID.Text = iMain.Id.ToString();
                    txtTitle.Text = iMain.Name;
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
            dgv_orgType.Enabled = true;

            dgv_orgType.Enabled = true;
            txtTitle.Text = "";
            // txtUsername.Enabled = false;
            txtID.Text = "(Auto Generated)";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            clear();
            txtTitle.Enabled = true;
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            dgv_orgType.Enabled = false;
            this.ActiveControl = txtTitle;
            txtTitle.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTitle.Enabled = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            dgv_orgType.Enabled = true;
            clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblerror1.Visible == true)
                {
                    MessageBox.Show("Institution Main type is already in use!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else if (txtTitle.Text == string.Empty)
                {
                    MessageBox.Show("Please complete the required data!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else
                {
                    iMain = new institutionTypeMain(txtTitle.Text);

                    DBAccess.insert_institution_Main(iMain);

                    logs = new auditTrail(frm_login.UserName, "Added a Organization type ");
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    dgv_orgType.DataSource = DBAccess.dataTableLoad("sp_load_institution_type");
                    btnUpdate.Visible = true;
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                    dgv_orgType.Enabled = true;

                    clear();

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }

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
                    MessageBox.Show("Please input Insitution type!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else
                {
                    iMain = new institutionTypeMain(int.Parse(txtID.Text), txtTitle.Text);
                    DBAccess.update_institution_Main(iMain);
                   
                    dgv_orgType.DataSource = DBAccess.dataTableLoad("sp_load_institution_type");

                    logs = new auditTrail(frm_login.UserName, "Updated Organization type id " + txtID.Text);
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


           // clear();
        
        }

        private void txtID_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTitle_OnValueChanged(object sender, EventArgs e)
        {
            
            if (temp_name ==txtTitle.Text.Trim())
            {
                lblerror1.Visible = false;
            }
            else if (DBAccess.find("sp_check_institution_Main", txtTitle.Text))
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








 /////////////////////// Close bracket
    }
}
