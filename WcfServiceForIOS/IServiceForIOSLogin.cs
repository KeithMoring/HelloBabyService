using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using WcfServiceForIOS.Model;

namespace WcfServiceForIOS
{
    [ServiceContract]
   public interface IServiceForIOSLogin
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Xml,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "xml/{id}")]
        string XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "json/{id}")]
        string JSONData(string id);
        [OperationContract]
        [WebInvoke(Method = "POST",
                 RequestFormat = WebMessageFormat.Xml,
                 ResponseFormat = WebMessageFormat.Xml,
                 BodyStyle = WebMessageBodyStyle.Bare,
                 UriTemplate = "Poster")]
        ResponsePoster PosterManager(RequestPoster reqData);

        [OperationContract]
        [WebInvoke(Method = "GET",
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 BodyStyle = WebMessageBodyStyle.Wrapped,
                 UriTemplate = "PosterJson/{name}/{level}/{note}/{mm}")]
        ResponsePoster PosterManagerJson(string name, string level, string note, string mm);
        #region create user and login
        ///Creat new user
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "CreateUser"
            )]
        int NewUser(string name, int sex, string Md5_password, string role, string email, string phoneNum);

        //login new user
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "Login")]
        Users Login(string name, string password);
        #endregion
        #region get the username and userid
        [OperationContract]
        [WebInvoke(Method = "GET",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               BodyStyle = WebMessageBodyStyle.Wrapped,
               UriTemplate = "GetUserId/{username}")]
        int GetUserID(string username);
        #endregion
    }
    [DataContract(Namespace = "http://www.entlib.com/business")]
    public class RequestPoster
    {
        [DataMember]
        public string PosterData { get; set; }
    }
    [DataContract]
    public class ResponsePoster
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Level { get; set; }
        [DataMember]
        public string Note { get; set; }
    }
}
