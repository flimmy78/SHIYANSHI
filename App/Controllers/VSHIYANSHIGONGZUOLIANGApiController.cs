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
    /// 实验室别工作量统计分析
    /// </summary>
    public class VSHIYANSHIGONGZUOLIANGApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<SHIYANSHIGONGZUO_Result> queryData = m_BLL.GetByParam(getParam.id, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,WEITUODAN = s.WEITUODAN
					,JIANDINGWANCHENG = s.JIANDINGWANCHENG
					,SHEBEIGUZHANG = s.SHEBEIGUZHANG
					,PIZHUNTONGGUO = s.PIZHUNTONGGUO
					,HEGE = s.HEGE
					,BUHEGE = s.BUHEGE
					,CHAOQI = s.CHAOQI
					

                })
            };
            return data;
        }

  

        IBLL.IVSHIYANSHIGONGZUOLIANGBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VSHIYANSHIGONGZUOLIANGApiController()
            : this(new VSHIYANSHIGONGZUOLIANGBLL()) { }

        public VSHIYANSHIGONGZUOLIANGApiController(VSHIYANSHIGONGZUOLIANGBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


