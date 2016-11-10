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
        /// 有功功率输出（测量）-引用误差
        /// </summary> 
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public ActionResult YouGongGongLvShuChuYinYongWuCha(string RULEID = "JJG126-1995_5", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

        /// <summary>
        /// 变送器-有功（无功）功率-引用误差
        /// </summary> 
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public ActionResult BianSongQiYouGongWuGong(string id = "有功功率", string RULEID = "126-1995_2_4_1", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            ViewBag.canshu = id;
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

        /// <summary>
        /// 变送器-相位-引用误差
        /// </summary> 
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public ActionResult BianSongQiXiangWei(string RULEID = "126-1995_2_7_1", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }
        /// <summary>
        /// 变送器-频率-引用误差
        /// </summary> 
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public ActionResult BianSongQiPinLu(string RULEID = "126-1995_2_1_1", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }
        /// <summary>
        /// 变送器-功率-引用误差
        /// </summary> 
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public ActionResult BianSongQiGongLu(string RULEID = "126-1995_2_6_1", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }
        /// <summary>
        /// 测试用
        /// </summary> 
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public ActionResult test(string id = "1", string RULEID = "JJG440-2008_3_1", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            ViewBag.canshu = Convert.ToInt32(id);
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

        /// <summary>
        /// 变送器-电流电压-引用误差 BianSongQiDianLiuDianYa/电流
        /// </summary> 
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public ActionResult BianSongQiDianLiuDianYa(string id = "电流", string RULEID = "126-1995_2_3_1", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            ViewBag.canshu = id;
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

      
        /// <summary>
        /// 工频单相相位输出（测量）-绝对误差-一列
        /// </summary> 
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public ActionResult GongPinDanXiangXiangWeiShuChuJueDuiWuChaYiLie(string id = "1", string RULEID = "JJG440-2008_3_1", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            ViewBag.canshu = Convert.ToInt32(id);
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

        /// <summary>
        /// 直流电压（电流）测量-非正负极性-相对误差
        /// </summary> 
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public ActionResult ZhiLiuDianLiuDianYaFeiZhengFu(string RULEID = "315-1983_2_1", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

        /// <summary>
        /// 直流电压（电流）测量-正负极性-相对误差（多通道）
        /// </summary> 
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public ActionResult ZhiLiuDianLiuDianYaZhengFu(string RULEID = "315-1983_2_2", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

        /// <summary>
        /// 直流电流输出
        /// </summary>
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult ZhiLiuDianLiuShuChu(string RULEID = "38-1987_2", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

        /// <summary>
        /// 交流电压（电流）-相对误差-两相
        /// </summary>
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult JiaoLiuDianYaXiangDuiWuChaLiangXiang(string RULEID = "35-1999_2_2", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

        /// <summary>
        /// 交流电压(电流)-相对误差-三相
        /// </summary>
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult JiaoLiuDianYaXiangDuiWuChaSanXiang(string RULEID = "35-1999_2_4", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

        /// <summary>
        /// 交流电压（电流）测量-相对误差-单相(多通道）
        /// </summary>
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult JiaoLiuDianYaXiangDuiWuChaDanxiang(string RULEID = "", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

        /// <summary>
        /// 频率输出-频率测量-相对误差
        /// </summary>
        /// <param name="RULEID">检测项目ID</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult PingLuShuChuCheLinagXiangDuiWuCha(string RULEID = "34-1999_2_41", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            return Detail(RULEID, SCHEMEID, PREPARE_SCHEMEID);
        }

        public ActionResult Detail(string RULEID = "", string SCHEMEID = "", string PREPARE_SCHEMEID = "")
        {
            // ViewBag.ITEID = "";
            if (!string.IsNullOrEmpty(SCHEMEID) && !string.IsNullOrEmpty(PREPARE_SCHEMEID))
            {
                DAL.PROJECTTEMPLET entity = m_BLL.GetModelByRULEID_SCHEMEID(RULEID, SCHEMEID);
                if (entity != null)
                {
                    ViewBag.ID = entity.ID;
                }
                else
                {
                    ViewBag.ID = string.Empty;
                }
                if (PREPARE_SCHEMEID != null && PREPARE_SCHEMEID.Trim() != "")
                {
                    QUALIFIED_UNQUALIFIED_TEST_ITE qEntity = null;
                    IBLL.IQUALIFIED_UNQUALIFIED_TEST_ITEBLL qBLL = new QUALIFIED_UNQUALIFIED_TEST_ITEBLL();
                    qEntity = qBLL.GetByPREPARE_SCHEMEID_RULEID(PREPARE_SCHEMEID, RULEID);
                    if (qEntity != null)
                    {
                        entity.HTMLVALUE = qEntity.HTMLVALUE;
                        ViewBag.ITEID = qEntity.ID;

                    }
                }
                return View(entity);
            }

            ViewBag.PREPARE_SCHEMEID = PREPARE_SCHEMEID;
            ViewBag.RULEID = RULEID;
            ViewBag.SCHEMEID = SCHEMEID;
            return View();
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


