using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 委托单信息
    /// </summary>
    public partial class ORDER_TASK_INFORMATIONRepository : BaseRepository<ORDER_TASK_INFORMATION>, IDisposable
    {
        /// <summary>
        /// 修改对象(公用)
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">表的实体类</param>
        public void EditField(SysEntities db, ORDER_TASK_INFORMATION entity)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<ORDER_TASK_INFORMATION> collection = from f in db.ORDER_TASK_INFORMATION
                                                            where f.ID == entity.ID
                                                            select f;

            foreach (var deleteItem in collection)
            {
                deleteItem.ORDER_NUMBER = entity.ORDER_NUMBER == null ? deleteItem.ORDER_NUMBER : entity.ORDER_NUMBER;
                deleteItem.ACCEPT_ORGNIZATION = entity.ACCEPT_ORGNIZATION == null ? deleteItem.ACCEPT_ORGNIZATION : entity.ACCEPT_ORGNIZATION;
                deleteItem.INSPECTION_ENTERPRISE = entity.INSPECTION_ENTERPRISE == null ? deleteItem.INSPECTION_ENTERPRISE : entity.INSPECTION_ENTERPRISE;
                deleteItem.INSPECTION_ENTERPRISE_ADDRESS = entity.INSPECTION_ENTERPRISE_ADDRESS == null ? deleteItem.INSPECTION_ENTERPRISE_ADDRESS : entity.INSPECTION_ENTERPRISE_ADDRESS;
                deleteItem.INSPECTION_ENTERPRISE_POST = entity.INSPECTION_ENTERPRISE_POST == null ? deleteItem.INSPECTION_ENTERPRISE_POST : entity.INSPECTION_ENTERPRISE_POST;
                deleteItem.CONTACTS = entity.CONTACTS == null ? deleteItem.CONTACTS : entity.CONTACTS;
                deleteItem.CONTACT_PHONE = entity.CONTACT_PHONE == null ? deleteItem.CONTACT_PHONE : entity.CONTACT_PHONE;
                deleteItem.FAX = entity.FAX == null ? deleteItem.FAX : entity.FAX;
                deleteItem.CERTIFICATE_ENTERPRISE = entity.CERTIFICATE_ENTERPRISE == null ? deleteItem.CERTIFICATE_ENTERPRISE : entity.CERTIFICATE_ENTERPRISE;
                deleteItem.CERTIFICATE_ENTERPRISE_ADDRESS = entity.CERTIFICATE_ENTERPRISE_ADDRESS == null ? deleteItem.CERTIFICATE_ENTERPRISE_ADDRESS : entity.CERTIFICATE_ENTERPRISE_ADDRESS;
                deleteItem.CERTIFICATE_ENTERPRISE_POST = entity.CERTIFICATE_ENTERPRISE_POST == null ? deleteItem.CERTIFICATE_ENTERPRISE_POST : entity.CERTIFICATE_ENTERPRISE_POST;
                deleteItem.CONTACTS2 = entity.CONTACTS2 == null ? deleteItem.CONTACTS2 : entity.CONTACTS2;
                deleteItem.CREATETIME = entity.CREATETIME == null ? deleteItem.CREATETIME : entity.CREATETIME;
                deleteItem.CREATEPERSON = entity.CREATEPERSON == null ? deleteItem.CREATEPERSON : entity.CREATEPERSON;
                deleteItem.UPDATETIME = entity.UPDATETIME == null ? deleteItem.UPDATETIME : entity.UPDATETIME;
                deleteItem.UPDATEPERSON = entity.UPDATEPERSON == null ? deleteItem.UPDATEPERSON : entity.UPDATEPERSON;
                deleteItem.CONTACT_PHONE2 = entity.CONTACT_PHONE2 == null ? deleteItem.CONTACT_PHONE2 : entity.CONTACT_PHONE2;
                deleteItem.FAX2 = entity.FAX2 == null ? deleteItem.FAX2 : entity.FAX2;
                deleteItem.ORDER_STATUS = entity.ORDER_STATUS == null ? deleteItem.ORDER_STATUS : entity.ORDER_STATUS;
                deleteItem.CUSTOMER_SPECIFIC_REQUIREMENTS = entity.CUSTOMER_SPECIFIC_REQUIREMENTS == null ? deleteItem.CUSTOMER_SPECIFIC_REQUIREMENTS : entity.CUSTOMER_SPECIFIC_REQUIREMENTS;
                deleteItem.ORDER_STATUS = entity.ORDER_STATUS == null ? deleteItem.ORDER_STATUS : entity.ORDER_STATUS;
            }
        }
        public void EditSTATUS(SysEntities db, string id, SIGN sign)
        {
            ORDER_TASK_INFORMATION task = (from f in db.ORDER_TASK_INFORMATION
                                           where f.ID == id
                                           select f).FirstOrDefault();
            task.ORDER_STATUS = Common.ORDER_STATUS.已分配.ToString();
            task.SIGN.Add(sign);
            foreach (var item in task.APPLIANCE_DETAIL_INFORMATION)
            {
                item.APPEARANCE_STATUS = Common.ORDER_STATUS.已分配.ToString();
            }
        }

    }
}

