using System.Collections.Generic;

namespace Langben.Report
{
    /// <summary>
    /// id name value hangshu(合并几行单元格) 通道 量程 行号 第几列
    /// </summary>
    public class BuDueDingDu
    {
        public BuDueDingDu()
        {
            buDueDingDuB = new List<BuDueDingDuB>();
            pingding = new List<MYData>();
        }

        public List<BuDueDingDuB> buDueDingDuB { get; set; }
        public List<MYData> pingding { get; set; }

        /// <summary>
        /// 不确定度的评定 下拉框
        /// </summary>
        public string pdDDL { get; set; }
        /// <summary>
        /// 不确定度的评定 输入
        /// </summary>
        public string pdText { get; set; }
        /// <summary>
        /// （1）不确定度的A类评定 UA
        /// </summary>
        public string txtBuQueDingA { get; set; }
        /// <summary>
        /// （1）不确定度的A类评定 UA
        /// </summary>
        public string txtValue { get; set; }
        public string A_1_1 { get; set; }
        public string A_1_2 { get; set; }
        public string A_1_3 { get; set; }
        public string A_1_4 { get; set; }
        public string A_1_5 { get; set; }
        public string A_2_1 { get; set; }
        public string A_2_2 { get; set; }
        public string A_2_3 { get; set; }
        public string A_2_4 { get; set; }
        public string A_2_5 { get; set; }
        /// <summary>
        /// 不确定度的B类评定 UB
        /// </summary>
        public string txtBuQueDingB { get; set; }
        /// <summary>
        /// 不确定度的B类评定 UB
        /// </summary>
        public string txtValueB { get; set; }
        /// <summary>
        /// 合成不确定度评定 Uc 
        /// </summary>
        public string txtBuQueDingC { get; set; }
        /// <summary>
        /// 合成不确定度评定 k
        /// </summary>
        public string ddlSelectD { get; set; }
        /// <summary>
        /// 合成不确定度评定 Urel 
        /// </summary>
        public string txtvalueD { get; set; }
        /// <summary>
        /// 测量结果报告 ,扩展不确定度为
        /// </summary>
        public string txtValueE { get; set; }
        /// <summary>
        /// 合并几行单元格
        /// </summary>
        public int mergedRowNum { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public int rowNum { get; set; }
        /// <summary>
        /// 第几列
        /// </summary>
        public int columnNum { get; set; }
    }
}
