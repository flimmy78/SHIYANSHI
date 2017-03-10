using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Langben.DAL
{
    /// <summary>
    /// 证书信息查询
    /// </summary>
    public class VZHENGSHUXINXICHAXUNRepository : BaseRepository<VZHENGSHUXINXICHAXUN>, IDisposable
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
        public IQueryable<VZHENGSHUXINXICHAXUN> GetData(SysEntities db, string order, string sort, string search, params object[] listQuery)
        {
            string where = string.Empty;
            int flagWhere = 0;
            DateTime? startTime = null;
            DateTime? endTime = null;
            DateTime? startTime2 = null;
            DateTime? endTime2 = null;
            Dictionary<string, string> queryDic = ValueConvert.StringToDictionary(search.GetString());
            if (queryDic != null && queryDic.Count > 0)
            {
                foreach (var item in queryDic)
                {
                    //oracle数据库使用linq对时间段查询
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key== "JIANDINGRIQIStart_Time") //开始时间
                    {
                        startTime = Convert.ToDateTime(item.Value);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "JIANDINGRIQIEnd_Time") //结束时间+1
                    {
                        endTime = Convert.ToDateTime(item.Value);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "YOUXIAOQIZHIStart_Time") //开始时间
                    {
                        startTime2 = Convert.ToDateTime(item.Value);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "YOUXIAOQIZHIEnd_Time") //结束时间+1
                    {
                        endTime2 = Convert.ToDateTime(item.Value);
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
                     .CreateObjectSet<VZHENGSHUXINXICHAXUN>().Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it.[" + sort.GetString() + "] " + order.GetString())
                     .AsQueryable();
            if (null != startTime)
            {
                //data = data.Where(m => m.JIANDINGRIQI>=startTime&& m.JIANDINGRIQI <= endTime);
               data = data.Where(m => startTime <= m.JIANDINGRIQI);
            }
            if (null != endTime)
            {
               // data = data.Where(m => m.JIANDINGRIQI <= endTime);
                data = data.Where(m => endTime >= m.JIANDINGRIQI);
            }
            if (null != startTime2)
            {
                data = data.Where(m => startTime2 <= m.YOUXIAOQIZHI);
            }
            if (null != endTime2)
            {
                data = data.Where(m => endTime2 >= m.YOUXIAOQIZHI);
            }
            return data;
        }
        /// <summary>
        /// 通过主键id，获取证书信息查询---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>证书信息查询</returns>
        public VZHENGSHUXINXICHAXUN GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取证书信息查询---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>证书信息查询</returns>
        public VZHENGSHUXINXICHAXUN GetById(SysEntities db, string id)
        { 
                 return db.VZHENGSHUXINXICHAXUN.SingleOrDefault(s => s.ID == id); 
        }
 
        public void Dispose()
        {            
        }
    }
}

