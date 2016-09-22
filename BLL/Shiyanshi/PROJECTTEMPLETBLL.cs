using Langben.DAL.shiyanshi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    /// <summary>
    /// 检定项目模板
    /// </summary>
    public partial class PROJECTTEMPLETBLL : IBLL.IPROJECTTEMPLETBLL, IDisposable
    {
       /// <summary>
       /// 根据检查项及方案获取检定项目模板
       /// </summary>
       /// <param name="RULEID"></param>
       /// <param name="SCHEMEID"></param>
       /// <returns></returns>
        public DAL.PROJECTTEMPLET GetModelByRULEID_SCHEMEID(string RULEID, string SCHEMEID)
        {
            DAL.PROJECTTEMPLET result = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("RULEID{0}&{1}^", ArgEnums.DDL_String, RULEID);
            sb.AppendFormat("SCHEMEID{0}&{1}^", ArgEnums.DDL_String, SCHEMEID);
            if (sb.ToString().Trim() != "")
            {
                sb = sb.Remove(sb.ToString().Length - 1, 1);
                List<DAL.PROJECTTEMPLET> list = repository.GetData(db, "desc", "CreateTime", sb.ToString()).ToList();
                if (list == null || list.Count == 0)
                {
                    result = null;
                }
                else
                {
                    result = list[0];
                }

            }
            else
            {
                result = null;
            }
            return result;

        }
    }
}
