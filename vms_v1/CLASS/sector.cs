using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class sector
    {
        public sector(int _id,string _name)
        {
            Id = _id;
            Name = _name;
        }

        public sector(string _name)
        {
            Name = _name;
        }






        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name = "";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }



    }
}
