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
using System.Web;
using System.Web.Script.Serialization;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 检定任务
    /// </summary>
    public class VJIANDINGRENWUController : BaseController
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
        /// 选择方案
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult XuanZheFangAn(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        /// <summary>
        /// 报告上传
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult BaoGaoShangChuan(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        /// <summary>
        /// 报告上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BaoGaoShangChuan(FILE_UPLOADER file)//文档上传
        {
            string msg = string.Empty;
            if (Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase pstFile = Request.Files[i];//获取页面选择的文件
                    string upfile = pstFile.FileName;//文件名
                    UploadFiles upFiles = new UploadFiles();
                    msg += upFiles.ReportToUpload(pstFile, upfile, i);//上传文件

                }
            }
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //FILE_UPLOADER jg = js.Deserialize<FILE_UPLOADER>(msg);
            //jg.PREPARE_SCHEMEID = file.ID;
            //jg.CONCLUSION = file.CONCLUSION;
            FILE_UPLOADER uplo = new FILE_UPLOADER();
            msg = msg.Substring(1, msg.Length - 1).TrimEnd('}');
            string[] mg = msg.Split(',');
            for (int i = 0; i < mg.Length; i++)
            {
                string[] m = mg[i].Split('*');
                switch (m[0].ToString())
                {
                    case "NAME":
                        uplo.NAME = m[1];
                        break;
                    case "NAME2":
                        uplo.NAME2 = m[1];
                        break;
                    case "PATH":
                        uplo.PATH = m[1];
                        break;
                    case "PATH2":
                        uplo.PATH2 = m[1];
                        break;
                    case "FULLPATH":
                        uplo.FULLPATH = m[1];
                        break;
                    case "FULLPATH2":
                        uplo.FULLPATH2 = m[1];
                        break;
                    case "SUFFIX":
                        uplo.SUFFIX = m[1];
                        break;
                    case "SUFFIX2":
                        uplo.SUFFIX2 = m[1];
                        break;
                    case "SIZE":
                        uplo.SIZE = Convert.ToInt32(m[1]);
                        break;
                    case "SIZE2":
                        uplo.SIZE2 = Convert.ToInt32(m[1]);
                        break;
                    default:
                        break;
                }
            }
            uplo.PREPARE_SCHEMEID = file.PREPARE_SCHEMEID;
            uplo.CONCLUSION = file.CONCLUSION;
            bool Create = false;
            bool Edit = false;
            if (string.IsNullOrEmpty(uplo.ID))
            {
                uplo.ID = Result.GetNewId();
                Create = m_BLL2.Create(ref validationErrors, uplo);
            }
            else
            {
                Edit = m_BLL2.Edit(ref validationErrors, uplo);
            }

            ViewBag.ID = uplo.ID;
            if (Create)
            {
                ViewBag.V = Create;
            }
            else if (Edit)
            {
                ViewBag.V = Edit;
            }
   
            return View();
        }
        /// <summary>
        /// 建立方案
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult JianLiFangAn(string id)
        {
            ViewBag.Id = id;
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

            search += "EQUIPMENT_STATUS_VALUUMN&" + Common.OrderStatus.已分配.GetHashCode() + "*" + Common.OrderStatus.已领取.GetHashCode() + "*" + Common.OrderStatus.试验中.GetHashCode() + "*" + Common.OrderStatus.试验完成.GetHashCode() + "*" + Common.OrderStatus.器具已入库.GetHashCode() + "*" + Common.OrderStatus.器具已返还.GetHashCode() + "";

            List<VJIANDINGRENWU> queryData = m_BLL.GetByParam(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    ORDER_NUMBER = s.ORDER_NUMBER
                    ,
                    APPLIANCE_NAME = s.APPLIANCE_NAME
                    ,
                    MODEL = s.VERSION,
                    FACTORY_NUM = s.FACTORY_NUM
                    ,
                    CERTIFICATE_ENTERPRISE = s.CERTIFICATE_ENTERPRISE
                    ,
                    CUSTOMER_SPECIFIC_REQUIREMENTS = s.CUSTOMER_SPECIFIC_REQUIREMENTS
                    ,
                    ORDER_STATUS = s.ORDER_STATUS
                    ,
                    CREATETIME = s.CREATETIME
                    ,
                    APPLIANCE_PROGRESS = s.APPLIANCE_PROGRESS
                    ,
                    OVERDUE = s.OVERDUE
                    ,
                    STATE = s.STATE
                    ,
                    REPORTSTATUS = s.REPORTSTATUS
                    ,
                    APPROVAL = s.APPROVAL
                    ,
                    INSPECTION_ENTERPRISE = s.INSPECTION_ENTERPRISE
                    ,
                    ISOVERDUE = s.ISOVERDUE
                    ,
                    EQUIPMENT_STATUS_VALUUMN = s.EQUIPMENT_STATUS_VALUUMN

                }

                    )
            });
        }



        IBLL.IVJIANDINGRENWUBLL m_BLL;
        IBLL.IFILE_UPLOADERBLL m_BLL2;

        ValidationErrors validationErrors = new ValidationErrors();

        public VJIANDINGRENWUController()
            : this(new VJIANDINGRENWUBLL(), new FILE_UPLOADERBLL()) { }

        public VJIANDINGRENWUController(VJIANDINGRENWUBLL bll, FILE_UPLOADERBLL bll2)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
        }

    }
}


