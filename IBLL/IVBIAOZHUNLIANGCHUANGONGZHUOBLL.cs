using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 标准量传部工作信息查询 接口
    /// </summary>
    [ServiceContract(Namespace = "www.langben.com")]
    public interface IVBIAOZHUNLIANGCHUANGONGZHUOBLL
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
        List<VBIAOZHUNLIANGCHUANGONGZHUO> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total);
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        System.Collections.Generic.List<VBIAOZHUNLIANGCHUANGONGZHUO> GetAll();
        /// <summary>
        /// 根据主键，查看详细信息
        /// </summary>
        /// <param name="id">根据主键</param>
        /// <returns></returns>
        [OperationContract]
        VBIAOZHUNLIANGCHUANGONGZHUO GetById(string id);    
 
    }
}

