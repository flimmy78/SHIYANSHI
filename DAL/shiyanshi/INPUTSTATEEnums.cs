using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.DAL.shiyanshi
{
    /// <summary>
    /// 录入格式
    /// </summary>
    public enum INPUTSTATEEnums
    {       
        /// <summary>
        /// 合格不合格  
        /// </summary>
        HGBHG = 0,
        /// <summary>
        /// 单相
        /// </summary>
        DX = 1,
        /// <summary>
        ///非正负极性
        /// </summary>
        FZFJX = 2,
        /// <summary>
        ///正负极性
        /// </summary>
        ZFJX = 3,
        /// <summary>
        /// 文本框
        /// </summary>
        WBK = 4,        

    }
    /// <summary>
    /// 规程
    /// </summary>
    public enum RuleEnums
    {
        /// <summary>
        /// JJG 598-1989 直流数字电流表检定规程
        /// </summary>
        ZLDL = 0,
    }

}
