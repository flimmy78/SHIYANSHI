using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 不确定度
    /// </summary>
    public partial class UNCERTAINTYTABLERepository : BaseRepository<UNCERTAINTYTABLE>, IDisposable
    {
        /// <summary>
        /// 修改对象(公用)
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">表的实体类</param>
        public void EditField(SysEntities db, UNCERTAINTYTABLE entity)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<UNCERTAINTYTABLE> collection = from f in db.UNCERTAINTYTABLE
                                                      where f.ID == entity.ID
                                                    select f;

            //db.APPLIANCE_DETAIL_INFORMATION.Attach(entity);
            //db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            //int i = db.SaveChanges();
            foreach (var deleteItem in collection)
            {

                deleteItem.NOTE = entity.NOTE == null ? deleteItem.NOTE : entity.NOTE;
                deleteItem.INDEX2UNIT = entity.INDEX2UNIT == null ? deleteItem.INDEX2UNIT : entity.INDEX2UNIT;
                deleteItem.INDEX2 = entity.INDEX2 == null ? deleteItem.INDEX2 : entity.INDEX2;
                deleteItem.INDEX1UNIT = entity.INDEX1UNIT == null ? deleteItem.INDEX1UNIT : entity.INDEX1UNIT;
                deleteItem.INDEX1 = entity.INDEX1 == null ? deleteItem.INDEX1 : entity.INDEX1;
                deleteItem.ENDRELATIONSHIPFREQUENCY = entity.ENDRELATIONSHIPFREQUENCY == null ? deleteItem.ENDRELATIONSHIPFREQUENCY : entity.ENDRELATIONSHIPFREQUENCY;
                deleteItem.ENDUNITFREQUENCY = entity.ENDUNITFREQUENCY == null ? deleteItem.ENDUNITFREQUENCY : entity.ENDUNITFREQUENCY;
                deleteItem.ENDFREQUENCY = entity.ENDFREQUENCY == null ? deleteItem.ENDFREQUENCY : entity.ENDFREQUENCY;
                deleteItem.THERELATIONSHIPFREQUENCY = entity.THERELATIONSHIPFREQUENCY == null ? deleteItem.THERELATIONSHIPFREQUENCY : entity.THERELATIONSHIPFREQUENCY;
                deleteItem.THEUNITFREQUENCY = entity.THEUNITFREQUENCY == null ? deleteItem.THEUNITFREQUENCY : entity.THEUNITFREQUENCY;
                deleteItem.THEFREQUENCY = entity.THEFREQUENCY == null ? deleteItem.THEFREQUENCY : entity.THEFREQUENCY;
                deleteItem.ENDRELATIONSHIP = entity.ENDRELATIONSHIP == null ? deleteItem.ENDRELATIONSHIP : entity.ENDRELATIONSHIP;
                deleteItem.ENDUNIT = entity.ENDUNIT == null ? deleteItem.ENDUNIT : entity.ENDUNIT;
                deleteItem.ENDRANGESCOPE = entity.ENDRANGESCOPE == null ? deleteItem.ENDRANGESCOPE : entity.ENDRANGESCOPE;
                deleteItem.THERELATIONSHIP = entity.THERELATIONSHIP == null ? deleteItem.THERELATIONSHIP : entity.THERELATIONSHIP;
                deleteItem.THEUNIT = entity.THEUNIT == null ? deleteItem.THEUNIT : entity.THEUNIT;
                deleteItem.THERANGESCOPE = entity.THERANGESCOPE == null ? deleteItem.THERANGESCOPE : entity.THERANGESCOPE;
                deleteItem.KVALE = entity.KVALE == null ? deleteItem.KVALE : entity.KVALE;
                deleteItem.THEERRODISTRIBUTION = entity.THEERRODISTRIBUTION == null ? deleteItem.THEERRODISTRIBUTION : entity.THEERRODISTRIBUTION;
                deleteItem.ERRORLIMITUNIT = entity.ERRORLIMITUNIT == null ? deleteItem.ERRORLIMITUNIT : entity.ERRORLIMITUNIT;
                deleteItem.ERRORLIMITS = entity.ERRORLIMITS == null ? deleteItem.ERRORLIMITS : entity.ERRORLIMITS;
                deleteItem.ERRORSOURCES = entity.ERRORSOURCES == null ? deleteItem.ERRORSOURCES : entity.ERRORSOURCES;
                deleteItem.CREATETIME = entity.CREATETIME == null ? deleteItem.CREATETIME : entity.CREATETIME;
                deleteItem.CREATEPERSON = entity.CREATEPERSON == null ? deleteItem.CREATEPERSON : entity.CREATEPERSON;
                deleteItem.UPDATETIME = entity.UPDATETIME == null ? deleteItem.UPDATETIME : entity.UPDATETIME;
                deleteItem.UPDATEPERSON = entity.UPDATEPERSON == null ? deleteItem.UPDATEPERSON : entity.UPDATEPERSON;
                deleteItem.ASSESSMENTITEM = entity.ASSESSMENTITEM == null ? deleteItem.ASSESSMENTITEM : entity.ASSESSMENTITEM;
                deleteItem.METERING_STANDARD_DEVICEID = entity.METERING_STANDARD_DEVICEID == null ? deleteItem.METERING_STANDARD_DEVICEID : entity.METERING_STANDARD_DEVICEID;
                deleteItem.GROUPS = entity.GROUPS == null ? deleteItem.GROUPS : entity.GROUPS;
                deleteItem.UNCERTAINTYUI = entity.UNCERTAINTYUI == null ? deleteItem.UNCERTAINTYUI : entity.UNCERTAINTYUI;              
            }
        }

    }
}

