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
    public partial class frm_manage_specializationSUB : Form
    {
        auditTrail logs = null;

        string temp_name = "";
        specializationSub sub = null;

        public frm_manage_specializationSUB()
        {
            InitializeComponent();
            cmbSector.DataSource = DBAccess.populatecmb("`sp_populate_cmb_sector`", "sector");
        }

        public void clear()
        {
            txtTitle.Enabled = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            dgv_sub.Enabled = true;
            // txtsec.Text = "";

            dgv_sub.Enabled = true;
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
            dgv_sub.Enabled = false;
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
            dgv_sub.Enabled = true;
            clear();
        }

        private void frm_manage_specializationSUB_Load(object sender, EventArgs e)
        {
            dgv_sub.DataSource = DBAccess.dataTableLoad("sp_load_specialization_sub");
           // dgv_sub.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTitle_OnValueChanged(object sender, EventArgs e)
        {
            if (temp_name == txtTitle.Text.Trim())
            {
                lblerror1.Visible = false;
            }
            else if (DBAccess.find("sp_check_specialization_sub", txtTitle.Text))
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

        private void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsec.Text = cmbSector.Text;

            cmbSpec.Text = string.Empty;
            cmbSpec.DataSource = DBAccess.populatecmb(cmbSector.Text, "sp_populate_cmb_specialization",
                "specialization_dsc");
            txtsec.Text = cmbSector.Text;
            txtSpec.Text = cmbSpec.Text;
        }

        private void cmbSpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSpec.Text = cmbSpec.Text;
        }

        private void dgv_sub_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = dgv_sub.CurrentRow.Index;
            int id = int.Parse(dgv_sub.Rows[i].Cells["ID"].Value.ToString());

            sub = DBAccess.get_specialization_sub(id);

            if (sub != null)
            {
                try
                {
                    txtID.Text = sub.Id.ToString();
                    txtTitle.Text = sub.Name;
                    cmbSector.Text = sub.Sector;
                    txtsec.Text = sub.Sector;
                    cmbSpec.Text = sub.Specialization;
                    txtSpec.Text = sub.Specialization;

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

                }
                else if (lblerror1.Visible == true)
                {
                    MessageBox.Show("Specialization sub Title is already in use!", "", MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                }
                else
                {
                    int sector = DBAccess.get_cmb_data(cmbSector.Text, "sp_get_cmb_sector", "sector_id");
                    int spec = DBAccess.get_cmb_data(cmbSpec.Text, "sp_get_cmb_specialization", "specialization_id");
                    if (cmbSpec.Text == string.Empty)
                    { spec = 106; }
                    else
                    { spec = DBAccess.get_cmb_data(cmbSpec.Text, "sp_get_cmb_specialization", "specialization_id"); }

                    sub = new specializationSub(int.Parse(txtID.Text),spec.ToString(),sector.ToString(), txtTitle.Text);
                    DBAccess.update_specialization_sub(sub);
                    
                    dgv_sub.DataSource = DBAccess.dataTableLoad("sp_load_specialization_sub");

                    logs = new auditTrail(frm_login.UserName, "Updated Specialization sub id " + txtID.Text);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblerror1.Visible == true)
                {
                    MessageBox.Show("Specialization sub Title is already in use!", "", MessageBoxButtons.OK,
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
                    int spec = DBAccess.get_cmb_data(cmbSpec.Text, "sp_get_cmb_specialization", "specialization_id");
                    if (cmbSpec.Text == string.Empty)
                    { spec = 106; }
                    else
                    { spec = DBAccess.get_cmb_data(cmbSpec.Text, "sp_get_cmb_specialization", "specialization_id"); }

                    sub = new specializationSub(spec.ToString(), sector.ToString(), txtTitle.Text);
                    DBAccess.insert_specialization_sub(sub);
                   
                    dgv_sub.DataSource = DBAccess.dataTableLoad("sp_load_specialization_sub");

                    logs = new auditTrail(frm_login.UserName, "Added a Specialization sub " );
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }













     ////
    }
}
