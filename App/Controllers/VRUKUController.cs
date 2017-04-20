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
    /// 入库
    /// </summary>
    public class VRUKUController : BaseController
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
            List<VRUKU> queryData = new List<VRUKU>();//m_BLL.GetByParamX(id, page, rows, order, sort, search, ref total).Where(w => w.EQUIPMENT_STATUS_VALUUMN != "器具已领取").ToList();
            string STORAGEINSTRUCTI_STATU = string.Empty;
            Dictionary<string, string> queryDic = ValueConvert.StringToDictionary(search.GetString());
            foreach (var item in queryDic)
            {
                if (item.Key == "STORAGEINSTRUCTI_STATU")
                {
                    STORAGEINSTRUCTI_STATU = item.Value;
                }
            }

            if (STORAGEINSTRUCTI_STATU == Common.ORDER_STATUS.待入库.ToString() || search == null)
            {
                if (search != null)
                {
                    int end = search.LastIndexOf("^STORAGEINSTRUCTI_STATU&");
                    search = search.Substring(0, end) + "^";
                }
                search += "EQUIPMENT_STATUS_VALUUMN&" + Common.ORDER_STATUS.待入库.GetHashCode() + "^";
                id = Common.ORDER_STATUS.器具已入库.GetHashCode().ToString();
                search += "REPORTSTATUSZI&" + Common.REPORTSTATUS.批准驳回.GetHashCode() + "*" + Common.REPORTSTATUS.已批准.GetHashCode() + "*" + Common.REPORTSTATUS.待批准.GetHashCode() + "*" + Common.REPORTSTATUS.报告已打印.GetHashCode() + "*" + Common.REPORTSTATUS.报告已领取.GetHashCode() + "";

            }
            else if (STORAGEINSTRUCTI_STATU == Common.ORDER_STATUS.器具已入库.ToString())
            {
                int end = search.LastIndexOf("^STORAGEINSTRUCTI_STATU&");
                search = search.Substring(0, end);
                search += "^EQUIPMENT_STATUS_VALUUMN&" + Common.ORDER_STATUS.器具已入库.GetHashCode() + "";

            }
            else
            {
                search += "^EQUIPMENT_STATUS_VALUUMN&" + Common.ORDER_STATUS.待入库.GetHashCode() + "*" + Common.ORDER_STATUS.器具已入库.GetHashCode() + "";
                search += "^REPORTSTATUSZI&" + Common.REPORTSTATUS.批准驳回.GetHashCode() + "*" + Common.REPORTSTATUS.已批准.GetHashCode() + "*" + Common.REPORTSTATUS.待批准.GetHashCode() + "*" + Common.REPORTSTATUS.报告已打印.GetHashCode() + "*" + Common.REPORTSTATUS.报告已领取.GetHashCode() + "";

            }
            queryData = m_BLL.GetByParamX(id, page, rows, order, sort, search, ref total);


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
                    APPLIANCE_PROGRESS = s.APPLIANCE_PROGRESS
                    ,
                    ORDER_STATUS = s.ORDER_STATUS
                    ,
                    STORAGEINSTRUCTIONS = s.STORAGEINSTRUCTIONS
                    ,
                    APPROVALDATE = s.APPROVALDATE
                    ,
                    STORAGEINSTRUCTI_STATU = s.STORAGEINSTRUCTI_STATU
                    ,
                    BAR_CODE_NUM=s.BAR_CODE_NUM
                }

                    )
            });
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
        public ActionResult GetData2(string order, string sort, string search)
        {
            var data = m_BLL.GetAll();
            string[] id = search.TrimEnd(',').Split(',');
            var a = from d in data
                    from i in id
                    where d.ID == i
                    select d;
            List<VRUKU> queryData = a.ToList();
            string[] fields = "BAR_CODE_NUM,ORDER_NUMBER,APPLIANCE_NAME,VERSION,FACTORY_NUM,CERTIFICATE_ENTERPRISE,CUSTOMER_SPECIFIC_REQUIREMENTS,APPLIANCE_PROGRESS,ORDER_STATUS,STORAGEINSTRUCTIONS".Split(',');
            return Content(WriteExcleRuKu(fields, queryData.ToArray()));
        }



        IBLL.IVRUKUBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VRUKUController()
            : this(new VRUKUBLL()) { }

        public VRUKUController(VRUKUBLL bll)
        {
            m_BLL = bll;
        }

    }
}


