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
    /// 不合格统计分析
    /// </summary>
    public class VBUHEGEApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<VBUHEGE> queryData = m_BLL.GetByParam(getParam.id, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,ZHENGSHUBAOGAOBIANHAO = s.ZHENGSHUBAOGAOBIANHAO
					,BUHEGEFENLEI = s.BUHEGEFENLEI
					,BUHEGESHUOMING = s.BUHEGESHUOMING
					,SHIYANSHI = s.SHIYANSHI
					,BAOGAOPIZHUNTONGGUOSHIJIAN = s.BAOGAOPIZHUNTONGGUOSHIJIAN
					,SHOULIDANWEI = s.SHOULIDANWEI
					

                })
            };
            return data;
        }

  
        IBLL.IVBUHEGEBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VBUHEGEApiController()
            : this(new VBUHEGEBLL()) { }

        public VBUHEGEApiController(VBUHEGEBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


