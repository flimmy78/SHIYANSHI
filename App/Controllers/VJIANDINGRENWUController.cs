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
using Langben.App.Models;

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
            Common.Account account = GetCurrentAccount();
            string Id = string.Empty;//预备方案表ID
            string APPLIANCE_LABORATORYID = string.Empty;//器具明细信息_承接实验室ID
            APPLIANCE_DETAIL_INFORMATION appl = m_BLL5.GetById(id);
            ICollection<APPLIANCE_LABORATORY> ory = appl.APPLIANCE_LABORATORY;
            foreach (var item in ory)
            {
                if (account.UNDERTAKE_LABORATORYName == item.UNDERTAKE_LABORATORYID)
                {
                    Id = item.PREPARE_SCHEMEID;
                    APPLIANCE_LABORATORYID = item.ID;
                }
            }
            ViewBag.Id = Id;
            ViewBag.APPLIANCE_LABORATORYID = APPLIANCE_LABORATORYID;
            ViewBag.APPLIANCE_DETAIL_INFORMATIONID = id;//器具明细表id
            
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
                ViewBag.REPORTSTATUS = prepare.REPORTSTATUS;//报告状态（前段判断是否能修改）
            }
            ViewBag.SYS = account.UNDERTAKE_LABORATORYName;
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
            ViewBag.PREPARE_SCHEMEID = bs[0];
            PREPARE_SCHEME prepare = m_BLL3.GetById(bs[0]);
           // List<FILE_UPLOADER> list = m_BLL2.GetByRefPREPARE_SCHEMEID(bs[0]);
            
            foreach (var item in prepare.FILE_UPLOADER)
            {
                ViewBag.NAME2 = item.NAME2;
                ViewBag.NAME = item.NAME;
                ViewBag.CONCLUSION = item.CONCLUSION;
                ViewBag.FILE_UPLOADERID = item.ID;
                ViewBag.PREPARE_SCHEMEID = item.PREPARE_SCHEMEID;
            }
            ViewBag.REPORTSTATUS = prepare.REPORTSTATUS;
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
            pre.PACKAGETYPE = Common.PACKAGETYPE.上传.ToString();
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
            pre.ID = file.PREPARE_SCHEMEID;//预备方案ID(修改)
            uplo.CONCLUSION = file.CONCLUSION;//结论
            bool Create = false;
            bool Edit = false;
            if (string.IsNullOrEmpty(file.ID))//判断是否为第一次进入
            {
                uplo.ID = Result.GetNewId();
                uplo.CREATETIME = DateTime.Now;//创建时间
                uplo.CREATEPERSON = GetCurrentPerson();//创建人
                uplo.STATE = Common.PACKAGETYPE.已上传.ToString();
                Create = m_BLL2.Create(ref validationErrors, uplo);//上传信息写入附件表中
                if (Create)
                {
                    Create = m_BLL3.EditField(ref validationErrors, pre);
                }
                if (Create)
                {
                    ViewBag.Create = "True";
                    ViewBag.Edit = "";
                    ViewBag.NAME2 = uplo.NAME2;//原始记录名称
                    ViewBag.NAME = uplo.NAME;//证书名称
                }
                else
                {
                    ViewBag.Create = "False";
                    ViewBag.Edit = "";
                    ViewBag.NAME2 = file.NAME2;//原始记录名称
                    ViewBag.NAME = file.NAME;//证书名称
                }
            }
            else
            {
                uplo.ID = file.ID;
                uplo.UPDATETIME = DateTime.Now;//修改时间
                uplo.UPDATEPERSON = GetCurrentPerson();//修改人

                Edit = m_BLL2.EditField(ref validationErrors, uplo);//上传信息修改附件表中
                if (Edit)
                {
                    //FILE_UPLOADER file_uplo = m_BLL2.GetById(uplo.ID);//取预备方案id
                   // pre.ID = file_uplo.PREPARE_SCHEMEID;
                    Edit = m_BLL3.EditField(ref validationErrors, pre);
                }
                if (Edit)
                {
                    ViewBag.Edit = "True";
                    ViewBag.Create = "";
                    ViewBag.NAME2 = uplo.NAME2;//原始记录名称
                    ViewBag.NAME = uplo.NAME;//证书名称
                }
                else
                {
                    ViewBag.Edit = "False";
                    ViewBag.Create = "";
                    ViewBag.NAME2 = file.NAME2;//原始记录名称
                    ViewBag.NAME = file.NAME;//证书名称
                };

            }
            //返回执行结果是新增还是修改并给出结论
            ViewBag.FILE_UPLOADERID = uplo.ID;

            ViewBag.REPORTSTATUS = null;
            ViewBag.REPORTNUMBER = REPORTNUMBER;//证书编号          
            ViewBag.CONCLUSION = uplo.CONCLUSION;//结论
            ViewBag.PREPARE_SCHEMEID = pre.ID;//预备方案id
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
            Common.Account account = GetCurrentAccount();
            search += "EQUIPMENT_STATUS_VALUUMN&" + Common.ORDER_STATUS.已分配.GetHashCode() + "*" + Common.ORDER_STATUS.已领取.GetHashCode() + "*" + Common.ORDER_STATUS.试验完成.GetHashCode() + "*" + Common.ORDER_STATUS.器具已入库.GetHashCode() + "*" + Common.ORDER_STATUS.器具已领取.GetHashCode() + "";
            search += "^NAME&" + account.UNDERTAKE_LABORATORYName;
            List<VJIANDINGRENWU> queryData = m_BLL.GetByParamX(id, page, rows, order, sort, search, ref total);
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
                    NAME = s.NAME,
                    VERSION = s.VERSION,
                    ISRECEIVE=s.ISRECEIVE
                }

                    )
            });
        }

        IBLL.IVJIANDINGRENWUBLL m_BLL;
        IBLL.IFILE_UPLOADERBLL m_BLL2;
        IBLL.IPREPARE_SCHEMEBLL m_BLL3;
        IBLL.IAPPLIANCE_LABORATORYBLL m_BLL4;
        IBLL.IAPPLIANCE_DETAIL_INFORMATIONBLL m_BLL5;
        ValidationErrors validationErrors = new ValidationErrors();

        public VJIANDINGRENWUController()
            : this(new VJIANDINGRENWUBLL(), new FILE_UPLOADERBLL(), new PREPARE_SCHEMEBLL(), new APPLIANCE_LABORATORYBLL(), new APPLIANCE_DETAIL_INFORMATIONBLL()) { }

        public VJIANDINGRENWUController(VJIANDINGRENWUBLL bll, FILE_UPLOADERBLL bll2, PREPARE_SCHEMEBLL bll3, APPLIANCE_LABORATORYBLL bll4, APPLIANCE_DETAIL_INFORMATIONBLL bll5)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
            m_BLL4 = bll4;
            m_BLL5 = bll5;
        }

    }
}


