using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 器具明细信息
    /// </summary>
    public partial class APPLIANCE_DETAIL_INFORMATIONRepository 
    {

        /// <summary>
        /// 修改对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="editCollection">主键的集合</param>
        /// <param name="shiyanshi">什么实验室领取的，传实验室名</param>
        public void EditCollection(SysEntities db, string[] editCollection,string shiyanshi)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<APPLIANCE_DETAIL_INFORMATION> collection = from f in db.APPLIANCE_DETAIL_INFORMATION
                    where editCollection.Contains(f.ID)
                    select f;
            foreach (var deleteItem in collection)
            {
                deleteItem.ORDER_STATUS="已领取";
                deleteItem.APPLIANCE_PROGRESS = shiyanshi+"进行实验";
            }
        }

   
    }
}

