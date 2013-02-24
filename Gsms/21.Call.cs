using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class Call
    {
        private DateTime dateAndTime;
        private int dialedPhoneNumber;
        private long duratationInSeconds;

        public Call(DateTime dateAndTime, int dialedPhoneNumber, long duratationInSeconds)
        {
            this.dateAndTime = dateAndTime;
            this.dialedPhoneNumber = dialedPhoneNumber;
            this.duratationInSeconds = duratationInSeconds;   
        }

        public DateTime DateAndTime
        {
            get { return this.dateAndTime;}
            set { this.dateAndTime=value; }
        }

        

        public int DialedPhoneNumber
        {
            get { return this.dialedPhoneNumber; }
            set { this.dialedPhoneNumber = value; }
        }

        public long DuratationInSeconds
        {
            get { return this.duratationInSeconds; }
            set { this.duratationInSeconds = value; }
        }
    }

