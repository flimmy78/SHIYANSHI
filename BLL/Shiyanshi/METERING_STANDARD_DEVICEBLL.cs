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
    /// 标准装置/计量标准器信息 
    /// </summary>
    public partial  class METERING_STANDARD_DEVICEBLL : IBLL.IMETERING_STANDARD_DEVICEBLL, IDisposable
    {
       
        /// <summary>
        /// 创建一个标准装置/计量标准器信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个标准装置/计量标准器信息</param>
        /// <returns></returns>
       public bool CreateX(ref ValidationErrors validationErrors, SysEntities db, METERING_STANDARD_DEVICE entity)
        {   
            repository.Create(db, entity);
            if (repository.Save(db)>0)
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
        /// 创建一个标准装置/计量标准器信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个标准装置/计量标准器信息</param>
        /// <returns></returns>
        public bool CreateX(ref ValidationErrors validationErrors, METERING_STANDARD_DEVICE entity)
        {
            try
            {
                //using (TransactionScope transactionScope = new TransactionScope())
                //{ 
                    if (CreateX(ref validationErrors, db, entity))
                    {
                        //transactionScope.Complete();
                        return true;
                    }
                    else
                    {
                        Transaction.Current.Rollback();
                    }
                //}
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }

        /// <summary>
        /// 编辑一个标准装置/计量标准器信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个标准装置/计量标准器信息</param>
        /// <returns></returns>
        public bool EditField(ref ValidationErrors validationErrors, METERING_STANDARD_DEVICE entity)
        {
            try
            {
                repository.EditField(db, entity);
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
    }
}

