using System.Collections.Generic;
using System.Linq;
using System;
using Langben.DAL;
using Langben.IBLL;
namespace Langben.BLL
{
    public class SysCOMPANY : IDisposable, ICOMPANYHander
    {
        protected SysEntities db = new SysEntities();
     
        /// <summary>
        /// 获取下拉框的数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="colum">列明</param>
        /// <returns></returns>
        public List<COMPANY> GetCOMPANY()
        {

            return (from m in db.COMPANY
                    //where m.CATEGORY == CATEGORY
                    // orderby m.Sort
                    select m).ToList();

        }
    
        public void Dispose()
        {
            db.Dispose();
        }
    }
}



