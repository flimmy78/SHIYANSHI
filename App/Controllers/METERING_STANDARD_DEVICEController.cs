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

namespace Langben.App.Controllers
{
    /// <summary>
    /// 标准装置/计量标准器信息
    /// </summary>
    public class METERING_STANDARD_DEVICEController : BaseController
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
        public ActionResult IndexSef(string id)
        {
            ViewBag.shiyanshi = id;
            return View();
        }
        public ActionResult IndexUA(string id)
        {
            ViewBag.shiyanshi = id;
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
            ViewBag.METERING_STANDARD_DEVICEID = id.Split('^')[0];
            ViewBag.IS = id.Split('^')[1];
            return View();
        }


        /// <summary>
        /// 最大允许误差信息
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult ALLOWABLE_ERROR(string id)
        {
            ViewBag.METERING_STANDARD_DEVICEID = id;
            return View();
        }

        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            METERING_STANDARD_DEVICEShow msdshow = new METERING_STANDARD_DEVICEShow();
            if (!string.IsNullOrWhiteSpace(id))
            {
                METERING_STANDARD_DEVICE msd = m_BLL.GetById(id.Split('^')[0]);//通过id查询数据
                int GROUPS = Convert.ToInt32(id.Split('^')[1]);//组别
                string IS = id.Split('^')[2];
                
                if (IS == "A")
                {
                    string CATEGORY = id.Split('^')[3];
                    var alledata = msd.ALLOWABLE_ERROR.Where(a => a.GROUPS == GROUPS&&a.CATEGORY== CATEGORY);//筛选数据
                    var msdcdata = msd.METERING_STANDARD_DEVICE_CHECK.Where(a => a.GROUPS == GROUPS && a.CATEGORY == CATEGORY);//筛选数据
                    foreach (var al in alledata)//循环添加数据
                    {
                        var alladd = new ALLOWABLE_ERRORShow()
                        {
                            ID = al.ID,
                            THEACCURACYLEVEL = al.THEACCURACYLEVEL,
                            THEUNCERTAINTYVALUEK = al.THEUNCERTAINTYVALUEK,
                            THEUNCERTAINTYNDEXL = al.THEUNCERTAINTYNDEXL,
                            THEUNCERTAINTYVALUE = al.THEUNCERTAINTYVALUE,
                            THEUNCERTAINTY = al.THEUNCERTAINTY,
                            MAXVALUE = al.MAXVALUE,
                            MAXCATEGORIES = al.MAXCATEGORIES,
                            METERING_STANDARD_DEVICEID = al.METERING_STANDARD_DEVICEID,
                            GROUPS = al.GROUPS
                        };
                        msdshow.ALLOWABLE_ERRORShow.Add(alladd);
                    }
                    foreach (var ms in msdcdata)//循环添加数据
                    {
                        var msdcadd = new METERING_STANDARD_DEVICE_CHECKShow()
                        {
                            ID = ms.ID,
                            CERTIFICATEUNIT = ms.CERTIFICATEUNIT,
                            CERTIFICATE_NUM = ms.CERTIFICATE_NUM,
                            CHECK_DATE = ms.CHECK_DATE,
                            VALID_TO = ms.VALID_TO,
                            METERING_STANDARD_DEVICEID = ms.METERING_STANDARD_DEVICEID,
                            GROUPS = ms.GROUPS
                        };
                        msdshow.METERING_STANDARD_DEVICE_CHECKShow.Add(msdcadd);
                    }
                }
                else if (IS == "UA"||IS=="UB")
                {                                     
                        var undata = msd.UNCERTAINTYTABLE.Where(a => a.GROUPS == GROUPS && a.CATEGORY == IS);//筛选数据
                        //undata = undata.Where(b => b.UNCERTAINTYUI != null);
                        foreach (var al in undata)//循环添加数据
                        {
                            var unadd = new UNCERTAINTYTABLEShow()
                            {
                                ID = al.ID,
                                ASSESSMENTITEM = al.ASSESSMENTITEM,
                                ERRORSOURCES = al.ERRORSOURCES,
                                ERRORLIMITS = al.ERRORLIMITS,
                                ERRORLIMITUNIT = al.ERRORLIMITUNIT,
                                THEERRODISTRIBUTION = al.THEERRODISTRIBUTION,
                                KVALE = al.KVALE,
                                THERANGESCOPE = al.THERANGESCOPE,
                                THEUNIT = al.THEUNIT,
                                THERELATIONSHIP = al.THERELATIONSHIP,
                                ENDRANGESCOPE = al.ENDRANGESCOPE,
                                ENDUNIT = al.ENDUNIT,
                                ENDRELATIONSHIP = al.ENDRELATIONSHIP,
                                THEFREQUENCY = al.THEFREQUENCY,
                                THEUNITFREQUENCY = al.THEUNITFREQUENCY,
                                THERELATIONSHIPFREQUENCY = al.THERELATIONSHIPFREQUENCY,
                                ENDFREQUENCY = al.ENDFREQUENCY,
                                ENDUNITFREQUENCY = al.ENDUNITFREQUENCY,
                                ENDRELATIONSHIPFREQUENCY = al.ENDRELATIONSHIPFREQUENCY,
                                INDEX1 = al.INDEX1,
                                INDEX1UNIT = al.INDEX1UNIT,
                                INDEX2 = al.INDEX2,
                                INDEX2UNIT = al.INDEX2UNIT,
                                NOTE = al.NOTE,
                                METERING_STANDARD_DEVICEID = al.METERING_STANDARD_DEVICEID,
                                GROUPS = al.GROUPS,
                                UNCERTAINTYUI = al.UNCERTAINTYUI,
                                UNCERTAINTYUIUNIT=al.UNCERTAINTYUIUNIT
                            };
                            msdshow.UNCERTAINTYTABLEShow.Add(unadd);
                        }                                                  
                }
                msdshow.IS = IS;
                msdshow.ID = msd.ID;
                ViewBag.GROUPS = GROUPS.ToString();
                ViewBag.CATEGORY = IS.ToString();
            }
            return View(msdshow);
        }

        IBLL.IMETERING_STANDARD_DEVICEBLL m_BLL;
        IBLL.IALLOWABLE_ERRORBLL m_BLL2;
        IBLL.IMETERING_STANDARD_DEVICE_CHECKBLL m_BLL3;

        ValidationErrors validationErrors = new ValidationErrors();

        public METERING_STANDARD_DEVICEController()
            : this(new METERING_STANDARD_DEVICEBLL(), new ALLOWABLE_ERRORBLL(), new METERING_STANDARD_DEVICE_CHECKBLL()) { }

        public METERING_STANDARD_DEVICEController(METERING_STANDARD_DEVICEBLL bll, ALLOWABLE_ERRORBLL bll2, METERING_STANDARD_DEVICE_CHECKBLL bll3)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
        }
    }
}


