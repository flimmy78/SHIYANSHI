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
using Webdiyer.WebControls.Mvc;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 预备方案
    /// </summary>
    public class PREPARE_SCHEMEController : BaseController
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
        /// 首次编辑
        /// </summary>
        /// <param name="id">预备方案主键</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns> 
        [SupportFilter] 
        public ActionResult Edit(string ID="")
        {
            Langben.App.Models.VTEST_ITE_YuBei result = new Models.VTEST_ITE_YuBei();
            ViewBag.ID = ID;
            ViewBag.SCHEMEID = "";
            DAL.PREPARE_SCHEME entity = m_BLL.GetById(ID);
            List<VTEST_ITE> vList = null;
            if (entity != null)
            {
                result.prepare_scheme = entity;
                ViewBag.ID = entity.ID;
                ViewBag.SCHEMEID = entity.SCHEMEID;
                IBLL.IVTEST_ITEBLL vBLL = new VTEST_ITEBLL();
                vList= vBLL.GetByPREPARE_SCHEMEID(entity.ID);
                result.vtest_ite = new PagedList<VTEST_ITE>(vList,1,int.MaxValue);
            }
            else
            {
                entity = new PREPARE_SCHEME();
                result.prepare_scheme = entity;
            }
            return View(result);
        }
        IBLL.IPREPARE_SCHEMEBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public PREPARE_SCHEMEController()
                    : this(new PREPARE_SCHEMEBLL()) { }

        public PREPARE_SCHEMEController(PREPARE_SCHEMEBLL bll)
        {
            m_BLL = bll;
        }

    }
}


