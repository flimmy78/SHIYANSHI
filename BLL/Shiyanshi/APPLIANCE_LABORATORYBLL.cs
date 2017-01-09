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
        /// 编辑一个器具明细信息_承接实验室(公用)
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个器具明细信息_承接实验室</param>
        /// <returns></returns>
        public bool EditField(ref ValidationErrors validationErrors, APPLIANCE_LABORATORY entity)
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

        
        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">器具明细信息的集合</param>
        /// <returns></returns>    
        public bool EditSTORAGEINSTRUCTI_STATU(ref ValidationErrors validationErrors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    //using (TransactionScope transactionScope = new TransactionScope())
                    {
                        repository.EditSTORAGEINSTRUCTI_STATU(db, deleteCollection);
                        if (deleteCollection.Length == repository.Save(db))
                        {
                            //transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            //Transaction.Current.Rollback();
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
    }
}

