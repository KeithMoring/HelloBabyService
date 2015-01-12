using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfServiceForIOS.Model
{
    [DataContract]
    public class UserVotePoster
    {
        [DataMember]
        public int User_Id { get; set; }
         [DataMember]
        public int Poster_Id { get; set; }
         [DataMember]
         public int VoteFlag { get; set; }

    }
}