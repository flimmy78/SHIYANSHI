using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 委托单信息 接口
    /// </summary>
    public partial interface IORDER_TASK_INFORMATIONBLL
    {

        /// <summary>
        /// 编辑一个对象
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个对象</param>
        /// <returns></returns>
        [OperationContract]
        bool EditField(ref Common.ValidationErrors validationErrors, ORDER_TASK_INFORMATION entity);
        [OperationContract]
        bool EditSTATUS(ref ValidationErrors validationErrors, string id, SIGN sign);
        /// <summary>
        /// 获取委托单号
        /// </summary>
        /// <param name="validationErrors"></param>
        /// <param name="id"></param>
        /// <returns>委托单号*编号*年份</returns>
        [OperationContract]
        string GetORDER_NUMBER(ref ValidationErrors validationErrors);
    }


}

