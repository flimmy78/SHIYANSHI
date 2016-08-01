using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 标准装置/计量标准器信息
    /// </summary>
    public partial class METERING_STANDARD_DEVICERepository : BaseRepository<METERING_STANDARD_DEVICE>, IDisposable
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
        public IQueryable<METERING_STANDARD_DEVICE> GetData(SysEntities db, string order, string sort, string search, params object[] listQuery)
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
                  
                    
                    if (queryDic.ContainsKey("UNDERTAKE_LABORATORYID") && !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Value == "noway" && item.Key == "UNDERTAKE_LABORATORYID")
                    {//查询一对多关系的列名
                        where += "it.UNDERTAKE_LABORATORYID is null";
                        continue;
                    }
                    
                    if (queryDic.ContainsKey("PREPARE_SCHEME")&& !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "PREPARE_SCHEME")
                    {//查询多对多关系的列名
                        where += "EXISTS(select p from it.PREPARE_SCHEME as p where p.ID='" + item.Value + "')";
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
                     .CreateObjectSet<METERING_STANDARD_DEVICE>().Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it.[" + sort.GetString() + "] " + order.GetString())
                     .AsQueryable(); 

        }
        /// <summary>
        /// 通过主键id，获取标准装置/计量标准器信息---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>标准装置/计量标准器信息</returns>
        public METERING_STANDARD_DEVICE GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取标准装置/计量标准器信息---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>标准装置/计量标准器信息</returns>
        public METERING_STANDARD_DEVICE GetById(SysEntities db, string id)
        { 
                 return db.METERING_STANDARD_DEVICE.SingleOrDefault(s => s.ID == id); 
        }
        
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<PREPARE_SCHEME> GetRefPREPARE_SCHEME(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetRefPREPARE_SCHEME(db, id);
            }
        }
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<PREPARE_SCHEME> GetRefPREPARE_SCHEME(SysEntities db, string id)
        {
                return from m in db.METERING_STANDARD_DEVICE
                       from f in m.PREPARE_SCHEME
                       where m.ID == id
                       select f;

        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<PREPARE_SCHEME> GetRefPREPARE_SCHEME(SysEntities db)
        {
            return from m in db.METERING_STANDARD_DEVICE
                   from f in m.PREPARE_SCHEME
                   select f;
        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<PREPARE_SCHEME> GetRefPREPARE_SCHEME()
        {
            using (SysEntities db = new SysEntities())
            {
                return GetRefPREPARE_SCHEME(db);
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
        /// 删除一个标准装置/计量标准器信息
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条标准装置/计量标准器信息的主键</param>
        public void Delete(SysEntities db, string id)
        {
            METERING_STANDARD_DEVICE deleteItem = GetById(db, id);
            if (deleteItem != null)
            { 
                db.METERING_STANDARD_DEVICE.Remove(deleteItem);
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
            IQueryable<METERING_STANDARD_DEVICE> collection = from f in db.METERING_STANDARD_DEVICE
                    where deleteCollection.Contains(f.ID)
                    select f;
            foreach (var deleteItem in collection)
            {
                db.METERING_STANDARD_DEVICE.Remove(deleteItem);
            }
        }

        /// <summary>
        /// 根据UNDERTAKE_LABORATORYID，获取所有标准装置/计量标准器信息数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<METERING_STANDARD_DEVICE> GetByRefUNDERTAKE_LABORATORYID(SysEntities db, string id)
        {
            return from c in db.METERING_STANDARD_DEVICE
                        where c.UNDERTAKE_LABORATORYID == id
                        select c;
                      
        }

        public void Dispose()
        {
        }
    }
}

