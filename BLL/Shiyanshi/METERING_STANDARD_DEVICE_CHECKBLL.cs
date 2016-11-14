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
        /// 编辑计量标准装置检定/校准信息 
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">计量标准装置检定/校准信息 </param>
        /// <returns></returns>
        public bool EditField(ref ValidationErrors validationErrors, METERING_STANDARD_DEVICE_CHECK entity)
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

