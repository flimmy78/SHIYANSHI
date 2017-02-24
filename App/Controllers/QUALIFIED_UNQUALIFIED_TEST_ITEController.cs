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
    /// 合格不合格检定项目
    /// </summary>
    public class QUALIFIED_UNQUALIFIED_TEST_ITEController : BaseController
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
            return View();
        }
        /// <summary>
        /// 非表格首次编辑
        /// </summary>        
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <param name="RULEID">检测项ID</param>  
        /// <param name="SORT">排序</param>
        /// <param name="INPUTSTATE">录入格式</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult FeiBiaoGe(string PREPARE_SCHEMEID="",string RULEID="",string INPUTSTATE="HGBHG")
        {
            QUALIFIED_UNQUALIFIED_TEST_ITE entity = null;
            ViewBag.ID = "";
            ViewBag.INPUTSTATE = INPUTSTATE;           
            entity = m_BLL.GetByPREPARE_SCHEMEID_RULEID(PREPARE_SCHEMEID, RULEID);
            if (entity == null)
            {
                entity = new QUALIFIED_UNQUALIFIED_TEST_ITE();
                entity.PREPARE_SCHEMEID = PREPARE_SCHEMEID;
                entity.RULEID = RULEID;
            }  
            else
            {
                ViewBag.ID = entity.ID;
            }              
                        
            return View(entity);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="ID">原编号</param>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <param name="RULEID">检测项ID</param>     
        /// <param name="CONCLUSION">结论</param>
        /// <param name="REMARK">注</param>
        /// <param name="HTMLVALUE"></param>
        /// <param name="INPUTSTATE">录入格式</param>
        /// <returns></returns>
        public ActionResult Save(string ID="", string PREPARE_SCHEMEID="", string RULEID="",string CONCLUSION="",string REMARK="",string HTMLVALUE="",string INPUTSTATE="")
        {
            string returnValue = string.Empty;
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            QUALIFIED_UNQUALIFIED_TEST_ITE entity = new QUALIFIED_UNQUALIFIED_TEST_ITE();
            string currentPerson = GetCurrentPerson();
            entity.CREATETIME = DateTime.Now;
            entity.CREATEPERSON = currentPerson;
            entity.RULEID = RULEID;
            entity.ID = Result.GetNewId();
            entity.PREPARE_SCHEMEID = PREPARE_SCHEMEID;
            entity.HTMLVALUE = Server.UrlDecode(HTMLVALUE);//解码
            entity.CONCLUSION = CONCLUSION;
            entity.REMARK = REMARK;
            entity.INPUTSTATE = INPUTSTATE;
            
                        
            IBLL.IVTEST_ITEBLL vBLL = new BLL.VTEST_ITEBLL();
            DAL.VTEST_ITE vEntity = vBLL.GetById(PREPARE_SCHEMEID, RULEID);
            if(vEntity!=null)
            {
                entity.RULENAME = vEntity.NAME;
                entity.RULENJOINAME = vEntity.NAMEOTHER;
                entity.SORT = vEntity.SORT;
                entity.INPUTSTATE = vEntity.INPUTSTATE;
            }
            if(vEntity!=null && !string.IsNullOrWhiteSpace(vEntity.ID))
            {
                ID = vEntity.ID;
            }
            if (ID != null && ID.Trim() != "")
            {
                if (!m_BLL.Delete(ref validationErrors, ID))
                {
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail+ "，预备方案检测项的Id为" + entity.ID, "预备方案检测项");//写入日志 
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.InsertFail + returnValue;
                    return Json(result); //提示插入失败
                }
            }

            
            if (m_BLL.Create(ref validationErrors, entity))
            {
                LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，预备方案检测项的Id为" + entity.ID, "预备方案检测项"
                    );//写入日志 
                result.Code = Common.ClientCode.Succeed;
                //result.Message = Suggestion.InsertSucceed;
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
                LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，预备方案检测项，" + returnValue, "预备方案检测项"
                    );//写入日志                      
                result.Code = Common.ClientCode.Fail;
                result.Message = Suggestion.InsertFail + returnValue;
                return Json(result); //提示插入失败
            }

        }
        IBLL.IQUALIFIED_UNQUALIFIED_TEST_ITEBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public QUALIFIED_UNQUALIFIED_TEST_ITEController()
                    : this(new QUALIFIED_UNQUALIFIED_TEST_ITEBLL()) { }

        public QUALIFIED_UNQUALIFIED_TEST_ITEController(QUALIFIED_UNQUALIFIED_TEST_ITEBLL bll)
        {
            m_BLL = bll;
        }

    }
}


