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

namespace Langben.App.Controllers
{
    /// <summary>
    /// 委托单信息
    /// </summary>
    public class ORDER_TASK_INFORMATIONApiController : BaseApiController
    {
        /// <summary>
        /// 器具登记查询功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ORDER_TASK_INFORMATIONShow PostDataByID(string id)
        {

            if (!string.IsNullOrWhiteSpace(id))
            {

                id = id.Replace("@", "&");
            }
            int total = 0;
            string UNDERTAKE_LABORATORYID = string.Empty;
            List<APPLIANCE_DETAIL_INFORMATION> queryData = m_BLL2.GetByParam(null, 1, 1, "DESC", "ID", id, ref total);
            foreach (var item in queryData)
            {
                UNDERTAKE_LABORATORYID = null;
                List<APPLIANCE_LABORATORY> list = m_BLL3.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(item.ID);
                foreach (var item2 in list)
                {
                    UNDERTAKE_LABORATORYID += item2.UNDERTAKE_LABORATORYID + ",";
                }
            }
            return queryData.Select(s => new ORDER_TASK_INFORMATIONShow()
            {
                APPLIANCE_DETAIL_INFORMATIONShows = new List<Models.APPLIANCE_DETAIL_INFORMATIONShow>() { new APPLIANCE_DETAIL_INFORMATIONShow() {
                    ID =s.ID,
                    BAR_CODE_NUM =s.BAR_CODE_NUM,
                    APPLIANCE_NAME =s.APPLIANCE_NAME,
                    VERSION =s.VERSION,
                    FORMAT =s.FORMAT,
                    FACTORY_NUM =s.FACTORY_NUM,
                    NUM =s.NUM,
                    ATTACHMENT =s.ATTACHMENT,
                    APPEARANCE_STATUS =s.APPEARANCE_STATUS,
                    MAKE_ORGANIZATION =s.MAKE_ORGANIZATION,
                    REMARKS =s.REMARKS,
                    END_PLAN_DATE =s.END_PLAN_DATE,
                    ORDER_TASK_INFORMATIONID =s.ORDER_TASK_INFORMATIONID,
                    CREATETIME =s.CREATETIME,
                    CREATEPERSON =s.CREATEPERSON,
                    UPDATETIME =s.UPDATETIME,
                    UPDATEPERSON =s.UPDATEPERSON,
                    APPLIANCE_RECIVE =s.APPLIANCE_RECIVE,
                    APPLIANCE_PROGRESS =s.APPLIANCE_PROGRESS,
                    ISOVERDUE =s.ISOVERDUE,
                    OVERDUE =s.OVERDUE,
                    STORAGEINSTRUCTIONS =s.STORAGEINSTRUCTIONS,
                    STORAGEINSTRUCTI_STATU =s.STORAGEINSTRUCTI_STATU,
                    UNDERTAKE_LABORATORYIDString =UNDERTAKE_LABORATORYID
    } },
                ID = s.ORDER_TASK_INFORMATION.ID,
                ORDER_NUMBER = s.ORDER_TASK_INFORMATION.ORDER_NUMBER,
                ACCEPT_ORGNIZATION = s.ORDER_TASK_INFORMATION.ACCEPT_ORGNIZATION,
                INSPECTION_ENTERPRISE = s.ORDER_TASK_INFORMATION.INSPECTION_ENTERPRISE,
                INSPECTION_ENTERPRISE_ADDRESS = s.ORDER_TASK_INFORMATION.INSPECTION_ENTERPRISE_ADDRESS,
                INSPECTION_ENTERPRISE_POST = s.ORDER_TASK_INFORMATION.INSPECTION_ENTERPRISE_POST,
                CONTACTS = s.ORDER_TASK_INFORMATION.CONTACTS,
                CONTACT_PHONE = s.ORDER_TASK_INFORMATION.CONTACT_PHONE,
                FAX = s.ORDER_TASK_INFORMATION.FAX,
                CERTIFICATE_ENTERPRISE = s.ORDER_TASK_INFORMATION.CERTIFICATE_ENTERPRISE,
                CERTIFICATE_ENTERPRISE_ADDRESS = s.ORDER_TASK_INFORMATION.CERTIFICATE_ENTERPRISE_ADDRESS,
                CERTIFICATE_ENTERPRISE_POST = s.ORDER_TASK_INFORMATION.CERTIFICATE_ENTERPRISE_POST,
                CONTACTS2 = s.ORDER_TASK_INFORMATION.CONTACTS2,
                CONTACT_PHONE2 = s.ORDER_TASK_INFORMATION.CONTACT_PHONE2,
                FAX2 = s.ORDER_TASK_INFORMATION.FAX2,
                CUSTOMER_SPECIFIC_REQUIREMENTS = s.ORDER_TASK_INFORMATION.CUSTOMER_SPECIFIC_REQUIREMENTS,
                ORDER_STATUS = s.ORDER_TASK_INFORMATION.ORDER_STATUS,
                CREATETIME = s.ORDER_TASK_INFORMATION.CREATETIME,
                CREATEPERSON = s.ORDER_TASK_INFORMATION.CREATEPERSON,
                UPDATETIME = s.ORDER_TASK_INFORMATION.UPDATETIME,
                UPDATEPERSON = s.ORDER_TASK_INFORMATION.UPDATEPERSON,
            }).FirstOrDefault();

        }


