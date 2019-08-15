using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vms_v1.CLASS
{
    class loginInformation
    {
        public loginInformation() { }
        
        public loginInformation(
        string _username,
        string _password)
        {
            Username = _username;
            Password = _password;
        }



        public loginInformation(
         int _id,
         string _username,
         string _password,
         string _userLoginName,
         string _secretQuestion,
         string _secretAnswer,
         string _hintPassword)
        {
            Id = _id;
            Username = _username;
            Password = _password;
            UserLoginName = _userLoginName;
            SecretQuestion = _secretQuestion;
            SecretAnswer = _secretAnswer;
            HintPassword = _hintPassword;
        }



        public loginInformation(
         
           string _username,
           string _password,
           int _userLevel,
           int _isActive)
        {
       
            Username = _username;
            Password = _password;
            UserLevel = _userLevel;
            IsActive = _isActive;

        }


        public loginInformation(
          int _id,
          int _userLevel,
          int _isActive)
        {
            Id = _id;
            UserLevel = _userLevel;
            IsActive = _isActive;
        }


        public loginInformation(
            int _id,
            string _username,
            string _password,
            int _userLevel,
            string _userLoginName,
            string _secretQuestion,
            string _secretAnswer,
            string _hintPassword,
            int _isActive) 
        {
            Id = _id;
            Username = _username;
            Password = _password;
            UserLevel = _userLevel;
            UserLoginName = _userLoginName;
            SecretQuestion = _secretQuestion;
            SecretAnswer = _secretAnswer;
            HintPassword = _hintPassword;
            IsActive = _isActive;
           
        }



        private int id = 0;
        private string username = "";
        private string password = "";
        private int userLevel = 0;
        private string userLoginName = "";
        private string secretQuestion = "";
        private string secretAnswer = "";
        private string hintPassword = "";
        private int isActive = 0;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
       

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
       

        public int UserLevel
        {
            get { return userLevel; }
            set { userLevel = value; }
        }
        

        public string UserLoginName
        {
            get { return userLoginName; }
            set { userLoginName = value; }
        }
       

        public string SecretQuestion
        {
            get { return secretQuestion; }
            set { secretQuestion = value; }
        }
        

        public string SecretAnswer
        {
            get { return secretAnswer; }
            set { secretAnswer = value; }
        }
       

        public string HintPassword
        {
            get { return hintPassword; }
            set { hintPassword = value; }
        }
      
        public int IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }



    }
}
