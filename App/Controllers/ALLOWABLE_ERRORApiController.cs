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
    /// 最大允许误差信息
    /// </summary>
    public class ALLOWABLE_ERRORApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<ALLOWABLE_ERROR> queryData = m_BLL.GetByParam(null, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    THEACCURACYLEVEL = s.THEACCURACYLEVEL
                    ,
                    THEUNCERTAINTYVALUEK = s.THEUNCERTAINTYVALUEK
                     ,
                    THEUNCERTAINTYNDEXL = s.THEUNCERTAINTYNDEXL
                     ,
                    THEUNCERTAINTYVALUE = s.THEUNCERTAINTYVALUE
                     ,
                    THEUNCERTAINTY = s.THEUNCERTAINTY
                     ,
                    MAXVALUE = s.MAXVALUE
                     ,
                    MAXCATEGORIES = s.MAXCATEGORIES
                    ,
                    METERING_STANDARD_DEVICEID = s.METERING_STANDARD_DEVICEIDOld
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
        public ALLOWABLE_ERROR Get(string id)
        {
            ALLOWABLE_ERROR item = m_BLL.GetById(id);
            return item;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Post([FromBody]METERING_STANDARD_DEVICE entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            string returnValue = string.Empty;
            if (entity != null && ModelState.IsValid)
            {
                string currentPerson = GetCurrentPerson();
                entity.CREATETIME = DateTime.Now;
                entity.CREATEPERSON = currentPerson;
                int groups = 1;
                List<ALLOWABLE_ERROR> list = m_BLL.GetByRefMETERING_STANDARD_DEVICEID(entity.ID);
                var data = (from f in list select f.GROUPS).Max();
                if (data!=null)
                {
                    groups = (int)data + 1;
                }

                foreach (var item in entity.ALLOWABLE_ERROR)
                {
                    item.ID = Result.GetNewId();
                    item.CREATETIME = DateTime.Now;
                    item.CREATEPERSON = currentPerson;
                    item.METERING_STANDARD_DEVICEID = entity.ID;
                    item.GROUPS = groups;
                    if (m_BLL.Create(ref validationErrors, item))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，最大允许误差信息的信息的Id为" + entity.ID, "最大允许误差信息"
                            );//写入日志 
                        result.Code = Common.ClientCode.Succeed;
                        result.Message = Suggestion.InsertSucceed;
                        //return result; //提示创建成功
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
                        LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，最大允许误差信息的信息，" + returnValue, "最大允许误差信息"
                            );//写入日志                      
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.InsertFail + returnValue;
                        return result; //提示插入失败
                    }
                }
                foreach (var item in entity.METERING_STANDARD_DEVICE_CHECK)
                {
                    item.ID = Result.GetNewId();
                    item.CREATETIME = DateTime.Now;
                    item.CREATEPERSON = currentPerson;
                    item.METERING_STANDARD_DEVICEID = entity.ID;
                    item.GROUPS = groups;
                    if (m_BLL2.Create(ref validationErrors, item))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，计量标准装置检定/校准信息的信息的Id为" + entity.ID, "计量标准装置检定/校准信息"
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
                        LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，计量标准装置检定/校准信息的信息，" + returnValue, "计量标准装置检定/校准信息"
                            );//写入日志                      
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.InsertFail + returnValue;
                        return result; //提示插入失败
                    }
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
        public Common.ClientResult.Result Put([FromBody]ALLOWABLE_ERROR entity)
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，最大允许误差信息信息的Id为" + entity.ID, "最大允许误差信息"
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，最大允许误差信息信息的Id为" + entity.ID + "," + returnValue, "最大允许误差信息"
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
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息"
                        );//删除失败，写入日志
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.DeleteFail + returnValue;
                }
            }
            return result;
        }

        IBLL.IALLOWABLE_ERRORBLL m_BLL;
        IBLL.IMETERING_STANDARD_DEVICE_CHECKBLL m_BLL2;

        ValidationErrors validationErrors = new ValidationErrors();

        public ALLOWABLE_ERRORApiController()
            : this(new ALLOWABLE_ERRORBLL(), new METERING_STANDARD_DEVICE_CHECKBLL()) { }

        public ALLOWABLE_ERRORApiController(ALLOWABLE_ERRORBLL bll, METERING_STANDARD_DEVICE_CHECKBLL bll2)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
        }

    }
}


