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
                    url = "~/Xml/TableTemplate.xml";
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
                    url = "~/ Xml /TableTemplate_JianDing.xml";
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
                    url= "~/ Xml /TableTemplate_JiaoZhun.xml";
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
                    url = "~/ Xml / SpecialCharacter.xml";
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
                    path = "~/Template/原始记录-校准.xls";
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
                    path = "~/Template/原始记录-检定.xls";
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
                    path = "~/Template/检定证书.xls";
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
                    path = "~/Template/校准证书.xls";
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
                    path = "~/Template/校准证书-CNAS.xls";
                }
                path = System.Web.HttpContext.Current.Server.MapPath(path);
                return path;
            }
        }
        public static List<Rule_DengJi> Rule_DengJiList()
        {
            List<Rule_DengJi> list = new List<Rule_DengJi>();
            Rule_DengJi item = new Rule_DengJi();
            #region 125-2004_9_1单桥-基本量程-相对误差
            //如果等级数目 >= 0.1，比如0.2；那么检定证书合格，检定项目就标注合格，不用出数据。如果不合格，所有检定项目都需要给出数据。如果是0.01等 < 0.1,检定证书都要给出数据。校准证书无论等级如何都需要给出数据。
            item.RuleID = "125-2004_9_1";
            item.RuleName = "单桥-基本量程-相对误差";           
            item.DengJi = 0.1;           
            item.IsXuYaoHeGe = true;           
            list.Add(item);

            #endregion

            #region 125-2004_9_2单桥-其他量程-相对误差            
            //如果等级数目>=0.1，比如0.2；那么检定证书合格，检定项目就标注合格，不用出数据。如果不合格，所有检定项目都需要给出数据。如果是0.01等<0.1,检定证书都要给出数据。校准证书无论等级如何都需要给出数据。
            item = new Rule_DengJi();
            item.RuleID = "125-2004_9_2";
            item.RuleName = "单桥-其他量程-相对误差";            
            item.DengJi = 0.1;          
            item.IsXuYaoHeGe = true;
            
            list.Add(item);
            #endregion

            #region 125-2004_9_3双桥-基本量程-滑线盘步进盘-相对误差        
            //如果等级数目>=0.1，比如0.2；那么检定证书合格，检定项目就标注合格，不用出数据。如果不合格，所有检定项目都需要给出数据。如果是0.01等<0.1,检定证书都要给出数据。校准证书无论等级如何都需要给出数据。
            item = new Rule_DengJi();
            item.RuleID = "125-2004_9_3";
            item.RuleName = "双桥-基本量程-滑线盘步进盘-相对误差";           
            item.DengJi = 0.1;           
            item.IsXuYaoHeGe = true;            
            list.Add(item);
            #endregion

            #region 125-2004_9_4双桥-其他量程-相对误差
            //如果等级数目>=0.1，比如0.2；那么检定证书合格，检定项目就标注合格，不用出数据。如果不合格，所有检定项目都需要给出数据。如果是0.01等<0.1,检定证书都要给出数据。校准证书无论等级如何都需要给出数据。
            item = new Rule_DengJi();
            item.RuleID = "125-2004_9_4";
            item.RuleName = "双桥-其他量程-相对误差";            
            item.DengJi = 0.1;           
            item.IsXuYaoHeGe = true;            
            list.Add(item);
            #endregion

            #region 622-1997_3基本误差检定
            //1.被试设备的准确度等级<=10.0,例如设备准确度为15.0时,出非表格																												
            //2.被试设备的准确度等级 > 10.0,例如设备准确度为9.0时，出表格
            item = new Rule_DengJi();
            item.RuleID = "622-1997_3";
            item.RuleName = "基本误差检定";           
            item.DengJi = 10;           
            item.IsXuYaoHeGe = false;           
            list.Add(item);
            #endregion

            #region 622-1997_4钮端电压
            //1.被试设备的准确度等级<=10.0,例如设备准确度为15.0时,出非表格																												
            //2.被试设备的准确度等级 > 10.0,例如设备准确度为9.0时，出表格
            item = new Rule_DengJi();
            item.RuleID = "622-1997_4";
            item.RuleName = "钮端电压";
            item.DengJi = 10;
            item.IsXuYaoHeGe = false;
            list.Add(item);
            #endregion

            #region 1005-2005_4钮端电压
            //1.被试设备的准确度等级<=10.0,例如设备准确度为15.0时,出非表格																												
            //2.被试设备的准确度等级 > 10.0,例如设备准确度为9.0时，出表格
            item = new Rule_DengJi();
            item.RuleID = "1005-2005_4";
            item.RuleName = "钮端电压";
            item.DengJi = 10;
            item.IsXuYaoHeGe = false;
            list.Add(item);
            #endregion

            #region 622-1997_5钮端电压稳定性
            //1.被试设备的准确度等级<=10.0,例如设备准确度为15.0时,出非表格																												
            //2.被试设备的准确度等级 > 10.0,例如设备准确度为9.0时，出表格
            item = new Rule_DengJi();
            item.RuleID = "622-1997_5";
            item.RuleName = "钮端电压稳定性";
            item.DengJi = 10;
            item.IsXuYaoHeGe = false;
            list.Add(item);
            #endregion

            #region 622-1997_6倾斜影响
            //1.被试设备的准确度等级<=10.0,例如设备准确度为15.0时,出非表格																												
            //2.被试设备的准确度等级 > 10.0,例如设备准确度为9.0时，出表格
            item = new Rule_DengJi();
            item.RuleID = "622-1997_6";
            item.RuleName = "倾斜影响";
            item.DengJi = 10;
            item.IsXuYaoHeGe = false;
            list.Add(item);
            #endregion

            #region 366-2004_4_1电子式示值误差
            //1.被试设备的准确度等级>=2.0,例如设备准确度为3.0时	,出非表格																												
            //2.被试设备的准确度等级<2.0,例如设备准确度为1.0时，出表格
            item = new Rule_DengJi();
            item.RuleID = "366-2004_4_1";
            item.RuleName = "电子式示值误差";
            item.DengJi = 2;
            item.IsXuYaoHeGe = false;
            list.Add(item);
            #endregion

            #region 366-2004_4_2指针式示值误差
            //1.被试设备的准确度等级>=2.0,例如设备准确度为3.0时	,出非表格																												
            //2.被试设备的准确度等级<2.0,例如设备准确度为1.0时，出表格
            item = new Rule_DengJi();
            item.RuleID = "366-2004_4_2";
            item.RuleName = "指针式示值误差";
            item.DengJi = 2;
            item.IsXuYaoHeGe = false;
            list.Add(item);
            #endregion

            #region 366-2004_5位置影响
            //1.被试设备的准确度等级>=2.0,例如设备准确度为3.0时	,出非表格																												
            //2.被试设备的准确度等级<2.0,例如设备准确度为1.0时，出表格
            item = new Rule_DengJi();
            item.RuleID = "366-2004_5";
            item.RuleName = "位置影响";
            item.DengJi = 2;
            item.IsXuYaoHeGe = false;
            list.Add(item);
            #endregion

            #region 366-2004_6_1电子式辅助电阻影响
            //1.被试设备的准确度等级>=2.0,例如设备准确度为3.0时	,出非表格																												
            //2.被试设备的准确度等级<2.0,例如设备准确度为1.0时，出表格
            item = new Rule_DengJi();
            item.RuleID = "366-2004_6_1";
            item.RuleName = "电子式辅助电阻影响";
            item.DengJi = 2;
            item.IsXuYaoHeGe = false;
            list.Add(item);
            #endregion

            #region 366-2004_6_2指针式辅助电阻影响
            //1.被试设备的准确度等级>=2.0,例如设备准确度为3.0时	,出非表格																												
            //2.被试设备的准确度等级<2.0,例如设备准确度为1.0时，出表格
            item = new Rule_DengJi();
            item.RuleID = "366-2004_6_2";
            item.RuleName = "指针式辅助电阻影响";
            item.DengJi = 2;
            item.IsXuYaoHeGe = false;
            list.Add(item);
            #endregion

            return list;


        }
    }
}
