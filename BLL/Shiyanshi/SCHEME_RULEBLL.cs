using Langben.DAL.shiyanshi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    public partial class SCHEME_RULEBLL : IBLL.ISCHEME_RULEBLL, IDisposable
    {
        /// <summary>
        /// 根据方案ID获取检查项
        /// </summary>        
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public List<DAL.SCHEME_RULE> GetModelBySCHEMEID(string SCHEMEID)
        {
            List<DAL.SCHEME_RULE> result = null;
            StringBuilder sb = new StringBuilder();            
            sb.AppendFormat("SCHEMEID{0}&{1}^", ArgEnums.DDL_String, SCHEMEID);
            if (sb.ToString().Trim() != "")
            {
                sb = sb.Remove(sb.ToString().Length - 1, 1);
                result = repository.GetData(db, "desc", "CreateTime", sb.ToString()).ToList();
            }            
            return result;
        }
        /// <summary>
        /// 根据方案ID获取检查项ID（多个用,1,2,分割）
        /// </summary>        
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public string GetRuleIDsBySCHEMEID(string SCHEMEID)
        {
            StringBuilder sb = new StringBuilder();
            List<DAL.SCHEME_RULE> list = GetModelBySCHEMEID(SCHEMEID);
            if(list!=null && list.Count>=0)
            {
                foreach(DAL.SCHEME_RULE item in list)
                {
                    sb.Append(","+item.RULEID + ",");
                }
            }            
            return sb.ToString();
        }
    }
}
