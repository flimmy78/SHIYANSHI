using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Langben.DAL
{
    /// <summary>
    /// 实验室别工作量统计分析
    /// </summary>
    public class VSHIYANSHIGONGZUOLIANGRepository : BaseRepository<VSHIYANSHIGONGZUOLIANG>, IDisposable
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
        public List<SHIYANSHIGONGZUO_Result> GetData(SysEntities db, string order, string sort, string search, params object[] listQuery)
        {
            Nullable<System.DateTime> sTARTDATE = null; Nullable<System.DateTime> eNDDATE = null; string dANWEI = string.Empty;
       
            Dictionary<string, string> queryDic = ValueConvert.StringToDictionary(search.GetString());
            if (queryDic != null && queryDic.Count > 0)
            {
                foreach (var item in queryDic)
                {                                                     
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(Start_Time)) //开始时间
                    {
                        sTARTDATE =Convert.ToDateTime(item.Value);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_Time)) //结束时间+1
                    {
                        eNDDATE = Convert.ToDateTime(item.Value).AddDays(1);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key== "SHOULIDANWEI") //
                    {
                        dANWEI = item.Value;
                        continue;
                    }
                }
            }

        
            if (sTARTDATE == null)
            {
                sTARTDATE = System.DateTime.Now.AddYears(-11);
            }
            if (eNDDATE == null)
            {
                eNDDATE = System.DateTime.Now.AddYears(11);
            }
            if (string.IsNullOrWhiteSpace(dANWEI))
            {
                dANWEI = "";
            }


            var data = db.SHIYANSHIGONGZUO(System.DateTime.Now.AddYears(-1), System.DateTime.Now.AddYears(1), dANWEI).ToList();




            return data; 

        }
        /// <summary>
        /// 通过主键id，获取实验室别工作量统计分析---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实验室别工作量统计分析</returns>
        public VSHIYANSHIGONGZUOLIANG GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取实验室别工作量统计分析---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实验室别工作量统计分析</returns>
        public VSHIYANSHIGONGZUOLIANG GetById(SysEntities db, string id)
        { 
                 return db.VSHIYANSHIGONGZUOLIANG.SingleOrDefault(s => s.ID == id); 
        }
 
        public void Dispose()
        {            
        }
    }
}

