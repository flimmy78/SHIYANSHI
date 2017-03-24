using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;

namespace Langben.BLL
{
    /// <summary>
    /// 入库 
    /// </summary>
    public partial class VRUKUBLL : IBLL.IVRUKUBLL, IDisposable
    {

        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">升序asc（默认）还是降序desc</param>
        /// <param name="sort">排序字段</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<VRUKU> GetByParamX(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            IQueryable<VRUKU> queryData = null;
            string lingqu = Common.ORDER_STATUS.器具已领取.GetHashCode().ToString();
            if (!string.IsNullOrWhiteSpace(id))
            {
                queryData = repository.GetDataX(db, order, sort, search)
                    .Where(w => w.EQUIPMENT_STATUS_VALUUMN != id && w.EQUIPMENT_STATUS_VALUUMN != lingqu)
                    .Distinct();

            }
            else
            {
                queryData = repository.GetDataX(db, order, sort, search)
                 .Where(w => w.EQUIPMENT_STATUS_VALUUMN != lingqu).Distinct();

            }

            List<VRUKU> collection = new List<VRUKU>();
             string ids = string.Empty;
            int a = queryData.Count;
            foreach (var item in queryData)
            {
                if (string.IsNullOrWhiteSpace(item.ID))
                {
                    continue;
                }
                if (!ids.Contains(item.ID))
                {
                    ids += item.ID + ",";
                    collection.Add(item);
                }
            }
            total = collection.Count;
            if (total > 0)
            {
                if (page <= 1)
                {
                    return collection.Take(rows).OrderByDescending(o => o.ID).ToList();
                }
                else
                {
                    return collection.Skip((page - 1) * rows).Take(rows).OrderByDescending(o => o.ID).ToList();
                }

            }
            return collection;
        }

    }
}

