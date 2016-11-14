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
    /// 最大允许误差信息 
    /// </summary>
    public partial class ALLOWABLE_ERRORBLL :  IBLL.IALLOWABLE_ERRORBLL, IDisposable
    {
        /// <summary>
        /// 最大允许误差信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">最大允许误差信息 </param>
        /// <returns></returns>
        public bool EditField(ref ValidationErrors validationErrors, ALLOWABLE_ERROR entity)
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

