using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using vms_v1.CLASS;


namespace vms_v1.CLASS
{
    class DBAccess
    {
        static string key_str = "3r15M15c@l@";
        static MySqlCommand cmd;
        static MySqlDataAdapter adp = new MySqlDataAdapter();

        #region General functions


        public static void setCommand(string cmdtxt)
        {
            cmd = new MySqlCommand(cmdtxt);
            cmd.Connection = DBConnection.connection();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public static string GetColumnValueAsString(MySqlDataReader reader, string colName)
        {
            if (reader[colName] == DBNull.Value)
            {
                return string.Empty;
            }
            else 
            {
                return reader.GetDateTime(colName).ToString("yyyy-MM-dd");
            }     
        }

        public static DataView search(string sql, string tableName)
        {
           DataSet ds = new DataSet();

           try
           {
               adp = new MySqlDataAdapter(sql, DBConnection.connection());
               adp.Fill(ds, tableName);
           }
           catch (Exception ex) { MessageBox.Show(ex.Message); }

           return ds.Tables[tableName].DefaultView;

        }

        public static DataTable search(string sql)
        {
            MySqlCommand cmd2 = new MySqlCommand();
            DataTable dt = new DataTable();
            MySqlDataReader reader = null;

            try
            {
                cmd2.Connection = DBConnection.connection();
                cmd2.CommandText = sql;
                reader = cmd2.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally 
            {
                cmd2.Connection.Dispose();
                reader.Dispose();
                cmd2.Dispose();
            }
            return dt;
        }

        public static DataTable dataTableLoad(string cmdtxt)
        {
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();

            try
            {
                setCommand(cmdtxt);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return dt;
        }

        public static DataTable dataTableLoad(string cmdtxt, int ID)
        {
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                setCommand(cmdtxt);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return dt;
        }

        public static DataTable dataTableLoad(string cmdtxt, string foo)
        {
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                setCommand(cmdtxt);
                cmd.Parameters.AddWithValue("@foo", foo);
                cmd.Parameters["@foo"].MySqlDbType = MySqlDbType.VarChar;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return dt;
        }

        public static int get_data_id(string name, string cmdtxt, string col)
        {
            int id = 0;
            MySqlDataReader reader = null;
            try
            {
                setCommand(cmdtxt);
                cmd.Parameters.AddWithValue("@foo", name);
                cmd.Parameters["@foo"].MySqlDbType = MySqlDbType.VarChar;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader[col]);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "System Error!",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return id;
        }

        public static string get_data_name(int name, string cmdtxt, string col)
        {
            string data = "";

            MySqlDataReader reader = null;
            try
            {
                setCommand(cmdtxt);
                cmd.Parameters.AddWithValue("@ID", name);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = reader[col].ToString();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "System Error!",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return data;
        }

        public static void deleteData(string cmdtxt, int id)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand(cmdtxt);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "System Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }
        }

        public static void deleteData(string cmdtxt, string id)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand(cmdtxt);
                cmd.Parameters.AddWithValue("@ID", id);
                //cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "System Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }
        }

        public static int get_cmb_data(string name, string cmdtxt, string column)
        {
            int data = 0;
            MySqlDataReader reader = null;
            try
            {
                setCommand(cmdtxt);
                cmd.Parameters.AddWithValue("@foo", name);
                cmd.Parameters["@foo"].MySqlDbType = MySqlDbType.VarChar;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = Convert.ToInt32(reader[column]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return data;
        }

        public static List<String> populatecmb(string cmdtxt, string column)
        {
            List<String> list = new List<string>();
            setCommand(cmdtxt);

            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(column));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "System Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }
            return list;
        }
        public static List<String> populatecmb(string i, string cmdtxt, string column)
        {
            List<String> list = new List<String>();
            setCommand(cmdtxt);
            cmd.Parameters.AddWithValue("@foo", i);

            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(column));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "System Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }
            return list;
        }

        public static List<String> populatecmb(string i, string i2, string cmdtxt, string column)
        {
            List<String> list = new List<String>();
            setCommand(cmdtxt);
            cmd.Parameters.AddWithValue("@foo", i);
            cmd.Parameters.AddWithValue("@foo2", i2);

            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(column));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "System Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }
            return list;
        }
        #endregion

        #region HOST org


        public static hostOrg get_host_org(int id)
        {
            hostOrg hstOrg = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_host_org");
                cmd.Parameters.AddWithValue("@orgID", id);
                cmd.Parameters["@orgID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();
               
                if (reader.Read())
                {
                    hstOrg = new hostOrg(
                        Convert.ToInt32(reader["host_org_id"]),
                        reader["host_org"].ToString(),
                        reader["head_name"].ToString(),
                        reader["title"].ToString(),
                        reader["Address1"].ToString(),
                        reader["Address2"].ToString(),
                        reader["mun_city"].ToString(),
                        reader["tel_number1"].ToString(),
                        reader["tel_number2"].ToString(),
                        reader["fax_number"].ToString(),
                        reader["email"].ToString(),
                        reader["website"].ToString(),
                        reader["Mandate"].ToString(),
                        reader["prov_dsc"].ToString(),
                        reader["region_desc"].ToString(),
                        reader["host_org_type_sub"].ToString(),
                        reader["host_org_type"].ToString()
                        
                        );
                }
            }
            catch (Exception e) 
            { 
                MessageBox.Show(e.Message); 
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return hstOrg;
        }

       
        public static void update_host_org(hostOrg h)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("`sp_update_host_org`");
                cmd.Parameters.AddWithValue("@orgID", h.Host_id);
                cmd.Parameters.AddWithValue("@orgName", h.Host_org_name);
                cmd.Parameters.AddWithValue("@orgHeadName", h.Head_name);
                cmd.Parameters.AddWithValue("@orgTitle", h.Title);
                cmd.Parameters.AddWithValue("@orgAddress1", h.Address1);
                cmd.Parameters.AddWithValue("@orgAddress2", h.Address2);
                cmd.Parameters.AddWithValue("@munCity", h.City);
                cmd.Parameters.AddWithValue("@telNumber1", h.Tel_number1);
                cmd.Parameters.AddWithValue("@telNumber2", h.Tel_number2);
                cmd.Parameters.AddWithValue("@faxNumber", h.Fax_number);
                cmd.Parameters.AddWithValue("@orgEmail", h.Email);
                cmd.Parameters.AddWithValue("@orgWebsite", h.Website);
                cmd.Parameters.AddWithValue("@orgMandate", h.Mandate);
                cmd.Parameters.AddWithValue("@provID", int.Parse(h.Province));
                cmd.Parameters.AddWithValue("@regionID", int.Parse(h.Region));
                cmd.Parameters.AddWithValue("@hostSubID", int.Parse(h.Host_org_type_sub));
                cmd.Parameters.AddWithValue("@hostMain", int.Parse(h.Host_org_type));

                cmd.Parameters["@orgID"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void insert_host_org(hostOrg h)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_host_org");
                cmd.Parameters.AddWithValue("@orgName", h.Host_org_name);
                cmd.Parameters.AddWithValue("@orgHeadName", h.Head_name);
                cmd.Parameters.AddWithValue("@orgTitle", h.Title);
                cmd.Parameters.AddWithValue("@orgAddress1", h.Address1);
                cmd.Parameters.AddWithValue("@orgAddress2", h.Address2);
                cmd.Parameters.AddWithValue("@munCity", h.City);
                cmd.Parameters.AddWithValue("@telNumber1", h.Tel_number1);
                cmd.Parameters.AddWithValue("@telNumber2", h.Tel_number2);
                cmd.Parameters.AddWithValue("@faxNumber", h.Fax_number);
                cmd.Parameters.AddWithValue("@orgEmail", h.Email);
                cmd.Parameters.AddWithValue("@orgWebsite", h.Website);
                cmd.Parameters.AddWithValue("@orgMandate", h.Mandate);
                cmd.Parameters.AddWithValue("@provID", int.Parse(h.Province));
                cmd.Parameters.AddWithValue("@regionID", int.Parse(h.Region));
                cmd.Parameters.AddWithValue("@hostSubID", int.Parse(h.Host_org_type_sub));
                cmd.Parameters.AddWithValue("@hostMain", int.Parse(h.Host_org_type));

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }
    #endregion 

        #region HOST_proj

        public static void insert_host_proj(hostProjects h)
        {
           MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_host_proj");
                cmd.Parameters.AddWithValue("@hostOrgID", int.Parse(h.Host_org_id));
                cmd.Parameters.AddWithValue("@projTitle", h.Proj_title);
                cmd.Parameters.AddWithValue("@projMgr", h.Proj_mgr);
                cmd.Parameters.AddWithValue("@projDuration", h.Proj_duration);
                cmd.Parameters.AddWithValue("@projAddressNo", h.Proj_address_no);
                cmd.Parameters.AddWithValue("@projAddressStreet", h.Proj_address_street);
                cmd.Parameters.AddWithValue("@projMunCity", h.Mun_city);
                cmd.Parameters.AddWithValue("@provID", int.Parse(h.Prov_id));
                cmd.Parameters.AddWithValue("@regionID", int.Parse(h.Region_id));
                cmd.Parameters.AddWithValue("@projBudget", h.Bugdet);
                cmd.Parameters.AddWithValue("@projSourceFund", h.Source_fund);
                cmd.Parameters.AddWithValue("@projObjective", h.Objective);
                cmd.Parameters.AddWithValue("@projTargetBeneficiaries", h.Target_benificiaries);
                cmd.Parameters.AddWithValue("@projDateStart",h.Date_start);
                cmd.Parameters.AddWithValue("@projPosition", h.Coordinator_position);
                cmd.Parameters.AddWithValue("@projContactNo", h.ContactNo);
            
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

        }

        public static void update_host_proj(hostProjects h)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("`sp_update_host_project`");
                cmd.Parameters.AddWithValue("@projID", h.Project_id);
                cmd.Parameters.AddWithValue("@projTitle", h.Proj_title);
                cmd.Parameters.AddWithValue("@projMgr", h.Proj_mgr);
                cmd.Parameters.AddWithValue("@projDuration", h.Proj_duration);
                cmd.Parameters.AddWithValue("@projAddressNo", h.Proj_address_no);
                cmd.Parameters.AddWithValue("@projAddressStreet", h.Proj_address_street);
                cmd.Parameters.AddWithValue("@projMunCity", h.Mun_city);
                cmd.Parameters.AddWithValue("@projBudget", h.Bugdet);
                cmd.Parameters.AddWithValue("@projSourceFund", h.Source_fund);
                cmd.Parameters.AddWithValue("@projObjective", h.Objective);
                cmd.Parameters.AddWithValue("@projTargetBeneficiaries", h.Target_benificiaries);
                cmd.Parameters.AddWithValue("@provID", int.Parse(h.Prov_id));
                cmd.Parameters.AddWithValue("@regionID", int.Parse(h.Region_id));
                cmd.Parameters.AddWithValue("@projDateStart", h.Date_start );
                cmd.Parameters.AddWithValue("@projPosition", h.Coordinator_position);
                cmd.Parameters.AddWithValue("@projContactNo", h.ContactNo);
                cmd.Parameters["@projID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static DataTable dtProject(string cmdtxt,int id)
        {
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();
            try
            {
                setCommand(cmdtxt);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return dt;
        }

        
        public static hostProjects get_host_project (int id)
        {
            hostProjects hstProj = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_host_project");
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    hstProj = new hostProjects(
                        Convert.ToInt32(reader["project_id"]),
                        reader["proj_title"].ToString(),
                        reader["proj_mgr"].ToString(),
                        reader["proj_duration"].ToString(),
                        reader["proj_address_no"].ToString(),
                        reader["proj_address_street"].ToString(),
                        reader["mun_city"].ToString(),
                        reader["prov_dsc"].ToString(),
                        reader["region_desc"].ToString(),
                        reader["bugdet"].ToString(),
                        reader["source_fund"].ToString(),
                        reader["objective"].ToString(),
                        reader["date_start"].ToString(),
                        reader["target_benificiaries"].ToString(),
                        reader["proj_position"].ToString(),
                        reader["proj_contactNo"].ToString()
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return hstProj;

        }

        #endregion

        #region volunteer

        public static string vol_check_in_service(string cmdtxt, string foo)
        {
            string data = "";
            setCommand(cmdtxt);
            cmd.Parameters.AddWithValue("@foo", foo);
            MySqlDataReader reader = null;

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = reader[0].ToString();
                }
            }
            catch (MySqlException e)
            {
                // MessageBox.Show(ex.Message, "DBConnection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return data;
        }

        public static void update_volunteer_status_via_delete(string foo)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_vol_status_via_delete_in_request");
                cmd.Parameters.AddWithValue("@foo", foo);
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void update_volunteer_status(volunteer v)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_vol_status_on_req");
                cmd.Parameters.AddWithValue("@foo", v.Vol_status);
                cmd.Parameters.AddWithValue("@refNo", v.Ref_no);
   
                cmd.Parameters["@refNo"].MySqlDbType = MySqlDbType.VarChar;
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

       public static void update_volunteer(volunteer v)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_volunteer");
                cmd.Parameters.AddWithValue("@volID", v.Vol_id);
                cmd.Parameters.AddWithValue("@refNo",v.Ref_no);
                cmd.Parameters.AddWithValue("@volName", v.Vol_name);
                cmd.Parameters.AddWithValue("@volOrg", int.Parse(v.Vol_org));
                cmd.Parameters.AddWithValue("@volSex", v.Sex);
                cmd.Parameters.AddWithValue("@volBday", v.Birthdate);
                cmd.Parameters.AddWithValue("@addNo", v.Add_no);
                cmd.Parameters.AddWithValue("@addSt", v.Add_st);
                cmd.Parameters.AddWithValue("@munCity", v.Mun_city);
                cmd.Parameters.AddWithValue("@provID", int.Parse(v.Prov_id));
                cmd.Parameters.AddWithValue("@regionID", int.Parse(v.Region_id));
                cmd.Parameters.AddWithValue("@volEmail", v.Email);
                cmd.Parameters.AddWithValue("@mobileNumber", v.Mobile_number);
                cmd.Parameters.AddWithValue("@dateArrival", v.Date_arrival);
                cmd.Parameters.AddWithValue("@dateDeparture", v.Date_departure);
                cmd.Parameters.AddWithValue("@dateVisa", v.Visa_exp_date);
                cmd.Parameters.AddWithValue("@datePassport", v.Passport_exp);
                cmd.Parameters.AddWithValue("@volRemarks", v.Remarks);
                cmd.Parameters.AddWithValue("@volPicture", v.Vol_picture);
                cmd.Parameters["@volID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static volunteer get_volunteer(string id)
        {
            volunteer vol = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_volunteer");
                cmd.Parameters.AddWithValue("@refNo", id);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    vol = new volunteer(
                        Convert.ToInt32( reader["vol_id"]),
                        reader["ref_no"].ToString(),
                        reader["vol_name"].ToString(),
                        reader["vol_org_dsc"].ToString(),
                        reader["sex"].ToString(),
                        Convert.ToDateTime(reader["birthdate"]),
                        reader["add_no"].ToString(),
                        reader["add_st"].ToString(),
                        reader["mun_city"].ToString(),
                        reader["prov_dsc"].ToString(),
                        reader["region_desc"].ToString(),
                        reader["email"].ToString(),
                        reader["mobile_number"].ToString(),
                        GetColumnValueAsString(reader,"date_arrival"),
                        GetColumnValueAsString(reader,"date_departure"),
                        GetColumnValueAsString(reader,"visa_exp_date"),
                        GetColumnValueAsString(reader, "passport_exp"),
                        reader["remarks"].ToString(),
                        reader["vol_picture"].ToString()
                        );
                }
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return vol;

        }


        public static void insert_volunteer(volunteer v)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_volunteer");
                cmd.Parameters.AddWithValue("@refNo", v.Ref_no);
                cmd.Parameters.AddWithValue("@volName", v.Vol_name);
                cmd.Parameters.AddWithValue("@volOrg", int.Parse(v.Vol_org));
                cmd.Parameters.AddWithValue("@volSex", v.Sex);
                cmd.Parameters.AddWithValue("@volBday", v.Birthdate);
                cmd.Parameters.AddWithValue("@addNo", v.Add_no);
                cmd.Parameters.AddWithValue("@addSt", v.Add_st);
                cmd.Parameters.AddWithValue("@munCity", v.Mun_city);
                cmd.Parameters.AddWithValue("@provID", int.Parse(v.Prov_id));
                cmd.Parameters.AddWithValue("@regionID", int.Parse(v.Region_id));
                cmd.Parameters.AddWithValue("@volEmail", v.Email);
                cmd.Parameters.AddWithValue("@mobileNumber", v.Mobile_number);
                cmd.Parameters.AddWithValue("@dateArrival", v.Date_arrival);
                cmd.Parameters.AddWithValue("@dateDeparture", v.Date_departure);
                cmd.Parameters.AddWithValue("@dateVisa", v.Visa_exp_date);
                cmd.Parameters.AddWithValue("@datePassport", v.Passport_exp);
                cmd.Parameters.AddWithValue("@volRemarks", v.Remarks);
                cmd.Parameters.AddWithValue("@volPicture", v.Vol_picture);
;
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        #endregion

        #region request

        public static request get_request(string foo)
        {
            request req = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_request");
                cmd.Parameters.AddWithValue("@refNo", foo);
                cmd.Parameters["@refNo"].MySqlDbType = MySqlDbType.VarChar;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    req = new request(
                        Convert.ToInt32(reader["request_id"]),
                        reader["ref_no"].ToString(),
                        reader["duration_vol_assistance"].ToString(),
                        reader["host_org"].ToString(),
                        reader["proj_title"].ToString(),
                        reader["vol_org_dsc"].ToString(),
                        GetColumnValueAsString(reader,"date_received"),
                        GetColumnValueAsString(reader,"date_assessed"),
                        GetColumnValueAsString(reader,"date_approved"),
                        reader["assessed_by"].ToString(),
                        reader["request_status"].ToString(),
                        reader["remarks"].ToString(),
                        GetColumnValueAsString(reader,"date_letter_intent"),
                        GetColumnValueAsString(reader,"date_request_volunteer"),
                        GetColumnValueAsString(reader,"date_site_assesment"),
                        reader["sec_registration"].ToString(),
                        GetColumnValueAsString(reader,"date_app_volorgr"),
                        Convert.ToInt32(reader["complete_requirements"]),
                        GetColumnValueAsString(reader,"date_completion"),
                        reader["requirement_remarks"].ToString()
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return req;
        }



        public static void update_request(request req)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_request");
                cmd.Parameters.AddWithValue("@reqID", req.Id);
                cmd.Parameters.AddWithValue("@refNo", req.RefNo);
                cmd.Parameters.AddWithValue("@duration", req.Duration);
                cmd.Parameters.AddWithValue("@hostOrgID", int.Parse(req.HostOrg));
                cmd.Parameters.AddWithValue("@projID", int.Parse(req.ProjTitle));
                cmd.Parameters.AddWithValue("@volOrgID", int.Parse(req.VolOrg));
                cmd.Parameters.AddWithValue("@dateReceived", req.DateReceived);
                cmd.Parameters.AddWithValue("@dateAssessed", req.DateAssessed);
                cmd.Parameters.AddWithValue("@dateApproved", req.DateApproved);
                cmd.Parameters.AddWithValue("@requestStatusID", int.Parse(req.RequestStatus));
                cmd.Parameters.AddWithValue("@remarksRequest",req.Remarks);
                cmd.Parameters.AddWithValue("@dateLetterIntent", req.LetterOfIntent);
                cmd.Parameters.AddWithValue("@dateRequestVolunteer", req.RVF1);
                cmd.Parameters.AddWithValue("@dateSiteAssesment", req.SiteAssesment);
                cmd.Parameters.AddWithValue("@secRegistration", req.SECRegistration1);
                cmd.Parameters.AddWithValue("@dateAppVolOrg", req.AFVOR1);
                cmd.Parameters.AddWithValue("@completeRequirement", req.CompleteRequirement);
                cmd.Parameters.AddWithValue("@dateCompletion", req.DateOfCompletion);
                cmd.Parameters.AddWithValue("@requirementRemarks", req.RequirementRemarks);
                cmd.Parameters["@reqID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }



        public static void insert_request(request req)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_request");
                cmd.Parameters.AddWithValue("@refNo", req.RefNo);
                cmd.Parameters.AddWithValue("@duration", req.Duration);
                cmd.Parameters.AddWithValue("@hostOrgID", int.Parse(req.HostOrg));
                cmd.Parameters.AddWithValue("@projID", int.Parse(req.ProjTitle));
                cmd.Parameters.AddWithValue("@volOrgID", int.Parse(req.VolOrg));
                cmd.Parameters.AddWithValue("@dateReceived", req.DateReceived);
                cmd.Parameters.AddWithValue("@dateAssessed", req.DateAssessed);
                cmd.Parameters.AddWithValue("@dateApproved", req.DateApproved);
                cmd.Parameters.AddWithValue("@assessedBy", req.AssessedBy);
                cmd.Parameters.AddWithValue("@requestStatusID", int.Parse(req.RequestStatus));
                cmd.Parameters.AddWithValue("@remarksRequest", req.Remarks);
                cmd.Parameters.AddWithValue("@dateLetterIntent", req.LetterOfIntent);
                cmd.Parameters.AddWithValue("@dateRequestVolunteer", req.RVF1);
                cmd.Parameters.AddWithValue("@dateSiteAssesment", req.SiteAssesment);
                cmd.Parameters.AddWithValue("@secRegistration", req.SECRegistration1);
                cmd.Parameters.AddWithValue("@dateAppVolOrg", req.AFVOR1);
                cmd.Parameters.AddWithValue("@completeRequirement", req.CompleteRequirement);
                cmd.Parameters.AddWithValue("@dateCompletion", req.DateOfCompletion);
                cmd.Parameters.AddWithValue("@requirementRemarks", req.RequirementRemarks);

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

        }

        public static int isNGO(string foo)
        {
            int i = 0;
            setCommand("sp_check_isNGO");
            cmd.Parameters.AddWithValue("@foo", foo);
            cmd.Parameters["@foo"].MySqlDbType = MySqlDbType.VarChar;
            MySqlDataReader reader = null;
           try
            {
               reader = cmd.ExecuteReader();
               if(reader.Read())
               {
                   i = Convert.ToInt32(reader["isNGO"]);
               }

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

           return i;
        }

        #endregion

        #region request_sub

        public static requestSub get_request_sub(int subID)
        {
            requestSub req_sub= null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_request_sub");
                cmd.Parameters.AddWithValue("@subID", subID);
                cmd.Parameters["@subID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    req_sub = new requestSub(
                        Convert.ToInt32(reader["request_sub_id"]),
                        Convert.ToInt32(reader["request_id"]),
                        Convert.ToInt32(reader["report_id"]),
                        Convert.ToInt32(reader["vol_id"]),
                        reader["sector"].ToString(),
                        reader["specialization_dsc"].ToString(),
                        reader["specialization_sub_desc"].ToString(),
                        reader["status_vol"].ToString(),
                        reader["ref_no"].ToString(),
                        reader["vol_name"].ToString(),
                        reader["vol_picture"].ToString(),
                        reader["batch_number"].ToString(),
                        GetColumnValueAsString(reader,"asst_start"),
                        GetColumnValueAsString(reader,"asst_end"),
                        GetColumnValueAsString(reader,"report_wfp"),
                        GetColumnValueAsString(reader,"report_placement"),
                        GetColumnValueAsString(reader,"report_initial"),
                        GetColumnValueAsString(reader,"report_annual"),
                        GetColumnValueAsString(reader,"report_end"),
                        reader["act_acomp"].ToString(),
                        reader["issue_concern"].ToString(),
                        reader["recommend"].ToString(),
                        reader["major_outputs"].ToString(),
                        reader["outcomes"].ToString()
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return req_sub;
        }

        public static void update_request_sub(requestSub req_sub)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_request_sub");
                cmd.Parameters.AddWithValue("@subID",req_sub.SubID);
                cmd.Parameters.AddWithValue("@reportID", req_sub.ReportID);
                cmd.Parameters.AddWithValue("@sectorID", int.Parse(req_sub.SectorID));
                cmd.Parameters.AddWithValue("@specializationID", int.Parse(req_sub.SpecializationID));
                cmd.Parameters.AddWithValue("@specializationSubID", int.Parse(req_sub.SpecializationSubID));
                cmd.Parameters.AddWithValue("@batchNumber", req_sub.BatchNumber);
                cmd.Parameters.AddWithValue("@volStatusID", int.Parse(req_sub.VolunteerStatus));
                cmd.Parameters.AddWithValue("@volID", req_sub.VolID);
                cmd.Parameters.AddWithValue("@asstStart", req_sub.StartAssistance);
                cmd.Parameters.AddWithValue("@asstEnd", req_sub.EndAssistance);
                cmd.Parameters.AddWithValue("@rptWFP", req_sub.WFP1);
                cmd.Parameters.AddWithValue("@rptPlacement", req_sub.PlacementRpt);
                cmd.Parameters.AddWithValue("@rptInitial", req_sub.InitialRpt);
                cmd.Parameters.AddWithValue("@rptAnnual", req_sub.AnnualRpt);
                cmd.Parameters.AddWithValue("@rptEndofAssignment", req_sub.EndOfAssignment);
                cmd.Parameters.AddWithValue("@activitiesAndAccmplshmnt", req_sub.ActivitiesAndAccmplsmnt);
                cmd.Parameters.AddWithValue("@issueAndConcern", req_sub.IssueAndConcerns);
                cmd.Parameters.AddWithValue("@majorOutput", req_sub.MajorOutput);
                cmd.Parameters.AddWithValue("@outComes", req_sub.Outcomes);
                cmd.Parameters.AddWithValue("@recommendations", req_sub.Recommendations);
               
                cmd.Parameters["@subID"].MySqlDbType = MySqlDbType.Int32;
                cmd.Parameters["@reportID"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

        }

        public static void insert_request_sub(requestSub req_sub)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_request_sub");
                cmd.Parameters.AddWithValue("@reqID", req_sub.ReqID);
                cmd.Parameters.AddWithValue("@sectorID", int.Parse(req_sub.SectorID));
                cmd.Parameters.AddWithValue("@specializationID", int.Parse(req_sub.SpecializationID));
                cmd.Parameters.AddWithValue("@specializationSubID", int.Parse(req_sub.SpecializationSubID));
                cmd.Parameters.AddWithValue("@batchNumber", req_sub.BatchNumber);
                cmd.Parameters.AddWithValue("@volStatusID", int.Parse(req_sub.VolunteerStatus));
                cmd.Parameters.AddWithValue("@volID", req_sub.VolID);
                cmd.Parameters.AddWithValue("@asstStart", req_sub.StartAssistance);
                cmd.Parameters.AddWithValue("@asstEnd", req_sub.EndAssistance);
                cmd.Parameters.AddWithValue("@rptWFP", req_sub.WFP1);
                cmd.Parameters.AddWithValue("@rptPlacement", req_sub.PlacementRpt);
                cmd.Parameters.AddWithValue("@rptInitial", req_sub.InitialRpt);
                cmd.Parameters.AddWithValue("@rptAnnual", req_sub.AnnualRpt);
                cmd.Parameters.AddWithValue("@rptEndofAssignment", req_sub.EndOfAssignment);
                cmd.Parameters.AddWithValue("@activitiesAndAccmplshmnt", req_sub.ActivitiesAndAccmplsmnt);
                cmd.Parameters.AddWithValue("@issueAndConcern", req_sub.IssueAndConcerns);
                cmd.Parameters.AddWithValue("@majorOutput", req_sub.MajorOutput);
                cmd.Parameters.AddWithValue("@outComes", req_sub.Outcomes);
                cmd.Parameters.AddWithValue("@recommendations", req_sub.Recommendations);

                cmd.Parameters["@reqID"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

        }

        #endregion

        #region login

        //halata namang pang login db ? hahaha
        public static bool find(string cmdtxt, string username,string userpassword)
        {

            setCommand(cmdtxt);
            cmd.Parameters.AddWithValue("@userName", username);
            cmd.Parameters.AddWithValue("@userPassword", userpassword);
            cmd.Parameters.AddWithValue("@key_str", key_str);
            MySqlDataReader reader = null;
            bool check;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    check = true;
                else
                    check = false;
            }
            catch (MySqlException e)
            {
                check = false;
                // MessageBox.Show(ex.Message, "DBConnection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return check;
        }

        public static bool find(string cmdtxt, string foo, string foo2,string user)
        {

            setCommand(cmdtxt);
            cmd.Parameters.AddWithValue("@foo", foo);
            cmd.Parameters.AddWithValue("@foo2", foo2);
            cmd.Parameters.AddWithValue("@userName", user);
            MySqlDataReader reader = null;
            bool check;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    check = true;
                else
                    check = false;
            }
            catch (MySqlException e)
            {
                check = false;
                // MessageBox.Show(ex.Message, "DBConnection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return check;
        }

        public static void update_login_password(loginInformation log_info)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_login_update_password");
                cmd.Parameters.AddWithValue("@userPassword", log_info.Password);
                cmd.Parameters.AddWithValue("@userName", log_info.Username);
                cmd.Parameters.AddWithValue("@key_str", key_str);


                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void update_login_admin(loginInformation log_info)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_login_update_admin");
                cmd.Parameters.AddWithValue("@loginID", log_info.Id);
                cmd.Parameters.AddWithValue("@userRole", log_info.UserLevel);
                cmd.Parameters.AddWithValue("@userStatus", log_info.IsActive);

                cmd.Parameters["@loginID"].MySqlDbType = MySqlDbType.Int32;
                cmd.Parameters["@userRole"].MySqlDbType = MySqlDbType.Int32;
                cmd.Parameters["@userStatus"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void update_login_user(loginInformation log_info)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_login_update_user");
                cmd.Parameters.AddWithValue("@loginID", log_info.Id);
                cmd.Parameters.AddWithValue("@acctName", log_info.UserLoginName);
                cmd.Parameters.AddWithValue("@userName", log_info.Username);
                cmd.Parameters.AddWithValue("@userPassword", log_info.Password);
                cmd.Parameters.AddWithValue("@secretQuestion", log_info.SecretQuestion);
                cmd.Parameters.AddWithValue("@secretAnswer", log_info.SecretAnswer);
                cmd.Parameters.AddWithValue("@secretHint", log_info.HintPassword);
                cmd.Parameters.AddWithValue("@key_str", key_str);

                cmd.Parameters["@loginID"].MySqlDbType = MySqlDbType.Int32;
             
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void insert_login_admin(loginInformation log_info)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_login_insert_account");
                cmd.Parameters.AddWithValue("@userPassword", log_info.Password);
                cmd.Parameters.AddWithValue("@userName", log_info.Username);
                cmd.Parameters.AddWithValue("@userRole", log_info.UserLevel);
                cmd.Parameters.AddWithValue("@userStatus", log_info.IsActive);
                cmd.Parameters.AddWithValue("@key_str", key_str);
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }
          
        public static string get_data_login(string cmdtxt, string username, string userpassword,string tablename)
        {
            string data = "";
            setCommand(cmdtxt);
            cmd.Parameters.AddWithValue("@userName", username);
            cmd.Parameters.AddWithValue("@userPassword", userpassword);
            cmd.Parameters.AddWithValue("@key_str", key_str);
            MySqlDataReader reader = null;

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    data = reader[tablename].ToString();
                }
            }
            catch (MySqlException e)
            {
                // MessageBox.Show(ex.Message, "DBConnection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return data;
        }

        public static loginInformation get_login_info(int id)
        {
            loginInformation log_info = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_login");
                cmd.Parameters.AddWithValue("@loginID", id);
                cmd.Parameters.AddWithValue("@key_str", key_str);
                cmd.Parameters["@loginID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    log_info = new loginInformation(
                        Convert.ToInt32(reader["ID"]),
                        reader["login_userName"].ToString(),
                        reader["login_password"].ToString(),
                        Convert.ToInt32(reader["userLevel"].ToString()),
                        reader["login_name"].ToString(),
                        reader["secret_question"].ToString(),
                        reader["secret_answer"].ToString(),
                        reader["hint"].ToString(),
                        Convert.ToInt32(reader["isActive"].ToString())
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return log_info;
        }

        public static loginInformation get_login_info_by_username(string foo)
        {
            loginInformation log_info = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_login_by_username");
                cmd.Parameters.AddWithValue("@foo", foo);
                cmd.Parameters["@foo"].MySqlDbType = MySqlDbType.VarChar;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    log_info = new loginInformation(
                        Convert.ToInt32(reader["ID"]),
                        reader["login_userName"].ToString(),
                        reader["login_password"].ToString(),
                        Convert.ToInt32(reader["userLevel"].ToString()),
                        reader["login_name"].ToString(),
                        reader["secret_question"].ToString(),
                        reader["secret_answer"].ToString(),
                        reader["hint"].ToString(),
                        Convert.ToInt32(reader["isActive"].ToString())
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return log_info;
        }

        #endregion

        #region ivso


        public static Ivso get_ivso(int ID)
        {
            Ivso i = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_ivso");
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    i = new Ivso(
                        Convert.ToInt32(reader["vol_org_id"]),
                        reader["vol_org_dsc"].ToString()
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return i;
        }

        public static void update_ivso(Ivso iv)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_ivso");
                cmd.Parameters.AddWithValue("@ID", iv.Id);
                cmd.Parameters.AddWithValue("@orgName", iv.Ivso1);

                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void insert_ivso(Ivso iv)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_ivso");
                cmd.Parameters.AddWithValue("@orgName", iv.Ivso1);

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }


        #endregion

        #region institutionTypeMain

        public static void insert_institution_Main(institutionTypeMain iMain)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_institution_Main");
                cmd.Parameters.AddWithValue("@orgTitle", iMain.Name);

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void update_institution_Main(institutionTypeMain iMain)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_institution_Main");
                cmd.Parameters.AddWithValue("@ID", iMain.Id);
                cmd.Parameters.AddWithValue("@orgTitle", iMain.Name);

                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static institutionTypeMain get_institutinMain(int ID)
        {
            institutionTypeMain i = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_institution_main");
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    i = new institutionTypeMain(
                        Convert.ToInt32(reader["host_org_type_id"]),
                        reader["host_org_type"].ToString()
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return i;
        }

        #endregion

        #region insitution type SUB

        public static void insert_institution_Sub(institutionTypeSUB iSub)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_institution_sub");
                cmd.Parameters.AddWithValue("@subName", iSub.SubType);
                cmd.Parameters.AddWithValue("@main", int.Parse(iSub.MainType));
                cmd.Parameters.AddWithValue("@subIsNGO", iSub.IsNGO);

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void update_institution_Sub(institutionTypeSUB iSub)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_institution_Sub");
                cmd.Parameters.AddWithValue("@ID", iSub.Id);
                cmd.Parameters.AddWithValue("@subName", iSub.SubType);
                cmd.Parameters.AddWithValue("@main", int.Parse(iSub.MainType));
                cmd.Parameters.AddWithValue("@subIsNGO", iSub.IsNGO);

                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static institutionTypeSUB get_institutionTypeSUB(int ID)
        {
            institutionTypeSUB i = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_institution_type_Sub");
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    i = new institutionTypeSUB(
                        Convert.ToInt32(reader["host_org_type_sub_id"]),
                        reader["host_org_type"].ToString(),
                        reader["host_org_type_sub"].ToString(),
                        Convert.ToInt32(reader["isNGO"])
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return i;
        }


        #endregion

        #region sector

        public static void insert_sector(sector sec)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_sector");
                cmd.Parameters.AddWithValue("@sectorName", sec.Name);

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void update_sector(sector sec)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_sector");
                cmd.Parameters.AddWithValue("@ID", sec.Id);
                cmd.Parameters.AddWithValue("@sectorName", sec.Name);
      

                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }


        public static sector get_sector(int ID)
        {
            sector i = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_sector");
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    i = new sector(
                        Convert.ToInt32(reader["sector_id"]),
                        reader["sector"].ToString()
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return i;
        }



        #endregion

        #region specialization

        public static void insert_specialization(specialization  spec)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_specialization");
                cmd.Parameters.AddWithValue("@sec", int.Parse(spec.Sector));
                cmd.Parameters.AddWithValue("@specializationDESC", spec.Name);

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void update_specialization(specialization spec)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_specialization");
                cmd.Parameters.AddWithValue("@ID", spec.Id);
                cmd.Parameters.AddWithValue("@specializationDESC", spec.Name);
                cmd.Parameters.AddWithValue("@sec", int.Parse(spec.Sector));

                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static specialization get_specialization(int ID)
        {
            specialization i = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_specialization");
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    i = new specialization(
                        Convert.ToInt32(reader["specialization_id"]),
                       (reader["sector"]).ToString(),
                        reader["specialization_dsc"].ToString()
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return i;

        }


        #endregion

        #region specialization SUB

        public static void insert_specialization_sub(specializationSub sub)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_specialization_sub");
                cmd.Parameters.AddWithValue("@sec", int.Parse(sub.Sector));
                cmd.Parameters.AddWithValue("@specSubDesc", sub.Name);
                cmd.Parameters.AddWithValue("@spec", int.Parse(sub.Specialization));

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void update_specialization_sub(specializationSub sub)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_specialization_sub");
                cmd.Parameters.AddWithValue("@ID", sub.Id);
                cmd.Parameters.AddWithValue("@sec", int.Parse(sub.Sector));
                cmd.Parameters.AddWithValue("@specSubDesc", sub.Name);
                cmd.Parameters.AddWithValue("@spec", int.Parse(sub.Specialization));

                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }


        public static specializationSub get_specialization_sub(int ID)
        {
            specializationSub i = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_specialization_sub");
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    i = new specializationSub(
                        Convert.ToInt32(reader["specialization_sub_id"]),
                        reader["specialization_dsc"].ToString(),
                        reader["sector"].ToString(),
                        reader["specialization_sub_desc"].ToString()
                        );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return i;

        }



        #endregion

        #region extension

        public static void insert_extension(extensionVol ext)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_extension");

                cmd.Parameters.AddWithValue("@subID", ext.ReqSub);
                cmd.Parameters.AddWithValue("@startDate", ext.StartDate);
                cmd.Parameters.AddWithValue("@endDate", ext.EndDate);
                cmd.Parameters.AddWithValue("@remarksExt", ext.Remarks);

                cmd.Parameters["@subID"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }

        public static void update_endAssistance_via_extension(int id,string endDate)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_endOfAssistance_via_extension");
                cmd.Parameters.AddWithValue("@subID", id);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }


        public static void update_extension(extensionVol ext)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_update_extension");
                cmd.Parameters.AddWithValue("@extensionID", ext.Id);
                cmd.Parameters.AddWithValue("@subID", ext.ReqSub);
                cmd.Parameters.AddWithValue("@startDate",ext.StartDate);
                cmd.Parameters.AddWithValue("@endDate", ext.EndDate);
                cmd.Parameters.AddWithValue("@remarksExt", ext.Remarks);

                cmd.Parameters["@extensionID"].MySqlDbType = MySqlDbType.Int32;

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }


        public static extensionVol get_extension(int ID)
        {
            extensionVol ex = null;
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_select_extension");
                cmd.Parameters.AddWithValue("@extensionID", ID);
                cmd.Parameters["@extensionID"].MySqlDbType = MySqlDbType.Int32;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ex = new extensionVol(
                        Convert.ToInt32(reader["extension_id"]),
                        Convert.ToInt32(reader["request_sub_id"]),
                        GetColumnValueAsString(reader,"start_date"),
                       GetColumnValueAsString(reader,"end_date"),
                        reader["remarks"].ToString()
                        );
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }

            return ex;

        }




        #endregion

        #region logs


        public static int latestid(string cmdtxt)
        {
            
            MySqlDataReader reader = null;
            int id = 0;
            try
            {
                setCommand(cmdtxt);
                reader = cmd.ExecuteReader();

                if (reader.Read()) 
                {
                    id = Convert.ToInt32(reader[0]);
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "System Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return id;

        }


        public static string[] getlatestid(string cmdtxt)
        {

            MySqlDataReader reader = null;
            string[] data = new string[3];
            try
            {
                setCommand(cmdtxt);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    data[0] = reader[0].ToString();
                    data[1] = reader[1].ToString();
                    data[2] = reader[2].ToString();
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "System Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return data;

        }

        public static void insert_logs(auditTrail log)
        {
            MySqlDataReader reader = null;
            try
            {
                setCommand("sp_insert_logs");

                cmd.Parameters.AddWithValue("@logname", log.Name);
                cmd.Parameters.AddWithValue("@logAction", log.Action);

                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
        }
        public static DataTable logs(DateTime dt1,DateTime dt2) 
        {
            MySqlDataReader reader = null;
            DataTable dt = new DataTable();

            try
            {
                setCommand("sp_audit_trail");
                cmd.Parameters.AddWithValue("date1", dt1);
                cmd.Parameters.AddWithValue("date2", dt2);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }

            return dt;
        }



        #endregion

        #region excess functions

        public static string findDataSet(String sql)
        {
            string data = "";
            DataSet ds = new DataSet();
            adp = new MySqlDataAdapter(sql, DBConnection.connection());
            adp.Fill(ds);
            data = ds.Tables[0].Rows[0][0].ToString();

            return data;
        }

        public static string findDataSet(String sql, int index)
        {
            string data = "";
            DataSet ds = new DataSet();
            adp = new MySqlDataAdapter(sql, DBConnection.connection());
            adp.Fill(ds);
            data = ds.Tables[0].Rows[0][index].ToString();

            return data;
        }

        public static void update_request_volunteer_status()// para maupdate ung mga finish contract
        {
            setCommand("sp_1");
            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "System Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }
        }

        public static void executecmd(String sql)
        {
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2 = new MySqlCommand();
            cmd2.Connection = DBConnection.connection();
            cmd2.CommandText = sql;

            MySqlDataReader reader = null;
            try
            {
                reader = cmd2.ExecuteReader();
                reader.Read();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "System Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd2.Dispose();
                cmd2.Connection.Dispose();
                reader.Dispose();
            }
        }

        public static bool findAcct(String sql)
        {

            cmd = new MySqlCommand();
            cmd.Connection = DBConnection.connection();
            cmd.CommandText = sql;
            MySqlDataReader reader = null;
            bool check;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    check = true;
                else
                    check = false;
            }
            catch (MySqlException e)
            {
                check = false;
                // MessageBox.Show(ex.Message, "DBConnection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return check;
        }

        //ginamit para sa pagcheck ng data
        public static bool find(string cmdtxt, String foo)
        {

            setCommand(cmdtxt);
            cmd.Parameters.AddWithValue("@foo", foo);
            cmd.Parameters["@foo"].MySqlDbType = MySqlDbType.VarChar;
            MySqlDataReader reader = null;
            bool check;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    check = true;
                else
                    check = false;
            }
            catch (MySqlException e)
            {
                check = false;
                // MessageBox.Show(ex.Message, "DBConnection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return check;
        }

        public static bool find(string cmdtxt, int id)
        {

            setCommand(cmdtxt);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
            MySqlDataReader reader = null;
            bool check;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    check = true;
                else
                    check = false;
            }
            catch (MySqlException e)
            {
                check = false;
                // MessageBox.Show(ex.Message, "DBConnection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return check;
        }

        public static bool find(string cmdtxt)
        {

            setCommand(cmdtxt);
           // cmd.Parameters.AddWithValue("@ID", id);
           // cmd.Parameters["@ID"].MySqlDbType = MySqlDbType.Int32;
            MySqlDataReader reader = null;
            bool check;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    check = true;
                else
                    check = false;
            }
            catch (MySqlException e)
            {
                check = false;
                // MessageBox.Show(ex.Message, "DBConnection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                cmd.Connection.Dispose();
                reader.Dispose();
            }

            return check;
        }

        #endregion


    }
}
