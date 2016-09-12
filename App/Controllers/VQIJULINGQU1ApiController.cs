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
    /// 器具领取1
    /// </summary>
    public class VQIJULINGQU1ApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<VQIJULINGQU1> queryData = m_BLL.GetByParam(getParam.id, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,ORDER_NUMBER = s.ORDER_NUMBER
					,CERTIFICATE_ENTERPRISE = s.CERTIFICATE_ENTERPRISE
					,CUSTOMER_SPECIFIC_REQUIREMENTS = s.CUSTOMER_SPECIFIC_REQUIREMENTS
					,
                    APPLIANCECOLLECTIONSATE = s.APPLIANCECOLLECTIONSATE
                    ,
                    CREATETIME = s.CREATETIME
					,
                    REPORTTORECEVESTATE = s.REPORTTORECEVESTATE


                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public VQIJULINGQU1 Get(string id)
        {
            VQIJULINGQU1 item = m_BLL.GetById(id);
            return item;
        }
  

        IBLL.IVQIJULINGQU1BLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VQIJULINGQU1ApiController()
            : this(new VQIJULINGQU1BLL()) { }

        public VQIJULINGQU1ApiController(VQIJULINGQU1BLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


