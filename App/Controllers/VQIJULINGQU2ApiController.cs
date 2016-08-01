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
					,APPLIANCE_NAME = s.APPLIANCE_NAME
					,MODEL = s.MODEL
					,FACTORY_NUM = s.FACTORY_NUM
					,NUM = s.NUM
					,ATTACHMENT = s.ATTACHMENT
					,NAME = s.NAME
					,APPLIANCE_RECIVE = s.APPLIANCE_RECIVE
					,REPORTNUMBER = s.REPORTNUMBER
					,REMARKS = s.REMARKS
					,ORDER_NUMBER = s.ORDER_NUMBER
					

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
  

        IBLL.IVQIJULINGQU2BLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VQIJULINGQU2ApiController()
            : this(new VQIJULINGQU2BLL()) { }

        public VQIJULINGQU2ApiController(VQIJULINGQU2BLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


