using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 标准装置/计量标准器信息 接口
    /// </summary>
    public partial interface IMETERING_STANDARD_DEVICEBLL
    {
        
        /// <summary>
        /// 创建一个对象
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个对象</param>
        /// <returns></returns>
        [OperationContract]
         bool CreateX(ref Common.ValidationErrors validationErrors, METERING_STANDARD_DEVICE entity); 
         
    }
}

