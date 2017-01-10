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
    /// 自动计算不确定公式请求参数
    /// </summary>
    public partial class BuQueDingBuInput
    {
        /// <summary>
        /// 检测项ID
        /// </summary>
        public string RuleID { get; set; }
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

        /// <summary>
        /// 输出示值、标准值
        /// </summary>
        public string ShuChuShiZhi { get; set; }
        /// <summary>
        /// 频率
        /// </summary>
        public string PinLv { get; set; }

    }

}
