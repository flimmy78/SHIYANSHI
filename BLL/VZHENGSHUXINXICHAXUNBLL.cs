﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;

namespace Langben.BLL
{
    /// <summary>
    /// 证书信息查询 
    /// </summary>
    public class VZHENGSHUXINXICHAXUNBLL :  IBLL.IVZHENGSHUXINXICHAXUNBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 证书信息查询的数据库访问对象
        /// </summary>
        VZHENGSHUXINXICHAXUNRepository repository = new VZHENGSHUXINXICHAXUNRepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public VZHENGSHUXINXICHAXUNBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public VZHENGSHUXINXICHAXUNBLL(SysEntities entities)
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
        public List<VZHENGSHUXINXICHAXUN> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            IQueryable<VZHENGSHUXINXICHAXUN> queryData = repository.GetData(db, order, sort, search);
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

        public VZHENGSHUXINXICHAXUN GetById(string id)
        {
            return repository.GetById(db, id);
        }
        public List<VZHENGSHUXINXICHAXUN> GetAll()
        {
            SysEntities db = new SysEntities();            
            return repository.GetAll(db).ToList();          
        }   
        public void Dispose()
        {
           
        }
    }
}

