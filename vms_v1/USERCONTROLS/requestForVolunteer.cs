using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using vms_v1.FORMS;


namespace vms_v1.USERCONTROLS
{
    public partial class requestForVolunteer : UserControl
    {
        auditTrail logs = null;

        int i = 0;
        string id = "";

        request req = null;
        public requestForVolunteer()
        {
            InitializeComponent();
            dgv_rqst.DataSource = DBAccess.dataTableLoad("sp_load_request",1);
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            dgv_rqst.DataSource = DBAccess.dataTableLoad("sp_load_request",1);
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
          

            //if (string.IsNullOrEmpty(txtSearch.Text))
            //{
            //    (dgv_rqst.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            //}
            //else
            //{
            //    (dgv_rqst.DataSource as DataTable).DefaultView.RowFilter =
            //        string.Format("Reference_No LIKE'{0}%' or Host_Organization LIKE'{0}%' or Volunteer_Organization LIKE'{0}%' or Project_Title LIKE'{0}%' or Request_Status LIKE'{0}%'  ", 
            //        txtSearch.Text);  
            //}
        }

        private void dgv_rqst_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frm_request frm_req = new frm_request(); 

            int i = dgv_rqst.CurrentRow.Index;
            string id = dgv_rqst.Rows[i].Cells["Reference_No"].Value.ToString();

            req = DBAccess.get_request(id);

            if (req != null)
            {
                try
                {
                    frm_req.req_id = req.Id;
                    frm_req.txtRefNo.Text = req.RefNo;
                    frm_req.txtDuration.Text = req.Duration;
                    frm_req.txtHostOrg.Text = req.HostOrg;
                    frm_req.txtProj.Text = req.ProjTitle;
                    frm_req.txtVolOrg.Text = req.VolOrg;
                    frm_req.txtDateReceived.Text = req.DateReceived;
                    frm_req.txtDateAssesed.Text = req.DateAssessed;
                    frm_req.txtDateApproved.Text = req.DateApproved;
                    frm_req.cmbRequestStatus.Text = req.RequestStatus;
                    frm_req.txtReqStatus.Text = req.RequestStatus;
                    frm_req.rtbRemarks.Text = req.Remarks;
                    frm_req.rtbRequirementRemarks.Text = req.RequirementRemarks;
                    frm_req.txtLetterOfIntent.Text = req.LetterOfIntent;
                    frm_req.txtRFV.Text = req.RVF1;
                    frm_req.txtSiteAssestment.Text = req.SiteAssesment;
                    frm_req.txtSECRegistration.Text = req.SECRegistration1;
                    frm_req.txtAFVOR.Text = req.AFVOR1;
                    frm_req.txtDateCompletion.Text = req.DateOfCompletion;
                  
                    if (req.CompleteRequirement == 1)
                    {
                        frm_req.chbCompleteRequirement.Checked = true;
                    }
                    else 
                    {
                        frm_req.chbCompleteRequirement.Checked = false;
                    }
                   // frm_req.txtRefNo.Enabled = false;
                    frm_req.btnSave.Visible = false;
                    frm_req.lblError.Visible = false;

                    if (frm_login.UserLvl != 2) 
                    {
                        frm_req.btnDelete.Enabled = false;
                    }

                    frm_req.ShowDialog();

                }
                catch (IndexOutOfRangeException ex)
                {

                    MessageBox.Show(ex.Message, "Incomplete Data!", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please click refresh!");
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            frm_request frm_req1 = new frm_request();
            frm_req1.btnUpdate.Visible = false;
            frm_req1.btnAdd.Enabled = false;
            frm_req1.btnDelete.Enabled = false;
            frm_req1.btnRef.Enabled = false;
            frm_req1.ActiveControl = frm_req1.txtRefNo;
            frm_req1.txtRefNo.Focus();
            frm_req1.ShowDialog();
            
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            if (dgv_rqst.RowCount == 0)
            {
                MessageBox.Show("Nothing to delete!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!DBAccess.findAcct("SELECT * FROM `t_request` WHERE isActive = 1 and ref_no = '" + id + "'  "))
                {
                    MessageBox.Show("ID not found!\nPlease select record ID!",
                        "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this record ID ("
                     + id + ")", "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_recycle_request_1", id);
                        dgv_rqst.DataSource = DBAccess.dataTableLoad("`sp_load_request`",1);
                        MessageBox.Show("Successfully deleted!", "Successful!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        logs = new auditTrail(frm_login.UserName, "Deleted Request id " + id);
                        DBAccess.insert_logs(logs);
                    }
                }
            }


        }

        private void dgv_rqst_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = dgv_rqst.CurrentRow.Index;
            id = dgv_rqst.Rows[i].Cells["Reference_No"].Value.ToString();
        }

        private void requestForVolunteer_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != String.Empty)
            {
                dgv_rqst.DataSource = DBAccess.search("SELECT req.ref_no AS 'Reference_No', " +
                    "org.host_org AS 'Host_Organization'," +
                    "proj.proj_title AS 'Project_Title'," +
                    "vso.vol_org_dsc AS 'Volunteer _Organization'," +
                    "req.`assessed_by`, " +
                    "req_stat.request_status AS 'Request_Status'  " +
                    "FROM " +
                    "`t_request` AS req  " +
                    "JOIN `t_host_org` AS org " +
                    "ON req.`host_org_id` = org.host_org_id " +
                    "JOIN `t_project` AS proj " +
                    "ON req.`project_id` = proj.project_id " +
                    "JOIN `t_vol_org` AS vso " +
                    "ON req.`vol_org_id` = vso.vol_org_id " +
                    "JOIN `t_request_status` AS req_stat " +
                    "ON req.`request_status_id` = req_stat.request_status_ID " +
                    "where req.isActive = 1 HAVING req.ref_no LIKE '%" + txtSearch.Text + "%' or " +
                    "org.host_org LIKE '%" + txtSearch.Text + "%' or " +
                    "proj.proj_title LIKE '%" + txtSearch.Text + "%' or " +
                    "vso.vol_org_dsc LIKE '%" + txtSearch.Text + "%' or req.`assessed_by` LIKE '%" + txtSearch.Text + "%' ORDER BY date_received DESC");
            }
            else
            {
                dgv_rqst.DataSource = DBAccess.dataTableLoad("sp_load_request", 1);
            }
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void bunifuMetroTextbox1_OnValueChanged_1(object sender, EventArgs e)
        {
            if (txtSearch.Text == String.Empty)
            {
                dgv_rqst.DataSource = DBAccess.dataTableLoad("sp_load_request", 1);
            }
        }
     


    }//
}
