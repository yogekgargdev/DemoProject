using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Customer
    {
        [NonSerialized]
        public string gender;
        public int CID
        {
            get;
            set;
        }
        public string CNAME
        {
            get;
            set;
        }


        public string CGENDER
        {
            get { return gender; }
            set { gender = value; }
        }
        public string ADDRESS
        {
            get;
            set;
        }
        public string MOBILE
        {
            get;
            set;
        }
        public override string ToString()
        {
            string s = "";
            s += "\nCustomer ID\t:\t" + CID;
            s += "\nCustomer Name\t:\t" + CNAME;
            s += "\nGender\t\t:\t" + CGENDER;
            s += "\nAddress\t\t:\t" + ADDRESS;
            s += "\nMobile Number\t:\t" + MOBILE;
            return s;
        }
    }
}

/*
 * 
 * 
 using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Customer
    {
      
        public int CID
        {
            get;
            set;
        }
        public string CNAME
        {
            get;
            set;
        }
        
        [field:NonSerialized]
        public string CGENDER
        {
            get;
            set;
        }
        public string ADDRESS
        {
            get;
            set;
        }
        public string MOBILE
        {
            get;
            set;
        }
        public override string ToString()
        {
            string s = "";
            s += "\nCustomer ID\t:\t" + CID;
            s+= "\nCustomer Name\t:\t" + CNAME;
            s += "\nGender\t\t:\t" + CGENDER;
            s+= "\nAddress\t\t:\t" + ADDRESS;
            s += "\nMobile Number\t:\t" +MOBILE;
            return s;
        }
    }
}
*/