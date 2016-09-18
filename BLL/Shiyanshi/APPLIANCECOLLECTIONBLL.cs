using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;

namespace Langben.BLL
{
    /// <summary>
    /// 器具领取 
    /// </summary>
    public partial class APPLIANCECOLLECTIONBLL :  IBLL.IAPPLIANCECOLLECTIONBLL, IDisposable
    {
        /// <summary>
        ///  根据APPLIANCE_DETAIL_INFORMATIONID,实验室名，领取人，获取所有器具领取数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public bool GetByRefAPPLIANCE_DETAIL_INFORMATIONID_NAME(string id, string CREATEPERSON, string LABORATORY)
        {
            return repository.GetByRefAPPLIANCE_DETAIL_INFORMATIONID_NAME(db, id, CREATEPERSON, LABORATORY);                      
        }    
    }
}

