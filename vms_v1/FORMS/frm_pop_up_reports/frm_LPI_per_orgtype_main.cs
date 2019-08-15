using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using vms_v1.REPORTS;



namespace vms_v1.FORMS.frm_pop_up_reports
{
    public partial class frm_LPI_per_orgtype_main : Form
    {
        public frm_LPI_per_orgtype_main()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int host_main = DBAccess.get_cmb_data(txtOrgtype.Text,
                          "sp_get_cmb_host_org_type_main",
                          "host_org_type_id");
            reports.LPI_view("report_LPI_per_orgtype_main", host_main);
        }

        private void frm_LPI_per_orgtype_main_Load(object sender, EventArgs e)
        {
            cmbOrgtype.DataSource = DBAccess.populatecmb("`sp_populate_cmb_host`", "host_org_type");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbOrgtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOrgtype.Text = cmbOrgtype.Text;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            int host_main = DBAccess.get_cmb_data(txtOrgtype.Text,
                          "sp_get_cmb_host_org_type_main",
                          "host_org_type_id");
            reports.LPI_export("pdf","report_LPI_per_orgtype_main", host_main);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            int host_main = DBAccess.get_cmb_data(txtOrgtype.Text,
                          "sp_get_cmb_host_org_type_main",
                          "host_org_type_id");
            reports.LPI_export("excel", "report_LPI_per_orgtype_main", host_main);
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            int host_main = DBAccess.get_cmb_data(txtOrgtype.Text,
                          "sp_get_cmb_host_org_type_main",
                          "host_org_type_id");
            reports.LPI_export("word", "report_LPI_per_orgtype_main", host_main);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
