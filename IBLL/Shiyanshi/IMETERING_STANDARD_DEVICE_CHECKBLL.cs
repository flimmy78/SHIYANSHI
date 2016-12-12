using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 计量标准装置检定/校准信息 接口
    /// </summary>

    public partial interface IMETERING_STANDARD_DEVICE_CHECKBLL
    {
        /// <summary>
        /// 修改对象（公用）
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">表实体对象</param>
        /// <returns></returns>       
        [OperationContract]
        bool EditField(ref Common.ValidationErrors validationErrors, METERING_STANDARD_DEVICE_CHECK entity);
        /// <summary>
        /// 修改对象
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">表实体对象</param>
        /// <returns></returns>       
        [OperationContract]
        bool EditUpdate(ref Common.ValidationErrors validationErrors, METERING_STANDARD_DEVICE entity);
    }
}

