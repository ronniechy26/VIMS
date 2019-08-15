using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class institutionTypeMain
    {

        public institutionTypeMain(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }

        public institutionTypeMain(string _name)
        {
            Name = _name;
        }


        private int id = 0;
        private string name = "";
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
