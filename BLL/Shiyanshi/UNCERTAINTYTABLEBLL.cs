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
    /// 不确定度 
    /// </summary>
    public partial class UNCERTAINTYTABLEBLL :  IBLL.IUNCERTAINTYTABLEBLL, IDisposable
    {
        public List<UNCERTAINTYTABLE> GetByASSESSMENTITEM(string UNCERTAINTYTABLE)
        {
            var queryData = from u in db.UNCERTAINTYTABLE
                            where u.ASSESSMENTITEM == UNCERTAINTYTABLE 
                            select u;

            return queryData.ToList();
        }
        /// <summary>
        /// 编辑计量标准装置检定/校准信息 
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">计量标准装置检定/校准信息 </param>
        /// <returns></returns>
        public bool EditField(ref ValidationErrors validationErrors, UNCERTAINTYTABLE entity)
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
        /// 编辑一个不确定度
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个不确定度</param>
        /// <returns></returns>
        public bool EditUpdate(ref ValidationErrors validationErrors, METERING_STANDARD_DEVICE entity)
        {
            try
            {
                var data = entity.UNCERTAINTYTABLE.Where(s => s.ID == null).ToList();
                var upda = entity.UNCERTAINTYTABLE.Where(s => s.ID != null).ToList();
                foreach (var item in upda)
                {
                    repository.EditField(db, item);
                }
                foreach (var item in data)
                {
                    item.ID = Result.GetNewId();
                    item.METERING_STANDARD_DEVICEID = entity.ID;
                    repository.Create(item);
                }
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

