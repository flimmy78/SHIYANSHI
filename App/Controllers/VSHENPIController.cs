﻿using System;
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
using System.IO;
using System.Web.UI;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 审批
    /// </summary>
    public class VSHENPIController : BaseController
    {
        public ActionResult ZaiXianShenHe(string id)
        {
            Common.Account account = GetCurrentAccount();
            string APPLIANCE_DETAIL_INFORMATIONID = string.Empty;
            string[] IDD = id.Split('^');
            PREPARE_SCHEME pr = m_BLL4.GetById(IDD[0]);
            FILE_UPLOADER file = m_BLL2.GetPREPARE_SCHEMEID(IDD[0]);
            //IList<APPLIANCE_LABORATORY> appliance = m_BLL3.GetByRefPREPARE_SCHEMEID(IDD[0]);
            foreach (var item in pr.APPLIANCE_LABORATORY)
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
            string x = "/";
            string sx = @"\";
            ViewBag.FULLPATH = dizhi.Replace(sx, x);//证书地址
            ViewBag.FULLPATH2 = dizhi2.Replace(sx, x);//原始记录地址          
            ViewBag.NAME = file.NAME;//证书名字
            ViewBag.NAME2 = file.NAME2;//原始记录
            ViewBag.CONCLUSION = file.CONCLUSION;//结论
            ViewBag.AUDITOPINION = pr.AUDITOPINION;//审核意见
            ViewBag.APPROVAL = pr.APPROVAL;//审批意见

            return View();
        }
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
        public ActionResult YuLanShenPi(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        /// <summary>
        /// 预览审核
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult XiaZaiShenPi(string id)
        {
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
            if (string.IsNullOrWhiteSpace(search))
            {
                search += "REPORTSTATUS&" + Common.REPORTSTATUS.待批准;

            }

            List<VSHENPI> queryData = m_BLL.GetByParamX(id, page, rows, order, sort, search, ref total);            
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
                    UNDERTAKE_LABORATORYID = s.UNDERTAKE_LABORATORYID
                    ,
                    APPROVALISAGGREY = s.APPROVALISAGGREY
                    ,
                    PACKAGETYPE = s.PACKAGETYPE,
                    FILECONCLUSION=s.FILECONCLUSION,
                    REPORTSTATUS=s.REPORTSTATUS

                }

                    )
            });
        }
        public ActionResult BaoGao(string id)
        { //定义Workbook对象
            PageOffice.ExcelWriter.Workbook workBook = new PageOffice.ExcelWriter.Workbook();
      
            System.Web.UI.Page page = new System.Web.UI.Page();

            string controlOutput = string.Empty;
            PageOffice.PageOfficeCtrl pc = new PageOffice.PageOfficeCtrl();
            pc.ID = "PageOfficeCtrl1";
            pc.ServerPage = "/pageoffice/server.aspx";
            // 设置文件打开后执行的js function
            pc.JsFunction_AfterDocumentOpened = "AfterDocumentOpened()";
            string filePath = Server.MapPath(id.Replace("..", "~"));
            pc.Caption = "------------------------------------^o^------------------双击我，报告最大化------------------^o^------------------------------------";

            pc.SetWriter(workBook);
            pc.WebOpen(filePath, PageOffice.OpenModeType.xlsReadOnly, "13718511828");

            page.Controls.Add(pc);
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    Server.Execute(page, htw, false);
                    controlOutput = sb.ToString();
                }
            }
            ViewBag.EditorHtml22 = controlOutput;


            return View();
        }

        IBLL.IVSHENPIBLL m_BLL;
        IBLL.IFILE_UPLOADERBLL m_BLL2;
  
        IBLL.IPREPARE_SCHEMEBLL m_BLL4;
        ValidationErrors validationErrors = new ValidationErrors();

        public VSHENPIController()
            : this(new VSHENPIBLL(), new FILE_UPLOADERBLL(),  new PREPARE_SCHEMEBLL()) { }

        public VSHENPIController(VSHENPIBLL bll, FILE_UPLOADERBLL bll2,   PREPARE_SCHEMEBLL bll4)
        {
            m_BLL = bll; m_BLL2 = bll2;
           
            m_BLL4 = bll4;
        }

    }
}


