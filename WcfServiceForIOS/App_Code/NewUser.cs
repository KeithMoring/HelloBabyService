using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceForIOS
{
    /// <summary>
    /// NewUser 创建新用户
    /// </summary>

    public class NewUser
    {
        public NewUser()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 返回mysql的参数列表
        /// </summary>
        /// <param name="name">Mysql存储过程中输入的变量名称，从存储过程中找</param>
        /// <param name="pvalue">Mysql存储过程的输入变量值</param>
        /// <returns></returns>
        public List<sqlparameters> makesqlpara(List<string> name, List<object> pvalue)
        {

            if (name.Count == pvalue.Count)
            {
                List<sqlparameters> paras = new List<sqlparameters>();
                sqlparameters para;
                for (int i = 0; i < name.Count; i++)
                {
                    para.name = name[i];
                    para.pvalue = pvalue[i];
                    paras.Add(para);
                }
                return paras;
            }
            else
            {
                return null;
            }


        }
        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="signname">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="email">邮箱</param>
        public bool signnewuser(string signname, string password, string email)
        {
            if (signname != "" && password != "" && email != "")
            {
                List<string> names = new List<string>();
                List<object> pvalues = new List<object>();
                names.Add("Signname");
                names.Add("Password");
                names.Add("Email");
                pvalues.Add(signname);
                pvalues.Add(password);
                pvalues.Add(email);
                List<sqlparameters> newuserpara = makesqlpara(names, pvalues);
                try
                {
                    DataConn newusersign = new DataConn();
                    newusersign.StroedGet("NewUser", newuserpara);
                    return true;

                }
                catch (Exception e)
                {
                    return false;
                    //日志
                }

            }
            else
            {
                ///日志
                return false;
            }
        }

    }
}