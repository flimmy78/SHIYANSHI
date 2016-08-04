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
    /// 检定任务
    /// </summary>
    public class VJIANDINGRENWUController : BaseController
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
            List<VJIANDINGRENWU> queryData = m_BLL.GetByParam(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,ORDER_NUMBER = s.ORDER_NUMBER
					,APPLIANCE_NAME = s.APPLIANCE_NAME
					,MODEL = s.MODEL
					,FACTORY_NUM = s.FACTORY_NUM
					,CERTIFICATE_ENTERPRISE = s.CERTIFICATE_ENTERPRISE
					,CUSTOMER_SPECIFIC_REQUIREMENTS = s.CUSTOMER_SPECIFIC_REQUIREMENTS
					,ORDER_STATUS = s.ORDER_STATUS
					,CREATEPERSON = s.CREATEPERSON
					,APPLIANCE_PROGRESS = s.APPLIANCE_PROGRESS
					,OVERDUE = s.OVERDUE
					,STATE = s.STATE
					,REPORTSTATUS = s.REPORTSTATUS
					,APPROVAL = s.APPROVAL
					,INSPECTION_ENTERPRISE = s.INSPECTION_ENTERPRISE
					,ISOVERDUE = s.ISOVERDUE
					
                }

                    )
            });
        }


        IBLL.IVJIANDINGRENWUBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VJIANDINGRENWUController()
            : this(new VJIANDINGRENWUBLL()) { }

        public VJIANDINGRENWUController(VJIANDINGRENWUBLL bll)
        {
            m_BLL = bll;
        }
      
    }
}


