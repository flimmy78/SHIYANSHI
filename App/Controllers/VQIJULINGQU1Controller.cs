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
    /// 器具领取1
    /// </summary>
    public class VQIJULINGQU1Controller : BaseController
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
            search += "EQUIPMENT_STATUS_VALUUMN&" + Common.ORDER_STATUS.器具已入库.GetHashCode()+"*" + Common.ORDER_STATUS.器具已领取.GetHashCode()+ "^" + "REPORTSTATUSZI&" + Common.REPORTSTATUS.报告已打印.GetHashCode() + "*" + Common.REPORTSTATUS.报告已领取.GetHashCode() + "";
            int total = 0;
            List<VQIJULINGQU1> queryData = m_BLL.GetByParamX(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    ORDER_NUMBER = s.ORDER_NUMBER
                    ,
                    CERTIFICATE_ENTERPRISE = s.CERTIFICATE_ENTERPRISE
                    ,
                    CUSTOMER_SPECIFIC_REQUIREMENTS = s.CUSTOMER_SPECIFIC_REQUIREMENTS
                    ,
                    APPLIANCECOLLECTIONSATE = s.APPLIANCECOLLECTIONSATE
                    ,
                    CREATETIME = s.CREATETIME
                    ,
                    REPORTTORECEVESTATE = s.REPORTTORECEVESTATE

                }

                    )
            });
        }


        IBLL.IVQIJULINGQU1BLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VQIJULINGQU1Controller()
            : this(new VQIJULINGQU1BLL()) { }

        public VQIJULINGQU1Controller(VQIJULINGQU1BLL bll)
        {
            m_BLL = bll;
        }

    }
}


