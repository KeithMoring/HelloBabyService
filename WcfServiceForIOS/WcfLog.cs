using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Reflection;
namespace WcfServiceForIOS
{
    enum logLevel
    {
        Error,
        Debug,
        Info,
        Warning
    }
    class WcfLog
    {
        /// <summary>
        /// log the text
        /// </summary>
        /// <param name="level"></param>
        /// <param name="e"></param>
        public static void Log(logLevel level, Exception e)
        {
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Error(level.ToString(), e);
        }
        public static void Log( string infoText) {
            Exception e = new Exception(infoText);
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Info(logLevel.Info,e);
        }
    }
}

