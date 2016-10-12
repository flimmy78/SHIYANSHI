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


