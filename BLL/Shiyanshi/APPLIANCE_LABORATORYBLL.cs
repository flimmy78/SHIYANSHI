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
    public partial class APPLIANCE_LABORATORYBLL : IBLL.IAPPLIANCE_LABORATORYBLL, IDisposable
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
        public string GetYuanShiJILu(ref ValidationErrors validationErrors, string id, string shiyanshi)
        {
            try
            {
                var data = (from f in db.APPLIANCE_LABORATORY
                            where f.APPLIANCE_DETAIL_INFORMATIONID == id && f.UNDERTAKE_LABORATORYID == shiyanshi
                            select f).First();

                var file = db.FILE_UPLOADER.Where(w => w.PREPARE_SCHEMEID == data.PREPARE_SCHEMEID && w.STATE != "已上传").OrderBy(o => o.CREATETIME).FirstOrDefault();
                if (file!=null)
                {
                    return file.PATH2;
                }
            
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);
            }
            return string.Empty;
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

