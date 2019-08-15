using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using MySql.Data.MySqlClient;
using vms_v1.USERCONTROLS;
using Bunifu.Framework.UI;
using Tulpep.NotificationWindow;


namespace vms_v1.FORMS
{
    public partial class frm_HstOrgnztnInfo : Form
    {
         auditTrail logs = null;

        public MySqlCommand cmd = new MySqlCommand();
        HstOrgnztnInfo h1 = new HstOrgnztnInfo();
        hostOrg hstOrg = new hostOrg();
        public string h_sub = "";
        public string prov = "";

        public frm_HstOrgnztnInfo()
        {
            InitializeComponent();
            cmbOrgtype.DataSource = DBAccess.populatecmb("`sp_populate_cmb_host`", "host_org_type");
            cmbRegion.DataSource = DBAccess.populatecmb("`sp_populate_cmb_region`", "region_desc");
        }
        private void frm_HstOrgnztnInfo_Load(object sender, EventArgs e)
        {
            cmbOrgtypeSub.Text = h_sub;
            cmbProvince.Text = prov;
        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbOrgtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOrgtypeSub.Text = string.Empty;
            txtOrgtypeSub.Text = string.Empty;
            cmbOrgtypeSub.DataSource = DBAccess.populatecmb(cmbOrgtype.Text, "`sp_populate_cmb_host_org`", "host_org_type_sub");
            txtOrgtype.Text = cmbOrgtype.Text;
            txtOrgtypeSub.Text = cmbOrgtypeSub.Text;
        }
        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProvince.DataSource = DBAccess.populatecmb(cmbRegion.Text, "sp_populate_cmb_province", "prov_dsc");
            txtReg.Text = cmbRegion.Text;
        }
        public bool check() 
        {
            if (Functions.checkSpace(txtName.Text,txtOrgtype.Text
                        ))
            { return true;  }

            return false;
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (check()) 
            {
                MessageBox.Show("Please complete required data!",
                    "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                try
                {
                    int prov = DBAccess.get_cmb_data(cmbProvince.Text,
                        "sp_get_cmb_province",
                        "prov_id");
                    int reg = DBAccess.get_cmb_data(cmbRegion.Text,
                        "sp_get_cmb_region",
                        "region_id");
                    int host_sub = DBAccess.get_cmb_data(cmbOrgtypeSub.Text,
                        "sp_get_cmb_host_org_type_sub",
                        "host_org_type_sub_id");
                    int host_main = DBAccess.get_cmb_data(txtOrgtype.Text,
                       "sp_get_cmb_host_org_type_main",
                       "host_org_type_id");

                    hstOrg = new hostOrg(
                            int.Parse(txtid.Text),
                            txtName.Text.Trim(),
                            txtHeadName.Text.Trim(),
                            txtPosition.Text.Trim(),
                            txtAddressNo.Text.Trim(),
                            txtAddressStreet.Text.Trim(),
                            txtAddressCity.Text.Trim(),
                            txtTelNumber1.Text.Trim(),
                            txtTelNumber2.Text.Trim(),
                            txtFaxNumber.Text.Trim(),
                            txtEmail.Text.Trim(),
                            txtWebsite.Text.Trim(),
                            rtbMandate.Text,
                            prov.ToString(),
                            reg.ToString(), 
                            host_sub.ToString(),
                            host_main.ToString()
                            );
                    DBAccess.update_host_org(hstOrg);

                    logs = new auditTrail(frm_login.UserName, "Updated LPI id " + txtid.Text);
                    DBAccess.insert_logs(logs);

                    

                    MessageBox.Show("Successfully updated!", "", MessageBoxButtons.OK,
                          MessageBoxIcon.Information);

                    txtclear();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }
            }
          
        }

        public void txtclear()
        {
           txtOrgtype.Text = "";
           txtOrgtypeSub.Text = "";
           txtProv.Text = "";
           txtReg.Text = "";
           txtName.Text= "";
           txtHeadName.Text = "";
           txtPosition.Text = "";
           txtAddressNo.Text= "";
           txtAddressStreet.Text= "";
           txtAddressCity.Text= "";
           txtTelNumber1.Text= "";
           txtTelNumber2.Text= "";
           txtFaxNumber.Text= "";
           txtEmail.Text= "";
           txtWebsite.Text= "";
           rtbMandate.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (check())
            {
                MessageBox.Show("Please complete required data!",
                    "System Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                try
                {
                    int prov = DBAccess.get_cmb_data(txtProv.Text,
                        "sp_get_cmb_province",
                        "prov_id");
                    int reg = DBAccess.get_cmb_data(txtReg.Text,
                        "sp_get_cmb_region",
                        "region_id");
                    int host_sub = DBAccess.get_cmb_data(txtOrgtypeSub.Text,
                        "sp_get_cmb_host_org_type_sub",
                        "host_org_type_sub_id");
                    int host_main = DBAccess.get_cmb_data(txtOrgtype.Text,
                        "sp_get_cmb_host_org_type_main",
                        "host_org_type_id");

                    hstOrg = new hostOrg(
                            txtName.Text.Trim(),
                            txtHeadName.Text.Trim(),
                            txtPosition.Text.Trim(),
                            txtAddressNo.Text.Trim(),
                            txtAddressStreet.Text.Trim(),
                            txtAddressCity.Text.Trim(),
                            txtTelNumber1.Text.Trim(),
                            txtTelNumber2.Text.Trim(),
                            txtFaxNumber.Text.Trim(),
                            txtEmail.Text.Trim(),
                            txtWebsite.Text.Trim(),
                            rtbMandate.Text,
                            prov.ToString(),
                            reg.ToString(),
                            host_sub.ToString(),
                            host_main.ToString()
                            );
                    DBAccess.insert_host_org(hstOrg);

                    logs = new auditTrail(frm_login.UserName, "Added a LPI");
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
       }

        private void btnProj_Click(object sender, EventArgs e)
        {
          frm_projects f = new frm_projects();
          f.id = Convert.ToInt32(txtid.Text);
          f.txtID.Enabled = false;
          f.ShowDialog();
            
        }

        private void bunifuCustomLabel17_Click(object sender, EventArgs e)
        {
            txtclear();
            this.Hide();
        }

       private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProv.Text = cmbProvince.Text;
        }

        private void cmbOrgtypeSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOrgtypeSub.Text = cmbOrgtypeSub.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReq_Click(object sender, EventArgs e)
        {
            frm_request frm_req = new frm_request();
            string data = DBAccess.get_data_name(int.Parse(txtid.Text), "sp_get_host_org_name", "host_org");
            frm_req.txtHostOrg.Text = data;
            frm_req.btnUpdate.Visible = false;
            frm_req.btnAdd.Enabled = false;
            frm_req.btnDelete.Enabled = false;
            frm_req.btnRef.Enabled = false;
            frm_req.ShowDialog();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            BunifuMetroTextbox txt = (BunifuMetroTextbox)sender;
            txt.Text = Functions.toTitleCase(txt);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            frm_hostOrg_hstry org = new frm_hostOrg_hstry();
            org.Id = int.Parse(txtid.Text);
            org.ShowDialog();
        }

    }//
}
