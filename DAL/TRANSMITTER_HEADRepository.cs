using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 变送器头
    /// </summary>
    public partial class TRANSMITTER_HEADRepository : BaseRepository<TRANSMITTER_HEAD>, IDisposable
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
        public IQueryable<TRANSMITTER_HEAD> GetData(SysEntities db, string order, string sort, string search, params object[] listQuery)
        {
            string where = string.Empty;
            int flagWhere = 0;

            Dictionary<string, string> queryDic = ValueConvert.StringToDictionary(search.GetString());
            if (queryDic != null && queryDic.Count > 0)
            {
                foreach (var item in queryDic)
                {
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
                    where += "it.[" + item.Key + "] like '%" + item.Value + "%'";//模糊查询
                }
            }
            return ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext 
                     .CreateObjectSet<TRANSMITTER_HEAD>().Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it.[" + sort.GetString() + "] " + order.GetString())
                     .AsQueryable(); 

        }
        /// <summary>
        /// 通过主键id，获取变送器头---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>变送器头</returns>
        public TRANSMITTER_HEAD GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取变送器头---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>变送器头</returns>
        public TRANSMITTER_HEAD GetById(SysEntities db, string id)
        { 
            return db.TRANSMITTER_HEAD.SingleOrDefault(s => s.ID == id);
        
        }
        /// <summary>
        /// 确定删除一个对象，调用Save方法
        /// </summary>
        /// <param name="id">一条数据的主键</param>
        /// <returns></returns>    
        public int Delete(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                this.Delete(db, id);
                return Save(db);
            }
        }
 
        /// <summary>
        /// 删除一个变送器头
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条变送器头的主键</param>
        public void Delete(SysEntities db, string id)
        {
            TRANSMITTER_HEAD deleteItem = GetById(db, id);
            if (deleteItem != null)
            { 
                db.TRANSMITTER_HEAD.Remove(deleteItem);
            }
        }
        /// <summary>
        /// 删除对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="deleteCollection">主键的集合</param>
        public void Delete(SysEntities db, string[] deleteCollection)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<TRANSMITTER_HEAD> collection = from f in db.TRANSMITTER_HEAD
                    where deleteCollection.Contains(f.ID)
                    select f;
            foreach (var deleteItem in collection)
            {
                db.TRANSMITTER_HEAD.Remove(deleteItem);
            }
        }

        public void Dispose()
        {          
        }
    }
}

