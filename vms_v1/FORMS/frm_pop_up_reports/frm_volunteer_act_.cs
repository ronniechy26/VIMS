using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using vms_v1.FORMS.frm_pop_up_in_rpt_vol_act;
using MySql.Data.MySqlClient;


namespace vms_v1.FORMS.frm_pop_up_reports
{
    public partial class frm_volunteer_act_ : Form
    {
        auditTrail logs = null;
        DataTable dt2 = new DataTable(); //temp para sa fatal error
        public string hst_org = "";
        public string hst_proj = "";
        public string vol = "";
        private static int host_id = 0; //reference id ng host_org para sa pag load ng project
        bool error = false;
            
      static string sql = "SELECT "+
                         "req.`ref_no` AS 'Request No'," +
                         "vol.`vol_name`,"+
                         "lpi.`host_org` AS 'LPI', " +
                         "proj.`proj_title`,"+
                         "vol_org.`vol_org_dsc` AS 'IVSO'," +
                         "sub.`asst_start`, sub.`asst_end`,"+
                         "vol_status.`status_vol`,"+
                         "sec.`sector`,"+
                         "spec.`specialization_dsc`,"+
                         "spec_sub.`specialization_sub_desc`,"+
                         "reg.`region_desc`,"+
                         "prov.`prov_dsc`"+
                      "FROM "+
                         "`t_request_sub` AS sub "+
                         "JOIN `t_request` AS req "+
                         "  ON sub.`request_id` = req.`request_id` "+
                         "JOIN `t_sector` AS sec "+
                         "  ON sub.`sector_id` = sec.`sector_id` "+
                         " JOIN `t_specialization` AS spec "+
                         "   ON sub.`specialization_id` = spec.`specialization_id` "+
                         " JOIN `t_specialization_sub` AS spec_sub "+
                         "   ON sub.`specialization_sub_id` = spec_sub.`specialization_sub_id` "+
                         " JOIN `t_volunteer` AS vol "+
                         "   ON sub.`vol_id` = vol.`vol_id` "+
                         " JOIN `t_host_org` AS lpi "+
                         "   ON req.`host_org_id` = lpi.`host_org_id` "+
                         " JOIN `t_project` AS proj"+
                         "   ON req.`project_id` = proj.`project_id`"+
                         " JOIN `t_vol_org` AS vol_org"+
                         "   ON req.`vol_org_id` = vol_org.`vol_org_id`"+
                         " JOIN `t_vol_status` AS vol_status "+
                         "   ON sub.`vol_status_id` =  vol_status.`status_id`"+
                         " JOIN `t_region` AS reg "+
                         "   ON proj.`region_id` = reg.`region_id` "+
                         " JOIN `t_province` AS prov "+
                         "  ON proj.`prov_id` = prov.`prov_id` "+
                      "WHERE req.`isActive` = 1 ";

        string sql2 = sql; // temp para sa reuse ng original na sql
        string sql3 = "";

        public static int Host_id
        {
            get { return host_id; }
            set { host_id = value; }
        }
        public frm_volunteer_act_()
        {
            InitializeComponent();
        }

        private void frm_volunteer_act__Load(object sender, EventArgs e)
        {
            cmbVolStatus.DataSource = DBAccess.populatecmb("`sp_populate_cmb_vol_status`", "status_vol");
            cmbSector.DataSource = DBAccess.populatecmb("`sp_populate_cmb_sector`", "sector");
            cmbRegion.DataSource = DBAccess.populatecmb("`sp_populate_cmb_region`", "region_desc");
            dgv_vol.DataSource = DBAccess.dataTableLoad("report_1");
            txtsectr.Text = "";
            txtspec.Text = "";
            txtspec_sub.Text = "";
            txtReg.Text = "";
            txtprv.Text = "";
           // dt2 = new DataTable();
            dt2 = DBAccess.dataTableLoad("report_1");
           
        }

        private void txtHostOrg_OnValueChanged(object sender, EventArgs e)
        {

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

        private void cmbVolStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtvolstatus.Text = cmbVolStatus.Text;
        }

        private void dtStartOfAssistance_ValueChanged(object sender, EventArgs e)
        {
            txtFrom.Text = dtStartOfAssistance.Text;
        }

