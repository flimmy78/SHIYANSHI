using Langben.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Langben.BLL;
namespace Langben.BLL.Report
{
    /// <summary>
    /// 自动计算不确定度公式
    /// </summary>
    public class BuQueDingBuGongShi
    {
        /// <summary>
        /// 获取计算不确定度UNCERTAINTYTABLE
        /// </summary>
        /// <param name="ID">不确定组ID</param>
        /// <param name="ShuChuShiJiZhi">输出实际值、显示值</param>
        /// <param name="ShuChuShiJiZhiDanWei">输出实际值单位、显示值单位</param>
        /// <param name="LiangCheng">量程</param>
        /// <param name="K"></param>
        /// <param name="XuanYongDianZu">选用电阻</param>
        /// <returns></returns>
        public static string GetBuQueDingDu(string ID, string ShuChuShiJiZhi, string ShuChuShiJiZhiDanWei, string LiangCheng, string K, string XuanYongDianZu)
        {
            UNCERTAINTYTABLEBLL bll = new BLL.UNCERTAINTYTABLEBLL();
            List<UNCERTAINTYTABLE> data = bll.GetByASSESSMENTITEM("METERING_STANDARD_DEVICEID", "", "", "");

            if (!string.IsNullOrWhiteSpace(ShuChuShiJiZhi))
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
