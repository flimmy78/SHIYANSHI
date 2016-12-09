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
            foreach (var item in appl.APPLIANCE_LABORATORY)
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
                ViewBag.PACKAGETYPE = prepare.PACKAGETYPE;//判断报告类型是上传还是系统生成，用来判断启用上传报告还是建立方案
            }
            ViewBag.SYS = account.UNDERTAKE_LABORATORYName;//实验室
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
            foreach (var item in prepare.APPLIANCE_LABORATORY)
            {
                if (item.RECYCLING != null)
                {
                    ViewBag.REPORTNUMBER = item.RECYCLING;
                }
                else
                {
                    ViewBag.REPORTNUMBER = m_BLL3.GetSerialNumber(bs[0]);
                }
            }
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
            pre.UNQUALIFIEDTYPE = file.UNQUALIFIEDTYPE.ToString();//不合格类型
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
            //id = "161008163205467348401f1aec5a1|161008162529892766577f2f96359";
            Common.Account account = GetCurrentAccount();
            string[] bs = id.Split('|');
            string PREPARE_SCHEMEID = bs[0];//预备方案id
            string APPLIANCE_DETAIL_INFORMATIONID = bs[1];//器具明细id
            APPLIANCE_DETAIL_INFORMATION appion = m_BLL5.GetById(APPLIANCE_DETAIL_INFORMATIONID);//器具明细表
            List<METERING_STANDARD_DEVICE> mete = m_BLL3.GetRefMETERING_STANDARD_DEVICE(PREPARE_SCHEMEID);//标准装置/计量标准器信息表
            PREPARE_SCHEME prme = m_BLL3.GetById(PREPARE_SCHEMEID);//预备方案表
            PREPARE_SCHEMEShow prepShow = new PREPARE_SCHEMEShow();//预备方案类
            if (prme != null && prme.SCHEME != null)
            {
                //为什么获取不到SCHEME这个对象
                prepShow.SCHEMENAME = prme.SCHEME.NAME;//  选择方案模板
                prepShow.SCHEMEID = prme.SCHEME.ID;//  选择方案模板
            }
            if (prme != null && prme.STANDARDCHOICE != null)
            {
                foreach (var item in prme.STANDARDCHOICE)
                {
                    //rows[i].ID + "*" + rows[i].GROUPS + "*A*" + rows[i].CERTIFICATE_NUM
                    prepShow.METERING_STANDARD_DEVICEID +=item.ID+"*"+item.METERING_STANDARD_DEVICEID+"*"+item.GROUPS+"*"+item.TYPE+"*"+item.NAMES + "&" + item.NAMES + "^";
                }
            }
            foreach (var item in prme.APPLIANCE_LABORATORY)
            {
                if (item.RECYCLING != null)
                {
                    prepShow.REPORTNUMBER = item.RECYCLING;
                }
                else
                {
                    prepShow.REPORTNUMBER = m_BLL3.GetSerialNumber(PREPARE_SCHEMEID);//报告编号
                }
            }
            prepShow.APPLIANCE_DETAIL_INFORMATIONShows.APPLIANCE_NAME = appion.APPLIANCE_NAME;//器具名称
            prepShow.APPLIANCE_DETAIL_INFORMATIONShows.VERSION = appion.VERSION;//器具型号
            prepShow.APPLIANCE_DETAIL_INFORMATIONShows.FORMAT = appion.FORMAT;//器具规格
            prepShow.APPLIANCE_DETAIL_INFORMATIONShows.FACTORY_NUM = appion.FACTORY_NUM;//出厂编号
            prepShow.ACCURACY_GRADE = prme.ACCURACY_GRADE;//准确度等级
            prepShow.RATED_FREQUENCY = prme.RATED_FREQUENCY;//额定频率
            prepShow.PULSE_CONSTANT = prme.PULSE_CONSTANT;//脉冲常数
            prepShow.APPLIANCE_DETAIL_INFORMATIONShows.MAKE_ORGANIZATION = appion.MAKE_ORGANIZATION;//制造单位
            prepShow.TEMPERATURE = prme.TEMPERATURE;//环境温度
            prepShow.HUMIDITY = prme.HUMIDITY;//相对湿度
            prepShow.CHECK_PLACE = prme.CHECK_PLACE;//检定/校准地点
            prepShow.CALIBRATION_DATE = prme.CALIBRATION_DATE;//检定/校准日期
            prepShow.DETECTERID = prme.DETECTERID;//核验员
            prepShow.OTHER = prme.OTHER;//其他 
            prepShow.ID = prme.ID;//id

            #region 标准装置/计量标准器相关数据
            prepShow.METERING_STANDARD_DEVICEShow = mete.Select(m => new METERING_STANDARD_DEVICEShow
            {
                ID = m.ID,
                NAME = m.NAME,
                TEST_RANGE = m.TEST_RANGE,
                FACTORY_NUM = m.FACTORY_NUM,
                CATEGORY = m.CATEGORY,
                STATUS = m.STATUS,
                UNDERTAKE_LABORATORYID = m.UNDERTAKE_LABORATORYID,
                CREATETIME = m.CREATETIME,
                CREATEPERSON = m.CREATEPERSON,
                UPDATETIME = m.UPDATETIME,
                UPDATEPERSON = m.UPDATEPERSON,
                METERING_STANDARD_DEVICE_CHECKShow = m.METERING_STANDARD_DEVICE_CHECK.Select(s => new METERING_STANDARD_DEVICE_CHECKShow
                {
                    ID = s.ID,
                    CERTIFICATE_NUM = s.CERTIFICATE_NUM,
                    CHECK_DATE = s.CHECK_DATE,
                    VALID_TO = s.VALID_TO,
                    METERING_STANDARD_DEVICEID = s.METERING_STANDARD_DEVICEID,
                    CREATETIME = s.CREATETIME,
                    CREATEPERSON = s.CREATEPERSON,
                    UPDATETIME = s.UPDATETIME,
                    UPDATEPERSON = s.UPDATEPERSON
                }).ToList(),
                ALLOWABLE_ERRORShow = m.ALLOWABLE_ERROR.Select(e => new ALLOWABLE_ERRORShow
                {
                    ID = e.ID,
                    //VALUE = e.VALUE,
                    //UNIT = e.UNIT,
                    METERING_STANDARD_DEVICEID = e.METERING_STANDARD_DEVICEID,
                    CREATETIME = e.CREATETIME,
                    CREATEPERSON = e.CREATEPERSON,
                    UPDATETIME = e.UPDATETIME,
                    UPDATEPERSON = e.UPDATEPERSON
                }).ToList()
            }).ToList();
            #endregion
            ViewBag.CERTIFICATE_CATEGORY = prme.CERTIFICATE_CATEGORY;//证书类别
            ViewBag.UNDERTAKE_LABORATORY_NAME = account.UNDERTAKE_LABORATORYName;//实验室
            foreach (var item in prme.APPLIANCE_LABORATORY)
            {
                if (item.UNDERTAKE_LABORATORYID == account.UNDERTAKE_LABORATORYName)
                {
                    ViewBag.ORDER_STATUS = item.ORDER_STATUS;//器具状态
                }
            }
            ViewBag.ACCEPT_ORGNIZATION = appion.ORDER_TASK_INFORMATION.ACCEPT_ORGNIZATION;//受理单位
            return View(prepShow);
        }

        /// <summary>
        /// 器具修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult QiJuXiuGai(string id)
        {
            ViewBag.ID = id;
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
                    ISRECEIVE = s.ISRECEIVE,
                    RETURNREASON=s.RETURNREASON
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


