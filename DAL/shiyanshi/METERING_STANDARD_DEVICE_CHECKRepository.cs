using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 计量标准装置检定/校准信息
    /// </summary>
    public partial class METERING_STANDARD_DEVICE_CHECKRepository : BaseRepository<METERING_STANDARD_DEVICE_CHECK>, IDisposable
    {
        /// <summary>
        /// 修改对象(公用)
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">表的实体类</param>
        public void EditField(SysEntities db, METERING_STANDARD_DEVICE_CHECK entity)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<METERING_STANDARD_DEVICE_CHECK> collection = from f in db.METERING_STANDARD_DEVICE_CHECK
                                                              where f.ID == entity.ID
                                                              select f;

            foreach (var deleteItem in collection)
            {
                deleteItem.CERTIFICATEUNIT = entity.CERTIFICATEUNIT == null ? deleteItem.CERTIFICATEUNIT : entity.CERTIFICATEUNIT;
                deleteItem.CERTIFICATE_NUM = entity.CERTIFICATE_NUM == null ? deleteItem.CERTIFICATE_NUM : entity.CERTIFICATE_NUM;
                deleteItem.CHECK_DATE = entity.CHECK_DATE == null ? deleteItem.CHECK_DATE : entity.CHECK_DATE;
                deleteItem.VALID_TO = entity.VALID_TO == null ? deleteItem.VALID_TO : entity.VALID_TO;
                deleteItem.METERING_STANDARD_DEVICEID = entity.METERING_STANDARD_DEVICEID == null ? deleteItem.METERING_STANDARD_DEVICEID : entity.METERING_STANDARD_DEVICEID;
                deleteItem.CREATETIME = entity.CREATETIME == null ? deleteItem.CREATETIME : entity.CREATETIME;
                deleteItem.CREATEPERSON = entity.CREATEPERSON == null ? deleteItem.CREATEPERSON : entity.CREATEPERSON;
                deleteItem.UPDATETIME = entity.UPDATETIME == null ? deleteItem.UPDATETIME : entity.UPDATETIME;
                deleteItem.UPDATEPERSON = entity.UPDATEPERSON == null ? deleteItem.UPDATEPERSON : entity.UPDATEPERSON;
            }
        }
    }
}

