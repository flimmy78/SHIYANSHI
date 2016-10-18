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
    /// 器具领取2
    /// </summary>
    public class VQIJULINGQU2Controller : BaseController
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
            List<VQIJULINGQU2> queryData = m_BLL.GetByParam(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    APPLIANCE_NAME = s.APPLIANCE_NAME
                    ,
                    VERSION = s.VERSION
                    ,
                    FACTORY_NUM = s.FACTORY_NUM
                    ,
                    NUM = s.NUM
                    ,
                    ATTACHMENT = s.ATTACHMENT
                    ,
                    UNDERTAKE_LABORATORYID = s.UNDERTAKE_LABORATORYID
                    ,
                    APPLIANCE_RECIVE = s.APPLIANCE_RECIVE
                    ,
                    REPORTNUMBER = s.REPORTNUMBER
                    ,
                    REMARKS = s.REMARKS
                    ,
                    ORDER_TASK_INFORMATIONID = s.ORDER_TASK_INFORMATIONID
                    ,
                    APPLIANCECOLLECTIONSATE=s.APPLIANCECOLLECTIONSATE
                    ,
                    REPORTTORECEVESTATE=s.REPORTTORECEVESTATE

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
        public JsonResult PostDataByID(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {

                id = "ORDER_TASK_INFORMATIONID&" + id;
            }
            int total = 0;
            List<VQIJULINGQU2> queryData = m_BLL.GetByParam(id, 1, 100, "DESC", "ID", id, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    APPLIANCE_NAME = s.APPLIANCE_NAME
                    ,
                    VERSION = s.VERSION
                    ,
                    FACTORY_NUM = s.FACTORY_NUM
                    ,
                    NUM = s.NUM
                    ,
                    ATTACHMENT = s.ATTACHMENT
                    ,
                    UNDERTAKE_LABORATORYID = s.UNDERTAKE_LABORATORYID
                    ,
                    APPLIANCE_RECIVE = s.APPLIANCE_RECIVE
                    ,
                    REPORTNUMBER = s.REPORTNUMBER
                    ,
                    REMARKS = s.REMARKS
                    ,
                    ORDER_TASK_INFORMATIONID = s.ORDER_TASK_INFORMATIONID
                    ,
                    PREPARE_SCHEMEID=s.PREPARE_SCHEMEID
                    ,
                    APPLIANCECOLLECTIONSATE=s.APPLIANCECOLLECTIONSATE
                    ,
                    REPORTTORECEVESTATE=s.REPORTTORECEVESTATE

                }

                    )
            });
        }

        IBLL.IVQIJULINGQU2BLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VQIJULINGQU2Controller()
            : this(new VQIJULINGQU2BLL()) { }

        public VQIJULINGQU2Controller(VQIJULINGQU2BLL bll)
        {
            m_BLL = bll;
        }

    }
}


