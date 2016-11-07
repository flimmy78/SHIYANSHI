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
    /// 委托单信息 
    /// </summary>
    public partial class ORDER_TASK_INFORMATIONBLL : IBLL.IORDER_TASK_INFORMATIONBLL, IDisposable
    {

        /// <summary>
        /// 编辑一个委托单信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个委托单信息</param>
        /// <returns></returns>
        public bool EditField(ref ValidationErrors validationErrors, ORDER_TASK_INFORMATION entity)
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
        public bool EditSTATUS(ref ValidationErrors validationErrors, string id, SIGN sign)
        {
            try
            {
                repository.EditSTATUS(db, id, sign);
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

