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
using System.Web.UI;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 预备方案
    /// </summary>
    public class PREPARE_SCHEMEController : BaseController
    {
        IList<int> start = new List<int>();
        public ActionResult Show(string id)
        {
            //定义Workbook对象
            PageOffice.ExcelWriter.Workbook workBook = new PageOffice.ExcelWriter.Workbook();
            //定义Sheet对象，"Sheet1"是打开的Excel表单的名称
            PageOffice.ExcelWriter.Sheet sheet = workBook.OpenSheet("Sheet1");
            System.Web.UI.Page page = new System.Web.UI.Page();

            string controlOutput = string.Empty;
            PageOffice.PageOfficeCtrl pc = new PageOffice.PageOfficeCtrl();
            pc.ID = "PageOfficeCtrl1";
            pc.ServerPage = "/pageoffice/server.aspx";
            pc.AddCustomToolButton("保存", "Save()", 1);
            string filePath = Server.MapPath(id.Replace("..","~"));
            pc.SaveFilePage = "/PREPARE_SCHEME/SaveFile/?id=" + id.Replace("..", "~");
            pc.Caption = "------------------------------------^o^------------------双击我，最大化------------------^o^------------------------------------";
            // 设置文件打开后执行的js function
            pc.JsFunction_AfterDocumentOpened = "AfterDocumentOpened()";
            pc.SetWriter(workBook);
            pc.WebOpen(filePath, PageOffice.OpenModeType.xlsNormalEdit, "Tom");

            page.Controls.Add(pc);
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    Server.Execute(page, htw, false); controlOutput = sb.ToString();
                }
            }
            ViewBag.EditorHtml22 = controlOutput;
         
            return View();
        }
        public ActionResult SaveFile(string id)
        {
            string filePath = string.Empty;
            if (!string.IsNullOrWhiteSpace(id) && id.Contains(".."))
            {
                filePath = Server.MapPath(id.Replace("..", "~"));
            }
            else
            {
                filePath = Server.MapPath(id);
            }
            //LogClassModels.WriteServiceLog(Suggestion.InsertFail + filePath+"，相位的信息888，" + id, "相位"
            //          );//写入日志    
            PageOffice.FileSaver fs = new PageOffice.FileSaver();
            //LogClassModels.WriteServiceLog(Suggestion.InsertFail + filePath + "，相位的信息8883，" + id, "相位"
            //        );//写入日志   
            fs.SaveToFile(filePath);
            fs.Close();
            //LogClassModels.WriteServiceLog(Suggestion.InsertFail + filePath + "，相位的信息88838，" + id, "相位"
            //        );//写入日志   
            return View();
        }
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
            Account current = GetCurrentAccount();
            if (current!=null)
            {
                ViewBag.ShiYanShi = current.UNDERTAKE_LABORATORYName;
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
        /// <param name="VALIDITY_PERIOD">检定结论</param>
        /// <returns></returns>
        public ActionResult Save(string ID, string CONCLUSION, string CONCLUSION_EXPLAIN, string VALIDITY_PERIOD, string UNQUALIFIEDTYPE,string CALIBRATION_INSTRUCTIONS)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            PREPARE_SCHEME entity = m_BLL.GetById(ID);
            if (entity != null)
            {
                entity.CONCLUSION = CONCLUSION;
                entity.CONCLUSION_EXPLAIN = CONCLUSION_EXPLAIN;
                try
                {
                    entity.VALIDITY_PERIOD = Convert.ToInt32(VALIDITY_PERIOD);
                }
                catch
                {
                    //result.Code = Common.ClientCode.Fail;
                    //result.Message = Suggestion.UpdateFail + "有效期格式错误";
                    //return Json(result); //提示插入失败
                    entity.VALIDITY_PERIOD = null;
                }
                //有效期至
                if (entity.VALIDITY_PERIOD.HasValue)
                {
                    entity.VALIDITYEND = Convert.ToDateTime(entity.CALIBRATION_DATE).AddYears(Convert.ToInt32(VALIDITY_PERIOD)).AddDays(-1);
                }
                //不合格类型
                entity.UNQUALIFIEDTYPE = UNQUALIFIEDTYPE;
                //检定结论
                entity.CALIBRATION_INSTRUCTIONS = CALIBRATION_INSTRUCTIONS;

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
        public ActionResult Test(string id)
        {
            ReportBLL reportBll = new ReportBLL();
            string Message = string.Empty;

            reportBll.Test(id, out Message);

            ViewBag.IsSuccess = Message;
            return View();

        }
        public ActionResult TestPROJECTTEMPLET(string id)
        {
            ReportBLL reportBll = new ReportBLL();
            string Message = string.Empty;

            reportBll.TestPROJECTTEMPLET(id, out Message);
           
            ViewBag.IsSuccess = Message;
            return View();

        }
        public ActionResult Testxml(string id)
        {
            ReportBLL reportBll = new ReportBLL();
            string Message = string.Empty;

            reportBll.Testxml(id, out Message);

            ViewBag.IsSuccess = Message;
            return View();

        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="ID">预备方案ID</param>
        /// <returns></returns>
        public ActionResult Export(string ID, string Type)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            ReportBLL reportBll = new ReportBLL();
            string Message = string.Empty;
            bool IsSuccess = false;
            FILE_UPLOADER fEntity = null;
            if (Type == "OriginalRecord")
            {
                IsSuccess = reportBll.ExportOriginalRecord(ID, GetCurrentPerson(), out Message, out fEntity);
            }
            else
            {
                IsSuccess = reportBll.ExportReport(ID, GetCurrentPerson(), out Message, out fEntity);
            }
            if (IsSuccess)
            {
                result.Code = Common.ClientCode.Succeed;
                result.Message = Message;
            }
            else
            {
                result.Code = Common.ClientCode.Fail;
                result.Message = Message + "错误一";
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


