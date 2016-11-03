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
    /// 报告器具领取详情
    /// </summary>
    public class VXIANGQINGApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<VXIANGQING> queryData = m_BLL.GetByParam(getParam.id, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,DD = s.DD
					,ORDER_TASK_INFORMATIONID = s.ORDER_TASK_INFORMATIONID
					,APPLIANCE_NAME = s.APPLIANCE_NAME
					,STATE = s.STATE
					,RECEIVEINS = s.RECEIVEINS
					,CREATEPERSON = s.CREATEPERSON
					,CREATETIME = s.CREATETIME
					

                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public VXIANGQING Get(string id)
        {
            VXIANGQING item = m_BLL.GetById(id);
            return item;
        }
  

        IBLL.IVXIANGQINGBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VXIANGQINGApiController()
            : this(new VXIANGQINGBLL()) { }

        public VXIANGQINGApiController(VXIANGQINGBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


