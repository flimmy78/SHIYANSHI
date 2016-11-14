using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 最大允许误差信息 接口
    /// </summary>
  
    public partial interface IALLOWABLE_ERRORBLL
    {
        /// <summary>
        /// 修改对象（公用）
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">表实体对象</param>
        /// <returns></returns>       
        [OperationContract]
        bool EditField(ref Common.ValidationErrors validationErrors, ALLOWABLE_ERROR entity);

    }
}

