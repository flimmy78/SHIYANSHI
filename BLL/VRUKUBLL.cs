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
    /// 入库 
    /// </summary>
    public partial class VRUKUBLL :  IBLL.IVRUKUBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 入库的数据库访问对象
        /// </summary>
        VRUKURepository repository = new VRUKURepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public VRUKUBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public VRUKUBLL(SysEntities entities)
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
        public List<VRUKU> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            IQueryable<VRUKU> queryData = repository.GetData(db, order, sort, search);
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
        /// 根据主键获取一个入库
        /// </summary>
        /// <param name="id">入库的主键</param>
        /// <returns>一个入库</returns>
        public VRUKU GetById(string id)
        {
            return repository.GetById(db, id);
        }
        public List<VRUKU> GetAll()
        {
            SysEntities db = new SysEntities();            
            return repository.GetAll(db).ToList();          
        }   
        public void Dispose()
        {
           
        }
    }
}

