using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 附件
    /// </summary>
    public partial class FILE_UPLOADERRepository : BaseRepository<FILE_UPLOADER>, IDisposable
    {
        /// <summary>
        /// 修改对象(公用)
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">表的实体类</param>
        public void EditField(SysEntities db, FILE_UPLOADER entity)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<FILE_UPLOADER> collection = from f in db.FILE_UPLOADER
                                                   where f.ID == entity.ID
                                                          select f;

            //db.APPLIANCE_DETAIL_INFORMATION.Attach(entity);
            //db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            //int i = db.SaveChanges();
            foreach (var deleteItem in collection)
            {
                deleteItem.NAME = entity.NAME == null ? deleteItem.NAME : entity.NAME;
                deleteItem.PATH = entity.PATH == null ? deleteItem.PATH : entity.PATH;
                deleteItem.PREPARE_SCHEMEID = entity.PREPARE_SCHEMEID == null ? deleteItem.PREPARE_SCHEMEID : entity.PREPARE_SCHEMEID;
                deleteItem.FULLPATH = entity.FULLPATH == null ? deleteItem.FULLPATH : entity.FULLPATH;
                deleteItem.SUFFIX = entity.SUFFIX == null ? deleteItem.SUFFIX : entity.SUFFIX;
                deleteItem.SIZE = entity.SIZE == null ? deleteItem.SIZE : entity.SIZE;
                deleteItem.REMARK = entity.REMARK == null ? deleteItem.REMARK : entity.REMARK;
                deleteItem.NAME2 = entity.NAME2 == null ? deleteItem.NAME2 : entity.NAME2;
                deleteItem.PATH2 = entity.PATH2 == null ? deleteItem.PATH2 : entity.PATH2;
                deleteItem.FULLPATH2 = entity.FULLPATH2 == null ? deleteItem.FULLPATH2 : entity.FULLPATH2;
                deleteItem.SUFFIX2 = entity.SUFFIX2 == null ? deleteItem.SUFFIX2 : entity.SUFFIX2;
                deleteItem.SIZE2 = entity.SIZE2 == null ? deleteItem.SIZE2 : entity.SIZE2;
                deleteItem.REMARK2 = entity.REMARK2 == null ? deleteItem.REMARK2 : entity.REMARK2;
                deleteItem.STATE2 = entity.STATE2 == null ? deleteItem.STATE2 : entity.STATE2;
                deleteItem.STATE = entity.STATE == null ? deleteItem.STATE : entity.STATE;
                deleteItem.CREATETIME = entity.CREATETIME == null ? deleteItem.CREATETIME : entity.CREATETIME;
                deleteItem.CREATEPERSON = entity.CREATEPERSON == null ? deleteItem.CREATEPERSON : entity.CREATEPERSON;
                deleteItem.CONCLUSION = entity.CONCLUSION == null ? deleteItem.CONCLUSION : entity.CONCLUSION;
                deleteItem.PREPARE_SCHEMEID = entity.PREPARE_SCHEMEID == null ? deleteItem.PREPARE_SCHEMEID : entity.PREPARE_SCHEMEID;
                deleteItem.UPDATETIME = entity.UPDATETIME == null ? deleteItem.UPDATETIME : entity.UPDATETIME;
                deleteItem.UPDATEPERSON = entity.UPDATEPERSON == null ? deleteItem.UPDATEPERSON : entity.UPDATEPERSON;
            }
        }
    }
}

