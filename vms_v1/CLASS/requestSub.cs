using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class requestSub
    {
        public requestSub() { }

        public requestSub(
              
               int _reqID,
               string _sectorID,
               string _specializationID,
               string _specializationSubID,
               string _batchNumber,
               string _volunteerStatus,
               int _volID,
               string _startAssistance,
               string _endAssistance,
               string _WFP,
               string _placementRpt,
               string _initialRpt,
               string _annualRpt,
               string _endOfAssignment,
               string _activitiesAndAccmplsmnt,
               string _issueAndConcerns,
               string _recommendations,
               string _majorOutput,
               string _outcomes
          )
        {

            ReqID = _reqID;
            VolID = _volID;
            SectorID = _sectorID;
            SpecializationID = _specializationID;
            SpecializationSubID = _specializationSubID;
            VolunteerStatus = _volunteerStatus;
            BatchNumber = _batchNumber;
            StartAssistance = _startAssistance;
            EndAssistance = _endAssistance;
            WFP1 = _WFP;
            PlacementRpt = _placementRpt;
            InitialRpt = _initialRpt;
            AnnualRpt = _annualRpt;
            EndOfAssignment = _endOfAssignment;
            ActivitiesAndAccmplsmnt = _activitiesAndAccmplsmnt;
            IssueAndConcerns = _issueAndConcerns;
            Recommendations = _recommendations;
            MajorOutput = _majorOutput;
            Outcomes = _outcomes;

        }





        public requestSub(
                int _subID,
                int _reportID,
                string _sectorID,
                string _specializationID,
                string _specializationSubID,
                string _batchNumber,   
                string _volunteerStatus,
                int _volID,
                string _startAssistance,
                string _endAssistance,
                string _WFP,
                string _placementRpt,
                string _initialRpt,
                string _annualRpt,
                string _endOfAssignment,
                string _activitiesAndAccmplsmnt,
                string _issueAndConcerns,
                string _recommendations,
                string _majorOutput,
                string _outcomes
           )
        {

            SubID = _subID;
            ReportID = _reportID;
            VolID = _volID;
            SectorID = _sectorID;
            SpecializationID = _specializationID;
            SpecializationSubID = _specializationSubID;
            VolunteerStatus = _volunteerStatus;
            BatchNumber = _batchNumber;
            StartAssistance = _startAssistance;
            EndAssistance = _endAssistance;
            WFP1 = _WFP;
            PlacementRpt = _placementRpt;
            InitialRpt = _initialRpt;
            AnnualRpt = _annualRpt;
            EndOfAssignment = _endOfAssignment;
            ActivitiesAndAccmplsmnt = _activitiesAndAccmplsmnt;
            IssueAndConcerns = _issueAndConcerns;
            Recommendations = _recommendations;
            MajorOutput = _majorOutput;
            Outcomes = _outcomes;

        }

        public requestSub(
                 string _sectorID,
                 string _specializationID,
                 string _specializationSubID,
                 string _volunteerStatus,
                 string _volRefno,
                 string _volName,
                 string _volPiture,
                 string _batchNumber,
                 string _startAssistance,
                 string _endAssistance,
                 string _WFP,
                 string _placementRpt,
                 string _initialRpt,
                 string _annualRpt,
                 string _endOfAssignment,
                 string _activitiesAndAccmplsmnt,
                 string _issueAndConcerns,
                 string _recommendations,
                 string _majorOutput,
                 string _outcomes
            )
        {
            SectorID = _sectorID;
            SpecializationID = _specializationID;
            SpecializationSubID = _specializationSubID;
            VolunteerStatus = _volunteerStatus;
            VolRefno = _volRefno;
            VolName = _volName;
            VolPiture = _volPiture;
            BatchNumber = _batchNumber;
            StartAssistance = _startAssistance;
            EndAssistance = _endAssistance;
            WFP1 = _WFP;
            PlacementRpt = _placementRpt;
            InitialRpt = _initialRpt;
            AnnualRpt = _annualRpt;
            EndOfAssignment = _endOfAssignment;
            ActivitiesAndAccmplsmnt = _activitiesAndAccmplsmnt;
            IssueAndConcerns = _issueAndConcerns;
            Recommendations = _recommendations;
            MajorOutput = _majorOutput;
            Outcomes = _outcomes;

        }


        public requestSub(
                 int _subID,
                 int _reqID,
                 int _reportID,
                int _volID,
                 string _sectorID,
                 string _specializationID,
                 string _specializationSubID,
                 string _volunteerStatus,
                 string _volRefno,
                 string _volName,
                 string _volPiture,
                 string _batchNumber,
                 string _startAssistance,
                 string _endAssistance,
                 string _WFP,
                 string _placementRpt,
                 string _initialRpt,
                 string _annualRpt,
                 string _endOfAssignment,
                 string _activitiesAndAccmplsmnt,
                 string _issueAndConcerns ,
                 string _recommendations,
                 string _majorOutput,
                 string _outcomes
            ) {

                 SubID = _subID;
                 ReqID = _reqID;
                 ReportID = _reportID;
                 SectorID = _sectorID;
                 VolID = _volID;
                 SpecializationID = _specializationID;
                 SpecializationSubID = _specializationSubID;
                 VolunteerStatus = _volunteerStatus;
                 VolRefno = _volRefno;
                 VolName = _volName;
                 VolPiture=_volPiture;
                 BatchNumber =  _batchNumber;
                 StartAssistance = _startAssistance;
                 EndAssistance = _endAssistance;
                 WFP1 = _WFP;
                 PlacementRpt = _placementRpt;
                 InitialRpt = _initialRpt;
                 AnnualRpt = _annualRpt;
                 EndOfAssignment = _endOfAssignment;
                 ActivitiesAndAccmplsmnt = _activitiesAndAccmplsmnt;
                 IssueAndConcerns = _issueAndConcerns;
                 Recommendations = _recommendations;
                 MajorOutput = _majorOutput;
                 Outcomes = _outcomes;
        }


        private int subID = 0;
        private int reqID = 0;
        private int reportID = 0;
        private int volID = 0;
        private string sectorID = "";
        private string specializationID = "";
        private string specializationSubID = "";
        private string volunteerStatus = "";
        private string volRefno = "";
        private string volName = "";
        private string volPiture;
        private string batchNumber = "";
        private string startAssistance = "";
        private string endAssistance = "";
        private string WFP = "";
        private string placementRpt = "";
        private string initialRpt = "";
        private string annualRpt = "";
        private string endOfAssignment = "";
        private string activitiesAndAccmplsmnt = "";
        private string issueAndConcerns = "";
        private string recommendations = "";
        private string majorOutput = "";
        private string outcomes = "";



        public int SubID
        {
            get { return subID; }
            set { subID = value; }
        }
     

        public int ReqID
        {
            get { return reqID; }
            set { reqID = value; }
        }

        public int ReportID
        {
            get { return reportID; }
            set { reportID = value; }
        }

        public int VolID
        {
            get { return volID; }
            set { volID = value; }
        }

        public string SectorID
        {
            get { return sectorID; }
            set { sectorID = value; }
        }
   

        public string SpecializationID
        {
            get { return specializationID; }
            set { specializationID = value; }
        }
       

        public string SpecializationSubID
        {
            get { return specializationSubID; }
            set { specializationSubID = value; }
        }
        

        public string VolunteerStatus
        {
            get { return volunteerStatus; }
            set { volunteerStatus = value; }
        }
       

        public string VolRefno
        {
            get { return volRefno; }
            set { volRefno = value; }
        }
       

        public string VolName
        {
            get { return volName; }
            set { volName = value; }
        }


        public string VolPiture
        {
            get { return volPiture; }
            set { volPiture = value; }
        }
       

        public string BatchNumber
        {
            get { return batchNumber; }
            set { batchNumber = value; }
        }

        public string StartAssistance
        {
            get { return startAssistance; }
            set { startAssistance = value; }
        }
        

        public string EndAssistance
        {
            get { return endAssistance; }
            set { endAssistance = value; }
        }
       

        public string WFP1
        {
            get { return WFP; }
            set { WFP = value; }
        }
       

        public string PlacementRpt
        {
            get { return placementRpt; }
            set { placementRpt = value; }
        }
      

        public string InitialRpt
        {
            get { return initialRpt; }
            set { initialRpt = value; }
        }
        

        public string AnnualRpt
        {
            get { return annualRpt; }
            set { annualRpt = value; }
        }
       

        public string EndOfAssignment
        {
            get { return endOfAssignment; }
            set { endOfAssignment = value; }
        }
   
        public string ActivitiesAndAccmplsmnt
        {
            get { return activitiesAndAccmplsmnt; }
            set { activitiesAndAccmplsmnt = value; }
        }
       

        public string IssueAndConcerns
        {
            get { return issueAndConcerns; }
            set { issueAndConcerns = value; }
        }
       

        public string Recommendations
        {
            get { return recommendations; }
            set { recommendations = value; }
        }
       

        public string MajorOutput
        {
            get { return majorOutput; }
            set { majorOutput = value; }
        }
        

        public string Outcomes
        {
            get { return outcomes; }
            set { outcomes = value; }
        }


    }
}
