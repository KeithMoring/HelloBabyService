using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data;
using MySql.Data.Common;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace WcfServiceForIOS
{
    /// <summary>
    /// Registerck 的摘要说明
    /// </summary>
    public class Registerck
    {


        public Registerck()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }



        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="username">用户名输入</param>
        /// <returns>存在false，不存在true</returns>
        public bool Checkname(string username)
        {
            string name = username;

            // using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["beaver_web"].ToString()))
            sqlparameters Username = new sqlparameters();
            Username.name = "SignName";
            Username.pvalue = username;
            DataConn UserNamecheck = new DataConn();
            List<sqlparameters> Parameters = new List<sqlparameters>();
            Parameters.Add(Username);
            DataTable dt = UserNamecheck.StroedGetTable("UsernameChk", Parameters);


            if (dt.Rows.Count != 0)
            {
                return false;

            }
            else
            {
                return true;
            }
        }


    }
}