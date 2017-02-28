using Langben.DAL;
using Langben.DAL.shiyanshi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

//using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.HSSF.Util;
using NPOI.POIFS.FileSystem;
//using NPOI.SS.UserModel;

using Langben.BLL;
using System.IO;
using Langben.IBLL;
using Common;

namespace Langben.Report
{
    public partial class ReportRule
    {
        public string ruleid { get; set; }
        public int ruleidnum { get; set; }
        public string biaoshi { get; set; }
        public int biaoshinum { get; set; }

    }
    /// <summary>
    /// 报告业务逻辑
    /// </summary>
    public partial class ReportBLL
    {

        public bool Test(string ID, out string Message)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string errors = string.Empty;
            IBLL.IPREPARE_SCHEMEBLL m_BLL = new PREPARE_SCHEMEBLL();
            PREPARE_SCHEME entity = m_BLL.GetById(ID);
            string saveFileName = "";
            if (entity != null)
            {
                ExportType type = GetExportType(entity, "ExportOriginal");

                if (entity.QUALIFIED_UNQUALIFIED_TEST_ITE != null &&
              entity.QUALIFIED_UNQUALIFIED_TEST_ITE.Count > 0)
                {
                    TableTemplates allTableTemplates = GetTableTemplates(type);
                    SpecialCharacters allSpecialCharacters = GetSpecialCharacters();

                    entity.QUALIFIED_UNQUALIFIED_TEST_ITE = entity.QUALIFIED_UNQUALIFIED_TEST_ITE.OrderBy(p => p.SORT).ToList();
                    string xml = string.Empty;
                    foreach (QUALIFIED_UNQUALIFIED_TEST_ITE iEntity in entity.QUALIFIED_UNQUALIFIED_TEST_ITE)
                    {
                        //iEntity.RULEID;
                        if (!string.IsNullOrWhiteSpace(iEntity.HTMLVALUE))
                        {
                            doc.LoadHtml(iEntity.HTMLVALUE);


                            //测试的时候使用
                            string data = AnalyticHTML.Getinput(doc);
                            if (!string.IsNullOrWhiteSpace(data))
                            {
                                errors += iEntity.ID + iEntity.RULENJOINAME + data;
                            }
                        }

                    }
                    var da = xml;
                }
            }
            Message = errors;
            return false;
        }
        public bool Testxml(string ID, out string Message)
        {


            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string errors = string.Empty;
            var m_BLL = new SCHEMEBLL();
            var entity = m_BLL.GetById(ID);



            // string xlsPath = @"D:\codes\SHIYANSHI\App\Template\原始记录-数据模板-数表三相.xls";//TableTemplateXml
            //原始记录 - /*校准*/
                string xlsPath = @"D:\codes\SHIYANSHI\App\Template\原始记录-校准.xls";//TableTemplateXml

            HSSFWorkbook _book = new HSSFWorkbook();
            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
            IWorkbook hssfworkbook = new HSSFWorkbook(file);
            string sheetName_Destination = "数据模板";
            ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);
            int rowCount = sheet_Destination.LastRowNum;
            var list = new List<ReportRule>();
            int flo = 0;
            for (int i = 0; i <= rowCount; ++i)
            {
                IRow row = sheet_Destination.GetRow(i);
                if (row == null) continue; //没有数据的行默认是null　　　　　　　

                for (int j = 67; j <= 69; ++j)
                {
                    if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                    {
                        ReportRule rr = new Report.ReportRule();
                        string s = row.GetCell(j).ToString();
                        if (!string.IsNullOrWhiteSpace(s))
                        {
                            if (j == 67)
                            {
                                var datadouhoa = s.Split(',');
                                foreach (var item in datadouhoa)
                                {
                                    rr.ruleid = item.Trim();

                                    rr.ruleidnum = i;
                                    flo++;
                                    list.Add(rr);
                                }

                            }
                            else
                            {
                                rr.biaoshi = s.Trim().ToUpper();
                                rr.biaoshinum = i;
                                flo++;
                                list.Add(rr);
                            }


                        }

                    }
                }

            }



            TableTemplates allTableTemplates = GetTableTemplates();
            var ruleids = (from f in allTableTemplates.TableTemplateList

                           select f.RuleID);
            if (entity != null)
            {

                if (entity.PROJECTTEMPLET != null &&
              entity.PROJECTTEMPLET.Count > 0)
                {


                    foreach (var iEntity in entity.PROJECTTEMPLET)
                    {
                        if (!string.IsNullOrWhiteSpace(iEntity.HTMLVALUE))
                        {
                            doc.LoadHtml(iEntity.HTMLVALUE);

                            //测试获取数据的时候使用
                            //var data1 = AnalyticHTML.GetData(doc);
                            //var data2 = AnalyticHTML.GetHeadData(doc);
                            if (!ruleids.Contains(iEntity.RULEID))
                            {
                                string s = CreatXML.Create(doc, iEntity.RULEID);

                                errors += s;
                            }

                        }
                        else
                        {

                        }

                    }
                }
            }
            Message = @"<TableTemplates><TableTemplateList>
 " + errors + @"
</TableTemplateList></TableTemplates>";

