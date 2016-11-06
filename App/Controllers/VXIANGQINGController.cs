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
    /// 报告器具领取详情
    /// </summary>
    public class VXIANGQINGController : BaseController
    {

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index(string id)
        {
            ViewBag.Id = id;
            return View();
        }
           
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public JsonResult GetData(string id, int page, int rows, string order, string sort, string search)
        {

            int total = 0;

            List<VXIANGQING> queryData = m_BLL.GetByParam(id, page, 999, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,DD = s.DD
					,ORDER_TASK_INFORMATIONID = s.ORDER_TASK_INFORMATIONID
					,APPLIANCE_NAME = s.APPLIANCE_NAME
					,STATE = s.STATE
					,RECEIVEINS = s.RECEIVEINS
					,CREATEPERSON = s.CREATEPERSON
					,CREATETIME = s.CREATETIME
					
                }

                    )
            });
        }


        IBLL.IVXIANGQINGBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VXIANGQINGController()
            : this(new VXIANGQINGBLL()) { }

        public VXIANGQINGController(VXIANGQINGBLL bll)
        {
            m_BLL = bll;
        }
      
    }
}


