using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class request
    {
        public request() { }
        public request(
          string _refNo,
          string _duration,
          string _hostOrg,
          string _projTitle,
          string _volOrg,
          string _dateReceived,
          string _dateAssessed,
          string _dateApproved,
          string _assessedBy,
          string _requestStatus,
          string _remarks,
          string _letterOfIntent,
          string _RVF,
          string _siteAssesment,
          string _SECRegistration,
          string _AFVOR,
          int _completeRequirement,
          string _dateOfCompletion,
          string _requirementRemarks
            )
        {
            RefNo = _refNo;
            Duration = _duration;
            HostOrg = _hostOrg;
            ProjTitle = _projTitle;
            VolOrg = _volOrg;
            DateReceived = _dateReceived;
            DateAssessed = _dateAssessed;
            DateApproved = _dateApproved;
            AssessedBy = _assessedBy;
            RequestStatus = _requestStatus;
            Remarks = _remarks;
            LetterOfIntent = _letterOfIntent;
            RVF1 = _RVF;
            SiteAssesment = _siteAssesment;
            SECRegistration1 = _SECRegistration;
            AFVOR1 = _AFVOR;
            CompleteRequirement = _completeRequirement;
            DateOfCompletion = _dateOfCompletion;
            RequirementRemarks = _requirementRemarks;
        }

        public request(
        int _id,
        string _refNo,
        string _duration,
        string _hostOrg,
        string _projTitle,
        string _volOrg,
        string _dateReceived,
        string _dateAssessed,
        string _dateApproved,
        string _requestStatus,
        string _remarks,
        string _letterOfIntent,
        string _RVF,
        string _siteAssesment,
        string _SECRegistration,
        string _AFVOR,
        int _completeRequirement,
        string _dateOfCompletion,
        string _requirementRemarks
          )
        {

            Id = _id;
            RefNo = _refNo;
            Duration = _duration;
            HostOrg = _hostOrg;
            ProjTitle = _projTitle;
            VolOrg = _volOrg;
            DateReceived = _dateReceived;
            DateAssessed = _dateAssessed;
            DateApproved = _dateApproved;
            RequestStatus = _requestStatus;
            Remarks = _remarks;
            LetterOfIntent = _letterOfIntent;
            RVF1 = _RVF;
            SiteAssesment = _siteAssesment;
            SECRegistration1 = _SECRegistration;
            AFVOR1 = _AFVOR;
            CompleteRequirement = _completeRequirement;
            DateOfCompletion = _dateOfCompletion;
            RequirementRemarks = _requirementRemarks;
        }

        public request(
          int _id,
          string _refNo,
          string _duration,
          string _hostOrg,
          string _projTitle,
          string _volOrg,
          string _dateReceived,
          string _dateAssessed,
          string _dateApproved,
          string _assessedBy,
          string _requestStatus,
          string _remarks,
          string _letterOfIntent,
          string _RVF,
          string _siteAssesment,
          string _SECRegistration,
          string _AFVOR,
          int _completeRequirement,
          string _dateOfCompletion,
          string _requirementRemarks
            ) 
        {

            Id = _id;
            RefNo = _refNo;
            Duration = _duration;
            HostOrg = _hostOrg;
            ProjTitle = _projTitle;
            VolOrg = _volOrg;
            DateReceived = _dateReceived;
            DateAssessed = _dateAssessed;
            DateApproved = _dateApproved;
            AssessedBy = _assessedBy;
            RequestStatus = _requestStatus;
            Remarks = _remarks;
            LetterOfIntent = _letterOfIntent;
            RVF1 = _RVF;
            SiteAssesment = _siteAssesment;
            SECRegistration1 = _SECRegistration;
            AFVOR1 = _AFVOR;
            CompleteRequirement = _completeRequirement;
            DateOfCompletion = _dateOfCompletion;
            RequirementRemarks = _requirementRemarks;
        }


        private int id = 0;
        private string refNo = "";
        private string duration = "";
        private string hostOrg = "";
        private string projTitle = "";
        private string volOrg = "";
        private string dateReceived = "";
        private string dateAssessed = "";
        private string dateApproved = "";
        private string assessedBy = "";
        private string requestStatus = "";
        private string remarks = "";
        private string letterOfIntent = "";
        private string RVF = "";
        private string siteAssesment = "";
        private string SECRegistration = "";
        private string AFVOR = "";
        private int completeRequirement = 0;
        private string dateOfCompletion = "";
        private string requirementRemarks = "";


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       

        public string RefNo
        {
            get { return refNo; }
            set { refNo = value; }
        }
        
        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        

        public string HostOrg
        {
            get { return hostOrg; }
            set { hostOrg = value; }
        }
       

        public string ProjTitle
        {
            get { return projTitle; }
            set { projTitle = value; }
        }
       

        public string VolOrg
        {
            get { return volOrg; }
            set { volOrg = value; }
        }
       

        public string DateReceived
        {
            get { return dateReceived; }
            set { dateReceived = value; }
        }
     
        public string DateAssessed
        {
            get { return dateAssessed; }
            set { dateAssessed = value; }
        }
        

        public string DateApproved
        {
            get { return dateApproved; }
            set { dateApproved = value; }
        }
        

        public string AssessedBy
        {
            get { return assessedBy; }
            set { assessedBy = value; }
        }
       

        public string RequestStatus
        {
            get { return requestStatus; }
            set { requestStatus = value; }
        }
        

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
       

        public string LetterOfIntent
        {
            get { return letterOfIntent; }
            set { letterOfIntent = value; }
        }
       

        public string RVF1
        {
            get { return RVF; }
            set { RVF = value; }
        }
       

        public string SiteAssesment
        {
            get { return siteAssesment; }
            set { siteAssesment = value; }
        }
      

        public string SECRegistration1
        {
            get { return SECRegistration; }
            set { SECRegistration = value; }
        }
        

        public string AFVOR1
        {
            get { return AFVOR; }
            set { AFVOR = value; }
        }
        

        public int CompleteRequirement
        {
            get { return completeRequirement; }
            set { completeRequirement = value; }
        }
      

        public string DateOfCompletion
        {
            get { return dateOfCompletion; }
            set { dateOfCompletion = value; }
        }
        

        public string RequirementRemarks
        {
            get { return requirementRemarks; }
            set { requirementRemarks = value; }
        }

    }
}
