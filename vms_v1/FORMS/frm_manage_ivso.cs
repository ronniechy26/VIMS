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
    public partial class frm_manage_ivso : Form
    {
        auditTrail logs = null;
        Ivso iv = null;
        string temp_name = "";
        public frm_manage_ivso()
        {
            InitializeComponent();
        }

        private void frm_manage_ivso_Load(object sender, EventArgs e)
        {
            dgv_ivso.DataSource = DBAccess.dataTableLoad("sp_load_vol_org_pop_up");
            //dgv_ivso.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_ivso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_ivso.CurrentRow.Index;
            int id = int.Parse(dgv_ivso.Rows[i].Cells["ID"].Value.ToString());

            iv = DBAccess.get_ivso(id);

            if (iv != null)
            {
                try
                {
                    txtID.Text = iv.Id.ToString();
                    txtUsername.Text = iv.Ivso1;
                    txtUsername.Enabled = true;
                    lblerror1.Visible = false;
                    temp_name = txtUsername.Text.Trim();

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clear();
            txtUsername.Enabled = true;
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            dgv_ivso.Enabled = false;
            this.ActiveControl = txtUsername;
            txtUsername.Focus();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            dgv_ivso.Enabled = true;
            clear();
        }


        public void clear() 
        {
            txtUsername.Enabled = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            dgv_ivso.Enabled = true;

            dgv_ivso.Enabled = true;
            txtUsername.Text = "";
           // txtUsername.Enabled = false;
            txtID.Text = "(Auto Generated)";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblerror1.Visible == true)
                {
                    MessageBox.Show("IVSO name is already in use!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else if (txtUsername.Text == string.Empty)
                {
                    MessageBox.Show("Please complete the required data!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else
                {
                    iv = new Ivso(txtUsername.Text);

                    DBAccess.insert_ivso(iv);

                    logs = new auditTrail(frm_login.UserName, "Added a IVSO");
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    dgv_ivso.DataSource = DBAccess.dataTableLoad("sp_load_vol_org_pop_up");
                    btnUpdate.Visible = true;
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                    dgv_ivso.Enabled = true;
                    
                    dgv_ivso.Enabled = true;
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
                else if(txtUsername.Text ==string.Empty)
                {
                    MessageBox.Show("Please complete input IVSO name!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else
                {
                   iv = new Ivso(int.Parse(txtID.Text),txtUsername.Text);
                   DBAccess.update_ivso(iv);

                   dgv_ivso.DataSource = DBAccess.dataTableLoad("sp_load_vol_org_pop_up");
                 
                   logs = new auditTrail(frm_login.UserName, "Updated IVSO id " + txtID.Text);
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

           
            clear();
        }

        private void txtUsername_OnValueChanged(object sender, EventArgs e)
        {
            
            if (temp_name == txtUsername.Text.Trim()) 
            {
                lblerror1.Visible = false;
            }
            else if (DBAccess.find("sp_check_ivso_name", txtUsername.Text))
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

        private void txtID_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


    
    
    
    
    
    
    
    //
    }
}
