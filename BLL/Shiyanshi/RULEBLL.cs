using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    public partial class RULEBLL : IBLL.IRULEBLL, IDisposable
    {
        /// <summary>
        /// 根据方案ID获取一级检测项目(规程)
        /// </summary>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        public List<DAL.RULE> GetFirstModelBySCHEMEID(string SCHEMEID)
        {

            List<DAL.RULE> result = null;
            result = (
                           from r in db.SCHEME_RULE
                           from p in db.RULE
                           where //r.RULEID.Substring(0, (r.RULEID.Split('_') - 1)) == p.ID &&
                           r.RULEID.Split('_')[0] == p.ID &&
                           r.SCHEMEID == SCHEMEID
                           select p
                           ).Distinct().OrderBy(o => o.SORT).ToList();

            //result = (
            //               from r in db.SCHEME_RULE
            //               where
            //               r.SCHEMEID == SCHEMEID
            //               select r
            //               ).Distinct().OrderBy(o => o.SORT).ToList();

            return result;
        }
    }
}
