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
            ViewBag.Id = id;
            METERING_STANDARD_DEVICE mce = m_BLL.GetById(id);
            #region 标准装置/计量标准器相关数据
            //mce.METERING_STANDARD_DEVICEShow = mete.Select(m => new METERING_STANDARD_DEVICEShow
            //{
            //    ID = m.ID,
            //    NAME = m.NAME,
            //    TEST_RANGE = m.TEST_RANGE,
            //    FACTORY_NUM = m.FACTORY_NUM,
            //    CATEGORY = m.CATEGORY,
            //    STATUS = m.STATUS,
            //    UNDERTAKE_LABORATORYID = m.UNDERTAKE_LABORATORYID,
            //    CREATETIME = m.CREATETIME,
            //    CREATEPERSON = m.CREATEPERSON,
            //    UPDATETIME = m.UPDATETIME,
            //    UPDATEPERSON = m.UPDATEPERSON,
            //    METERING_STANDARD_DEVICE_CHECKShow = m.METERING_STANDARD_DEVICE_CHECK.Select(s => new METERING_STANDARD_DEVICE_CHECKShow
            //    {
            //        ID = s.ID,
            //        CERTIFICATE_NUM = s.CERTIFICATE_NUM,
            //        CHECK_DATE = s.CHECK_DATE,
            //        VALID_TO = s.VALID_TO,
            //        METERING_STANDARD_DEVICEID = s.METERING_STANDARD_DEVICEID,
            //        CREATETIME = s.CREATETIME,
            //        CREATEPERSON = s.CREATEPERSON,
            //        UPDATETIME = s.UPDATETIME,
            //        UPDATEPERSON = s.UPDATEPERSON
            //    }).ToList(),
            //    ALLOWABLE_ERRORShow = m.ALLOWABLE_ERROR.Select(e => new ALLOWABLE_ERRORShow
            //    {
            //        ID = e.ID,
            //        //VALUE = e.VALUE,
            //        //UNIT = e.UNIT,
            //        METERING_STANDARD_DEVICEID = e.METERING_STANDARD_DEVICEID,
            //        CREATETIME = e.CREATETIME,
            //        CREATEPERSON = e.CREATEPERSON,
            //        UPDATETIME = e.UPDATETIME,
            //        UPDATEPERSON = e.UPDATEPERSON
            //    }).ToList()
            //}).ToList();
            #endregion
            return View(mce);
        }


        IBLL.IMETERING_STANDARD_DEVICEBLL m_BLL;


        ValidationErrors validationErrors = new ValidationErrors();

        public METERING_STANDARD_DEVICEController()
            : this(new METERING_STANDARD_DEVICEBLL()) { }

        public METERING_STANDARD_DEVICEController(METERING_STANDARD_DEVICEBLL bll)
        {
            m_BLL = bll;
        }


    }

}


