using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Langben.DAL
{
    /// <summary>
    /// 检定任务
    /// </summary>
    public partial class VJIANDINGRENWURepository : BaseRepository<VJIANDINGRENWU>, IDisposable
    {
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="SysEntities">数据访问的上下文</param>
        /// <param name="order">升序asc（默认）还是降序desc</param>
        /// <param name="sort">排序字段</param>
        /// <param name="search">查询条件</param>
        /// <param name="listQuery">额外的参数</param>
        /// <returns></returns>      
        public IQueryable<VJIANDINGRENWU> GetDataX(SysEntities db, string order, string sort, string search, params object[] listQuery)
        {
            string where = string.Empty;
            int flagWhere = 0;
            string EQUIPMENT_STATUS_VALUUMN = string.Empty;
            string NAME = string.Empty;
            string ISRECEIVE = string.Empty;
            Dictionary<string, string> queryDic = ValueConvert.StringToDictionary(search.GetString());
            if (queryDic != null && queryDic.Count > 0)
            {
                foreach (var item in queryDic)
                {
                    if (!string.IsNullOrEmpty(item.Key) && !string.IsNullOrEmpty(item.Value) && item.Key == "EQUIPMENT_STATUS_VALUUMN")
                    {
                        EQUIPMENT_STATUS_VALUUMN = item.Value;
                        continue;
                    }
                    if (!string.IsNullOrEmpty(item.Key) && !string.IsNullOrEmpty(item.Value) && item.Key == "NAME")
                    {
                        NAME = item.Value;
                        continue;
                    }
                    if (flagWhere != 0)
                    {
                        where += " and ";
                    }
                    flagWhere++;

                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(Start_Time)) //开始时间
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(Start_Time)) + "] >=  CAST('" + item.Value + "' as   System.DateTime)";
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_Time)) //结束时间+1
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(End_Time)) + "] <  CAST('" + Convert.ToDateTime(item.Value).AddDays(1) + "' as   System.DateTime)";
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(Start_Int)) //开始数值
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(Start_Int)) + "] >= " + item.Value.GetInt();
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_Int)) //结束数值
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(End_Int)) + "] <= " + item.Value.GetInt();
                        continue;
                    }

                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(DDL_Int)) //精确查询数值
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(DDL_Int)) + "] =" + item.Value;
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(DDL_String)) //精确查询字符串
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(DDL_String)) + "] = '" + item.Value + "'";
                        continue;
                    }
                    if (!string.IsNullOrEmpty(item.Key) && !string.IsNullOrEmpty(item.Value) && item.Key != "EQUIPMENT_STATUS_VALUUMN")
                    {
                        where += "it.[" + item.Key + "] like '%" + item.Value + "%'";//模糊查询
                    }

                }
            }
            string[] EQUIPMENT_STATUS_VALUUMNarr = null;
            if (!string.IsNullOrEmpty(EQUIPMENT_STATUS_VALUUMN))
            {
                EQUIPMENT_STATUS_VALUUMNarr = EQUIPMENT_STATUS_VALUUMN.Split('*');
            }
            return ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext
                    .CreateObjectSet<VJIANDINGRENWU>().Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it.[" + sort.GetString() + "] " + order.GetString())
                     .OrderBy("it.[CREATETIME] " + "desc")
                     .Where(w => EQUIPMENT_STATUS_VALUUMNarr.Contains(w.EQUIPMENT_STATUS_VALUUMN) && w.NAME == NAME)
                     .AsQueryable();

        }

    }
}

