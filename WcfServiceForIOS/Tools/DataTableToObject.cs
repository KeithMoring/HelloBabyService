using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using WcfServiceForIOS.Model;

namespace WcfServiceForIOS.Tools
{
    /// <summary>
    /// 通过反射将表中数据赋值到类中，类的名称需要和表中相同
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataTableToObject<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToT(DataTable dt) {
            List<T> Ts = new List<T>();
            Type t = typeof(T);
            PropertyInfo[] propertys = t.GetProperties();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                T obj_t = Activator.CreateInstance<T>();
                foreach (PropertyInfo p in propertys)
                {
                    if (dt.Columns.Contains(p.Name))
                    {
                        p.SetValue(obj_t, Convert.ChangeType(dt.Rows[i][p.Name].ToString(), p.PropertyType), null);

                    }
                }
                Ts.Add(obj_t);
            }
            return Ts;

        }
    }
}