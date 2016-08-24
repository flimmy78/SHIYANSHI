using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum OrderStatus
    {    
        /// <summary>
        /// 已分配
        /// </summary>
        已分配 = 1010,
        /// <summary>
        /// 已退回
        /// </summary>
        已退回 = 1015,
        /// <summary>
        /// 已领取
        /// </summary>
        已领取 = 1020,
        /// <summary>
        /// 试验中
        /// </summary>
        试验中 = 1030,
        /// <summary>
        /// 试验完成
        /// </summary>
        试验完成 = 1040,
        /// <summary>
        /// 已上传
        /// </summary>
        已上传 = 1050,
        /// <summary>
        /// 已审核
        /// </summary>
        已审核 = 1060,
        /// <summary>
        /// 已批准
        /// </summary>
        已批准 = 1070,
        /// <summary>
        /// 待入库
        /// </summary>
        待入库 = 1075,
        /// <summary>
        /// 器具已入库
        /// </summary>
        器具已入库 = 1080,
        /// <summary>
        /// 器具已返还
        /// </summary>
        器具已返还 = 1090,
        /// <summary>
        /// 报告已打印
        /// </summary>
        报告已打印 = 1110,
        /// <summary>
        /// 报告已发放
        /// </summary>
        报告已发放 = 1120
    }

    public enum ApplianceProgress 
    {
        进行实验,
    }
}
