using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.FORMS.frm_pop_up_in_rpt_vol_act;
using vms_v1.CLASS;
using MySql.Data.MySqlClient;


namespace vms_v1.FORMS.frm_pop_up_reports
{
    public partial class frm_RFV : Form
    {
        auditTrail logs = null;
        DataTable dt2 = new DataTable(); //temp para sa fatal error
        public string hst_org = "";
        public string hst_proj = "";
        public string vol = "";
        bool error = false;
        private static int host_id2 = 0;

        public static int Host_id2
        {
            get { return frm_RFV.host_id2; }
            set { frm_RFV.host_id2 = value; }
        }

       static string sql = "SELECT "+
                             " DISTINCT req.`ref_no` AS 'Request No' ," +
                             " lpi.`host_org` AS 'LPI'," +
                             " proj.`proj_title`,"+
                             " vol_org.`vol_org_dsc`,"+
                             " vol_org.`vol_org_dsc` AS 'IVSO'," +
                             " req.`date_received`,"+
                             " req.`date_assessed`,"+
                             " req.`date_approved`,"+
                             " req.`date_letter_intent`,"+
                             " req.`date_site_assesment`,"+
                             " req.`date_request_volunteer`"+
                           " FROM"+
                             " `t_request` AS req "+
                             " JOIN `t_request_sub` AS sub "+
                             "   ON sub.`request_id` = req.`request_id` "+
                             " JOIN `t_host_org` AS lpi "+
                             "   ON req.`host_org_id` = lpi.`host_org_id` "+
                             " JOIN `t_project` AS proj "+
                             "   ON req.`project_id` = proj.`project_id` "+
                             " JOIN `t_vol_org` AS vol_org "+
                             "   ON req.`vol_org_id` = vol_org.`vol_org_id` "+
                             " JOIN `t_vol_status` AS vol_status "+
                              "  ON sub.`vol_status_id` = vol_status.`status_id` "+
                              "  JOIN `t_request_status` AS req_stat"+
                              "  ON req.`request_status_id` = req_stat.`request_status_ID`"+
                           " WHERE req.`isActive` = 1 ";

        string sql2 = sql; // temp para sa reuse ng original na sql
        string sql3 = "";

