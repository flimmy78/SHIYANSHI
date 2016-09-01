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

        string SearchAutoComplete(string id, string term);
        /// <summary>
        /// 修改对象集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">主键的集合</param>
        /// <param name="shiyanshi">实验室</param>
        /// <returns></returns>       
        [OperationContract]
        bool EditCollection(ref Common.ValidationErrors validationErrors, string[] deleteCollection, string shiyanshi);
        /// <summary>
        /// 修改对象集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">主键的集合</param>
        /// <returns></returns>       
        [OperationContract]
        bool EditSTORAGEINSTRUCTI_STATU(ref Common.ValidationErrors validationErrors, string[] deleteCollection);
        /// <summary>
        /// 修改对象（公用）
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">表实体对象</param>
        /// <returns></returns>       
        [OperationContract]
        bool EditField(ref Common.ValidationErrors validationErrors, APPLIANCE_DETAIL_INFORMATION entity);
        /// <summary>
        /// 查找委托单中的受理单位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        string GetByAPPLIANCE_DETAIL_INFORMATIONId(string id);
        /// <summary>
        /// 根据ORDER_TASK_INFORMATIONIDId，获取所有器具明细信息数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        List<APPLIANCE_DETAIL_INFORMATION> GetByRefORDER_TASK_INFORMATIONID(string id);
    }
}

