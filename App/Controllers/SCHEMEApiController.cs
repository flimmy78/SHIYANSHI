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
    /// 方案
    /// </summary>
    public class SCHEMEApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<SCHEME> queryData = m_BLL.GetByParam(null, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,NAME = s.NAME
					,REPORT_CATEGORY = s.REPORT_CATEGORY
					,CERTIFICATE_CATEGORY = s.CERTIFICATE_CATEGORY
					,STATUS = s.STATUS
					,ISSTOP = s.ISSTOP
					,ISPUBLISH = s.ISPUBLISH
					,COPYID = s.COPYID
					,UNDERTAKE_LABORATORYID =   s.UNDERTAKE_LABORATORYIDOld
					,PUBLISHTIME = s.PUBLISHTIME
					,PUBLISHPERSON = s.PUBLISHPERSON
					,ISPUBLISHTIME = s.ISPUBLISHTIME
					,ISPUBLISHPERSON = s.ISPUBLISHPERSON
					,CREATETIME = s.CREATETIME
					,CREATEPERSON = s.CREATEPERSON
					,UPDATETIME = s.UPDATETIME
					,UPDATEPERSON = s.UPDATEPERSON
					

                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public SCHEME Get(string id)
        {
            SCHEME item = m_BLL.GetById(id);
            return item;
        }
 
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Post([FromBody]SCHEME entity)
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
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed  + "，方案的信息的Id为" + entity.ID,"方案"
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
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，方案的信息，" + returnValue,"方案"
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
        public Common.ClientResult.Result Put([FromBody]SCHEME entity)
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，方案信息的Id为" + entity.ID,"方案"
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，方案信息的Id为" + entity.ID + "," + returnValue, "方案"
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
        public Common.ClientResult.Result MultOp(string query,string Op)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            string returnValue = string.Empty;
            string[] deleteId = query.GetString().Split(',');
            if (deleteId != null && deleteId.Length > 0)
            {
                if (Op == "删除")
                {
                    if (m_BLL.DeleteCollection(ref validationErrors, deleteId))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，方案的Id为" + string.Join(",", deleteId), "消息"
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
                        LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，方案的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息"
                            );//删除失败，写入日志
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.DeleteFail + returnValue;
                    }
                }
                else if(Op=="停用")
                {
                    List<SCHEME> list = new List<SCHEME>();
                    foreach(string id in deleteId)
                    {                        
                        SCHEME entity = m_BLL.GetById(id);
                        string currentPerson = GetCurrentPerson();
                        entity.UPDATEPERSON = currentPerson;
                        entity.UPDATETIME = DateTime.Now;
                        entity.ISSTOP = "停用";
                        list.Add(entity);
                    }
                    if(m_BLL.EditCollection(ref validationErrors, (IQueryable<SCHEME>)list))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，方案的Id为" + string.Join(",", deleteId), "消息");//修改成功，写入日志
                                    
                        result.Code = Common.ClientCode.Succeed;
                        result.Message = Suggestion.UpdateSucceed;
                        return result; //提示更新成功 
                    }
                    else
                    {
                        LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，方案的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息");//删除失败，写入日志
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.UpdateFail + returnValue;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="NAME">方案名称</param>       
        /// <param name="UNDERTAKE_LABORATORYID">实验室编号</param>
        /// <param name="RULEIDs">检查项编号多个,分割例如（1,2)</param>
        /// <returns></returns>
        public Common.ClientResult.Result Create(string NAME,string UNDERTAKE_LABORATORYID,string RULEIDs)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            result.Code = Common.ClientCode.Succeed;
            result.Message = Suggestion.InsertSucceed;
            return result;
        }


            IBLL.ISCHEMEBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public SCHEMEApiController()
            : this(new SCHEMEBLL()) { }

        public SCHEMEApiController(SCHEMEBLL bll)
        {
            m_BLL = bll;
        }
    }
}


