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
        /// 编辑集合（领取功能）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [HttpPost]
        public Common.ClientResult.Result LINGQU(APPLIANCECOLLECTION app)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            string returnValue = string.Empty;
            string id = app.APPLIANCE_DETAIL_INFORMATIONID.TrimEnd(',');
            string APPLIANCECOLLECTIONSATE = app.APPLIANCECOLLECTIONSATE.TrimEnd(',');
            Dictionary<string, string> dicti = new Dictionary<string, string>();
            string[] deleteId = id.Split(',');//截取id
            string[] deleteAPPLIANCECOLLECTIONSATE = APPLIANCECOLLECTIONSATE.Split(',');//截取器具状态         
            if (deleteId != null && deleteId.Length > 0)
            {
                Common.Account account = GetCurrentAccount();
                for (int i = 0; i < deleteId.Length; i++)
                {
                    dicti.Add(deleteId[i], deleteAPPLIANCECOLLECTIONSATE[i]);
                }
                //Common.Account account = new Account();
                //account.UNDERTAKE_LABORATORYName = "三相";
                //判断出是试验完成的id
                //for (int i = 0; i < deleteId.Length; i++)
                //{
                //    deleteId[i]= deleteId[i].Substring(0,deleteId[i].Length - 1);
                //    string ids= deleteId[i].Substring(deleteId[i].Length - 1);
                //    if (ids=="*")
                //    {

                //    }
                //}
                //数据校验

                //添加领取信息
                APPLIANCECOLLECTION appliance = new APPLIANCECOLLECTION();
                bool isEdit = false;
                foreach (var item in dicti)
                {
                    appliance.ID = Result.GetNewId();
                    appliance.APPLIANCE_DETAIL_INFORMATIONID = item.Key;
                    appliance.CREATEPERSON = account.Name;
                    appliance.LABORATORY = account.UNDERTAKE_LABORATORYName;
                    appliance.CREATETIME = new DateTime();
                    appliance.APPLIANCECOLLECTIONSATE = item.Value;
                    if (!m_BLL2.Create(ref validationErrors, appliance))
                    {
                        break;
                    }
                    else
                    {
                        isEdit = true;
                    }

                }
                //判断器具领取信息是否添加成功
                if (isEdit)
                {
                    if (m_BLL.EditCollection(ref validationErrors, deleteId, account.UNDERTAKE_LABORATORYName))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具明细信息信息的Id为" + string.Join(",", deleteId), "器具明细信息"
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
                        LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，器具明细信息信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "器具明细信息"
                            );//写入日志   
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.UpdateFail + returnValue;
                        return result; //提示更新失败
                    }
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return result; //提示输入的数据的格式不对         
        }

        /// <summary>
        /// 编辑集合（入库功能）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [System.Web.Http.HttpPut]
        public Common.ClientResult.Result PutSTORAGEINSTRUCTI_STATU(string id)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            string returnValue = string.Empty;
            string[] deleteId = id.GetString().Split(',');
            if (deleteId != null && deleteId.Length > 0)
            {   //数据校验
                if (m_BLL.EditSTORAGEINSTRUCTI_STATU(ref validationErrors, deleteId))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具明细信息信息的Id为" + string.Join(",", deleteId), "器具明细信息"
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，器具明细信息信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "器具明细信息"
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
                if (!string.IsNullOrEmpty(entity.ORDER_STATUS))
                {
                    if (Enum.IsDefined(typeof(Common.ORDER_STATUS), entity.ORDER_STATUS))
                    {
                        entity.EQUIPMENT_STATUS_VALUUMN = Enum.Parse(typeof(Common.ORDER_STATUS), entity.ORDER_STATUS).GetHashCode().ToString();
                    }
                }
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

        ValidationErrors validationErrors = new ValidationErrors();

        public VAPPLIANCE_DETAIL_INFORMATIONApiController()
            : this(new APPLIANCE_DETAIL_INFORMATIONBLL(), new APPLIANCECOLLECTIONBLL()) { }

        public VAPPLIANCE_DETAIL_INFORMATIONApiController(APPLIANCE_DETAIL_INFORMATIONBLL bll, APPLIANCECOLLECTIONBLL bll2)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
        }

    }
}


