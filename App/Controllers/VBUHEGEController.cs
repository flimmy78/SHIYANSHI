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
    /// 不合格统计分析
    /// </summary>
    public class VBUHEGEController : BaseController
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
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public JsonResult GetData(string id, int page, int rows, string order, string sort, string search)
        {

            int total = 0;
            List<VBUHEGE> queryData = m_BLL.GetByParam(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,ZHENGSHUBAOGAOBIANHAO = s.ZHENGSHUBAOGAOBIANHAO
					,BUHEGEFENLEI = s.BUHEGEFENLEI
					,BUHEGESHUOMING = s.BUHEGESHUOMING
					,SHIYANSHI = s.SHIYANSHI
					,BAOGAOPIZHUNTONGGUOSHIJIAN = s.BAOGAOPIZHUNTONGGUOSHIJIAN
					,SHOULIDANWEI = s.SHOULIDANWEI
					
                }

                    )
            });
        }

        /// <summary>
        /// 导出报告
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public ActionResult GetData2(string order, string sort, string search)
        {
            int total = 0;
            List<VBUHEGE> queryData = m_BLL.GetByParam(null, 1, 9999, "desc", "ID", search, ref total);       
            string[] fields = "ZHENGSHUBAOGAOBIANHAO,BUHEGEFENLEI,BUHEGESHUOMING,SHIYANSHI,BAOGAOPIZHUNTONGGUOSHIJIAN,SHOULIDANWEI".Split(',');
            var a = Content(WriteExcleVBUHEGE(fields, queryData.ToArray()));
            return a;

        }
        IBLL.IVBUHEGEBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VBUHEGEController()
            : this(new VBUHEGEBLL()) { }

        public VBUHEGEController(VBUHEGEBLL bll)
        {
            m_BLL = bll;
        }
      
    }
}


