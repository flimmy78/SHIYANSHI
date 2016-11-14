using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Langben.DAL
{
    /// <summary>
    /// 附件
    /// </summary>
    public partial class FILE_UPLOADERRepository : BaseRepository<FILE_UPLOADER>, IDisposable
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
        public IQueryable<FILE_UPLOADER> GetData(SysEntities db, string order, string sort, string search, params object[] listQuery)
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
                    
                    
                    if (queryDic.ContainsKey("PREPARE_SCHEMEID") && !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Value == "noway" && item.Key == "PREPARE_SCHEMEID")
                    {//查询一对多关系的列名
                        where += "it.PREPARE_SCHEMEID is null";
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
                     .CreateObjectSet<FILE_UPLOADER>().Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it.[" + sort.GetString() + "] " + order.GetString())
                     .AsQueryable(); 

        }
        /// <summary>
        /// 通过主键id，获取附件---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>附件</returns>
        public FILE_UPLOADER GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取附件---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>附件</returns>
        public FILE_UPLOADER GetById(SysEntities db, string id)
        { 
            return db.FILE_UPLOADER.SingleOrDefault(s => s.ID == id);
        
        }
        /// <summary>
        /// 通过预备方案id，判断器具是否为上传报告
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>附件</returns>
        public FILE_UPLOADER GetPREPARE_SCHEMEID(SysEntities db, string id)
        {
            return db.FILE_UPLOADER.FirstOrDefault(s => s.PREPARE_SCHEMEID== id);

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
        /// 删除一个附件
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条附件的主键</param>
        public void Delete(SysEntities db, string id)
        {
            FILE_UPLOADER deleteItem = GetById(db, id);
            if (deleteItem != null)
            { 
                db.FILE_UPLOADER.Remove(deleteItem);
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
            IQueryable<FILE_UPLOADER> collection = from f in db.FILE_UPLOADER
                    where deleteCollection.Contains(f.ID)
                    select f;
            foreach (var deleteItem in collection)
            {
                db.FILE_UPLOADER.Remove(deleteItem);
            }
        }

        /// <summary>
        /// 根据PREPARE_SCHEMEID，获取所有附件数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<FILE_UPLOADER> GetByRefPREPARE_SCHEMEID(SysEntities db, string id)
        {
            return from c in db.FILE_UPLOADER
                        where c.PREPARE_SCHEMEID == id
                        select c;
                      
        }

        public void Dispose()
        {          
        }
    }
}

