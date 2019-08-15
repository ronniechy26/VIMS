using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;

namespace vms_v1.FORMS.frm_pop_up_reports
{
    public partial class frm_LPI_per_province : Form
    {
        public frm_LPI_per_province()
        {
            InitializeComponent();
            cmbRegion.DataSource = DBAccess.populatecmb("`sp_populate_cmb_region`", "region_desc");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProvince.DataSource = DBAccess.populatecmb(cmbRegion.Text, "sp_populate_cmb_province", "prov_dsc");
            txtReg.Text = cmbRegion.Text;
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            txtProv.Text = cmbProvince.Text;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int prov = DBAccess.get_cmb_data(txtProv.Text,
                        "sp_get_cmb_province",
                        "prov_id");
            reports.LPI_view("report_lpi_per_province", prov);
        }

        private void frm_LPI_per_province_Load(object sender, EventArgs e)
        {
            txtProv.Text = cmbProvince.Text;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            int prov = DBAccess.get_cmb_data(txtProv.Text,
                       "sp_get_cmb_province",
                       "prov_id");
            reports.LPI_export("pdf", "report_lpi_per_province", prov);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            int prov = DBAccess.get_cmb_data(txtProv.Text,
                      "sp_get_cmb_province",
                      "prov_id");
            reports.LPI_export("excel", "report_lpi_per_province", prov);
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            int prov = DBAccess.get_cmb_data(txtProv.Text,
                      "sp_get_cmb_province",
                      "prov_id");
            reports.LPI_export("word", "report_lpi_per_province", prov);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
