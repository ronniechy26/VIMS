using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class volunteer
    {
        public volunteer() { }

        public volunteer(string _refNo, string _volStatus) 
        {
            Ref_no = _refNo;
            Vol_status = _volStatus;
        }

        public volunteer( string _ref_no, string _vol_name, string _vol_org,
         string _sex, DateTime _birthdate, string _add_no, string _add_st, string _mun_city
           , string _provID, string _regionID, string _email, string _mobile_number, string _date_arrival,
           string _date_departure, string _visa_exp_date, string _passport_exp, string _remarks, string _vol_picture)
        {
            Ref_no = _ref_no;
            Vol_org = _vol_org;
            Vol_name = _vol_name;
            Sex = _sex;
            Birthdate = _birthdate;
            Add_no = _add_no;
            Add_st = _add_st;
            Mun_city = _mun_city;
            Prov_id = _provID;
            Region_id = _regionID;
            Mobile_number = _mobile_number;
            Email = _email;
            Date_arrival = _date_arrival;
            Date_departure = _date_departure;
            Visa_exp_date = _visa_exp_date;
            Passport_exp = _passport_exp;
            Vol_picture = _vol_picture;
            Remarks = _remarks;

        }

        public volunteer(int _ID,string _ref_no, string _vol_name, string _vol_org,
          string _sex, DateTime _birthdate, string _add_no, string _add_st, string _mun_city
            , string _provID, string _regionID, string _email, string _mobile_number, string _date_arrival,
           string _date_departure, string _visa_exp_date, string _passport_exp, string _remarks, string _vol_picture)
        {
            Vol_id = _ID;
            Ref_no = _ref_no;
            Vol_org = _vol_org;
            Vol_name = _vol_name;
            Sex = _sex;
            Birthdate = _birthdate;
            Add_no = _add_no;
            Add_st = _add_st;
            Mun_city = _mun_city;
            Prov_id = _provID;
            Region_id = _regionID;
            Mobile_number = _mobile_number;
            Email = _email;
            Date_arrival = _date_arrival;
            Date_departure = _date_departure;
            Visa_exp_date = _visa_exp_date;
            Passport_exp = _passport_exp;
            Vol_picture = _vol_picture;
            Remarks = _remarks;
            
        }

        public volunteer(int _vol_id, string _ref_no, string _vol_name, string _vol_org,
          string _sex, DateTime _birthdate, string _add_no, string _add_st, string _mun_city
            , string _provID, string _regionID, string _email, string _mobile_number, string _date_arrival,
            string _date_departure, string _visa_exp_date, string _passport_exp, string _remarks, string _vol_picture, DateTime _date_entry) 
        { 
             Vol_id = _vol_id;
             Ref_no = _ref_no;
             Vol_org = _vol_org;
             Vol_name = _vol_name;
             Sex = _sex;
             Birthdate = _birthdate;
             Add_no = _add_no;
             Add_st = _add_st;
             Mun_city = _mun_city;
             Prov_id = _provID;
             Region_id = _regionID;
             Mobile_number = _mobile_number;
             Email = _email;
             Date_arrival = _date_arrival;
             Date_departure = _date_departure;
             Visa_exp_date = _visa_exp_date;
             Passport_exp = _passport_exp;
             Vol_picture = _vol_picture;
             Remarks = _remarks;
             Date_entry = _date_entry;
        }

        private int vol_id = 0;
        private string ref_no = "";
        private string vol_name = "";
        private string vol_org = "";
        private string sex = "";
        private DateTime birthdate;
        private string add_no = "";
        private string add_st = "";
        private string mun_city = "";
        private string prov_id = "";
        private string region_id = "";
        private string mobile_number = "";
        private string email = "";
        private string date_arrival;
        private string date_departure;
        private string visa_exp_date;
        private string passport_exp;
        private string vol_picture;
        private string remarks = "";
        private DateTime date_entry;


        private string vol_status = "";

        public string Vol_status
        {
            get { return vol_status; }
            set { vol_status = value; }
        }



        public DateTime Date_entry
        {
            get { return date_entry; }
            set { date_entry = value; }
        }

        public string Vol_name
        {
            get { return vol_name; }
            set { vol_name = value; }
        }

        public string Ref_no
        {
            get { return ref_no; }
            set { ref_no = value; }
        }
        

        public string Vol_org
        {
            get { return vol_org; }
            set { vol_org = value; }
        }
        

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
      

        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
        

        public string Add_no
        {
            get { return add_no; }
            set { add_no = value; }
        }
        

        public string Add_st
        {
            get { return add_st; }
            set { add_st = value; }
        }
        

        public string Mun_city
        {
            get { return mun_city; }
            set { mun_city = value; }
        }
       

        public string Prov_id
        {
            get { return prov_id; }
            set { prov_id = value; }
        }
        

        public string Region_id
        {
            get { return region_id; }
            set { region_id = value; }
        }
        

        public string Mobile_number
        {
            get { return mobile_number; }
            set { mobile_number = value; }
        }
        

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public string Date_arrival
        {
            get { return date_arrival; }
            set { date_arrival = value; }
        }


        public string Date_departure
        {
            get { return date_departure; }
            set { date_departure = value; }
        }


        public string Visa_exp_date
        {
            get { return visa_exp_date; }
            set { visa_exp_date = value; }
        }


        public string Passport_exp
        {
            get { return passport_exp; }
            set { passport_exp = value; }
        }
        

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
       public string Vol_picture
        {
            get { return vol_picture; }
            set { vol_picture = value; }
        }
        
        public int Vol_id
        {
            get { return vol_id; }
            set { vol_id = value; }
        }
    
    }//
 }
