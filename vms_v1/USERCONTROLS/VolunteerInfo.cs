using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using vms_v1.CLASS;
using vms_v1.FORMS;
using System.IO;
using MySql.Data.MySqlClient;


namespace vms_v1.USERCONTROLS
{
    public partial class VolunteerInfo : UserControl
    {
        auditTrail logs = null;
        volunteer vol = null;
        int i2 = 0;
        string id2 =  "";

        

        public VolunteerInfo()
        {
            InitializeComponent();
            dgv_vol.DataSource = DBAccess.dataTableLoad("`sp_load_volunteer`",1);
        }

        private void VolunteerInfo_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            dgv_vol.DataSource = DBAccess.dataTableLoad("`sp_load_volunteer`",1);
        }

        private void dgv_vol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_vol_CellDoubleClick(object sender, DataGridViewCellEventArgs e) 
        {
            int i = dgv_vol.CurrentRow.Index;
            string id = dgv_vol.Rows[i].Cells["ID"].Value.ToString();
            
            vol = DBAccess.get_volunteer(id);
            frm_volunteer v = new frm_volunteer();

            if (vol != null)
            {
              try
               {
                    v.Id = vol.Vol_id;
                    v.txtRefNo.Text = vol.Ref_no.ToString();
                    v.txtName.Text = vol.Vol_name;
                    v.txtOrganization.Text = vol.Vol_org;
                    v.cmbSex.Text = vol.Sex;
                    v.dtBday.Value = vol.Birthdate;
                    v.txtAddressNo.Text = vol.Add_no;
                    v.txtAddressStreet.Text = vol.Add_st;
                    v.txtAddressCity.Text = vol.Mun_city;
                    v.cmbRegion.Text = vol.Region_id;
                    v.cmbProvince.Text = vol.Prov_id;
                    v.txtEmail.Text = vol.Email;
                    v.txtMobileNumber.Text = vol.Mobile_number;

                    v.rtbRemarks.Text = vol.Remarks;

                    if (vol.Vol_picture != "") 
                    {
                        try 
                        {
                            v.pbVolunteer.Image = Image.FromFile("" + vol.Vol_picture);
                            v.dest = vol.Vol_picture;
                        }
                        catch(FileNotFoundException ex)
                        {
                            MessageBox.Show("Volunteer Picture not found, Upload a new one! ","Warning!", MessageBoxButtons.OK,
                                                 MessageBoxIcon.Warning);
                        }
                        
                    }

                    v.txtArrival.Text = vol.Date_arrival;
                    v.txtDeparture.Text = vol.Date_departure;
                    v.txtPassport.Text = vol.Passport_exp;
                    v.txtVisa.Text = vol.Visa_exp_date;

                    v.txtbday.Text = vol.Birthdate.ToShortDateString().ToString();
                    v.txtReg.Text = vol.Region_id;
                    v.txtProv.Text= vol.Prov_id;
                    v.txtSex.Text = vol.Sex;
                    v.btnSave.Visible = false;
                    v.lblError.Visible = false;
                  //  v.txtRefNo.Enabled = false;

                  if(frm_login.UserLvl != 2)
                  {
                      v.btnDel.Enabled = false;
                  }
                    v.ShowDialog();   
                }
               catch (IndexOutOfRangeException ex)
                {
                  
                  MessageBox.Show(ex.Message, "Incomplete Data!", MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
               }
            }
            else
            {
                MessageBox.Show("Please click refresh!");
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            frm_volunteer v = new frm_volunteer();
            v.btnUpdate.Visible = false;
            v.btnDel.Visible= false;
            v.btnHistory.Visible = false;
            v.btnDownload.Visible = false;
            v.ActiveControl = v.txtRefNo;
            v.txtRefNo.Focus();
            v.ShowDialog();
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (dgv_vol.RowCount == 0 || id2 == "")
            {
                MessageBox.Show("Nothing to delete!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!DBAccess.find("sp_check_volunteer_before_deleting", id2))
                {
                    MessageBox.Show("Error in deleting Volunteer.The volunteer is currently tag in a request! ", "", MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete this record ID ("
                     + id2 + ")", "Confirm Action",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                     == System.Windows.Forms.DialogResult.Yes)
                    {
                        DBAccess.deleteData("sp_recycle_volunteer_1", id2);
                        dgv_vol.DataSource = DBAccess.dataTableLoad("`sp_load_volunteer`", 1);
                        MessageBox.Show("Successfully deleted!", "Successful!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        logs = new auditTrail(frm_login.UserName, "Deleted Volunteer id " + id2);
                        DBAccess.insert_logs(logs);
                    }
                }
            }


        }

        private void dgv_vol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i2 = dgv_vol.CurrentRow.Index;
            id2 = dgv_vol.Rows[i2].Cells["ID"].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != String.Empty)
            {
                dgv_vol.DataSource = DBAccess.search("SELECT vol.ref_no AS 'ID',vol.vol_name AS 'Volunteer Name',vol.sex AS 'Sex', " +
                "vol_org.vol_org_dsc AS 'Volunteer Organization',CONCAT(vol.add_no, ' ', vol.add_st, ' ', vol.mun_city) AS 'Address' " +
                "FROM `t_volunteer` AS vol JOIN `t_vol_org` AS vol_org ON vol_org.vol_org_id = vol.vol_org " +
                "where vol.isActive = 1 having vol.ref_no LIKE '%" + txtSearch.Text + "%' or " +
                "vol.vol_name LIKE '%" + txtSearch.Text + "%' or " +
                "Address LIKE '%" + txtSearch.Text + "%' or " +
                "vol_org.vol_org_dsc LIKE '%" + txtSearch.Text + "%'  ");
            }
            else
            {
                dgv_vol.DataSource = DBAccess.dataTableLoad("`sp_load_volunteer`", 1);
            }
        }

        private void bunifuMetroTextbox1_OnValueChanged_1(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void bunifuMetroTextbox1_OnValueChanged_2(object sender, EventArgs e)
        {
            if (txtSearch.Text == String.Empty)
            {
                dgv_vol.DataSource = DBAccess.dataTableLoad("`sp_load_volunteer`", 1);
            }
        }













    
    }//
}
