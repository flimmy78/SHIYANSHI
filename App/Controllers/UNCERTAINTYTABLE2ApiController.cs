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
    public class UNCERTAINTYTABLE2ApiController : BaseApiController
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
                    ,
                    INDEX2UNIT = s.INDEX2UNIT
                    ,
                    INDEX2 = s.INDEX2
                    ,
                    INDEX1UNIT = s.INDEX1UNIT
                    ,
                    INDEX1 = s.INDEX1
                    ,
                    ENDUNITFREQUENCY = s.ENDUNITFREQUENCY
                    ,
                    ENDRELATIONSHIPFREQUENCY = s.ENDRELATIONSHIPFREQUENCY
                    ,
                    THERELATIONSHIPFREQUENCY = s.THERELATIONSHIPFREQUENCY
                    ,
                    THEUNITFREQUENCY = s.THEUNITFREQUENCY
                    ,
                    THEFREQUENCY = s.THEFREQUENCY
                    ,
                    ENDRELATIONSHIP = s.ENDRELATIONSHIP
                    ,
                    ENDUNIT = s.ENDUNIT
                    ,
                    ENDRANGESCOPE = s.ENDRANGESCOPE
                    ,
                    THERELATIONSHIP = s.THERELATIONSHIP
                    ,
                    THEUNIT = s.THEUNIT
                    ,
                    THERANGESCOPE = s.THERANGESCOPE
                    ,
                    KVALE = s.KVALE
                    ,
                    THEERRODISTRIBUTION = s.THEERRODISTRIBUTION
                    ,
                    ERRORLIMITUNIT = s.ERRORLIMITUNIT
                    ,
                    ERRORLIMITS = s.ERRORLIMITS
                    ,
                    ERRORSOURCES = s.ERRORSOURCES
                    ,
                    ASSESSMENTITEM = s.ASSESSMENTITEM
                    ,
                    CREATETIME = s.CREATETIME
                    ,
                    CREATEPERSON = s.CREATEPERSON
                    ,
                    UPDATETIME = s.UPDATETIME
                    ,
                    UPDATEPERSON = s.UPDATEPERSON
                    ,
                    METERING_STANDARD_DEVICEID = s.METERING_STANDARD_DEVICEIDOld
                    ,
                    ID = s.ID


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
        [System.Web.Http.HttpPost]
        public Common.ClientResult.Result InstUAUB([FromBody]METERING_STANDARD_DEVICE entity)
        {

            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {
                //string currentPerson = GetCurrentPerson();
                //entity.CreateTime = DateTime.Now;
                //entity.CreatePerson = currentPerson;
                int groups = 1;
                string currentPerson = GetCurrentPerson();

                List<UNCERTAINTYTABLE> list = m_BLL.GetByRefMETERING_STANDARD_DEVICEID(entity.ID);
                var data = (from f in list select f.GROUPS).Max();
                if (data != null)
                {
                    groups = (int)data + 1;
                }
                string returnValue = string.Empty;
                foreach (var item in entity.UNCERTAINTYTABLE)
                {
                    item.CREATETIME = DateTime.Now;
                    item.CREATEPERSON = currentPerson;
                    item.ID = Result.GetNewId();
                    item.GROUPS = groups;
                    if (m_BLL.Create(ref validationErrors, item))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，不确定度的信息的Id为" + item.ID, "不确定度"
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
                        LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，不确定度的信息，" + returnValue, "不确定度"
                            );//写入日志                      
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.InsertFail + returnValue;
                        return result; //提示插入失败
                    }
                }
                return result;
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


                foreach (var item in entity.UNCERTAINTYTABLE)
                {
                    item.UPDATETIME = DateTime.Now;
                    item.UPDATEPERSON = currentPerson;
                }
                string returnValue = string.Empty;
                if (m_BLL.EditUpdate(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，不确定度信息的Id为" + entity.ID, "不确定度"
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
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息"
                        );//删除失败，写入日志
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.DeleteFail + returnValue;
                }
            }
            return result;
        }

        /// <summary>
        /// 误差来源数据展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult UNCERTAINTYTABLEData_WUCHA(string id)
        {
            int total = 0;
            List<UNCERTAINTYTABLE> msd = m_BLL.GetByRefMETERING_STANDARD_DEVICEID(id);
            string ASSESSMENTITEM = string.Empty;//评定项
            string ERRORSOURCES = string.Empty;//误差来源
            string ERRORLIMITS = string.Empty;//误差限
            string THEERRODISTRIBUTION = string.Empty;//误差分布状况
            string KVALE = string.Empty;//k
            string UNCERTAINTYUI = string.Empty;//不确定度ui
            string CATEGORY = string.Empty;//类型
            decimal? GROUPS = 0;
            //分组
            //var data = (from f in msd
            //            select f.CATEGORY).Distinct();
            var data = msd.Where(m => m.CATEGORY == "UA").Select(m => m.GROUPS).Distinct();

            List<UNCERTAINTYTABLE> alldata = new List<UNCERTAINTYTABLE>();

            foreach (var item in data)
            {
                ASSESSMENTITEM = null;
                ERRORSOURCES = null;
                ERRORLIMITS = null;
                THEERRODISTRIBUTION = null;
                KVALE = null;
                UNCERTAINTYUI = null;
                //计量标准装置检定/校准信息
                foreach (var it in msd.Where(w => w.GROUPS == item))
                {
                    ASSESSMENTITEM += it.ASSESSMENTITEM + ",";
                    ERRORSOURCES += it.ERRORSOURCES + ",";
                    ERRORLIMITS += it.ERRORLIMITS + it.ERRORLIMITUNIT + ",";
                    THEERRODISTRIBUTION += it.THEERRODISTRIBUTION + ",";
                    KVALE += it.KVALE + ",";
                    UNCERTAINTYUI += it.UNCERTAINTYUI + it.UNCERTAINTYUIUNIT + ",";
                    GROUPS = it.GROUPS;
                    CATEGORY = it.CATEGORY;
                }
                alldata.Add(new UNCERTAINTYTABLE()
                {
                    ASSESSMENTITEM = ASSESSMENTITEM,
                    ERRORSOURCES = ERRORSOURCES,
                    ERRORLIMITS = ERRORLIMITS,
                    THEERRODISTRIBUTION = THEERRODISTRIBUTION,
                    KVALE = KVALE,
                    UNCERTAINTYUI = UNCERTAINTYUI,
                    GROUPS = GROUPS,
                    CATEGORY = CATEGORY

                });
            }

            var show = new Common.ClientResult.DataResult
            {
                total = total,
                rows = alldata.Select(s => new
                {
                    ASSESSMENTITEM = s.ASSESSMENTITEM.TrimEnd(','),
                    ERRORSOURCES = s.ERRORSOURCES.TrimEnd(','),
                    ERRORLIMITS = s.ERRORLIMITS.TrimEnd(','),
                    THEERRODISTRIBUTION = s.THEERRODISTRIBUTION.TrimEnd(','),
                    KVALE = s.KVALE.TrimEnd(','),
                    UNCERTAINTYUI = s.UNCERTAINTYUI.TrimEnd(','),
                    GROUPS = s.GROUPS,
                    METERING_STANDARD_DEVICEID = id,
                    CATEGORY = s.CATEGORY
                })
            };
            return show;
        }
        /// <summary>
        /// 误差来源数据展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult UNCERTAINTYTABLEData_WUCHA_Set(string id)
        {
            int total = 0;
            List<UNCERTAINTYTABLE> msd = m_BLL.GetByRefMETERING_STANDARD_DEVICEID(id);
            string ASSESSMENTITEM = string.Empty;//评定项
            string ERRORSOURCES = string.Empty;//误差来源
            string ERRORLIMITS = string.Empty;//误差限
            string THEERRODISTRIBUTION = string.Empty;//误差分布状况
            string KVALE = string.Empty;//k
            string UNCERTAINTYUI = string.Empty;//不确定度ui

            //分组
            //var data = (from f in msd
            //            select f.CATEGORY).Distinct();
            //var data = msd.Where(m => m.CATEGORY == "UA").Select(m => m.CATEGORY).Distinct();
            var data = msd.Where(m => m.CATEGORY == "UA");
            List<UNCERTAINTYTABLE> alldata = new List<UNCERTAINTYTABLE>();
            //计量标准装置检定/校准信息
            var show = new Common.ClientResult.DataResult
            {
                total = total,
                rows = data.Select(s => new
                {
                    ASSESSMENTITEM = s.ASSESSMENTITEM,
                    ERRORSOURCES = s.ERRORSOURCES,
                    ERRORLIMITS = s.ERRORLIMITS+s.ERRORLIMITUNIT,
                    THEERRODISTRIBUTION = s.THEERRODISTRIBUTION,
                    KVALE = s.KVALE,
                    UNCERTAINTYUI = s.UNCERTAINTYUI+s.UNCERTAINTYUIUNIT,
                    GROUPS = s.GROUPS,
                    METERING_STANDARD_DEVICEID = id,
                    CATEGORY = s.CATEGORY
                })
            };
            return show;
        }
        /// <summary>
        /// 范围指标数据展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult UNCERTAINTYTABLEData_ZHIBIAO(string id)
        {
            int total = 0;
            List<UNCERTAINTYTABLE> msd = m_BLL.GetByRefMETERING_STANDARD_DEVICEID(id);
            string ASSESSMENTITEM = string.Empty;//评定项
            string THERANGESCOPE = string.Empty;//量程范围
            string THEFREQUENCY = string.Empty;//频率范围
            string INDEX1 = string.Empty;//指标1
            string INDEX2 = string.Empty;//指标2
            decimal? GROUPS = 0;
            string CATEGORY = string.Empty;//类型
            //分组
            //var data = (from f in msd
            //            select f.CATEGORY).Distinct();
            var data = msd.Where(m => m.CATEGORY == "UB").Select(m => m.GROUPS).Distinct();


            List<UNCERTAINTYTABLE> alldata = new List<UNCERTAINTYTABLE>();

            foreach (var item in data)
            {
                ASSESSMENTITEM = null;
                THERANGESCOPE = null;
                THEFREQUENCY = null;
                INDEX1 = null;
                INDEX2 = null;
                //计量标准装置检定/校准信息
                foreach (var it in msd.Where(w => w.GROUPS == item))
                {
                    ASSESSMENTITEM = it.ASSESSMENTITEM ;
                    THERANGESCOPE += it.THERANGESCOPE + it.THEUNIT + it.THERELATIONSHIP + it.ENDRANGESCOPE + it.ENDUNIT + it.ENDRELATIONSHIP + ",";
                    THEFREQUENCY += it.THEFREQUENCY + it.THEUNITFREQUENCY + it.THERELATIONSHIPFREQUENCY + it.ENDFREQUENCY + it.ENDUNITFREQUENCY + it.ENDRELATIONSHIPFREQUENCY + ",";
                    INDEX1 += it.INDEX1 + it.INDEX1UNIT + ",";
                    INDEX2 += it.INDEX2 + it.INDEX2UNIT + ",";
                    GROUPS = it.GROUPS;
                    CATEGORY = it.CATEGORY;
                }
                alldata.Add(new UNCERTAINTYTABLE()
                {
                    ASSESSMENTITEM = ASSESSMENTITEM,
                    THERANGESCOPE = THERANGESCOPE,
                    THEFREQUENCY = THEFREQUENCY,
                    INDEX1 = INDEX1,
                    INDEX2 = INDEX2,
                    GROUPS = GROUPS,
                    CATEGORY = CATEGORY
                });
            }

            var show = new Common.ClientResult.DataResult
            {
                total = total,
                rows = alldata.Select(s => new
                {
                    ASSESSMENTITEM = s.ASSESSMENTITEM.TrimEnd(','),
                    THERANGESCOPE = s.THERANGESCOPE.TrimEnd(','),
                    THEFREQUENCY = s.THEFREQUENCY.TrimEnd(','),
                    INDEX1 = s.INDEX1.TrimEnd(','),
                    INDEX2 = s.INDEX2.TrimEnd(','),
                    GROUPS = s.GROUPS,
                    METERING_STANDARD_DEVICEID = id,
                    CATEGORY = s.CATEGORY
                })
            };
            return show;
        }
       
        IBLL.IUNCERTAINTYTABLEBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public UNCERTAINTYTABLE2ApiController()
            : this(new UNCERTAINTYTABLEBLL()) { }

        public UNCERTAINTYTABLE2ApiController(UNCERTAINTYTABLEBLL bll)
        {
            m_BLL = bll;
        }

    }
}


