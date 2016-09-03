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

namespace Langben.App.Controllers
{
    /// <summary>
    /// 审核
    /// </summary>
    public class VSHENHEController : BaseController
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
        /// 预览审核
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult YuLanShenHe(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        /// <summary>
        /// 下载审核
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult XiaZaiShenHe(string id)
        {
            string[] IDD = id.Split('*');
            m_BLL2.GetByRefPREPARE_SCHEMEID(IDD[0]);
            ViewBag.Id = id;
            return View();
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

            int total = 0;
            search += "REPORTSTATUSZI&" + Common.REPORTSTATUS.审核驳回.GetHashCode() + "*" + Common.REPORTSTATUS.待审核.GetHashCode() + "*" + Common.REPORTSTATUS.待批准.GetHashCode() + "";
            List<VSHENHE> queryData = m_BLL.GetByParamX(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    REPORTNUMBER = s.REPORTNUMBER
                    ,
                    ORDER_NUMBER = s.ORDER_NUMBER
                    ,
                    APPLIANCE_NAME = s.APPLIANCE_NAME
                    ,
                    VERSION = s.VERSION
                    ,
                    FACTORY_NUM = s.FACTORY_NUM
                    ,
                    CERTIFICATE_ENTERPRISE = s.CERTIFICATE_ENTERPRISE
                    ,
                    CUSTOMER_SPECIFIC_REQUIREMENTS = s.CUSTOMER_SPECIFIC_REQUIREMENTS
                    ,
                    CERTIFICATE_CATEGORY = s.CERTIFICATE_CATEGORY
                    ,
                    QUALIFICATIONS = s.QUALIFICATIONS
                    ,
                    CONCLUSION_EXPLAIN = s.CONCLUSION_EXPLAIN
                    ,
                    CONCLUSION = s.CONCLUSION
                    ,
                    ISAGGREY = s.ISAGGREY,

                    PACKAGETYPE = s.PACKAGETYPE

                }

                    )
            });
        }


        IBLL.IVSHENHEBLL m_BLL;
        IBLL.IFILE_UPLOADERBLL m_BLL2;

        ValidationErrors validationErrors = new ValidationErrors();

        public VSHENHEController()
            : this(new VSHENHEBLL(),new FILE_UPLOADERBLL()) { }

        public VSHENHEController(VSHENHEBLL bll, FILE_UPLOADERBLL bll2)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
        }

    }
}


