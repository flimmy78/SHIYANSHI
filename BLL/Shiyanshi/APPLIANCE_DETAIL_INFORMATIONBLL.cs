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
    /// 客户管理 
    /// </summary>
    public partial class APPLIANCE_DETAIL_INFORMATIONBLL : IBLL.IAPPLIANCE_DETAIL_INFORMATIONBLL, IDisposable
    {
        /// <summary>
        /// 在查询中输入字符串，自动提示的功能
        /// </summary>
        /// <param name="id">需要查询的数据库字段的名称</param>
        /// <param name="term">输入的字符串</param>
        /// <returns></returns>  
        public string SearchAutoComplete(string id, string term)
        {
            string search = id + "&" + term + "^";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            int i = 0;

            using (SysEntities db = new SysEntities())
            {

                var queryData = repository.GetData(db, "DESC", "CREATETIME", search);//调用GetData方法从数据库中获取到相关数据      
                if (queryData != null)
                {
                    queryData = queryData.Take(5).Distinct();//5表示显示5行
                    foreach (var item in queryData)
                    {
                        if (null == item)
                        {
                            continue;
                        }
                        if (i == 0)
                        {
                            i++;
                            stringBuilder.Append(@"{@BAR_CODE_NUM@:@" + item.BAR_CODE_NUM + "@");
                            stringBuilder.Append(",");
                            switch (id)//判断页面上选择的是那个输入框，从而判断value中的值
                            {
                                case "FACTORY_NUM":
                                 stringBuilder.Append(@"@value@:@" + item.FACTORY_NUM + "@");
                                    break;
                                case "VERSION":
                                    stringBuilder.Append(@"@value@:@" + item.VERSION + "@");
                                    break;
                                case "APPLIANCE_NAME":
                                    stringBuilder.Append(@"@value@:@" + item.APPLIANCE_NAME + "@");
                                    break;
                                default:
                                    break;
                            }
                            stringBuilder.Append(",");
                            stringBuilder.Append(@"@label@:@" + item.BAR_CODE_NUM +","+item.FACTORY_NUM+","+item.VERSION + ","+ item.APPLIANCE_NAME+ "@");
                            stringBuilder.Append(",");
                            stringBuilder.Append(@"@VERSION@:@" + item.VERSION + "@");
                            stringBuilder.Append(",");
                            stringBuilder.Append(@"@FACTORY_NUM@:@" + item.FACTORY_NUM + "@");
                            stringBuilder.Append(",");
                            stringBuilder.Append(@"@APPLIANCE_NAME@:@" + item.APPLIANCE_NAME + "@}");
                        }
                        else
                        {

                            stringBuilder.Append(",");
                            stringBuilder.Append(@"{@BAR_CODE_NUM@:@" + item.BAR_CODE_NUM + "@");
                            stringBuilder.Append(",");
                            switch (id)//判断页面上选择的是那个输入框，从而判断value中的值
                            {
                                case "FACTORY_NUM":
                                    stringBuilder.Append(@"@value@:@" + item.FACTORY_NUM + "@");
                                    break;
                                case "VERSION":
                                    stringBuilder.Append(@"@value@:@" + item.VERSION + "@");
                                    break;
                                case "APPLIANCE_NAME":
                                    stringBuilder.Append(@"@value@:@" + item.APPLIANCE_NAME + "@");
                                    break;
                                default:
                                    break;
                            }
                            stringBuilder.Append(",");
                            stringBuilder.Append(@"@label@:@" + item.BAR_CODE_NUM + "," + item.FACTORY_NUM + "," + item.VERSION + "," + item.APPLIANCE_NAME + "@");
                            stringBuilder.Append(",");
                            stringBuilder.Append(@"@VERSION@:@" + item.VERSION + "@");
                            stringBuilder.Append(",");
                            stringBuilder.Append(@"@FACTORY_NUM@:@" + item.FACTORY_NUM + "@");
                            stringBuilder.Append(",");
                            stringBuilder.Append(@"@APPLIANCE_NAME@:@" + item.APPLIANCE_NAME + "@}");
                        }
                    }
                }
            }

            stringBuilder.Append("]");
            return stringBuilder.ToString().Replace('@', '"');
        }


    }
}

