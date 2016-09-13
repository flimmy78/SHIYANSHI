using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.DAL.shiyanshi
{
    /// <summary>
    /// 公共数据字典
    /// </summary>
    public class CommDic
    {
        /// <summary>
        /// 规程数据字典
        /// </summary>
        public static Dictionary<string, string> RuleDic
        {
            get
            {
                Dictionary<string, string> _RuleDic = new Dictionary<string, string>();
                _RuleDic.Add("38-1987", "JJG(航天) 38-1987 直流标准电流源检定规程");
                return _RuleDic;
            }
        }
    }
}
