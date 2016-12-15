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
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostDataX([FromBody]GetDataParam getParam)
        {
            int total = 0;
            getParam.page = 1;
            getParam.rows = 9999;
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
                string returnValue = string.Empty;
                if (!string.IsNullOrWhiteSpace(entity.ID))
                {
                    entity.UPDATEPERSON = currentPerson;
                    entity.UPDATETIME = DateTime.Now;
                    if (m_BLL.EditField(ref validationErrors, entity))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，标准装置/计量标准器信息的信息的Id为" + entity.ID, "标准装置/计量标准器信息"
                            );//写入日志 
                        result.Code = Common.ClientCode.Succeed;
                        result.Message = Suggestion.UpdateSucceed;
                        return result; //提示修改成功
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
                        LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，标准装置/计量标准器信息的信息，" + returnValue, "标准装置/计量标准器信息"
                            );//写入日志                      
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.UpdateFail + returnValue;
                        return result; //提示修改失败
                    }
                }
                else
                {
                    entity.ID = Result.GetNewId();
                    entity.CREATETIME = DateTime.Now;
                    entity.CREATEPERSON = currentPerson;
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
        [HttpPost]
        public METERING_STANDARD_DEVICEShow Update(string id)
        {
            METERING_STANDARD_DEVICEShow msdshow = new METERING_STANDARD_DEVICEShow();
            if (!string.IsNullOrWhiteSpace(id))
            {
                METERING_STANDARD_DEVICE msd = m_BLL.GetById(id);
                msdshow.ID = msd.ID;
                msdshow.NAME = msd.NAME;
                msdshow.TEST_RANGE = msd.TEST_RANGE;
                msdshow.FACTORY_NUM = msd.FACTORY_NUM;
                msdshow.CATEGORY = msd.CATEGORY;
                msdshow.STATUS = msd.STATUS;
                msdshow.UNDERTAKE_LABORATORYID = msd.UNDERTAKE_LABORATORYID;
                msdshow.CREATETIME = msd.CREATETIME;
                msdshow.CREATEPERSON = msd.CREATEPERSON;
                msdshow.UPDATETIME = msd.UPDATETIME;
                msdshow.UPDATEPERSON = msd.UPDATEPERSON;
                msdshow.XINGHAO = msd.XINGHAO;
                msdshow.THESUPERIOR = msd.THESUPERIOR;
                if (!string.IsNullOrWhiteSpace(msd.THESUPERIOR))
                {
                    METERING_STANDARD_DEVICE msd2 = m_BLL.GetById(msd.THESUPERIOR);
                    msdshow.THESUPERIORNAME = msd2.ID + "&" + msd2.NAME;
                }
                if (!string.IsNullOrWhiteSpace(msd.ID))
                {
                    msdshow.IS = "1";
                }
                else
                {
                    msdshow.IS = "2";
                }
            }
            return msdshow;
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

        /// <summary>
        /// 准确度等级数据展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult ALLOWABLE_ERRORData(string id)
        {
            int total = 0;
            METERING_STANDARD_DEVICE msd = m_BLL.GetById(id);
            string CERTIFICATE_NUM = string.Empty;//证书编号
            string VALID_TO = string.Empty;//有效期
            string MAXCATEGORIES = string.Empty;//最大允许误差
            decimal? GROUPS = 0;//组别
            //分组
            var data = (from f in msd.METERING_STANDARD_DEVICE_CHECK
                        select f.CATEGORY).Distinct();


            List<App.Models.ALLOWABLE_ERRORData> alldata = new List<App.Models.ALLOWABLE_ERRORData>();

            foreach (var item in data)
            {
                CERTIFICATE_NUM = null;
                VALID_TO = null;
                MAXCATEGORIES = null;
                //计量标准装置检定/校准信息
                foreach (var it in msd.METERING_STANDARD_DEVICE_CHECK.Where(w => w.CATEGORY == item))
                {
                    TimeSpan ts = Convert.ToDateTime(it.VALID_TO) - DateTime.Now;

                    if (ts.Days > 0)
                    {

                        CERTIFICATE_NUM += it.CERTIFICATE_NUM + ",";

                        VALID_TO += Convert.ToDateTime(it.VALID_TO).ToString("yyyy-MM-dd") + ",";
                    }
                    GROUPS = it.GROUPS;
                }
                //最大允许误差信息
                foreach (var it in msd.ALLOWABLE_ERROR.Where(w => w.CATEGORY == item))
                {
                    if (!string.IsNullOrWhiteSpace(VALID_TO))
                    {
                        if (!string.IsNullOrWhiteSpace(it.THEACCURACYLEVEL))
                        {

                            MAXCATEGORIES += it.THEACCURACYLEVEL + ",";
                        }
                        else if (!string.IsNullOrWhiteSpace(it.MAXCATEGORIES) || !string.IsNullOrWhiteSpace(it.MAXVALUE))
                        {

                            MAXCATEGORIES += it.MAXCATEGORIES + it.MAXVALUE + ",";
                        }
                        else if (!string.IsNullOrWhiteSpace(it.THEUNCERTAINTY) || !string.IsNullOrWhiteSpace(it.THEUNCERTAINTYVALUE) || !string.IsNullOrWhiteSpace(it.THEUNCERTAINTYNDEXL) || !string.IsNullOrWhiteSpace(it.THEUNCERTAINTYVALUEK))
                        {

                            MAXCATEGORIES += it.THEUNCERTAINTY + it.THEUNCERTAINTYVALUE + it.THEUNCERTAINTYNDEXL + it.THEUNCERTAINTYVALUEK + ",";
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(MAXCATEGORIES))
                {
                    alldata.Add(new ALLOWABLE_ERRORData()
                    {
                        CERTIFICATE_NUM = CERTIFICATE_NUM,//证书编号
                        VALID_TO = VALID_TO,//有效期
                        ID = id,//id
                        MAXCATEGORIES = MAXCATEGORIES,//最大允许误差
                        GROUPS = GROUPS,
                        CATEGORY = item
                    });
                }
            }

            var show = new Common.ClientResult.DataResult
            {
                total = total,
                rows = alldata.Select(s => new
                {
                    CERTIFICATE_NUM = s.CERTIFICATE_NUM.TrimEnd(','),//证书编号
                    VALID_TO = s.VALID_TO.TrimEnd(','),//有效期
                    ID = s.ID,//id
                    MAXCATEGORIES = s.MAXCATEGORIES.TrimEnd(','),//最大允许误差
                    GROUPS = s.GROUPS,
                    CATEGORY = s.CATEGORY
                })
            };
            return show;
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


