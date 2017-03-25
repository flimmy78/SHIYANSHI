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
    /// 实验室别工作量统计分析
    /// </summary>
    public class VSHIYANSHIGONGZUOLIANGController : BaseController
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
        [SupportFilter]
        public ActionResult RenYuan()
        {

            return View();
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult ZhengShu()
        {

            return View();
        }
        /// <summary>
        /// 所属单位别工作量统计
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult DanWei()
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
        //工作量统计分析
        public JsonResult GetData(string id = "", int page = 11, int rows = 11, string order = "", string sort = "", string search = "")
        {
            try
            {
                int total = 0;
                page = 1;
                rows = 9999;
                List<SHIYANSHIGONGZUO_Result> queryData = m_BLL.GetByParam(id, page, rows, order, sort, search, ref total);
                return Json(new datagrid
                {
                    total = total,
                    rows = queryData.Select(s => new
                    {
                        ID = s.ID
                        ,
                        WEITUODAN = s.WEITUODAN
                        ,
                        JIANDINGWANCHENG = s.JIANDINGWANCHENG
                        ,
                        SHEBEIGUZHANG = s.SHEBEIGUZHANG
                        ,
                        PIZHUNTONGGUO = s.PIZHUNTONGGUO
                        ,
                        HEGE = s.HEGE
                        ,
                        BUHEGE = s.BUHEGE
                        ,
                        CHAOQI = s.CHAOQI

                    }

                        )
                });
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message + "@");
                validationErrors.Add(ex.Source + "@");
                validationErrors.Add(ex.StackTrace + "@");
                validationErrors.Add(ex.HelpLink + "@");
                validationErrors.Add(ex.HResult.ToString() + "@");

                if (ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Message))
                {
                    validationErrors.Add(ex.InnerException.Message);
                }
                if (ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Source))
                {
                    validationErrors.Add(ex.InnerException.Source);
                }
                if (ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.StackTrace))
                {
                    validationErrors.Add(ex.InnerException.StackTrace);
                }
                if (ex.InnerException != null && null != (ex.InnerException.TargetSite))
                {
                    validationErrors.Add(ex.InnerException.TargetSite.Name);
                }

                if (ex.Data != null)
                {
                    validationErrors.Add(ex.Data.Count.ToString());
                }
                if (ex.Data != null)
                {
                    foreach (KeyValuePair<string, string> kvp in ex.Data.Keys)
                    {
                        validationErrors.Add(string.Format("姓名：{0},电影：{1}", kvp.Key, kvp.Value));
                    }
                }

                if (ex.TargetSite != null)
                {
                    validationErrors.Add(ex.TargetSite.Name);
                }
                if (ex.TargetSite != null)
                {
                    validationErrors.Add(ex.TargetSite.ReflectedType.ToString());
                }
                if (ex.TargetSite != null)
                {
                    validationErrors.Add(ex.TargetSite.Module.ToString());
                }
                if (ex.TargetSite != null)
                {
                    validationErrors.Add(ex.TargetSite.MethodImplementationFlags.ToString());
                }
                if (ex.TargetSite != null)
                {
                    validationErrors.Add(ex.TargetSite.MethodHandle.ToString());
                }
                if (ex.TargetSite != null)
                {
                    validationErrors.Add(ex.TargetSite.MetadataToken.ToString());
                }

                string returnValue = string.Empty;
                if (validationErrors != null && validationErrors.Count > 0)
                {
                    validationErrors.All(a =>
                    {
                        returnValue += a.ErrorMessage;
                        return true;
                    });
                }
                LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，人员的信息，dd" + returnValue, "人员"
                    );//写入日志   
                ExceptionsHander.WriteExceptions(ex);
                throw ex;
            }
        }
        //人员工作量统计分析
        public JsonResult GetDataRE(string id = "", int page = 11, int rows = 11, string order = "", string sort = "", string search = "")
        {
            
            int total = 0;
            page = 1;
            rows = 9999;
            List<RENYUANGONGZUOLIANG_Result> queryData = m_BLL.GetByParamRE(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    WEITUODAN = s.WEITUODAN
                    ,
                    JIANDINGWANCHENG = s.JIANDINGWANCHENG
                    ,
                    SHEBEIGUZHANG = s.SHEBEIGUZHANG
                    ,
                    PIZHUNTONGGUO = s.PIZHUNTONGGUO
                    ,
                    HEGE = s.HEGE
                    ,
                    BUHEGE = s.BUHEGE
                    ,
                    CHAOQI = s.CHAOQI
                    ,
                    SHENHEBUTONGGUO = s.SHENHEBUTONGGUO
                    ,
                    PIZHUNBUTONGGUO = s.PIZHUNBUTONGGUO

                }

                    )
            });
        }
        //实验室别工作量统计分析
        public JsonResult GetDataZH(string id = "", int page = 11, int rows = 11, string order = "", string sort = "", string search = "")
        {

            int total = 0;
            page = 1;
            rows = 9999;
            List<ZHENGSHUHAOLEIBIE_Result> queryData = m_BLL.GetByParamZH(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    WEITUODAN = s.WEITUODAN
                    ,
                    JIANDINGWANCHENG = s.JIANDINGWANCHENG
                    ,
                    SHEBEIGUZHANG = s.SHEBEIGUZHANG
                    ,
                    PIZHUNTONGGUO = s.PIZHUNTONGGUO
                    ,
                    HEGE = s.HEGE
                    ,
                    BUHEGE = s.BUHEGE
                    ,
                    CHAOQI = s.CHAOQI
                }

                    )
            });
        }
        //所属单位别工作量统计
        public JsonResult GetDataDW(string id = "", int page = 11, int rows = 11, string order = "", string sort = "", string search = "")
        {

            int total = 0;
            page = 1;
            rows = 9999;
            List<SUOSHUDANWEI_Result> queryData = m_BLL.GetByParamDW(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    SUOSHUDANWEI = s.SUOSHUDANWEI
                    ,
                    BIAOBIAO = s.BIAOBIAO
                    ,
                    DIANBIAO = s.DIANBIAO
                    ,
                    NENGZHI = s.NENGZHI
                    ,
                    SHUBIAO = s.SHUBIAO
                    ,
                    ZHILIUYIQI = s.ZHILIUYIQI
                    ,
                    ZHISHIYIQI = s.ZHISHIYIQI
                    ,
                    HUGANQI = s.HUGANQI
                    ,
                    QITA = s.QITA
                    ,
                    HEJI = Convert.ToInt32(s.BIAOBIAO) + Convert.ToInt32(s.DIANBIAO) + Convert.ToInt32(s.NENGZHI) + Convert.ToInt32(s.SHUBIAO) + Convert.ToInt32(s.ZHILIUYIQI) + Convert.ToInt32(s.ZHISHIYIQI) + Convert.ToInt32(s.HUGANQI) + Convert.ToInt32(s.QITA)
                }
                    )
            });
        }


        IBLL.IVSHIYANSHIGONGZUOLIANGBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VSHIYANSHIGONGZUOLIANGController()
            : this(new VSHIYANSHIGONGZUOLIANGBLL()) { }

        public VSHIYANSHIGONGZUOLIANGController(VSHIYANSHIGONGZUOLIANGBLL bll)
        {
            m_BLL = bll;
        }

    }
}


