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
    /// 单位 
    /// </summary>
    public partial class COMPANYBLL : IBLL.ICOMPANYBLL, IDisposable
    {
        /// <summary>
        /// 制造单位下拉框数据绑定
        /// </summary>
        /// <returns></returns>
        public string Getdate()
        {
            string search = null;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            int i = 0;
            using (SysEntities db = new SysEntities())
            {
                var queryData = repository.GetData(db, "DESC", "CREATETIME", search);//调用GetData方法从数据库中获取到相关数据    
                int a = queryData.Count();
                if (queryData != null)
                {
                    //queryData = queryData.Take(2).Distinct();//5表示显示5行
                    foreach (var item in queryData)
                    {
                        if (null == item)
                        {
                            continue;
                        }
                        if (i == 0)
                        {
                            i++;
                            stringBuilder.Append(@"{@value@:@" + item.COMPANYNAME + "@");
                            stringBuilder.Append(",");
                            stringBuilder.Append(@"@text@:@" + item.COMPANYNAME + "@}");
                        }
                        else
                        {
                            stringBuilder.Append(",");
                            stringBuilder.Append(@"{@value@:@" + item.COMPANYNAME + "@");
                            stringBuilder.Append(",");
                            stringBuilder.Append(@"@text@:@" + item.COMPANYNAME + "@}");
                        }
                    }
                }
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString().Replace('@', '"');
        }

        /// <summary>
        /// 送检单位下拉框数据带出
        /// </summary>
        /// <returns></returns>
        public COMPANY GetVasedate(string COMPANYNAME)
        {
            string search = null;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            int i = 0;
            using (SysEntities db = new SysEntities())
            {
                var queryData = repository.GetData(db, "DESC", "CREATETIME", search);//调用GetData方法从数据库中获取到相关数据    
                int a = queryData.Count();
                if (queryData != null)
                {
                    COMPANY cOMPANY = queryData.Where(m => m.COMPANYNAME == COMPANYNAME).FirstOrDefault();

                    return new COMPANY()
                    {
                        COMPANYADDRES = cOMPANY.COMPANYADDRES,
                        CONTACTS= cOMPANY.CONTACTS,
                        CONTACTSNUMBER= cOMPANY.CONTACTSNUMBER,
                        FAX= cOMPANY.FAX
                    };
                }
            }
            return new COMPANY();
        }
    }
}

