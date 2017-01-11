using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Langben.DAL;
using Langben.BLL;

namespace Langben.BLL.Report
{
    /// <summary>
    /// 自动计算不确定度公式
    /// </summary>
    public partial class BuQueDingBuGongShi
    {
        /// <summary>
        /// 获取计算不确定度
        /// </summary>
        ///<param name="paras">请求参数对象</param>
        /// <returns></returns>
        public static string GetBuQueDingDu(BuQueDingBuInput paras)
        {

            var buQueDingBuJiHe = new BuQueDingDu();
            if (string.IsNullOrWhiteSpace(paras.XuanYongDianZu))
            {//无电阻
                buQueDingBuJiHe = (from f in BuQueDingBuJiHe.jihe
                                   where f.RuleID == paras.RuleID
                                   select f).First();
            }
            else
            {//有电阻
                buQueDingBuJiHe = (from f in BuQueDingBuJiHe.jihe
                                   where f.RuleID == paras.RuleID && f.DianZu == "Y"
                                   select f).First();
            }

            //获取数据库表
            UNCERTAINTYTABLEBLL bll = new BLL.UNCERTAINTYTABLEBLL();
            List<UNCERTAINTYTABLE> data = bll.GetByASSESSMENTITEM(buQueDingBuJiHe.MingChen);

            GongShi.GetBuQueDingDu(paras, data, buQueDingBuJiHe);

            if (!string.IsNullOrWhiteSpace(paras.ShuChuShiJiZhi))
            {
                return "10.123";
            }
            else
            {
                return "";
            }
        }

    }
}