        public frm_RFV()
        {
            InitializeComponent();
            cmbReqStatus.DataSource = DBAccess.populatecmb("sp_populate_cmb_request_status","request_status");
           
        }
        private void frm_RFV_Load(object sender, EventArgs e)
        {
            dgv_RFV.DataSource = DBAccess.dataTableLoad("report_RFV");
            dt2 = DBAccess.dataTableLoad("report_RFV");
            txtReqStatus.Text = "n/a";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql = sql2;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hst_org = txtHostOrg.Text;
            hst_proj = txtProj.Text;
            using (frm_lpi pop = new frm_lpi())
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

        private void button5_Click(object sender, EventArgs e)
        {
            host_id2 = DBAccess.get_data_id(txtHostOrg.Text, "sp_get_host_org_id", "host_org_id");
            hst_proj = txtProj.Text;

            frm_proj_RFV pop = new frm_proj_RFV();

            pop.ShowDialog();
            txtProj.Text = pop.Org;
            if (pop.Org == string.Empty)
            {
                txtProj.Text = hst_proj;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            vol = txtVolOrg.Text;
            using (frm_vol_org pop = new frm_vol_org())
            {
                pop.ShowDialog();
                txtVolOrg.Text = pop.Org;

                if (pop.Org == string.Empty)
                {
                    txtVolOrg.Text = vol;
                }
            }
        }

       

        private void dtReceivedFrom_ValueChanged(object sender, EventArgs e)
        {
            txtReceivedFrom.Text = dtReceivedFrom.Text;
        }

        private void dtReceivedTo_ValueChanged(object sender, EventArgs e)
        {
            txtReceivedTo.Text = dtReceivedTo.Text;
        }

        private void dtAssessedFrom_ValueChanged(object sender, EventArgs e)
        {
            txtAssessedFrom.Text = dtAssessedFrom.Text;
        }

        private void dtAssessedTo_ValueChanged(object sender, EventArgs e)
        {
            txtAssessedTo.Text = dtAssessedTo.Text;
        }

        private void dtApprovedFrom_ValueChanged(object sender, EventArgs e)
        {
            txtApprovedFrom.Text = dtApprovedFrom.Text;

        }

        private void dtApprovedTo_ValueChanged(object sender, EventArgs e)
        {
            txtApprovedTo.Text = dtApprovedTo.Text;
        }

        private void bunifuCustomLabel22_Click(object sender, EventArgs e)
        {

        }

        private void txtvolstatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbVolStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtReqStatus.Text = cmbReqStatus.Text;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            string back_up_file_name = String.Format("{0:MM-dd-yyyy}", DateTime.Now);
            save.FileName = back_up_file_name;
            save.Filter = "Excel(*.xlsx)|*.xlsx";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               reports.ExportToExcel(dt2, save.FileName);
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            string back_up_file_name = String.Format("{0:MM-dd-yyyy}", DateTime.Now);
            save.FileName = back_up_file_name;
            save.Filter = "Pdf(*.pdf)|*.pdf";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                reports.createPDF(dt2, save.FileName);
                MessageBox.Show("Pdf file saved!");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = DBConnection.connection();
            MySqlDataAdapter adp = new MySqlDataAdapter();
            MySqlDataReader reader = null;
            dt = new DataTable();
            sql = sql2;

            int vol_org_id = DBAccess.get_cmb_data(txtVolOrg.Text,
                        "sp_get_vol_org",
                        "vol_org_id");
            int host_org_id = DBAccess.get_cmb_data(txtHostOrg.Text,
                 "sp_get_host_org_id",
                 "host_org_id");
            int proj_id = DBAccess.get_cmb_data(txtProj.Text,
                 "sp_get_project_id",
                 "project_id");
            int req_stat_id = DBAccess.get_cmb_data(cmbReqStatus.Text,
                        "sp_get_cmb_req_status",
                        "request_status_ID");

            if(txtReqStatus.Text != "n/a")
            {
                sql = sql + " AND req.`request_status_id` = @reqStatus ";
                cmd.Parameters.AddWithValue("@reqStatus", req_stat_id );
            }


          //  if (tabControl1.Controls[0] == tabControl1.SelectedTab)
           // {

                if (txtReceivedFrom.Text == string.Empty && txtReceivedTo.Text == string.Empty)
                {
                    error = false;
                   // goto awit;
                }

                else if (txtReceivedFrom.Text != "" && txtReceivedTo.Text == "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (txtReceivedFrom.Text == "" && txtReceivedTo.Text != "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (dtReceivedFrom.Value > dtReceivedTo.Value)
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else
                {
                    sql = sql + " AND req.`date_received` BETWEEN @date1 and @date2 ";
                    cmd.Parameters.AddWithValue("@date1",txtReceivedFrom.Text);
                    cmd.Parameters.AddWithValue("@date2", txtReceivedTo.Text);
                    error = false;
                }
           // }
           // if (tabControl1.Controls[1] == tabControl1.SelectedTab)
          //  {
                if (txtAssessedFrom.Text == string.Empty && txtAssessedTo.Text == string.Empty)
                {
                    error = false;
                   // goto awit;
                }

                else if (txtAssessedFrom.Text != "" && txtAssessedTo.Text == "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (txtAssessedFrom.Text == "" && txtAssessedTo.Text != "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (dtAssessedFrom.Value > dtAssessedTo.Value)
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }

                else
                {
                    sql = sql + " AND req.`date_assessed` between @date3 and @date4 ";
                    cmd.Parameters.AddWithValue("@date3", txtAssessedFrom.Text);
                    cmd.Parameters.AddWithValue("@date4", txtAssessedTo.Text);
                    error = false;
                }
          //  }

           // if (tabControl1.Controls[2] == tabControl1.SelectedTab)
           // {
                if (txtApprovedFrom.Text == string.Empty && txtApprovedTo.Text == string.Empty)
                {
                    error = false;
                    //goto awit;
                }

                else if (txtApprovedFrom.Text != "" && txtApprovedTo.Text == "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (txtApprovedFrom.Text == "" && txtApprovedTo.Text != "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (dtApprovedFrom.Value > dtApprovedTo.Value)
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);

                    error = true;
                    goto finish;
                }
                else
                {
                    sql = sql + " AND req.`date_approved` BETWEEN @date5 and @date6 ";
                    cmd.Parameters.AddWithValue("@date5", txtApprovedFrom.Text);
                    cmd.Parameters.AddWithValue("@date6", txtApprovedTo.Text);
                    error = false;
                }
           // }

            //

           // if (tabControl2.Controls[0] == tabControl1.SelectedTab)
           // {

                if (txtLettetintentFrom.Text == string.Empty && txtLetterIntentTo.Text == string.Empty)
                {
                    error = false;
                  //  goto awit;
                }

                else if (txtLettetintentFrom.Text != "" && txtLetterIntentTo.Text == "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (txtLettetintentFrom.Text == "" && txtLetterIntentTo.Text != "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (dtLettetintentFrom.Value > dtLetterIntentTo.Value)
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else
                {
                    sql = sql + " AND req.`date_letter_intent` BETWEEN @date7 and @date8 ";
                    cmd.Parameters.AddWithValue("@date7", txtLettetintentFrom.Text);
                    cmd.Parameters.AddWithValue("@date8", txtLetterIntentTo.Text);
                    error = false;
                }
           // }
          //  if (tabControl2.Controls[1] == tabControl1.SelectedTab)
          //  {
                if (txtSiteAssestmentFrom.Text == string.Empty && txtSiteAssestmentTo.Text == string.Empty)
                {
                    error = false;
                  //  goto awit;
                }

                else if (txtSiteAssestmentFrom.Text != "" && txtSiteAssestmentTo.Text == "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (txtSiteAssestmentFrom.Text == "" && txtSiteAssestmentTo.Text != "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (dtSiteAssestmentFrom.Value > dtSiteAssestmentTo.Value)
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }

                else
                {
                    sql = sql + " AND req.`date_site_assesment` between @date9 and @date10 ";
                    cmd.Parameters.AddWithValue("@date9", txtSiteAssestmentFrom.Text);
                    cmd.Parameters.AddWithValue("@date10", txtSiteAssestmentTo.Text);
                    error = false;
                }
        //    }

           // if (tabControl2.Controls[2] == tabControl1.SelectedTab)
          //  {
                if (txtRFVFormFrom.Text == string.Empty && txtRFVFormTo.Text == string.Empty)
                {
                    error = false;
                   // goto awit;
                }
                else if (txtRFVFormFrom.Text != "" && txtRFVFormTo.Text == "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (txtRFVFormFrom.Text == "" && txtRFVFormTo.Text != "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (dtRFVFormFrom.Value > dtRFVFormTo.Value)
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else
                {
                    sql = sql + " AND req.`date_approved` BETWEEN @date11 and @date12 ";
                    cmd.Parameters.AddWithValue("@date11", txtRFVFormFrom.Text);
                    cmd.Parameters.AddWithValue("@date12", txtRFVFormTo.Text);
                    error = false;
                }
           // } 

//awit:

            if (txtHostOrg.Text != string.Empty)
            {
                sql = sql + " AND req.`host_org_id` =@hostOrgID";
                cmd.Parameters.AddWithValue("@hostOrgID", host_org_id);
            }

            if (txtProj.Text != string.Empty)
            {
                sql = sql + " AND req.`project_id` =@projID";
                cmd.Parameters.AddWithValue("@projID", proj_id);
            }

            if (txtVolOrg.Text != string.Empty)
            {
                sql = sql + " AND req.`vol_org_id`=@volOrgID";
                cmd.Parameters.AddWithValue("@volOrgID", vol_org_id);
            }

finish:
            cmd.CommandText = sql + "ORDER BY req.`date_created` ";
            sql3 = sql;

            if (error == true)
            {
                dgv_RFV.DataSource = null;
            }
            else
            {
                try
                {
                    reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    dgv_RFV.DataSource = dt;
                    dt2 = dt;

                    logs = new auditTrail(frm_login.UserName, "Generate Reports from RFV Records");
                    DBAccess.insert_logs(logs);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message, "System Error!",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    cmd.Connection.Dispose();
                    reader.Dispose();
                }
            }

        }

        private void dtLettetintentFrom_ValueChanged(object sender, EventArgs e)
        {
            txtLettetintentFrom.Text = dtLettetintentFrom.Text;
        }

        private void dtLetterIntentTo_ValueChanged(object sender, EventArgs e)
        {
            txtLetterIntentTo.Text = dtLetterIntentTo.Text;
        }

        private void dtSiteAssestmentFrom_ValueChanged(object sender, EventArgs e)
        {
            txtSiteAssestmentFrom.Text = dtSiteAssestmentFrom.Text;
        }

        private void dtSiteAssestmentTo_ValueChanged(object sender, EventArgs e)
        {
           txtSiteAssestmentTo.Text =  dtSiteAssestmentTo.Text;
        }

        private void dtRFVFormFrom_ValueChanged(object sender, EventArgs e)
        {
            txtRFVFormFrom.Text = dtRFVFormFrom.Text;
        }

        private void dtRFVFormTo_ValueChanged(object sender, EventArgs e)
        {
            txtRFVFormTo.Text = dtRFVFormTo.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

















//
    }
}
