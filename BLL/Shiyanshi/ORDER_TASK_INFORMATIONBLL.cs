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
        /// 修改编号
        /// </summary>
        /// <param name="id">预备方案的主键</param>
        /// <returns>证书编号</returns>
        public bool UPORDER_NUMBER(string id)
        {
            ValidationErrors validationErrors = new ValidationErrors();
            String time = DateTime.Now.ToString("yyyy", DateTimeFormatInfo.InvariantInfo);//当前年
            ORDER_TASK_INFORMATION prepare = repository.GetById(id);//调用方法取数据
            decimal? ser = prepare.ORSERIALNUMBER;
            bool seria = true;
            ORDER_TASK_INFORMATION scheme = new ORDER_TASK_INFORMATION();
            if (ser == null)
            {
                decimal? max = repository.GetORSERIALNUMBERmax(db, time); //调用方法获取表格中最大的编号 
                if (max != null)
                {
                    scheme.ORSERIALNUMBER = max + 1;
                }
                else
                {
                    scheme.ORSERIALNUMBER = 1;
                }
                scheme.ORYEARS = time;
                scheme.ID = id;
                seria = EditField(ref validationErrors, scheme);

            }
            return seria;
        }

        /// <summary>
        ///获取委托单号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetORDER_NUMBER(string id)
        {
            String time = DateTime.Now.ToString("yyyy", DateTimeFormatInfo.InvariantInfo);//当前年
            ORDER_TASK_INFORMATION prepare = repository.GetById(id);//调用方法取数据
            string ORDER_NUMBER = string.Empty;//委托单号
            if (prepare.ORSERIALNUMBER != null)
            {
                string ORSERIALNUMBER = prepare.ORSERIALNUMBER.ToString();
                if (ORSERIALNUMBER.Length <= 2)
                {
                    ORSERIALNUMBER = ORSERIALNUMBER.PadLeft(3, '0');
                }
                ORDER_NUMBER = "DC" + time + ORSERIALNUMBER + "";
            }
            return ORDER_NUMBER;
        }
    }
}

