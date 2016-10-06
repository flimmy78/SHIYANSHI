using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 预备方案检测项信息 接口
    /// </summary>
    [ServiceContract(Namespace = "www.langben.com")]
    public interface IVTEST_ITEBLL
    {
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        [OperationContract]
        List<VTEST_ITE> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total);
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        System.Collections.Generic.List<VTEST_ITE> GetAll();
        /// <summary>
        /// 通过预备方案ID,检测项ID，获取预备方案检测项信息---查看详细，首次编辑
        /// </summary>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <param name="RULEID">检测项ID</param>
        /// <returns>预备方案检测项信息</returns>
        [OperationContract]
        VTEST_ITE GetById(string PREPARE_SCHEMEID = "", string RULEID = "");
        /// <summary>
        /// 根据预备方案ID获取检测项信息
        /// </summary>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <returns></returns>
        [OperationContract]
        List<VTEST_ITE> GetByPREPARE_SCHEMEID(string PREPARE_SCHEMEID="");
    }
        
}

