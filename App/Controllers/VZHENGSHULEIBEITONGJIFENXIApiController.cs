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
    /// 证书类别统计分析
    /// </summary>
    public class VZHENGSHULEIBEITONGJIFENXIApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<VZHENGSHULEIBEITONGJIFENXI> queryData = m_BLL.GetByParam(getParam.id, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,SUOSHUDANWEI = s.SUOSHUDANWEI
					,ZHENGSHUDANWEI = s.ZHENGSHUDANWEI
					,SHOULIDANWEI = s.SHOULIDANWEI
					,PIZHUNJIELUN = s.PIZHUNJIELUN
					,PIZHUNSHIJIAN = s.PIZHUNSHIJIAN
					,SHOUQUANZIZHI = s.SHOUQUANZIZHI
					,
                    ZHEGNSHUBAOGAOLEIBIE = s.ZHEGNSHUBAOGAOLEIBIE
                    ,
                    BAOGAOSHULIANG = s.BAOGAOSHULIANG
					

                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public VZHENGSHULEIBEITONGJIFENXI Get(string id)
        {
            VZHENGSHULEIBEITONGJIFENXI item = m_BLL.GetById(id);
            return item;
        }
  

        IBLL.IVZHENGSHULEIBEITONGJIFENXIBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VZHENGSHULEIBEITONGJIFENXIApiController()
            : this(new VZHENGSHULEIBEITONGJIFENXIBLL()) { }

        public VZHENGSHULEIBEITONGJIFENXIApiController(VZHENGSHULEIBEITONGJIFENXIBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


