using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.Report
{
    /// <summary>
    /// 报告
    /// </summary>
    public class ReportStatic
    {
        /// <summary>
        /// 报告模板配置文件xml内容
        /// </summary>
        public static string  TableTemplateXml
        {
            get
            {
                string url = string.Empty;
                if(ConfigurationManager.AppSettings["TableTemplateXmlPath"]!=null && ConfigurationManager.AppSettings["TableTemplateXmlPath"].Trim()!="")
                {
                    url= ConfigurationManager.AppSettings["TableTemplateXmlPath"].Trim();
                }
                else
                {
                    url= "../ Xml / TableTemplate.xml";
                }
                return Common.DirFile.ReadFile(url);
            }
        }
        /// <summary>
        /// 特殊字符xml内容
        /// </summary>
        public static string SpecialCharacterXml
        {
            get
            {
                string url = string.Empty;
                if (ConfigurationManager.AppSettings["SpecialCharacterXmlPath"] != null && ConfigurationManager.AppSettings["SpecialCharacterXmlPath"].Trim() != "")
                {
                    url = ConfigurationManager.AppSettings["SpecialCharacterXmlPath"].Trim();
                }
                else
                {
                    url = "../ Xml / SpecialCharacter.xml";
                }
                return Common.DirFile.ReadFile(url);
            }
        }
        /// <summary>
        /// 原始记录校准模板文件绝对路径
        /// </summary>
        public static string YuanShiJiLuXiaoZhunPath
        {
            get
            {
                string path = string.Empty;
                if (ConfigurationManager.AppSettings["YuanShiJiLuXiaoZhunPath"] != null && ConfigurationManager.AppSettings["YuanShiJiLuXiaoZhunPath"].Trim() != "")
                {
                    path = ConfigurationManager.AppSettings["YuanShiJiLuXiaoZhunPath"].Trim();
                }
                else
                {
                    path = "../Template/原始记录-校准.xls";
                }               
                path = System.Web.HttpContext.Current.Server.MapPath(path);
                return path;
            }
        }

        /// <summary>
        /// 原始记录检定模板文件绝对路径
        /// </summary>
        public static string YuanShiJiLuJianDingPath
        {
            get
            {
                string path = string.Empty;
                if (ConfigurationManager.AppSettings["YuanShiJiLuJianDingPath"] != null && ConfigurationManager.AppSettings["YuanShiJiLuJianDingPath"].Trim() != "")
                {
                    path = ConfigurationManager.AppSettings["YuanShiJiLuJianDingPath"].Trim();
                }
                else
                {
                    path = "../Template/原始记录-检定.xls";
                }
                path = System.Web.HttpContext.Current.Server.MapPath(path);
                return path;
            }
        }
    }
}
