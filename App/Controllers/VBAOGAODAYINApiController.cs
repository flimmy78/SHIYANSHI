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
    /// 报告打印
    /// </summary>
    public class VBAOGAODAYINApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<VBAOGAODAYIN> queryData = m_BLL.GetByParam(getParam.id, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,REPORTNUMBER = s.REPORTNUMBER
					,ORDER_NUMBER = s.ORDER_NUMBER
					,APPLIANCE_NAME = s.APPLIANCE_NAME
					,MODEL = s.MODEL
					,FACTORY_NUM = s.FACTORY_NUM
					,CERTIFICATE_ENTERPRISE = s.CERTIFICATE_ENTERPRISE
					,CUSTOMER_SPECIFIC_REQUIREMENTS = s.CUSTOMER_SPECIFIC_REQUIREMENTS
					,CERTIFICATE_CATEGORY = s.CERTIFICATE_CATEGORY
					,QUALIFICATIONS = s.QUALIFICATIONS
					,CONCLUSION_EXPLAIN = s.CONCLUSION_EXPLAIN
					,CONCLUSION = s.CONCLUSION
					,UNDERTAKE_LABORATORYID = s.UNDERTAKE_LABORATORYID
					,APPROVALDATE = s.APPROVALDATE
					,BAR_CODE_NUM = s.BAR_CODE_NUM
					,PRINTSTATUS = s.PRINTSTATUS
					

                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public VBAOGAODAYIN Get(string id)
        {
            VBAOGAODAYIN item = m_BLL.GetById(id);
            return item;
        }
  

        IBLL.IVBAOGAODAYINBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VBAOGAODAYINApiController()
            : this(new VBAOGAODAYINBLL()) { }

        public VBAOGAODAYINApiController(VBAOGAODAYINBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


