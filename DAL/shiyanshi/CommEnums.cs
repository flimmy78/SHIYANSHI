using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 公共枚举
/// </summary>
namespace Langben.DAL.shiyanshi
{

    /// <summary>
    /// 查询参数枚举，查询参数例如：State+ArgEnums.DDL_String&开启^AccountID+ArgEnums.DDL_String&test
    /// </summary>
    public enum ArgEnums
    {
        /// <summary>
        /// 开始时间的标识
        /// </summary>            
        Start_Time = 0,
        /// <summary>
        /// 结束时间的标识
        /// </summary>
        End_Time = 1,
        /// <summary>
        /// 开始数值的标识
        /// </summary>
        Start_Int = 2,
        /// <summary>
        /// 结束数值的标识
        /// </summary>
        End_Int = 3,
        /// <summary>
        /// 精确字符串
        /// </summary>
        DDL_String = 4,
        /// <summary>
        /// 精确数字
        /// </summary>
        DDL_Int = 5,

    }
    /// <summary>
    /// 录入格式
    /// </summary>
    public enum InputStateEnums
    { 
        /// <summary>
        /// 合格不合格  
        /// </summary>
        HGBHG = 0,        
        /// <summary>
        /// 文本框
        /// </summary>
        WBK = 1,
        /// <summary>
        /// 直流电流输出
        /// </summary>
        ZhiLiuDianLiuShuChu = 2

    }

    /// <summary>
    /// 证书类别
    /// </summary>
    public enum  ZhengShuLeiBieEnums
    {
        检定=0,
        校准=1
    }
    /// <summary>
    /// 是否是CNAS
    /// </summary>
    public enum ShiFouCNAS
    {
        No = 0,
        Yes = 1
    }
    /// <summary>
    /// 规则标识
    /// </summary>
    public enum RuleFlag
    {
        开始 = 0,
        中间 = 1,
        结束=2
    }
    /// <summary>
    /// 直流电流输出单元格位置设置
    /// </summary>
    public enum ZhiLiuDianLiuShuChuEnum
    {
        /// <summary>
        /// 量程
        /// </summary>
        RANGE = 0,
        /// <summary>
        /// 量程单位
        /// </summary>
        RANGE_UNIT = 2,
        /// <summary>
        /// 选用电阻阻值
        /// </summary>
        RESISTANCE = 3,
        /// <summary>
        /// 输出示值
        /// </summary>
        OUTPUT_VALUE = 7,
        /// <summary>
        /// 输出示值单位
        /// </summary>
        OUTPUT_VALUE_UNIT = 11,
        /// <summary>
        /// 读数值
        /// </summary>
        READ_VALUE = 12,
        /// <summary>
        /// 读数值单位
        /// </summary>
        READ_VALUE_UNIT = 16,
        /// <summary>
        /// 输出实际值
        /// </summary>
        ACTUAL_OUTPUT_VALUE = 17,
        /// <summary>
        /// 输出实际值单位
        /// </summary>
        ACTUAL_OUTPUT_VALUE_UNIT = 21,
        /// <summary>
        /// 相对误差
        /// </summary>
        RELATIVE_ERROR = 23,
        /// <summary>
        /// 校准结果的不确定度U(k=2)
        /// </summary>
        UNCERTAINTY_DEGREE = 26,
        /// <summary>
        /// 校准结果的不确定度U(k=2)单位
        /// </summary>
        UNCERTAINTY_DEGREE_UNIT = 30          
                  
    }
    /// <summary>
    /// 导出类型
    /// </summary>
    public enum ExportType
    {
        /// <summary>
        /// 检定原始记录
        /// </summary>          
        OriginalRecord_JianDing = 0,
        /// <summary>
        /// 校准原始记录
        /// </summary>          
        OriginalRecord_XiaoZhun = 1,
        /// <summary>
        /// 检定报告
        /// </summary>
        Report_JianDing = 2,
        /// <summary>
        /// 校准报告(非CNAS)
        /// </summary>
        Report_XiaoZhun = 3,
        /// <summary>
        /// 校准报告(CNAS)
        /// </summary>
        Report_XiaoZhun_CNAS = 4

    }
    /// <summary>
    /// 装置类型
    /// </summary>
    public enum CATEGORYType
    {
        /// <summary>
        /// 标准装置
        /// </summary>          
        标准装置 = 0,
        /// <summary>
        /// 标准器
        /// </summary>          
        标准器 = 1,
        /// <summary>
        /// 中间试品
        /// </summary>
        中间试品 = 2
        

    }
    //public enum


}
