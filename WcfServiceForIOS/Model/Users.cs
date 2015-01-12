using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfServiceForIOS.Model
{
    public enum Sex { 
        Man=0,
        Woman=1
    }
    [DataContract]
    public class Users
    {
        private string sex;
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Sex
        {
            get
            {
                if (sex == "1")
                    return "Woman";
                else {
                    return "Man";
                }
            }
            set { sex = value; }
        }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PhotoUrl { get; set; }

        [DataMember]
        public string Role { get; set; }

        [DataMember]
        public string LoginStatus { get;set;}

        [DataMember]
        public string Token { get;set;}
    }
}