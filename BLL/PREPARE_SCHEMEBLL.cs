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
    /// 预备方案 
    /// </summary>
    public partial  class PREPARE_SCHEMEBLL : IBLL.IPREPARE_SCHEMEBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 预备方案的数据库访问对象
        /// </summary>
        PREPARE_SCHEMERepository repository = new PREPARE_SCHEMERepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public PREPARE_SCHEMEBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public PREPARE_SCHEMEBLL(SysEntities entities)
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
        public List<PREPARE_SCHEME> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {

            
            IQueryable<PREPARE_SCHEME> queryData = repository.GetData(db, order, sort, search);
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
                        if (item.SCHEMEID != null && item.SCHEME != null)
                        { 
                                item.SCHEMEIDOld = item.SCHEME.NAME.GetString();//                            
                        }                  
 
                        if (item.METERING_STANDARD_DEVICE != null)
                        {
                            item.METERING_STANDARD_DEVICEID = string.Empty;
                            foreach (var it in item.METERING_STANDARD_DEVICE)
                            {
                                item.METERING_STANDARD_DEVICEID += it.NAME + ' ';
                            }                         
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
        public List<PREPARE_SCHEME> GetByParam(string id, string order, string sort, string search)
        {
            IQueryable<PREPARE_SCHEME> queryData = repository.GetData(db, order, sort, search);
            
            return queryData.ToList();
        }
        /// <summary>
        /// 创建一个预备方案
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个预备方案</param>
        /// <returns></returns>
       public bool Create(ref ValidationErrors validationErrors, SysEntities db, PREPARE_SCHEME entity)
        {   
            int count = 1;
        
            foreach (string item in entity.METERING_STANDARD_DEVICEID.GetIdSort())
            {
                METERING_STANDARD_DEVICE sys = new METERING_STANDARD_DEVICE { ID = item };
                db.METERING_STANDARD_DEVICE.Attach(sys);
                entity.METERING_STANDARD_DEVICE.Add(sys);
                count++;
            }

            repository.Create(db, entity);
            if (count == repository.Save(db))
            {
                return true;
            }
            else
            {
                validationErrors.Add("创建出错了");
            }
            return false;
        }
        /// <summary>
        /// 创建一个预备方案
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个预备方案</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, PREPARE_SCHEME entity)
        {
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                { 
                    if (Create(ref validationErrors, db, entity))
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
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        ///  创建预备方案集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">预备方案集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<PREPARE_SCHEME> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int flag = 0, count = entitys.Count();
                    if (count > 0)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        {
                            foreach (var entity in entitys)
                            {
                                if (Create(ref validationErrors, db, entity))
                                {
                                    flag++;
                                }
                                else
                                {
                                    Transaction.Current.Rollback();
                                    return false;
                                }
                            }
                            if (count == flag)
                            {
                                transactionScope.Complete();
                                return true;
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
        /// 删除一个预备方案
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一个预备方案的主键</param>
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
        /// 删除预备方案集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">主键的预备方案</param>
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
        ///  创建预备方案集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">预备方案集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<PREPARE_SCHEME> entitys)
        {
            if (entitys != null)
            {
                try
                {
                    int flag = 0, count = entitys.Count();
                    if (count > 0)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        {
                            foreach (var entity in entitys)
                            {
                                if (Edit(ref validationErrors, db, entity))
                                {
                                    flag++;
                                }
                                else
                                {
                                    Transaction.Current.Rollback();
                                    return false;
                                }
                            }
                            if (count == flag)
                            {
                                transactionScope.Complete();
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    validationErrors.Add(ex.Message);
                    ExceptionsHander.WriteExceptions(ex);                
                }
            }
            return false;
        }
        /// <summary>
        /// 编辑一个预备方案
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据上下文</param>
        /// <param name="entity">一个预备方案</param>
        /// <returns>是否编辑成功</returns>
       public bool Edit(ref ValidationErrors validationErrors, SysEntities db, PREPARE_SCHEME entity)
        {  /*                       
                           * 不操作 原有 现有
                           * 增加   原没 现有
                           * 删除   原有 现没
                           */
            if (entity == null)
            {
                return false;
            }
            int count = 1;            
            
            List<string> addMETERING_STANDARD_DEVICEID = new List<string>();
            List<string> deleteMETERING_STANDARD_DEVICEID = new List<string>();
            DataOfDiffrent.GetDiffrent(entity.METERING_STANDARD_DEVICEID.GetIdSort(), entity.METERING_STANDARD_DEVICEIDOld.GetIdSort(), ref addMETERING_STANDARD_DEVICEID, ref deleteMETERING_STANDARD_DEVICEID);
            List<METERING_STANDARD_DEVICE> listEntityMETERING_STANDARD_DEVICE = new List<METERING_STANDARD_DEVICE>();
            if (deleteMETERING_STANDARD_DEVICEID != null && deleteMETERING_STANDARD_DEVICEID.Count() > 0)
            {                
                foreach (var item in deleteMETERING_STANDARD_DEVICEID)
                {
                    METERING_STANDARD_DEVICE sys = new METERING_STANDARD_DEVICE { ID = item };
                    listEntityMETERING_STANDARD_DEVICE.Add(sys);
                    entity.METERING_STANDARD_DEVICE.Add(sys);
                }                
            } 

            PREPARE_SCHEME editEntity = repository.Edit(db, entity);
            
         
            if (addMETERING_STANDARD_DEVICEID != null && addMETERING_STANDARD_DEVICEID.Count() > 0)
            {
                foreach (var item in addMETERING_STANDARD_DEVICEID)
                {
                    METERING_STANDARD_DEVICE sys = new METERING_STANDARD_DEVICE { ID = item };
                    db.METERING_STANDARD_DEVICE.Attach(sys);
                    editEntity.METERING_STANDARD_DEVICE.Add(sys);
                    count++;
                }
            }
            if (deleteMETERING_STANDARD_DEVICEID != null && deleteMETERING_STANDARD_DEVICEID.Count() > 0)
            { 
                foreach (METERING_STANDARD_DEVICE item in listEntityMETERING_STANDARD_DEVICE)
                {
                    editEntity.METERING_STANDARD_DEVICE.Remove(item);
                    count++;
                }
            } 

            if (count == repository.Save(db))
            {
                return true;
            }
            else
            {
                validationErrors.Add("编辑预备方案出错了");
            }
            return false;
        }
        /// <summary>
        /// 编辑一个预备方案
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个预备方案</param>
        /// <returns>是否编辑成功</returns>
        public bool Edit(ref ValidationErrors validationErrors, PREPARE_SCHEME entity)
        {           
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                { 
                    if (Edit(ref validationErrors, db, entity))
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
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        public List<PREPARE_SCHEME> GetAll()
        {            
            return repository.GetAll(db).ToList();          
        }     
        
        /// <summary>
        /// 根据主键获取一个预备方案
        /// </summary>
        /// <param name="id">预备方案的主键</param>
        /// <returns>一个预备方案</returns>
        public PREPARE_SCHEME GetById(string id)
        {          
            return repository.GetById(db, id);           
        }
        
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<METERING_STANDARD_DEVICE> GetRefMETERING_STANDARD_DEVICE(string id)
        { 
            return repository.GetRefMETERING_STANDARD_DEVICE(db, id).ToList();
        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<METERING_STANDARD_DEVICE> GetRefMETERING_STANDARD_DEVICE()
        { 
            return repository.GetRefMETERING_STANDARD_DEVICE(db).ToList();
        }

        
        /// <summary>
        /// 根据SCHEMEIDId，获取所有预备方案数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<PREPARE_SCHEME> GetByRefSCHEMEID(string id)
        {
            return repository.GetByRefSCHEMEID(db, id).ToList();                      
        }

        public void Dispose()
        {
           
        }
    }
}

