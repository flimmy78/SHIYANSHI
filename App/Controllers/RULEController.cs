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
    /// 规程表
    /// </summary>
    public class RULEController : BaseController
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
        IBLL.IRULEBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public RULEController()
                    : this(new RULEBLL()) { }

        public RULEController(RULEBLL bll)
        {
            m_BLL = bll;
        }
        
        /// <summary>
        /// 获取树形列表的数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetAllMetadata(string id)
        {
            RULEBLL m_BLL = new RULEBLL();
            IQueryable<RULE> rows = m_BLL.GetAllMetadata(id);
            if (rows.Any())
            {//是否可以省
                return Json(new treegrid
                {
                    rows = rows.Select(s =>
                        new
                        {
                          ID = s.ID
					,NAMEOTHER = s.NAMEOTHER
					,NAME = s.NAME
					,SCHEME_MENU = s.SCHEME_MENU
					,SORT = s.SORT
					,IS_UNCERTAINTY = s.IS_UNCERTAINTY
					,UNCERTAINTY_MENU = s.UNCERTAINTY_MENU
					,UNDERTAKE_LABORATORYIDOld =   s.UNDERTAKE_LABORATORYID//自连接的表要注意，等号两边可能需要换位
					,INPUTSTATE = s.INPUTSTATE
					,_parentId =   s.PARENTID
					,state = s.RULE1.Any(a => a.PARENTID == s.ID) ? "closed" : null
					,CREATETIME = s.CREATETIME
					,CREATEPERSON = s.CREATEPERSON
					,UPDATETIME = s.UPDATETIME
					,UPDATEPERSON = s.UPDATEPERSON
					
                        }
                        ).OrderBy(o => o.ID)
                });
            }
            return Content("[]");
        }
    }
}


