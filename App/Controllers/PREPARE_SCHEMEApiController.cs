using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using System.Web.Http;
using Langben.App.Models;
using Newtonsoft.Json;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 预备方案
    /// </summary>
    public class PREPARE_SCHEMEApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        /// 
        [System.Web.Http.HttpPost]
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<PREPARE_SCHEME> queryData = m_BLL.GetByParam(null, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    REPORT_CATEGORY = s.REPORT_CATEGORY
                    ,
                    CERTIFICATE_CATEGORY = s.CERTIFICATE_CATEGORY
                    ,
                    CNAS = s.CNAS
                    ,
                    CONTROL_NUMBER = s.CONTROL_NUMBER
                    ,
                    CERTIFICATION_AUTHORITY = s.CERTIFICATION_AUTHORITY
                    ,
                    QUALIFICATIONS = s.QUALIFICATIONS
                    ,
                    TEMPERATURE = s.TEMPERATURE
                    ,
                    HUMIDITY = s.HUMIDITY
                    ,
                    CHECK_PLACE = s.CHECK_PLACE
                    ,
                    CHECKERID = s.CHECKERID
                    ,
                    DETECTERID = s.DETECTERID
                    ,
                    APPROVALID = s.APPROVALID
                    ,
                    CALIBRATION_DATE = s.CALIBRATION_DATE
                    ,
                    CONCLUSION = s.CONCLUSION
                    ,
                    CONCLUSION_EXPLAIN = s.CONCLUSION_EXPLAIN
                    ,
                    VALIDITY_PERIOD = s.VALIDITY_PERIOD
                    ,
                    CALIBRATION_INSTRUCTIONS = s.CALIBRATION_INSTRUCTIONS
                    ,
                    ACCURACY_GRADE = s.ACCURACY_GRADE
                    ,
                    RATED_FREQUENCY = s.RATED_FREQUENCY
                    ,
                    PULSE_CONSTANT = s.PULSE_CONSTANT
                    ,
                    EXTERNAL_RESITANCE_VALUE = s.EXTERNAL_RESITANCE_VALUE
                    ,
                    SCHEMEID = s.SCHEMEIDOld
                    ,
                    CREATETIME = s.CREATETIME
                    ,
                    CREATEPERSON = s.CREATEPERSON
                    ,
                    UPDATETIME = s.UPDATETIME
                    ,
                    UPDATEPERSON = s.UPDATEPERSON
                    ,
                    AUDITOPINION = s.AUDITOPINION
                    ,
                    AUDITTIME = s.AUDITTIME
                    ,
                    AUDITTEPERSON = s.AUDITTEPERSON
                    ,
                    ISAGGREY = s.ISAGGREY
                    ,
                    APPROVAL = s.APPROVAL
                    ,
                    APPROVALDATE = s.APPROVALDATE
                    ,
                    APPROVALEPERSON = s.APPROVALEPERSON
                    ,
                    APPROVALISAGGREY = s.APPROVALISAGGREY
                    ,
                    PRINTSTATUS = s.PRINTSTATUS
                    ,
                    ISBACK = s.ISBACK
                    ,
                    REPORTNUMBER = s.REPORTNUMBER
                    ,
                    REPORTSTATUS = s.REPORTSTATUS


                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public PREPARE_SCHEME Get(string id)
        {
            PREPARE_SCHEME item = m_BLL.GetById(id);
            return item;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        //[HttpPost]
        [System.Web.Http.HttpPost]
        public Common.ClientResult.Result Post([FromBody]PREPARE_SCHEME entity)
        {
            string putid = entity.ID;
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            if (entity != null && ModelState.IsValid)
            {
                //string currentPerson = GetCurrentPerson();
                entity.CREATETIME = DateTime.Now;
                // entity.CREATEPERSON = currentPerson;
                //修改证书编号
               
                entity.ID = Result.GetNewId();
                string returnValue = string.Empty;
                APPLIANCE_LABORATORY app = new APPLIANCE_LABORATORY();
                app.ID = entity.APPLIANCE_LABORATORYID;
                app.PREPARE_SCHEMEID = entity.ID;
                if (!string.IsNullOrEmpty(putid))//判断是否为第二次进入
                {
                    //修改
                    entity.ID = putid;
                    if (m_BLL.Edit(ref validationErrors, entity) && m_BLL.UPTSerialNumber(entity.ID))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，预备方案信息的Id为" + entity.ID, "预备方案"
                            );//写入日志                   
                        result.Code = Common.ClientCode.Succeed;
                        result.Message = Suggestion.UpdateSucceed;
                        result.Id = entity.ID;
                        return result; //提示更新成功 
                    }
                    else
                    {
                        if (validationErrors != null && validationErrors.Count > 0)
                        {
                            validationErrors.All(a =>
                            {
                                returnValue += a.ErrorMessage;
                                return true;
                            });
                        }
                        LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，预备方案信息的Id为" + entity.ID + "," + returnValue, "预备方案"
                            );//写入日志   
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.UpdateFail + returnValue;
                        return result; //提示更新失败
                    }                    
                }
                //新增
                if (m_BLL.Create(ref validationErrors, entity) && m_BLL2.EditField(ref validationErrors, app) && m_BLL.UPTSerialNumber(entity.ID))
                {
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，预备方案的信息的Id为" + entity.ID, "预备方案"
                        );//写入日志 
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.InsertSucceed;
                    result.Id = entity.ID;
                    return result; //提示创建成功
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，预备方案的信息，" + returnValue, "预备方案"
                        );//写入日志                      
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.InsertFail + returnValue;
                    return result; //提示插入失败
                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            return result;
        }

        // PUT api/<controller>/5
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [System.Web.Http.HttpPut]
        public Common.ClientResult.Result Put([FromBody]PREPARE_SCHEME entity)
        {
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                //string currentPerson = GetCurrentPerson();
                entity.UPDATETIME = DateTime.Now;
               // entity.UPDATEPERSON = currentPerson;

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，预备方案信息的Id为" + entity.ID, "预备方案"
                        );//写入日志                   
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.UpdateSucceed;
                    result.Id = entity.ID;
                    return result; //提示更新成功 
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，预备方案信息的Id为" + entity.ID + "," + returnValue, "预备方案"
                        );//写入日志   
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return result; //提示更新失败
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return result; //提示输入的数据的格式不对         
        }

        // PUT api/<controller>/5
        /// <summary>
        /// 编辑(公用)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [System.Web.Http.HttpPut]
        public Common.ClientResult.Result EditField([FromBody]PREPARE_SCHEME entity)
        {
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                string currentPerson = GetCurrentPerson();
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = currentPerson;

                string returnValue = string.Empty;
                if (m_BLL.EditField(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，预备方案信息的Id为" + entity.ID, "预备方案"
                        );//写入日志                   
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.UpdateSucceed;
                    result.Id = entity.ID;
                    return result; //提示更新成功 
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，预备方案信息的Id为" + entity.ID + "," + returnValue, "预备方案"
                        );//写入日志   
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return result; //提示更新失败
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return result; //提示输入的数据的格式不对         
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>  
        [System.Web.Http.HttpDelete]
        public Common.ClientResult.Result Delete(string query)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            string returnValue = string.Empty;
            string[] deleteId = query.GetString().Split(',');
            if (deleteId != null && deleteId.Length > 0)
            {
                if (m_BLL.DeleteCollection(ref validationErrors, deleteId))
                {
                    LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，信息的Id为" + string.Join(",", deleteId), "消息"
                        );//删除成功，写入日志
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.DeleteSucceed;
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息"
                        );//删除失败，写入日志
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.DeleteFail + returnValue;
                }
            }
            return result;
        }

        IBLL.IPREPARE_SCHEMEBLL m_BLL;
        IBLL.IAPPLIANCE_LABORATORYBLL m_BLL2;

        ValidationErrors validationErrors = new ValidationErrors();

        public PREPARE_SCHEMEApiController()
            : this(new PREPARE_SCHEMEBLL(), new APPLIANCE_LABORATORYBLL()) { }

        public PREPARE_SCHEMEApiController(PREPARE_SCHEMEBLL bll, APPLIANCE_LABORATORYBLL bll2)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
        }

    }
}


