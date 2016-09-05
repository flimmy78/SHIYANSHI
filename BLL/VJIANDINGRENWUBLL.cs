using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;

namespace Langben.BLL
{
    /// <summary>
    /// 检定任务 
    /// </summary>
    public partial class VJIANDINGRENWUBLL :  IBLL.IVJIANDINGRENWUBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 检定任务的数据库访问对象
        /// </summary>
        VJIANDINGRENWURepository repository = new VJIANDINGRENWURepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public VJIANDINGRENWUBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public VJIANDINGRENWUBLL(SysEntities entities)
        {
            db = entities;
        }
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">升序asc（默认）还是降序desc</param>
        /// <param name="sort">排序字段</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<VJIANDINGRENWU> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            IQueryable<VJIANDINGRENWU> queryData = repository.GetData(db, order, sort, search);
            total = queryData.Count();
            if (total > 0)
            {
                if (page <= 1)
                {
                    queryData = queryData.Take(rows);
                }
                else
                {
                    queryData = queryData.Skip((page - 1) * rows).Take(rows);
                }
                 
            }
            return queryData.ToList();
        }

        /// <summary>
        /// 根据主键获取一个检定任务
        /// </summary>
        /// <param name="id">检定任务的主键</param>
        /// <returns>一个检定任务</returns>
        public VJIANDINGRENWU GetById(string id)
        {
            return repository.GetById(db, id);
        }
        public List<VJIANDINGRENWU> GetAll()
        {
            SysEntities db = new SysEntities();            
            return repository.GetAll(db).ToList();          
        }   
        public void Dispose()
        {
           
        }
    }
}

