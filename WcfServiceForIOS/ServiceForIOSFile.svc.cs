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

namespace WcfServiceForIOS
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ServiceForIOSFile”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ServiceForIOSFile.svc 或 ServiceForIOSFile.svc.cs，然后开始调试。
    public class ServiceForIOSFile : IServiceForIOSFile
    {
        #region save image from ios or get image to ios
        public void SaveImage(Stream request)
        {

            MultipartParser parser = new MultipartParser(request);
            if (parser != null && parser.Success) {
                WcfLog.Log(parser.Filename+"|"+parser.ContentType);
                byte[] imagebyte = parser.FileContents;
                string filenamepath = MapPath.GetfileName(parser.Filename,"imagesUpLoad");
                WcfLog.Log(filenamepath);
                FileStream file = null;
                try
                {
                    file = new FileStream(filenamepath, FileMode.Create, FileAccess.Write, FileShare.None);
                    file.Write(imagebyte, 0, imagebyte.Length);

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


        }







        #endregion
    }
}
