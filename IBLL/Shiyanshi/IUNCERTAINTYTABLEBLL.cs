using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 不确定度 接口
    /// </summary>
    public partial interface IUNCERTAINTYTABLEBLL
    {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        bool EditField(ref Common.ValidationErrors validationErrors, UNCERTAINTYTABLE entity);
        /// <summary>
        /// 编辑一个对象
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个对象</param>
        /// <returns></returns>
        [OperationContract]
        bool EditUpdate(ref Common.ValidationErrors validationErrors, METERING_STANDARD_DEVICE entity); 
    
    }
}

