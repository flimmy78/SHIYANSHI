using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;

namespace Langben.BLL
{
    /// <summary>
    /// 标准装置/计量标准器信息 
    /// </summary>
    public partial class METERING_STANDARD_DEVICEBLL : IBLL.IMETERING_STANDARD_DEVICEBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 标准装置/计量标准器信息的数据库访问对象
        /// </summary>
        METERING_STANDARD_DEVICERepository repository = new METERING_STANDARD_DEVICERepository();
        STANDARDCHOICERepository repository2 = new STANDARDCHOICERepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public METERING_STANDARD_DEVICEBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public METERING_STANDARD_DEVICEBLL(SysEntities entities)
        {
            db = entities;
        }
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">升序asc（默认）还是降序desc</param>
        /// <param name="sort">排序字段</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<METERING_STANDARD_DEVICE> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {


            IQueryable<METERING_STANDARD_DEVICE> queryData = repository.GetData(db, order, sort, search);
            total = queryData.Count();
            if (total > 0)
            {
                if (page <= 1)
                {
                    queryData = queryData.Take(rows);
                }
                else
                {
                    queryData = queryData.Skip((page - 1) * rows).Take(rows);
                }

                foreach (var item in queryData)
                {
                    if (item.UNDERTAKE_LABORATORYID != null && item.UNDERTAKE_LABORATORY != null)
                    {
                        item.UNDERTAKE_LABORATORYIDOld = item.UNDERTAKE_LABORATORY.NAME.GetString();//                            
                    }

                    if (item.PREPARE_SCHEME != null)
                    {
                        item.PREPARE_SCHEMEID = string.Empty;
                        foreach (var it in item.PREPARE_SCHEME)
                        {
                            item.PREPARE_SCHEMEID += it.REPORT_CATEGORY + ' ';
                        }
                    }

                }

            }
            return queryData.ToList();
        }
        /// <summary>
        /// 查询的数据 /*在6.0版本中 新增*/
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">升序asc（默认）还是降序desc</param>
        /// <param name="sort">排序字段</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<METERING_STANDARD_DEVICE> GetByParam(string id, string order, string sort, string search)
        {
            IQueryable<METERING_STANDARD_DEVICE> queryData = repository.GetData(db, order, sort, search);

            return queryData.ToList();
        }
        /// <summary>
        /// 创建一个标准装置/计量标准器信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个标准装置/计量标准器信息</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, SysEntities db, METERING_STANDARD_DEVICE entity)
        {
            int count = 1;

            foreach (string item in entity.PREPARE_SCHEMEID.GetIdSort())
            {
                PREPARE_SCHEME sys = new PREPARE_SCHEME { ID = item };
                db.PREPARE_SCHEME.Attach(sys);
                entity.PREPARE_SCHEME.Add(sys);
                count++;
            }

            repository.Create(db, entity);
            if (count == repository.Save(db))
            {
                return true;
            }
            else
            {
                validationErrors.Add("创建出错了");
            }
            return false;
        }
        /// <summary>
        /// 创建一个标准装置/计量标准器信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个标准装置/计量标准器信息</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, METERING_STANDARD_DEVICE entity)
        {
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    if (Create(ref validationErrors, db, entity))
                    {
                        transactionScope.Complete();
                        return true;
                    }
                    else
                    {
                        Transaction.Current.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);
            }
            return false;
        }
        /// <summary>
        ///  创建标准装置/计量标准器信息集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">标准装置/计量标准器信息集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<METERING_STANDARD_DEVICE> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int flag = 0, count = entitys.Count();
                    if (count > 0)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        {
                            foreach (var entity in entitys)
                            {
                                if (Create(ref validationErrors, db, entity))
                                {
                                    flag++;
                                }
                                else
                                {
                                    Transaction.Current.Rollback();
                                    return false;
                                }
                            }
                            if (count == flag)
                            {
                                transactionScope.Complete();
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);
            }
            return false;
        }

        /// <summary>
        /// 删除一个标准装置/计量标准器信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一个标准装置/计量标准器信息的主键</param>
        /// <returns></returns>  
        public bool Delete(ref ValidationErrors validationErrors, string id)
        {
            try
            {
                return repository.Delete(id) == 1;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);
            }
            return false;
        }
        /// <summary>
        /// 删除标准装置/计量标准器信息集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">主键的标准装置/计量标准器信息</param>
        /// <returns></returns>    
        public bool DeleteCollection(ref ValidationErrors validationErrors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {

                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        repository.Delete(db, deleteCollection);
                        if (deleteCollection.Length == repository.Save(db))
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);
            }
            return false;
        }
        /// <summary>
        ///  创建标准装置/计量标准器信息集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">标准装置/计量标准器信息集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<METERING_STANDARD_DEVICE> entitys)
        {
            if (entitys != null)
            {
                try
                {
                    int flag = 0, count = entitys.Count();
                    if (count > 0)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        {
                            foreach (var entity in entitys)
                            {
                                if (Edit(ref validationErrors, db, entity))
                                {
                                    flag++;
                                }
                                else
                                {
                                    Transaction.Current.Rollback();
                                    return false;
                                }
                            }
                            if (count == flag)
                            {
                                transactionScope.Complete();
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    validationErrors.Add(ex.Message);
                    ExceptionsHander.WriteExceptions(ex);
                }
            }
            return false;
        }
        /// <summary>
        /// 编辑一个标准装置/计量标准器信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据上下文</param>
        /// <param name="entity">一个标准装置/计量标准器信息</param>
        /// <returns>是否编辑成功</returns>
        public bool Edit(ref ValidationErrors validationErrors, SysEntities db, METERING_STANDARD_DEVICE entity)
        {  /*                       
                           * 不操作 原有 现有
                           * 增加   原没 现有
                           * 删除   原有 现没
                           */


            if (entity == null)
            {
                return false;
            }
            int count = 1;

            var data = (from m in db.METERING_STANDARD_DEVICE
                        where m.ID == entity.ID
                        select m).FirstOrDefault();//在数据的原始数据


            data.NAME = entity.NAME;





            List<string> addPREPARE_SCHEMEID = new List<string>();
            List<string> deletePREPARE_SCHEMEID = new List<string>();
            DataOfDiffrent.GetDiffrent(entity.PREPARE_SCHEMEID.GetIdSort(), entity.PREPARE_SCHEMEIDOld.GetIdSort(), ref addPREPARE_SCHEMEID, ref deletePREPARE_SCHEMEID);
            List<PREPARE_SCHEME> listEntityPREPARE_SCHEME = new List<PREPARE_SCHEME>();
            if (deletePREPARE_SCHEMEID != null && deletePREPARE_SCHEMEID.Count() > 0)
            {
                foreach (var item in deletePREPARE_SCHEMEID)
                {
                    PREPARE_SCHEME sys = new PREPARE_SCHEME { ID = item };
                    listEntityPREPARE_SCHEME.Add(sys);
                    entity.PREPARE_SCHEME.Add(sys);
                }
            }

            METERING_STANDARD_DEVICE editEntity = repository.Edit(db, entity);


            if (addPREPARE_SCHEMEID != null && addPREPARE_SCHEMEID.Count() > 0)
            {
                foreach (var item in addPREPARE_SCHEMEID)
                {
                    PREPARE_SCHEME sys = new PREPARE_SCHEME { ID = item };
                    db.PREPARE_SCHEME.Attach(sys);
                    editEntity.PREPARE_SCHEME.Add(sys);
                    count++;
                }
            }
            if (deletePREPARE_SCHEMEID != null && deletePREPARE_SCHEMEID.Count() > 0)
            {
                foreach (PREPARE_SCHEME item in listEntityPREPARE_SCHEME)
                {
                    editEntity.PREPARE_SCHEME.Remove(item);
                    count++;
                }
            }

            if (count == repository.Save(db))
            {
                return true;
            }
            else
            {
                validationErrors.Add("编辑标准装置/计量标准器信息出错了");
            }
            return false;
        }
        /// <summary>
        /// 编辑一个标准装置/计量标准器信息
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个标准装置/计量标准器信息</param>
        /// <returns>是否编辑成功</returns>
        public bool Edit(ref ValidationErrors validationErrors, METERING_STANDARD_DEVICE entity)
        {
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    if (Edit(ref validationErrors, db, entity))
                    {
                        transactionScope.Complete();
                        return true;
                    }
                    else
                    {
                        Transaction.Current.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);
            }
            return false;
        }
        public List<METERING_STANDARD_DEVICE> GetAll()
        {
            return repository.GetAll(db).ToList();
        }

        /// <summary>
        /// 根据主键获取一个标准装置/计量标准器信息
        /// </summary>
        /// <param name="id">标准装置/计量标准器信息的主键</param>
        /// <returns>一个标准装置/计量标准器信息</returns>
        public METERING_STANDARD_DEVICE GetById(string id)
        {
            return repository.GetById(db, id);
        }

        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<PREPARE_SCHEME> GetRefPREPARE_SCHEME(string id)
        {
            return repository.GetRefPREPARE_SCHEME(db, id).ToList();
        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<PREPARE_SCHEME> GetRefPREPARE_SCHEME()
        {
            return repository.GetRefPREPARE_SCHEME(db).ToList();
        }


        /// <summary>
        /// 根据UNDERTAKE_LABORATORYIDId，获取所有标准装置/计量标准器信息数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<METERING_STANDARD_DEVICE> GetByRefUNDERTAKE_LABORATORYID(string id)
        {
            return repository.GetByRefUNDERTAKE_LABORATORYID(db, id).ToList();
        }

        /// <summary>
        /// 标准器的选择查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<METERING_STANDARD_DEVICE> GetPREPARE_SCHEME(string id)
        {
            List<METERING_STANDARD_DEVICE> msddlist = new List<METERING_STANDARD_DEVICE>();
            METERING_STANDARD_DEVICE msdd = new METERING_STANDARD_DEVICE();
            //if (!string.IsNullOrWhiteSpace(id))
            //{
            //    List<STANDARDCHOICE> stalist = repository2.GetByRefPREPARE_SCHEMEID(db,id).ToList();
            //    foreach (var item in stalist)
            //    {
            //        if (!string.IsNullOrWhiteSpace(item.METERING_STANDARD_DEVICEID))
            //        {
            //            METERING_STANDARD_DEVICE msd = repository.GetById(item.METERING_STANDARD_DEVICEID);
                        
            //            var data = msd.ALLOWABLE_ERROR.Where(m => m.CATEGORY == "AA" && m.GROUPS == Convert.ToInt32(item.GROUPS));
            //            foreach (var al in data)
            //            {
            //                var alladd = new ALLOWABLE_ERROR()
            //                {
            //                    ID = al.ID,
            //                    THEACCURACYLEVEL = al.THEACCURACYLEVEL,
            //                    THEUNCERTAINTYVALUEK = al.THEUNCERTAINTYVALUEK,
            //                    THEUNCERTAINTYNDEXL = al.THEUNCERTAINTYNDEXL,
            //                    THEUNCERTAINTYVALUE = al.THEUNCERTAINTYVALUE,
            //                    THEUNCERTAINTY = al.THEUNCERTAINTY,
            //                    MAXVALUE = al.MAXVALUE,
            //                    MAXCATEGORIES = al.MAXCATEGORIES,
            //                    METERING_STANDARD_DEVICEID = al.METERING_STANDARD_DEVICEID,
            //                    GROUPS = al.GROUPS
            //                };
            //                msdd.ALLOWABLE_ERROR.Add(alladd);
            //            }
            //            var data2 = msd.METERING_STANDARD_DEVICE_CHECK.Where(m => m.CATEGORY == "AA" && m.GROUPS == Convert.ToInt32(item.GROUPS));
            //            foreach (var ms in data2)
            //            {
            //                var msdcadd = new METERING_STANDARD_DEVICE_CHECK()
            //                {
            //                    ID = ms.ID,
            //                    CERTIFICATEUNIT = ms.CERTIFICATEUNIT,
            //                    CERTIFICATE_NUM = ms.CERTIFICATE_NUM,
            //                    CHECK_DATE = ms.CHECK_DATE,
            //                    VALID_TO = ms.VALID_TO,
            //                    METERING_STANDARD_DEVICEID = ms.METERING_STANDARD_DEVICEID,
            //                    GROUPS = ms.GROUPS
            //                };
            //                msdd.METERING_STANDARD_DEVICE_CHECK.Add(msdcadd);
            //            }
            //        }
            //        msddlist.Add(msdd);
            //    }
            //}

            return msddlist;
        }
        public void Dispose()
        {

        }
    }
}

