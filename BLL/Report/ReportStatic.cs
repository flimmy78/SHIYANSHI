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
        /// 原始记录模板配置文件xml内容
        /// </summary>
        public static string TableTemplateXml
        {
            get
            {
                string url = string.Empty;
                if (ConfigurationManager.AppSettings["TableTemplateXmlPath"] != null && ConfigurationManager.AppSettings["TableTemplateXmlPath"].Trim() != "")
                {
                    url = ConfigurationManager.AppSettings["TableTemplateXmlPath"].Trim();
                }
                else
                {
                    url = "../ Xml / TableTemplate.xml";
                }
                return Common.DirFile.ReadFile(url);
            }
        }
        /// <summary>
        /// 检定报告模板配置文件xml内容
        /// </summary>
        public static string TableTemplate_JianDingXml
        {
            get
            {
                string url = string.Empty;
                if (ConfigurationManager.AppSettings["TableTemplate_JianDingXmlPath"] != null && ConfigurationManager.AppSettings["TableTemplate_JianDingXmlPath"].Trim() != "")
                {
                    url = ConfigurationManager.AppSettings["TableTemplate_JianDingXmlPath"].Trim();
                }
                else
                {
                    url = "../ Xml /TableTemplate_JianDing.xml";
                }
                return Common.DirFile.ReadFile(url);
            }
        }
        /// <summary>
        /// 校准报告模板配置文件xml内容
        /// </summary>
        public static string TableTemplate_JiaoZhunXml
        {
            get
            {
                string url = string.Empty;
                if(ConfigurationManager.AppSettings["TableTemplate_JiaoZhunXmlPath"] !=null && ConfigurationManager.AppSettings["TableTemplate_JiaoZhunXmlPath"].Trim()!="")
                {
                    url= ConfigurationManager.AppSettings["TableTemplate_JiaoZhunXmlPath"].Trim();
                }
                else
                {
                    url= "../ Xml /TableTemplate_JiaoZhun.xml";
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

        /// <summary>
        /// 检定证书模板文件绝对路径
        /// </summary>
        public static string BaoGaoJianDingPath
        {
            get
            {
                string path = string.Empty;
                if (ConfigurationManager.AppSettings["BaoGaoJianDingPath"] != null && ConfigurationManager.AppSettings["BaoGaoJianDingPath"].Trim() != "")
                {
                    path = ConfigurationManager.AppSettings["BaoGaoJianDingPath"].Trim();
                }
                else
                {
                    path = "../Template/检定证书.xls";
                }
                path = System.Web.HttpContext.Current.Server.MapPath(path);
                return path;
            }
        }

        /// <summary>
        /// 校准非CNAS证书模板文件绝对路径
        /// </summary>
        public static string BaoGaoXiaoZhunPath
        {
            get
            {
                string path = string.Empty;
                if (ConfigurationManager.AppSettings["BaoGaoXiaoZhunPath"] != null && ConfigurationManager.AppSettings["BaoGaoXiaoZhunPath"].Trim() != "")
                {
                    path = ConfigurationManager.AppSettings["BaoGaoXiaoZhunPath"].Trim();
                }
                else
                {
                    path = "../Template/校准证书.xls";
                }
                path = System.Web.HttpContext.Current.Server.MapPath(path);
                return path;
            }
        }
        /// <summary>
        /// 校准CNAS证书模板文件绝对路径
        /// </summary>
        public static string BaoGaoXiaoZhunCNASPath
        {
            get
            {
                string path = string.Empty;
                if (ConfigurationManager.AppSettings["BaoGaoXiaoZhunCNASPath"] != null && ConfigurationManager.AppSettings["BaoGaoXiaoZhunCNASPath"].Trim() != "")
                {
                    path = ConfigurationManager.AppSettings["BaoGaoXiaoZhunCNASPath"].Trim();
                }
                else
                {
                    path = "../Template/校准证书-CNAS.xls";
                }
                path = System.Web.HttpContext.Current.Server.MapPath(path);
                return path;
            }
        }
    }
}
