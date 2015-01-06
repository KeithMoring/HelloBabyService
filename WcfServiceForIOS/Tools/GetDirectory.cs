using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
namespace WcfServiceForIOS.Tools
{
    public class GetDirectory
    {
        public static string currentDir() {
            string path = Process.GetCurrentProcess().MainModule.FileName;
            int n = path.LastIndexOf("\\");
            if(n>0)
            {
                path = path.Remove(n, path.Length - n);
            }
            return path;
        }
    }
}