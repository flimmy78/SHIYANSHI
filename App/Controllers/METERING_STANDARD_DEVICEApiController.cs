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
    /// 标准装置/计量标准器信息
    /// </summary>
    public class METERING_STANDARD_DEVICEApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<METERING_STANDARD_DEVICE> queryData = m_BLL.GetByParam(null, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    NAME = s.NAME
                    ,
                    TEST_RANGE = s.TEST_RANGE
                    ,
                    FACTORY_NUM = s.FACTORY_NUM
                    ,
                    XINGHAO = s.XINGHAO
                    ,
                    CATEGORY = s.CATEGORY
                    ,
                    STATUS = s.STATUS
                    ,
                    UNDERTAKE_LABORATORYID = s.UNDERTAKE_LABORATORYIDOld
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
        public METERING_STANDARD_DEVICE Get(string id)
        {
            METERING_STANDARD_DEVICE item = m_BLL.GetById(id);
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
            if (entity != null && ModelState.IsValid)
            {
                string currentPerson = GetCurrentPerson();
                entity.CREATETIME = DateTime.Now;
                entity.CREATEPERSON = currentPerson;

                entity.ID = Result.GetNewId();
                foreach (var item in entity.ALLOWABLE_ERROR)
                {
                    item.ID = Result.GetNewId();
                    item.CREATETIME = DateTime.Now;
                    item.CREATEPERSON = currentPerson;
                }
                foreach (var item in entity.METERING_STANDARD_DEVICE_CHECK)
                {
                    item.ID = Result.GetNewId();
                    item.CREATETIME = DateTime.Now;
                    item.CREATEPERSON = currentPerson;
                }
                foreach (var item in entity.UNCERTAINTYTABLE)
                {
                    item.ID = Result.GetNewId();
                    item.CREATETIME = DateTime.Now;
                    item.CREATEPERSON = currentPerson;
                }
                string returnValue = string.Empty;
                if (m_BLL.CreateX(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，标准装置/计量标准器信息的信息的Id为" + entity.ID, "标准装置/计量标准器信息"
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
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，标准装置/计量标准器信息的信息，" + returnValue, "标准装置/计量标准器信息"
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
        public Common.ClientResult.Result Put([FromBody]METERING_STANDARD_DEVICE entity)
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，标准装置/计量标准器信息信息的Id为" + entity.ID, "标准装置/计量标准器信息"
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，标准装置/计量标准器信息信息的Id为" + entity.ID + "," + returnValue, "标准装置/计量标准器信息"
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

        // PUT api/<controller>/5
        /// <summary>
        /// 编辑(标准器编辑功能)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        public Common.ClientResult.Result Update([FromBody]METERING_STANDARD_DEVICE entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                string currentPerson = GetCurrentPerson();
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = currentPerson;

                METERING_STANDARD_DEVICE mce = m_BLL.GetById(entity.ID);

                //List<CAttributeFeature> check = mce.METERING_STANDARD_DEVICE_CHECK.ToList();
                //check.Sort(SortCompare);
                foreach (var item in mce.METERING_STANDARD_DEVICE_CHECK)
                {
                    foreach (var item2 in entity.METERING_STANDARD_DEVICE_CHECK)
                    {
                        if (item.ID == item2.ID)
                        {

                        }
                    }
                }


                string returnValue = string.Empty;
                if (m_BLL.EditField(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，标准装置/计量标准器信息信息的Id为" + entity.ID, "标准装置/计量标准器信息"
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，标准装置/计量标准器信息信息的Id为" + entity.ID + "," + returnValue, "标准装置/计量标准器信息"
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
        #region

        #region SortCompare()函数，对List<CAttributeFeature>进行排序时作为参数使用

        /// <summary>

        /// 对List<CAttributeFeature>进行排序时作为参数使用

        /// </summary>

        /// <param name="AF1"></param>

        /// <param name="AF2"></param>

        /// <returns></returns>

        public static int SortCompare(CAttributeFeature AF1, CAttributeFeature AF2)

        {

            int res = 0;

            if (AF1.m_dAttributeFeature > AF2.m_dAttributeFeature)

            {

                res = -1;

            }

            else if (AF1.m_dAttributeFeature < AF2.m_dAttributeFeature)

            {

                res = 1;

            }

            return res;

        }

        #endregion
        #endregion

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

        /// <summary>
        /// list排序
        /// </summary>
        public class CAttributeFeature
        {
            public string m_strAttributeName { get; set; }

            public double m_dAttributeFeature { get; set; }

            public CAttributeFeature(string strName, double dFeature)

            {

                this.m_strAttributeName = strName;

                this.m_dAttributeFeature = dFeature;

            }

            public void FeatureAdd(double dFeature)

            {

                this.m_dAttributeFeature += dFeature;

            }
        }

        IBLL.IMETERING_STANDARD_DEVICEBLL m_BLL;
        IBLL.IALLOWABLE_ERRORBLL m_BLL2;
        IBLL.IMETERING_STANDARD_DEVICE_CHECKBLL m_BLL3;

        ValidationErrors validationErrors = new ValidationErrors();

        public METERING_STANDARD_DEVICEApiController()
            : this(new METERING_STANDARD_DEVICEBLL(), new ALLOWABLE_ERRORBLL(), new METERING_STANDARD_DEVICE_CHECKBLL()) { }

        public METERING_STANDARD_DEVICEApiController(METERING_STANDARD_DEVICEBLL bll, ALLOWABLE_ERRORBLL bll2, METERING_STANDARD_DEVICE_CHECKBLL bll3)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
        }

    }
}


