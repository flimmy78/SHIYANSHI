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
    /// 获取检测项目 
    /// </summary>
    public class VRULEBLL : IBLL.IVRULEBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 预备方案检测项信息的数据库访问对象
        /// </summary>
        VRULERepository repository = new VRULERepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public VRULEBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public VRULEBLL(SysEntities entities)
        {
            db = entities;
        }
        /// <summary>
        /// 根据方案ID获取检测项信息
        /// </summary>       
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public List<VRULE> GetBySCHEMEID(string SCHEMEID)
        {
            BLL.SCHEMEBLL sBLL = new SCHEMEBLL();
            DAL.SCHEME sModel = sBLL.GetById(SCHEMEID);
            if(sModel==null)
            {
                return null;
            }

            List<DAL.VRULE> list = (from m in db.VRULE
                        where m.UNDERTAKE_LABORATORYID == sModel.UNDERTAKE_LABORATORYID &&
                              m.SCHEMEID==SCHEMEID
                    orderby m.SORT ascending
                    select m).ToList();
            return list;

            //StringBuilder sb = new StringBuilder();
            //if (SCHEMEID != null && SCHEMEID.Trim() != "")
            //{
            //    sb.AppendFormat("SCHEMEID{0}&{1}^", ArgEnums.DDL_String, SCHEMEID);
            //}
            //if (sb.ToString().Trim() != "")
            //{
            //    sb = sb.Remove(sb.ToString().Length - 1, 1);
            //}
            //List<DAL.VRULE> list = repository.GetData(db, "asc", "SORT", sb.ToString()).ToList();            
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
        public List<VRULE> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            IQueryable<VRULE> queryData = repository.GetData(db, order, sort, search);
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
        /// 通过主键id，检测项目
        /// </summary>
        /// <param name="RULEID">主键</param>
        /// <returns>通过主键id，检测项目</returns>    
        public VRULE GetById(string RULEID = "")
        {
            return repository.GetById(db, RULEID);
        }
        public void Dispose()
        {

        }
    }
}
