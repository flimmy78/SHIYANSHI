using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 委托单状态
    /// </summary>
    public enum ORDER_STATUS_INFORMATION
    {
        /// <summary>
        /// 器具登记分配好实验室后
        /// </summary>
        已分配=4001,
        /// <summary>
        /// 退回功能选择退回到器具登记
        /// </summary>
        有退回=4002,
        /// <summary>
        /// 器具和报告都领取后
        /// </summary>
        已归档=4003
    }
    /// <summary>
    /// 器具状态
    /// </summary>
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
        器具已领取 = 1043,

    }

    /// <summary>
    /// 报告状态
    /// </summary>
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
        报告已领取 = 1120
    }

    /// <summary>
    /// 报告是上传还是系统生成
    /// </summary>
    public enum PACKAGETYPE
    {
        /// <summary>
        /// 报告通过上传点击上传按钮时记录
        /// </summary>
        上传 = 1011,
        /// <summary>
        /// 报告通过系统生成的
        /// </summary>
        生成 = 1022,
        /// <summary>
        /// 上传成功后附件表状态为已上传
        /// </summary>
        已上传=1033

    }
    /// <summary>
    /// 实验室
    /// </summary>
    public enum LABORATORYNAME
    {
        数表三相 = 60001,
        数表单相 = 60002,
        电能 = 60003,
        指示仪表 = 60004,
        直流仪器 = 60005,
        互感器 = 60006
    }

    /// <summary>
    /// 是否领取
    /// </summary>
    public enum ISRECEIVE
    {
        是=1050,
        否=1060
    }
}
