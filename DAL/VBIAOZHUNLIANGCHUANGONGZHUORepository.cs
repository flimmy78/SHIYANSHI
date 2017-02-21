using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Langben.DAL
{
    /// <summary>
    /// 标准量传部工作信息查询
    /// </summary>
    public class VBIAOZHUNLIANGCHUANGONGZHUORepository : BaseRepository<VBIAOZHUNLIANGCHUANGONGZHUO>, IDisposable
    {
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="SysEntities">数据访问的上下文</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="listQuery">额外的参数</param>
        /// <returns></returns>      
        public IQueryable<VBIAOZHUNLIANGCHUANGONGZHUO> GetData(SysEntities db, string order, string sort, string search, params object[] listQuery)
        {
            string where = string.Empty;
            int flagWhere = 0;
            DateTime? startTime = null;
            DateTime? endTime = null;
            DateTime? startTime2 = null;
            DateTime? endTime2 = null;
            DateTime? startTime3 = null;
            DateTime? endTime3 = null;
            Dictionary<string, string> queryDic = ValueConvert.StringToDictionary(search.GetString());
            if (queryDic != null && queryDic.Count > 0)
            {
                foreach (var item in queryDic)
                {
                    //oracle数据库使用linq对时间段查询
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key== "SONGJIANRIQIStart_Time") //开始时间
                    {
                        startTime = Convert.ToDateTime(item.Value);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "SONGJIANRIQIEnd_Time") //结束时间+1
                    {
                        endTime = Convert.ToDateTime(item.Value).AddDays(1);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "JIANDINGRIQIStart_Time") //开始时间
                    {
                        startTime2 = Convert.ToDateTime(item.Value);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "JIANDINGRIQIEnd_Time") //结束时间+1
                    {
                        endTime2 = Convert.ToDateTime(item.Value).AddDays(1);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "BAOGAOSHENPITONGGUORIQIStart_Time") //开始时间
                    {
                        startTime3 = Convert.ToDateTime(item.Value);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "BAOGAOSHENPITONGGUORIQIEnd_Time") //结束时间+1
                    {
                        endTime3 = Convert.ToDateTime(item.Value).AddDays(1);
                        continue;
                    }
                    if (flagWhere != 0)
                    {
                        where += " and ";
                    }
                    flagWhere++;
                  
                   
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
                    where += "it.[" + item.Key + "] like '%" + item.Value + "%'";//模糊查询
                }
            }
            var data= ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext 
                     .CreateObjectSet<VBIAOZHUNLIANGCHUANGONGZHUO>().Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it.[" + sort.GetString() + "] " + order.GetString())
                     .AsQueryable();
            if (null != startTime)
            {
                data = data.Where(m => startTime <= m.SONGJIANRIQI);
            }
            if (null != endTime)
            {
                data = data.Where(m => endTime >= m.SONGJIANRIQI);
            }
            if (null != startTime2)
            {
                data = data.Where(m => startTime2 <= m.JIANDINGRIQI);
            }
            if (null != endTime2)
            {
                data = data.Where(m => endTime2 >=m.JIANDINGRIQI);
            }
            if (null != startTime3)
            {
                data = data.Where(m => startTime3 <= m.BAOGAOSHENPITONGGUORIQI);
            }
            if (null != endTime3)
            {
                data = data.Where(m => endTime3 >= m.BAOGAOSHENPITONGGUORIQI);
            }
            return data;
        }
        /// <summary>
        /// 通过主键id，获取标准量传部工作信息查询---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>标准量传部工作信息查询</returns>
        public VBIAOZHUNLIANGCHUANGONGZHUO GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取标准量传部工作信息查询---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>标准量传部工作信息查询</returns>
        public VBIAOZHUNLIANGCHUANGONGZHUO GetById(SysEntities db, string id)
        { 
                 return db.VBIAOZHUNLIANGCHUANGONGZHUO.SingleOrDefault(s => s.ID == id); 
        }
 
        public void Dispose()
        {            
        }
    }
}

