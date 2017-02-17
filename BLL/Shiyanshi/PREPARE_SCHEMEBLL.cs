using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;
using System.Globalization;
using Langben.Report;

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
        /// 报告生成发送审核
        /// </summary>
        /// <param name="validationErrors"></param>
        /// <param name="entity"></param>
        public bool EditField1(ref ValidationErrors validationErrors, PREPARE_SCHEME entity, string CreatePerson = "")
        {
            try
            {

              //  string Message = "";
                ReportBLL reportBll = new ReportBLL();
                //bool IsSuccess = reportBll.ExportReport(entity.ID, out Message, CreatePerson,true);
               // bool IsSuccess = reportBll.ExportAndSavePath(entity.ID, out Message, CreatePerson);
               // if (IsSuccess)
               // {
                    repository.EditField(db, entity);
                    repository.Save(db);
                    return true;
               // }
              //  else
               // {
              //      throw new Exception(Message);
               // }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);
            }
            return false;
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

        /// <summary>
        /// 建立方案保存下一步
        /// </summary>
        /// <param name="validationErrors"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditInst(ref ValidationErrors validationErrors, PREPARE_SCHEME entity)
        {
            try
            {
                if (entity == null)
                {
                    return false;
                }
                List<string> addMETERING_STANDARD_DEVICEID = new List<string>();
                List<string> deleteMETERING_STANDARD_DEVICEID = new List<string>();
                PREPARE_SCHEME prepare = null;
                if (entity != null)
                {
                    prepare = repository.GetById(entity.ID);
                }
                DataOfDiffrent.GetDiffrent(entity.METERING_STANDARD_DEVICEID.GetIdSort(), entity.METERING_STANDARD_DEVICEIDOld.GetIdSort(), ref addMETERING_STANDARD_DEVICEID, ref deleteMETERING_STANDARD_DEVICEID);

                PREPARE_SCHEME editEntity = repository.EditInst(db, entity);

                if (addMETERING_STANDARD_DEVICEID != null && addMETERING_STANDARD_DEVICEID.Count() > 0)
                {
                    foreach (var item in addMETERING_STANDARD_DEVICEID)
                    {
                        STANDARDCHOICE sys = new STANDARDCHOICE
                        {
                            ID = Result.GetNewId(),
                            PREPARE_SCHEMEID = entity.ID,
                            METERING_STANDARD_DEVICEID = item.Split('*')[0],
                            GROUPS = item.Split('*')[1],
                            TYPE = item.Split('*')[2],
                            NAMES = item.Split('*')[3],
                            CREATEPERSON=entity.CREATEPERSON,
                            CREATETIME=entity.CREATETIME
                        };
                        //db.STANDARDCHOICE.Attach(sys);
                        editEntity.STANDARDCHOICE.Add(sys);
                    }
                }
                if (deleteMETERING_STANDARD_DEVICEID != null && deleteMETERING_STANDARD_DEVICEID.Count() > 0)
                {
                    foreach (var item in deleteMETERING_STANDARD_DEVICEID)
                    {
                        string ID = item.Split('*')[0];                       
                         
                        STANDARDCHOICE sys = new STANDARDCHOICE() { ID=ID};
                        
                        db.STANDARDCHOICE.Attach(sys);
                        editEntity.STANDARDCHOICE.Remove(sys);
                        db.STANDARDCHOICE.Remove(sys);

                    }


                }
                #region 更新了引用方案，需要删除原方案数据所录入的数据
                if(prepare!=null && !string.IsNullOrWhiteSpace(prepare.SCHEMEID) && prepare.SCHEMEID!=entity.SCHEMEID)
                {

                    List<QUALIFIED_UNQUALIFIED_TEST_ITE> deleteQUALIFIED_UNQUALIFIED_TEST_ITEList = (from f in db.QUALIFIED_UNQUALIFIED_TEST_ITE
                                                 where f.PREPARE_SCHEMEID == entity.ID
                                                 select f).ToList();
                    db.QUALIFIED_UNQUALIFIED_TEST_ITE.RemoveRange(deleteQUALIFIED_UNQUALIFIED_TEST_ITEList);
                }
                #endregion 
               
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

