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
    /// 标准量传部工作信息查询
    /// </summary>
    public class VBIAOZHUNLIANGCHUANGONGZHUOApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<VBIAOZHUNLIANGCHUANGONGZHUO> queryData = m_BLL.GetByParam(getParam.id, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
					,WEITUODANWEI = s.WEITUODANWEI
					,SUOSHUDANWEI = s.SUOSHUDANWEI
					,ZHENGSHUDANWEI = s.ZHENGSHUDANWEI
					,SONGJIANDANWEI = s.SONGJIANDANWEI
					,SHOULIDANWEI = s.SHOULIDANWEI
					,CHUCHANGRIQI = s.CHUCHANGRIQI
					,QIJUMINGCHENG = s.QIJUMINGCHENG
					,SHENGCHANCHANGJIA = s.SHENGCHANCHANGJIA
					,QIJUXINGHAO = s.QIJUXINGHAO
					,QIJUGUIGE = s.QIJUGUIGE
					,CHUCHANGBIANHAO = s.CHUCHANGBIANHAO
					,SHULIANG = s.SHULIANG
					,SONGJIANRIQI = s.SONGJIANRIQI
					,SONGJIANREN = s.SONGJIANREN
					,JIESHOUREN = s.JIESHOUREN
					,SHIYANSHI = s.SHIYANSHI
					,SHIYANSHIJIESHOUSHIJIAN = s.SHIYANSHIJIESHOUSHIJIAN
					,JIANDINGRIQI = s.JIANDINGRIQI
					,JIANDINGXIAOZHUNYUAN = s.JIANDINGXIAOZHUNYUAN
					,HEYANYUAN = s.HEYANYUAN
					,ZHENGSHUHAOLEIBIE = s.ZHENGSHUHAOLEIBIE
					,ZHENGSHUBAOGAOBIANHAO = s.ZHENGSHUBAOGAOBIANHAO
					,ZHENGSHULEIBIE = s.ZHENGSHULEIBIE
					,BAOGAOLEIBIE = s.BAOGAOLEIBIE
					,SHOUQUANZIZHI = s.SHOUQUANZIZHI
					,QIJUZHUANGTAI = s.QIJUZHUANGTAI
					,YOUXIAOQIZHI = s.YOUXIAOQIZHI
					,BAOGAOSHENPITONGGUORIQI = s.BAOGAOSHENPITONGGUORIQI
					,MOCHONGCHANGSHU = s.MOCHONGCHANGSHU
					,SONGJIANYUEDU = s.SONGJIANYUEDU
					,JIANDINGSHIJIAN = s.JIANDINGSHIJIAN
					,JIANDINGYUEDU = s.JIANDINGYUEDU
					,BAOGAOSHIJIAN = s.BAOGAOSHIJIAN
					,BAOGAOYUEDU = s.BAOGAOYUEDU
					,GONHZUOSHIJIAN = s.GONHZUOSHIJIAN
					,ZONGSHIJIAN = s.ZONGSHIJIAN
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
        public VBIAOZHUNLIANGCHUANGONGZHUO Get(string id)
        {
            VBIAOZHUNLIANGCHUANGONGZHUO item = m_BLL.GetById(id);
            return item;
        }
  

        IBLL.IVBIAOZHUNLIANGCHUANGONGZHUOBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public VBIAOZHUNLIANGCHUANGONGZHUOApiController()
            : this(new VBIAOZHUNLIANGCHUANGONGZHUOBLL()) { }

        public VBIAOZHUNLIANGCHUANGONGZHUOApiController(VBIAOZHUNLIANGCHUANGONGZHUOBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


