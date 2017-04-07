using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 人员
    /// </summary>
    public partial class SysPersonRepository : BaseRepository<SysPerson>, IDisposable
    {
        /// <summary>
        /// 根据Province，获取所有人员数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<SysPerson> GetMyName(SysEntities db, string Province)
        {
            return from c in db.SysPerson
                       // where c.Province == Province
                   select c;
                      
        }    
    }
}

