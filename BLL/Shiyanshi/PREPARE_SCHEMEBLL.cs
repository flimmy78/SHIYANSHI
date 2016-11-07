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
    /// 预备方案  
    /// </summary>
    public partial class PREPARE_SCHEMEBLL : IBLL.IPREPARE_SCHEMEBLL, IDisposable
    {
        /// <summary>
        /// 修改编号
        /// </summary>
        /// <param name="id">预备方案的主键</param>
        /// <returns>证书编号</returns>
        public bool UPTSerialNumber(string id)
        {
            ValidationErrors validationErrors = new ValidationErrors();
            String time = DateTime.Now.ToString("yyyy", DateTimeFormatInfo.InvariantInfo);//当前年
            PREPARE_SCHEME prepare = repository.GetById(id);//调用方法取数据
            decimal? ser = prepare.SERIALNUMBER;
            bool seria = true;
            PREPARE_SCHEME scheme = new PREPARE_SCHEME();
            if (ser == null)
            {
                decimal? max = repository.GetSERIALNUMBERmax(db, time); //调用方法获取表格中最大的编号 
                if (max != null)
                {
                    scheme.SERIALNUMBER = max + 1;
                }
                else
                {
                    scheme.SERIALNUMBER = 1;
                }
                scheme.YEARS = time;
                scheme.ID = id;
                seria = EditField(ref validationErrors, scheme);

            }
            return seria;
        }

        /// <summary>
        ///获取证书编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetSerialNumber(string id)
        {
            String time = DateTime.Now.ToString("yyyy", DateTimeFormatInfo.InvariantInfo);//当前年
            PREPARE_SCHEME prepare = repository.GetById(id);//调用方法取数据
            string REPORTNUMBER = string.Empty;//证书编号
            if (prepare.SERIALNUMBER != null)
            {
                string SERIALNUMBER = prepare.SERIALNUMBER.ToString();
                SERIALNUMBER = SERIALNUMBER.PadLeft(4, '0');
                REPORTNUMBER = "DC/" + prepare.REPORT_CATEGORY + "-" + SERIALNUMBER + "-" + time;
            }
            return REPORTNUMBER;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="validationErrors"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditField(ref ValidationErrors validationErrors, PREPARE_SCHEME entity)
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

