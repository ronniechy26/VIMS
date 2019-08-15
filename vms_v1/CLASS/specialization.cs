using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class specialization
    {

        public specialization(int _id,string _sector,string _name) 
        {
            Id = _id;
            Sector = _sector;
            Name = _name;
        }
        public specialization(string _sector, string _name)
        {
            Sector = _sector;
            Name = _name;
        }


        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
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
