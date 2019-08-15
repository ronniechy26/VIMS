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
    public partial class frm_login_password_recovery : Form
    {
        auditTrail logs = null;
        loginInformation log_info = null;

        public frm_login_password_recovery()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {   if(txtSearch.Text ==  string.Empty )
            {
                MessageBox.Show("Please Input username!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = txtSearch;
                txtSearch.Focus();
            }
            else if (!DBAccess.find("sp_login_check_username", txtSearch.Text))
            {
                MessageBox.Show("Username not found!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = txtSearch;
                txtSearch.Focus();
            }
            else 
            {
                log_info = DBAccess.get_login_info_by_username(txtSearch.Text);
              
                if (log_info != null)
                {
                    try
                    {
                        txtQuestion.Text = log_info.SecretQuestion;
                        lblHint.Text = log_info.HintPassword;
                        lblHint.Visible = true;

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
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtretypepassword.Text && txtretypepassword.Text != string.Empty)
            {
                lblerror2.Visible = true;
            }
            else { lblerror2.Visible = false; }
        }

        private void txtretypepassword_OnValueChanged(object sender, EventArgs e)
        {

            if (txtPassword.Text != txtretypepassword.Text)
            {
                lblerror2.Visible = true;
            }
            else { lblerror2.Visible = false; }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text == string.Empty)
            {
                MessageBox.Show("Please Input Answer!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!DBAccess.find("sp_login_check_QandA", txtQuestion.Text, txtAnswer.Text, txtSearch.Text))
            {
                MessageBox.Show("Incorrect Answer!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Verification Successful! \n Please Enter your new Password", 
                    "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Enabled = true;
                txtretypepassword.Enabled = true;
                btnSave.Enabled = true;
                this.ActiveControl = txtPassword;
                txtPassword.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblerror2.Visible == true)
            {
                MessageBox.Show("Password does not match!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                log_info = new loginInformation(txtSearch.Text,txtPassword.Text);
                DBAccess.update_login_password(log_info);


                logs = new auditTrail(txtSearch.Text, "Recover his/her account ");
                DBAccess.insert_logs(logs);

                MessageBox.Show("Password successfully change!", "", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frm_login_password_recovery_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtSearch;
            txtSearch.Focus();
        }






    }//
}