        private void dtEndOfAssistance_ValueChanged(object sender, EventArgs e)
        {
            txtTo.Text = dtEndOfAssistance.Text;
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

        private void button5_Click(object sender, EventArgs e)
        {
            host_id = DBAccess.get_data_id(txtHostOrg.Text, "sp_get_host_org_id", "host_org_id");
            hst_proj = txtProj.Text;

            frm_proj pop = new frm_proj();

            pop.ShowDialog();
            txtProj.Text = pop.Org;
            if (pop.Org == string.Empty)
            {
                txtProj.Text = hst_proj;
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

            int prov = DBAccess.get_cmb_data(cmbProvince.Text,
                        "sp_get_cmb_province",
                        "prov_id");
            int reg = DBAccess.get_cmb_data(cmbRegion.Text,
                "sp_get_cmb_region",
                "region_id");

            int vol_org_id = DBAccess.get_cmb_data(txtVolOrg.Text,
                        "sp_get_vol_org",
                        "vol_org_id");
            int host_org_id = DBAccess.get_cmb_data(txtHostOrg.Text,
                 "sp_get_host_org_id",
                 "host_org_id");
            int proj_id = DBAccess.get_cmb_data(txtProj.Text,
                 "sp_get_project_id",
                 "project_id");
            int vol_status = DBAccess.get_cmb_data(cmbVolStatus.Text, "sp_get_cmb_vol_status", "status_id");

            int sector = DBAccess.get_cmb_data(cmbSector.Text, "sp_get_cmb_sector", "sector_id");
            int spec;
            int spec_sub;

            if (cmbSpecialization.Text == string.Empty)
            { spec = 106; }
            else
            { spec = DBAccess.get_cmb_data(cmbSpecialization.Text, "sp_get_cmb_specialization", "specialization_id"); }

            if (cmbSpecializationSub.Text == "")
            { spec_sub = 1; }
            else
            { spec_sub = DBAccess.get_cmb_data(cmbSpecializationSub.Text, "`sp_get_cmb_specializationSUB`", "specialization_sub_id"); }
          
            //////

           
            if (tabControl1.Controls[0] == tabControl1.SelectedTab)
            { 

                if (txtInserviceTo.Text == string.Empty && txtInserviceFrom.Text == string.Empty)
                {
                    error = false;
                    goto awit;
                }
              
                else if (txtInserviceFrom.Text != "" && txtInserviceTo.Text == "") 
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (txtInserviceFrom.Text == "" && txtInserviceTo.Text != "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (dtInserviceFrom.Value > dtInserviceTo.Value)
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else 
                {
                    sql = sql + " AND sub.`asst_start` <= @date1 and sub.`asst_end` >= @date2 ";
                    cmd.Parameters.AddWithValue("@date1", txtInserviceTo.Text);
                    cmd.Parameters.AddWithValue("@date2", txtInserviceFrom.Text);
                    error = false;
                }
            }
            if (tabControl1.Controls[1] == tabControl1.SelectedTab)
            {
                if (txtDplymentFrom.Text == string.Empty && txtDplymentTo.Text == string.Empty)
                {
                    error = false;
                    goto awit;
                }
                
                else if (txtDplymentFrom.Text != "" && txtDplymentTo.Text == "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (txtDplymentFrom.Text == "" && txtDplymentTo.Text != "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (dtDplymentFrom.Value > dtDplymentTo.Value)
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }

                else 
                {
                    sql = sql + " AND sub.`asst_start` <= @date1 and sub.`asst_start` >= @date2 ";
                    cmd.Parameters.AddWithValue("@date1", txtDplymentTo.Text);
                    cmd.Parameters.AddWithValue("@date2", txtDplymentFrom.Text);
                    error = false;
                }
            }
            if (tabControl1.Controls[2] == tabControl1.SelectedTab)
            {
                 if (txtEndTo.Text == string.Empty && txtEndFrom.Text == string.Empty)
                {
                    error = false;
                    goto awit;
                }
                
                else if (txtEndTo.Text != "" && txtEndFrom.Text == "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (txtEndTo.Text == "" && txtEndFrom.Text != "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if(dtEndFrom.Value > dtEndTo.Value)
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);

                    error = true;
                    goto finish; 
                }
                else 
                {
                    sql = sql + " AND sub.`asst_end` <= @date1 and sub.`asst_end` >= @date2 ";
                    cmd.Parameters.AddWithValue("@date1", txtEndTo.Text);
                    cmd.Parameters.AddWithValue("@date2", txtEndFrom.Text);
                    error = false;
                }
            } 
           if (tabControl1.Controls[3] == tabControl1.SelectedTab)
            {
                if (txtvolstatus.Text != string.Empty)
                {
                    sql = sql + " AND sub.vol_status_id = @volStatus";
                    cmd.Parameters.AddWithValue("@volStatus", vol_status);
                }


               if (txtFrom.Text == string.Empty && txtTo.Text == string.Empty)
                {
                    error = false;
                    goto awit;
                }
               
                else if (txtFrom.Text != "" && txtTo.Text == "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
                else if (txtFrom.Text == "" && txtTo.Text != "")
                {
                    MessageBox.Show("Incorrect dates", "System Error!",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                    goto finish;
                }
               else if (dtStartOfAssistance.Value > dtEndOfAssistance.Value)
               {
                   MessageBox.Show("Incorrect dates", "System Error!",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                   error = true;
                   goto finish;
               }
                else
                {
                    sql = sql + " AND sub.`asst_start` <= @date1 and sub.`asst_end` >= @date2";
                    cmd.Parameters.AddWithValue("@date1", txtTo.Text);
                    cmd.Parameters.AddWithValue("@date2", txtFrom.Text);
                    error = false;
                }
            }

            awit:

            if(txtHostOrg.Text != string.Empty)
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

            if (txtsectr.Text  != string.Empty)
            {
                sql = sql + " AND sub.`sector_id` =@secID";
                cmd.Parameters.AddWithValue("@secID", sector);
            }

            if (txtspec.Text != string.Empty)
            {
                sql = sql + " AND sub.`specialization_id`=@specID";
                cmd.Parameters.AddWithValue("@specID", spec);
            }

            if (txtspec_sub.Text != string.Empty)
            {
                sql = sql + " AND sub.`specialization_sub_id` =@specSubID";
                cmd.Parameters.AddWithValue("@specSubID", spec_sub);
            }

            if (txtReg.Text != string.Empty)
            {
                sql = sql + " AND proj.`region_id` =@regID";
                cmd.Parameters.AddWithValue("@regID", reg);
            }

            if (txtprv.Text != string.Empty)
            {
                sql = sql + " AND proj.`prov_id` = @provID";
                cmd.Parameters.AddWithValue("@provID", prov);
            }



        finish:

            cmd.CommandText = sql + " ORDER BY sub.date_entry DESC";
            sql3 = sql;

            if (error == true)
            {
                dgv_vol.DataSource = null;
            }
            else
            {
                try
                {
                    reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    dgv_vol.DataSource = dt;
                    dt2 = dt;

                    logs = new auditTrail(frm_login.UserName, "Generate Reports from Volunteer Activities ");
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
                }
            }
  
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

        private void button2_Click(object sender, EventArgs e)
        {
            sql = sql2;
            this.Close();
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

        private void cmbSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSpecializationSub.Text = string.Empty;
            txtspec_sub.Text = string.Empty;
            cmbSpecializationSub.DataSource = DBAccess.populatecmb(cmbSpecialization.Text, cmbSector.Text,
                "sp_populate_cmb_specialization_sub", "specialization_sub_desc");
            txtspec.Text = cmbSpecialization.Text;
        }

        private void cmbSpecializationSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtspec_sub.Text = cmbSpecializationSub.Text;
        }

        private void dtInserviceFrom_ValueChanged(object sender, EventArgs e)
        {
            txtInserviceFrom.Text = dtInserviceFrom.Text;

        }

        private void dtInserviceTo_ValueChanged(object sender, EventArgs e)
        {
            txtInserviceTo.Text = dtInserviceTo.Text;
        }

        private void dtDplymentFrom_ValueChanged(object sender, EventArgs e)
        {
            txtDplymentFrom.Text = dtDplymentFrom.Text;
        }

        private void dtDplymentTo_ValueChanged(object sender, EventArgs e)
        {
            txtDplymentTo.Text = dtDplymentTo.Text;
        }

        private void dtEndFrom_ValueChanged(object sender, EventArgs e)
        {
            txtEndFrom.Text = dtEndFrom.Text;

        }

        private void dtEndTo_ValueChanged(object sender, EventArgs e)
        {
            txtEndTo.Text = dtEndTo.Text;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            string back_up_file_name = String.Format("{0:MM-dd-yyyy}", DateTime.Now);
            save.FileName = back_up_file_name;
            save.Filter = "Pdf(*.pdf)|*.pdf";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                reports.createPDF(dt2,save.FileName);
                MessageBox.Show("Pdf file saved!");
            }
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProvince.DataSource = DBAccess.populatecmb(cmbRegion.Text, "sp_populate_cmb_province", "prov_dsc");
            txtReg.Text = cmbRegion.Text;
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtprv.Text = cmbProvince.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }





  //
    }
}
