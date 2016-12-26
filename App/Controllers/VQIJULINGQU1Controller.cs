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
                        Bao.Add(item.Split('~')[0]);
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
                        Qi.Add(item.Split('~')[0]);
                    }
                }
            }
            int total = 0;
            if (!string.IsNullOrWhiteSpace(ORDER_TASK_INFORMATIONID))
            {
                List<VQIJULINGQU2> queryData = m_BLL5.GetByParam(null, 1, 100, "DESC", "ID", "ORDER_TASK_INFORMATIONID&" + ORDER_TASK_INFORMATIONID, ref total).Distinct().ToList();
                foreach (var item in Bao)
                {
                    foreach (var q in queryData)
                    {
                        if (item == q.PREPARE_SCHEMEID)
                        {
                            q.REPORTTORECEVESTATE = "已领取";
                        }
                    }
                }
                foreach (var item in Qi)
                {
                    foreach (var q in queryData)
                    {
                        if (item == q.ID)
                        {
                            q.APPLIANCECOLLECTIONSATE = "已领取";
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
            ViewBag.Baogaoid = baogaoid;
            ViewBag.Qijuid = qijuid;
            return View(osi);
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
            List<VQIJULINGQU1> queryData = m_BLL.GetByParamX(id, page, rows, order, sort, search, ref total).Distinct().ToList();
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    ORDER_NUMBER = s.ORDER_NUMBER
                    ,
                    CERTIFICATE_ENTERPRISE = s.CERTIFICATE_ENTERPRISE
                    ,
                    CUSTOMER_SPECIFIC_REQUIREMENTS = s.CUSTOMER_SPECIFIC_REQUIREMENTS
                    ,
                    APPLIANCECOLLECTIONSATE = s.APPLIANCECOLLECTIONSATE
                    ,
                    CREATETIME = s.CREATETIME
                    ,
                    REPORTTORECEVESTATE = s.REPORTTORECEVESTATE

                }

                    )
            });
        }


        IBLL.IVQIJULINGQU1BLL m_BLL;
        IBLL.IVQIJULINGQU2BLL m_BLL2;
        IBLL.IORDER_TASK_INFORMATIONBLL m_BLL3;
        IBLL.IPREPARE_SCHEMEBLL m_BLL4;
        IBLL.IVQIJULINGQU2BLL m_BLL5;

        ValidationErrors validationErrors = new ValidationErrors();

        public VQIJULINGQU1Controller()
            : this(new VQIJULINGQU1BLL(), new VQIJULINGQU2BLL(), new ORDER_TASK_INFORMATIONBLL(), new PREPARE_SCHEMEBLL(), new VQIJULINGQU2BLL()) { }

        public VQIJULINGQU1Controller(VQIJULINGQU1BLL bll, VQIJULINGQU2BLL bll2, ORDER_TASK_INFORMATIONBLL bll3, PREPARE_SCHEMEBLL bll4, VQIJULINGQU2BLL bll5)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
            m_BLL4 = bll4;
            m_BLL5 = bll5;
        }

    }
}


