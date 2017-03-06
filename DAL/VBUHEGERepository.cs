using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Langben.DAL
{
    /// <summary>
    /// 不合格统计分析
    /// </summary>
    public class VBUHEGERepository : BaseRepository<VBUHEGE>, IDisposable
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
        public IQueryable<VBUHEGE> GetData(SysEntities db, string order, string sort, string search, params object[] listQuery)
        {
            string where = string.Empty;
            int flagWhere = 0;
            DateTime? startTime = null;
            DateTime? endTime = null;
            Dictionary<string, string> queryDic = ValueConvert.StringToDictionary(search.GetString());
            if (queryDic != null && queryDic.Count > 0)
            {
                foreach (var item in queryDic)
                {

                    //oracle数据库使用linq对时间段查询
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "BAOGAOPIZHUNTONGGUOSHIJIANStart_Time") //开始时间
                    {
                        startTime = Convert.ToDateTime(item.Value);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "BAOGAOPIZHUNTONGGUOSHIJIANEnd_Time") //结束时间+1
                    {
                        endTime = Convert.ToDateTime(item.Value).AddDays(1);
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
                     .CreateObjectSet<VBUHEGE>().Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it.[" + sort.GetString() + "] " + order.GetString())
                     .AsQueryable();
            if (null != startTime)
            {
                data = data.Where(m => startTime <= m.BAOGAOPIZHUNTONGGUOSHIJIAN);
            }
            if (null != endTime)
            {
                data = data.Where(m => endTime >= m.BAOGAOPIZHUNTONGGUOSHIJIAN);
            }
            return data;
        }
        /// <summary>
        /// 通过主键id，获取不合格统计分析---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>不合格统计分析</returns>
        public VBUHEGE GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取不合格统计分析---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>不合格统计分析</returns>
        public VBUHEGE GetById(SysEntities db, string id)
        { 
                 return db.VBUHEGE.SingleOrDefault(s => s.ID == id); 
        }
 
        public void Dispose()
        {            
        }
    }
}

