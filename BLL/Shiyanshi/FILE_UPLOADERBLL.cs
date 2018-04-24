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
    /// 附件 
    /// </summary>
    public partial class FILE_UPLOADERBLL :  IBLL.IFILE_UPLOADERBLL, IDisposable
    {
       
         /// <summary>
        /// 编辑一个附件
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个附件</param>
        /// <returns></returns>
        public bool EditField(ref ValidationErrors validationErrors, FILE_UPLOADER entity)
        {
            try
            { 
                repository.EditField(db, entity);
                Langben.Report.ReportBLL re = new Langben.Report.ReportBLL();
                string err  = string.Empty;
                re.UpdateFuJianRemark(entity.PREPARE_SCHEMEID, out  err);
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

