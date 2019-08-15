using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using System.IO;


namespace vms_v1.FORMS
{
    public partial class frm_request_sub : Form
    {
        auditTrail logs = null;

        public int reqSubID; //temp variable para sa double click nung datatable ng request form
        public int reqID = 0;//
        public int reportID;//
        public int volID;//
        string ref_no = string.Empty;//para sa bug sa close nung pop_up
        string vol_name = string.Empty;//
        private string endDate = "";// para sa pag transfer nung last enddate from extension t request sub

        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private string vol_status_frm_extension = "";

        public string Vol_status_frm_extension
        {
            get { return vol_status_frm_extension; }
            set { vol_status_frm_extension = value; }
        }


        volunteer v = null;
        requestSub req_sub = null;
      
        private int req_id_for_add = 0; //para sa adding ng bagong sub request,kunin ang request_id para sa reference

        public int Req_id_for_add
        {
            get { return req_id_for_add; }
            set { req_id_for_add = value; }
        }

        public frm_request_sub()
        {
            InitializeComponent();
            cmbVolStatus.DataSource = DBAccess.populatecmb("`sp_populate_cmb_vol_status`", "status_vol");
            cmbSector.DataSource = DBAccess.populatecmb("`sp_populate_cmb_sector`", "sector");
        }

        private void frm_request_sub_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(req_id_for_add.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtWFP_ValueChanged(object sender, EventArgs e)
        {
            txtWFP.Text = dtWFP.Text;
        }

        private void dtPlacementRpt_ValueChanged(object sender, EventArgs e)
        {
            txtPlacementRpt.Text = dtPlacementRpt.Text;
        }

        private void dtInitialRpt_ValueChanged(object sender, EventArgs e)
        {
            txtInitialRpt.Text = dtInitialRpt.Text;
        }

        private void dtAnnualRpt_ValueChanged(object sender, EventArgs e)
        {
            txtAnnualRPt.Text = dtAnnualRpt.Text;
        }

        private void dtEndOfAssigment_ValueChanged(object sender, EventArgs e)
        {
            txtEndOfAssigment.Text = dtEndOfAssigment.Text;
        }

        private void dtStartOfAssistance_ValueChanged(object sender, EventArgs e)
        {
            txtStartOfAssistance.Text = dtStartOfAssistance.Text;
        }

        private void dtEndOfAssistance_ValueChanged(object sender, EventArgs e)
        {
            txtEndOfAssistance.Text = dtEndOfAssistance.Text;
        }

        private void cmbSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSpecializationSub.Text = string.Empty;
            txtspec_sub.Text = string.Empty;
            cmbSpecializationSub.DataSource = DBAccess.populatecmb(cmbSpecialization.Text, cmbSector.Text,
                "sp_populate_cmb_specialization_sub", "specialization_sub_desc");
            txtspec.Text = cmbSpecialization.Text;


        }

        private void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSpecialization.Text = string.Empty;
            cmbSpecializationSub.Text = string.Empty;
            cmbSpecialization.DataSource = DBAccess.populatecmb(cmbSector.Text, "sp_populate_cmb_specialization",
                "specialization_dsc");
            txtsectr.Text = cmbSector.Text;
            txtspec.Text = cmbSpecialization.Text;
            txtspec_sub.Text = cmbSpecializationSub.Text;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
 
            ref_no = txtRefNo.Text;
            vol_name = txtVolName.Text;

            using (frm_pop_up_volunteer pop = new frm_pop_up_volunteer())
            {
                pop.ShowDialog();

                try
                {
                    txtRefNo.Text = pop.Ref_no;
                    txtVolName.Text = pop.Vol_name;
                    pbVolunteer.Image = Image.FromFile("" + pop.Vol_pic);

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message); 
                }

                if (pop.Ref_no == string.Empty || pop.Vol_name == string.Empty || pop.Vol_pic == null)
                {

                    try
                    {
                        txtRefNo.Text = ref_no;
                        txtVolName.Text = vol_name;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message); 
                    }
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            

