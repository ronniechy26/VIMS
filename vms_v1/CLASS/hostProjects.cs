using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class hostProjects
    {
        public hostProjects() {}

        public hostProjects(
         string _host_org_id, string _proj_title, string _proj_mgr, string _proj_duration,
                string _proj_address_no, string _proj_address_street, string _mun_city, string _prov_id, string _region_id, string _bugdet,
                string _source_fund, string _objective, string _date_start, string _target_benificiaries, string _position, string _cntactNo)
        {
            Host_org_id = _host_org_id;
            Proj_title = _proj_title;
            Proj_mgr = _proj_mgr;
            Proj_duration = _proj_duration;
            Proj_address_no = _proj_address_no;
            Proj_address_street = _proj_address_street;
            Mun_city = _mun_city;
            Prov_id = _prov_id;
            Region_id = _region_id;
            Bugdet = _bugdet;
            Source_fund = _source_fund;
            Objective = _objective;
            Date_start = _date_start;
            Target_benificiaries = _target_benificiaries;
            Coordinator_position = _position;
            ContactNo = _cntactNo;
        }

        public hostProjects(int _proj_id,string _proj_title, string _proj_mgr, string _proj_duration,
            string _proj_address_no, string _proj_address_street, string _mun_city, string _prov_id, string _region_id, string _bugdet,
            string _source_fund, string _objective, string _date_start, string _target_benificiaries,string _position, string _cntactNo
            ) 
        {
            Project_id = _proj_id;
            Proj_title = _proj_title;
            Proj_mgr = _proj_mgr;
            Proj_duration = _proj_duration;
            Proj_address_no = _proj_address_no;
            Proj_address_street = _proj_address_street;
            Mun_city = _mun_city;
            Prov_id = _prov_id;
            Region_id = _region_id;
            Bugdet = _bugdet;
            Source_fund = _source_fund;
            Objective = _objective;
            Date_start = _date_start;
            Target_benificiaries = _target_benificiaries;
            Coordinator_position = _position;
            ContactNo = _cntactNo;
        }

        public hostProjects(int _proj_id, string _host_org_id, string _proj_title, string _proj_mgr, string _proj_duration,
            string _proj_address_no, string _proj_address_street, string _mun_city, string _prov_id, string _region_id, string _bugdet,
            string _source_fund, string _objective, string _date_start,DateTime _date_created, string _target_benificiaries,string _position, string _cntactNo) 
        {
            Project_id = _proj_id;
            Host_org_id = _host_org_id;
            Proj_title = _proj_title;
            Proj_mgr = _proj_mgr;
            Proj_duration = _proj_duration;
            Proj_address_no = _proj_address_no;
            Proj_address_street = _proj_address_street;
            Mun_city = _mun_city;
            Prov_id = _prov_id;
            Region_id = _region_id;
            Bugdet = _bugdet;
            Source_fund = _source_fund;
            Objective = _objective;
            Date_start = _date_start;
            Target_benificiaries = _target_benificiaries;
            Coordinator_position = _position;
            ContactNo = _cntactNo;
        }
     
        private string bugdet = "";
        private string date_start="";
        private string source_fund = "";
        private string prov_id = "";
        private string region_id = "";
        private string proj_address_street = "";
        private string mun_city = "";
        private int project_id = 0;
        private string objective = "";
        private string proj_mgr = "";
        private string proj_title = "";
        private string proj_duration = "";
        private string target_benificiaries = "";
        private string proj_address_no = "";
        private DateTime date_created;
        private string host_org_id = "";
        private string coordinator_position = "";
        private string contactNo = "";



        public string Coordinator_position
        {
            get { return coordinator_position; }
            set { coordinator_position = value; }
        }

      
       
        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }


        public string Host_org_id
        {
            get { return host_org_id; }
            set { host_org_id = value; }
        }
        

        public int Project_id
        {
            get { return project_id; }
            set { project_id = value; }
        }
       

        public string Proj_title
        {
            get { return proj_title; }
            set { proj_title = value; }
        }
       

        public string Proj_mgr
        {
            get { return proj_mgr; }
            set { proj_mgr = value; }
        }
        

        public string Proj_duration
        {
            get { return proj_duration; }
            set { proj_duration = value; }
        }
       

        public string Proj_address_no
        {
            get { return proj_address_no; }
            set { proj_address_no = value; }
        }
        

        public string Proj_address_street
        {
            get { return proj_address_street; }
            set { proj_address_street = value; }
        }
       

        public string Prov_id
        {
            get { return prov_id; }
            set { prov_id = value; }
        }
        

        public string Mun_city
        {
            get { return mun_city; }
            set { mun_city = value; }
        }
        

        public string Region_id
        {
            get { return region_id; }
            set { region_id = value; }
        }
        

        public string Bugdet
        {
            get { return bugdet; }
            set { bugdet = value; }
        }
      

        public string Source_fund
        {
            get { return source_fund; }
            set { source_fund = value; }
        }
        

        public string Objective
        {
            get { return objective; }
            set { objective = value; }
        }
       

        public string Date_start
        {
            get { return date_start; }
            set { date_start = value; }
        }
        
        public DateTime Date_created
        {
            get { return date_created; }
            set { date_created = value; }
        }
       

        public string Target_benificiaries
        {
            get { return target_benificiaries; }
            set { target_benificiaries = value; }
        }
    
    }//
}