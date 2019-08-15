using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using vms_v1.CLASS;
using System.IO;



namespace vms_v1.FORMS
{
    public partial class frm_request : Form
    {

        auditTrail logs = null;

        request req = null;

        int i = 0;
        int id = 0;
        string vol_ref_no = "";

        public int req_id = 0;//temp variable para sa request id- double click sa USR CNTRL Request
        public string hst_org = "";
        public string hst_proj = "";
        public string vol = "";
        string ref_no ="";
        int isNgo = 0; // para icheck ang LPI type kung NGO 
        requestSub req_sub = null;
      

        private static int host_id = 0; //reference id ng host_org para sa pag load ng project
        public static int Host_id
        {
            get { return host_id; }
            set { host_id = value; }
        }

        private static string volOrg = "";

        public static string VolOrg
        {
            get { return frm_request.volOrg; }
            set { frm_request.volOrg = value; }
        }

        public frm_request()
        {
            InitializeComponent();
            cmbRequestStatus.DataSource = DBAccess.populatecmb("`sp_populate_cmb_request_status`", "request_status");
           
        }

        private void frm_request_Load(object sender, EventArgs e)
        {
            dgv_vol.DataSource = DBAccess.dataTableLoad("sp_load_req_sub_volunteerInfo", req_id);
           // dgv_vol.Columns[0].Visible = false;
            ref_no = txtRefNo.Text;

            if (isNgo == 1)
            {
                txtSECRegistration.Enabled = true;
            }
            else
            {
                txtSECRegistration.Enabled = false;
                txtSECRegistration.Text = string.Empty;
            }

        }

        private void dtDateCompletion_ValueChanged(object sender, EventArgs e)
        {
            txtDateCompletion.Text = dtDateCompletion.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hst_org = txtHostOrg.Text;
            hst_proj = txtProj.Text;

            using (frm_pop_up_host_org2 pop = new frm_pop_up_host_org2())
            {
                pop.ShowDialog();
                txtHostOrg.Text = pop.Org;
                if (pop.Org == string.Empty) 
                {
                    txtHostOrg.Text = hst_org;
                    txtProj.Text = hst_proj;
                }
            }
        }

