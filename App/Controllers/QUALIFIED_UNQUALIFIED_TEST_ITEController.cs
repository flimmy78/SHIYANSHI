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
    /// 合格不合格检定项目
    /// </summary>
    public class QUALIFIED_UNQUALIFIED_TEST_ITEController : BaseController
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
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter] 
        public ActionResult Edit(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        /// <summary>
        /// 非表格首次编辑
        /// </summary>
        /// <param name="ITEID">预备方案检测项ID</param>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <param name="RULEID">检测项ID</param>      
        /// <param name="INPUTSTATE">录入格式</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult FeiBiaoGe(string ITEID = "",string PREPARE_SCHEMEID="",string RULEID="",string INPUTSTATE="HGBHG")
        {
            QUALIFIED_UNQUALIFIED_TEST_ITE entity = null;
            ViewBag.ID = "";
            ViewBag.INPUTSTATE = INPUTSTATE;                      
            if (ITEID != null && ITEID.Trim()!="")
            {
                entity = m_BLL.GetById(ITEID);
                ViewBag.ID = entity.ID;                
            }
            if(entity==null)
            {
                entity = new QUALIFIED_UNQUALIFIED_TEST_ITE();
                entity.PREPARE_SCHEMEID = PREPARE_SCHEMEID;
                entity.RULEID = RULEID;
                Langben.IBLL.IRULEBLL rBLL = new RULEBLL();
                DAL.RULE rEntity = rBLL.GetById(RULEID);
                if (rEntity != null)
                {
                    entity.RULENAME = rEntity.NAME;
                    entity.RULENJOINAME = rEntity.NAMEOTHER;
                }
            }
            return View(entity);
        }
        IBLL.IQUALIFIED_UNQUALIFIED_TEST_ITEBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public QUALIFIED_UNQUALIFIED_TEST_ITEController()
                    : this(new QUALIFIED_UNQUALIFIED_TEST_ITEBLL()) { }

        public QUALIFIED_UNQUALIFIED_TEST_ITEController(QUALIFIED_UNQUALIFIED_TEST_ITEBLL bll)
        {
            m_BLL = bll;
        }

    }
}


