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
    /// 实验室别工作量统计分析 
    /// </summary>
    public class VSHIYANSHIGONGZUOLIANGBLL :  IBLL.IVSHIYANSHIGONGZUOLIANGBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 实验室别工作量统计分析的数据库访问对象
        /// </summary>
        VSHIYANSHIGONGZUOLIANGRepository repository = new VSHIYANSHIGONGZUOLIANGRepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public VSHIYANSHIGONGZUOLIANGBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public VSHIYANSHIGONGZUOLIANGBLL(SysEntities entities)
        {
            db = entities;
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
        public List<SHIYANSHIGONGZUO_Result> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
          return  repository.GetData(db, order, sort, search,id);
             
        }
        /// <summary>
        /// 人员查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<RENYUANGONGZUOLIANG_Result> GetByParamRE(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            return repository.GetDataRE(db, order, sort, search, id);

        }
        /// <summary>
        /// 人员查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<ZHENGSHUHAOLEIBIE_Result> GetByParamZH(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            return repository.GetDataZH(db, order, sort, search, id);

        }

        public List<VSHIYANSHIGONGZUOLIANG> GetAll()
        {
            SysEntities db = new SysEntities();            
            return repository.GetAll(db).ToList();          
        }   
        public void Dispose()
        {
           
        }
    }
}

