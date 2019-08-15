using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class institutionTypeSUB
    {
        public institutionTypeSUB() { }

        public institutionTypeSUB(string _mainType, string _subType,int _isNGO)
        {
            MainType = _mainType;
            SubType = _subType;
            IsNGO = _isNGO;
        }

        public institutionTypeSUB(int _id, string _mainType,string _subType,int _isNGO) 
        {
            Id = _id;
            MainType = _mainType;
            SubType = _subType;
            IsNGO = _isNGO;
        }



        private int isNGO = 0;

        public int IsNGO
        {
            get { return isNGO; }
            set { isNGO = value; }
        }

        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string mainType = "";

        public string MainType
        {
            get { return mainType; }
            set { mainType = value; }
        }
        private string subType = "";

        public string SubType
        {
            get { return subType; }
            set { subType = value; }
        }
    }
}
