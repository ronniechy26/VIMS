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
    public partial class frm_extension : Form
    {
        extensionVol ext = null;
        private int req_sub_id = 0;

        auditTrail logs = null;

        private string vol_stats_frm_ext = "";

        public string Vol_stats_frm_ext
        {
            get { return vol_stats_frm_ext; }
            set { vol_stats_frm_ext = value; }
        }

        private string endDateEx = "";

        public string EndDateEx
        {
            get { return endDateEx; }
            set { endDateEx = value; }
        }


        public int Req_sub_id
        {
            get { return req_sub_id; }
            set { req_sub_id = value; }
        }

        public frm_extension()
        {
            InitializeComponent();
        }

        private void frm_extension_Load(object sender, EventArgs e)
        {
            txtID.Text = "(Auto Generated)";
            dgv_extension.DataSource = DBAccess.dataTableLoad("sp_load_extension",Req_sub_id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtStartOfAssistance_ValueChanged(object sender, EventArgs e)
        {
            txtStartOfAssistance.Text = dtStartOfAssistance.Text;
        }

        private void dtEndOfAssistance_ValueChanged(object sender, EventArgs e)
        {
            txtEndOfAssistance.Text = dtEndOfAssistance.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enable(true);
            clear();
            this.ActiveControl = txtStartOfAssistance;
            txtStartOfAssistance.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            enable(false);
            clear();
        }


        public void enable(bool x) 
        {
            if (x)
            {
                btnAdd.Visible = false;
                btnCancel.Visible = true;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
            else 
            {
                btnAdd.Visible = true;
                btnCancel.Visible = false;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
        }
        public void clear() 
        {
            txtID.Text = "(Auto Generated)";
            txtStartOfAssistance.Text = "";
            txtEndOfAssistance.Text = "";
            rtbRemarks.Text = "";
        }

        private void dgv_extension_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_extension.CurrentRow.Index;
            int id = int.Parse(dgv_extension.Rows[i].Cells["ID"].Value.ToString());
            ext = DBAccess.get_extension(id);

            if (ext != null)
            {
                try
                {

                    txtID.Text = ext.Id.ToString();
                    txtStartOfAssistance.Text = ext.StartDate;
                    txtEndOfAssistance.Text = ext.EndDate;
                    rtbRemarks.Text = ext.Remarks;
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
            if (txtStartOfAssistance.Text == string.Empty && txtEndOfAssistance.Text == string.Empty)
            {
                MessageBox.Show("Error in updating extension!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
            else if (txtID.Text == "(Auto Generated)" || txtID.Text =="") 
            {
                MessageBox.Show("Please select data to update!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
            else if (dtStartOfAssistance.Value > dtEndOfAssistance.Value)
            {
                MessageBox.Show("Incorrect dates!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    ext = new extensionVol(
                        int.Parse(txtID.Text),
                        req_sub_id,
                        txtStartOfAssistance.Text,
                        txtEndOfAssistance.Text,
                        rtbRemarks.Text
                         );

                    endDateEx = txtEndOfAssistance.Text;
                    vol_stats_frm_ext = "In Service";

                    DBAccess.update_extension(ext);
                    DBAccess.update_endAssistance_via_extension(req_sub_id, txtEndOfAssistance.Text);
                    dgv_extension.DataSource = DBAccess.dataTableLoad("sp_load_extension", Req_sub_id);
                    
                    enable(false);
                    clear();

                    logs = new auditTrail(frm_login.UserName, "updated extension of request sub id " + Req_sub_id);
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Updated!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }
            }

           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStartOfAssistance.Text == string.Empty && txtEndOfAssistance.Text == string.Empty)
            {
                MessageBox.Show("Error in updating extension!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
            else if (req_sub_id == 0) 
            {
                MessageBox.Show("bug in request id!");
            }else if(dtStartOfAssistance.Value > dtEndOfAssistance.Value)
            {
                MessageBox.Show("Incorrect dates!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    ext = new extensionVol(
                        req_sub_id,
                        txtStartOfAssistance.Text,
                        txtEndOfAssistance.Text,
                        rtbRemarks.Text
                         );

                    endDateEx = txtEndOfAssistance.Text;
                    vol_stats_frm_ext = "In Service";

                    DBAccess.insert_extension(ext);
                    DBAccess.update_endAssistance_via_extension(req_sub_id, txtEndOfAssistance.Text);
                    dgv_extension.DataSource = DBAccess.dataTableLoad("sp_load_extension", Req_sub_id);
                   
                    enable(false);
                    clear();

                    logs = new auditTrail(frm_login.UserName, "added an extension of request sub id " + Req_sub_id);
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Updated!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }








    }
}
