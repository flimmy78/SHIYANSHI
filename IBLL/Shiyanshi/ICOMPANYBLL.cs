using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 单位 接口
    /// </summary>
    public partial interface ICOMPANYBLL
    {
        /// <summary>
        /// 制造单位下拉框数据绑定
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string Getdate();

        /// <summary>
        /// 送检单位下拉框数据带出
        /// </summary>
        /// <returns></returns>

        COMPANY GetVasedate(string COMPANYNAME);
    }
}

