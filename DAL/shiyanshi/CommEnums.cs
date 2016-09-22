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
        ZLDLSC = 2

    }
}
