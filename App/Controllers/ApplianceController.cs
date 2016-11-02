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
    public class ApplianceController : BaseController
    {

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index(string id)
        {
            PREPARE_SCHEME ps = m_BLL5.GetById(id);
            if (!string.IsNullOrWhiteSpace(id))
            {
                ViewBag.REPORTNUMBER = ps.REPORTNUMBER;
            }

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
        [SupportFilter]
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
        /// <summary>
        /// 在查询中输入字符串，自动提示的功能
        /// </summary>
        /// <param name="id">需要查询的数据库字段的名称</param>
        /// <param name="term">输入的字符串</param>
        /// <returns></returns> 
        public ActionResult SearchAutoComplete(string id, string term)
        {
            return new ContentResult() { Content = m_BLL.SearchAutoComplete(id, term) };
        }

        /// <summary>
        /// 制造单位下拉框数据绑定
        /// </summary>
        /// <returns></returns>
        public ActionResult Getdate()
        {
            return new ContentResult() { Content = m_BLL2.Getdate() };
        }
        IBLL.IAPPLIANCE_DETAIL_INFORMATIONBLL m_BLL;
        IBLL.ICOMPANYBLL m_BLL2;
        IBLL.IPREPARE_SCHEMEBLL m_BLL5;

        ValidationErrors validationErrors = new ValidationErrors();

        public ApplianceController() : this(new APPLIANCE_DETAIL_INFORMATIONBLL(), new COMPANYBLL(), new PREPARE_SCHEMEBLL()) { }

        public ApplianceController(APPLIANCE_DETAIL_INFORMATIONBLL bll, COMPANYBLL bll2, PREPARE_SCHEMEBLL bll5)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL5 = bll5;
        }

    }
}


