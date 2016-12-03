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
    /// 证书信息查询
    /// </summary>
    public class VZHENGSHUXINXICHAXUNApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<VZHENGSHUXINXICHAXUN> queryData = m_BLL.GetByParam(getParam.id, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,SONGJIANDANWEI = s.SONGJIANDANWEI
					,ZHENGSHUDANWEI = s.ZHENGSHUDANWEI
					,SHOULIDANWEI = s.SHOULIDANWEI
					,CHUCHANGRIQI = s.CHUCHANGRIQI
					,QIJUMINGCHENG = s.QIJUMINGCHENG
					,SHENGCHANCHANGJIA = s.SHENGCHANCHANGJIA
					,QIJUXINGHAO = s.QIJUXINGHAO
					,CHUCHANGBIANHAO = s.CHUCHANGBIANHAO
					,ZHUNQUEDUDENGJI = s.ZHUNQUEDUDENGJI
					,JIANDINGRIQI = s.JIANDINGRIQI
					,WENDU = s.WENDU
					,XIANGDUISHIDU = s.XIANGDUISHIDU
					,MOCHONGCHANGSHU = s.MOCHONGCHANGSHU
					,QIJUGUIGE = s.QIJUGUIGE
					,JIANDINGXIAOZHUNYUAN = s.JIANDINGXIAOZHUNYUAN
					,HEYANYUAN = s.HEYANYUAN
					,YOUXIAOQI = s.YOUXIAOQI
					,YOUXIAOQIZHI = s.YOUXIAOQIZHI
					,ZHENGSHUBAOGAOBIANHAO = s.ZHENGSHUBAOGAOBIANHAO
					,ZHENGSHULEIBIE = s.ZHENGSHULEIBIE
					,BAOGAOLEIBIE = s.BAOGAOLEIBIE
					,SHOUQUANZIZHI = s.SHOUQUANZIZHI
					,FAFANGZHUANGTAI = s.FAFANGZHUANGTAI
					,SUOSHUDANWEI = s.SUOSHUDANWEI
					,WEITUODANWEI = s.WEITUODANWEI
					,BEIZHU = s.BEIZHU
					

                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public VZHENGSHUXINXICHAXUN Get(string id)
        {
            VZHENGSHUXINXICHAXUN item = m_BLL.GetById(id);
            return item;
        }
  

        IBLL.IVZHENGSHUXINXICHAXUNBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VZHENGSHUXINXICHAXUNApiController()
            : this(new VZHENGSHUXINXICHAXUNBLL()) { }

        public VZHENGSHUXINXICHAXUNApiController(VZHENGSHUXINXICHAXUNBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


