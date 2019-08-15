using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;
using vms_v1.USERCONTROLS;
using MySql.Data.MySqlClient;
using System.IO;
using Bunifu.Framework.UI;


namespace vms_v1.FORMS
{
    public partial class frm_volunteer : Form
    {
        string picturePathUponUploading = ""; //path nung picture pag click mo nung upload
        string path = ""; // path nung pinaka directory (initial directory) ung nsa settings.ini
        public string dest = ""; //path kasama na ung file name nung bagong picture (full path)
        string destForDelete = ""; // temp ng dest para makuha ung old picture for deletion
 
        auditTrail logs = null;

        private int id = 0;
        volunteer vol = null;
        public string vol_ = "";
        string ref_no = "";


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       
        public frm_volunteer()
        {
            InitializeComponent();
            cmbRegion.DataSource = DBAccess.populatecmb("`sp_populate_cmb_region`", "region_desc");
        }
        private void frm_volunteer_Load(object sender, EventArgs e)
        {
            destForDelete = dest;
            ref_no = txtRefNo.Text;

        }
        private void bunifuCustomLabel17_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pbVolunteer.Image.Dispose();
                picturePathUponUploading = opf.FileName;
                pbVolunteer.Image = Image.FromFile(opf.FileName);
            }
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProvince.DataSource = DBAccess.populatecmb(cmbRegion.Text, "sp_populate_cmb_province", "prov_dsc");
            txtReg.Text = cmbRegion.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vol_ = txtOrganization.Text;
            using (frm_pop_up_org pop = new frm_pop_up_org())
            {
                pop.ShowDialog();
                txtOrganization.Text = pop.Org;
                if(pop.Org == string.Empty)
                {
                    txtOrganization.Text = vol_;
                }
            }
        }

        private bool check() 
        {
            if (Functions.checkSpace(txtName.Text,txtRefNo.Text,txtbday.Text,txtOrganization.Text)) 
            {
                return true;
            }
            return false;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (lblError.Visible == true)
            {
                MessageBox.Show("Error in updating Volunteer Info!", "Error!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else if (check() == true) 
            {
                MessageBox.Show("Please input all required fields! (If not applicable please indicate n/a)", "Error!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else if (id == 0) { MessageBox.Show("Bug in raw ID! hindi nakuha ung raw Id sa pag double click sa datatable Volunteer"); }
            else
            {
                try
                {
                    if (picturePathUponUploading != "")
                    {
                        try
                        {
                            path = Functions.GetSettingItem(Application.StartupPath + @"\\Settings.ini", "volPicturePath");
                            dest = path + Functions.generateRandomString() + Path.GetExtension(picturePathUponUploading);
                            File.Copy(picturePathUponUploading, dest);

                            try { File.Delete(destForDelete); }catch(Exception ex){}
                        }
                        catch (Exception ex) 
                        {
                            flag = true;
                            MessageBox.Show(ex.Message);
                            goto awit;
                        }
                    }

                    int prov = DBAccess.get_cmb_data(cmbProvince.Text,
                        "sp_get_cmb_province",
                        "prov_id");
                    int reg = DBAccess.get_cmb_data(cmbRegion.Text,
                        "sp_get_cmb_region",
                        "region_id");
                    int org = DBAccess.get_cmb_data(txtOrganization.Text,
                         "sp_get_vol_org",
                         "vol_org_id");

                    vol = new volunteer(id,
                        txtRefNo.Text.Trim(), 
                        txtName.Text.Trim(),
                        org.ToString(),
                        cmbSex.Text.Trim(),
                        Convert.ToDateTime(txtbday.Text.Trim()),
                        txtAddressNo.Text.Trim(),
                        txtAddressStreet.Text.Trim(),
                        txtAddressCity.Text.Trim(),
                        prov.ToString(),
                        reg.ToString(),
                        txtEmail.Text.Trim(),
                        txtMobileNumber.Text.Trim(),
                        txtArrival.Text.Trim(),
                        txtDeparture.Text.Trim(),
                        txtVisa.Text.Trim(),
                        txtPassport.Text.Trim(),
                        rtbRemarks.Text.Trim(),
                        dest
                        );

                    DBAccess.update_volunteer(vol);
                    

                    logs = new auditTrail(frm_login.UserName, "Updated Volunteer id " + txtRefNo.Text);
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Updated!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    awit:
                    
                    if(flag == false)
                    {
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (DBAccess.find("sp_check_id_volunteer",txtRefNo.Text))
            {
                MessageBox.Show("Error in saving Volunteer Info!", "", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (check() == true)
            {
                MessageBox.Show("Please input all required fields! (If not applicable please indicate n/a)", "Error!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else 
            {
                try
                {

                    if (picturePathUponUploading != "")
                    {
                        try
                        {
                            path = Functions.GetSettingItem(Application.StartupPath + @"\\Settings.ini", "volPicturePath");
                            dest = path + Functions.generateRandomString() + Path.GetExtension(picturePathUponUploading);
                            File.Copy(picturePathUponUploading, dest, true);
                        }
                        catch (Exception ex)
                        {
                            flag = true;
                            MessageBox.Show(ex.Message);
                            goto awit;
                        }
                    }

                    int prov = DBAccess.get_cmb_data(cmbProvince.Text,
                        "sp_get_cmb_province",
                        "prov_id");
                    int reg = DBAccess.get_cmb_data(cmbRegion.Text,
                        "sp_get_cmb_region",
                        "region_id");
                    int org = DBAccess.get_cmb_data(txtOrganization.Text,
                        "sp_get_vol_org",
                        "vol_org_id");

                    vol = new volunteer(
                        txtRefNo.Text.Trim(),
                        txtName.Text.Trim(),
                        org.ToString(),
                        cmbSex.Text.Trim(),
                        Convert.ToDateTime(txtbday.Text.Trim()),
                        txtAddressNo.Text.Trim(),
                        txtAddressStreet.Text.Trim(),
                        txtAddressCity.Text.Trim(),
                        prov.ToString(), 
                        reg.ToString(),
                        txtEmail.Text.Trim(),
                        txtMobileNumber.Text.Trim(),
                        txtArrival.Text.Trim(),
                        txtDeparture.Text.Trim(),
                        txtVisa.Text.Trim(),
                        txtPassport.Text.Trim(), 
                        rtbRemarks.Text,
                        dest
                        );

                    DBAccess.insert_volunteer(vol);

                    MessageBox.Show("Successfully Added!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    logs = new auditTrail(frm_login.UserName, "added Volunteer");

                    DBAccess.insert_logs(logs);
                awit:

                    if (flag == false)
                    {
                        this.Close();
                    }

                }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }

            }
           
        }

        private void cmbSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSex.Text = cmbSex.Text;
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProv.Text = cmbProvince.Text;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (id != 0 && DBAccess.find("sp_check_volunteer_before_deleting", txtRefNo.Text))
            {
                if (MessageBox.Show("Are you sure you want to Delete this ref No.  "
                                         + txtRefNo.Text, "Confirm Action",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                         == System.Windows.Forms.DialogResult.Yes)
                {
                    DBAccess.deleteData("sp_delete_volunteer", id);
                 

                    logs = new auditTrail(frm_login.UserName, "Deleted Volunteer id " + txtRefNo.Text);
                    DBAccess.insert_logs(logs);

                    MessageBox.Show("Successfully Deleted!", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Error in deleting Volunteer.The volunteer is currently tag in a request! ", "", MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation);
            }
        }

        private void txtRefNo_OnValueChanged(object sender, EventArgs e)
        {
            if (ref_no == txtRefNo.Text.Trim())
            {
                lblError.Visible = false;
            }
            else if (DBAccess.find("sp_check_id_volunteer",txtRefNo.Text))
            {
                lblError.Visible = true;
            }
            else 
            { 
                lblError.Visible = false; 
            }
        }
        private void dtBday_ValueChanged(object sender, EventArgs e)
        {
            txtbday.Text = dtBday.Value.ToShortDateString().ToString();
        }

        private void dtArrival_date_ValueChanged(object sender, EventArgs e)
        {
            txtArrival.Text = dtArrival_date.Text;
        }

        private void dtDeparture_ValueChanged(object sender, EventArgs e)
        {
            txtDeparture.Text = dtDeparture.Text; 
        }

        private void dtPassport_ValueChanged(object sender, EventArgs e)
        {
            txtPassport.Text = dtPassport.Text; 
        }

        private void dtVisa_ValueChanged(object sender, EventArgs e)
        {
            txtVisa.Text = dtVisa.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            string back_up_file_name = String.Format(txtName.Text + " {0:MM-dd-yyyy}", DateTime.Now);
            save.FileName = back_up_file_name;
            save.Filter = "Jpeg(*.Jpg)|*.jpg;|Bmp(*.bmp)|*.BMP;|PNG(*.png)|*.png";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                if (Path.GetExtension(dest) == ".jpg" || Path.GetExtension(dest) == ".JPG") 
                {
                    pbVolunteer.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("Image Successfully saved!", "", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                }
                else if (Path.GetExtension(dest) == ".png" || Path.GetExtension(dest) == ".PNG") 
                {
                    pbVolunteer.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Image Successfully saved!", "", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                }
                else if (Path.GetExtension(dest) == ".bmp" || Path.GetExtension(dest) == ".BMP")
                {
                    pbVolunteer.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    MessageBox.Show("Image Successfully saved!", "", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                }
                else if (Path.GetExtension(dest) == ".gif" || Path.GetExtension(dest) == ".GIF")
                {
                    pbVolunteer.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                    MessageBox.Show("Image Successfully saved!", "", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("bugs " + dest);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            BunifuMetroTextbox txt = (BunifuMetroTextbox)sender;
            txt.Text = Functions.toTitleCase(txt);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            frm_volunteer_hstry hstry = new frm_volunteer_hstry();
            hstry.Ref_no = txtRefNo.Text;
            hstry.ShowDialog();
        }
       




        //
    }
}
