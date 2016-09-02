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
    /// 器具明细信息_承接实验室 
    /// </summary>
    public partial class APPLIANCE_LABORATORYBLL :  IBLL.IAPPLIANCE_LABORATORYBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 器具明细信息_承接实验室的数据库访问对象
        /// </summary>
        APPLIANCE_LABORATORYRepository repository = new APPLIANCE_LABORATORYRepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public APPLIANCE_LABORATORYBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public APPLIANCE_LABORATORYBLL(SysEntities entities)
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
        public List<APPLIANCE_LABORATORY> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            IQueryable<APPLIANCE_LABORATORY> queryData = repository.GetData(db, order, sort, search);
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
                        if (item.UNDERTAKE_LABORATORYID != null && item.UNDERTAKE_LABORATORY != null)
                        { 
                                item.UNDERTAKE_LABORATORYIDOld = item.UNDERTAKE_LABORATORY.NAME.GetString();//                            
                        }                  

                        if (item.APPLIANCE_DETAIL_INFORMATIONID != null && item.APPLIANCE_DETAIL_INFORMATION != null)
                        { 
                                item.APPLIANCE_DETAIL_INFORMATIOIDOld = item.APPLIANCE_DETAIL_INFORMATION.BAR_CODE_NUM.GetString();//                            
                        }                  

                        if (item.PREPARE_SCHEMEID != null && item.PREPARE_SCHEME != null)
                        { 
                                item.PREPARE_SCHEMEIDOld = item.PREPARE_SCHEME.REPORT_CATEGORY.GetString();//                            
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
        /// <param name="order">升序asc（默认）还是降序desc</param>
        /// <param name="sort">排序字段</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<APPLIANCE_LABORATORY> GetByParam(string id, string order, string sort, string search)
        {
            IQueryable<APPLIANCE_LABORATORY> queryData = repository.GetData(db, order, sort, search);
            
            return queryData.ToList();
        }
        /// <summary>
        /// 创建一个器具明细信息_承接实验室
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个器具明细信息_承接实验室</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, APPLIANCE_LABORATORY entity)
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
        ///  创建器具明细信息_承接实验室集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">器具明细信息_承接实验室集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<APPLIANCE_LABORATORY> entitys)
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
        /// 删除一个器具明细信息_承接实验室
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一器具明细信息_承接实验室的主键</param>
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
        /// 删除器具明细信息_承接实验室集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">器具明细信息_承接实验室的集合</param>
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
        ///  创建器具明细信息_承接实验室集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">器具明细信息_承接实验室集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<APPLIANCE_LABORATORY> entitys)
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
        /// 编辑一个器具明细信息_承接实验室
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个器具明细信息_承接实验室</param>
        /// <returns></returns>
        public bool Edit(ref ValidationErrors validationErrors, APPLIANCE_LABORATORY entity)
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
      
        public List<APPLIANCE_LABORATORY> GetAll()
        {           
            return repository.GetAll(db).ToList();          
        }   
        
        /// <summary>
        /// 根据主键获取一个器具明细信息_承接实验室
        /// </summary>
        /// <param name="id">器具明细信息_承接实验室的主键</param>
        /// <returns>一个器具明细信息_承接实验室</returns>
        public APPLIANCE_LABORATORY GetById(string id)
        {           
            return repository.GetById(db, id);           
        }


        /// <summary>
        /// 根据UNDERTAKE_LABORATORYIDId，获取所有器具明细信息_承接实验室数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<APPLIANCE_LABORATORY> GetByRefUNDERTAKE_LABORATORYID(string id)
        {
            return repository.GetByRefUNDERTAKE_LABORATORYID(db, id).ToList();                      
        }

        /// <summary>
        /// 根据APPLIANCE_DETAIL_INFORMATIOIDId，获取所有器具明细信息_承接实验室数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<APPLIANCE_LABORATORY> GetByRefAPPLIANCE_DETAIL_INFORMATIOID(string id)
        {
            return repository.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(db, id).ToList();                      
        }

        /// <summary>
        /// 根据PREPARE_SCHEMEIDId，获取所有器具明细信息_承接实验室数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<APPLIANCE_LABORATORY> GetByRefPREPARE_SCHEMEID(string id)
        {
            return repository.GetByRefPREPARE_SCHEMEID(db, id).ToList();                      
        }

        public void Dispose()
        {
           
        }
    }
}

