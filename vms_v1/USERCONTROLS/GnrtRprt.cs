using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using vms_v1.FORMS.frm_pop_up_reports;
using vms_v1.FORMS;


namespace vms_v1.USERCONTROLS
{
    public partial class GnrtRprt : UserControl
    {
        public GnrtRprt()
        {
            InitializeComponent();
        }
        private void GnrtRprt_Load(object sender, EventArgs e)
        {

        }

        private void lklLPI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_LPI_per_region().ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reports.LPI_view("report_lpi_all");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_LPI_per_province().ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_LPI_per_orgtype_main().ShowDialog();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_volunteer_act_().ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_RFV().ShowDialog();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reports.vol_ivso("report_vol_ivso");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reports.vol_sex("report_vol_sex");
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reports.vol_age("`report_vol_age_range`");
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reports.vol_sector("`report_vol_sector`");
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reports.vol_lpi_type("report_vol_lpi_type");
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reports.vol_reg("report_vol_reg");
        }
    }
}
