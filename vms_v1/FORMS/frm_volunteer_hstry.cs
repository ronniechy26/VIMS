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
    public partial class frm_volunteer_hstry : Form
    {
        private string ref_no = "";
        requestSub req_sub = null;
        public frm_request_sub frm_req_sub = new frm_request_sub();

        public string Ref_no
        {
            get { return ref_no; }
            set { ref_no = value; }
        }

        public frm_volunteer_hstry()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_volunteer_hstry_Load(object sender, EventArgs e)
        {
            dgv_hstry_vol.DataSource = DBAccess.dataTableLoad("sp_load_history_vol", ref_no);
        }

        private void dgv_hstry_vol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_hstry_vol.CurrentRow.Index;
            int id = int.Parse(dgv_hstry_vol.Rows[i].Cells["Sub ID"].Value.ToString());
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
                    frm_req_sub.txtEndOfAssistance.Text = req_sub.EndAssistance;
                    frm_req_sub.cmbVolStatus.Text = req_sub.VolunteerStatus;
                    frm_req_sub.cmbSpecialization.Text = req_sub.SpecializationID;
                    frm_req_sub.cmbSpecializationSub.Text = req_sub.SpecializationSubID;
                    frm_req_sub.txtsectr.Text = req_sub.SectorID;
                    frm_req_sub.txtspec.Text = req_sub.SpecializationID;
                    frm_req_sub.txtspec_sub.Text = req_sub.SpecializationSubID;
                    frm_req_sub.rtbActivitiesAndAccmplshmnt.Text = req_sub.ActivitiesAndAccmplsmnt;
                    frm_req_sub.rtbIssueAndConcern.Text = req_sub.IssueAndConcerns;
                    frm_req_sub.rtbRecommendation.Text = req_sub.Recommendations;
                    frm_req_sub.rtbMajorOutput.Text = req_sub.MajorOutput;
                    frm_req_sub.rtfOutcomes.Text = req_sub.Outcomes;

                   // MemoryStream ms = new MemoryStream((byte[])req_sub.VolPiture);
                   // frm_req_sub.pbVolunteer.Image = Image.FromFile("" + req_sub.VolPiture);


                    if (req_sub.VolPiture != "")
                    {
                        try
                        {
                            frm_req_sub.pbVolunteer.Image = Image.FromFile("" + req_sub.VolPiture);
                        }
                        catch (FileNotFoundException ex)
                        { }
                    }
                   

                  //  volOrg = txtVolOrg.Text;
                    frm_req_sub.btnsearch.Visible = false;
                    frm_req_sub.btnSave.Visible = false;
                   // frm_req_sub.btnUpdate.Enabled = false;
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            if (this.WindowState == FormWindowState.Minimized)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    frm.WindowState = FormWindowState.Minimized;
                }
            }
        }












        ////
    }
}
