using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.ServiceModel.Web;
using WcfServiceForIOS.Model;
namespace WcfServiceForIOS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IServiceForIOSPoster”。
    [ServiceContract]
    public interface IServiceForIOSPoster
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SavePoster"
            )]
        ConnectStatus SavePoster(Poster newPoster);


        [OperationContract]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetPosterByUserID"
            )]
        List<Poster> GetPosterByUserID(string User_ID,int pageStart,int pageEnd);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GPD"
            )]
        string GetPosterByUserIDTest(string User_ID, int pageStart, int pageEnd);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetPoster/{User_ID}/{pageStart}/{pageEnd}"
            )]
        List<Poster> GetPoster(string User_ID,string pageStart, string pageEnd);
        /*
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetPosterByUserTag"
            )]
        List<Poster> GetPosterByUserTag(string User_ID, int pageStart, int pageEnd);
        */
        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "json/{id}")]
        string JSONData(string id);

        #region---the vote up and vote down
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "PosterVoteUp/{User_ID}/{Poster_id}/{User_token}"
            )]
        ConnectStatus PosterVoteUp(string User_ID, string Poster_id,string User_token);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "PosterVoteCancel/{User_ID}/{Poster_id}/{User_token}"
            )]
        ConnectStatus PosterVoteCancel(string User_ID, string Poster_id,string User_token);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "PosterVoteDown/{User_ID}/{Poster_id}/{User_token}"
            )]
        ConnectStatus PosterVoteDown(string User_ID, string Poster_id,string User_token);

        //stop to use this
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "UserVote")]
        List<UserVotePoster> UserVoteList(string User_ID,string User_token);
        #endregion
    }
}
