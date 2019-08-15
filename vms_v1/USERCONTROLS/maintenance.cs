using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using vms_v1.FORMS;


namespace vms_v1.USERCONTROLS
{
    public partial class maintenance : UserControl
    {
        public maintenance()
        {
            InitializeComponent();
        }

    

        private void lklLPI_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_recyclebin_hostorg().ShowDialog();
        }

        private void lklVolunteer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_recyclebin_volunteer().ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_recyclebin_request().ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_recyclebin_req_sub().ShowDialog();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_user_management().ShowDialog();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_manage_ivso().ShowDialog();
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_manage_org_type().ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_manage_org_type_SUB().ShowDialog();
        }



        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_manage_sector().ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_manage_specialization().ShowDialog();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_manage_specializationSUB().ShowDialog();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DBAccess.update_request_volunteer_status();
            MessageBox.Show("Database Updated! ", "", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frm_auditTrail().Show();
        }



    }
}
