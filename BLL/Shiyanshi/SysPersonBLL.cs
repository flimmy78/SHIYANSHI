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
    /// 人员 
    /// </summary>
    public partial  class SysPersonBLL : IBLL.ISysPersonBLL, IDisposable
    {
       
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<SysPerson> GetMyName(ref Common.ValidationErrors validationErrors,string Province)
        { 
            return repository.GetMyName(db, Province).ToList();
        }
    
    }
}

