using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using Langben.BLL;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Langben.App.Models;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 器具领取1
    /// </summary>
    public class VQIJULINGQU1Controller : BaseController
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
        [SupportFilter]
        public ActionResult Show(string baogaoid, string qijuid)
        {
            ORDER_TASK_INFORMATIONShow osi = new ORDER_TASK_INFORMATIONShow();
            #region 器具信息数据展示处理
            string ORDER_TASK_INFORMATIONID = string.Empty;
            List<string> Bao = new List<string>();
            List<string> Qi = new List<string>();
            if (!string.IsNullOrWhiteSpace(baogaoid))
            {
                foreach (var item in baogaoid.Split('|'))
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        ORDER_TASK_INFORMATIONID = item.Split('~')[1];
                        if (!Bao.Contains(item.Split('~')[0]))
                        {
                            Bao.Add(item.Split('~')[0]);
                        }

                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(qijuid))
            {
                foreach (var item in qijuid.Split('|'))
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        ORDER_TASK_INFORMATIONID = item.Split('~')[1];
                        if (!Qi.Contains(item.Split('~')[0]))
                            Qi.Add(item.Split('~')[0]);
                    }
                }
            }
            int total = 0;
            if (!string.IsNullOrWhiteSpace(ORDER_TASK_INFORMATIONID))
            {
                List<VQIJULINGQU2> queryData = m_BLL5.GetByParam(null, 1, 100, "DESC", "ID", "ORDER_TASK_INFORMATIONID&" + ORDER_TASK_INFORMATIONID, ref total).Distinct().ToList();
                foreach (var q in queryData)
                {
                    q.REPORTTORECEVESTATE = string.Empty;

                }
                foreach (var item in Bao)
                {
                  
                    foreach (var q in queryData)
                    {
                        if (item == q.PREPARE_SCHEMEID)
                        {
                            q.REPORTTORECEVESTATE = q.REPORTNUMBER;
                        }
                    }
                }
                foreach (var item in Qi)
                {
                    foreach (var q in queryData)
                    {
                        if (item == q.ID)
                        {
                            q.APPLIANCECOLLECTIONSATE = "本次领取";
                        }
                    }
                }
                foreach (var item in queryData)
                {
                    var vq = new VQIJULINGQU2Show()
                    {
                        ID = item.ID,
                        APPLIANCE_NAME = item.APPLIANCE_NAME,
                        VERSION = item.VERSION,
                        FACTORY_NUM = item.FACTORY_NUM,
                        NUM = item.NUM,
                        ATTACHMENT = item.ATTACHMENT,
                        UNDERTAKE_LABORATORYID = item.UNDERTAKE_LABORATORYID,
                        APPLIANCE_RECIVE = item.APPLIANCE_RECIVE,
                        REPORTNUMBER = item.REPORTNUMBER,
                        REMARKS = item.REMARKS,
                        ORDER_TASK_INFORMATIONID = item.ORDER_TASK_INFORMATIONID,
                        APPLIANCECOLLECTIONSATE = item.APPLIANCECOLLECTIONSATE,
                        REPORTTORECEVESTATE = item.REPORTTORECEVESTATE,
                        PREPARE_SCHEMEID = item.PREPARE_SCHEMEID,
                        REPORTSTATUS = item.REPORTSTATUS,
                    };
                    osi.VQIJULINGQU2Show.Add(vq);
                }

            }
            #endregion
            #region 委托单信息数据处理
            ORDER_TASK_INFORMATION oti = m_BLL3.GetById(ORDER_TASK_INFORMATIONID);
            osi.ID = oti.ID;
            osi.ORDER_NUMBER = oti.ORDER_NUMBER;
            osi.ACCEPT_ORGNIZATION = oti.ACCEPT_ORGNIZATION;
            osi.INSPECTION_ENTERPRISE = oti.INSPECTION_ENTERPRISE;
            osi.INSPECTION_ENTERPRISE_ADDRESS = oti.INSPECTION_ENTERPRISE_ADDRESS;
            osi.INSPECTION_ENTERPRISE_POST = oti.INSPECTION_ENTERPRISE_POST;
            osi.CONTACTS = oti.CONTACTS;
            osi.CONTACT_PHONE = oti.CONTACT_PHONE;
            osi.FAX = oti.FAX;
            osi.CERTIFICATE_ENTERPRISE = oti.CERTIFICATE_ENTERPRISE;
            osi.CERTIFICATE_ENTERPRISE_ADDRESS = oti.CERTIFICATE_ENTERPRISE_ADDRESS;
            osi.CERTIFICATE_ENTERPRISE_POST = oti.CERTIFICATE_ENTERPRISE_POST;
            osi.CONTACTS2 = oti.CONTACTS2;
            osi.CONTACT_PHONE2 = oti.CONTACT_PHONE2;
            osi.FAX2 = oti.FAX2;
            osi.CUSTOMER_SPECIFIC_REQUIREMENTS = oti.CUSTOMER_SPECIFIC_REQUIREMENTS;
            osi.ORDER_STATUS = oti.ORDER_STATUS;
            osi.CREATETIME = oti.CREATETIME;
            osi.CREATEPERSON = oti.CREATEPERSON;
            osi.UPDATETIME = oti.UPDATETIME;
            osi.UPDATEPERSON = oti.UPDATEPERSON;
            #endregion
            ViewBag.Id = osi.ID;
            ViewBag.Baogaoid = baogaoid;
            ViewBag.Qijuid = qijuid;
            return View(osi);
        }
        public ActionResult QianZi(string baogaoid, string qijuid, string yemian, string PICTURE)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (baogaoid != null || qijuid != null)
            {   //数据校验          
                string currentPerson = GetCurrentPerson();
                string returnValue = string.Empty;
                //#region 报告领取操作
                //if (!string.IsNullOrWhiteSpace(baogaoid))
                //{
                //    foreach (var item in baogaoid.Split('|'))
                //    {
                //        REPORTCOLLECTION rep = new REPORTCOLLECTION();//报告领取
                //        PREPARE_SCHEME prep = new PREPARE_SCHEME();//预备方案
                //        if (!string.IsNullOrEmpty(item))
                //        {
                //            rep.CREATETIME = DateTime.Now;//领取时间
                //            rep.CREATEPERSON = currentPerson;//领取者
                //            rep.ID = Result.GetNewId();//主键id
                //            rep.PREPARE_SCHEMEID = item.Split('~')[0];//预备方案id
                //            rep.REPORTTORECEVESTATE = Common.REPORTSTATUS.报告已领取.ToString();//报告领取状态
                //            rep.RECEIVEREPORT = yemian;//领取单
                //            prep.ID = item.Split('~')[0];
                //            prep.REPORTSTATUS = Common.REPORTSTATUS.报告已领取.ToString();//报告领取状态
                //            prep.REPORTSTATUSZI = Common.REPORTSTATUS.报告已领取.GetHashCode().ToString();//报告领取状态
                //            if (m_BLL3.Create(ref validationErrors, rep) && m_BLL5.EditField(ref validationErrors, prep))
                //            {
                //                LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，报告领取信息的Id为" + rep.ID, "报告领取");//写入日志        
                //                result.Code = Common.ClientCode.Succeed;
                //                result.Message = Suggestion.InsertSucceed;
                //            }
                //            else
                //            {
                //                if (validationErrors != null && validationErrors.Count > 0)
                //                {
                //                    validationErrors.All(a =>
                //                    {
                //                        returnValue += a.ErrorMessage;
                //                        return true;
                //                    });
                //                }
                //                LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，报告领取信息的Id为" + rep.ID + "," + returnValue, "报告领取");//写入日志
                //                result.Code = Common.ClientCode.Fail;
                //                result.Message = Suggestion.InsertFail + returnValue;
                //                return View(result);
                //            }
                //        }
                //    }
                //}
                //#endregion
                //#region 器具领取操作
                //if (!string.IsNullOrWhiteSpace(qijuid))
                //{
                //    foreach (var item in qijuid.Split('|'))
                //    {
                //        APPLIANCECOLLECTION app = new APPLIANCECOLLECTION();//器具领取
                //        APPLIANCE_LABORATORY appry = new APPLIANCE_LABORATORY();//器具明细信息_承接实验室
                //        APPLIANCE_DETAIL_INFORMATION appion = new APPLIANCE_DETAIL_INFORMATION();//器具明细
                //        if (!string.IsNullOrEmpty(item))
                //        {
                //            app.CREATETIME = DateTime.Now;//领取时间
                //            app.CREATEPERSON = currentPerson;//领取者
                //            app.ID = Result.GetNewId();//主键id
                //            app.APPLIANCE_DETAIL_INFORMATIONID = item.Split('~')[0];//器具明细id
                //            app.APPLIANCECOLLECTIONSATE = Common.ORDER_STATUS.器具已领取.ToString();//器具领取状态
                //            app.RECEIVEINS = yemian;//领取单
                //            appion.APPLIANCE_PROGRESS = null;//所在实验室
                //            appion.ID = item.Split('~')[0];//id
                //            if (!m_BLL6.EditField(ref validationErrors, appion))//修改器具所在实验室数据
                //            {
                //                LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具明细信息的Id为" + appion.ID, "器具领取");//写入日志       
                //                result.Code = Common.ClientCode.Succeed;
                //                result.Message = Suggestion.UpdateFail;
                //                return View(result);
                //            }

                //            List<APPLIANCE_LABORATORY> list = m_BLL4.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(item.Split('~')[0]);
                //            foreach (var item2 in list)
                //            {
                //                appry.ID = item2.ID;
                //                appry.ORDER_STATUS = Common.ORDER_STATUS.器具已领取.ToString();
                //                appry.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.器具已领取.GetHashCode().ToString();
                //                if (!m_BLL4.EditField(ref validationErrors, appry))
                //                {
                //                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具明细信息_承接实验室的Id为" + appry.ID, "器具领取");//写入日志  
                //                    result.Code = Common.ClientCode.Succeed;
                //                    result.Message = Suggestion.UpdateFail;
                //                    return View(result);
                //                }
                //            }
                //            if (m_BLL2.Create(ref validationErrors, app))
                //            {
                //                LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具领取信息的Id为" + app.ID, "器具领取");//写入日志       
                //                result.Code = Common.ClientCode.Succeed;
                //                result.Message = Suggestion.InsertSucceed;
                //            }
                //            else
                //            {
                //                if (validationErrors != null && validationErrors.Count > 0)
                //                {
                //                    validationErrors.All(a =>
                //                    {
                //                        returnValue += a.ErrorMessage;
                //                        return true;
                //                    });
                //                }
                //                LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，器具领取信息的Id为" + app.ID + "," + returnValue, "器具领取"
                //                    );//写入日志   
                //                result.Code = Common.ClientCode.Fail;
                //                result.Message = Suggestion.InsertFail + returnValue;
                //                return View(result);
                //            }
                //        }
                //    }
                //}
                //#endregion
                return View(result);
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "请核对输入的数据的格式";

            return View(result);
        }
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">升序asc（默认）还是降序desc</param>
        /// <param name="sort">排序字段</param>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public JsonResult GetData(string id, int page, int rows, string order, string sort, string search)
        {
            search += "EQUIPMENT_STATUS_VALUUMN&" + Common.ORDER_STATUS.器具已入库.GetHashCode() + "*" + Common.ORDER_STATUS.器具已领取.GetHashCode() + "^" + "REPORTSTATUSZI&" + Common.REPORTSTATUS.报告已打印.GetHashCode() + "*" + Common.REPORTSTATUS.报告已领取.GetHashCode() + "";
            int total = 0;
            var queryData = m_BLL.GetByParamX(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData
            });
        }
        public ActionResult Edit(string id)
        {
            SIGN data = m_BLLSIGN.GetById(id);
           
            if (data != null)
            {
                ViewBag.HTML = data.HTMLVALUE;
                ViewBag.Img = data.PICTURE;
            }


            return View();
        }
        IBLL.ISIGNBLL m_BLLSIGN;
        IBLL.IVQIJULINGQU1BLL m_BLL;
        IBLL.IVQIJULINGQU2BLL m_BLL2;
        IBLL.IORDER_TASK_INFORMATIONBLL m_BLL3;
        IBLL.IPREPARE_SCHEMEBLL m_BLL4;
        IBLL.IVQIJULINGQU2BLL m_BLL5;
        IBLL.IAPPLIANCE_DETAIL_INFORMATIONBLL m_BLL6;

        ValidationErrors validationErrors = new ValidationErrors();

        public VQIJULINGQU1Controller()
            : this(new VQIJULINGQU1BLL(), new VQIJULINGQU2BLL(), new ORDER_TASK_INFORMATIONBLL(), new PREPARE_SCHEMEBLL(), new VQIJULINGQU2BLL(), new APPLIANCE_DETAIL_INFORMATIONBLL(), new SIGNBLL()) { }

        public VQIJULINGQU1Controller(VQIJULINGQU1BLL bll, VQIJULINGQU2BLL bll2, ORDER_TASK_INFORMATIONBLL bll3, PREPARE_SCHEMEBLL bll4, VQIJULINGQU2BLL bll5, APPLIANCE_DETAIL_INFORMATIONBLL bll6, SIGNBLL bll7)
        { 
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
            m_BLL4 = bll4;
            m_BLL5 = bll5; m_BLL6 = bll6;
            m_BLLSIGN = bll7;
        }

    }
}


