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
    public partial class frm_LPI_per_region : Form
    {
        public frm_LPI_per_region()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_LPI_per_region_Load(object sender, EventArgs e)
        {
            cmbRegion.DataSource = DBAccess.populatecmb("`sp_populate_cmb_region`", "region_desc");
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtReg.Text = cmbRegion.Text;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int reg = DBAccess.get_cmb_data(txtReg.Text,
                      "sp_get_cmb_region",
                      "region_id");
            reports.LPI_view("report_lpi_per_region", reg);
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            int reg = DBAccess.get_cmb_data(txtReg.Text,
                     "sp_get_cmb_region",
                     "region_id");
            reports.LPI_export("pdf","report_lpi_per_region", reg);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            int reg = DBAccess.get_cmb_data(txtReg.Text,
                     "sp_get_cmb_region",
                     "region_id");
            reports.LPI_export("excel", "report_lpi_per_region", reg);
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            int reg = DBAccess.get_cmb_data(txtReg.Text,
                     "sp_get_cmb_region",
                     "region_id");
            reports.LPI_export("word", "report_lpi_per_region", reg);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



    }
}
