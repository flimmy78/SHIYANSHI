using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 器具明细信息_承接实验室
    /// </summary>
    public partial class APPLIANCE_LABORATORYRepository : BaseRepository<APPLIANCE_LABORATORY>, IDisposable
    {
        /// <summary>
        /// 修改对象(公用)
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">表的实体类</param>
        public void EditField(SysEntities db, APPLIANCE_LABORATORY entity)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<APPLIANCE_LABORATORY> collection = from f in db.APPLIANCE_LABORATORY
                                                          where f.ID == entity.ID
                                                                  select f;

            //db.APPLIANCE_DETAIL_INFORMATION.Attach(entity);
            //db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            //int i = db.SaveChanges();
            foreach (var deleteItem in collection)
            {
                deleteItem.UNDERTAKE_LABORATORYID = entity.UNDERTAKE_LABORATORYID == null ? deleteItem.UNDERTAKE_LABORATORYID : entity.UNDERTAKE_LABORATORYID;
                deleteItem.APPLIANCE_DETAIL_INFORMATIONID = entity.APPLIANCE_DETAIL_INFORMATIONID == null ? deleteItem.APPLIANCE_DETAIL_INFORMATIONID : entity.APPLIANCE_DETAIL_INFORMATIONID;
                deleteItem.PREPARE_SCHEMEID = entity.PREPARE_SCHEMEID == null ? deleteItem.PREPARE_SCHEMEID : entity.PREPARE_SCHEMEID;
                deleteItem.RECEIVEPERSON = entity.RECEIVEPERSON == null ? deleteItem.RECEIVEPERSON : entity.RECEIVEPERSON;
                deleteItem.RECEIVETIME = entity.RECEIVETIME == null ? deleteItem.RECEIVETIME : entity.RECEIVETIME;
                deleteItem.BACKPERSON = entity.BACKPERSON == null ? deleteItem.BACKPERSON : entity.BACKPERSON;
                deleteItem.BACKTIME = entity.BACKTIME == null ? deleteItem.BACKTIME : entity.BACKTIME;
                deleteItem.DISTRIBUTIONPERSON = entity.DISTRIBUTIONPERSON == null ? deleteItem.DISTRIBUTIONPERSON : entity.DISTRIBUTIONPERSON;
                deleteItem.DISTRIBUTIONTIME = entity.DISTRIBUTIONTIME == null ? deleteItem.DISTRIBUTIONTIME : entity.DISTRIBUTIONTIME;
                deleteItem.CREATEPERSON = entity.CREATEPERSON == null ? deleteItem.CREATEPERSON : entity.CREATEPERSON;
                deleteItem.ORDER_STATUS = entity.ORDER_STATUS == null ? deleteItem.ORDER_STATUS : entity.ORDER_STATUS;
                deleteItem.EQUIPMENT_STATUS_VALUUMN = entity.EQUIPMENT_STATUS_VALUUMN == null ? deleteItem.EQUIPMENT_STATUS_VALUUMN : entity.EQUIPMENT_STATUS_VALUUMN;
                deleteItem.RETURN_INSTRUCTIONS = entity.RETURN_INSTRUCTIONS == null ? deleteItem.RETURN_INSTRUCTIONS : entity.RETURN_INSTRUCTIONS;
                deleteItem.ISRECEIVE = entity.ISRECEIVE == null ? deleteItem.ISRECEIVE : entity.ISRECEIVE;
            }
        }        
        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="editCollection">主键的集合</param>
        /// <param name="shiyanshi">什么实验室领取的，传实验室名</param>
        public void EditSTORAGEINSTRUCTI_STATU(SysEntities db, string[] editCollection)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<APPLIANCE_LABORATORY> collection = from f in db.APPLIANCE_LABORATORY
                                                          where editCollection.Contains(f.APPLIANCE_DETAIL_INFORMATIONID)
                                                          select f;
            foreach (var deleteItem in collection)
            {
                deleteItem.ORDER_STATUS = Common.ORDER_STATUS.器具已入库.ToString();
                deleteItem.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.器具已入库.GetHashCode().ToString();
            }
        }
    }
}

