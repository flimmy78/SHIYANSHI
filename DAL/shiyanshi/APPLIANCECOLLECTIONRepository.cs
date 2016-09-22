using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 器具领取
    /// </summary>
    public partial class APPLIANCECOLLECTIONRepository : BaseRepository<APPLIANCECOLLECTION>, IDisposable
    {

        /// <summary>
        /// 根据APPLIANCE_DETAIL_INFORMATIONID,实验室名，领取人，获取所有器具领取数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public bool GetByRefAPPLIANCE_DETAIL_INFORMATIONID_NAME(SysEntities db, string id, string CREATEPERSON, string LABORATORY)
        {
            IQueryable<APPLIANCECOLLECTION> App = db.APPLIANCECOLLECTION.Where(m => m.APPLIANCE_DETAIL_INFORMATIONID == id && m.CREATEPERSON == CREATEPERSON && m.LABORATORY == LABORATORY);
            int a = App.Count();
            if (a >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

