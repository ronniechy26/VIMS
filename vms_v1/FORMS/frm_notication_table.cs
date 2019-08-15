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
    public partial class frm_notication_table : Form
    {
        public frm_request frm_req = new frm_request();
        request req = null;

        public frm_notication_table()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_notication_table_Load(object sender, EventArgs e)
        {
            dgv_notif.DataSource = DBAccess.dataTableLoad("sp_check_notification_for_asst_end");
        }

        private void dgv_notif_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_notif.CurrentRow.Index;
            string id = dgv_notif.Rows[i].Cells["ref_no"].Value.ToString();

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
                    // frm_req.btnAdd.Enabled = false;
                    // frm_req.btnDelete.Enabled = false;
                    // frm_req.btnUpdate.Enabled = false;
                    // frm_req.btnRef.Enabled = false;

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
                MessageBox.Show("Null");
            }
        }
    }
}
