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
    /// 附件 
    /// </summary>
    public partial class FILE_UPLOADERBLL : IBLL.IFILE_UPLOADERBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 附件的数据库访问对象
        /// </summary>
        FILE_UPLOADERRepository repository = new FILE_UPLOADERRepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public FILE_UPLOADERBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public FILE_UPLOADERBLL(SysEntities entities)
        {
            db = entities;
        }
        /// <summary>
        /// 根据预备方案ID获取报告
        /// </summary>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <returns></returns>
        public FILE_UPLOADER GetEntityByPREPARE_SCHEMEID(string PREPARE_SCHEMEID)
        {
            List<FILE_UPLOADER> list = null;

            using (SysEntities db = new SysEntities())
            {
                list = db.FILE_UPLOADER.Where(p => p.PREPARE_SCHEMEID == PREPARE_SCHEMEID && p.STATE != "已删除").ToList();
            }
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            return null;
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
        public List<FILE_UPLOADER> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {
            IQueryable<FILE_UPLOADER> queryData = repository.GetData(db, order, sort, search);
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
                    if (item.PREPARE_SCHEMEID != null && item.PREPARE_SCHEME != null)
                    {
                        item.PREPARE_SCHEMEIDOld = item.PREPARE_SCHEME.REPORT_CATEGORY.GetString();//                            
                    }

                }

            }
            return queryData.ToList();
        }
        /// <summary>
        /// 根据预备方案删除删除信息
        /// </summary>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <param name="Person">操作人</param>
        public void DeleteByPREPARE_SCHEMEID(string PREPARE_SCHEMEID, string Person)
        {
            try
            {
                if (PREPARE_SCHEMEID != null && PREPARE_SCHEMEID.Trim() != "")
                {
                    string sb = string.Format("PREPARE_SCHEMEID{0}&{1}^", "DDL_String", PREPARE_SCHEMEID);
                    List<FILE_UPLOADER> list = repository.GetData(db, "desc", "CreateTime", sb.ToString()).ToList();
                    if (list == null || list.Count > 0)
                    {
                        ValidationErrors validationErrors = null;
                        foreach (FILE_UPLOADER item in list)
                        {
                            item.STATE = "已删除";
                            item.UPDATEPERSON = Person;
                            item.UPDATETIME = DateTime.Now;
                            Edit(ref validationErrors, item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

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
        public List<FILE_UPLOADER> GetByParam(string id, string order, string sort, string search)
        {
            IQueryable<FILE_UPLOADER> queryData = repository.GetData(db, order, sort, search);

            return queryData.ToList();
        }
        /// <summary>
        /// 创建一个附件
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个附件</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, FILE_UPLOADER entity)
        {
            try
            {
                string err = string.Empty;

                //  DeleteByPREPARE_SCHEMEID(entity.PREPARE_SCHEMEID,entity.CREATEPERSON);
                repository.Create(entity);
                if (!string.IsNullOrWhiteSpace(entity.STATE2)&& entity.STATE2== "已上传")//原始记录
                {
                    Langben.Report.ReportBLL re = new Langben.Report.ReportBLL();
                    return re.UpdateFuJianRemark(entity.PREPARE_SCHEMEID, out err);
                }
                //if (chuanzhi == "Y")
                //{
                //    file.STATE2 = Common.PACKAGETYPE.已上传.ToString();
                //}
                //else
                //{
                //    file.STATE = Common.PACKAGETYPE.已上传.ToString();
                //}

             
                return true;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message + "创建错误");
                validationErrors.Add(ex.Source);
                ExceptionsHander.WriteExceptions(ex);
            }
            return false;
        }
        /// <summary>
        ///  创建附件集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">附件集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<FILE_UPLOADER> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int count = entitys.Count();
                    if (count == 1)
                    {
                        return this.Create(ref validationErrors, entitys.FirstOrDefault());
                    }
                    else if (count > 1)
                    {
                        //using (TransactionScope transactionScope = new TransactionScope())
                        {
                            repository.Create(db, entitys);
                            if (count == repository.Save(db))
                            {
                                //transactionScope.Complete();
                                return true;
                            }
                            else
                            {
                                //Transaction.Current.Rollback();
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
        /// 删除一个附件
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一附件的主键</param>
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
        /// 删除附件集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">附件的集合</param>
        /// <returns></returns>    
        public bool DeleteCollection(ref ValidationErrors validationErrors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    //using (TransactionScope transactionScope = new TransactionScope())
                    {
                        repository.Delete(db, deleteCollection);
                        if (deleteCollection.Length == repository.Save(db))
                        {
                            //transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            //Transaction.Current.Rollback();
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
        ///  创建附件集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">附件集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<FILE_UPLOADER> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int count = entitys.Count();
                    if (count == 1)
                    {
                        return this.Edit(ref validationErrors, entitys.FirstOrDefault());
                    }
                    else if (count > 1)
                    {
                        //using (TransactionScope transactionScope = new TransactionScope())
                        {
                            repository.Edit(db, entitys);
                            if (count == repository.Save(db))
                            {
                                //transactionScope.Complete();
                                return true;
                            }
                            else
                            {
                                //Transaction.Current.Rollback();
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
        /// 编辑一个附件
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个附件</param>
        /// <returns></returns>
        public bool Edit(ref ValidationErrors validationErrors, FILE_UPLOADER entity)
        {
            try
            {
                repository.Edit(db, entity);
                repository.Save(db);
                return true;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);
            }
            return false;
        }

        public List<FILE_UPLOADER> GetAll()
        {
            return repository.GetAll(db).ToList();
        }

        /// <summary>
        /// 根据主键获取一个附件
        /// </summary>
        /// <param name="id">附件的主键</param>
        /// <returns>一个附件</returns>
        public FILE_UPLOADER GetById(string id)
        {
            return repository.GetById(db, id);
        }

        /// <summary>
        /// 通过预备方案id，判断器具是否为上传报告
        /// </summary>
        /// <param name="id">预备方案的id</param>
        /// <returns>一个附件</returns>
        public FILE_UPLOADER GetPREPARE_SCHEMEID(string id)
        {
            return repository.GetPREPARE_SCHEMEID(db, id);
        }

        /// <summary>
        /// 根据PREPARE_SCHEMEIDId，获取所有附件数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<FILE_UPLOADER> GetByRefPREPARE_SCHEMEID(string id)
        {
            return repository.GetByRefPREPARE_SCHEMEID(db, id).ToList();
        }

        public void Dispose()
        {

        }
    }
}

