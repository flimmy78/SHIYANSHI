using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 预备方案 接口
    /// </summary>
    public partial interface IPREPARE_SCHEMEBLL
    {
        /// <summary>
        /// 获取证书编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        string GetSerialNumber(string id);
        /// <summary>
        /// 修改编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        bool UPTSerialNumber(string id);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        bool EditField(ref Common.ValidationErrors validationErrors, PREPARE_SCHEME entity);
    }
}

