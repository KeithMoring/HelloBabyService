using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceForIOS.Model
{
    [DataContract]
    public class Poster
    {
        [DataMember]
        public int User_ID { get; set; }
        [DataMember]
        public string Title {get;set; }
        [DataMember]
        public string User_Name { get; set; }
         [DataMember]
        public string PosterInput { get; set; }
         [DataMember]
        public int VisitNum { get; set; }
         [DataMember]
        public int FavorNum { get; set; }
         [DataMember]
        public int LoveNum { get; set; }
         [DataMember]
        public int OppsitionNum { get; set; }
         [DataMember]
        public int ScoresNum { get; set; }
        [DataMember]
        public DateTime PostTime { get;set;}
        [DataMember]
        public string PosterID { get; set; }
    }
}