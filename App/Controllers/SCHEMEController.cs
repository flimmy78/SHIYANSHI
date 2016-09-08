using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using Langben.App.Models;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 方案
    /// </summary>
    public class SCHEMEController : BaseController
    {

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {
        
            return View();
        }
         /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexSef()
        {

            return View();
        }

        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SupportFilter]  
        public ActionResult Details(string id)
        {
            ViewBag.Id = id;
            return View();

        }
        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Create()
        {            
            return View();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="NAME">方案名称</param>       
        /// <param name="UNDERTAKE_LABORATORYID">实验室编号</param>
        /// <param name="RULEIDs">检查项编号多个,分割例如（1,2)</param>
        /// <returns></returns>
        public ActionResult CreateSave(string NAME, string UNDERTAKE_LABORATORYID, string RULEIDs)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            SCHEME entity = new SCHEME();
            string currentPerson = GetCurrentPerson();
            entity.CREATETIME = DateTime.Now;
            entity.CREATEPERSON = currentPerson;
            entity.UNDERTAKE_LABORATORYID = UNDERTAKE_LABORATORYID;
            entity.ID = Result.GetNewId();
            entity.STATUS = "未使用";
            entity.ISSTOP = "停用";
            entity.NAME = NAME;
            //if (RULEIDs != null && RULEIDs.Trim() != "")
            //{
            //    string[] RULEIDList = RULEIDs.Split(',');
            //    foreach (string ruleID in RULEIDList)
            //    {
            //        if (ruleID != null && ruleID.Trim() != "")
            //        {
            //            SCHEME_RULE item = new SCHEME_RULE();
            //            item.CREATEPERSON = currentPerson;
            //            item.CREATETIME = entity.CREATETIME;
            //            item.RULEID = ruleID;
            //            item.SCHEMEID = entity.ID;
            //            item.ID = Result.GetNewId();
            //            entity.SCHEME_RULE.Add(item);
            //        }
            //    }
            //}

            string returnValue = string.Empty;
            if (m_BLL.Create(ref validationErrors, entity))
            {
                LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，方案的信息的Id为" + entity.ID, "方案"
                    );//写入日志 
                result.Code = Common.ClientCode.Succeed;
                result.Message = Suggestion.InsertSucceed;
                return Json(result); //提示创建成功
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
                LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，方案的信息，" + returnValue, "方案"
                    );//写入日志                      
                result.Code = Common.ClientCode.Fail;
                result.Message = Suggestion.InsertFail + returnValue;
                return Json(result); //提示插入失败
            }   
                 
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="ID">方案编号</param>
        /// <param name="NAME">方案名称</param>       
        /// <param name="UNDERTAKE_LABORATORYID">实验室编号</param>
        /// <param name="RULEIDs">检查项编号多个,分割例如（1,2)</param>
        /// <returns></returns>
        public ActionResult UpdateSave(string ID,string NAME, string UNDERTAKE_LABORATORYID, string RULEIDs)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (ID != null && ID.Trim() != "")
            {
                SCHEME entity = m_BLL.GetById(ID);


                if (entity != null && ModelState.IsValid)
                {   //数据校验

                    string currentPerson = GetCurrentPerson();
                    entity.UPDATEPERSON = currentPerson;
                    entity.UPDATETIME = DateTime.Now;
                    entity.NAME = NAME;
                    entity.UNDERTAKE_LABORATORYID = UNDERTAKE_LABORATORYID;

                    //if (RULEIDs != null && RULEIDs.Trim() != "")
                    //{
                    //    string[] RULEIDList = RULEIDs.Split(',');
                    //    foreach (string ruleID in RULEIDList)
                    //    {
                    //        if (ruleID != null && ruleID.Trim() != "")
                    //        {
                    //            SCHEME_RULE item = new SCHEME_RULE();
                    //            item.CREATEPERSON = currentPerson;
                    //            item.CREATETIME = entity.CREATETIME;
                    //            item.RULEID = ruleID;
                    //            item.SCHEMEID = entity.ID;
                    //            item.ID = Result.GetNewId();
                    //            entity.SCHEME_RULE.Add(item);
                    //        }
                    //    }
                    //}             

                    string returnValue = string.Empty;
                    if (m_BLL.Edit(ref validationErrors, entity))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，方案信息的Id为" + entity.ID, "方案"
                            );//写入日志                   
                        result.Code = Common.ClientCode.Succeed;
                        result.Message = Suggestion.UpdateSucceed;
                        return Json(result); //提示更新成功 
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
                        LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，方案信息的Id为" + entity.ID + "," + returnValue, "方案"
                            );//写入日志   
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.UpdateFail + returnValue;
                        return Json(result); //提示更新失败
                    }
                }
                result.Code = Common.ClientCode.FindNull;
                result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
                return Json(result); //提示输入的数据的格式不对   
            }
            else
            {
                return CreateSave(NAME, UNDERTAKE_LABORATORYID, RULEIDs);
            }
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// 删除\停用
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>  
        public ActionResult MultOp(string query, string Op)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            string returnValue = string.Empty;
            string[] deleteId = query.GetString().Split(',');
            if (deleteId != null && deleteId.Length > 0)
            {
                if (Op == "删除")
                {
                    if (m_BLL.DeleteCollection(ref validationErrors, deleteId))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，方案的Id为" + string.Join(",", deleteId), "消息"
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
                        LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，方案的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息"
                            );//删除失败，写入日志
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.DeleteFail + returnValue;
                    }
                }
                else if (Op == "停用" || Op=="启用")
                {
                    List<SCHEME> list = new List<SCHEME>();
                    foreach (string id in deleteId)
                    {
                        SCHEME entity = m_BLL.GetById(id);
                        string currentPerson = GetCurrentPerson();
                        entity.UPDATEPERSON = currentPerson;
                        entity.UPDATETIME = DateTime.Now;
                        entity.ISSTOP = Op;
                        list.Add(entity);
                    }                    
                    if (m_BLL.EditCollection(ref validationErrors, list.AsQueryable<SCHEME>()))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，方案的Id为" + string.Join(",", deleteId), "消息");//修改成功，写入日志

                        result.Code = Common.ClientCode.Succeed;
                        result.Message = Suggestion.UpdateSucceed;
                        return Json(result); //提示更新成功 
                    }
                    else
                    {
                        LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，方案的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息");//删除失败，写入日志
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.UpdateFail + returnValue;
                    }
                }
            }
            return Json(result);
        }
        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="NAME">方案名称</param>       
        /// <param name="UNDERTAKE_LABORATORYID">实验室编号</param>
        /// <param name="RULEIDs">检查项编号多个,分割例如（1,2)</param>
        /// <returns></returns>
        public ActionResult UpdateIsStop(string ID,string ISSTOP)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            SCHEME entity = m_BLL.GetById(ID);            
           

            if (entity != null && ModelState.IsValid)
            {   //数据校验

                string currentPerson = GetCurrentPerson();
                entity.UPDATEPERSON = currentPerson;
                entity.UPDATETIME = DateTime.Now;
                entity.ISSTOP = ISSTOP;

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，方案信息的Id为" + entity.ID, "方案"
                        );//写入日志                   
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.UpdateSucceed;
                    return Json(result); //提示更新成功 
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，方案信息的Id为" + entity.ID + "," + returnValue, "方案"
                        );//写入日志   
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return Json(result); //提示更新失败
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return Json(result); //提示输入的数据的格式不对     
        }

        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter] 
        public ActionResult Edit(string id,string op)
        {
            ViewBag.Id = id;
            SCHEME entity = m_BLL.GetById(id);
            if (op != null && op == "复制")
            {
                entity.ID = "";
            }
            return View(entity);
        }
        IBLL.ISCHEMEBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public SCHEMEController()
                    : this(new SCHEMEBLL()) { }

        public SCHEMEController(SCHEMEBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


