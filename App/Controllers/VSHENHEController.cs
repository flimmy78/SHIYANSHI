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
            Common.Account account = GetCurrentAccount();
            string APPLIANCE_DETAIL_INFORMATIONID = string.Empty;
            string[] IDD = id.Split('^');
            FILE_UPLOADER file = m_BLL2.GetPREPARE_SCHEMEID(IDD[0]);
            IList<APPLIANCE_LABORATORY> appliance = m_BLL3.GetByRefPREPARE_SCHEMEID(IDD[0]);
            foreach (var item in appliance)
            {
                if (IDD[1] == "H")
                {
                    if (account.UNDERTAKE_LABORATORYName == item.UNDERTAKE_LABORATORYID)
                    {
                        APPLIANCE_DETAIL_INFORMATIONID = item.APPLIANCE_DETAIL_INFORMATIONID;
                        ViewBag.REPORTSTATUS = item.PREPARE_SCHEME.REPORTSTATUS;//报告状态用来判断是否启用
                    }
                }
                else
                {
                    APPLIANCE_DETAIL_INFORMATIONID = item.APPLIANCE_DETAIL_INFORMATIONID;
                    ViewBag.REPORTSTATUS = item.PREPARE_SCHEME.REPORTSTATUS;//报告状态用来判断是否启用
                }
            }

            ViewBag.HEIFSP = IDD[1];//判断是审核的下载预览还是审批的下载预览
            ViewBag.FILE_UPLOADER_ID = IDD[0];//附件的id
            ViewBag.PREPARE_SCHEME_ID = file.PREPARE_SCHEMEID;//预备方案的id
            ViewBag.APPLIANCE_DETAIL_INFORMATIONID = APPLIANCE_DETAIL_INFORMATIONID;//器具明细的id
            int end = file.FULLPATH.LastIndexOf("\\up");
            string dizhi = file.FULLPATH.Substring(end);
            int end2 = file.FULLPATH2.LastIndexOf("\\up");
            string dizhi2 = file.FULLPATH2.Substring(end);
            ViewBag.FULLPATH = dizhi;//证书地址
            ViewBag.FULLPATH2 = dizhi2;//原始记录地址          
            ViewBag.NAME = file.NAME;//证书名字
            ViewBag.NAME2 = file.NAME2;//原始记录
            ViewBag.CONCLUSION = file.CONCLUSION;//结论
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
            Common.Account account = GetCurrentAccount();
            int total = 0;
            search += "UNDERTAKE_LABORATORYID&" + account.UNDERTAKE_LABORATORYName + "^";
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

                    PACKAGETYPE = s.PACKAGETYPE,
                    FILECONCLUSION = s.FILECONCLUSION,
                    REPORTSTATUS = s.REPORTSTATUS

                }

                    )
            });
        }


        IBLL.IVSHENHEBLL m_BLL;
        IBLL.IFILE_UPLOADERBLL m_BLL2;
        IBLL.IAPPLIANCE_LABORATORYBLL m_BLL3;

        ValidationErrors validationErrors = new ValidationErrors();

        public VSHENHEController()
            : this(new VSHENHEBLL(), new FILE_UPLOADERBLL(), new APPLIANCE_LABORATORYBLL()) { }

        public VSHENHEController(VSHENHEBLL bll, FILE_UPLOADERBLL bll2, APPLIANCE_LABORATORYBLL bll3)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
        }

    }
}


