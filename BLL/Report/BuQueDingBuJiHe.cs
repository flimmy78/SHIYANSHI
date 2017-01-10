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
    public static partial class BuQueDingBuJiHe
    {
        public static List<BuQueDingDu> jihe { get; set; }
        static BuQueDingBuJiHe()
        {
            jihe = new List<BuQueDingDu>();
            jihe.Add(new BuQueDingDu() { RuleID = "1", GongShi = "2", MingChen = "3" , DianZu="Y"});


        }

    }
    /// <summary>
    /// 自动计算不确定公式
    /// </summary>
    public partial class BuQueDingDu
    {
        /// <summary>
        /// 检测项ID
        /// </summary>
        public string RuleID { get; set; }
        /// <summary>
        /// 公式
        /// </summary>
        public string GongShi { get; set; }

        /// <summary>
        /// 数据库存的名称
        /// </summary>
        public string MingChen { get; set; }
        /// <summary>
        ///电阻，如果有Y，无可以不写
        /// </summary>
        public string DianZu { get; set; }

    }
}
