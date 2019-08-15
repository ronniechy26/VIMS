using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class history
    {
        public history() { }

        public history(string _lpiname,
                       string _projectName,
                       string _reqNO
            )
        {
            LPIName1 = _lpiname;
            ProjectName = _projectName;
            ReqNo = _reqNO;
        }

        public history(string _volname,
                       string _ivso,
                       string _projectname,
                       string _reqNO
            )
        {
            VolName = _volname;
            Ivso = _ivso;
            ProjectName = _projectname;
            ReqNo = _reqNO;
        }



        private string LPIName = "";

        public string LPIName1
        {
            get { return LPIName; }
            set { LPIName = value; }
        }
        private string projectName = "";

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private string reqNo = "";

        public string ReqNo
        {
            get { return reqNo; }
            set { reqNo = value; }
        }
        private string volName = "";

        public string VolName
        {
            get { return volName; }
            set { volName = value; }
        }

        private string ivso = "";

        public string Ivso
        {
            get { return ivso; }
            set { ivso = value; }
        }


    }
}
