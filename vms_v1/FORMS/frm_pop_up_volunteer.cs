using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.CLASS;


namespace vms_v1.FORMS
{
    
    public partial class frm_pop_up_volunteer : Form
    {
        volunteer vol = null;

        private string ref_no = "";

        public string Ref_no
        {
            get { return ref_no; }
            set { ref_no = value; }
        }
        private string vol_name = "";

        public string Vol_name
        {
            get { return vol_name; }
            set { vol_name = value; }
        }
        private object vol_pic;

        public object Vol_pic
        {
            get { return vol_pic; }
            set { vol_pic = value; }
        }

        public frm_pop_up_volunteer()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frm_pop_up_volunteer_Load(object sender, EventArgs e)
        {
            dgv_vol.DataSource = DBAccess.dataTableLoad("sp_load_pop_up_vol",frm_request.VolOrg);

        }

        private void dgv_vol_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv_vol.CurrentRow.Index;
            string id = dgv_vol.Rows[i].Cells["ref_no"].Value.ToString();
            vol = DBAccess.get_volunteer(id);

            if (vol != null)
            {
                try
                {
                    vol_name = vol.Vol_name;
                    vol_pic = vol.Vol_picture;
                    ref_no = vol.Ref_no;
                    this.Close();
                }
                catch (IndexOutOfRangeException ex)
                {

                    MessageBox.Show(ex.Message, "Incomplete Data!", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Null");
            }
        }

        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {

        }
   
    
    
    
    }//
}
