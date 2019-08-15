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
    public partial class frm_manage_specialization : Form
    {
         auditTrail logs = null;

        string temp_name = "";
        specialization spec = null;

        public frm_manage_specialization()
        {
            InitializeComponent();
            cmbSector.DataSource = DBAccess.populatecmb("`sp_populate_cmb_sector`", "sector");
            
        }

        private void frm_manage_specialization_Load(object sender, EventArgs e)
        {
            dgv_spec.DataSource = DBAccess.dataTableLoad("sp_load_specialization");
           // dgv_spec.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void clear()
        {
            txtTitle.Enabled = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            dgv_spec.Enabled = true;
           // txtsec.Text = "";

            dgv_spec.Enabled = true;
            txtTitle.Text = "";
            // txtUsername.Enabled = false;
            txtID.Text = "(Auto Generated)";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgv_spec_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = dgv_spec.CurrentRow.Index;
            int id = int.Parse(dgv_spec.Rows[i].Cells["ID"].Value.ToString());

            spec = DBAccess.get_specialization(id);

            if (spec != null)
            {
                try
                {
                    txtID.Text = spec.Id.ToString();
                    txtTitle.Text = spec.Name;
                    cmbSector.Text = spec.Sector;
                    txtsec.Text = spec.Sector;

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
            dgv_spec.Enabled = false;
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
            dgv_spec.Enabled = true;
            clear();
        }

        private void cmbSpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsec.Text = cmbSector.Text;
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
                else if (txtTitle.Text == string.Empty.Trim())
                {
                    MessageBox.Show("Please input specilization!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);

                }else if(lblerror1.Visible == true)
                {
                    MessageBox.Show("Specialization Title is in use!", "", MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
                else
                {
                    int sector = DBAccess.get_cmb_data(cmbSector.Text, "sp_get_cmb_sector", "sector_id");




                    spec = new specialization(int.Parse(txtID.Text), sector.ToString() ,txtTitle.Text);
                    DBAccess.update_specialization(spec);

                    dgv_spec.DataSource = DBAccess.dataTableLoad("sp_load_specialization");

                    logs = new auditTrail(frm_login.UserName, "Updated Specialization id " + txtID.Text);
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

        private void txtTitle_OnValueChanged(object sender, EventArgs e)
        {
            if (temp_name == txtTitle.Text.Trim())
            {
                lblerror1.Visible = false;
            }
            else if (DBAccess.find("sp_check_specialization", txtTitle.Text))
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
                    int sector = DBAccess.get_cmb_data(cmbSector.Text, "sp_get_cmb_sector", "sector_id");

                    spec = new specialization(sector.ToString(), txtTitle.Text);
                    DBAccess.insert_specialization(spec);

                    logs = new auditTrail(frm_login.UserName, "Added a Specialization ");
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    dgv_spec.DataSource = DBAccess.dataTableLoad("sp_load_specialization");
                    btnUpdate.Visible = true;
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                    dgv_spec.Enabled = true;


                    clear();


                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }

        }









    }
}
