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
    public interface IVRULEBLL
    {
        /// <summary>
        /// 根据方案ID获取检测项信息
        /// </summary>        
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns>
        [OperationContract]
        List<VRULE> GetBySCHEMEID(string SCHEMEID);
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
        List<VRULE> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total);

        /// <summary>
        /// 通过主键id，检测项目
        /// </summary>
        /// <param name="RULEID">主键</param>
        /// <returns>通过主键id，检测项目</returns>
        [OperationContract]
        VRULE GetById(string RULEID);
    }
}
