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
    public partial class frm_manage_sector : Form
    {
        auditTrail logs = null;

        sector sec = null;
        string temp_name = "";
        public frm_manage_sector()
        {
            InitializeComponent();
        }

        private void frm_manage_sector_Load(object sender, EventArgs e)
        {
            dgv_sector.DataSource = DBAccess.dataTableLoad("sp_load_sector");
            //dgv_sector.Columns[0].Visible = false;
        }

        public void clear()
        {
            txtTitle.Enabled = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            dgv_sector.Enabled = true;

            dgv_sector.Enabled = true;
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
            dgv_sector.Enabled = true;
            clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblerror1.Visible == true)
                {
                    MessageBox.Show("Sector title is already in use!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else if (txtTitle.Text == string.Empty)
                {
                    MessageBox.Show("Please complete the required data!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else
                {
                    sec = new sector(txtTitle.Text);

                    DBAccess.insert_sector(sec);
                    
                    dgv_sector.DataSource = DBAccess.dataTableLoad("sp_load_sector");
                    btnUpdate.Visible = true;
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                    dgv_sector.Enabled = true;

                    logs = new auditTrail(frm_login.UserName, "Added a Sector ");
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

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
            else if (DBAccess.find("sp_check_sector", txtTitle.Text))
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

        private void dgv_sector_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = dgv_sector.CurrentRow.Index;
            int id = int.Parse(dgv_sector.Rows[i].Cells["ID"].Value.ToString());

            sec = DBAccess.get_sector(id);

            if (sec != null)
            {
                try
                {
                    txtID.Text = sec.Id.ToString();
                    txtTitle.Text = sec.Name;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clear();
            txtTitle.Enabled = true;
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            dgv_sector.Enabled = false;
            this.ActiveControl = txtTitle;
            txtTitle.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblerror1.Visible == true)
                {
                    MessageBox.Show("Sector name is already in use!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                else if (txtID.Text == string.Empty || txtID.Text == "(Auto Generated)")
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
                    sec = new sector(int.Parse(txtID.Text), txtTitle.Text);
                    DBAccess.update_sector(sec);

                    dgv_sector.DataSource = DBAccess.dataTableLoad("sp_load_sector");

                    logs = new auditTrail(frm_login.UserName, "Updated sector id " + txtID.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }













        ////
    }
}
