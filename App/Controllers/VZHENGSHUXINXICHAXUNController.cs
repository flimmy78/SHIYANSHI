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
    /// 证书信息查询
    /// </summary>
    public class VZHENGSHUXINXICHAXUNController : BaseController
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
            List<VZHENGSHUXINXICHAXUN> queryData = m_BLL.GetByParam(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,SONGJIANDANWEI = s.SONGJIANDANWEI
					,ZHENGSHUDANWEI = s.ZHENGSHUDANWEI
					,SHOULIDANWEI = s.SHOULIDANWEI
					,CHUCHANGRIQI = s.CHUCHANGRIQI
					,QIJUMINGCHENG = s.QIJUMINGCHENG
					,SHENGCHANCHANGJIA = s.SHENGCHANCHANGJIA
					,QIJUXINGHAO = s.QIJUXINGHAO
					,CHUCHANGBIANHAO = s.CHUCHANGBIANHAO
					,ZHUNQUEDUDENGJI = s.ZHUNQUEDUDENGJI
					,JIANDINGRIQI = s.JIANDINGRIQI
					,WENDU = s.WENDU
					,XIANGDUISHIDU = s.XIANGDUISHIDU
					,MOCHONGCHANGSHU = s.MOCHONGCHANGSHU
					,QIJUGUIGE = s.QIJUGUIGE
					,JIANDINGXIAOZHUNYUAN = s.JIANDINGXIAOZHUNYUAN
					,HEYANYUAN = s.HEYANYUAN
					,YOUXIAOQI = s.YOUXIAOQI
					,YOUXIAOQIZHI = s.YOUXIAOQIZHI
					,ZHENGSHUBAOGAOBIANHAO = s.ZHENGSHUBAOGAOBIANHAO
					,ZHENGSHULEIBIE = s.ZHENGSHULEIBIE
					,BAOGAOLEIBIE = s.BAOGAOLEIBIE
					,SHOUQUANZIZHI = s.SHOUQUANZIZHI
					,FAFANGZHUANGTAI = s.FAFANGZHUANGTAI
					,SUOSHUDANWEI = s.SUOSHUDANWEI
					,WEITUODANWEI = s.WEITUODANWEI
					,BEIZHU = s.BEIZHU
					
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
            List<VZHENGSHUXINXICHAXUN> queryData = m_BLL.GetByParam(null, 1, 9999, "desc", "ID", search, ref total);
            string[] fields = "SONGJIANDANWEI,ZHENGSHUDANWEI,SHOULIDANWEI,CHUCHANGRIQI,QIJUMINGCHENG,SHENGCHANCHANGJIA,QIJUXINGHAO,CHUCHANGBIANHAO,ZHUNQUEDUDENGJI,JIANDINGRIQI,WENDU,XIANGDUISHIDU,MOCHONGCHANGSHU,QIJUGUIGE,JIANDINGXIAOZHUNYUAN,HEYANYUAN,YOUXIAOQI,YOUXIAOQIZHI,ZHENGSHUBAOGAOBIANHAO,ZHENGSHULEIBIE,BAOGAOLEIBIE,SHOUQUANZIZHI,FAFANGZHUANGTAI,SUOSHUDANWEI,WEITUODANWEI,BEIZHU".Split(',');
            var a = Content(WriteExcleVZHENGSHUXINXICHAXUN(fields, queryData.ToArray()));
            return a;
               
        }
        IBLL.IVZHENGSHUXINXICHAXUNBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VZHENGSHUXINXICHAXUNController()
            : this(new VZHENGSHUXINXICHAXUNBLL()) { }

        public VZHENGSHUXINXICHAXUNController(VZHENGSHUXINXICHAXUNBLL bll)
        {
            m_BLL = bll;
        }
      
    }
}


