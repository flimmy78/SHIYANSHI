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
