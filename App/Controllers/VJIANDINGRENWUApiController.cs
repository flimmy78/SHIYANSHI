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
    /// 检定任务
    /// </summary>
    public class VJIANDINGRENWUApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<VJIANDINGRENWU> queryData = m_BLL.GetByParam(getParam.id, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    ORDER_NUMBER = s.ORDER_NUMBER
                    ,
                    APPLIANCE_NAME = s.APPLIANCE_NAME
                    ,
                    VERSION = s.VERSION,
                    FACTORY_NUM = s.FACTORY_NUM
                    ,
                    CERTIFICATE_ENTERPRISE = s.CERTIFICATE_ENTERPRISE
                    ,
                    CUSTOMER_SPECIFIC_REQUIREMENTS = s.CUSTOMER_SPECIFIC_REQUIREMENTS
                    ,
                    ORDER_STATUS = s.ORDER_STATUS
                    ,
                    CREATETIME = s.CREATETIME
                    ,
                    APPLIANCE_PROGRESS = s.APPLIANCE_PROGRESS
                    ,
                    OVERDUE = s.OVERDUE
                    ,
                    STATE = s.STATE
                    ,
                    REPORTSTATUS = s.REPORTSTATUS
                    ,
                    APPROVAL = s.APPROVAL
                    ,
                    INSPECTION_ENTERPRISE = s.INSPECTION_ENTERPRISE
                    ,
                    ISOVERDUE = s.ISOVERDUE


                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public VJIANDINGRENWU Get(string id)
        {
            VJIANDINGRENWU item = m_BLL.GetById(id);
            return item;
        }


        IBLL.IVJIANDINGRENWUBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VJIANDINGRENWUApiController()
            : this(new VJIANDINGRENWUBLL()) { }

        public VJIANDINGRENWUApiController(VJIANDINGRENWUBLL bll)
        {
            m_BLL = bll;
        }

    }
}


