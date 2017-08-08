using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Langben.DAL;
using Langben.BLL;
using System.Web.Mvc;
using Models;
using System.Web;
using Langben.App.Models;
using System.Collections;

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
            if (!string.IsNullOrWhiteSpace(id))
            {
                string[] bs = id.Split('|');
                ViewBag.PREPARE_SCHEMEID = bs[0];
                PREPARE_SCHEME prepare = m_BLL3.GetById(bs[0]);
                Account acc = GetCurrentAccount();
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
                ViewBag.DETECTERID = prepare.DETECTERID;//核验员
                ViewBag.CERTIFICATE_CATEGORY = prepare.CERTIFICATE_CATEGORY;//报告类别
                ViewBag.CALIBRATION_DATE = prepare.CALIBRATION_DATE;//检定/校准时间
                ViewBag.CHECKERID = acc.PersonName;//登入用户名
                ViewBag.VALIDITY_PERIOD = prepare.VALIDITY_PERIOD;//有效期VALIDITY_PERIOD
                ViewBag.CONCLUSION_EXPLAIN = prepare.CONCLUSION_EXPLAIN;//

            }

            return View();
        }

        /// <summary>
        /// 报告上传功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public JsonResult ShangChuang(object sender, EventArgs e)
        {
            HttpPostedFileBase files = Request.Files["file"];
            string chuanzhi = Request["chuanzhi"].ToString();
            string PREPARE_SCHEMEID = Request["PREPARE_SCHEMEID"].ToString();
            string FILE_UPLOADERID = Request["FILE_UPLOADERID"].ToString();
            FILE_UPLOADER file = JieXi((new UploadFiles()).ReportToUpload(files, files.FileName, chuanzhi == "Y" ? 0 : 1));//上传文件,解析
            file.PREPARE_SCHEMEID = PREPARE_SCHEMEID;
            file.REMARK = "33_13|35_13|37_13";//添加签名位置
            file.STATE = Common.PACKAGETYPE.已上传.ToString();
            if (string.IsNullOrWhiteSpace(FILE_UPLOADERID))
            {
                file.ID = Result.GetNewId();
                file.CREATETIME = DateTime.Now;//创建时间
                file.CREATEPERSON = GetCurrentPerson();//创建人
                bool fh = m_BLL2.Create(ref validationErrors, file);
                Hashtable hash = new Hashtable();
                hash.Add("FH", fh);
                hash.Add("Name", files.FileName);
                hash.Add("FILE_UPLOADERID", file.ID);
                return Json(hash);
            }
            else
            {
                file.ID = FILE_UPLOADERID;
                file.UPDATETIME = DateTime.Now;
                file.UPDATEPERSON = GetCurrentPerson();
                bool fh = m_BLL2.EditField(ref validationErrors, file);//上传信息修改附件表中                            
                Hashtable hash = new Hashtable();
                hash.Add("FH", fh);
                hash.Add("Name", files.FileName);
                hash.Add("FILE_UPLOADERID", FILE_UPLOADERID);
                return Json(hash);
            }
        }

        [HttpPost]
        public JsonResult ShengHe(PREPARE_SCHEME ps)
        {
            string[] id = ps.ID.Split('|');
            ps.ID = id[0];
            ps.PACKAGETYPE = Common.PACKAGETYPE.上传.ToString();
            
            bool ef = m_BLL3.EditField(ref validationErrors, ps);
            FILE_UPLOADER fu = new FILE_UPLOADER();
            fu.ID = id[1];
            fu.CONCLUSION = ps.CONCLUSION;
            bool ef2 = m_BLL2.EditField(ref validationErrors, fu);
            Hashtable hb = new Hashtable();
            hb.Add("FX",ef==true&&ef2==true?true:false);
            return Json(hb);
        }
        /// <summary>
        /// 解析上传返回字符串
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        public FILE_UPLOADER JieXi(string rod)
        {
            FILE_UPLOADER uplo = new FILE_UPLOADER();
            rod = rod.TrimStart('{').TrimEnd('}');
            //rod = rod.Substring(0, rod.Length - 1).TrimEnd('}');//去掉头尾｛｝
            string[] mg = rod.Split(',');
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
            return uplo;
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
                    prepShow.METERING_STANDARD_DEVICEID += item.ID + "*" + item.METERING_STANDARD_DEVICEID + "*" + item.GROUPS + "*" + item.TYPE + "*" + item.NAMES + "&" + item.NAMES + "^";
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
            search += "EQUIPMENT_STATUS_VALUUMN&" + Common.ORDER_STATUS.已分配.GetHashCode() + "*" + Common.ORDER_STATUS.已领取.GetHashCode() + "*" + Common.ORDER_STATUS.试验完成.GetHashCode() + "*" + Common.ORDER_STATUS.待入库.GetHashCode() + "*" + Common.ORDER_STATUS.器具已入库.GetHashCode() + "*" + Common.ORDER_STATUS.器具已领取.GetHashCode() + "";
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
                    RETURNREASON = s.RETURNREASON
                    ,
                    REPORTNUMBER = s.REPORTNUMBER
                }

                    )
            });
        }

        [SupportFilter]
        public ActionResult GetData2(string id, int page = 1, int rows = 999999, string order = "asc", string sort = "ID", string search = null)
        {

            int total = 0;
            Common.Account account = GetCurrentAccount();
            search += "EQUIPMENT_STATUS_VALUUMN&" + Common.ORDER_STATUS.已分配.GetHashCode() + "*" + Common.ORDER_STATUS.已领取.GetHashCode() + "*" + Common.ORDER_STATUS.试验完成.GetHashCode() + "*" + Common.ORDER_STATUS.待入库.GetHashCode() + "*" + Common.ORDER_STATUS.器具已入库.GetHashCode() + "*" + Common.ORDER_STATUS.器具已领取.GetHashCode() + "";
            search += "^NAME&" + account.UNDERTAKE_LABORATORYName;
            List<VJIANDINGRENWU> queryData = m_BLL.GetByParamX(id, page, rows, order, sort, search, ref total);
            string[] fields = "ORDER_NUMBER,REPORTNUMBER,ISRECEIVE,APPLIANCE_NAME,VERSION,FACTORY_NUM,CERTIFICATE_ENTERPRISE,CUSTOMER_SPECIFIC_REQUIREMENTS,APPLIANCE_PROGRESS,ORDER_STATUS,CREATETIME,OVERDUE,STATE,REPORTSTATUS,APPROVAL,INSPECTION_ENTERPRISE".Split(',');
            return Content(WriteExcleVJianDingRenWu(fields, queryData.ToArray()));
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


