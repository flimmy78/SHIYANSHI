using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using Langben.App.Models;
using Webdiyer.WebControls.Mvc;
using System.IO;
using Langben.IBLL;
using NPOI.HSSF.UserModel;
using Langben.DAL.shiyanshi;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Filters;
using Langben.Report;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 预备方案
    /// </summary>
    public class PREPARE_SCHEMEController : BaseController
    {
        IList<int> start = new List<int>();

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
        public ActionResult IndexSef()
        {

            return View();
        }

        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Details(string id)
        {
            ViewBag.Id = id;
            return View();

        }

        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
        {

            return View();
        }

        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">预备方案主键</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Edit(string ID = "")
        {
            Langben.App.Models.VTEST_ITE_YuBei result = new Models.VTEST_ITE_YuBei();
            ViewBag.ID = ID;
            ViewBag.SCHEMEID = "";
            DAL.PREPARE_SCHEME entity = m_BLL.GetById(ID);
            List<VTEST_ITE> vList = null;
            if (entity != null)
            {
                result.prepare_scheme = entity;
                ViewBag.ID = entity.ID;
                ViewBag.SCHEMEID = entity.SCHEMEID;
                IBLL.IVTEST_ITEBLL vBLL = new VTEST_ITEBLL();
                vList = vBLL.GetByPREPARE_SCHEMEID(entity.ID);
                result.vtest_ite = new PagedList<VTEST_ITE>(vList, 1, int.MaxValue);
            }
            else
            {
                entity = new PREPARE_SCHEME();
                result.prepare_scheme = entity;
            }
            return View(result);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="ID">预备方案编号</param>
        /// <param name="CONCLUSION">总结论</param>
        /// <param name="CONCLUSION_EXPLAIN">结论说明</param>
        /// <param name="VALIDITY_PERIOD">有效期</param>
        /// <returns></returns>
        public ActionResult Save(string ID, string CONCLUSION, string CONCLUSION_EXPLAIN, string VALIDITY_PERIOD)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            PREPARE_SCHEME entity = m_BLL.GetById(ID);
            if (entity != null)
            {
                entity.CONCLUSION = CONCLUSION;
                entity.CONCLUSION_EXPLAIN = CONCLUSION_EXPLAIN;
                try
                {
                    entity.VALIDITY_PERIOD = Convert.ToDateTime(VALIDITY_PERIOD);
                }
                catch
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + "有效期格式错误";
                    return Json(result); //提示插入失败
                }
                string currentPerson = GetCurrentPerson();
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = currentPerson;

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，检定项目模板的Id为" + entity.ID, "检定项目模板"
                        );//写入日志 
                    result.Code = Common.ClientCode.Succeed;
                    //result.Message = Suggestion.UpdateSucceed;
                    result.Message = entity.ID;
                    return Json(result); //提示创建成功
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，检定项目模板，" + returnValue, "检定项目模板"
                        );//写入日志                      
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return Json(result); //提示插入失败
                }

            }
            else
            {
                result.Code = Common.ClientCode.Fail;
                result.Message = Suggestion.UpdateFail + "未找到预备方案ID为【" + ID + "】的数据";
                return Json(result); //提示插入失败
            }



        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="ID">预备方案ID</param>
        /// <returns></returns>
        public ActionResult Export(string ID,string Type)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            ReportBLL reportBll = new ReportBLL();
            string Message = string.Empty;
            bool IsSuccess = false;
            if (Type == "OriginalRecord")
            {
                IsSuccess = reportBll.ExportOriginalRecord(ID, out Message);
            }
            else
            {
                IsSuccess = reportBll.ExportReport(ID, out Message);
            }
            if (IsSuccess)
            {
                result.Code = Common.ClientCode.Succeed;
                result.Message = Message;
            }
            else
            {
                result.Code = Common.ClientCode.Fail;
                result.Message = Message;
            }            
            return Json(result); //返回        
        
        }
        IBLL.IPREPARE_SCHEMEBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public PREPARE_SCHEMEController()
                    : this(new PREPARE_SCHEMEBLL()) { }

        public PREPARE_SCHEMEController(PREPARE_SCHEMEBLL bll)
        {
            m_BLL = bll;
        }

    }
}


