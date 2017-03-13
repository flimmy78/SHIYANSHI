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
    /// 证书类别统计分析
    /// </summary>
    public class VZHENGSHULEIBEITONGJIFENXIController : BaseController
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
            List<VZHENGSHULEIBEITONGJIFENXI> queryData = m_BLL.GetByParam(id, page, rows, order, sort, search, ref total);
            //List<VZHENGSHULEIBEITONGJIFENXI> queryData2 = new List<VZHENGSHULEIBEITONGJIFENXI>();
            //var q =
            //from p in queryData
            //group p by new { p.ZHEGNSHUBAOGAOLEIBIE, p.SHOUQUANZIZHI } into g
            //select new
            //{
            // //g.Key,
            //BAOGAOSHULIANG = g.Count(p => p.ZHEGNSHUBAOGAOLEIBIE)
            // };
            var date = queryData.GroupBy(m => (new { ZHEGNSHUBAOGAOLEIBIE = m.ZHEGNSHUBAOGAOLEIBIE, SHOUQUANZIZHI = m.SHOUQUANZIZHI })).Select(g => (new
            {
                ZHEGNSHUBAOGAOLEIBIE = g.Key.ZHEGNSHUBAOGAOLEIBIE,
                SHOUQUANZIZHI = g.Key.SHOUQUANZIZHI,
                BAOGAOSHULIANG = g.Count()
                //BAOGAOSHULIANG =g.Count(t=>t.ZHEGNSHUBAOGAOLEIBIE)
            }));
            int w = date.Count();
            return Json(new datagrid
            {
                total = total,
                rows = date.Select(s => new
                {
                    ID = ""
                    ,
                    SUOSHUDANWEI = ""
                    ,
                    ZHENGSHUDANWEI = ""
                    ,
                    SHOULIDANWEI = ""
                    ,
                    PIZHUNJIELUN = ""
                    ,
                    PIZHUNSHIJIAN = ""
                    ,
                    SHOUQUANZIZHI = s.SHOUQUANZIZHI
                    ,
                    ZHEGNSHUBAOGAOLEIBIE = s.ZHEGNSHUBAOGAOLEIBIE
                    ,
                    BAOGAOSHULIANG = s.BAOGAOSHULIANG

                }

                    )
            });
        }


        IBLL.IVZHENGSHULEIBEITONGJIFENXIBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VZHENGSHULEIBEITONGJIFENXIController()
            : this(new VZHENGSHULEIBEITONGJIFENXIBLL()) { }

        public VZHENGSHULEIBEITONGJIFENXIController(VZHENGSHULEIBEITONGJIFENXIBLL bll)
        {
            m_BLL = bll;
        }

    }
}


