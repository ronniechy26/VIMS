using System;
using System.Windows.Forms;
using vms_v1.CLASS;



namespace vms_v1.FORMS
{
    public partial class frm_user_management : Form
    {
        auditTrail logs = null;
     
        loginInformation log_info = null;

        public frm_user_management()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_user_management_Load(object sender, EventArgs e)
        {
            dgv_login.DataSource = DBAccess.dataTableLoad("sp_load_login");
            dgv_login.Columns[0].Visible = false;
            
        }

        private void dgv_login_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        
      
            int i = dgv_login.CurrentRow.Index;
            int id = int.Parse(dgv_login.Rows[i].Cells["ID"].Value.ToString());

            log_info = DBAccess.get_login_info(id);

            if (log_info != null)
            {
                try
                {
                    txtID.Text = log_info.Id.ToString();
                    txtUsername.Text = log_info.Username;
                    txtPassword.Text = log_info.Password;
                    txtretypepassword.Text = log_info.Password;
                    lblerror1.Visible = false;
                    lblerror2.Visible = false;
                    if (log_info.UserLevel == 2)
                    {
                        rdbAdmin.Checked = true;
                    }
                    else { rdbStaff.Checked = true; }

                    if (log_info.IsActive == 1)
                    {
                        rdbActivated.Checked = true;
                    }
                    else { rdbDeActivated.Checked = true; }

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             try 
             {
                 if (txtID.Text == string.Empty || txtID.Text == "(Auto Generated)")
                 {
                     MessageBox.Show("Please select user to update!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                 }
                 else
                 {
                     log_info = new loginInformation(int.Parse(txtID.Text.Trim()), 
                         rdbAdmin.Checked ? 2 : 1,
                         rdbActivated.Checked ?1:0);

                     DBAccess.update_login_admin(log_info);
                    
                     dgv_login.DataSource = DBAccess.dataTableLoad("sp_load_login");

                     logs = new auditTrail(frm_login.UserName, "Updated the account " + txtUsername.Text );
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

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnCancel.Visible =false;
            btnAdd.Visible = true;
            btnSave.Visible = false;
            dgv_login.Enabled = true;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            txtretypepassword.Enabled = false;
            clear();
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            btnUpdate.Visible = false;
            btnCancel.Visible = true;
            btnAdd.Visible = false;
            btnSave.Visible = true;
            dgv_login.Enabled = false;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtretypepassword.Enabled = true;
            this.ActiveControl = txtUsername;
            clear();
            rdbActivated.Checked = true;
            rdbAdmin.Checked = true;
            this.ActiveControl = txtUsername;
            txtUsername.Focus();


        }
        public void clear() 
        {
           
            txtID.Text = "(Auto Generated)";
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtretypepassword.Text = string.Empty;
            rdbActivated.Checked = false;
            rdbAdmin.Checked = false;
            rdbDeActivated.Checked = false;
            rdbStaff.Checked = false;
            lblerror1.Visible = false;
            lblerror2.Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            { 
                if (lblerror1.Visible == true)
                {
                    MessageBox.Show("Username is already in use!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else if (lblerror2.Visible == true) 
                {
                    MessageBox.Show("Password does not matched!", "", MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
                else if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Please complete the required data!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else
                {
                    log_info = new loginInformation(txtUsername.Text.Trim(), 
                        txtPassword.Text.Trim(), 
                        rdbAdmin.Checked ?2:1, 1);

                    DBAccess.insert_login_admin(log_info);

                    logs = new auditTrail(frm_login.UserName, "Added User Account ");
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);

                    dgv_login.DataSource = DBAccess.dataTableLoad("sp_load_login");
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                    btnAdd.Visible = true;
                    dgv_login.Enabled = true;

                    

                   

                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }

        }

        private void txtUsername_OnValueChanged(object sender, EventArgs e)
        {
            if (DBAccess.find("sp_login_check_username", txtUsername.Text))
            {
                lblerror1.Visible = true;
            }
            else
            {
                lblerror1.Visible = false;
            }

        }

        private void txtretypepassword_OnValueChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtretypepassword.Text)
            {
                lblerror2.Visible = true;
            }
            else { lblerror2.Visible = false; }
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtretypepassword.Text && txtretypepassword.Text != string.Empty)
            {
                lblerror2.Visible = true;
            }
            else { lblerror2.Visible = false; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        

      
    }////
}
