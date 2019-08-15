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
    public partial class frm_user_account : Form
    {
        auditTrail logs = null;

        loginInformation log_info = null;
        string temp_userName = "";


        public frm_user_account()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_user_account_Load(object sender, EventArgs e)
        {
            log_info = DBAccess.get_login_info(int.Parse(frm_login.UserID));

            if (log_info != null)
            {
                try
                {
                    txtAccountName.Text = log_info.UserLoginName;
                    txtUsername.Text = log_info.Username;
                    txtPassword.Text = log_info.Password;
                    txtQuestion.Text = log_info.SecretQuestion;
                    txtAnswer.Text = log_info.SecretAnswer;
                    txtHint.Text = log_info.HintPassword;
                    temp_userName = log_info.Username;
                    lblerror1.Visible = false;
                    lblerror2.Visible = false;

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
        public bool check() 
        {
            if (Functions.checkSpace(txtAccountName.Text,
                txtAnswer.Text,txtHint.Text,txtPassword.Text,txtUsername.Text,
                txtQuestion.Text,txtAnswer.Text
                ))
            {
                return true;
            }
            else { return false; }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (check())
                {
                    MessageBox.Show("Please complete the required data!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }else if(txtretypepassword.Text ==string.Empty)
                {
                    MessageBox.Show("Password does not matched!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    lblerror2.Visible = true;
                }
                else if(lblerror1.Visible == true)
                {
                    MessageBox.Show("Username is already in  use!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else if (lblerror2.Visible == true)
                {
                    MessageBox.Show("Password does not matched!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else
                {
                    log_info = new loginInformation(int.Parse(frm_login.UserID),
                        txtUsername.Text.Trim(),
                        txtPassword.Text.Trim(),
                        txtAccountName.Text.Trim(),
                        txtQuestion.Text.Trim(),
                        txtAnswer.Text.Trim(),
                        txtHint.Text.Trim()
                        );

                    DBAccess.update_login_user(log_info);

                    logs = new auditTrail(frm_login.UserName, "Updated his/her own account  ");
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Updated!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }


        }

        private void txtUsername_OnValueChanged(object sender, EventArgs e)
        {
            if (temp_userName == txtUsername.Text)
            {
                lblerror1.Visible = false;
            }
            else if (DBAccess.find("sp_login_check_username", txtUsername.Text))
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






    }//
}
