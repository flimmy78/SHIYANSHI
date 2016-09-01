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
            string Id = string.Empty;
            string APPLIANCE_LABORATORYID = string.Empty;
            List<APPLIANCE_LABORATORY> list = m_BLL4.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(id);
            foreach (var item in list)
            {
                Id = item.PREPARE_SCHEMEID;
                APPLIANCE_LABORATORYID = item.ID;
            }
            ViewBag.Id = Id;
            ViewBag.APPLIANCE_LABORATORYID = APPLIANCE_LABORATORYID;
            ViewBag.APPLIANCE_DETAIL_INFORMATIONID = id;
            string erchizi = string.Empty;
            if (!string.IsNullOrEmpty(Id))
            {
                PREPARE_SCHEME prepare = m_BLL3.GetById(Id);//二次进入绑定数据
                erchizi += "REPORT_CATEGORY*" + prepare.REPORT_CATEGORY + ",";
                erchizi += "CERTIFICATE_CATEGORY*" + prepare.CERTIFICATE_CATEGORY + ",";
                erchizi += "CONTROL_NUMBER*" + prepare.CONTROL_NUMBER + ",";
                erchizi += "QUALIFICATIONS*" + prepare.QUALIFICATIONS + ",";
                erchizi += "CERTIFICATE_CATEGORY*" + prepare.CERTIFICATE_CATEGORY + ",";
                erchizi += "CERTIFICATION_AUTHORITY*" + prepare.CERTIFICATION_AUTHORITY + ",";
                erchizi += "CNAS*" + prepare.CNAS;
                ViewBag.SBL = erchizi;
            }

            return View();
        }
        /// <summary>
        /// 报告上传
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult BaoGaoShangChuan(string id)
        {
            string[] bs = id.Split('|');
            ViewBag.Id = bs[0];
            List<FILE_UPLOADER> list = m_BLL2.GetByRefPREPARE_SCHEMEID(id);
            foreach (var item in list)
            {
                ViewBag.NAME2 = item.NAME2;
                ViewBag.NAME = item.NAME;
                ViewBag.ID = item.ID;
                ViewBag.CONCLUSION = item.CONCLUSION;
            }
            ViewBag.REPORTNUMBER = m_BLL3.GetSerialNumber(bs[0]);
            ViewBag.APPLIANCE_DETAIL_INFORMATIONID = bs[1];//器具明细id
            return View();
        }
        /// <summary>
        /// 报告上传(上传按钮)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BaoGaoShangChuan(FILE_UPLOADER file, string REPORTNUMBER)//文档上传
        {
            PREPARE_SCHEME pre = new PREPARE_SCHEME();
            pre.REPORTNUMBER = REPORTNUMBER;//证书编号
            pre.PACKAGETYPE = "上传";
            string msg = string.Empty;
            if (Request.Files.Count > 0)//前端获取文件选择控件值
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
            msg = msg.Substring(1, msg.Length - 1).TrimEnd('}');//去掉头尾｛｝
            string[] mg = msg.Split(',');
            for (int i = 0; i < mg.Length; i++)//解析上传文件方法返回的字符串
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
            uplo.PREPARE_SCHEMEID = file.PREPARE_SCHEMEID;//预备方案ID
            uplo.CONCLUSION = file.CONCLUSION;//结论
            bool Create = false;
            bool Edit = false;
            if (string.IsNullOrEmpty(file.ID))//判断是否为第一次进入
            {
                uplo.ID = Result.GetNewId();
                uplo.CREATETIME = DateTime.Now;//创建时间
                uplo.CREATEPERSON = GetCurrentPerson();//创建人
                Create = m_BLL2.Create(ref validationErrors, uplo);//上传信息写入附件表中
                if (Create)
                {
                    Create = m_BLL3.EditField(ref validationErrors, pre);
                }

            }
            else
            {
                uplo.ID = file.ID;
                uplo.UPDATETIME = DateTime.Now;//修改时间
                uplo.UPDATEPERSON = GetCurrentPerson();//修改人
                Edit = m_BLL2.Edit(ref validationErrors, uplo);//上传信息修改附件表中
                if (Edit)
                {
                    Edit = m_BLL3.EditField(ref validationErrors, pre);
                }

            }
            //返回执行结果是新增还是修改并给出结论
            ViewBag.ID = uplo.ID;
            if (Create)
            {
                ViewBag.Create = Create;
            }
            else if (Edit)
            {
                ViewBag.Edit = Edit;
            }
            ViewBag.REPORTNUMBER = REPORTNUMBER;//证书编号
            ViewBag.NAME2 = uplo.NAME2;//原始记录名称
            ViewBag.NAME = uplo.NAME;//证书名称
            ViewBag.CONCLUSION = uplo.CONCLUSION;//结论
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

            search += "EQUIPMENT_STATUS_VALUUMN&" + Common.ORDER_STATUS.已分配.GetHashCode() + "*" + Common.ORDER_STATUS.已领取.GetHashCode() + "*" + Common.ORDER_STATUS.试验完成.GetHashCode() + "*" + Common.ORDER_STATUS.器具已入库.GetHashCode() + "*" + Common.ORDER_STATUS.器具已返还.GetHashCode() + "";

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
                    ,
                    NAME = s.NAME

                }

                    )
            });
        }



        IBLL.IVJIANDINGRENWUBLL m_BLL;
        IBLL.IFILE_UPLOADERBLL m_BLL2;
        IBLL.IPREPARE_SCHEMEBLL m_BLL3;
        IBLL.IAPPLIANCE_LABORATORYBLL m_BLL4;

        ValidationErrors validationErrors = new ValidationErrors();

        public VJIANDINGRENWUController()
            : this(new VJIANDINGRENWUBLL(), new FILE_UPLOADERBLL(), new PREPARE_SCHEMEBLL(), new APPLIANCE_LABORATORYBLL()) { }

        public VJIANDINGRENWUController(VJIANDINGRENWUBLL bll, FILE_UPLOADERBLL bll2, PREPARE_SCHEMEBLL bll3, APPLIANCE_LABORATORYBLL bll4)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
            m_BLL4 = bll4;
        }

    }
}