            if(txtStartOfAssistance.Text == string.Empty && txtEndOfAssistance.Text != string.Empty)
            {
                MessageBox.Show("Please input dates!", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if(txtStartOfAssistance.Text != string.Empty && txtEndOfAssistance.Text == string.Empty)
            {
                MessageBox.Show("Please input dates!", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
           else 
            {
                if (txtStartOfAssistance.Text != string.Empty && txtEndOfAssistance.Text != string.Empty)
                {
                    DateTime start = Convert.ToDateTime(txtStartOfAssistance.Text);
                    DateTime end = Convert.ToDateTime(txtEndOfAssistance.Text);
                    if (start > end)
                    {
                        MessageBox.Show("Incorrect dates!", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            int sector = DBAccess.get_cmb_data(cmbSector.Text, "sp_get_cmb_sector", "sector_id");
                            int spec;
                            int spec_sub;
                            int vol_status = DBAccess.get_cmb_data(cmbVolStatus.Text, "sp_get_cmb_vol_status", "status_id");
                            int vol = DBAccess.get_cmb_data(txtRefNo.Text, "sp_get_vol_id", "vol_id");


                            if (cmbSpecialization.Text == string.Empty)
                            { spec = 106; }
                            else
                            { spec = DBAccess.get_cmb_data(cmbSpecialization.Text, "sp_get_cmb_specialization", "specialization_id"); }

                            if (cmbSpecializationSub.Text == "")
                            { spec_sub = 1; }
                            else
                            { spec_sub = DBAccess.get_cmb_data(cmbSpecializationSub.Text, "`sp_get_cmb_specializationSUB`", "specialization_sub_id"); }

                            req_sub = new requestSub(
                                reqSubID,
                                reportID,
                                sector.ToString(),
                                spec.ToString(),
                                spec_sub.ToString(),
                                txtBatchNumber.Text.Trim(),
                                vol_status.ToString(),
                                vol,
                                txtStartOfAssistance.Text.Trim(),
                                txtEndOfAssistance.Text.Trim(),
                                txtWFP.Text.Trim(),
                                txtPlacementRpt.Text.Trim(),
                                txtInitialRpt.Text.Trim(),
                                txtAnnualRPt.Text.Trim(),
                                txtEndOfAssigment.Text.Trim(),
                                rtbActivitiesAndAccmplshmnt.Text,
                                rtbIssueAndConcern.Text,
                                rtbRecommendation.Text,
                                rtbMajorOutput.Text,
                                rtfOutcomes.Text
                                 );

                            DBAccess.update_request_sub(req_sub);

                            logs = new auditTrail(frm_login.UserName, "Updated Request sub ID  " + reqSubID);
                            DBAccess.insert_logs(logs);

                            v = new volunteer(txtRefNo.Text, txtvolstatus.Text);
                            DBAccess.update_volunteer_status(v);

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
                else 
                {
                    try
                    {
                        int sector = DBAccess.get_cmb_data(cmbSector.Text, "sp_get_cmb_sector", "sector_id");
                        int spec;
                        int spec_sub;
                        int vol_status = DBAccess.get_cmb_data(cmbVolStatus.Text, "sp_get_cmb_vol_status", "status_id");
                        int vol = DBAccess.get_cmb_data(txtRefNo.Text, "sp_get_vol_id", "vol_id");


                        if (cmbSpecialization.Text == string.Empty)
                        { spec = 106; }
                        else
                        { spec = DBAccess.get_cmb_data(cmbSpecialization.Text, "sp_get_cmb_specialization", "specialization_id"); }

                        if (cmbSpecializationSub.Text == "")
                        { spec_sub = 1; }
                        else
                        { spec_sub = DBAccess.get_cmb_data(cmbSpecializationSub.Text, "`sp_get_cmb_specializationSUB`", "specialization_sub_id"); }

                        req_sub = new requestSub(
                            reqSubID,
                            reportID,
                            sector.ToString(),
                            spec.ToString(),
                            spec_sub.ToString(),
                            txtBatchNumber.Text.Trim(),
                            vol_status.ToString(),
                            vol,
                            txtStartOfAssistance.Text.Trim(),
                            txtEndOfAssistance.Text.Trim(),
                            txtWFP.Text.Trim(),
                            txtPlacementRpt.Text.Trim(),
                            txtInitialRpt.Text.Trim(),
                            txtAnnualRPt.Text.Trim(),
                            txtEndOfAssigment.Text.Trim(),
                            rtbActivitiesAndAccmplshmnt.Text,
                            rtbIssueAndConcern.Text,
                            rtbRecommendation.Text,
                            rtbMajorOutput.Text,
                            rtfOutcomes.Text
                             );

                        DBAccess.update_request_sub(req_sub);

                        logs = new auditTrail(frm_login.UserName, "Updated Request sub ID  " + reqSubID);
                        DBAccess.insert_logs(logs);

                        v = new volunteer(txtRefNo.Text, txtvolstatus.Text);
                        DBAccess.update_volunteer_status(v);

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
        }

        public bool check_in_service() 
        {
            string data = DBAccess.vol_check_in_service("sp_check_vol_in_service", txtRefNo.Text);

            if (data == "In Service" || data == "Finished Contract") 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(txtStartOfAssistance.Text == string.Empty && txtEndOfAssistance.Text != string.Empty)
            {
                MessageBox.Show("Please input dates!", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if(txtStartOfAssistance.Text != string.Empty && txtEndOfAssistance.Text == string.Empty)
            {
                MessageBox.Show("Please input dates!", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (txtRefNo.Text == string.Empty)
            {
                MessageBox.Show("Please select Volunteer!", "", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                lblerror2.Visible = true;
            }
           else 
            {
                if (txtStartOfAssistance.Text != string.Empty && txtEndOfAssistance.Text != string.Empty)
                {
                    DateTime start = Convert.ToDateTime(txtStartOfAssistance.Text);
                    DateTime end = Convert.ToDateTime(txtEndOfAssistance.Text);
                    if (start > end)
                    {
                        MessageBox.Show("Incorrect dates!", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else 
                    {
                        try
                        {
                            int sector = DBAccess.get_cmb_data(cmbSector.Text, "sp_get_cmb_sector", "sector_id");
                            int spec = DBAccess.get_cmb_data(cmbSpecialization.Text, "sp_get_cmb_specialization", "specialization_id");
                            int spec_sub;
                            int vol_status = DBAccess.get_cmb_data(cmbVolStatus.Text, "sp_get_cmb_vol_status", "status_id");
                            int vol = DBAccess.get_cmb_data(txtRefNo.Text, "sp_get_vol_id", "vol_id");

                            if (cmbSpecializationSub.Text == "")
                            { spec_sub = 1; }
                            else
                            { spec_sub = DBAccess.get_cmb_data(cmbSpecializationSub.Text, "`sp_get_cmb_specializationSUB`", "specialization_sub_id"); }

                            req_sub = new requestSub(
                                req_id_for_add,
                                sector.ToString(),
                                spec.ToString(),
                                spec_sub.ToString(),
                                txtBatchNumber.Text.Trim(),
                                vol_status.ToString(),
                                vol,
                                txtStartOfAssistance.Text.Trim(),
                                txtEndOfAssistance.Text.Trim(),
                                txtWFP.Text.Trim(),
                                txtPlacementRpt.Text.Trim(),
                                txtInitialRpt.Text.Trim(),
                                txtAnnualRPt.Text.Trim(),
                                txtEndOfAssigment.Text.Trim(),
                                rtbActivitiesAndAccmplshmnt.Text,
                                rtbIssueAndConcern.Text,
                                rtbRecommendation.Text,
                                rtbMajorOutput.Text,
                                rtfOutcomes.Text
                                 );

                            DBAccess.insert_request_sub(req_sub);
                            MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            logs = new auditTrail(frm_login.UserName, "Added Request sub of request ID " + Req_id_for_add);
                            DBAccess.insert_logs(logs);


                            v = new volunteer(txtRefNo.Text, txtvolstatus.Text);
                            DBAccess.update_volunteer_status(v);


                            this.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                        }
                    }
                }
                else 
                {
                    try
                    {
                        int sector = DBAccess.get_cmb_data(cmbSector.Text, "sp_get_cmb_sector", "sector_id");
                        int spec = DBAccess.get_cmb_data(cmbSpecialization.Text, "sp_get_cmb_specialization", "specialization_id");
                        int spec_sub;
                        int vol_status = DBAccess.get_cmb_data(cmbVolStatus.Text, "sp_get_cmb_vol_status", "status_id");
                        int vol = DBAccess.get_cmb_data(txtRefNo.Text, "sp_get_vol_id", "vol_id");

                        if (cmbSpecializationSub.Text == "")
                        { spec_sub = 1; }
                        else
                        { spec_sub = DBAccess.get_cmb_data(cmbSpecializationSub.Text, "`sp_get_cmb_specializationSUB`", "specialization_sub_id"); }

                        req_sub = new requestSub(
                            req_id_for_add,
                            sector.ToString(),
                            spec.ToString(),
                            spec_sub.ToString(),
                            txtBatchNumber.Text.Trim(),
                            vol_status.ToString(),
                            vol,
                            txtStartOfAssistance.Text.Trim(),
                            txtEndOfAssistance.Text.Trim(),
                            txtWFP.Text.Trim(),
                            txtPlacementRpt.Text.Trim(),
                            txtInitialRpt.Text.Trim(),
                            txtAnnualRPt.Text.Trim(),
                            txtEndOfAssigment.Text.Trim(),
                            rtbActivitiesAndAccmplshmnt.Text,
                            rtbIssueAndConcern.Text,
                            rtbRecommendation.Text,
                            rtbMajorOutput.Text,
                            rtfOutcomes.Text
                             );

                        DBAccess.insert_request_sub(req_sub);
                        MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        logs = new auditTrail(frm_login.UserName, "Added Request sub of request ID " + Req_id_for_add);
                        DBAccess.insert_logs(logs);


                        v = new volunteer(txtRefNo.Text, txtvolstatus.Text);
                        DBAccess.update_volunteer_status(v);


                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                    }
                }
             }



         
        }

        private void cmbVolStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtvolstatus.Text = cmbVolStatus.Text;
        }

        private void cmbSpecializationSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtspec_sub.Text = cmbSpecializationSub.Text;
        }

        private void btnExtension_Click(object sender, EventArgs e)
        {
            if (!check_in_service())
            {
                MessageBox.Show("Volunteer is not yet deployed!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else
            {
                endDate = txtEndOfAssistance.Text;
                vol_status_frm_extension = txtvolstatus.Text;

                using (frm_extension pop = new frm_extension())
                {
                    pop.Req_sub_id = reqSubID;
                    pop.btnSave.Visible = false;
                    pop.btnCancel.Visible = false;
                    pop.ShowDialog();
                    txtEndOfAssistance.Text = pop.EndDateEx;
                    txtvolstatus.Text = pop.Vol_stats_frm_ext;

                    if (pop.EndDateEx == string.Empty && pop.Vol_stats_frm_ext == "")
                    {
                        txtEndOfAssistance.Text = endDate;
                        txtvolstatus.Text = vol_status_frm_extension;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtRefNo_OnValueChanged(object sender, EventArgs e)
        {
            lblerror2.Visible = false;
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }
                
    
    
    
    
    
    }//
}
