using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class Ivso
    {
        public Ivso() { }




        public Ivso( string _ivso)
        {

            Ivso1 = _ivso;
        }

        public Ivso(int _id , string _ivso) 
        {
            Id = _id;
            Ivso1 = _ivso;
        }


        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string ivso = "";

        public string Ivso1
        {
            get { return ivso; }
            set { ivso = value; }
        }
    }
}
