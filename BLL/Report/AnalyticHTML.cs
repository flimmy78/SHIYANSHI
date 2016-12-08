using System.Collections.Generic;
using System.Linq;
namespace Langben.Report
{
    /// <summary>
    /// 解析HTML文件
    /// </summary>
    public class AnalyticHTML
    {
        /// <summary>
        /// 获取表头中的所有的第一级tr标签
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>按照通道+节点的方式返回</returns>
        public static int GetTheadOfTR(HtmlAgilityPack.HtmlDocument doc)
        {
            Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> theadOfInputAndSelect = new Dictionary<int, HtmlAgilityPack.HtmlNodeCollection>();

            string xpath = @"//table[@id='tongdao_1']/thead/tr";
            var thead = doc.DocumentNode.SelectNodes(xpath);
            if (thead == null)
            {
                return 0;//表头下没有行
            }
            else
            {
                return thead.Count;
            }

        }
        /// <summary>
        /// 获取表头中的所有的input和select标签
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>按照通道+节点的方式返回</returns>
        public static Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> GetTheadOfInputAndSelect(HtmlAgilityPack.HtmlDocument doc)
        {
            Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> theadOfInputAndSelect = new Dictionary<int, HtmlAgilityPack.HtmlNodeCollection>();

            for (int i = 1; i < 99; i++)
            {
                string xpath = @"//table[@id='tongdao_" + i + @"']/thead//input[@type='text'] | //table[@id='tongdao_" + i + @"']/thead//select";
                var thead = doc.DocumentNode.SelectNodes(xpath);
                if (thead == null)
                {
                    return theadOfInputAndSelect;
                }
                else
                {
                    theadOfInputAndSelect.Add(i, thead);//表头下的所有input和select
                }
            }

            return theadOfInputAndSelect;//
        }
        /// <summary>
        /// 获取表体中的所有的input和select标签
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>按照通道+节点的方式返回</returns>
        public static Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> GetTBodyOfInputAndSelect(HtmlAgilityPack.HtmlDocument doc)
        {
            Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> theadOfInputAndSelect = new Dictionary<int, HtmlAgilityPack.HtmlNodeCollection>();

            for (int i = 1; i < 99; i++)
            {
                string xpath = @"//table[@id='tongdao_" + i + @"']/tbody//input[@type='text'] | //table[@id='tongdao_" + i + @"']/tbody//select";
                var thead = doc.DocumentNode.SelectNodes(xpath);
                if (thead == null)
                {
                    return theadOfInputAndSelect;
                }
                else
                {
                    theadOfInputAndSelect.Add(i, thead);//表体下的所有input和select
                }
            }

            return theadOfInputAndSelect;//
        }
        /// <summary>
        /// 获取表尾巴中的所有的input和select标签
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>按照通道+节点的方式返回</returns>
        public static Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> GetTfootOfInputAndSelect(HtmlAgilityPack.HtmlDocument doc)
        {
            Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> theadOfInputAndSelect = new Dictionary<int, HtmlAgilityPack.HtmlNodeCollection>();

            for (int i = 1; i < 99; i++)
            {
                string xpath = @"//table[@id='tongdao_" + i + @"']//tfoot//input[@type='text'] | //table[@id='tongdao_" + i + @"']//tfoot//select";
                var thead = doc.DocumentNode.SelectNodes(xpath);
                if (thead == null)
                {
                    return theadOfInputAndSelect;
                }
                else
                {
                    theadOfInputAndSelect.Add(i, thead);//所有input和select
                }
            }

            return theadOfInputAndSelect;//
        }

        public static string Getinput(HtmlAgilityPack.HtmlDocument doc)
        {
            string errors = "";
            string xpath = @"//input | //select";
            var collection = doc.DocumentNode.SelectNodes(xpath);
            Dictionary<string, string> ids = new Dictionary<string, string>();
            foreach (var item in collection)
            {
                if (string.IsNullOrWhiteSpace(item.Id))
                {
                    errors += item.XPath + "|Id没有";
                    continue;
                }
                else
                {
                    try
                    {
                        ids.Add(item.Id, item.XPath);
                    }
                    catch (System.Exception ex)
                    {
                        if(item.Attributes["name"] == null)
                        {
                            errors += item.Attributes["name"].Value;
                        }
                        errors += item.XPath + ex.Message + "|"+ item.Id;
                        continue;
                    }
                 
                }
                if (item.Name == "input")
                {
                    if (item.Attributes["type"] == null)
                    {
                        errors += item.XPath + "|type没有";
                    }
                    else if ((item.Attributes["type"].Value != "hidden") && item.Attributes["name"] == null)
                    {
                        errors += item.XPath + "|name没有";
                    }
                }
                else if (item.Name == "select")
                {
                    if (item.Attributes["name"] == null)
                    {
                        errors += item.XPath + "|selectname没有";
                    }
                }
            }

            return errors;
        }



        public static HtmlAgilityPack.HtmlNodeCollection GetTBodyOfInputAndSelect2(HtmlAgilityPack.HtmlDocument doc)
        {
            string xpath = @"//ruleid";
            return doc.DocumentNode.SelectNodes(xpath);


        }
        public static HtmlAgilityPack.HtmlNodeCollection GetTBodyOfInputAndSelect3(HtmlAgilityPack.HtmlDocument doc)
        {
            string xpath = @"//tabletitlelist/rowinfo[1]/rowindex";
            return doc.DocumentNode.SelectNodes(xpath);


        }

    }
}
