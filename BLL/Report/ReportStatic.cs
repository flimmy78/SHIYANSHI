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
                if (ConfigurationManager.AppSettings["TableTemplate_JiaoZhunXmlPath"] != null && ConfigurationManager.AppSettings["TableTemplate_JiaoZhunXmlPath"].Trim() != "")
                {
                    url = ConfigurationManager.AppSettings["TableTemplate_JiaoZhunXmlPath"].Trim();
                }
                else
                {
                    url = "~/ Xml /TableTemplate_JiaoZhun.xml";
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
        /// <summary>
        /// 检测项与等级关系
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// S化整比较名称
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, List<string>> SHuaZhengNames()
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            List<string> list = new List<string>();
            #region 平衡负载时有功电能误差
            list.Add("JISUANWUCHA");//校准结果的不确定度
            list.Add("ACTUALVALUE");//Ib(%)
            list.Add("READVALUE");//功率因素
            list.Add("OUTPUTVAL1_UNIT");//量程Ib单位
            list.Add("OUTPUTVAL1");//量程Ib值
            list.Add("OUTPUTVALUE_UNIT");//量程Un单位
            list.Add("OUTPUTVALUE");//量程Un值
            list.Add("RANGE");//相线及测量模式
            result.Add("P", list);
            #endregion

            #region 电能标准偏差估计值   
            list = new List<string>();      
            list.Add("READVALUE");//功率因素
            list.Add("OUTPUTVAL1_UNIT");//量程Ib单位
            list.Add("OUTPUTVAL1");//量程Ib值
            list.Add("OUTPUTVALUE_UNIT");//量程Un单位
            list.Add("OUTPUTVALUE");//量程Un值
            list.Add("RANGE");//相线及测量模式
            list.Add("JISUANWUCHA1");//s(%)

            result.Add("D", list);
            #endregion 
            return result;
        }
        /// <summary>
        /// s化整检测项ID关系
        /// </summary>
        /// <returns></returns>
        public static SHuaZhengRule SHuaZhengRules()
        {
            SHuaZhengRule result = new Report.SHuaZhengRule();
            result.DianNengBiaoZhunPianChaGuZhiJiSuan = "1085-2013_7";
            result.PingHengFuZaiShiYouGongDianNengWuCha = new List<string>();
            result.PingHengFuZaiShiYouGongDianNengWuCha.Add("1085-2013_6_3");
            result.PingHengFuZaiShiYouGongDianNengWuCha.Add("1085-2013_6_1");
            return result;

        }
        /// <summary>
        /// 检测项特殊注
        /// </summary>
        /// <returns></returns>
        public static List<Remark_Rules> RemarkRules()
        {
            List<Remark_Rules> result = new List<Remark_Rules>();
            Remark_Rules item = new Remark_Rules();
            #region 166-1993_3_1
            item.RuleID = "166-1993_3_1";
            item.RuleName = "1000Ω以下 - 无误差 - 有型号编号";
            item.Remark = "注：δn为标准电阻的相对修正值。</br>　　δx1、δx2分别为由正向及反向测量结果所得到的被测电阻的相对修正值。</br>　　δx =（δx1+δx2）/2".Replace("</br>", Environment.NewLine);
            //item.ImgUrl = "/Images/73_74.png";
            result.Add(item);
            #endregion

            #region 166-1993_3_2
            item = new Remark_Rules();
            item.RuleID = "166-1993_3_2";
            item.RuleName = "1000Ω以下-标准电阻-相对误差-无型号编号";
            item.Remark = "注：δn为标准电阻的相对修正值。</br>　　δx1、δx2分别为由正向及反向测量结果所得到的被测电阻的相对修正值。</br>　　δx =（δx1+δx2）/2".Replace("</br>", Environment.NewLine);
            //item.ImgUrl = "/Images/73_74.png";
            result.Add(item);
            #endregion

            #region 166-1993_3_3
            item = new Remark_Rules();
            item.RuleID = "166-1993_3_3";
            item.RuleName = "1000Ω以上-无误差";
            item.Remark = "注：Rn —  二等标准电阻的上级检定结果</br>　　Rx —  被测电阻的实际值</br>　　Ax —  本装置检定被测电阻时电压表示值</br>　　An —  本装置检定二等标准电阻时电压表示值</br>                 Rx = Rn + (Ax / I - An / I)".Replace("</br>", Environment.NewLine);
            //item.ImgUrl = string.Empty;
            result.Add(item);
            #endregion

            return result;

        }
        /// <summary>
        /// 第一位斜体特殊字符信息
        /// </summary>
        /// <returns></returns>
        public static List<string> FirstSpecialCharacter()
        {
            List<string> result = new List<string>();
            result.Add("U=100V");
            result.Add("U=100/√3V");
            result.Add("I=1A");
            result.Add("I=5A");
            return result;           
        }
        /// <summary>
        /// 特殊字符10号字体
        /// </summary>
        /// <returns></returns>
        public static List<string> SpecialCharacterFontHeightInPoints10()
        {
            List<string> result = new List<string>();
            //result.Add("U=100V");
            //result.Add("U=100/√3V");
            //result.Add("I=1A");
            //result.Add("I=5A");
            result.Add("ΔI/I");
            result.Add("ΔU/U");
            return result;
        }
        /// <summary>
        /// 备注特殊字符
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, List<SpecialCharacter>> RemarkSpecialCharacter()
        {
            Dictionary<string, List<SpecialCharacter>> result = new Dictionary<string, List<SpecialCharacter>>();
            List<SpecialCharacter> list = new List<SpecialCharacter>();
            SpecialCharacter item = new SpecialCharacter();
            item.Code = "δn";
            item.SubscriptLastCount = 1;
            list.Add(item);
            item = new SpecialCharacter();
            item.Code = "δx1";
            item.SubscriptLastCount = 2;
            list.Add(item);
            item = new SpecialCharacter();
            item.Code = "δx2";
            item.SubscriptLastCount = 2;
            list.Add(item);
            item = new SpecialCharacter();
            item.Code = "δx";
            item.SubscriptLastCount = 1;
            list.Add(item);
            result.Add("166-1993_3_1", list);
            result.Add("166-1993_3_2", list);

            list = new List<SpecialCharacter>();
            item = new SpecialCharacter();
            item.Code = "Rn";
            item.SubscriptLastCount = 1;
            list.Add(item);
            item = new SpecialCharacter();
            item.Code = "Rx";
            item.SubscriptLastCount = 1;
            list.Add(item);
            item = new SpecialCharacter();
            item.Code = "Ax";
            item.SubscriptLastCount = 1;
            list.Add(item);
            item = new SpecialCharacter();
            item.Code = "An";
            item.SubscriptLastCount = 1;
            list.Add(item);
            result.Add("166-1993_3_3", list);

            return result;
        }
        /// <summary>
        /// 获取特殊字符索引位置信息
        /// </summary>
        /// <param name="RuleID">检测项ID</param>
        /// <param name="RemarkStr">备注</param>
        /// <returns></returns>
        public static List<SpecialCharacter_Index> GetSpecialCharacter_Indexs(string RuleID,out string RemarkStr)
        {
            //RuleID = "166-1993_3_1";//测试
            RemarkStr = string.Empty;
            Dictionary<string, List<SpecialCharacter>> RemarkSpecialCharacterDic = RemarkSpecialCharacter();
            List<Remark_Rules> RemarkRulesList = RemarkRules();
            if (string.IsNullOrWhiteSpace(RuleID) || (RemarkSpecialCharacterDic == null || !RemarkSpecialCharacterDic.ContainsKey(RuleID) || RemarkSpecialCharacterDic[RuleID] == null || RemarkSpecialCharacterDic[RuleID].Count == 0)
                || (RemarkRulesList == null || RemarkRulesList.FirstOrDefault(p => p.RuleID == RuleID) == null || string.IsNullOrWhiteSpace(RemarkRulesList.FirstOrDefault(p => p.RuleID == RuleID).Remark)))
            {
                return null;
            }

            List<SpecialCharacter> Speciallist = RemarkSpecialCharacterDic[RuleID];
            Remark_Rules Remark = RemarkRulesList.FirstOrDefault(p => p.RuleID == RuleID);
            if(Remark!=null)
            {
                RemarkStr = Remark.Remark;
            }
            List<SpecialCharacter_Index> result = new List<SpecialCharacter_Index>();
            SpecialCharacter_Index item = new SpecialCharacter_Index();
            foreach (SpecialCharacter s in Speciallist)
            {
                int index = -2;
                int length = 0;
                while (index != -1 && index < Remark.Remark.Length - 1 - length)
                {
                    index = Remark.Remark.IndexOf(s.Code, index == -2 ? 0 : index + length);
                    if (index >= 0 && (result == null || result.FirstOrDefault(p => p.StartIndex == index) == null))
                    {
                        item = new SpecialCharacter_Index();
                        item.Code = s.Code;
                        item.StartIndex = index;
                        item.SubCount = s.SubscriptLastCount;
                        result.Add(item);
                        length = s.Code.Length;
                    }
                    else if(index >=0)
                    {
                        length = s.Code.Length;
                    }
                    else
                    {
                        break;
                    }
                }

            }
            return result;
        }


    }
}
