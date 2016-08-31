using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    //器具状态
    public enum ORDER_STATUS
    {
        /// <summary>
        /// 器具登记完成时
        /// </summary>
        已分配 = 1010,
        /// <summary>
        /// 器具检定退回到器具登记时
        /// </summary>
        已退回 = 1015,
        /// <summary>
        /// 点击领取按钮时
        /// </summary>
        已领取 = 1020,
        /// <summary>
        /// 审核完成时
        /// </summary>
        试验完成 = 1040,
        /// <summary>
        /// 批准同意后在没有其余实验室要做实验时器具状态改为待入库
        /// </summary>
        待入库 = 1041,
        /// <summary>
        /// 点击入库按钮时
        /// </summary>
        器具已入库 = 1042,
        /// <summary>
        /// 器具领取环节
        /// </summary>
        器具已返还 = 1043,

    }

    //报告状态
    public enum REPORTSTATUS
    {
        /// <summary>
        /// 器具检定完成发往审核时
        /// </summary>
        待审核 = 1060,
        /// <summary>
        /// 审核不同意时
        /// </summary>
        审核驳回 = 1065,
        /// <summary>
        /// 审核通过发往审批时
        /// </summary>
        待批准 = 1070,
        /// <summary>
        /// 批准不同意时
        /// </summary>
        批准驳回 = 1071,
        /// <summary>
        /// 批准同意时
        /// </summary>
        已批准 = 1072,        
        /// <summary>
        /// 报告打印环节
        /// </summary>
        报告已打印 = 1110,
        /// <summary>
        /// 报告领取环节
        /// </summary>
        报告已发放 = 1120
    }
}
