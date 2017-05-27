﻿using System;
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
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            try
            {
                Common.Account account = GetCurrentAccount();
                string putid = entity.ID;

                if (entity != null && ModelState.IsValid)
                {

                    entity.CREATETIME = DateTime.Now;
                    entity.CREATEPERSON = account.PersonName;
                    //修改证书编号
                    entity.ID = Result.GetNewId();
                    string returnValue = string.Empty;
                    APPLIANCE_LABORATORY app = new APPLIANCE_LABORATORY();
                    if (string.IsNullOrWhiteSpace(entity.APPLIANCE_LABORATORYID))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，中间表没有id" + entity.ID, "预备方案表数据保存");//写入日志 
                        result.Code = Common.ClientCode.Fail;
                        result.Message = "中间表ID没取到";
                        return result; //提示更新成功 
                    }
                    app.ID = entity.APPLIANCE_LABORATORYID;
                    app.PREPARE_SCHEMEID = entity.ID;
                    if (!string.IsNullOrEmpty(putid))//判断是否为第二次进入
                    {
                        //修改
                        entity.ID = putid;
                        if (m_BLL.EditField(ref validationErrors, entity) && m_BLL.UPTSerialNumber(entity.ID))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，预备方案信息修改" + entity.ID, "预备方案");//写入日志                  
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
                    else
                    {
                        try
                        {
                            if (m_BLL.Create(ref validationErrors, entity))
                            {
                                LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，预备方案的信息的Id为" + entity.ID, "预备方案保存");//写入日志 
                                result.Code = Common.ClientCode.Succeed;
                                result.Id = entity.ID;
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
                                result.Code = Common.ClientCode.Fail;
                                result.Message = returnValue + "预备方案添加数据出错!";
                                result.Id = entity.ID;
                                return result;
                            }
                        }
                        catch (Exception ex)
                        {
                            validationErrors.Add(ex.Message);
                            ExceptionsHander.WriteExceptions(ex);
                        }

                        if (m_BLL2.EditField(ref validationErrors, app))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，中间表出错了" + app.ID, "中间表修改");//写入日志 
                            result.Code = Common.ClientCode.Succeed;
                            result.Id = entity.ID;
                        }
                        else
                        {
                            result.Code = Common.ClientCode.Fail;
                            result.Message = validationErrors + "中间表修改出错了!";
                            result.Id = entity.ID;
                            return result;
                        }
                        if (m_BLL.UPTSerialNumber(entity.ID))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，修改编号" + entity.ID, "修改编号");//写入日志 
                            result.Code = Common.ClientCode.Succeed;
                            result.Id = entity.ID;
                        }
                        else
                        {
                            result.Code = Common.ClientCode.Fail;
                            result.Message = validationErrors + "修改编号出错!";
                            result.Id = entity.ID;
                            return result;
                        }
                        return result;
                    }

                }

            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);
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
            if (entity != null)
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
        /// 建立方案保存下一步
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [HttpPut]
        public Common.ClientResult.Result EditInst([FromBody]PREPARE_SCHEME entity)
        {
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            if (entity != null && ModelState.IsValid)
            {   //数据校验
                Account acc = GetCurrentAccount();
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = acc.PersonName;

                string returnValue = string.Empty;
                entity.CHECKERID = acc.PersonName;

                if (m_BLL.EditInst(ref validationErrors, entity))
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
        /// 报告生成发送审核
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [HttpPut]
        public Common.ClientResult.Result EditField1([FromBody]PREPARE_SCHEME entity)
        {
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                string currentPerson = GetCurrentPerson();
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = currentPerson;
                entity.AUDITDATE = System.DateTime.Now;
                PREPARE_SCHEME ps = m_BLL.GetById(entity.ID);
                if (ps.REPORTSTATUSZI == Common.REPORTSTATUS.审核驳回.GetHashCode().ToString() || ps.REPORTSTATUSZI == Common.REPORTSTATUS.批准驳回.GetHashCode().ToString() || ps.REPORTSTATUSZI == null)
                {
                    string returnValue = string.Empty;
                    if (m_BLL.EditField1(ref validationErrors, entity))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，预备方案信息的Id为" + entity.ID, "预备方案"
                            );//写入日志                   
                        result.Code = Common.ClientCode.Succeed;
                        result.Message = "发送审核成功!";
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
                        result.Message = "发送审核失败，" + returnValue;
                        return result; //提示更新失败
                    }
                }
                else
                {
                    result.Code = Common.ClientCode.FindNull;
                    result.Message = "报告状态不对，不能发送！";
                    return result; //提示输入的数据的格式不对
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
                string returnValue = string.Empty;
                List<APPLIANCE_LABORATORY> APPlist = m_BLL2.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(entity.APPLIANCE_DETAIL_INFORMATIONID);
                THEREVIEWPROCESS SH = new THEREVIEWPROCESS();//审核操作记录
                THEAPPROVALPROCESS SP = new THEAPPROVALPROCESS();//审批操作记录
                APPLIANCE_LABORATORY applianceOne = APPlist.Find(f => f.PREPARE_SCHEMEID == entity.ID);
                APPLIANCE_LABORATORY applianceTwo = null;
                if (APPlist.Remove(applianceOne))
                {
                    applianceTwo = APPlist.FirstOrDefault();
                }

                if (entity.SHPI == "H")
                {
                    entity.AUDITTIME = DateTime.Now;//审核时间
                    entity.AUDITTEPERSON = currentPerson;
                    if (entity.ISAGGREY == "不同意")
                    {
                        entity.REPORTSTATUS = Common.REPORTSTATUS.审核驳回.ToString();
                        entity.REPORTSTATUSZI = Common.REPORTSTATUS.审核驳回.GetHashCode().ToString();

                        if (applianceTwo != null)
                        {
                            applianceOne.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                            m_BLL2.EditField(ref validationErrors, applianceOne);
                            applianceTwo.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                            m_BLL2.EditField(ref validationErrors, applianceTwo);

                        }
                        else
                        {
                            applianceOne.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                            m_BLL2.EditField(ref validationErrors, applianceOne);
                        }

                    }
                    else if (entity.ISAGGREY == "同意")
                    {
                        entity.REPORTSTATUS = Common.REPORTSTATUS.待批准.ToString();
                        entity.REPORTSTATUSZI = Common.REPORTSTATUS.待批准.GetHashCode().ToString();
                        applianceOne.ORDER_STATUS = Common.ORDER_STATUS.试验完成.ToString();//自己改变状态
                        applianceOne.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.试验完成.GetHashCode().ToString();//自己改变状态
                        if (applianceTwo != null)
                        {
                            applianceOne.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                            m_BLL2.EditField(ref validationErrors, applianceOne);
                            applianceTwo.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                            m_BLL2.EditField(ref validationErrors, applianceTwo);
                        }
                        else
                        {
                            applianceOne.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                            m_BLL2.EditField(ref validationErrors, applianceOne);
                        }
                    }
                    #region 审核过程记录
                    SH.ID = Result.GetNewId();//id
                    SH.CREATEPERSON = account.PersonName;//审核者
                    SH.CREATETIME = DateTime.Now;//审核时间
                    SH.REVIEWCONCLUSION = entity.ISAGGREY;
                    SH.REVIEWCONCLUSIONZI = entity.AUDITOPINION;//审核意见
                    SH.PREPARE_SCHEMEID = entity.ID;
                    if (!m_BLL4.Create(ref validationErrors, SH))
                    {
                        if (validationErrors != null && validationErrors.Count > 0)
                        {
                            validationErrors.All(a =>
                            {
                                returnValue += a.ErrorMessage;
                                return true;
                            });
                        }
                        LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，预备方案信息的Id为" + entity.ID, "审核过程记录");//写入日志  
                    }
                    #endregion

                }
                else if (entity.SHPI == "P")
                {
                    entity.APPROVALDATE = DateTime.Now;
                    entity.APPROVALEPERSON = currentPerson;
                    if (entity.APPROVALISAGGREY == "不同意")
                    {
                        entity.REPORTSTATUS = Common.REPORTSTATUS.批准驳回.ToString();
                        entity.REPORTSTATUSZI = Common.REPORTSTATUS.批准驳回.GetHashCode().ToString();
                        if (applianceTwo != null)
                        {
                            if (applianceTwo.ORDER_STATUS == Common.ORDER_STATUS.已分配.ToString())
                            {
                                applianceOne.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                applianceTwo.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                            }
                            else if (applianceTwo.ORDER_STATUS == Common.ORDER_STATUS.已领取.ToString())
                            {
                                applianceOne.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                applianceTwo.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                            }
                            else if (applianceTwo.PREPARE_SCHEME.REPORTSTATUS == Common.REPORTSTATUS.待批准.ToString())
                            {
                                applianceOne.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                applianceTwo.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                            }
                            else if (applianceTwo.PREPARE_SCHEME.REPORTSTATUS == Common.REPORTSTATUS.已批准.ToString())
                            {
                                applianceOne.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                                applianceTwo.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                            }
                            else if (applianceTwo.PREPARE_SCHEME.REPORTSTATUS == Common.REPORTSTATUS.批准驳回.ToString())
                            {
                                applianceOne.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                                applianceTwo.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                            }
                            m_BLL2.EditField(ref validationErrors, applianceOne);
                            m_BLL2.EditField(ref validationErrors, applianceTwo);
                        }
                        else
                        {
                            applianceOne.ISRECEIVE = Common.ISRECEIVE.是.ToString();
                            m_BLL2.EditField(ref validationErrors, applianceOne);
                        }
                    }
                    else if (entity.APPROVALISAGGREY == "同意")
                    {
                        entity.REPORTSTATUS = Common.REPORTSTATUS.已批准.ToString();
                        entity.REPORTSTATUSZI = Common.REPORTSTATUS.已批准.GetHashCode().ToString();
                        APPLIANCE_DETAIL_INFORMATION adi= m_BLL3.GetById(applianceOne.ID);
                        if (adi!=null)
                        {
                            if (adi.APPLIANCE_RECIVE=="是")
                            {
                                applianceOne.ORDER_STATUS = Common.ORDER_STATUS.待入库.ToString();
                                applianceOne.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.待入库.GetHashCode().ToString();
                            }
                            else
                            {
                                applianceOne.ORDER_STATUS = Common.ORDER_STATUS.器具未收.ToString();
                                applianceOne.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.器具未收.GetHashCode().ToString();
                            }
                        }
                       
                        applianceOne.ISRECEIVE = Common.ISRECEIVE.否.ToString();
                        m_BLL2.EditField(ref validationErrors, applianceOne);
                       
                    }
                    #region 审批过程记录
                    SP.ID = Result.GetNewId();//id
                    SP.CREATEPERSON = account.Name;//审核者
                    SP.CREATETIME = DateTime.Now;//审核时间
                    SP.APPROVALCONCLUSION = entity.APPROVALISAGGREY;
                    SP.PREPARE_SCHEMEID = entity.ID;
                    SP.APPROVALCONCLUSIONZI = entity.APPROVAL;//审批意见
                    if (!m_BLL5.Create(ref validationErrors, SP))
                    {
                        if (validationErrors != null && validationErrors.Count > 0)
                        {
                            validationErrors.All(a =>
                            {
                                returnValue += a.ErrorMessage;
                                return true;
                            });
                        }
                        LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，预备方案信息的Id为" + entity.ID, "审批过程记录");//写入日志  
                    }

                    #endregion
                }


                bool HE = false;
                if (!string.IsNullOrEmpty(applianceOne.ORDER_STATUS) || !string.IsNullOrEmpty(entity.REPORTSTATUS))
                {
                    HE = m_BLL.EditField(ref validationErrors, entity);//器具明细修改
                }
                try
                {
                    if (entity.REPORTSTATUS == Common.REPORTSTATUS.待批准.ToString() || entity.REPORTSTATUS == Common.REPORTSTATUS.已批准.ToString())
                    {
                        Langben.Report.ReportBLL rBLL = new Langben.Report.ReportBLL();
                        string err = "";
                        rBLL.AddQianMing(entity.ID, entity.REPORTSTATUS, out err);
                    }
                }
                catch (Exception ex)
                {

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

      
        IBLL.IPREPARE_SCHEMEBLL m_BLL;
        IBLL.IAPPLIANCE_LABORATORYBLL m_BLL2;
        IBLL.IAPPLIANCE_DETAIL_INFORMATIONBLL m_BLL3;
        IBLL.ITHEREVIEWPROCESSBLL m_BLL4;
        IBLL.ITHEAPPROVALPROCESSBLL m_BLL5;

        ValidationErrors validationErrors = new ValidationErrors();

        public PREPARE_SCHEMEApiController()
            : this(new PREPARE_SCHEMEBLL(), new APPLIANCE_LABORATORYBLL(), new APPLIANCE_DETAIL_INFORMATIONBLL(), new THEREVIEWPROCESSBLL(), new THEAPPROVALPROCESSBLL()) { }

        public PREPARE_SCHEMEApiController(PREPARE_SCHEMEBLL bll, APPLIANCE_LABORATORYBLL bll2, APPLIANCE_DETAIL_INFORMATIONBLL bll3, THEREVIEWPROCESSBLL bll4, THEAPPROVALPROCESSBLL bll5)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
            m_BLL4 = bll4;
            m_BLL5 = bll5;
        }

    }
}


