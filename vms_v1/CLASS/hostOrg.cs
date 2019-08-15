using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class hostOrg
    {
        public hostOrg() { }
        //public hostOrg(
        //    int _host_id,
        //    string _host_org,
        //    string _head_name,
        //    string _title,
        //    string _address1,
        //    string _address2,
        //    string _city,
        //    string _tel_number1,
        //    string _tel_number2,
        //    string _fax_number,
        //    string _email,
        //    string _website,
        //    string _mandate,
        //    string _province,
        //    string _region,
        //    string _host_org_type_sub,
        //    string _host_org_type
        //    )
        //{
        //    host_id = _host_id;
        //    host_org_name = _host_org;
        //    head_name = _head_name;
        //    title = _title;
        //    address1 = _address1;
        //    address2 = _address2;
        //    city = _city;
        //    tel_number1 = _tel_number1;
        //    tel_number2 = _tel_number2;
        //    fax_number = _fax_number;
        //    email = _email;
        //    website = _website;
        //    mandate = _mandate;
        //    province = _province;
        //    region = _region;
        //    host_org_type_sub = _host_org_type_sub;
        //    host_org_type = _host_org_type;


        //}
        public hostOrg(
            int _host_id,
            string _host_org,
            string _head_name, 
            string _title,
            string _address1, 
            string _address2, 
            string _city,
            string _tel_number1, 
            string _tel_number2,
            string _fax_number, 
            string _email, 
            string _website,
            string _mandate,
            string _province,
            string _region,
            string _host_org_type_sub,
            string _host_org_type
          )
        {
            Host_id = _host_id;
            Host_org_name = _host_org;
            Head_name = _head_name;
            Title = _title;
            Address1 = _address1;
            Address2 = _address2;
            City = _city;
            Tel_number1 = _tel_number1;
            Tel_number2 = _tel_number2;
            Fax_number = _fax_number;
            Email = _email;
            Website = _website;
            Mandate = _mandate;
            Province = _province;
            Region = _region;
            Host_org_type_sub = _host_org_type_sub;
            Host_org_type = _host_org_type;

        }

        //add
        public hostOrg(
            string _host_org, 
            string _head_name, 
            string _title,
            string _address1, 
            string _address2,
            string _city, 
            string _tel_number1,
            string _tel_number2,
            string _fax_number, 
            string _email, 
            string _website, 
            string _mandate, 
            string _province,
            string _region, 
            string _host_org_type_sub, 
            string _host_org_type
          )
        {
            Host_org_name = _host_org;
            Head_name = _head_name;
            Title = _title;
            Address1 = _address1;
            Address2 = _address2;
            City = _city;
            Tel_number1 = _tel_number1;
            Tel_number2 = _tel_number2;
            Fax_number = _fax_number;
            Email = _email;
            Website = _website;
            Mandate = _mandate;
            Province = _province;
            Host_org_type_sub = _host_org_type_sub;
            Region = _region;
            Host_org_type = _host_org_type;
           

        }
        private string host_org_name = "";
        private int host_id = 0;
        private string head_name = "";
        private string title = "";
        private string address2 = "";
        private string address1 = "";
        private string tel_number1 = "";
        private string city = "";
        private string fax_number = "";
        private string host_org_type_sub = "";
        private string email = "";
        private string tel_number2 = "";
        private string website = "";
        private string host_org_type = "";
        private string province = "";
        private string mandate = "";
        private string region = "";
        private DateTime dateEntry;




        public DateTime DateEntry
        {
            get { return dateEntry; }
            set { dateEntry = value; }
        }


        public int Host_id
        {
            get { return host_id; }
            set { host_id = value; }
        }

        public string Host_org_name
        {
            get { return host_org_name; }
            set { host_org_name = value; }
        }
       

        public string Head_name
        {
            get { return head_name; }
            set { head_name = value; }
        }
       

        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }
     

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }
    

        public string City
        {
            get { return city; }
            set { city = value; }
        }
     

        public string Tel_number1
        {
            get { return tel_number1; }
            set { tel_number1 = value; }
        }
      

        public string Tel_number2
        {
            get { return tel_number2; }
            set { tel_number2 = value; }
        }
   

        public string Fax_number
        {
            get { return fax_number; }
            set { fax_number = value; }
        }
      

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
       

        public string Website
        {
            get { return website; }
            set { website = value; }
        }
   

        public string Mandate
        {
            get { return mandate; }
            set { mandate = value; }
        }
       

        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        

        public string Host_org_type_sub
        {
            get { return host_org_type_sub; }
            set { host_org_type_sub = value; }
        }
       

        public string Host_org_type
        {
            get { return host_org_type; }
            set { host_org_type = value; }
        }

       
        public string Region
        {
            get { return region; }
            set { region = value; }
        }

    }
}
