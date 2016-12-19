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
    /// 工作时长查询
    /// </summary>
    public class VGONGZUOSHICHANGApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<VGONGZUOSHICHANG> queryData = m_BLL.GetByParam(getParam.id, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,WEITUODANWEI = s.WEITUODANWEI
					,SUOSHUDANWEI = s.SUOSHUDANWEI
					,ZHENGSHUDANWEI = s.ZHENGSHUDANWEI
					,SHOULIDANWEI = s.SHOULIDANWEI
					,QIJUMINGCHENG = s.QIJUMINGCHENG
					,SHENGCHANCHANGJIA = s.SHENGCHANCHANGJIA
					,QIJUXINGHAO = s.QIJUXINGHAO
					,QIJUGUIGE = s.QIJUGUIGE
					,CHUCHANGBIANHAO = s.CHUCHANGBIANHAO
					,SHULIANG = s.SHULIANG
					,ZHENGSHUBAOGAOBIANHAO = s.ZHENGSHUBAOGAOBIANHAO
					,SHIYANSHI = s.SHIYANSHI
					,JIANDINGXIAOZHUNYUAN = s.JIANDINGXIAOZHUNYUAN
					,HEYANYUAN = s.HEYANYUAN
					,WEITUORIQI = s.WEITUORIQI
					,SHIYANSHIJIESHOUSHIJIAN = s.SHIYANSHIJIESHOUSHIJIAN
					,JIANDINGWANCHENGRIQI = s.JIANDINGWANCHENGRIQI
					,SHENHERIQI = s.SHENHERIQI
					,PIZHUNRIQI = s.PIZHUNRIQI
					,DAILINGQUSHICHANG = s.DAILINGQUSHICHANG
					,JIANDINGSHICHANG = s.JIANDINGSHICHANG
					,SHENHESHICHANG = s.SHENHESHICHANG
					,PIZHUNSHICHANG = s.PIZHUNSHICHANG
					,ZONGSHICHANG = s.ZONGSHICHANG
					,BEIZHU = s.BEIZHU
					

                })
            };
            return data;
        }


  

        IBLL.IVGONGZUOSHICHANGBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VGONGZUOSHICHANGApiController()
            : this(new VGONGZUOSHICHANGBLL()) { }

        public VGONGZUOSHICHANGApiController(VGONGZUOSHICHANGBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


