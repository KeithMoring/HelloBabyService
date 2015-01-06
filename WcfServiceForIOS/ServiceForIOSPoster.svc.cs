using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using WcfServiceForIOS.Model;
using WcfServiceForIOS.Tools;
using System.Reflection;

namespace WcfServiceForIOS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ServiceForIOSPoster”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ServiceForIOSPoster.svc 或 ServiceForIOSPoster.svc.cs，然后开始调试。

    public class ServiceForIOSPoster : IServiceForIOSPoster
    {
        /*Create a new Poster*/

        public ConnectStatus SavePoster(Poster newPoster)
        {
            if (newPoster != null)
            {
                try
                {
                    List<sqlparameters> paras = new List<sqlparameters>();
                    sqlparameters para_user_id = new sqlparameters("P_User_ID", newPoster.User_ID);
                    sqlparameters para_poster = new sqlparameters("P_Poster_Input", newPoster.PosterInput);

                    paras.AddParas(para_poster, para_user_id);
                    DataConn con = new DataConn();
                    con.StroedGet("PKG_Poster_New", paras);
                }
                catch (Exception e)
                {
                    WcfLog.Log(logLevel.Error, e);
                    return ConnectStatus.ActionFailed;
                }

            }
            else
            {
                return ConnectStatus.ActionFailed;
            }
            return ConnectStatus.ActionSuccess;
        }
        /// <summary>
        /// 取得该用户的帖子,获得总记录数，分页表，第一个是总记录数，第二个是分页表
        /// </summary>
        /// <param name="User_ID"></param>
        /// <param name="pageStart"></param>
        /// <param name="pageEnd"></param>
        /// <returns></returns>
        public List<Poster> GetPosterByUserID(string User_ID, int pageStart, int pageEnd)
        {
            List<Poster> posterList = new List<Poster>();
            try
            {
                if (pageStart >= 0 && pageEnd >= 0)
                {

                    DataConn conn = new DataConn();
                    sqlparameters para_user_id = new sqlparameters("r_User_ID", User_ID);
                    sqlparameters para_page_start = new sqlparameters("startPageNum", pageStart);
                    sqlparameters para_page_end = new sqlparameters("endPageNum", pageEnd);
                    List<sqlparameters> paras = new List<sqlparameters> { para_user_id, para_page_start, para_page_end };
                    List<DataTable> dts = conn.StroedGetTableList("PKG_Get_Poster_ByUserID", paras);
                    #region 多个返回集写法
                    //获得dts有两个表，第一个是记录数，第二个是帖子内容
                    /*
                      Type t = typeof(Poster);                    
                      PropertyInfo[] propertys = t.GetProperties();
                      DataTable dt_poster = dts[1];
                      for (int i = 0; i < dt_poster.Rows.Count; i++)
                      {
                          object poster_o = Activator.CreateInstance(t);
                          foreach (PropertyInfo p in propertys)
                          {
                              if (dts[1].Columns.Contains(p.Name))
                              {
                                  p.SetValue(poster_o, Convert.ChangeType(dt_poster.Rows[i][p.Name].ToString(), p.PropertyType), null);

                              }
                          }
                          posterList.Add(poster_o as Poster);
                      }
                     */
                    #endregion
                    posterList = DataTableToObject<Poster>.ToT(dts[1]);
                    return posterList;

                }
                else
                {
                    return posterList;
                }
            }
            catch (Exception e)
            {

                WcfLog.Log(logLevel.Error, e);
                return posterList;
            }
        }
        /// <summary>
        /// Get this user's poster
        /// </summary>
        /// <param name="User_ID"></param>
        /// <param name="pageStart"></param>
        /// <param name="pageEnd"></param>
        /// <returns></returns>
        public string GetPosterByUserIDTest(string User_ID, int pageStart, int pageEnd)
        {
            DataTable dt = new DataTable();
            if (pageStart >= 0 && pageEnd >= 0)
            {

                DataConn conn = new DataConn();
                sqlparameters para_user_id = new sqlparameters("r_User_ID", User_ID);
                sqlparameters para_page_start = new sqlparameters("startPageNum", pageStart);
                sqlparameters para_page_end = new sqlparameters("endPageNum", pageEnd);
                List<sqlparameters> paras = new List<sqlparameters> { para_user_id, para_page_start, para_page_end };
                List<DataTable> dts = conn.StroedGetTableList("PKG_Get_Poster_ByUserID", paras);
                dt = dts[1];
            }
            return ObjectToJson.Serialize(dt, false);
        }
        /// <summary>
        /// get the this user main page posters
        /// </summary>
        /// <param name="User_ID"></param>
        /// <param name="pageStart"></param>
        /// <param name="pageEnd"></param>
        /// <returns></returns>
        public List<Poster> GetPoster(string User_ID, string pageStart, string pageEnd)
        {
            List<Poster> posterList = new List<Poster>();
            int num_pageEnd = int.Parse(pageEnd);
            int num_pageStart = int.Parse(pageStart);
            try
            {
                if (num_pageStart >= 0 && num_pageEnd >= 0)
                {

                    DataConn conn = new DataConn();
                    sqlparameters para_user_id = new sqlparameters("r_User_ID", User_ID);
                    sqlparameters para_page_start = new sqlparameters("startPageNum", pageStart);
                    sqlparameters para_page_end = new sqlparameters("endPageNum", pageEnd);
                    List<sqlparameters> paras = new List<sqlparameters> { para_user_id, para_page_start, para_page_end };
                    List<DataTable> dts = conn.StroedGetTableList("PKG_Get_Poster", paras);
                    posterList = DataTableToObject<Poster>.ToT(dts[1]);
                    return posterList;

                }
                else
                {
                    return posterList;
                }
            }
            catch (Exception e)
            {

                WcfLog.Log(logLevel.Error, e);
                return posterList;
            }


        }

        public string JSONData(string Posterid)
        {
            return "This poster id is " + Posterid + "from json";
        }
        private void voteAction(string User_ID, string Poster_id, VoteAction voteCancel, VoteAction voteupdown)
        {
            DataConn conn = new DataConn();
            sqlparameters para_user_id = new sqlparameters("r_user_id", User_ID);
            sqlparameters para_poster_id = new sqlparameters("r_poster_id", Poster_id);
            sqlparameters para_voteCancel = new sqlparameters("r_vote",voteCancel);
            sqlparameters para_voteUpdown = new sqlparameters("r_vote", voteupdown);
            List<sqlparameters> parasCancel = new List<sqlparameters> { para_user_id,para_poster_id,para_voteCancel};
            List<sqlparameters> parasUpDown = new List<sqlparameters> { para_user_id, para_poster_id, para_voteUpdown };
            conn.StroedGet("PKG_User_Vote", parasCancel);
            conn.StroedGet("PKG_User_Vote", parasUpDown);
        }
        private void voteCancel(string User_ID, string Poster_id, VoteAction voteCancel)
        {
            DataConn conn = new DataConn();
            sqlparameters para_user_id = new sqlparameters("r_user_id", User_ID);
            sqlparameters para_poster_id = new sqlparameters("r_poster_id", Poster_id);
            sqlparameters para_voteCancel = new sqlparameters("r_vote", voteCancel);
            List<sqlparameters> parasCancel = new List<sqlparameters> { para_user_id, para_poster_id, para_voteCancel };
            conn.StroedGet("PKG_User_Vote", parasCancel);
        }
        public ConnectStatus PosterVoteUp(string User_ID, string Poster_id)
        {
            try
            {
                voteAction(User_ID, Poster_id, VoteAction.VoteCancle, VoteAction.VoteUp);
                return ConnectStatus.ActionSuccess;
            }
            catch (Exception e){
                WcfLog.Log(logLevel.Error,e);
                return ConnectStatus.ActionFailed;
            }
            
        }
        public ConnectStatus PosterVoteCancel(string User_ID, string Poster_id)
        {

            try
            {
                voteCancel(User_ID, Poster_id, VoteAction.VoteCancle);
                return ConnectStatus.ActionSuccess;
            }
            catch (Exception e)
            {
                WcfLog.Log(logLevel.Error, e);
                return ConnectStatus.ActionFailed;
            }
        }
        public ConnectStatus PosterVoteDown(string User_ID, string Poster_id)
        {
            try
            {
                voteAction(User_ID, Poster_id, VoteAction.VoteCancle, VoteAction.VoteDown);
                return ConnectStatus.ActionSuccess;
            }
            catch (Exception e)
            {
                WcfLog.Log(logLevel.Error, e);
                return ConnectStatus.ActionFailed;
            }
        }

    }
}
