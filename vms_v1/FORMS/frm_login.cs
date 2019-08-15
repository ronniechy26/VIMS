using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using vms_v1.Properties;
using vms_v1.USERCONTROLS;


namespace vms_v1.FORMS
{
    public partial class frm_login : Form
    {
        int temp = 3;
        string isActive = "";
        auditTrail logs = null;

        private static string userID = "";
        private static string userName = "";
        private static int userLvl = 0;

        public static string UserID
        {
            get { return frm_login.userID; }
            set { frm_login.userID = value; }
        }
       
        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
      
        public static int UserLvl
        {
            get { return userLvl; }
            set { userLvl = value; }
        }

        public frm_login()
        {
            InitializeComponent();
            Settings s = new Settings();
            s.Reload();
            txtusername.Text = Settings.Default.username;
            txtpassword.Text = Settings.Default.password;
            bunifuCheckbox1.Checked = Settings.Default.check;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == string.Empty && txtpassword.Text == string.Empty)
            {
                MessageBox.Show("Please input Username and Password!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtpassword.Text == string.Empty)
            {
                MessageBox.Show("Please input Password!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtusername.Text == string.Empty)
            {
                MessageBox.Show("Please input Username!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               isActive = DBAccess.get_data_login("sp_login_check_if_active", txtusername.Text, txtpassword.Text, "isActive");
                
               if (!DBAccess.find("sp_login", txtusername.Text, txtpassword.Text))
                {
                    MessageBox.Show("Incorrect Username or Password !", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.ActiveControl = txtpassword;

                    temp -= 1;
                }
               else if (isActive != "1")
                {
                   MessageBox.Show("Your account is deactivated !", "Error!",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                   txtpassword.isPassword = true;
                }
                else
               {
                    userID = DBAccess.get_data_login("sp_login_get_id", txtusername.Text, txtpassword.Text, "ID");
                    userName = DBAccess.get_data_login("sp_login_get_name", txtusername.Text, txtpassword.Text, "login_name");
                    userLvl = int.Parse(DBAccess.get_data_login("sp_login_get_userlevel", txtusername.Text, txtpassword.Text, "userLevel"));
                   
                       logs = new auditTrail(userName, "Logged in");

                        if (userLvl == 2)
                        {
                            frm_dashboard ds = new frm_dashboard();

                            DBAccess.insert_logs(logs);

                            this.Hide();
                            ds.ShowDialog();    
                        }
                        else
                        {
                            frm_dashboard ds = new frm_dashboard();
                            ds.h.bunifuFlatButton2.Enabled = false;
                            ds.v.bunifuFlatButton2.Enabled = false;
                            ds.r.bunifuFlatButton2.Enabled = false;
                            ds.btnMaintenance.Visible = false;

                            DBAccess.insert_logs(logs);

                            this.Hide();
                            ds.ShowDialog(); 
                        }

                        if (bunifuCheckbox1.Checked == true)
                        {
                            Settings.Default.username = txtusername.Text;
                            Settings.Default.password = txtpassword.Text;
                            Settings.Default.check = true;
                            Settings.Default.Save();
                        }
                        else
                        {
                            Settings.Default.username = "Username";
                            Settings.Default.password = "Password";
                            Settings.Default.check = false;
                            Settings.Default.Save();
                        }
                }

                lblattempt.Text = temp.ToString();

                if (temp == 0)
                {
                    MessageBox.Show("You have been reach the maximum trial for " +
                        "entering Username and Password.This system will now EXIT.",
                        "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }  
            }
        }

        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void bunifuCheckbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
           this.ActiveControl = txtusername;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_login_password_recovery().ShowDialog();
        }

        private void txtpassword_OnValueChanged(object sender, EventArgs e)
        {
            txtpassword.isPassword = true;
        }

        private void frm_login_Shown(object sender, EventArgs e)
        {
            string key_string = Functions.GetSettingItem(Application.StartupPath + @"\\Settings.ini", "Keystring");
            if (key_string == "PNVSC@adm1n77" || key_string == "rnnchy")
            {
                //as is
            }
            else 
            {
                MessageBox.Show("Sorry but the keystring in the system is not recognized! Please check the keystring in Settings.ini ! ", "Fatal Error!",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }





    }//
}
