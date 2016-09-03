using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 预备方案
    /// </summary>
    public partial class PREPARE_SCHEMERepository : BaseRepository<PREPARE_SCHEME>, IDisposable
    {


        /// <summary>
        /// 查找编号最大值
        /// </summary>
        /// <returns>编号最大值</returns>
        public decimal? GetSERIALNUMBERmax(SysEntities db, string time)
        {
            return db.PREPARE_SCHEME.Where(s => s.YEARS == time).Select(s => s.SERIALNUMBER).Max();
        }
        /// <summary>
        /// 修改对象(公用)
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="entity">表的实体类</param>
        public void EditField(SysEntities db, PREPARE_SCHEME entity)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<PREPARE_SCHEME> collection = from f in db.PREPARE_SCHEME
                                                    where f.ID == entity.ID
                                                    select f;

            //db.APPLIANCE_DETAIL_INFORMATION.Attach(entity);
            //db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            //int i = db.SaveChanges();
            foreach (var deleteItem in collection)
            {
                deleteItem.REPORT_CATEGORY = entity.REPORT_CATEGORY == null ? deleteItem.REPORT_CATEGORY : entity.REPORT_CATEGORY;
                deleteItem.CERTIFICATE_CATEGORY = entity.CERTIFICATE_CATEGORY == null ? deleteItem.CERTIFICATE_CATEGORY : entity.CERTIFICATE_CATEGORY;
                deleteItem.CNAS = entity.CNAS == null ? deleteItem.CNAS : entity.CNAS;
                deleteItem.CONTROL_NUMBER = entity.CONTROL_NUMBER == null ? deleteItem.CONTROL_NUMBER : entity.CONTROL_NUMBER;
                deleteItem.CERTIFICATION_AUTHORITY = entity.CERTIFICATION_AUTHORITY == null ? deleteItem.CERTIFICATION_AUTHORITY : entity.CERTIFICATION_AUTHORITY;
                deleteItem.QUALIFICATIONS = entity.QUALIFICATIONS == null ? deleteItem.QUALIFICATIONS : entity.QUALIFICATIONS;
                deleteItem.TEMPERATURE = entity.TEMPERATURE == null ? deleteItem.TEMPERATURE : entity.TEMPERATURE;
                deleteItem.HUMIDITY = entity.HUMIDITY == null ? deleteItem.HUMIDITY : entity.HUMIDITY;
                deleteItem.CHECK_PLACE = entity.CHECK_PLACE == null ? deleteItem.CHECK_PLACE : entity.CHECK_PLACE;
                deleteItem.CHECKERID = entity.CHECKERID == null ? deleteItem.CHECKERID : entity.CHECKERID;
                deleteItem.DETECTERID = entity.DETECTERID == null ? deleteItem.DETECTERID : entity.DETECTERID;
                deleteItem.APPROVALID = entity.APPROVALID == null ? deleteItem.APPROVALID : entity.APPROVALID;
                deleteItem.CALIBRATION_DATE = entity.CALIBRATION_DATE == null ? deleteItem.CALIBRATION_DATE : entity.CALIBRATION_DATE;
                deleteItem.CONCLUSION = entity.CONCLUSION == null ? deleteItem.CONCLUSION : entity.CONCLUSION;
                deleteItem.CONCLUSION_EXPLAIN = entity.CONCLUSION_EXPLAIN == null ? deleteItem.CONCLUSION_EXPLAIN : entity.CONCLUSION_EXPLAIN;
                deleteItem.VALIDITY_PERIOD = entity.VALIDITY_PERIOD == null ? deleteItem.VALIDITY_PERIOD : entity.VALIDITY_PERIOD;
                deleteItem.CALIBRATION_INSTRUCTIONS = entity.CALIBRATION_INSTRUCTIONS == null ? deleteItem.CALIBRATION_INSTRUCTIONS : entity.CALIBRATION_INSTRUCTIONS;
                deleteItem.ACCURACY_GRADE = entity.ACCURACY_GRADE == null ? deleteItem.ACCURACY_GRADE : entity.ACCURACY_GRADE;
                deleteItem.RATED_FREQUENCY = entity.RATED_FREQUENCY == null ? deleteItem.RATED_FREQUENCY : entity.RATED_FREQUENCY;
                deleteItem.PULSE_CONSTANT = entity.PULSE_CONSTANT == null ? deleteItem.PULSE_CONSTANT : entity.PULSE_CONSTANT;
                deleteItem.EXTERNAL_RESITANCE_VALUE = entity.EXTERNAL_RESITANCE_VALUE == null ? deleteItem.EXTERNAL_RESITANCE_VALUE : entity.EXTERNAL_RESITANCE_VALUE;
                deleteItem.SCHEMEID = entity.SCHEMEID == null ? deleteItem.SCHEMEID : entity.SCHEMEID;
                deleteItem.CREATETIME = entity.CREATETIME == null ? deleteItem.CREATETIME : entity.CREATETIME;
                deleteItem.CREATEPERSON = entity.CREATEPERSON == null ? deleteItem.CREATEPERSON : entity.CREATEPERSON;
                deleteItem.UPDATETIME = entity.UPDATETIME == null ? deleteItem.UPDATETIME : entity.UPDATETIME;
                deleteItem.UPDATEPERSON = entity.UPDATEPERSON == null ? deleteItem.UPDATEPERSON : entity.UPDATEPERSON;
                deleteItem.AUDITOPINION = entity.AUDITOPINION == null ? deleteItem.AUDITOPINION : entity.AUDITOPINION;
                deleteItem.AUDITTIME = entity.AUDITTIME == null ? deleteItem.AUDITTIME : entity.AUDITTIME;
                deleteItem.AUDITTEPERSON = entity.AUDITTEPERSON == null ? deleteItem.AUDITTEPERSON : entity.AUDITTEPERSON;
                deleteItem.ISAGGREY = entity.ISAGGREY == null ? deleteItem.ISAGGREY : entity.ISAGGREY;
                deleteItem.APPROVAL = entity.APPROVAL == null ? deleteItem.APPROVAL : entity.APPROVAL;
                deleteItem.APPROVALDATE = entity.APPROVALDATE == null ? deleteItem.APPROVALDATE : entity.APPROVALDATE;
                deleteItem.APPROVALEPERSON = entity.APPROVALEPERSON == null ? deleteItem.APPROVALEPERSON : entity.APPROVALEPERSON;
                deleteItem.APPROVALISAGGREY = entity.APPROVALISAGGREY == null ? deleteItem.APPROVALISAGGREY : entity.APPROVALISAGGREY;
                deleteItem.PRINTSTATUS = entity.PRINTSTATUS == null ? deleteItem.PRINTSTATUS : entity.PRINTSTATUS;
                deleteItem.ISBACK = entity.ISBACK == null ? deleteItem.ISBACK : entity.ISBACK;
                deleteItem.REPORTNUMBER = entity.REPORTNUMBER == null ? deleteItem.REPORTNUMBER : entity.REPORTNUMBER;
                deleteItem.REPORTSTATUS = entity.REPORTSTATUS == null ? deleteItem.REPORTSTATUS : entity.REPORTSTATUS;
                deleteItem.SERIALNUMBER = entity.SERIALNUMBER == null ? deleteItem.SERIALNUMBER : entity.SERIALNUMBER;
                deleteItem.YEARS = entity.YEARS == null ? deleteItem.YEARS : entity.YEARS;
                deleteItem.PACKAGETYPE = entity.PACKAGETYPE == null ? deleteItem.PACKAGETYPE : entity.PACKAGETYPE;
                deleteItem.REPORTSTATUSZI = entity.REPORTSTATUSZI == null ? deleteItem.REPORTSTATUSZI : entity.REPORTSTATUSZI;
            }
        }
    }
}

