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
    /// 器具领取2
    /// </summary>
    public class VQIJULINGQU2ApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<VQIJULINGQU2> queryData = m_BLL.GetByParam(getParam.id, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    APPLIANCE_NAME = s.APPLIANCE_NAME
                    ,
                    VERSION = s.VERSION
                    ,
                    FACTORY_NUM = s.FACTORY_NUM
                    ,
                    NUM = s.NUM
                    ,
                    ATTACHMENT = s.ATTACHMENT
                    ,
                    NAME = s.NAME
                    ,
                    APPLIANCE_RECIVE = s.APPLIANCE_RECIVE
                    ,
                    REPORTNUMBER = s.REPORTNUMBER
                    ,
                    REMARKS = s.REMARKS
                    ,
                    ORDER_TASK_INFORMATIONID = s.ORDER_TASK_INFORMATIONID


                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public VQIJULINGQU2 Get(string id)
        {
            VQIJULINGQU2 item = m_BLL.GetById(id);
            return item;
        }

        // PUT api/<controller>/5
        /// <summary>
        /// 报告，器具领取
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        public Common.ClientResult.Result Put(string baogaoid,string qijuid)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (baogaoid != null|| qijuid != null && ModelState.IsValid)
            {   //数据校验

                APPLIANCECOLLECTION app = new APPLIANCECOLLECTION();//器具领取
                REPORTCOLLECTION rep = new REPORTCOLLECTION();//报告领取
                string currentPerson = GetCurrentPerson();
                app.CREATETIME = DateTime.Now;//领取时间
                app.CREATEPERSON = currentPerson;//领取者
                rep.CREATETIME = DateTime.Now;//领取时间
                rep.CREATEPERSON = currentPerson;//领取者
                string returnValue = string.Empty;
                if (m_BLL2.Create(ref validationErrors, app))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，报告领取信息的Id为" + app.ID, "报告领取"
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，报告领取信息的Id为" + app.ID + "," + returnValue, "报告领取"
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

        IBLL.IVQIJULINGQU2BLL m_BLL;
        IBLL.IAPPLIANCECOLLECTIONBLL m_BLL2;
        IBLL.IREPORTCOLLECTIONBLL m_BLL3;


        ValidationErrors validationErrors = new ValidationErrors();

        public VQIJULINGQU2ApiController()
            : this(new VQIJULINGQU2BLL(),new APPLIANCECOLLECTIONBLL(),new REPORTCOLLECTIONBLL()) { }

        public VQIJULINGQU2ApiController(VQIJULINGQU2BLL bll, APPLIANCECOLLECTIONBLL bll2, REPORTCOLLECTIONBLL bll3)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
        }

    }
}


