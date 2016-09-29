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
    /// 检定项目模板
    /// </summary>
    public class PROJECTTEMPLETController : BaseController
    {
        /// <summary>
        /// 直流电压（电流）测量-非正负极性-相对误差
        /// </summary>
        /// <param name="id"></param>
        /// <param name="RULEID"></param>
        /// <param name="SCHEMEID"></param>
        /// <returns></returns>
        public ActionResult ZhiLiuDianLiuDianYaFeiZhengFu(string id, string RULEID, string SCHEMEID)
        {
           
            if (string.IsNullOrWhiteSpace(id))
            { 
                //id为空，则为新增
                DAL.PROJECTTEMPLET model = m_BLL.GetModelByRULEID_SCHEMEID(RULEID, SCHEMEID);
                if (model != null)
                {
                    ViewData["ID"] = model.ID;
                }
                else
                {//这种情况，应该重新登陆试试了
                    RedirectToAction("Account");
                }
            }
            else
            {
                //已有id，则为修改
                ViewData["ID"] = id;
            }
            ViewData["RULEID"] = RULEID;
            ViewData["SCHEMEID"] = SCHEMEID;
            return View();
        }
        /// <summary>
        /// 直流电流输出
        /// </summary>
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult ZhiLiuDianLiuShuChu(string RULEID, string SCHEMEID)
        {
            DAL.PROJECTTEMPLET entity = m_BLL.GetModelByRULEID_SCHEMEID(RULEID, SCHEMEID);
            if (entity != null)
            {
                ViewData["ID"] = entity.ID;
            }

            ViewData["RULEID"] = RULEID;
            ViewData["SCHEMEID"] = SCHEMEID;
            return View(entity);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="OldID">原编号</param>
        /// <param name="RULEID">规程编号</param>
        /// <param name="SCHEMEID">方案编号</param>
        /// <param name="HTMLVALUE">html</param>
        /// <returns></returns>
        public ActionResult Save(string OldID, string RULEID, string SCHEMEID, string HTMLVALUE)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            PROJECTTEMPLET entity = new PROJECTTEMPLET();
            string currentPerson = GetCurrentPerson();
            entity.CREATETIME = DateTime.Now;
            entity.CREATEPERSON = currentPerson;
            entity.RULEID = RULEID;
            entity.ID = Result.GetNewId();
            entity.SCHEMEID = SCHEMEID;
            entity.HTMLVALUE = Server.UrlDecode(HTMLVALUE);//解码

            if (OldID != null && OldID.Trim() != "")
            {
                m_BLL.Delete(ref validationErrors, OldID);
            }

            string returnValue = string.Empty;
            if (m_BLL.Create(ref validationErrors, entity))
            {
                LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，检定项目模板的Id为" + entity.ID, "检定项目模板"
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
                LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，检定项目模板，" + returnValue, "检定项目模板"
                    );//写入日志                      
                result.Code = Common.ClientCode.Fail;
                result.Message = Suggestion.InsertFail + returnValue;
                return Json(result); //提示插入失败
            }

        }

        IBLL.IPROJECTTEMPLETBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public PROJECTTEMPLETController()
                    : this(new PROJECTTEMPLETBLL()) { }

        public PROJECTTEMPLETController(PROJECTTEMPLETBLL bll)
        {
            m_BLL = bll;
        }

    }
}


