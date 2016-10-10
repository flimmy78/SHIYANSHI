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
            Common.Account account = GetCurrentAccount();
            string putid = entity.ID;
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            if (entity != null && ModelState.IsValid)
            {
                //if (entity.ID != null && string.IsNullOrWhiteSpace(entity.SCHEMEID))
                //{
                //    result.Code = Common.ClientCode.FindNull;
                //    result.Message = Suggestion.InsertFail + "，请选择方案模板"; //提示输入的数据的格式不对 
                //    return result;
                //}
                string currentPerson = GetCurrentPerson();
                entity.CREATETIME = DateTime.Now;
                entity.CREATEPERSON = currentPerson;
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
                    if (m_BLL.EditField(ref validationErrors, entity) && m_BLL.UPTSerialNumber(entity.ID))
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
        [HttpPut]
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

        // PUT api/<controller>/5
        /// <summary>
        /// 审核审批结论
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [HttpPost]
        public Common.ClientResult.Result SheIsPi([FromBody]PREPARE_SCHEME entity)
        {
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            if (entity != null && ModelState.IsValid)
            {   //数据校验
                Common.Account account = GetCurrentAccount();
                string currentPerson = GetCurrentPerson();
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = currentPerson;
                List<APPLIANCE_LABORATORY> APPlist = m_BLL2.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(entity.APPLIANCE_DETAIL_INFORMATIONID);

                APPLIANCE_LABORATORY appliance = new APPLIANCE_LABORATORY();//器具明细信息_承接实验室1
                APPLIANCE_LABORATORY appliance2 = new APPLIANCE_LABORATORY();//器具明细信息_承接实验室2
                if (APPlist.Count > 1)
                {
                    appliance = APPlist[0];
                    appliance2 = APPlist[1];
                }
                else
                {
                    appliance = APPlist[0];
                }

                if (entity.SHPI == "H")
                {
                    if (entity.ISAGGREY == "不同意")
                    {
                        entity.REPORTSTATUS = Common.REPORTSTATUS.审核驳回.ToString();
                        entity.REPORTSTATUSZI = Common.REPORTSTATUS.审核驳回.GetHashCode().ToString();
                        if (APPlist.Count > 1)
                        {
                            if (appliance.UNDERTAKE_LABORATORYID == account.UNDERTAKE_LABORATORYName)
                            {
                                appliance.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                m_BLL2.EditField(ref validationErrors, appliance);
                                appliance2.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                m_BLL2.EditField(ref validationErrors, appliance2);
                            }
                            else if (appliance2.UNDERTAKE_LABORATORYID == account.UNDERTAKE_LABORATORYName)
                            {
                                appliance2.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                m_BLL2.EditField(ref validationErrors, appliance2);
                                appliance.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                m_BLL2.EditField(ref validationErrors, appliance);
                            }
                        }
                        else
                        {
                            if (appliance.UNDERTAKE_LABORATORYID == account.UNDERTAKE_LABORATORYName)
                            {
                                appliance.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                m_BLL2.EditField(ref validationErrors, appliance);
                            }
                        }
                    }
                    else if (entity.ISAGGREY == "同意")
                    {
                        entity.REPORTSTATUS = Common.REPORTSTATUS.待批准.ToString();
                        entity.REPORTSTATUSZI = Common.REPORTSTATUS.待批准.GetHashCode().ToString();
                        entity.AUDITTIME = new DateTime();//审核时间
                        entity.AUDITTEPERSON = currentPerson;
                        if (APPlist.Count > 1)
                        {
                            if (appliance.UNDERTAKE_LABORATORYID == account.UNDERTAKE_LABORATORYName)
                            {
                                appliance.ORDER_STATUS = Common.ORDER_STATUS.试验完成.ToString();
                                appliance.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.试验完成.GetHashCode().ToString();
                                appliance.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                m_BLL2.EditField(ref validationErrors, appliance);
                                appliance2.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                m_BLL2.EditField(ref validationErrors, appliance2);
                            }
                            else if (appliance2.UNDERTAKE_LABORATORYID == account.UNDERTAKE_LABORATORYName)
                            {
                                appliance2.ORDER_STATUS = Common.ORDER_STATUS.试验完成.ToString();
                                appliance2.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.试验完成.GetHashCode().ToString();
                                appliance2.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                m_BLL2.EditField(ref validationErrors, appliance2);
                                appliance.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                m_BLL2.EditField(ref validationErrors, appliance);
                            }
                        }
                        else
                        {
                            if (appliance.UNDERTAKE_LABORATORYID == account.UNDERTAKE_LABORATORYName)
                            {
                                appliance.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                m_BLL2.EditField(ref validationErrors, appliance);
                            }
                        }
                    }
                }
                else if (entity.SHPI == "P")
                {
                    if (entity.APPROVALISAGGREY == "不同意")
                    {
                        entity.REPORTSTATUS = Common.REPORTSTATUS.批准驳回.ToString();
                        entity.REPORTSTATUSZI = Common.REPORTSTATUS.批准驳回.GetHashCode().ToString();
                        int i = APPlist.Count;
                        if (i > 1)
                        {
                            appliance.PREPARE_SCHEMEID = appliance.PREPARE_SCHEMEID == null ? "" : appliance.PREPARE_SCHEMEID;
                            appliance2.PREPARE_SCHEMEID = appliance2.PREPARE_SCHEMEID == null ? "" : appliance2.PREPARE_SCHEMEID;
                            if (appliance.PREPARE_SCHEMEID == entity.ID)
                            {
                                if (appliance2.ORDER_STATUS == Common.ORDER_STATUS.已分配.ToString())
                                {
                                    appliance.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                }
                                else if (appliance2.ORDER_STATUS == Common.ORDER_STATUS.已领取.ToString())
                                {
                                    appliance.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                }
                                else if (appliance2.PREPARE_SCHEME.REPORTSTATUS == Common.REPORTSTATUS.待批准.ToString())
                                {
                                    appliance.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                }
                                else if (appliance2.PREPARE_SCHEME.REPORTSTATUS == Common.REPORTSTATUS.已批准.ToString())
                                {
                                    appliance.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                }
                                else if (appliance2.PREPARE_SCHEME.REPORTSTATUS == Common.REPORTSTATUS.批准驳回.ToString())
                                {
                                    appliance.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                }
                                m_BLL2.EditField(ref validationErrors, appliance);
                                m_BLL2.EditField(ref validationErrors, appliance2);
                            }
                            else if (appliance2.PREPARE_SCHEMEID == entity.ID)
                            {
                                if (appliance.ORDER_STATUS == Common.ORDER_STATUS.已分配.ToString())
                                {
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                    appliance.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                }
                                else if (appliance.ORDER_STATUS == Common.ORDER_STATUS.已领取.ToString())
                                {
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                    appliance.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                }
                                else if (appliance.PREPARE_SCHEME.REPORTSTATUS == Common.REPORTSTATUS.待批准.ToString())
                                {
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                    appliance.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                }
                                else if (appliance.PREPARE_SCHEME.REPORTSTATUS == Common.REPORTSTATUS.已批准.ToString())
                                {
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                    appliance.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                }
                                else if (appliance.PREPARE_SCHEME.REPORTSTATUS == Common.REPORTSTATUS.批准驳回.ToString())
                                {
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                    appliance.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                }
                                m_BLL2.EditField(ref validationErrors, appliance);
                                m_BLL2.EditField(ref validationErrors, appliance2);
                            }

                        }
                        else
                        {
                            appliance.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                            m_BLL2.EditField(ref validationErrors, appliance);
                        }

                    }
                    else if (entity.APPROVALISAGGREY == "同意")
                    {
                        entity.REPORTSTATUS = Common.REPORTSTATUS.已批准.ToString();
                        entity.REPORTSTATUSZI = Common.REPORTSTATUS.已批准.GetHashCode().ToString();
                        entity.APPROVALDATE = new DateTime();
                        entity.APPROVALEPERSON = currentPerson;
                        //判断器具是否满足入库条件
                        if (ISAPPLIANCE(entity.APPLIANCE_DETAIL_INFORMATIONID))
                        {
                            if (APPlist.Count > 1)
                            {
                                appliance.PREPARE_SCHEMEID = appliance.PREPARE_SCHEMEID == null ? "" : appliance.PREPARE_SCHEMEID;
                                appliance2.PREPARE_SCHEMEID = appliance2.PREPARE_SCHEMEID == null ? "" : appliance2.PREPARE_SCHEMEID;
                                if (appliance.PREPARE_SCHEMEID == entity.ID)
                                {
                                    appliance.ORDER_STATUS = Common.ORDER_STATUS.待入库.ToString();
                                    appliance.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.待入库.GetHashCode().ToString();
                                    appliance.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                    m_BLL2.EditField(ref validationErrors, appliance);
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                    m_BLL2.EditField(ref validationErrors, appliance2);
                                }
                                else if (appliance2.PREPARE_SCHEMEID == entity.ID)
                                {
                                    appliance2.ORDER_STATUS = Common.ORDER_STATUS.待入库.ToString();
                                    appliance2.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.待入库.GetHashCode().ToString();
                                    appliance2.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                    m_BLL2.EditField(ref validationErrors, appliance2);
                                    appliance.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                    m_BLL2.EditField(ref validationErrors, appliance);
                                }
                            }
                            else
                            {
                                appliance.ORDER_STATUS = Common.ORDER_STATUS.待入库.ToString();
                                appliance.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.待入库.GetHashCode().ToString();
                                appliance.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                m_BLL2.EditField(ref validationErrors, appliance);
                            }

                        }
                    }
                }

                string returnValue = string.Empty;
                bool HE = false;
                if (!string.IsNullOrEmpty(appliance.ORDER_STATUS) || !string.IsNullOrEmpty(entity.REPORTSTATUS))
                {
                    HE = m_BLL.EditField(ref validationErrors, entity);//器具明细修改
                }

                if (HE)
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

        /// <summary>
        /// 判断器具是否满足入库条件
        /// </summary>
        /// <param name="id">器具明细表id</param>
        /// <returns>满足：true；不满足：false</returns>
        public bool ISAPPLIANCE(string id)
        {
            bool JG = false;
            List<APPLIANCE_LABORATORY> list = m_BLL2.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(id);
            if (list.Count == 1)
            {
                foreach (var item in list)
                {
                    PREPARE_SCHEME prepare = m_BLL.GetById(item.PREPARE_SCHEMEID);
                    if (prepare.REPORTSTATUS == Common.REPORTSTATUS.待批准.ToString())//判断当前报告是否满足条件
                    {
                        JG = true;
                    }
                    else
                    {
                        JG = false;
                        return JG;
                    }
                }
            }
            return JG;
        }

        IBLL.IPREPARE_SCHEMEBLL m_BLL;
        IBLL.IAPPLIANCE_LABORATORYBLL m_BLL2;
        IBLL.IAPPLIANCE_DETAIL_INFORMATIONBLL m_BLL3;

        ValidationErrors validationErrors = new ValidationErrors();

        public PREPARE_SCHEMEApiController()
            : this(new PREPARE_SCHEMEBLL(), new APPLIANCE_LABORATORYBLL(), new APPLIANCE_DETAIL_INFORMATIONBLL()) { }

        public PREPARE_SCHEMEApiController(PREPARE_SCHEMEBLL bll, APPLIANCE_LABORATORYBLL bll2, APPLIANCE_DETAIL_INFORMATIONBLL bll3)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
        }

    }
}


