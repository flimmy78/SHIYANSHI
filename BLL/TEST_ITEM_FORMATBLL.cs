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
    /// 检测项格式 
    /// </summary>
    public partial class TEST_ITEM_FORMATBLL :  IBLL.ITEST_ITEM_FORMATBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 检测项格式的数据库访问对象
        /// </summary>
        TEST_ITEM_FORMATRepository repository = new TEST_ITEM_FORMATRepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public TEST_ITEM_FORMATBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public TEST_ITEM_FORMATBLL(SysEntities entities)
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
        public List<TEST_ITEM_FORMAT> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            IQueryable<TEST_ITEM_FORMAT> queryData = repository.GetData(db, order, sort, search);
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
        /// 查询的数据 /*在6.0版本中 新增*/
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<TEST_ITEM_FORMAT> GetByParam(string id, string order, string sort, string search)
        {
            IQueryable<TEST_ITEM_FORMAT> queryData = repository.GetData(db, order, sort, search);
            
            return queryData.ToList();
        }
        /// <summary>
        /// 创建一个检测项格式
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个检测项格式</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, TEST_ITEM_FORMAT entity)
        {
            try
            {
                repository.Create(entity);
                return true;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        ///  创建检测项格式集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">检测项格式集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<TEST_ITEM_FORMAT> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int count = entitys.Count();
                    if (count == 1)
                    {
                        return this.Create(ref validationErrors, entitys.FirstOrDefault());
                    }
                    else if (count > 1)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        { 
                            repository.Create(db, entitys);
                            if (count == repository.Save(db))
                            {
                                transactionScope.Complete();
                                return true;
                            }
                            else
                            {
                                Transaction.Current.Rollback();
                            }                          
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        /// 删除一个检测项格式
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一检测项格式的主键</param>
        /// <returns></returns>  
        public bool Delete(ref ValidationErrors validationErrors, string id)
        {
            try
            {
                return repository.Delete(id) == 1;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        /// 删除检测项格式集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">检测项格式的集合</param>
        /// <returns></returns>    
        public bool DeleteCollection(ref ValidationErrors validationErrors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                { 
                        using (TransactionScope transactionScope = new TransactionScope())
                        { 
                            repository.Delete(db, deleteCollection);
                            if (deleteCollection.Length == repository.Save(db))
                            {
                                transactionScope.Complete();
                                return true;
                            }
                            else
                            {
                                Transaction.Current.Rollback();
                            }
                        }
                    }
             
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        ///  创建检测项格式集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">检测项格式集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<TEST_ITEM_FORMAT> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int count = entitys.Count();
                    if (count == 1)
                    {
                        return this.Edit(ref validationErrors, entitys.FirstOrDefault());
                    }
                    else if (count > 1)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        { 
                            repository.Edit(db, entitys);
                            if (count == repository.Save(db))
                            {
                                transactionScope.Complete();
                                return true;
                            }
                            else
                            {
                                Transaction.Current.Rollback();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
         /// <summary>
        /// 编辑一个检测项格式
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个检测项格式</param>
        /// <returns></returns>
        public bool Edit(ref ValidationErrors validationErrors, TEST_ITEM_FORMAT entity)
        {
            try
            { 
                repository.Edit(db, entity);
                repository.Save(db);
                return true;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
      
        public List<TEST_ITEM_FORMAT> GetAll()
        {           
            return repository.GetAll(db).ToList();          
        }   
        
        /// <summary>
        /// 根据主键获取一个检测项格式
        /// </summary>
        /// <param name="id">检测项格式的主键</param>
        /// <returns>一个检测项格式</returns>
        public TEST_ITEM_FORMAT GetById(string id)
        {           
            return repository.GetById(db, id);           
        }


        public void Dispose()
        {
           
        }
    }
}

