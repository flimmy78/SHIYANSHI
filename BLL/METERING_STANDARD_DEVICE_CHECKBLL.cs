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
    /// 计量标准装置检定/校准信息 
    /// </summary>
    public partial class METERING_STANDARD_DEVICE_CHECKBLL :  IBLL.IMETERING_STANDARD_DEVICE_CHECKBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 计量标准装置检定/校准信息的数据库访问对象
        /// </summary>
        METERING_STANDARD_DEVICE_CHECKRepository repository = new METERING_STANDARD_DEVICE_CHECKRepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public METERING_STANDARD_DEVICE_CHECKBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public METERING_STANDARD_DEVICE_CHECKBLL(SysEntities entities)
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
        public List<METERING_STANDARD_DEVICE_CHECK> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            IQueryable<METERING_STANDARD_DEVICE_CHECK> queryData = repository.GetData(db, order, sort, search);
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
                
                    foreach (var item in queryData)
                    {
                        if (item.METERING_STANDARD_DEVICEID != null && item.METERING_STANDARD_DEVICE != null)
                        { 
                                item.METERING_STANDARD_DEVICEIDOld = item.METERING_STANDARD_DEVICE.NAME.GetString();//                            
                        }                  

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
        public List<METERING_STANDARD_DEVICE_CHECK> GetByParam(string id, string order, string sort, string search)
        {
            IQueryable<METERING_STANDARD_DEVICE_CHECK> queryData = repository.GetData(db, order, sort, search);
            
            return queryData.ToList();
        }
        /// <summary>
        /// 创建一个计量标准装置检定/校准信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个计量标准装置检定/校准信息</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, METERING_STANDARD_DEVICE_CHECK entity)
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
        ///  创建计量标准装置检定/校准信息集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">计量标准装置检定/校准信息集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<METERING_STANDARD_DEVICE_CHECK> entitys)
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
        /// 删除一个计量标准装置检定/校准信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一计量标准装置检定/校准信息的主键</param>
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
        /// 删除计量标准装置检定/校准信息集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">计量标准装置检定/校准信息的集合</param>
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
        ///  创建计量标准装置检定/校准信息集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">计量标准装置检定/校准信息集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<METERING_STANDARD_DEVICE_CHECK> entitys)
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
        /// 编辑一个计量标准装置检定/校准信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个计量标准装置检定/校准信息</param>
        /// <returns></returns>
        public bool Edit(ref ValidationErrors validationErrors, METERING_STANDARD_DEVICE_CHECK entity)
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
      
        public List<METERING_STANDARD_DEVICE_CHECK> GetAll()
        {           
            return repository.GetAll(db).ToList();          
        }   
        
        /// <summary>
        /// 根据主键获取一个计量标准装置检定/校准信息
        /// </summary>
        /// <param name="id">计量标准装置检定/校准信息的主键</param>
        /// <returns>一个计量标准装置检定/校准信息</returns>
        public METERING_STANDARD_DEVICE_CHECK GetById(string id)
        {           
            return repository.GetById(db, id);           
        }


        /// <summary>
        /// 根据METERING_STANDARD_DEVICEIDId，获取所有计量标准装置检定/校准信息数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<METERING_STANDARD_DEVICE_CHECK> GetByRefMETERING_STANDARD_DEVICEID(string id)
        {
            return repository.GetByRefMETERING_STANDARD_DEVICEID(db, id).ToList();                      
        }

        public void Dispose()
        {
           
        }
    }
}

