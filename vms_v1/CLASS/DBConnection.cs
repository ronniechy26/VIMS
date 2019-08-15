using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;


namespace vms_v1.CLASS
{
    class DBConnection
    {
        public static string servername = Functions.GetSettingItem(Application.StartupPath +
                @"\\Settings.ini", "Servername");
        public static string username = Functions.GetSettingItem(Application.StartupPath +
                 @"\\Settings.ini", "Username");
        public static string password = Functions.GetSettingItem(Application.StartupPath +
                 @"\\Settings.ini", "Password");
        public static string databasename = Functions.GetSettingItem(Application.StartupPath +
                 @"\\Settings.ini", "Databasename");

        public static MySqlConnection connection()
        {
            MySqlConnection con = new MySqlConnection();

            if (con.State != ConnectionState.Open)
            {
                string constr = "server=" + servername + ";user id= "
                    + username + ";password=" + password + ";database=" + databasename + "";
                try
                {
                    con.ConnectionString = constr;
                    con.Open();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show(e.Message, "System Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return con;
        }

       
    }
}
