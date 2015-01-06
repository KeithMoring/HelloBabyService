using System.Web;
using System.Text;
using System.Security.Cryptography;
using System;

namespace WcfServiceForIOS
{
    /// <summary>
    /// MD5 的摘要说明
    /// </summary>
    public class MyMD5
    {
        public MyMD5()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public static string ConvertintoMD5(string input)
        {
            byte[] result = Encoding.Default.GetBytes((input).Trim());
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] outre = md5.ComputeHash(result);
            return BitConverter.ToString(outre).Replace("-", "");

        }
    }
}