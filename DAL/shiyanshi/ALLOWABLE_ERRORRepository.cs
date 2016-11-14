using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 最大允许误差信息
    /// </summary>
    public partial class ALLOWABLE_ERRORRepository : BaseRepository<ALLOWABLE_ERROR>, IDisposable
    {
        /// <summary>
        /// 修改对象(公用)
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">表的实体类</param>
        public void EditField(SysEntities db, ALLOWABLE_ERROR entity)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<ALLOWABLE_ERROR> collection = from f in db.ALLOWABLE_ERROR
                                                              where f.ID == entity.ID
                                                              select f;

            foreach (var deleteItem in collection)
            {
                deleteItem.THEACCURACYLEVEL = entity.THEACCURACYLEVEL == null ? deleteItem.THEACCURACYLEVEL : entity.THEACCURACYLEVEL;
                deleteItem.THEUNCERTAINTYVALUEK = entity.THEUNCERTAINTYVALUEK == null ? deleteItem.THEUNCERTAINTYVALUEK : entity.THEUNCERTAINTYVALUEK;
                deleteItem.THEUNCERTAINTYNDEXL = entity.THEUNCERTAINTYNDEXL == null ? deleteItem.THEUNCERTAINTYNDEXL : entity.THEUNCERTAINTYNDEXL;
                deleteItem.THEUNCERTAINTYVALUE = entity.THEUNCERTAINTYVALUE == null ? deleteItem.THEUNCERTAINTYVALUE : entity.THEUNCERTAINTYVALUE;
                deleteItem.THEUNCERTAINTY = entity.THEUNCERTAINTY == null ? deleteItem.THEUNCERTAINTY : entity.THEUNCERTAINTY;
                deleteItem.MAXVALUE = entity.MAXVALUE == null ? deleteItem.MAXVALUE : entity.MAXVALUE;
                deleteItem.MAXCATEGORIES = entity.MAXCATEGORIES == null ? deleteItem.MAXCATEGORIES : entity.MAXCATEGORIES;
                deleteItem.CREATETIME = entity.CREATETIME == null ? deleteItem.CREATETIME : entity.CREATETIME;
                deleteItem.CREATEPERSON = entity.CREATEPERSON == null ? deleteItem.CREATEPERSON : entity.CREATEPERSON;
                deleteItem.UPDATETIME = entity.UPDATETIME == null ? deleteItem.UPDATETIME : entity.UPDATETIME;
                deleteItem.UPDATEPERSON = entity.UPDATEPERSON == null ? deleteItem.UPDATEPERSON : entity.UPDATEPERSON;
                deleteItem.METERING_STANDARD_DEVICEID = entity.METERING_STANDARD_DEVICEID == null ? deleteItem.METERING_STANDARD_DEVICEID : entity.METERING_STANDARD_DEVICEID;

            }
        }
    }
}