            TableTemplates allTableTemplates2 = TableTemplates.XmlCovertObj(Message);
            var data = (
                        from f2 in allTableTemplates2.TableTemplateList

                        select f2).Distinct().ToList();
            TableTemplates t = new TableTemplates();
            t.TableTemplateList = new List<TableTemplate>();
            var dsaf =new List<string>();
            foreach (var item in data)
            {
                var rrd = (from l in list
                          where l.ruleid != null
                          select l);
                var rr = (from l in list
                          where l.ruleid == item.RuleID
                          select l).FirstOrDefault();
                if (rr==null)
                {
                    dsaf.Add(item.RuleID);
                    continue;
                }
                ReportRule rr2 = (from l in list
                           where l.ruleid != null && l.ruleidnum > rr.ruleidnum
                           select l).FirstOrDefault();

                if (rr2==null)
                {
                    rr2 = (from l in list
                          
                           select l).Last();
                }
                ////////////////
                var rrbiaoshi = (from l in list
                                 where l.biaoshinum >= rr.ruleidnum && l.biaoshinum <= rr2.ruleidnum
                                 select l);

                var BODY = rrbiaoshi.Where(c => c.biaoshi == "BODY").FirstOrDefault();

                if (BODY != null)
                {
                    item.DataRowIndex = BODY.biaoshinum + 2;//数据模板开始行号
                }
                var ZHU = rrbiaoshi.Where(c => c.biaoshi == "ZHU").FirstOrDefault();

                if (ZHU != null)
                {
                    item.RemarkRowIndex = ZHU.biaoshinum+2;//备注模板行号
                }
                var JIELUN = rrbiaoshi.Where(c => c.biaoshi == "JIELUN").FirstOrDefault();

                if (JIELUN != null)
                {
                    item.ConclusionRowIndex = JIELUN.biaoshinum + 2;//结论模板行号
                }

                //if (item.IsHaveTableTitle)
                {
                    var countData= (from f in rrbiaoshi
                                where f.biaoshi == "HEAD"
                                select f);
                    if (countData!=null && countData.Count() > 0)
                    {
                        item.TableTitleList.First().RowIndex = countData.First().biaoshinum + 2;
                        item.TableTitleList.First().RowNumber = countData.Count();
                    }

                  
                }

                //if (item.IsHaveTableFooter)
                {
                    var countData = (from f in rrbiaoshi
                                     where f.biaoshi == "BUQUEDINGDU"
                                     select f);
                    if (countData != null&& countData.Count()>0)
                    {
                        item.TableFooterList.First().RowIndex = countData.First().biaoshinum + 2;
                        item.TableFooterList.First().RowNumber = countData.Count();
                    }

                }
                t.TableTemplateList.Add(item);


            }

            Message = t.ToString();
            return false;


        }
        public bool TestPROJECTTEMPLET(string ID, out string Message)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string errors = string.Empty;
            var m_BLL = new SCHEMEBLL();
            var entity = m_BLL.GetById(ID);

            if (entity != null)
            {

                if (entity.PROJECTTEMPLET != null &&
              entity.PROJECTTEMPLET.Count > 0)
                {


                    foreach (var iEntity in entity.PROJECTTEMPLET)
                    {
                        if (!string.IsNullOrWhiteSpace(iEntity.HTMLVALUE))
                        {
                            doc.LoadHtml(iEntity.HTMLVALUE);
                            string data = AnalyticHTML.Getinput(doc);
                            AnalyticHTML.GetData(doc);
                            string data2 = AnalyticHTML.GetinputHead(doc);
                            if (!string.IsNullOrWhiteSpace(data2))
                            {
                                errors += "<br/><br/>thead标签中，name是不能相同的" + iEntity.ID + iEntity.RULE.ID + iEntity.RULE.NAMEOTHER + data2;
                            }
                            if (!string.IsNullOrWhiteSpace(data))
                            {
                                errors += iEntity.ID + iEntity.RULE.ID + iEntity.RULE.NAMEOTHER + data;
                            }

                        }

                    }
                }
            }
            Message = errors;
            return false;
        }


    }
}
