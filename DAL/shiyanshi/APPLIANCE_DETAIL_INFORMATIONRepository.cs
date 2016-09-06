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
        public void EditCollection(SysEntities db, string[] editCollection, string shiyanshi)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<APPLIANCE_DETAIL_INFORMATION> collection = from f in db.APPLIANCE_DETAIL_INFORMATION
                                                                  where editCollection.Contains(f.ID)
                                                                  select f;
            foreach (var deleteItem in collection)
            {
                deleteItem.ORDER_STATUS = Common.ORDER_STATUS.已领取.ToString();
                deleteItem.APPLIANCE_PROGRESS = shiyanshi;
                deleteItem.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.已领取.GetHashCode().ToString();
            }
        }

        /// <summary>
        /// 修改对象(公用)
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">表的实体类</param>
        public void EditField(SysEntities db, APPLIANCE_DETAIL_INFORMATION entity)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<APPLIANCE_DETAIL_INFORMATION> collection = from f in db.APPLIANCE_DETAIL_INFORMATION
                                                                  where f.ID == entity.ID
                                                                  select f;

            //db.APPLIANCE_DETAIL_INFORMATION.Attach(entity);
            //db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            //int i = db.SaveChanges();
            foreach (var deleteItem in collection)
            {
                deleteItem.BAR_CODE_NUM = entity.BAR_CODE_NUM==null? deleteItem.BAR_CODE_NUM: entity.BAR_CODE_NUM;
                deleteItem.APPLIANCE_NAME = entity.APPLIANCE_NAME == null ? deleteItem.APPLIANCE_NAME : entity.APPLIANCE_NAME;
                deleteItem.VERSION = entity.VERSION == null ? deleteItem.VERSION : entity.VERSION;
                deleteItem.FORMAT = entity.FORMAT == null ? deleteItem.FORMAT : entity.FORMAT;
                deleteItem.FACTORY_NUM = entity.FACTORY_NUM == null ? deleteItem.FACTORY_NUM : entity.FACTORY_NUM;
                deleteItem.NUM = entity.NUM == null ? deleteItem.NUM : entity.NUM;
                deleteItem.ATTACHMENT = entity.ATTACHMENT == null ? deleteItem.ATTACHMENT : entity.ATTACHMENT;
                deleteItem.APPEARANCE_STATUS = entity.APPEARANCE_STATUS == null ? deleteItem.APPEARANCE_STATUS : entity.APPEARANCE_STATUS;
                deleteItem.MAKE_ORGANIZATION = entity.MAKE_ORGANIZATION == null ? deleteItem.MAKE_ORGANIZATION : entity.MAKE_ORGANIZATION;
                deleteItem.REMARKS = entity.REMARKS == null ? deleteItem.REMARKS : entity.REMARKS;
                deleteItem.END_PLAN_DATE = entity.END_PLAN_DATE == null ? deleteItem.END_PLAN_DATE : entity.END_PLAN_DATE;
                deleteItem.ORDER_TASK_INFORMATIONID = entity.ORDER_TASK_INFORMATIONID == null ? deleteItem.ORDER_TASK_INFORMATIONID : entity.ORDER_TASK_INFORMATIONID;
                deleteItem.CREATETIME = entity.CREATETIME == null ? deleteItem.CREATETIME : entity.CREATETIME;
                deleteItem.CREATEPERSON = entity.CREATEPERSON == null ? deleteItem.CREATEPERSON : entity.CREATEPERSON;
                deleteItem.UPDATETIME = entity.UPDATETIME == null ? deleteItem.UPDATETIME : entity.UPDATETIME;
                deleteItem.UPDATEPERSON = entity.UPDATEPERSON == null ? deleteItem.UPDATEPERSON : entity.UPDATEPERSON;
                deleteItem.APPLIANCE_RECIVE = entity.APPLIANCE_RECIVE == null ? deleteItem.APPLIANCE_RECIVE : entity.APPLIANCE_RECIVE;
                deleteItem.APPLIANCE_PROGRESS = entity.APPLIANCE_PROGRESS == null ? deleteItem.APPLIANCE_PROGRESS : entity.APPLIANCE_PROGRESS;
                deleteItem.ORDER_STATUS = entity.ORDER_STATUS == null ? deleteItem.ORDER_STATUS : entity.ORDER_STATUS;
                deleteItem.ISOVERDUE = entity.ISOVERDUE == null ? deleteItem.ISOVERDUE : entity.ISOVERDUE;
                deleteItem.OVERDUE = entity.OVERDUE == null ? deleteItem.OVERDUE : entity.OVERDUE;
                deleteItem.STORAGEINSTRUCTIONS = entity.STORAGEINSTRUCTIONS == null ? deleteItem.STORAGEINSTRUCTIONS : entity.STORAGEINSTRUCTIONS;
                deleteItem.STORAGEINSTRUCTI_STATU = entity.STORAGEINSTRUCTI_STATU == null ? deleteItem.STORAGEINSTRUCTI_STATU : entity.STORAGEINSTRUCTI_STATU;
                deleteItem.EQUIPMENT_STATUS_VALUUMN = entity.EQUIPMENT_STATUS_VALUUMN == null ? deleteItem.EQUIPMENT_STATUS_VALUUMN : entity.EQUIPMENT_STATUS_VALUUMN;
            }
        }

        /// <summary>
        /// 修改对象集合(入库)
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="editCollection">主键的集合</param>
        public void EditSTORAGEINSTRUCTI_STATU(SysEntities db, string[] editCollection)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<APPLIANCE_DETAIL_INFORMATION> collection = from f in db.APPLIANCE_DETAIL_INFORMATION
                                                                  where editCollection.Contains(f.ID)
                                                                  select f;
            foreach (var deleteItem in collection)
            {
                deleteItem.ORDER_STATUS =Common.ORDER_STATUS.器具已入库.ToString();
                deleteItem.EQUIPMENT_STATUS_VALUUMN = Common.ORDER_STATUS.器具已入库.GetHashCode().ToString();
            }
        }
        /// <summary>
        /// 通过器具明细表中的id查找委托单中的受理单位
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>受理单位</returns>
        public string GetByAPPLIANCE_DETAIL_INFORMATIONId(SysEntities db, string id)
        {
            return db.APPLIANCE_DETAIL_INFORMATION.Where(a => a.ID == id).Select(a => a.ORDER_TASK_INFORMATION.ACCEPT_ORGNIZATION).FirstOrDefault();

        }
        /// <summary>
        /// 根据ORDER_TASK_INFORMATIONID，获取所有器具明细信息数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<APPLIANCE_DETAIL_INFORMATION> GetByRefORDER_TASK_INFORMATIONID(SysEntities db, string id)
        {
            return from c in db.APPLIANCE_DETAIL_INFORMATION
                   where c.ORDER_TASK_INFORMATIONID == id
                   select c;

        }
    }
}

