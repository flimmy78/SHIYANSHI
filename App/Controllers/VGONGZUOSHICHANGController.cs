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
    /// 工作时长查询
    /// </summary>
    public class VGONGZUOSHICHANGController : BaseController
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
            List<VGONGZUOSHICHANG> queryData = m_BLL.GetByParam(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,WEITUODANWEI = s.WEITUODANWEI
					,SUOSHUDANWEI = s.SUOSHUDANWEI
					,ZHENGSHUDANWEI = s.ZHENGSHUDANWEI
					,SHOULIDANWEI = s.SHOULIDANWEI
					,QIJUMINGCHENG = s.QIJUMINGCHENG
					,SHENGCHANCHANGJIA = s.SHENGCHANCHANGJIA
					,QIJUXINGHAO = s.QIJUXINGHAO
					,QIJUGUIGE = s.QIJUGUIGE
					,CHUCHANGBIANHAO = s.CHUCHANGBIANHAO
					,SHULIANG = s.SHULIANG
					,ZHENGSHUBAOGAOBIANHAO = s.ZHENGSHUBAOGAOBIANHAO
					,SHIYANSHI = s.SHIYANSHI
					,JIANDINGXIAOZHUNYUAN = s.JIANDINGXIAOZHUNYUAN
					,HEYANYUAN = s.HEYANYUAN
					,WEITUORIQI = s.WEITUORIQI
					,SHIYANSHIJIESHOUSHIJIAN = s.SHIYANSHIJIESHOUSHIJIAN
					,JIANDINGWANCHENGRIQI = s.JIANDINGWANCHENGRIQI
					,SHENHERIQI = s.SHENHERIQI
					,PIZHUNRIQI = s.PIZHUNRIQI

					,DAILINGQUSHICHANG = s.SHIYANSHIJIESHOUSHIJIAN==null?"0":(Convert.ToDateTime(s.SHIYANSHIJIESHOUSHIJIAN)- Convert.ToDateTime(s.WEITUORIQI)).Days.ToString()
                    ,
                    JIANDINGSHICHANG = s.SHIYANSHIJIESHOUSHIJIAN == null && s.JIANDINGWANCHENGRIQI==null ? "0":(Convert.ToDateTime(s.JIANDINGWANCHENGRIQI) - Convert.ToDateTime(s.SHIYANSHIJIESHOUSHIJIAN)).Days.ToString() 
                    ,
                    SHENHESHICHANG = s.SHENHERIQI == null && s.JIANDINGWANCHENGRIQI == null ?"0": (Convert.ToDateTime(s.SHENHERIQI) - Convert.ToDateTime(s.JIANDINGWANCHENGRIQI)).Days.ToString() 
                    ,
                    PIZHUNSHICHANG = s.SHENHERIQI == null && s.PIZHUNRIQI == null ? "0":(Convert.ToDateTime(s.PIZHUNRIQI) - Convert.ToDateTime(s.SHENHERIQI)).Days.ToString()
                    ,
                    ZONGSHICHANG = s.WEITUORIQI == null && s.PIZHUNRIQI == null ?"0" :(Convert.ToDateTime(s.PIZHUNRIQI) - Convert.ToDateTime(s.WEITUORIQI)).Days.ToString()
                    ,
                    BEIZHU = s.BEIZHU
					
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
            List<VGONGZUOSHICHANG> queryData = m_BLL.GetByParam(null, 1, 9999, "desc", "ID", search, ref total);

           var rows = queryData.Select(s => new
            {
                ID = s.ID
                    ,
                WEITUODANWEI = s.WEITUODANWEI
                    ,
                SUOSHUDANWEI = s.SUOSHUDANWEI
                    ,
                ZHENGSHUDANWEI = s.ZHENGSHUDANWEI
                    ,
                SHOULIDANWEI = s.SHOULIDANWEI
                    ,
                QIJUMINGCHENG = s.QIJUMINGCHENG
                    ,
                SHENGCHANCHANGJIA = s.SHENGCHANCHANGJIA
                    ,
                QIJUXINGHAO = s.QIJUXINGHAO
                    ,
                QIJUGUIGE = s.QIJUGUIGE
                    ,
                CHUCHANGBIANHAO = s.CHUCHANGBIANHAO
                    ,
                SHULIANG = s.SHULIANG
                    ,
                ZHENGSHUBAOGAOBIANHAO = s.ZHENGSHUBAOGAOBIANHAO
                    ,
                SHIYANSHI = s.SHIYANSHI
                    ,
                JIANDINGXIAOZHUNYUAN = s.JIANDINGXIAOZHUNYUAN
                    ,
                HEYANYUAN = s.HEYANYUAN
                    ,
                WEITUORIQI = s.WEITUORIQI
                    ,
                SHIYANSHIJIESHOUSHIJIAN = s.SHIYANSHIJIESHOUSHIJIAN
                    ,
                JIANDINGWANCHENGRIQI = s.JIANDINGWANCHENGRIQI
                    ,
                SHENHERIQI = s.SHENHERIQI
                    ,
                PIZHUNRIQI = s.PIZHUNRIQI

                    ,
                DAILINGQUSHICHANG = s.SHIYANSHIJIESHOUSHIJIAN == null ? "0" : (Convert.ToDateTime(s.SHIYANSHIJIESHOUSHIJIAN) - Convert.ToDateTime(s.WEITUORIQI)).Days.ToString()
                    ,
                JIANDINGSHICHANG = s.SHIYANSHIJIESHOUSHIJIAN == null && s.JIANDINGWANCHENGRIQI == null ? "0" : (Convert.ToDateTime(s.JIANDINGWANCHENGRIQI) - Convert.ToDateTime(s.SHIYANSHIJIESHOUSHIJIAN)).Days.ToString()
                    ,
                SHENHESHICHANG = s.SHENHERIQI == null && s.JIANDINGWANCHENGRIQI == null ? "0" : (Convert.ToDateTime(s.SHENHERIQI) - Convert.ToDateTime(s.JIANDINGWANCHENGRIQI)).Days.ToString()
                    ,
                PIZHUNSHICHANG = s.SHENHERIQI == null && s.PIZHUNRIQI == null ? "0" : (Convert.ToDateTime(s.PIZHUNRIQI) - Convert.ToDateTime(s.SHENHERIQI)).Days.ToString()
                    ,
                ZONGSHICHANG = s.WEITUORIQI == null && s.PIZHUNRIQI == null ? "0" : (Convert.ToDateTime(s.PIZHUNRIQI) - Convert.ToDateTime(s.WEITUORIQI)).Days.ToString()
                    ,
                BEIZHU = s.BEIZHU

            }).ToList();

            string[] fields = "WEITUODANWEI,SUOSHUDANWEI,ZHENGSHUDANWEI,SHOULIDANWEI,QIJUMINGCHENG,SHENGCHANCHANGJIA,QIJUXINGHAO,QIJUGUIGE,CHUCHANGBIANHAO,SHULIANG,ZHENGSHUBAOGAOBIANHAO,SHIYANSHI,JIANDINGXIAOZHUNYUAN,HEYANYUAN,WEITUORIQI,SHIYANSHIJIESHOUSHIJIAN,JIANDINGWANCHENGRIQI,SHENHERIQI,PIZHUNRIQI,DAILINGQUSHICHANG,JIANDINGSHICHANG,SHENHESHICHANG,PIZHUNSHICHANG,ZONGSHICHANG,BEIZHU".Split(',');
            var a = Content(WriteExcleVGONGZUOSHICHANG(fields, rows.ToArray()));
            return a;

        }
        IBLL.IVGONGZUOSHICHANGBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VGONGZUOSHICHANGController()
            : this(new VGONGZUOSHICHANGBLL()) { }

        public VGONGZUOSHICHANGController(VGONGZUOSHICHANGBLL bll)
        {
            m_BLL = bll;
        }

    }
}


