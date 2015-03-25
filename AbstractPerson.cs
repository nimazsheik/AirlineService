using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AirlineService
{
    [DataContract]
    public class AbstractPerson
    {
        private string fname;
        private string lname;
        private string nic;
        private char gender;
        private DateTime dob;
        private string add1;
        private string add2;
        private string email;
        private string phone;

        [DataMember]
        public string Fname
        {
            get { return fname; }
            set { fname = value; }
        }

        [DataMember]
        public string Lname
        {
            get { return lname; }
            set { lname = value; }
        }

        [DataMember]
        public string Nic
        {
            get { return nic; }
            set { nic = value; }
        }

        [DataMember]
        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        [DataMember]
        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        [DataMember]
        public string Add1
        {
            get { return add1; }
            set { add1 = value; }
        }

        [DataMember]
        public string Add2
        {
            get { return add2; }
            set { add2 = value; }
        }

        [DataMember]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        //public abstract int addDetails();
        //public abstract void updateDetails(int id);


       
    }
}
