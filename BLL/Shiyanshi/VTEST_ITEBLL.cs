using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;
using Langben.DAL.shiyanshi;

namespace Langben.BLL
{
    /// <summary>
    /// 预备方案检测项信息 
    /// </summary>
    public class VTEST_ITEBLL :  IBLL.IVTEST_ITEBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 预备方案检测项信息的数据库访问对象
        /// </summary>
        VTEST_ITERepository repository = new VTEST_ITERepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public VTEST_ITEBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public VTEST_ITEBLL(SysEntities entities)
        {
            db = entities;
        }
        /// <summary>
        /// 根据预备方案ID获取检测项信息
        /// </summary>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <returns></returns>
        public List<VTEST_ITE> GetByPREPARE_SCHEMEID(string PREPARE_SCHEMEID)
        {
            StringBuilder sb = new StringBuilder();
            if (PREPARE_SCHEMEID != null && PREPARE_SCHEMEID.Trim() != "")
            {
                sb.AppendFormat("PREPARE_SCHEMEID{0}&{1}^", ArgEnums.DDL_String, PREPARE_SCHEMEID);
            }
            if (sb.ToString().Trim() != "")
            {
                sb = sb.Remove(sb.ToString().Length - 1, 1);
            }
            List<DAL.VTEST_ITE> list = repository.GetData(db, "asc", "SORT", sb.ToString()).ToList();
            return list;
            //db.VTEST_ITE
            //var dt = (from f in db.VTEST_ITE
            //          where f.SCHEMEID == "1610041126146630519c6f9724683"
            //          select f).OrderBy(x => x.SCHEME_RULEID);
            //List<VTEST_ITE> list = dt.ToList<VTEST_ITE>();
            //IQueryable<VTEST_ITE> d = dt.Distinct();
            //return list;

        }
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<VTEST_ITE> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            IQueryable<VTEST_ITE> queryData = repository.GetData(db, order, sort, search);
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
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public List<VTEST_ITE> GetAll()
        {            
            return repository.GetAll(db).ToList();          
        }

        /// <summary>
        /// 根据主键，查看详细信息
        /// </summary>
        /// <param name="id">根据主键</param>
        /// <returns></returns>        
        public VTEST_ITE GetById(string id)
        {           
            return repository.GetById(id);
        }
        public void Dispose()
        {
           
        }
    }
}

