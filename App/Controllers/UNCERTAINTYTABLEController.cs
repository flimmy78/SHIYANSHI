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
    /// 不确定度
    /// </summary>
    public class UNCERTAINTYTABLEController : BaseController
    {

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index(string id)
        {
            ViewBag.METERING_STANDARD_DEVICEID = id;
            return View();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult IndexSet(string id)
        {
            ViewBag.METERING_STANDARD_DEVICEID = id;
            return View();
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult IndexUB()
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
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            UNCERTAINTYTABLEBLL ulbll = new UNCERTAINTYTABLEBLL();
         
            var data = ulbll.GetAll();//查询数据
            int zhu = Convert.ToInt32(id);
            var date = data.Where(w => w.GROUPS == zhu && w.CATEGORY == "UB");
            int a = date.Count();
            //List<UNCERTAINTYTABLE> list = new List<UNCERTAINTYTABLE>();
            METERING_STANDARD_DEVICEShow msdshow = new METERING_STANDARD_DEVICEShow();
            UNCERTAINTYTABLEShow ueshow = null;
            List<UNCERTAINTYTABLEShow> ueshowlist = new List<UNCERTAINTYTABLEShow>();
            int GROUPS = 0;
            string groups = string.Empty;
            foreach (var item in date)
            {
                ueshow= new UNCERTAINTYTABLEShow();
                ueshow.ASSESSMENTITEM = item.ASSESSMENTITEM;//评定项
                ueshow.THERANGESCOPE = item.THERANGESCOPE;//量程范围起
                ueshow.THEUNIT = item.THEUNIT;//起单位
                ueshow.THERELATIONSHIP = item.THERELATIONSHIP;//起关系
                ueshow.ENDRANGESCOPE = item.ENDRANGESCOPE;//量程范围止
                ueshow.ENDUNIT = item.ENDUNIT;//止单位
                ueshow.ENDRELATIONSHIP = item.ENDRELATIONSHIP;//止关系
                ueshow.THEFREQUENCY = item.THEFREQUENCY;//频率范围起
                ueshow.THEUNITFREQUENCY = item.THEUNITFREQUENCY;//起单位
                ueshow.THERELATIONSHIPFREQUENCY = item.THERELATIONSHIPFREQUENCY;//频率起关系
                ueshow.ENDFREQUENCY = item.ENDFREQUENCY;//频率范围止
                ueshow.ENDUNITFREQUENCY = item.ENDUNITFREQUENCY;//频率止单位
                ueshow.ENDRELATIONSHIPFREQUENCY = item.ENDRELATIONSHIPFREQUENCY;//频率止关系
                ueshow.INDEX1 = item.INDEX1;//指标1
                ueshow.INDEX1UNIT = item.INDEX1UNIT;//指标1单位
                ueshow.INDEX2 = item.INDEX2;//指标2
                ueshow.INDEX2UNIT = item.INDEX2UNIT;//指标2单位
                ueshow.NOTE = item.NOTE;//备注
                ueshow.CATEGORY = item.CATEGORY;
                ueshow.GROUPS = GROUPS;
                ueshow.ID = item.ID;
                groups = item.GROUPS.ToString();
                ueshowlist.Add(ueshow);
                
                GROUPS++;
            }
            msdshow.UNCERTAINTYTABLEShow = ueshowlist;
            ViewBag.groups = groups;
            return View(msdshow);
        }
        IBLL.IUNCERTAINTYTABLEBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public UNCERTAINTYTABLEController()
            : this(new UNCERTAINTYTABLEBLL()) { }

        public UNCERTAINTYTABLEController(UNCERTAINTYTABLEBLL bll)
        {
            m_BLL = bll;
        }
    }
}


