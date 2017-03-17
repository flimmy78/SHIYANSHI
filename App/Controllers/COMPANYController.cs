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
    /// 单位
    /// </summary>
    public class COMPANYController : BaseController
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
            COMPANYBLL combll = new COMPANYBLL();
            COMPANY com = new COMPANY();
            com = combll.GetById(id);
            return View(com);
        }

        /// <summary>
        /// 获取树形列表的数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetAllMetadata(string id)
        {
            COMPANYBLL m_BLL = new COMPANYBLL();
            IQueryable<COMPANY> rows = m_BLL.GetAllMetadata(id);
            if (rows.Any())
            {//是否可以省
                return Json(new treegrid
                {
                    rows = rows.Select(s =>
                        new
                        {
                            ID = s.ID
                    ,
                            COMPANYNAME = s.COMPANYNAME
                    ,
                            COMPANYADDRES = s.COMPANYADDRES
                    ,
                            POSTCODE = s.POSTCODE
                    ,
                            CONTACTS = s.CONTACTS
                    ,
                            CONTACTSNUMBER = s.CONTACTSNUMBER
                    ,
                            FAX = s.FAX
                    ,
                            _parentId = s.PARENTID
                    ,
                            state = s.COMPANY1.Any(a => a.PARENTID == s.ID) ? "closed" : null
                    ,
                            CREATETIME = s.CREATETIME
                    ,
                            CREATEPERSON = s.CREATEPERSON
                    ,
                            UPDATETIME = s.UPDATETIME
                    ,
                            UPDATEPERSON = s.UPDATEPERSON

                        }
                        ).OrderBy(o => o.ID)
                });
            }
            return Content("[]");
        }
    }
}


