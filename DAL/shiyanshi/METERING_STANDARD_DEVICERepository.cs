using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 标准装置/计量标准器信息
    /// </summary>
    public partial class METERING_STANDARD_DEVICERepository : BaseRepository<METERING_STANDARD_DEVICE>, IDisposable
    {
        /// <summary>
        /// 修改对象(公用)
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">表的实体类</param>
        public void EditField(SysEntities db, METERING_STANDARD_DEVICE entity)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<METERING_STANDARD_DEVICE> collection = from f in db.METERING_STANDARD_DEVICE
                                                              where f.ID == entity.ID
                                                            select f;

            foreach (var deleteItem in collection)
            {
                deleteItem.NAME = entity.NAME == null ? deleteItem.NAME : entity.NAME;
                deleteItem.TEST_RANGE = entity.TEST_RANGE == null ? deleteItem.TEST_RANGE : entity.TEST_RANGE;
                deleteItem.FACTORY_NUM = entity.FACTORY_NUM == null ? deleteItem.FACTORY_NUM : entity.FACTORY_NUM;
                deleteItem.XINGHAO = entity.XINGHAO == null ? deleteItem.XINGHAO : entity.XINGHAO;
                deleteItem.CATEGORY = entity.CATEGORY == null ? deleteItem.CATEGORY : entity.CATEGORY;
                deleteItem.UNDERTAKE_LABORATORYID = entity.UNDERTAKE_LABORATORYID == null ? deleteItem.UNDERTAKE_LABORATORYID : entity.UNDERTAKE_LABORATORYID;
                deleteItem.STATUS = entity.STATUS == null ? deleteItem.STATUS : entity.STATUS;
                deleteItem.CREATETIME = entity.CREATETIME == null ? deleteItem.CREATETIME : entity.CREATETIME;
                deleteItem.CREATEPERSON = entity.CREATEPERSON == null ? deleteItem.CREATEPERSON : entity.CREATEPERSON;
                deleteItem.UPDATETIME = entity.UPDATETIME == null ? deleteItem.UPDATETIME : entity.UPDATETIME;
                deleteItem.UPDATEPERSON = entity.UPDATEPERSON == null ? deleteItem.UPDATEPERSON : entity.UPDATEPERSON;
                deleteItem.THESUPERIOR = entity.THESUPERIOR == null ? deleteItem.THESUPERIOR : entity.THESUPERIOR;
              
            }
        }
    }
}

