using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 器具领取 接口
    /// </summary>
    public partial interface IAPPLIANCECOLLECTIONBLL
    {
        /// <summary>
        /// 根据APPLIANCE_DETAIL_INFORMATIONIDId，获取所有器具领取数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
       bool GetByRefAPPLIANCE_DETAIL_INFORMATIONID_NAME(string id, string CREATEPERSON, string LABORATORY);
    }
}

