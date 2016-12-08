﻿using System.Collections.Generic;
using System.Linq;

namespace Langben.Report
{
    /// <summary>
    /// 解析HTML文件
    /// </summary>
    public class CreatXML
    {


        public static string tempRowNumber = @"
          <RowNumber>{1}</RowNumber>
            {0}
";
        public static string tempCellList = @"
          <CellList>
            {0}
          </CellList>
";
        public static string tempCell = @"
            <Cell>
              <Code>{0}</Code>
              <!--在页面中的排序-->
              <Name>{1}</Name>
              <ColIndex></ColIndex>             
            </Cell>
";
        public static void Create(HtmlAgilityPack.HtmlDocument doc)
        {
            //表头
            Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> theadOfInputAndSelect = AnalyticHTML.GetTheadOfInputAndSelect(doc);
            //表身
            Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> tbodyOfInputAndSelect = AnalyticHTML.GetTBodyOfInputAndSelect(doc);
            //表尾巴
            Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> tfootOfInputAndSelect = AnalyticHTML.GetTfootOfInputAndSelect(doc);
            //表头的xml字符串
            string outHead = "";

            //只遍历通道1
            var tongdao1 = theadOfInputAndSelect[1];
            for (int i = 0; i < tongdao1.Count; i++)
            {
                outHead += string.Format(tempCell, tongdao1[i].Attributes["name"].Value, i);

            }
            outHead = string.Format(tempCellList, outHead);

            outHead = string.Format(tempRowNumber, outHead, AnalyticHTML.GetTheadOfTR(doc));

            //表体的xml字符串
            string outBody = "";

            //只遍历通道1
            var tongdao1OfBodyOfInputAndSelect = tbodyOfInputAndSelect[1];
            //将name去重       
            var tongdao1OfBodyOfInputAndSelectAttributes = (from b in tongdao1OfBodyOfInputAndSelect
                                                                // where b.Attributes["name"] != null//hidden标签会为空
                                                            select b.Attributes["name"].Value).Distinct().ToList();

            for (int i = 0; i < tongdao1OfBodyOfInputAndSelectAttributes.Count; i++)
            {
                outBody += string.Format(tempCell, tongdao1OfBodyOfInputAndSelectAttributes[i], i);

            }
            outBody += string.Format(tempCellList, outBody);

            //表格xml
            string outXML = "";
            outXML = string.Format(temp,
                ""/*RuleID*/,
                ""/*数据模板开始行号*/,
                 ""/*备注模板行号*/,
                  ""/*结论模板行号*/,
                   ""/*表格表头行号*/,
                    outHead,
                    outBody);



            var d = 0;

        }
        public static string temp = @"
    <TableTemplate>
      <RuleID>{0}</RuleID>
      <!--数据模板开始行号-->
      <DataRowIndex>{1}</DataRowIndex>
      <!--备注模板行号-->
      <RemarkRowIndex>{2}</RemarkRowIndex>
      <!--结论模板行号-->
      <ConclusionRowIndex>{3}</ConclusionRowIndex>
      <TableTitleList>
        <RowInfo>     
          <!--表格表头行号-->   
          <RowIndex>{4}</RowIndex>
{5}
        </RowInfo>
      </TableTitleList>
{6}
    </TableTemplate>
";
    }
}