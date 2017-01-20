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
            /*
  <option value="5720A交流电流测量">5720A交流电流测量</option>
                            <option value="5720A交流电压测量单相">5720A交流电压测量单相</option>
                            <option value="5720A交流电压测量三相">5720A交流电压测量三相</option>
                            <option value="5720A直流电流测量">5720A直流电流测量</option>
                            <option value="5720A直流电压测量">5720A直流电压测量</option>
                            <option value="5720A直流电阻输出">5720A直流电阻输出</option>
                            <option value="8508A交流电流输出">85080A交流电流输出</option>
                            <option value="8508A交流电压变换器">8508A交流电压变换器</option>
                            <option value="8508A交流电压输出">8508A交流电压输出</option>
                            <option value="8508A直流电流输出">8508A直流电流输出</option>
                            <option value="8508A直流电压输出">8508A直流电压输出</option>
                            <option value="8508A直流电阻测量">8508A直流电阻测量</option>

*/
            jihe = new List<BuQueDingDu>();
            jihe.Add(new BuQueDingDu() { RuleID = "315-1983_2_4", GongShi = "2", MingChen = "5720A直流电压测量", DianZu="N", ShuChu = "N" });
            jihe.Add(new BuQueDingDu() { RuleID = "d315-1983_2_4", GongShi = "2", MingChen = "5720A直流电压测量", DianZu = "N", ShuChu = "N" });

            jihe.Add(new BuQueDingDu() { RuleID = "598-1989_2_2", GongShi = "2", MingChen = "5720A直流电流测量", DianZu = "N", ShuChu = "N" });
            jihe.Add(new BuQueDingDu() { RuleID = "d598-1989_2_2", GongShi = "2", MingChen = "5720A直流电流测量", DianZu = "N", ShuChu = "N" });

            jihe.Add(new BuQueDingDu() { RuleID = "315-1983_2_5", GongShi = "2", MingChen = "5720A直流电压测量", DianZu = "N", ShuChu = "N" });
            jihe.Add(new BuQueDingDu() { RuleID = "598-1989_2_6", GongShi = "2", MingChen = "5720A直流电流测量", DianZu = "N", ShuChu = "N" });
            jihe.Add(new BuQueDingDu() { RuleID = "315-1983_2_2", GongShi = "2", MingChen = "5720A直流电压测量", DianZu = "N", ShuChu = "N" });
            jihe.Add(new BuQueDingDu() { RuleID = "598-1989_2_4", GongShi = "2", MingChen = "5720A直流电流测量", DianZu = "N", ShuChu = "N" });

            jihe.Add(new BuQueDingDu() { RuleID = "445-1986_2_1", GongShi = "9", MingChen = "8508A直流电压输出", DianZu = "N", ShuChu = "Y" });
            jihe.Add(new BuQueDingDu() { RuleID = "d445-1986_2_1", GongShi = "9", MingChen = "8508A直流电压输出", DianZu = "N", ShuChu = "Y" });

            jihe.Add(new BuQueDingDu() { RuleID = "724-1991_2_1", GongShi = "5", MingChen = "5720A直流电阻测量", DianZu = "N", ShuChu = "N" });
            jihe.Add(new BuQueDingDu() { RuleID = "724-1991_2_2", GongShi = "5", MingChen = "5720A直流电阻测量", DianZu = "N", ShuChu = "N" });
            jihe.Add(new BuQueDingDu() { RuleID = "724-1991_2_3", GongShi = "9", MingChen = "8508A直流电阻输出", DianZu = "N", ShuChu = "N" });
            jihe.Add(new BuQueDingDu() { RuleID = "445-1986_2_2", GongShi = "9", MingChen = "8508A直流电压输出", DianZu = "N", ShuChu = "Y" });
            jihe.Add(new BuQueDingDu() { RuleID = "724-1991_2_4", GongShi = "9", MingChen = "8508A直流电阻输出", DianZu = "N", ShuChu = "N" });

            jihe.Add(new BuQueDingDu() { RuleID = "34-1999_3_2", GongShi = "2", MingChen = "5720A交流电压测量三相", DianZu = "N", ShuChu = "N" });
            jihe.Add(new BuQueDingDu() { RuleID = "d34-1999_3_2", GongShi = "2", MingChen = "5720A交流电压测量单相", DianZu = "N", ShuChu = "N" });

            jihe.Add(new BuQueDingDu() { RuleID = "35-1999_3_2", GongShi = "2", MingChen = "5720A交流电流测量", DianZu = "N", ShuChu = "N" });
            jihe.Add(new BuQueDingDu() { RuleID = "d35-1999_3_2", GongShi = "2", MingChen = "5720A交流电流测量", DianZu = "N", ShuChu = "N" });

            jihe.Add(new BuQueDingDu() { RuleID = "34-1999_3_7", GongShi = "2", MingChen = "5720A交流电压测量单相", DianZu = "N", ShuChu = "N" });
            jihe.Add(new BuQueDingDu() { RuleID = "35-1999_3_7", GongShi = "2", MingChen = "5720A交流电流测量", DianZu = "N", ShuChu = "N" });

            jihe.Add(new BuQueDingDu() { RuleID = "410-1994_6_3", GongShi = "9", MingChen = "8508A交流电压输出", DianZu = "N", ShuChu = "Y" });
            jihe.Add(new BuQueDingDu() { RuleID = "410-1994_6_4", GongShi = "9", MingChen = "8508A交流电压输出", DianZu = "N", ShuChu = "Y" });



            jihe.Add(new BuQueDingDu() { RuleID = "38-1987_2_1", GongShi = "9", MingChen = "8508A直流电流输出", DianZu = "N", ShuChu = "Y" });
            jihe.Add(new BuQueDingDu() { RuleID = "38-1987_2_1", GongShi = "8", MingChen = "8508A直流电压输出", DianZu = "Y", ShuChu = "Y" });
            jihe.Add(new BuQueDingDu() { RuleID = "d38-1987_2_1", GongShi = "9", MingChen = "8508A直流电流输出", DianZu = "N", ShuChu = "Y" });
            jihe.Add(new BuQueDingDu() { RuleID = "d38-1987_2_1", GongShi = "8", MingChen = "8508A直流电压输出", DianZu = "Y", ShuChu = "Y" });

            jihe.Add(new BuQueDingDu() { RuleID = "38-1987_2_2", GongShi = "9", MingChen = "8508A直流电流输出", DianZu = "N", ShuChu = "Y" });
            jihe.Add(new BuQueDingDu() { RuleID = "38-1987_2_2", GongShi = "8", MingChen = "8508A直流电压输出", DianZu = "Y", ShuChu = "Y" });


            jihe.Add(new BuQueDingDu() { RuleID = "51-1999_3_3", GongShi = "9", MingChen = "8508A交流电流输出", DianZu = "N", ShuChu = "Y" });
            jihe.Add(new BuQueDingDu() { RuleID = "51-1999_3_3", GongShi = "6", MingChen = "8508A交流电压", DianZu = "Y", ShuChu = "Y" });

            jihe.Add(new BuQueDingDu() { RuleID = "51-1999_3_4", GongShi = "9", MingChen = "8508A交流电流输出", DianZu = "N", ShuChu = "Y" });
            jihe.Add(new BuQueDingDu() { RuleID = "51-1999_3_4", GongShi = "6", MingChen = "8508A交流电压", DianZu = "Y", ShuChu = "Y" });

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
        /// <summary>
        ///源
        /// </summary>
        public string ShuChu { get; set; }

    }
}
