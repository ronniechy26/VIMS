using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace vms_v1.CLASS
{
    class auditTrail

    {
        public auditTrail(
           string _name,
           string _action)
        {
            Name = _name;
            Action = _action;
        }

        public auditTrail(
           string _name,
           string _action,
           DateTime _time)
        {
            Name = _name;
            Action = _action;
            TimeStamp = _time;
        } 

        public auditTrail(
            int _id,
            string _name,
            string _action,
            DateTime _time) 
        {
            Id = _id;
            Name = _name;
            Action = _action;
            TimeStamp = _time;
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
        private string action = "";

        public string Action
        {
            get { return action; }
            set { action = value; }
        }
        private DateTime timeStamp;

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
    }
}
