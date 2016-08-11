using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 
    /// </summary>

    public partial interface IAPPLIANCE_DETAIL_INFORMATIONBLL
    {
        
        string SearchAutoComplete(string id,  string term);
        /// <summary>
        /// 修改对象集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">主键的集合</param>
        /// <param name="shiyanshi">实验室</param>
        /// <returns></returns>       
        [OperationContract]
        bool EditCollection(ref Common.ValidationErrors validationErrors, string[] deleteCollection, string shiyanshi);
    }
}

