using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL.Report
{
    /// <summary>
    /// 自动计算不确定度公式
    /// </summary>
    public class BuQueDingBuGongShi
    {
        /// <summary>
        /// 获取不确定度值集
        /// </summary>
        /// <param name="RuleName">检测项名称</param>
        /// <param name="paras">请求参数</param>
        /// <returns></returns>
        public static List<BuQueDingDuOut> GetBuQueDingDu(string RuleName,List<BuQueDingBuInput> paras)
        {
            List<BuQueDingDuOut> result = new List<BuQueDingDuOut>();
            #region  返回测试数据，未真实实现
            if(paras!=null && paras.Count>0)
            {
                int i = 0;
                foreach(BuQueDingBuInput p in paras)
                {
                    BuQueDingDuOut item = new Report.BuQueDingDuOut();
                    item.ID = p.ID;
                    item.Value = i.ToString();
                    result.Add(item);
                    i++;
                }
            }
            #endregion 
            return result;
        }
    }
    /// <summary>
    /// 不确定度返回对象
    /// </summary>
    public class BuQueDingDuOut
    {
        /// <summary>
        /// 对应的不确定度控件ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///不确定度值
        /// </summary>
        public string Value { get; set; }
    }
    /// <summary>
    /// 自动计算不确定公式请求参数
    /// </summary>
    public class BuQueDingBuInput
    {
        /// <summary>
        /// 检测项名称
        /// </summary>
        public string RuleName { get; set; }
        /// <summary>
        /// 对应的不确定度控件ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 输出实际值、显示值
        /// </summary>
        public string ShuChuShiJiZhi { get; set; }
        /// <summary>
        /// 输出实际值单位、显示值单位
        /// </summary>
        public string ShuChuShiJiZhiDanWei { get; set; }
        /// <summary>
        /// 量程
        /// </summary>
        public string LiangCheng { get; set; }
        /// <summary>
        /// K值
        /// </summary>
        public string K { get; set; }
        /// <summary>
        /// 选用电阻
        /// </summary>
        public string XuanYongDianZu { get; set; }
    }
}
