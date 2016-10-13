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
using System.Web;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 器具明细信息
    /// </summary>
    public class VAPPLIANCE_DETAIL_INFORMATIONApiController : BaseApiController
    {
        /// <summary>
        /// 编辑（公用）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [HttpPost]
        public Common.ClientResult.Result EditField([FromBody]APPLIANCE_DETAIL_INFORMATION entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                string currentPerson = GetCurrentPerson();
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = currentPerson;

                string returnValue = string.Empty;
                if (m_BLL.EditField(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具明细信息信息的Id为" + entity.ID, "器具明细信息"
                        );//写入日志                   
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.UpdateSucceed;
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，器具明细信息信息的Id为" + entity.ID + "," + returnValue, "器具明细信息"
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

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [HttpPost]
        public Common.ClientResult.Result PutSTORAGEINSTRUCTI_STATU(string id)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (id != null && ModelState.IsValid)
            {   //数据校验
                APPLIANCE_DETAIL_INFORMATION app = null;
                APPLIANCE_LABORATORY appry = null;
                foreach (var item in id.TrimEnd(',').Split(','))
                {
                    app = new APPLIANCE_DETAIL_INFORMATION();
                    appry = new APPLIANCE_LABORATORY();
                    app.UPDATEPERSON = GetCurrentPerson();
                    app.UPDATETIME = new DateTime();
                    app.ID = item;
                    app.STORAGEINSTRUCTI_STATU = Common.ORDER_STATUS.器具已入库.ToString();//入库状态
                    //器具明细信息_承接实验室表修改器具状态
                    List<APPLIANCE_LABORATORY> list = m_BLL3.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(item);
                    appry.ORDER_STATUS = Common.ORDER_STATUS.器具已入库.ToString();//器具状态
                    foreach (var ps in list)
                    {
                        string returnValue = string.Empty;
                        appry.ID = ps.ID;
                        if (m_BLL3.EditField(ref validationErrors, appry))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具明细信息_承接实验室的Id为" + appry.ID, "器具明细信息_承接实验室信息"
                                );//写入日志                   
                            result.Code = Common.ClientCode.Succeed;
                            result.Message = Suggestion.UpdateSucceed;
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
                            LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，器具明细信息_承接实验室的Id为" + app.ID + "," + returnValue, "器具明细信息_承接实验室信息"
                                );//写入日志   
                            result.Code = Common.ClientCode.Fail;
                            result.Message = Suggestion.UpdateFail + returnValue;
                            return result; //提示更新失败
                        }
                    }
                    //器具明细信息表的入库状态修改
                    string returnValue2 = string.Empty;
                    if (m_BLL.EditField(ref validationErrors, app))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具明细信息信息的Id为" + app.ID, "器具明细信息"
                            );//写入日志                   
                        result.Code = Common.ClientCode.Succeed;
                        result.Message = Suggestion.UpdateSucceed;
                        continue;
                    }
                    else
                    {
                        if (validationErrors != null && validationErrors.Count > 0)
                        {
                            validationErrors.All(a =>
                            {
                                returnValue2 += a.ErrorMessage;
                                return true;
                            });
                        }
                        LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，器具明细信息信息的Id为" + app.ID + "," + returnValue2, "器具明细信息"
                            );//写入日志   
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.UpdateFail + returnValue2;
                        return result; //提示更新失败
                    }
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return result; //提示输入的数据的格式不对                 
        }


        /// <summary>
        /// 器具登记器具修改功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ORDER_TASK_INFORMATIONShow UpdateDataByID(string id)
        {
            Common.Account account = GetCurrentAccount();
            string UNDERTAKE_LABORATORYID = string.Empty;
            string ORDER_STATUS = string.Empty;
            APPLIANCE_DETAIL_INFORMATION queryData = m_BLL.GetById(id);//查询器具明细表数据
            foreach (var item in queryData.APPLIANCE_LABORATORY)
            {
                UNDERTAKE_LABORATORYID += item.UNDERTAKE_LABORATORYID + ",";//实验室
                if (item.UNDERTAKE_LABORATORYID == account.UNDERTAKE_LABORATORYName)
                {
                    ORDER_STATUS = item.ORDER_STATUS;//器具状态
                }
            }
            ORDER_TASK_INFORMATIONShow ordershow = new ORDER_TASK_INFORMATIONShow();
            ordershow.ID = queryData.ORDER_TASK_INFORMATION.ID;//委托单id
            ordershow.ACCEPT_ORGNIZATION = queryData.ORDER_TASK_INFORMATION.ACCEPT_ORGNIZATION;//受理单位
            ordershow.INSPECTION_ENTERPRISE = queryData.ORDER_TASK_INFORMATION.INSPECTION_ENTERPRISE;//送检单位
            ordershow.INSPECTION_ENTERPRISE_ADDRESS = queryData.ORDER_TASK_INFORMATION.INSPECTION_ENTERPRISE_ADDRESS;//送检单位地址
            ordershow.INSPECTION_ENTERPRISE_POST = queryData.ORDER_TASK_INFORMATION.INSPECTION_ENTERPRISE_POST;//送检单位邮政编码
            ordershow.CONTACTS = queryData.ORDER_TASK_INFORMATION.CONTACTS;//联系人
            ordershow.CONTACT_PHONE = queryData.ORDER_TASK_INFORMATION.CONTACT_PHONE;//联系电话
            ordershow.FAX = queryData.ORDER_TASK_INFORMATION.FAX;//传真
            ordershow.CERTIFICATE_ENTERPRISE = queryData.ORDER_TASK_INFORMATION.CERTIFICATE_ENTERPRISE;//证书单位
            ordershow.CERTIFICATE_ENTERPRISE_ADDRESS = queryData.ORDER_TASK_INFORMATION.CERTIFICATE_ENTERPRISE_ADDRESS;//证书单位地址
            ordershow.CERTIFICATE_ENTERPRISE_POST = queryData.ORDER_TASK_INFORMATION.CERTIFICATE_ENTERPRISE_POST;//证书单位邮政编码
            ordershow.CONTACTS2 = queryData.ORDER_TASK_INFORMATION.CONTACTS2;//联系人2
            ordershow.CONTACT_PHONE2 = queryData.ORDER_TASK_INFORMATION.CONTACT_PHONE2;//联系电话2
            ordershow.FAX2 = queryData.ORDER_TASK_INFORMATION.FAX2;//传真2
            ordershow.CUSTOMER_SPECIFIC_REQUIREMENTS = queryData.ORDER_TASK_INFORMATION.CUSTOMER_SPECIFIC_REQUIREMENTS;//客户特殊要求
            ordershow.APPLIANCE_DETAIL_INFORMATIONShows.Add(new APPLIANCE_DETAIL_INFORMATIONShow()
            {
                ID = queryData.ID,//器具明细id
                APPLIANCE_NAME = queryData.APPLIANCE_NAME,//器具名称
                VERSION = queryData.VERSION,//型号
                FORMAT = queryData.FORMAT,//规格
                FACTORY_NUM = queryData.FACTORY_NUM,//出厂编号
                NUM = queryData.NUM,//数量
                ATTACHMENT = queryData.ATTACHMENT,//附件
                APPEARANCE_STATUS = queryData.APPEARANCE_STATUS,//外观状态
                MAKE_ORGANIZATION = queryData.MAKE_ORGANIZATION,//制造单位
                UNDERTAKE_LABORATORYIDString = UNDERTAKE_LABORATORYID,//实验室
                REMARKS = queryData.REMARKS,//备注
                ORDER_STATUS = ORDER_STATUS//状态
            });
            return ordershow;
        }
        // PUT api/<controller>/5
        /// <summary>
        /// 器具登记器具修改功能（保存功能）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        [HttpPut]
        public Common.ClientResult.Result PutUpdate([FromBody]ORDER_TASK_INFORMATION entity)
        {
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            {
                string currentPerson = GetCurrentPerson();
                if (!string.IsNullOrEmpty(entity.ID))
                {
                    entity.CREATETIME = DateTime.Now;
                    entity.CREATEPERSON = currentPerson;
                    foreach (var item in entity.APPLIANCE_DETAIL_INFORMATION)
                    {
                        item.UPDATETIME = DateTime.Now;
                        item.UPDATEPERSON = currentPerson;
                        if (string.IsNullOrWhiteSpace(item.UNDERTAKE_LABORATORYID))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，委托单信息的信息，实验室为空", "委托单信息");//写入日志
                            result.Code = Common.ClientCode.Fail;
                            result.Message = "实验室不能为空";
                            return result; //提示插入失败
                        }
                    }
                    string returnValue = string.Empty;
                    foreach (var item in entity.APPLIANCE_DETAIL_INFORMATION)
                    {
                        if (m_BLL.EditField(ref validationErrors, item))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，器具明细信息的Id为" + item.ID, "委托单信息");//写入日志 
                            result.Code = Common.ClientCode.Succeed;
                            result.Message = Suggestion.UpdateSucceed;
                        }
                        else
                        {
                            LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，器具明细信息的Id为" + item.ID, "委托单信息");//写入日志 
                            result.Code = Common.ClientCode.Fail;
                            result.Message = Suggestion.UpdateFail;
                            return result;
                        }
                    }
                    if (m_BLL4.EditField(ref validationErrors, entity))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，委托单信息的信息的Id为" + entity.ID, "委托单信息");//写入日志 
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
                        LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，委托单信息的信息，" + returnValue, "委托单信息");//写入日志 
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.InsertFail + returnValue;
                        return result; //提示插入失败
                    }
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            return result;
        }
        /// <summary>
        /// 查找委托单中的受理单位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPut]
        public string GetGetByAPPLIANCE_DETAIL_INFORMATIONId(string id)
        {
            string ACCEPT_ORGNIZATION = string.Empty;
            if (!string.IsNullOrEmpty(id))
            {
                ACCEPT_ORGNIZATION = m_BLL.GetByAPPLIANCE_DETAIL_INFORMATIONId(id);
            }
            return ACCEPT_ORGNIZATION;
        }

        IBLL.IAPPLIANCE_DETAIL_INFORMATIONBLL m_BLL;
        IBLL.IAPPLIANCECOLLECTIONBLL m_BLL2;
        IBLL.IAPPLIANCE_LABORATORYBLL m_BLL3;
        IBLL.IORDER_TASK_INFORMATIONBLL m_BLL4;

        ValidationErrors validationErrors = new ValidationErrors();

        public VAPPLIANCE_DETAIL_INFORMATIONApiController()
            : this(new APPLIANCE_DETAIL_INFORMATIONBLL(), new APPLIANCECOLLECTIONBLL(), new APPLIANCE_LABORATORYBLL(), new ORDER_TASK_INFORMATIONBLL()) { }

        public VAPPLIANCE_DETAIL_INFORMATIONApiController(APPLIANCE_DETAIL_INFORMATIONBLL bll, APPLIANCECOLLECTIONBLL bll2, APPLIANCE_LABORATORYBLL bll3, ORDER_TASK_INFORMATIONBLL bll4)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
            m_BLL4 = bll4;
        }

    }
}