        /// <summary>
        /// 器具登记查询功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ORDER_TASK_INFORMATIONShow PostID(string id)
        {
            var data = new ORDER_TASK_INFORMATIONShow();
            string UNDERTAKE_LABORATORYID = string.Empty;
            string ORDER_STATUS = string.Empty;
            ORDER_TASK_INFORMATION queryData = m_BLL.GetById(id);
            foreach (var s in queryData.APPLIANCE_DETAIL_INFORMATION)
            {
                UNDERTAKE_LABORATORYID = null;
                ORDER_STATUS = null;
                List<APPLIANCE_LABORATORY> list = m_BLL3.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(s.ID);
                foreach (var item2 in list)
                {
                    UNDERTAKE_LABORATORYID += item2.UNDERTAKE_LABORATORYID + ",";
                    ORDER_STATUS += item2.ORDER_STATUS + ",";
                }
                s.UNDERTAKE_LABORATORYID = UNDERTAKE_LABORATORYID;

                data.APPLIANCE_DETAIL_INFORMATIONShows.Add(new Models.APPLIANCE_DETAIL_INFORMATIONShow()
                {
                    ID = s.ID,
                    BAR_CODE_NUM = s.BAR_CODE_NUM,
                    APPLIANCE_NAME = s.APPLIANCE_NAME,
                    VERSION = s.VERSION,
                    FORMAT = s.FORMAT,
                    FACTORY_NUM = s.FACTORY_NUM,
                    NUM = s.NUM,
                    ATTACHMENT = s.ATTACHMENT,
                    APPEARANCE_STATUS = s.APPEARANCE_STATUS,
                    MAKE_ORGANIZATION = s.MAKE_ORGANIZATION,
                    REMARKS = s.REMARKS,
                    END_PLAN_DATE = s.END_PLAN_DATE,
                    ORDER_TASK_INFORMATIONID = s.ORDER_TASK_INFORMATIONID,
                    CREATETIME = s.CREATETIME,
                    CREATEPERSON = s.CREATEPERSON,
                    UPDATETIME = s.UPDATETIME,
                    UPDATEPERSON = s.UPDATEPERSON,
                    APPLIANCE_RECIVE = s.APPLIANCE_RECIVE,
                    APPLIANCE_PROGRESS = s.APPLIANCE_PROGRESS,
                    ISOVERDUE = s.ISOVERDUE,
                    OVERDUE = s.OVERDUE,
                    STORAGEINSTRUCTIONS = s.STORAGEINSTRUCTIONS,
                    STORAGEINSTRUCTI_STATU = s.STORAGEINSTRUCTI_STATU,
                    UNDERTAKE_LABORATORYIDString = UNDERTAKE_LABORATORYID,
                    ORDER_STATUS = ORDER_STATUS
                });
            }
            data.ID = queryData.ID;
            data.ORDER_NUMBER = queryData.ORDER_NUMBER;
            data.ACCEPT_ORGNIZATION = queryData.ACCEPT_ORGNIZATION;
            data.INSPECTION_ENTERPRISE = queryData.INSPECTION_ENTERPRISE;
            data.INSPECTION_ENTERPRISE_ADDRESS = queryData.INSPECTION_ENTERPRISE_ADDRESS;
            data.INSPECTION_ENTERPRISE_POST = queryData.INSPECTION_ENTERPRISE_POST;
            data.CONTACTS = queryData.CONTACTS;
            data.CONTACT_PHONE = queryData.CONTACT_PHONE;
            data.FAX = queryData.FAX;
            data.CERTIFICATE_ENTERPRISE = queryData.CERTIFICATE_ENTERPRISE;
            data.CERTIFICATE_ENTERPRISE_ADDRESS = queryData.CERTIFICATE_ENTERPRISE_ADDRESS;
            data.CERTIFICATE_ENTERPRISE_POST = queryData.CERTIFICATE_ENTERPRISE_POST;
            data.CONTACTS2 = queryData.CONTACTS2;
            data.CONTACT_PHONE2 = queryData.CONTACT_PHONE2;
            data.FAX2 = queryData.FAX2;
            data.CUSTOMER_SPECIFIC_REQUIREMENTS = queryData.CUSTOMER_SPECIFIC_REQUIREMENTS;
            data.ORDER_STATUS = queryData.ORDER_STATUS;
            data.CREATETIME = queryData.CREATETIME;
            data.CREATEPERSON = queryData.CREATEPERSON;
            data.UPDATETIME = queryData.UPDATETIME;
            data.UPDATEPERSON = queryData.UPDATEPERSON;
            return data;
        }
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<ORDER_TASK_INFORMATION> queryData = m_BLL.GetByParam(null, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    ORDER_NUMBER = s.ORDER_NUMBER
                    ,
                    ACCEPT_ORGNIZATION = s.ACCEPT_ORGNIZATION
                    ,
                    INSPECTION_ENTERPRISE = s.INSPECTION_ENTERPRISE
                    ,
                    INSPECTION_ENTERPRISE_ADDRESS = s.INSPECTION_ENTERPRISE_ADDRESS
                    ,
                    INSPECTION_ENTERPRISE_POST = s.INSPECTION_ENTERPRISE_POST
                    ,
                    CONTACTS = s.CONTACTS
                    ,
                    CONTACT_PHONE = s.CONTACT_PHONE
                    ,
                    FAX = s.FAX
                    ,
                    CERTIFICATE_ENTERPRISE = s.CERTIFICATE_ENTERPRISE
                    ,
                    CERTIFICATE_ENTERPRISE_ADDRESS = s.CERTIFICATE_ENTERPRISE_ADDRESS
                    ,
                    CERTIFICATE_ENTERPRISE_POST = s.CERTIFICATE_ENTERPRISE_POST
                    ,
                    CONTACTS2 = s.CONTACTS2
                    ,
                    CONTACT_PHONE2 = s.CONTACT_PHONE2
                    ,
                    FAX2 = s.FAX2
                    ,
                    CUSTOMER_SPECIFIC_REQUIREMENTS = s.CUSTOMER_SPECIFIC_REQUIREMENTS
                    ,
                    ORDER_STATUS = s.ORDER_STATUS
                    ,
                    CREATETIME = s.CREATETIME
                    ,
                    CREATEPERSON = s.CREATEPERSON
                    ,
                    UPDATETIME = s.UPDATETIME
                    ,
                    UPDATEPERSON = s.UPDATEPERSON


                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        [HttpGet]
        public ORDER_TASK_INFORMATION Get(string id)
        {
            ORDER_TASK_INFORMATION item = m_BLL.GetById(id);
            return item;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Post([FromBody]ORDER_TASK_INFORMATION entity)
        {

            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            if (entity != null && ModelState.IsValid)
            {
                string currentPerson = GetCurrentPerson();
                entity.CREATETIME = DateTime.Now;
                entity.CREATEPERSON = currentPerson;

                entity.ID = Result.GetNewId();
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，委托单信息的信息的Id为" + entity.ID, "委托单信息"
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
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，委托单信息的信息，" + returnValue, "委托单信息"
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
        public Common.ClientResult.Result Put([FromBody]ORDER_TASK_INFORMATION entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                string currentPerson = GetCurrentPerson();
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = currentPerson;

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，委托单信息信息的Id为" + entity.ID, "委托单信息"
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，委托单信息信息的Id为" + entity.ID + "," + returnValue, "委托单信息"
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
        /// 修改（我的工作发送功能）
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
                    // entity.ID = Result.GetNewId();
                    entity.ORDER_STATUS = Common.ORDER_STATUS_INFORMATION.已分配.ToString();
                    foreach (var item in entity.APPLIANCE_DETAIL_INFORMATION)
                    {
                        item.CREATETIME = DateTime.Now;
                        item.CREATEPERSON = currentPerson;
                        if (string.IsNullOrWhiteSpace(item.UNDERTAKE_LABORATORYID))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，委托单信息的信息，实验室为空", "委托单信息"
                          );//写入日志                      
                            result.Code = Common.ClientCode.Fail;
                            result.Message = "实验室不能为空";
                            return result; //提示插入失败
                        }
                        else
                        {

                            //器具明细信息_承接实验室表添加数据
                            List<APPLIANCE_LABORATORY> appory = m_BLL3.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(item.ID);
                            bool a = false;

                            foreach (var item2 in appory)
                            {
                                foreach (var it in item.UNDERTAKE_LABORATORYID.TrimEnd(',').Split(','))
                                {
                                    if (item2.ORDER_STATUS == Common.ORDER_STATUS.已退回.ToString())
                                    {
                                        item.APPLIANCE_LABORATORY.Add(new APPLIANCE_LABORATORY()
                                        {
                                            ID = item2.ID,
                                            UNDERTAKE_LABORATORYID = it,
                                            ORDER_STATUS = Common.ORDER_STATUS.已分配.ToString(),
                                            EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.已分配.GetHashCode().ToString(),
                                            DISTRIBUTIONPERSON = currentPerson,
                                            DISTRIBUTIONTIME = new DateTime(),
                                            CREATEPERSON = currentPerson,
                                            CREATETIME = new DateTime(),
                                            ISRECEIVE = Common.ISRECEIVE.是.ToString()
                                        });
                                        a = true;
                                        break;
                                    }
                                }
                                if (a)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    string returnValue = string.Empty;
                    foreach (var item in entity.APPLIANCE_DETAIL_INFORMATION)
                    {
                        if (m_BLL2.EditField(ref validationErrors, item))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，器具明细信息的Id为" + item.ID, "委托单信息"
                                                      );//写入日志 
                            result.Code = Common.ClientCode.Succeed;
                            result.Message = Suggestion.UpdateSucceed;
                        }
                        else
                        {
                            LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，器具明细信息的Id为" + item.ID, "委托单信息"
                                                      );//写入日志 
                            result.Code = Common.ClientCode.Fail;
                            result.Message = Suggestion.UpdateFail;
                            return result;
                        }
                        foreach (var item2 in item.APPLIANCE_LABORATORY)
                        {
                            if (m_BLL3.EditField(ref validationErrors, item2))
                            {
                                LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，器具明细信息_承接实验室的Id为" + item2.ID, "委托单信息"
                           );//写入日志 
                                result.Code = Common.ClientCode.Succeed;
                                result.Message = Suggestion.UpdateSucceed;                             
                            }
                            else
                            {
                                LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，器具明细信息_承接实验室的Id为" + item2.ID, "委托单信息"
                                                          );//写入日志 
                                result.Code = Common.ClientCode.Fail;
                                result.Message = Suggestion.UpdateFail;
                                return result;
                            }
                        }
                    }
                   
                    if (m_BLL.EditField(ref validationErrors, entity))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，委托单信息的信息的Id为" + entity.ID, "委托单信息"
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
                        LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，委托单信息的信息，" + returnValue, "委托单信息"
                            );//写入日志                      
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.InsertFail + returnValue;
                        return result; //提示插入失败
                    }
                }
                else
                {

                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 

            return result;
        }
        // DELETE api/<controller>/5
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>  
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

        IBLL.IORDER_TASK_INFORMATIONBLL m_BLL;
        IBLL.IAPPLIANCE_DETAIL_INFORMATIONBLL m_BLL2;
        IBLL.IAPPLIANCE_LABORATORYBLL m_BLL3;
        ValidationErrors validationErrors = new ValidationErrors();

        public ORDER_TASK_INFORMATIONApiController()
                    : this(new ORDER_TASK_INFORMATIONBLL(), new APPLIANCE_DETAIL_INFORMATIONBLL(), new APPLIANCE_LABORATORYBLL()) { }

        public ORDER_TASK_INFORMATIONApiController(ORDER_TASK_INFORMATIONBLL bll, APPLIANCE_DETAIL_INFORMATIONBLL bll2, APPLIANCE_LABORATORYBLL bll3)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
        }

    }
}


