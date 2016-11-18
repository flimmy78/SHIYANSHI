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
using System.Web.Http;
using Langben.App.Models;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 不确定度
    /// </summary>
    public class UNCERTAINTYTABLEApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<UNCERTAINTYTABLE> queryData = m_BLL.GetByParam(null, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    NOTE = s.NOTE
					,INDEX2UNIT = s.INDEX2UNIT
					,INDEX2 = s.INDEX2
					,INDEX1UNIT = s.INDEX1UNIT
					,INDEX1 = s.INDEX1
					,ENDUNITFREQUENCY = s.ENDUNITFREQUENCY
					,ENDRELATIONSHIPFREQUENCY = s.ENDRELATIONSHIPFREQUENCY
					,THERELATIONSHIPFREQUENCY = s.THERELATIONSHIPFREQUENCY
					,THEUNITFREQUENCY = s.THEUNITFREQUENCY
					,THEFREQUENCY = s.THEFREQUENCY
					,ENDRELATIONSHIP = s.ENDRELATIONSHIP
					,ENDUNIT = s.ENDUNIT
					,ENDRANGESCOPE = s.ENDRANGESCOPE
					,THERELATIONSHIP = s.THERELATIONSHIP
					,THEUNIT = s.THEUNIT
					,THERANGESCOPE = s.THERANGESCOPE
					,KVALE = s.KVALE
					,THEERRODISTRIBUTION = s.THEERRODISTRIBUTION
					,ERRORLIMITUNIT = s.ERRORLIMITUNIT
					,ERRORLIMITS = s.ERRORLIMITS
					,ERRORSOURCES = s.ERRORSOURCES
					,ASSESSMENTITEM = s.ASSESSMENTITEM
					,CREATETIME = s.CREATETIME
					,CREATEPERSON = s.CREATEPERSON
					,UPDATETIME = s.UPDATETIME
					,UPDATEPERSON = s.UPDATEPERSON
					,METERING_STANDARD_DEVICEID =   s.METERING_STANDARD_DEVICEIDOld
					,ID = s.ID
					

                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public UNCERTAINTYTABLE Get(string id)
        {
            UNCERTAINTYTABLE item = m_BLL.GetById(id);
            return item;
        }
 
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Post([FromBody]UNCERTAINTYTABLE entity)
        {           

            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {
                //string currentPerson = GetCurrentPerson();
                //entity.CreateTime = DateTime.Now;
                //entity.CreatePerson = currentPerson;
              
                entity.ID = Result.GetNewId();   
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed  + "，不确定度的信息的Id为" + entity.ID,"不确定度"
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
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，不确定度的信息，" + returnValue,"不确定度"
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
        public Common.ClientResult.Result Put([FromBody]UNCERTAINTYTABLE entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                //string currentPerson = GetCurrentPerson();
                //entity.UpdateTime = DateTime.Now;
                //entity.UpdatePerson = currentPerson;

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，不确定度信息的Id为" + entity.ID,"不确定度"
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，不确定度信息的Id为" + entity.ID + "," + returnValue, "不确定度"
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
        /// <returns></returns>  
        public Common.ClientResult.Result Delete(string query)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            string returnValue = string.Empty;
            string[] deleteId = query.GetString().Split(',');
            if (deleteId != null && deleteId.Length > 0)
            {
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
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId)+ "," + returnValue, "消息"
                        );//删除失败，写入日志
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.DeleteFail + returnValue;
                }
            }
            return result;
        }

        IBLL.IUNCERTAINTYTABLEBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public UNCERTAINTYTABLEApiController()
            : this(new UNCERTAINTYTABLEBLL()) { }

        public UNCERTAINTYTABLEApiController(UNCERTAINTYTABLEBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


