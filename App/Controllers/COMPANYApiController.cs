using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using System.Web.Http;
using Langben.App.Models;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 单位
    /// </summary>
    public class COMPANYApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<COMPANY> queryData = m_BLL.GetByParam(null, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    COMPANYNAME = s.COMPANYNAME
                    ,
                    COMPANYADDRES = s.COMPANYADDRES
                    ,
                    POSTCODE = s.POSTCODE
                    ,
                    CONTACTS = s.CONTACTS
                    ,
                    CONTACTSNUMBER = s.CONTACTSNUMBER
                    ,
                    FAX = s.FAX
                    ,
                    PARENTID = s.PARENTID
                    ,
                    CREATETIME = s.CREATETIME
                    ,
                    CREATEPERSON = s.CREATEPERSON
                    ,
                    UPDATETIME = s.UPDATETIME
                    ,
                    UPDATEPERSON = s.UPDATEPERSON


                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public COMPANY Get(string id)
        {
            COMPANY item = m_BLL.GetById(id);
            return item;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Post([FromBody]COMPANY entity)
        {

            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {
                string currentPerson = GetCurrentPerson();
                entity.CREATETIME = DateTime.Now;
                entity.CREATEPERSON = currentPerson;

                entity.ID = Result.GetNewId();
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，单位的信息的Id为" + entity.ID, "单位"
                        );//写入日志 
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.InsertSucceed;
                    return result; //提示创建成功
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
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，单位的信息，" + returnValue, "单位"
                        );//写入日志                      
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.InsertFail + returnValue;
                    return result; //提示插入失败
                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            return result;
        }

        // PUT api/<controller>/5
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        public Common.ClientResult.Result Put([FromBody]COMPANY entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                string currentPerson = GetCurrentPerson();
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = currentPerson;

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，单位信息的Id为" + entity.ID, "单位"
                        );//写入日志                   
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.UpdateSucceed;
                    return result; //提示更新成功 
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，单位信息的Id为" + entity.ID + "," + returnValue, "单位"
                        );//写入日志   
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return result; //提示更新失败
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return result; //提示输入的数据的格式不对         
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        [HttpPost]
        public Common.ClientResult.Result Delete(string id)
        {
            Common.ClientResult.OrderTaskGong result = new Common.ClientResult.OrderTaskGong();

            string returnValue = string.Empty;
            string[] deleteId = id.GetString().Split(',');
            if (deleteId != null && deleteId.Length > 0)
            {
                COMPANY com = m_BLL.GetById(deleteId[0]);//查询单位数据
                if (!ISUNIT(com.COMPANYNAME))//判断单位是否已经使用
                {
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息;以被使用不能删除！"
                       );//删除失败，写入日志
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.DeleteFail + returnValue;
                    result.IS = "有";
                    return result;
                }
                if (m_BLL.DeleteCollection(ref validationErrors, deleteId))
                {
                    LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，信息的Id为" + string.Join(",", deleteId), "消息"
                        );//删除成功，写入日志
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.DeleteSucceed;
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
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息"
                        );//删除失败，写入日志
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.DeleteFail + returnValue;
                }
            }
            return result;
        }

        /// <summary>
        /// 判断是否可以删除
        /// </summary>
        /// <param name="COMPANYNAME"></param>
        /// <returns></returns>
        public bool ISUNIT(string COMPANYNAME)
        {
            List<ORDER_TASK_INFORMATION> order = m_BLL2.GetAll();
            List<APPLIANCE_DETAIL_INFORMATION> APPLIANCE = m_BLL3.GetAll();
            foreach (var item in order)
            {
                if (item.INSPECTION_ENTERPRISE == COMPANYNAME || item.CERTIFICATE_ENTERPRISE == COMPANYNAME)
                {
                    return false;
                }
            }
            foreach (var item in APPLIANCE)
            {
                if (item.MAKE_ORGANIZATION == COMPANYNAME)
                {
                    return false;
                }
            }
            return true;
        }

        IBLL.ICOMPANYBLL m_BLL;
        IBLL.IORDER_TASK_INFORMATIONBLL m_BLL2;
        IBLL.IAPPLIANCE_DETAIL_INFORMATIONBLL m_BLL3;

        ValidationErrors validationErrors = new ValidationErrors();

        public COMPANYApiController()
            : this(new COMPANYBLL(), new ORDER_TASK_INFORMATIONBLL(), new APPLIANCE_DETAIL_INFORMATIONBLL()) { }

        public COMPANYApiController(COMPANYBLL bll, ORDER_TASK_INFORMATIONBLL bll2, APPLIANCE_DETAIL_INFORMATIONBLL bll3)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
        }

    }
}


