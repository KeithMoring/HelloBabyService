using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using WcfServiceForIOS.Model;
using WcfServiceForIOS.Tools;
using System.Drawing;
using System.Text.RegularExpressions;

namespace WcfServiceForIOS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ServiceForIOSFile”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ServiceForIOSFile.svc 或 ServiceForIOSFile.svc.cs，然后开始调试。
    public class ServiceForIOSFile : IServiceForIOSFile
    {
        #region save image from ios or get image to ios
        static string userPhotoPath = @"imagesUpLoad/UserPhoto";
        
        public string SaveImage(Stream request)
        {

            MultipartParser parser = new MultipartParser(request);
            string mapFilePath = "E";
            if (parser != null && parser.Success) {
                //WcfLog.Log(parser.Filename+"|"+parser.ContentType);
                byte[] imagebyte = parser.FileContents;
                string filenamepath = MapPath.GetfileName(parser.Filename, userPhotoPath);
               
                FileStream file = null;
                try
                {
                    file = new FileStream(filenamepath, FileMode.Create, FileAccess.Write, FileShare.None);
                    file.Write(imagebyte, 0, imagebyte.Length);
                    string userid = GetIdFromFilename(parser.Filename);
                    mapFilePath = userPhotoPath + @"/" + parser.Filename;
                    UpdateUserPhotoUrl(mapFilePath,userid);
                    WcfLog.Log("success: "+filenamepath);
                    return mapFilePath;
                }
                catch (Exception e)
                {

                    WcfLog.Log(logLevel.Error, e);                    
                }
                finally {
                    if (file != null)
                    {
                        file.Close();
                        request.Close();
                    }
                    
                }
               
            }

            return mapFilePath;
        }

        public void UpdateUserPhotoUrl(string mapFilePath,string userId) {
            sqlparameters r_para = new sqlparameters("p_relative_url",mapFilePath);
            sqlparameters r_userid = new sqlparameters("p_user_id",userId);
            List<sqlparameters> paras = new List<sqlparameters>();
            paras.AddParas(r_para, r_userid);
            DataConn con = new DataConn();
            con.StroedGet("pkg_update_user_photo",paras);
        }

        public string GetIdFromFilename(string filename) {
            Regex re = new Regex(@"_(\d+)\.");
            Match t= re.Match(filename);
            if (t.Success)
            {
                return t.Groups[1].Value.Trim();
            }
            else {
                return string.Empty;
            }
           
        }



        #endregion
    }
}