        private void txtHostOrg_OnValueChanged(object sender, EventArgs e)
        {
            lblerror1.Visible = false;
            if (txtHostOrg.Text != string.Empty || hst_org != string.Empty)
            {
                btnProj.Enabled = true;
                txtProj.Text = string.Empty;
            }
            else 
            { 
                btnProj.Enabled = false; 
                txtProj.Text = string.Empty;
            }

            isNgo = DBAccess.isNGO(txtHostOrg.Text);
          
            if (isNgo == 1)
            {
                txtSECRegistration.Enabled = true;
            }
            else 
            { 
                txtSECRegistration.Enabled = false;
                txtSECRegistration.Text = string.Empty;
            }
            
        }
        private void btnProj_Click_1(object sender, EventArgs e)
        {
            host_id = DBAccess.get_data_id(txtHostOrg.Text, "sp_get_host_org_id", "host_org_id");
            hst_proj = txtProj.Text;

            frm_pop_up_project pop = new frm_pop_up_project();
            
                pop.ShowDialog();
                txtProj.Text = pop.Org;
               if (pop.Org == string.Empty) 
                {
                    txtProj.Text = hst_proj;
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vol = txtVolOrg.Text;
            using (frm_pop_up_vol_org pop = new frm_pop_up_vol_org())
            {
                pop.ShowDialog();
                txtVolOrg.Text = pop.Org;

                if(pop.Org == string.Empty)
                {
                    txtVolOrg.Text = vol;
                }
            }
        }

        private void dtDateReceived_ValueChanged(object sender, EventArgs e)
        {
            txtDateReceived.Text = dtDateReceived.Text;
        }

        private void dtDateAssesed_ValueChanged(object sender, EventArgs e)
        {
            txtDateAssesed.Text = dtDateAssesed.Text;
        }

        private void dtDateApproved_ValueChanged(object sender, EventArgs e)
        {
            txtDateApproved.Text = dtDateApproved.Text;
        }

        private void dtLetterIntent_ValueChanged(object sender, EventArgs e)
        {
            txtLetterOfIntent.Text = dtLetterIntent.Text;
        }
        private void dtRFV_ValueChanged(object sender, EventArgs e)
        {
            txtRFV.Text = dtRFV.Text;
        }
        private void dtSiteAssessment_ValueChanged(object sender, EventArgs e)
        {
            txtSiteAssestment.Text = dtSiteAssessment.Text;
        }
        private void dtAFVOR_ValueChanged(object sender, EventArgs e)
        {
            txtAFVOR.Text = dtAFVOR.Text;
        }
       private void txtRefNo_OnValueChanged(object sender, EventArgs e)
       {
           if(ref_no == txtRefNo.Text.Trim())
           {
               lblError.Visible = false;
           }
           else if (DBAccess.find("sp_check_id_request", txtRefNo.Text))
           {
               lblError.Visible = true;
           }
           else 
           { 
               lblError.Visible = false; 
           }
       }

       private void txtProj_OnValueChanged(object sender, EventArgs e)
       {
           lblerror2.Visible = false;
           if(txtProj.Text != string.Empty)
           {
               btnProj.Enabled = true;
           }
       }

       private void button1_Click(object sender, EventArgs e)
       {
         
           this.Close();
       }

       private bool check() 
       {
           if (Functions.checkSpace(
                        txtHostOrg.Text,
                        txtProj.Text,
                        txtVolOrg.Text))
           {
               return true;
           }
           else { return false; }
       }

       private void btnSave_Click_1(object sender, EventArgs e)
       {
           if (lblError.Visible == true)
           {
               MessageBox.Show("Error in Saving Request Info!", "Error!", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
           }
           else if(txtRefNo.Text == string.Empty)
           {
               
               MessageBox.Show("Ref. No is required!",
                   "Error in Saving!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               this.ActiveControl = txtRefNo;
               txtRefNo.Focus();
           }
           else if (txtSECRegistration.Text == string.Empty && isNgo == 1)
           {
               MessageBox.Show("Sec Registration is required for NGO!",
                   "Error in Saving!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               this.ActiveControl = txtSECRegistration;
               txtSECRegistration.Focus();
           }
           else if(check())
           {
               lblerror1.Visible = true;
               lblerror2.Visible = true;
               lblerror3.Visible = true;
              
               if(txtHostOrg.Text != string.Empty) { lblerror1.Visible = false; }
               if (txtProj.Text != string.Empty) { lblerror2.Visible = false; }
               if (txtVolOrg.Text != string.Empty) { lblerror3.Visible = false; }

                MessageBox.Show("Please complete the fields!",
                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {
               try
               {

                   int vol_org_id = DBAccess.get_cmb_data(txtVolOrg.Text,
                        "sp_get_vol_org",
                        "vol_org_id");
                   int host_org_id = DBAccess.get_cmb_data(txtHostOrg.Text,
                        "sp_get_host_org_id",
                        "host_org_id");
                   int proj_id = DBAccess.get_cmb_data(txtProj.Text,
                        "sp_get_project_id",
                        "project_id");
                   int req_stat_id = DBAccess.get_cmb_data(cmbRequestStatus.Text,
                        "sp_get_cmb_req_status",
                        "request_status_ID");

                   req = new request(txtRefNo.Text.Trim(),
                        txtDuration.Text.Trim(),
                        host_org_id.ToString().Trim(),
                        proj_id.ToString().Trim(),
                        vol_org_id.ToString().Trim(),
                        txtDateReceived.Text.Trim(),
                        txtDateAssesed.Text.Trim(),
                        txtDateApproved.Text.Trim(),
                        frm_login.UserName,
                        req_stat_id.ToString().Trim(),
                        rtbRemarks.Text,
                        txtLetterOfIntent.Text.Trim(),
                        txtRFV.Text.Trim(),
                        txtSiteAssestment.Text.Trim(),
                        txtSECRegistration.Text.Trim(),
                        txtAFVOR.Text.Trim(),
                        chbCompleteRequirement.Checked ?1:0,
                        txtDateCompletion.Text.Trim(),
                        rtbRequirementRemarks.Text
                        );


                   DBAccess.insert_request(req);

                   logs = new auditTrail(frm_login.UserName, "Added Request id ");
                   DBAccess.insert_logs(logs);

                   MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                     MessageBoxIcon.Information);

                   this.Close();

               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
               }
           }
       }


       private void btnUpdate_Click(object sender, EventArgs e)
       {
           if (lblError.Visible == true)
           {
               MessageBox.Show("Error in Saving Request Info!", "Error!", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
           }
           else if (txtRefNo.Text == string.Empty)
           {
               MessageBox.Show("Ref. No is required!",
                   "Error in Saving!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               this.ActiveControl = txtRefNo;
               txtRefNo.Focus();
           }
           else if (txtSECRegistration.Text == string.Empty && isNgo == 1)
           {
               MessageBox.Show("Sec Registration is required in NGO!",
                   "Error in Saving!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               this.ActiveControl = txtSECRegistration;
               txtSECRegistration.Focus();
           }
           else if (check())
           {
               lblerror1.Visible = true;
               lblerror2.Visible = true;
               lblerror3.Visible = true;

               if (txtHostOrg.Text != string.Empty) { lblerror1.Visible = false; }
               if (txtProj.Text != string.Empty) { lblerror2.Visible = false; }
               if (txtVolOrg.Text != string.Empty) { lblerror3.Visible = false; }

               MessageBox.Show("Please complete the fields!",
                  "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else if (req_id == 0) { MessageBox.Show("Bug in ID!"); }
           else
           {
               try
               {

                   int vol_org_id = DBAccess.get_cmb_data(txtVolOrg.Text,
                        "sp_get_vol_org",
                        "vol_org_id");
                   int host_org_id = DBAccess.get_cmb_data(txtHostOrg.Text,
                        "sp_get_host_org_id",
                        "host_org_id");
                   int proj_id = DBAccess.get_cmb_data(txtProj.Text,
                        "sp_get_project_id",
                        "project_id");
                   int req_stat_id = DBAccess.get_cmb_data(cmbRequestStatus.Text,
                        "sp_get_cmb_req_status",
                        "request_status_ID");

                   req = new request(req_id,
                        txtRefNo.Text,
                        txtDuration.Text,
                        host_org_id.ToString(),
                        proj_id.ToString(),
                        vol_org_id.ToString(),
                        txtDateReceived.Text,
                        txtDateAssesed.Text,
                        txtDateApproved.Text,
                        req_stat_id.ToString(),
                        rtbRemarks.Text,
                        txtLetterOfIntent.Text,
                        txtRFV.Text,
                        txtSiteAssestment.Text,
                        txtSECRegistration.Text,
                        txtAFVOR.Text,
                        chbCompleteRequirement.Checked ? 1 : 0,
                        txtDateCompletion.Text,
                        rtbRequirementRemarks.Text
                        );

                   DBAccess.update_request(req);
                   

                   logs = new auditTrail(frm_login.UserName, "Updated Request ID  " + txtRefNo.Text);
                   DBAccess.insert_logs(logs);

                   MessageBox.Show("Successfully Updated!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);

                   this.Close();

               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
               }
           }
       }

       public void updateReq() 
       {
          try
               {
                   int vol_org_id = DBAccess.get_cmb_data(txtVolOrg.Text,
                        "sp_get_vol_org",
                        "vol_org_id");
                   int host_org_id = DBAccess.get_cmb_data(txtHostOrg.Text,
                        "sp_get_host_org_id",
                        "host_org_id");
                   int proj_id = DBAccess.get_cmb_data(txtProj.Text,
                        "sp_get_project_id",
                        "project_id");
                   int req_stat_id = DBAccess.get_cmb_data(cmbRequestStatus.Text,
                        "sp_get_cmb_req_status",
                        "request_status_ID");

                   int complete_req = 0;
                   if (chbCompleteRequirement.Checked == true)
                   {
                       complete_req = 1;
                   }

                   req = new request(req_id,
                        txtRefNo.Text,
                        txtDuration.Text,
                        host_org_id.ToString(),
                        proj_id.ToString(),
                        vol_org_id.ToString(),
                        txtDateReceived.Text,
                        txtDateAssesed.Text,
                        txtDateApproved.Text,
                        req_stat_id.ToString(),
                        rtbRemarks.Text,
                        txtLetterOfIntent.Text,
                        txtRFV.Text,
                        txtSiteAssestment.Text,
                        txtSECRegistration.Text,
                        txtAFVOR.Text,
                        complete_req,
                        txtDateCompletion.Text,
                        rtbRequirementRemarks.Text
                        );

                   DBAccess.update_request(req);
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
               }
           
 
       }

       private void txtVolOrg_OnValueChanged(object sender, EventArgs e)
       {
           lblerror3.Visible = false;
       }

       private void dgv_vol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
       {
           frm_request_sub frm_req_sub = new frm_request_sub();
           updateReq();
           volOrg = txtVolOrg.Text;//para sa reference id sa pag load ng list ng volunteer sa pop up form nito- request sub
           int i = dgv_vol.CurrentRow.Index;
           int id = int.Parse(dgv_vol.Rows[i].Cells["Sub ID"].Value.ToString());
           req_sub = DBAccess.get_request_sub(id);

           if (req_sub != null)
           {
               try
               {
                   frm_req_sub.reqSubID = req_sub.SubID;
                   frm_req_sub.reqID = req_sub.ReqID;
                   frm_req_sub.reportID = req_sub.ReportID;
                   frm_req_sub.volID = req_sub.VolID;
                   frm_req_sub.cmbSector.Text = req_sub.SectorID;
                   frm_req_sub.txtRefNo.Text = req_sub.VolRefno;
                   frm_req_sub.txtVolName.Text = req_sub.VolName;
                   frm_req_sub.txtWFP.Text = req_sub.WFP1;
                   frm_req_sub.txtPlacementRpt.Text = req_sub.PlacementRpt;
                   frm_req_sub.txtInitialRpt.Text = req_sub.InitialRpt;
                   frm_req_sub.txtAnnualRPt.Text = req_sub.AnnualRpt;
                   frm_req_sub.txtEndOfAssigment.Text = req_sub.EndOfAssignment;
                   frm_req_sub.txtBatchNumber.Text = req_sub.BatchNumber;
                   frm_req_sub.txtStartOfAssistance.Text = req_sub.StartAssistance;

                   //frm_req_sub.dtStartOfAssistance.Value = Convert.ToDateTime(req_sub.StartAssistance);
                  // frm_req_sub.dtEndOfAssistance.Value = Convert.ToDateTime(req_sub.EndAssistance);

                   frm_req_sub.txtEndOfAssistance.Text = req_sub.EndAssistance;
                   frm_req_sub.cmbVolStatus.Text = req_sub.VolunteerStatus;
                   frm_req_sub.cmbSpecialization.Text = req_sub.SpecializationID;
                   frm_req_sub.cmbSpecializationSub.Text  = req_sub.SpecializationSubID;
                   frm_req_sub.txtsectr.Text = req_sub.SectorID;
                   frm_req_sub.txtspec.Text = req_sub.SpecializationID;
                   frm_req_sub.txtspec_sub.Text = req_sub.SpecializationSubID;
                   frm_req_sub.rtbActivitiesAndAccmplshmnt.Text = req_sub.ActivitiesAndAccmplsmnt;
                   frm_req_sub.rtbIssueAndConcern.Text = req_sub.IssueAndConcerns;
                   frm_req_sub.rtbRecommendation.Text = req_sub.Recommendations;
                   frm_req_sub.rtbMajorOutput.Text = req_sub.MajorOutput;
                   frm_req_sub.rtfOutcomes.Text = req_sub.Outcomes;

                 //  frm_req_sub.pbVolunteer.Image = Image.FromFile("" + req_sub.VolPiture);

                   if (req_sub.VolPiture != "")
                   {
                       try
                       {
                           frm_req_sub.pbVolunteer.Image = Image.FromFile("" + req_sub.VolPiture);
                       }
                       catch (FileNotFoundException ex)
                       { }
                   } 
                   

                   volOrg = txtVolOrg.Text;
                   frm_req_sub.btnsearch.Visible = false;
                   frm_req_sub.btnSave.Visible = false;
                   frm_req_sub.ShowDialog();
                  

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
           volOrg = txtVolOrg.Text; //para sa reference id sa pag load ng list ng volunteer sa pop up form nito- request sub
           updateReq();
           frm_request_sub frm_req_sub1 = new frm_request_sub();
           frm_req_sub1.Req_id_for_add = req_id;
           frm_req_sub1.btnUpdate.Visible = false;
           frm_req_sub1.btnExtension.Visible = false;
         
           frm_req_sub1.ShowDialog();
       }

       private void btnRef_Click(object sender, EventArgs e)
       {
           dgv_vol.DataSource = DBAccess.dataTableLoad("sp_load_req_sub_volunteerInfo", req_id);
       }

       private void cmbRequestStatus_SelectedIndexChanged(object sender, EventArgs e)
       {
           txtReqStatus.Text = cmbRequestStatus.Text;
       }


       private void btnDelete_Click(object sender, EventArgs e)
       {
           if (dgv_vol.RowCount == 0)
           {
               MessageBox.Show("Nothing to delete!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           }
           else
           {
               if (!DBAccess.findAcct("SELECT * FROM `t_request_sub` WHERE isActive = 1 and request_sub_id = '" + id + "'  "))
               {
                   MessageBox.Show("ID not found!\nPlease check the record's ID!",
                       "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               else
               {
                   if (MessageBox.Show("Are you sure you want to delete this record ID "
                    + id, "Confirm Action",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == System.Windows.Forms.DialogResult.Yes)
                   {
                       DBAccess.deleteData("sp_recycle_req_sub_1", Convert.ToInt32(id));
                       //.Show(vol_ref_no);
                       DBAccess.update_volunteer_status_via_delete(vol_ref_no); //para iupdate ung vol status once na idelete ung sub id nun
                       dgv_vol.DataSource = DBAccess.dataTableLoad("sp_load_req_sub_volunteerInfo", req_id);

                       logs = new auditTrail(frm_login.UserName, "Deleted Request ID  " + txtRefNo.Text);
                       DBAccess.insert_logs(logs);

                       MessageBox.Show("Successfully deleted!", "Successful!",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
               }
           }

       }

       private void dgv_vol_CellClick(object sender, DataGridViewCellEventArgs e)
       {
            i = dgv_vol.CurrentRow.Index;
            id = int.Parse(dgv_vol.Rows[i].Cells["Sub ID"].Value.ToString());
            vol_ref_no = dgv_vol.Rows[i].Cells["Vol ID"].Value.ToString(); //para iupdate ung vol status once na idelete ung sub id nun
       }

       private void button4_Click(object sender, EventArgs e)
       {
           this.WindowState = FormWindowState.Minimized;
       }

       private void dgv_vol_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
       {
           if (dgv_vol.RowCount >= 1)
           {
               btnHstOrg.Visible = false;
               btnProj.Visible = false;
               btnVolOrg.Visible = false;
           }
           if (dgv_vol.RowCount == 0)
           {
               btnHstOrg.Visible = true;
               btnProj.Visible = true;
               btnVolOrg.Visible = true;
           }
       }
       private void dgv_vol_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
       {
           if (dgv_vol.RowCount >= 1)
           {
               btnHstOrg.Visible = false;
               btnProj.Visible = false;
               btnVolOrg.Visible = false;
           }
           if (dgv_vol.RowCount == 0)
           {
               btnHstOrg.Visible = true;
               btnProj.Visible = true;
               btnVolOrg.Visible = true;
           }
       }





    }//
}
