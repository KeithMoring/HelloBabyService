using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

/// <summary>
/// GetIPT 的摘要说明
/// </summary>
public class GetIPT
{
	public GetIPT()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string GetIPAddress()
        {
            //读取网站的数据
            string ip = string.Empty;
            try
            {
                Uri uri = new Uri("http://iframe.ip138.com/ic.asp");
                WebRequest wr = WebRequest.Create(uri);
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, System.Text.Encoding.Default);
                string all = sr.ReadToEnd();
                //all = "sfasf[12.1.9.12]sdf";
                //找出ip
                int i = all.IndexOf("[") + 1;
                int j = all.IndexOf("]");
                string tempip = all.Substring(i, j - i);
                ip = tempip.Replace(" ", "");

                sr.Close();
                s.Close();
                return ip;
            }
            catch (Exception e){
                return ip;
            }
        }
}