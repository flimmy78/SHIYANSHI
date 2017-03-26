using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Langben.DAL
{
    /// <summary>
    /// 证书类别统计分析
    /// </summary>
    public class VZHENGSHULEIBEITONGJIFENXIRepository : BaseRepository<VZHENGSHULEIBEITONGJIFENXI>, IDisposable
    {
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="SysEntities">数据访问的上下文</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="listQuery">额外的参数</param>
        /// <returns></returns>      
        public IQueryable<VZHENGSHULEIBEITONGJIFENXI> GetData(SysEntities db, string order, string sort, string search, params object[] listQuery)
        {
            string SUOSHUDANWEI = string.Empty, ZHENGSHUDANWEI = string.Empty, SHOULIDANWEI = string.Empty;

            DateTime? startTime = null;
            DateTime? endTime = null;
            Dictionary<string, string> queryDic = ValueConvert.StringToDictionary(search.GetString());
            if (queryDic != null && queryDic.Count > 0)
            {
                foreach (var item in queryDic)
                {
                    //oracle数据库使用linq对时间段查询
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(Start_Time)) //开始时间
                    {
                        startTime = Convert.ToDateTime(item.Value);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_Time)) //结束时间+1
                    {
                        endTime = Convert.ToDateTime(item.Value).AddDays(1);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(SUOSHUDANWEI)) //所属单位
                    {
                        SUOSHUDANWEI = (item.Value);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(ZHENGSHUDANWEI)) //证书单位
                    {
                        ZHENGSHUDANWEI = (item.Value);
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(SHOULIDANWEI)) //受理单位
                    {
                        SHOULIDANWEI = (item.Value);
                        continue;
                    }

                }
            }
            var data = db.ORDER_TASK_INFORMATION;
            if (!string.IsNullOrWhiteSpace(SUOSHUDANWEI))
            {
                data.Where(w => w.CERTIFICATE_ENTERPRISEHELLD == SUOSHUDANWEI);
            }
            if (!string.IsNullOrWhiteSpace(ZHENGSHUDANWEI))
            {
                data.Where(w => w.CERTIFICATE_ENTERPRISE == ZHENGSHUDANWEI);
            }
            if (!string.IsNullOrWhiteSpace(SHOULIDANWEI))
            {
                data.Where(w => w.ACCEPT_ORGNIZATION == SHOULIDANWEI);
            }

            var ids = data.Select(s => s.ID).ToList();
            var ps = from p in db.PREPARE_SCHEME
                     from a in p.APPLIANCE_LABORATORY
                     where ids.Contains(a.APPLIANCE_DETAIL_INFORMATION.ORDER_TASK_INFORMATION.ID) && p.APPROVALISAGGREY == "同意"
                     && p.CERTIFICATE_CATEGORY != null && p.AUTHORIZATION != null
                     select p;

            if (null != startTime)
            {
                ps = ps.Where(m => startTime < m.APPROVALDATE);
            }
            if (null != endTime)
            {
                ps = ps.Where(m => endTime > m.APPROVALDATE);
            }
            var dataps = ps.ToList();
            var pp = (from l in dataps
                      group l by new { AUTHORIZATION = l.AUTHORIZATION, CERTIFICATE_CATEGORY = l.CERTIFICATE_CATEGORY } into grouped

                      select new VZHENGSHULEIBEITONGJIFENXI() { SHOUQUANZIZHI = grouped.Key.AUTHORIZATION, ZHEGNSHUBAOGAOLEIBIE = grouped.Key.CERTIFICATE_CATEGORY, BAOGAOSHULIANG = grouped.Count() }).AsQueryable();

            return pp;
        }
        /// <summary>
        /// 通过主键id，获取证书类别统计分析---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>证书类别统计分析</returns>
        public VZHENGSHULEIBEITONGJIFENXI GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }
        }
        /// <summary>
        /// 通过主键id，获取证书类别统计分析---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>证书类别统计分析</returns>
        public VZHENGSHULEIBEITONGJIFENXI GetById(SysEntities db, string id)
        {
            return db.VZHENGSHULEIBEITONGJIFENXI.SingleOrDefault(s => s.ID == id);
        }

        public void Dispose()
        {
        }
    }
}

