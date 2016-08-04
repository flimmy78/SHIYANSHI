using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 预备方案
    /// </summary>
    public partial class PREPARE_SCHEMERepository : BaseRepository<PREPARE_SCHEME>, IDisposable
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
        public IQueryable<PREPARE_SCHEME> GetData(SysEntities db, string order, string sort, string search, params object[] listQuery)
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
                  
                    
                    if (queryDic.ContainsKey("SCHEMEID") && !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Value == "noway" && item.Key == "SCHEMEID")
                    {//查询一对多关系的列名
                        where += "it.SCHEMEID is null";
                        continue;
                    }
                    
                    if (queryDic.ContainsKey("METERING_STANDARD_DEVICE")&& !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "METERING_STANDARD_DEVICE")
                    {//查询多对多关系的列名
                        where += "EXISTS(select p from it.METERING_STANDARD_DEVICE as p where p.ID='" + item.Value + "')";
                        continue;
                    }
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
                     .CreateObjectSet<PREPARE_SCHEME>().Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it.[" + sort.GetString() + "] " + order.GetString())
                     .AsQueryable(); 

        }
        /// <summary>
        /// 通过主键id，获取预备方案---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>预备方案</returns>
        public PREPARE_SCHEME GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取预备方案---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>预备方案</returns>
        public PREPARE_SCHEME GetById(SysEntities db, string id)
        { 
                 return db.PREPARE_SCHEME.SingleOrDefault(s => s.ID == id); 
        }
        
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<METERING_STANDARD_DEVICE> GetRefMETERING_STANDARD_DEVICE(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetRefMETERING_STANDARD_DEVICE(db, id);
            }
        }
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<METERING_STANDARD_DEVICE> GetRefMETERING_STANDARD_DEVICE(SysEntities db, string id)
        {
                return from m in db.PREPARE_SCHEME
                       from f in m.METERING_STANDARD_DEVICE
                       where m.ID == id
                       select f;

        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<METERING_STANDARD_DEVICE> GetRefMETERING_STANDARD_DEVICE(SysEntities db)
        {
            return from m in db.PREPARE_SCHEME
                   from f in m.METERING_STANDARD_DEVICE
                   select f;
        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<METERING_STANDARD_DEVICE> GetRefMETERING_STANDARD_DEVICE()
        {
            using (SysEntities db = new SysEntities())
            {
                return GetRefMETERING_STANDARD_DEVICE(db);
            }
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
        /// 删除一个预备方案
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条预备方案的主键</param>
        public void Delete(SysEntities db, string id)
        {
            PREPARE_SCHEME deleteItem = GetById(db, id);
            if (deleteItem != null)
            { 
                db.PREPARE_SCHEME.Remove(deleteItem);
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
            IQueryable<PREPARE_SCHEME> collection = from f in db.PREPARE_SCHEME
                    where deleteCollection.Contains(f.ID)
                    select f;
            foreach (var deleteItem in collection)
            {
                db.PREPARE_SCHEME.Remove(deleteItem);
            }
        }

        /// <summary>
        /// 根据SCHEMEID，获取所有预备方案数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<PREPARE_SCHEME> GetByRefSCHEMEID(SysEntities db, string id)
        {
            return from c in db.PREPARE_SCHEME
                        where c.SCHEMEID == id
                        select c;
                      
        }

        public void Dispose()
        {
        }
    }
}

