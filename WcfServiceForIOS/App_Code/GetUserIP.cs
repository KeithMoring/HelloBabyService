using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// GetUserIP 获得用户的外网ip，使用的为http://iframe.ip138.com/ic.asp
/// </summary>
public class GetUserIP
{
	public GetUserIP()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
        netIP();
        getIP();
	}
    private string strgetIP;

    /// <summary>
    /// 获得网络外部IP
    /// </summary>
    /// <returns></returns>
    public string renetIP()
    { return netIP(); }//返回网络IP
    /// <summary>
    /// 获得网络内部IP
    /// </summary>
    /// <returns></returns>
    public string regetIP()
    { return strgetIP; }//返回内网IP

    static string netIP()
    {
        Uri uri = new Uri("http://city.ip138.com/ip2city.asp");
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        req.ContentLength = 0;
        req.CookieContainer = new CookieContainer();
        req.GetRequestStream().Write(new byte[0], 0, 0);
        HttpWebResponse res = (HttpWebResponse)(req.GetResponse());
        StreamReader rs = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("GB18030"));
        string s = rs.ReadToEnd();
        rs.Close();
        req.Abort();
        res.Close();
        s = s.Substring(s.IndexOf('[') + 1, s.LastIndexOf(']') - s.IndexOf('[')-1);      //自己灵活取出IP
        return s;
       
       
    }
    public string getIP()//注意与static 的区别
    {
        System.Net.IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;//获取本机内网IP

        strgetIP = addressList[0].ToString();
        return strgetIP;
    }
}