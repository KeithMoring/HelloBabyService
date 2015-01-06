using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
//using log4net;
using System.Reflection;
using System.IO;
using System.Drawing;
using WcfServiceForIOS.Model;
using WcfServiceForIOS.Tools;
using System.Data;


namespace WcfServiceForIOS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ServiceForIOS”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ServiceForIOS.svc 或 ServiceForIOS.svc.cs，然后开始调试。
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
   
    
    public class ServiceForIOS :IServiceForIOS
    {
        #region example
        public void DoWork()
        {
        }
        public string XMLData(string Posterid) {
            return "This poster id is" + Posterid;
        }
        public string JSONData(string Posterid) {
            return "This poster id is " + Posterid + "from json";
        }

        public ResponsePoster PosterManager(RequestPoster reqData) {
            var data = reqData.PosterData.Split('|');
            var response = new ResponsePoster
            {
                Name = data[0],
                Level = data[1],
                Note = data[2]
            };
            return response;
        }

        public ResponsePoster PosterManagerJson(string name,string levle,string note,string mm)
        {
            ResponsePoster response = new ResponsePoster { Name = name, Level = levle, Note = note };
            return response;
        }
        #endregion

        #region register user and login
        /// <summary>
        /// Create new user, 0 failed network, 1 success, 2 username has existed, 3 phonenum has existed
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="Md5_password"></param>
        /// <param name="role"></param>
        /// <param name="email"></param>
        /// <param name="phoneNum"></param>
        /// <returns></returns>
        public int NewUser(string name, int sex, string Md5_password, string role, string email, string phoneNum)
        {
            try
            {
                DataConn dataconn = new DataConn();
                List<sqlparameters> parameters = new List<sqlparameters>();
                sqlparameters p_name = new sqlparameters("r_user_name", name);
                parameters.Add(p_name);               
                string exist_num=dataconn.getdata("get_exist",parameters,"int",2,"PKG_Exist_User");
                if (exist_num == "1") {

                    return 2;
                }
                sqlparameters p_sex = new sqlparameters("r_user_sex", sex);
                parameters.Add(p_sex);
                Md5_password = MyMD5.ConvertintoMD5(Md5_password);
                sqlparameters p_Md5_password = new sqlparameters("r_user_Password", Md5_password);
                parameters.Add(p_Md5_password);
                sqlparameters p_role = new sqlparameters("r_Role", role);
                parameters.Add(p_role);
                sqlparameters p_email = new sqlparameters("r_user_email", email);
                parameters.Add(p_email);
                sqlparameters p_phoneNum = new sqlparameters("r_user_phoneNum", phoneNum);
                parameters.Add(p_phoneNum);
                dataconn.StroedGet("PKG_Creat_User", parameters);
                return 1;
            }
            catch (Exception e) {
               // ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
               // log.Error("E",e);
                WcfLog.Log(logLevel.Error,e);
                return 0; }
            
        }
        /// <summary>
        /// if return N is not pass ,P is pass ,E is error may be network,result is userid
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Users Login(string name, string password) {
            try
            {
                string pass = "Pass";
                DataConn con = new DataConn();
                List<sqlparameters> parameters = new List<sqlparameters>();
                //sqlparameters p_pass = new sqlparameters("pass",pass);
                sqlparameters p_name = new sqlparameters("p_name", name);
                password = MyMD5.ConvertintoMD5(password);
                sqlparameters p_password = new sqlparameters("p_password", password);
               // parameters.Add(p_pass);
                parameters.Add(p_name);               
                parameters.Add(p_password);
               string result= con.getdata(pass, parameters, "string", 10, "LoginCheck");
                //if login success,result is this user id
                if (result == "No")
                {
                    Users user=new Users() ;
                    user.LoginStatus="N";
                    return user;
                }
                else {
                    List<sqlparameters> parametersLogin = new List<sqlparameters>();
                    sqlparameters p_user_id = new sqlparameters("p_user_id", result);
                    parametersLogin.Add(p_user_id);
                    DataTable dt = con.StroedGetTable("PKG_Get_Login_User", parametersLogin);
                    Users user = DataTableToObject<Users>.ToT(dt)[0];
                    return user;
                }
                
                
                
            }
            catch (Exception e) {
                WcfLog.Log(logLevel.Error, e);
                Users user = new Users();
                user.LoginStatus = "E";
                return user;
            }
        }
        /// <summary>
        /// get the userid by the username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetUserID(string username) {
            sqlparameters para = new sqlparameters("username",username);
            List<sqlparameters> paras = new List<sqlparameters>();
            paras.Add(para);
            DataConn con = new DataConn();
           string userid= con.getdata("User_ID", paras, "int", 20, "PKG_Get_UserID");
           return Convert.ToInt32(userid);
        }
        
        public void testLog() {
            try
            {
                int a = 0;
                int b = 9;
                int c = b / a;
            }
            catch (Exception e) {
               // ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                //log.Error("E", e);
                WcfLog.Log(logLevel.Error, e);
            }
        }

        #endregion

      
    }
      


}
