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
    /// 委托单信息
    /// </summary>
    public class ORDER_TASK_INFORMATIONController : BaseController
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
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
        {

            return View();
        }
        /// <summary>
        /// 保存发送-如果已经存在，判断状态，
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(ORDER_TASK_INFORMATION entity)
        {

            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();
            //如果是查询出来的委托单，又增加了一个器具，点击了发送实验室，怎么处理？
            //   if (entity != null && ModelState.IsValid)
            {
                string currentPerson = GetCurrentPerson();
                if (string.IsNullOrWhiteSpace(entity.ID))
                {
                    entity.CREATETIME = DateTime.Now;
                    entity.CREATEPERSON = currentPerson;
                    entity.ID = Result.GetNewId();
                    entity.ORDER_STATUS = Common.ORDER_STATUS.已分配.ToString();
                    foreach (var item in entity.APPLIANCE_DETAIL_INFORMATION)
                    {
                        item.ID = Result.GetNewId();
                        item.CREATETIME = DateTime.Now;
                        item.CREATEPERSON = currentPerson;
                        item.ORDER_STATUS = Common.ORDER_STATUS.已分配.ToString();
                        item.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.已分配.GetHashCode().ToString();
                        if (string.IsNullOrWhiteSpace(item.UNDERTAKE_LABORATORYID))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，委托单信息的信息，实验室为空", "委托单信息"
                          );//写入日志                      
                            result.Code = Common.ClientCode.Fail;
                            result.Message = "实验室不能为空";
                            return Json(result); //提示插入失败
                        }
                        else
                        {
                            foreach (var it in item.UNDERTAKE_LABORATORYID.Split(','))
                            {
                                item.APPLIANCE_LABORATORY.Add(new APPLIANCE_LABORATORY() { ID = Result.GetNewId(), UNDERTAKE_LABORATORYID = it });
                            }
                        }

                    }

                    string returnValue = string.Empty;
                    if (m_BLL.Create(ref validationErrors, entity))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，委托单信息的信息的Id为" + entity.ID, "委托单信息"
                            );//写入日志 
                        result.Code = Common.ClientCode.Succeed;
                        result.Message = Suggestion.InsertSucceed;
                        result.Id = entity.ID;
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
                        LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，委托单信息的信息，" + returnValue, "委托单信息"
                            );//写入日志                      
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.InsertFail + returnValue;
                        return Json(result); //提示插入失败
                    }
                }
                else
                {

                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 

            return Json(result);

        }

        public ActionResult Createto(string id)
        {

            return View();
        }

        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        IBLL.IORDER_TASK_INFORMATIONBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public ORDER_TASK_INFORMATIONController()
            : this(new ORDER_TASK_INFORMATIONBLL()) { }

        public ORDER_TASK_INFORMATIONController(ORDER_TASK_INFORMATIONBLL bll)
        {
            m_BLL = bll;
        }

    }
}


