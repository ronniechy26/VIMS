using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class extensionVol
    {
        public extensionVol() { }

        public extensionVol(int _id, int _reqSub,string _startDate,string _endDate,string _remarks) 
        {
            Id = _id;
            ReqSub = _reqSub;
            StartDate = _startDate;
            EndDate = _endDate;
            Remarks = _remarks;
        }

        public extensionVol(int _reqSub, string _startDate, string _endDate, string _remarks)
        {
            ReqSub = _reqSub;
            StartDate = _startDate;
            EndDate = _endDate;
            Remarks = _remarks;
        }




        private int reqSub = 0;

        public int ReqSub
        {
            get { return reqSub; }
            set { reqSub = value; }
        }
        
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string startDate = "";

        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        private string endDate = "";

        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        private string remarks = "";

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

    }
}
