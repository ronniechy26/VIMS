using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vms_v1.USERCONTROLS;
using System.Threading;
using MySql.Data.MySqlClient;
using vms_v1.CLASS;
using Tulpep.NotificationWindow;
using System.IO;

namespace vms_v1.FORMS
{
    public partial class frm_dashboard : Form
    {
       public HstOrgnztnInfo h = new HstOrgnztnInfo();
       public VolunteerInfo v = new VolunteerInfo();
       public GnrtRprt g = new GnrtRprt();
       public requestForVolunteer r = new requestForVolunteer();
       public maintenance m = new maintenance();
       int temp = 0;
       int last = 0;

        public frm_dashboard()
        {
            InitializeComponent();
        }

        private void moveSidePanel(Control btn)
        {
            panel4.Top = btn.Top;
            panel4.Height = btn.Height;
        }
        public void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            pnlControl.Controls.Clear();
            pnlControl.Controls.Add(c);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
          //  new loading_().Show();
            moveSidePanel(btnHostOrg);
            AddControlsToPanel(h);
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
          //  new loading_().Show();
            moveSidePanel(btnVolunteer);
            AddControlsToPanel(v);
        }
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
          //  new loading_().Show();
            moveSidePanel(btnReports);
            AddControlsToPanel(g);
        }
        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
          //  new loading_().Show();
            AddControlsToPanel(r);
            moveSidePanel(btnRequest);
        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        { 
           // new loading_().Show();
            AddControlsToPanel(m);
            moveSidePanel(btnMaintenance);
        }
        private void frm_dashboard_Load(object sender, EventArgs e)
        {
            AddControlsToPanel(h);

            lblName.Text = Functions.GetSettingItem(Application.StartupPath + @"\\Settings.ini", "name");

            if (frm_login.UserLvl == 2)
            {
                if (Functions.GetSettingItem(Application.StartupPath + @"\\Settings.ini", "AuditTrail") == "1") 
                {
                    timer1.Start();
                }
                
            }

            if (DBAccess.find("sp_check_notification_for_asst_end") == true) 
            {
                notifyIcon1.ShowBalloonTip(8000, "There is a Volunteer that will end in 7 days",
                    "Please double click this or click show to view!", ToolTipIcon.Info);
                btnNotif.Visible = false;
                btnNotif_red.Visible = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnUserAccount_Click(object sender, EventArgs e)
        {
            new frm_user_account().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            last = temp;
            string[] data = new string[2];
            data = DBAccess.getlatestid("sp_logs_get_latest_id");
            temp = DBAccess.latestid("sp_logs_latestid") + 1;

                if(temp > last)
                {
                    PopupNotifier pop = new PopupNotifier();
                    pop.Image = Properties.Resources.notification;
                    pop.TitleText = "VIMS@pnvsca";
                    pop.ContentText = "\n"+ data[0] + ": " + data[1] + " (" + data[2]+ ")";
                    pop.Delay = 4000;
                    pop.Popup();
                }

                if (DBAccess.find("sp_check_notification_for_asst_end") == true)
                {
                    btnNotif.Visible = false;
                    btnNotif_red.Visible = true;
                }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new frm_notication_table().ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            new frm_notication_table().ShowDialog();
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DBAccess.find("sp_check_notification_for_asst_end") == true)
            {
                new frm_notication_table().ShowDialog();
            }
        }

        private void btnNotif_red_Click(object sender, EventArgs e)
        {
            new frm_notication_table().ShowDialog();
        }




       
    }
}
