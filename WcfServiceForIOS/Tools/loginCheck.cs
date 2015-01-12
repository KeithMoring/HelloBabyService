using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceForIOS.Tools
{
    public class loginCheck
    {
        /// <summary>
        /// false is failed,true is pass
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool TokenCheck(int userid,string token) {
            sqlparameters p_user_id = new sqlparameters("p_user_id",userid);
            sqlparameters p_token = new sqlparameters("p_token",token);
            string sql_result="p_result";
            List<sqlparameters> paras=new List<sqlparameters> {p_user_id,p_token};
            DataConn con = new DataConn();
            string result= con.getdata(sql_result, paras, "int", 10, "pkg_token_check");
            if (result == "1") {
                return true;
            }
            return false;
        }
    }
}