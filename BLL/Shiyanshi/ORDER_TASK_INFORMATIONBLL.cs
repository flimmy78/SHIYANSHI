using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;
using System.Globalization;

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

        /// <summary>
        /// 获取委托单号
        /// </summary>
        /// <param name="validationErrors"></param>
        /// <returns>委托单号*编号*年份</returns>
        public string GetORDER_NUMBER(ref ValidationErrors validationErrors)
        {
            String time = DateTime.Now.ToString("yyyy", DateTimeFormatInfo.InvariantInfo);//当前年
            string seria = string.Empty;
            decimal? ORSERIALNUMBER = 0;
            string ORSERIALNUMBER2 = string.Empty;
            string ORYEARS = string.Empty;
            string ORDER_NUMBER = string.Empty;
            decimal? max = repository.GetORSERIALNUMBERmax(db, time); //调用方法获取表格中最大的编号 
            if (max != null)
            {
                ORSERIALNUMBER = max + 1;
            }
            else
            {
                ORSERIALNUMBER = 1;
            }

            ORSERIALNUMBER2 = ORSERIALNUMBER.ToString().PadLeft(4, '0');

            ORDER_NUMBER = "DC" + time + ORSERIALNUMBER2 + "";
            seria = ORDER_NUMBER + "*" + ORSERIALNUMBER.ToString() + "*" + time;
            return seria;
        }
    }
}

