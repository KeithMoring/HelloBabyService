using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WcfServiceForIOS.Tools
{
    public class MapPath
    {
        public static string GetMapPath()
        {
            string t2 = System.Web.Hosting.HostingEnvironment.MapPath("~");
            return t2;
        }
        public static string GetfileName(string filename,string otherpath) {
            if (otherpath == null) {
                otherpath = @"\\otherfiles";

            }
            if (filename == null) {
                filename = @"otherfile.dat";
            }
            string currentPath = GetMapPath();
            if (!currentPath.EndsWith("\\")) {
                currentPath += "\\";
            }
            if (!otherpath.EndsWith("\\")) {
                otherpath += "\\";
            }
            string upLoadFolder = currentPath + otherpath;
            if (!Directory.Exists(upLoadFolder)) {
                Directory.CreateDirectory(upLoadFolder);
            }
            return upLoadFolder+ filename;
        }
    }
}