using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class specializationSub
    {

        public specializationSub(int _id,string _specialization,string _sector,string _name)
        {
            Id = _id;
            Specialization = _specialization;
            Sector = _sector;
            Name = _name;
        }


        public specializationSub(string _specialization, string _sector, string _name)
        {
            Specialization = _specialization;
            Sector = _sector;
            Name = _name;
        }


        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string specialization = "";

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }
        private string sector = "";

        public string Sector
        {
            get { return sector; }
            set { sector = value; }
        }
        private string name = "";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

}
