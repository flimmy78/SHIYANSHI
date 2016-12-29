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

using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Filters;
using Langben.BLL;
using System.IO;
using Langben.IBLL;
using Common;

namespace Langben.Report
{
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
            var dsaf = 1;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string errors = string.Empty;
            var m_BLL = new SCHEMEBLL();
            var entity = m_BLL.GetById(ID);
            TableTemplates allTableTemplates = GetTableTemplates();
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
                            var data1 = AnalyticHTML.GetData(doc);
                            var data2 = AnalyticHTML.GetHeadData(doc);
                            //不确定度的
                            var sadf = AnalyticHTML.GetBuDueDingDu(doc);
                            string s = CreatXML.Create(doc, iEntity.RULEID);
                            if (string.IsNullOrWhiteSpace(s))
                            {
                                dsaf++;
                            }
                            errors += s;
                        }
                        else
                        {
                            dsaf++;
                        }

                    }
                }
            }
            Message = @"<TableTemplates><TableTemplateList>
 " + errors + @"
</TableTemplateList></TableTemplates>";

            TableTemplates allTableTemplates2 = TableTemplates.XmlCovertObj(Message);
            var data = (from f in allTableTemplates.TableTemplateList
                        from f2 in allTableTemplates2.TableTemplateList
                        where f.RuleID == f2.RuleID

                        select f2).ToList();
            TableTemplates t = new TableTemplates();
            t.TableTemplateList = new List<TableTemplate>();

            foreach (var item in data)
            {
                var TableTemplate = (from f in allTableTemplates.TableTemplateList
                                     where f.RuleID == item.RuleID
                                     select f).FirstOrDefault();

                item.DataRowIndex = TableTemplate.DataRowIndex + 2;//数据模板开始行号
                item.RemarkRowIndex = TableTemplate.RemarkRowIndex + 2;//备注模板行号
                item.ConclusionRowIndex = TableTemplate.ConclusionRowIndex + 2;//结论模板行号
                item.Remark = TableTemplate.Remark;//

                var RowInfo = (from f in TableTemplate.TableTitleList

                               select f).FirstOrDefault();
                if (RowInfo != null)
                {
                    foreach (var it in item.TableTitleList)
                    {
                        it.RowIndex = RowInfo.RowIndex + 2;//表格表头行号
                    }
                }

                var Cells = (from f in TableTemplate.Cells

                             select f);
                if (Cells != null)
                {
                    foreach (var it in item.Cells)
                    {
                        var ishide = (from f in Cells
                                      where f.Code == it.Code
                                      select f.IsHideRowNull).FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(ishide))
                        {
                            it.IsHideRowNull = ishide;
                        }

                        var IsMergeSameValue = (from f in Cells
                                                where f.Code == it.Code
                                                select f.IsMergeSameValue).FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(IsMergeSameValue))
                        {
                            it.IsMergeSameValue = IsMergeSameValue;
                        }
                        var Name = (from f in Cells
                                    where f.Code == it.Code
                                    select f.Name).FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(Name))
                        {
                            it.Name = Name;
                        }
                    }
                }

                t.TableTemplateList.Add(item);
            }

            Message = t.ToString();
            return false;


        }
        public bool TestxmlDistinct(string ID, out string Message)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string errors = string.Empty;
            var m_BLL = new SCHEMEBLL();
            var entity = m_BLL.GetById(ID);
            TableTemplates allTableTemplates = GetTableTemplates();



            var data = (from f in allTableTemplates.TableTemplateList


                        select f.RuleID).ToList();

            var dis = data.Distinct();


            TableTemplates t = new TableTemplates();
            t.TableTemplateList = new List<TableTemplate>();
            foreach (var item in dis)
            {

                var datafirst = (from f in allTableTemplates.TableTemplateList

                                 where f.RuleID == item
                                 select f).First();
                t.TableTemplateList.Add(datafirst);


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
                            if (!string.IsNullOrWhiteSpace(data))
                            {
                                errors += iEntity.ID + iEntity.RULE.NAME + data;
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
