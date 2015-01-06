using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceForIOS.Tools
{
    public static class ExteneClassMeathod
    {
        /// <summary>
        /// 添加多个参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paras"></param>
        /// <param name="para"></param>
        public static void AddParas<T>(this List<T> paras, params T[] para) {
            for (int i = 0; i < para.Length; i++)
            {
                paras.Add(para[i]);
            }
        }
  
    }
}