using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 器具明细信息_承接实验室 接口
    /// </summary>
    public partial interface IAPPLIANCE_LABORATORYBLL
    {
       /// <summary>
       /// 修改（公用）
       /// </summary>
       /// <param name="validationErrors"></param>
       /// <param name="entity"></param>
       /// <returns></returns>
        [OperationContract]
        bool EditField(ref Common.ValidationErrors validationErrors, APPLIANCE_LABORATORY entity); 
    
    }
}

