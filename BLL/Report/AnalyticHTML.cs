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
        public static int GetTBodyOfTR(HtmlAgilityPack.HtmlDocument doc)
        {
            Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> theadOfInputAndSelect = new Dictionary<int, HtmlAgilityPack.HtmlNodeCollection>();

            string xpath = @"//table[@id='tongdao_1']/tbody/tr";
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
        public static int GetContainTable(HtmlAgilityPack.HtmlDocument doc)
        {
            Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> theadOfInputAndSelect = new Dictionary<int, HtmlAgilityPack.HtmlNodeCollection>();

            string xpath = @"//table[@id='tongdao_1']/tbody//table";
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
        public static Dictionary<string, int> GetHead(HtmlAgilityPack.HtmlDocument doc)
        {
            var list = new Dictionary<string, int>();
            //只遍历通道1
            var tongdao1OfBodyOfInputAndSelect = GetTBodyOfInputAndSelect(doc)[1];
            if (tongdao1OfBodyOfInputAndSelect != null)
            {
                //将name去重       
                var tongdao1OfBodyOfInputAndSelectAttributes = (from b in tongdao1OfBodyOfInputAndSelect
                                                                    // where b.Attributes["name"] != null//hidden标签会为空
                                                                select b.Attributes["name"].Value).Distinct().ToList();

                for (int i = 0; i < tongdao1OfBodyOfInputAndSelectAttributes.Count; i++)
                {
                    list.Add(tongdao1OfBodyOfInputAndSelectAttributes[i], i);


                }
            }

            return list;
        }

        /// <summary>
        /// 获取表头中的所有的input和select标签
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>按照通道+节点的方式返回</returns>
        public static Dictionary<int, DataValue> GetData(HtmlAgilityPack.HtmlDocument doc)
        {
            var data = new Dictionary<int, DataValue>();

            int trCount = GetTBodyOfTR(doc);//最外层有几行
            int tableCount = GetContainTable(doc);//内部包含几个table
            Dictionary<string, int> head = GetHead(doc);//列头的名称

            Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> tbodyOfInputAndSelect = GetTBodyOfInputAndSelect(doc);//列

            foreach (var item in tbodyOfInputAndSelect.Keys)
            {
                HtmlAgilityPack.HtmlNodeCollection body = tbodyOfInputAndSelect[item];
                List<MYData> list = new List<MYData>();
                foreach (var b in body)
                {
                    MYData mydata = new MYData();
                    mydata.id = b.Attributes["id"].Value;
                    mydata.name = b.Attributes["name"].Value;
                    mydata.columnNum = head[mydata.name];
                    mydata.rowNum = GetRowNum(mydata.id);

                    if (string.IsNullOrWhiteSpace(b.ParentNode.GetAttributeValue("rowspan", string.Empty)))
                    {
                        mydata.mergedRowNum = 1;
                    }
                    else
                    {
                        int row = int.Parse(b.ParentNode.GetAttributeValue("rowspan", string.Empty));
                        if (row > 1)
                        {
                            var tr = 1;
                            var node = b.SelectNodes("../parent::*/parent::tbody/tr");
                            if (node != null)
                            {
                                tr = node.Count;

                            }
                            //谁小就是谁
                            mydata.mergedRowNum = (tr > row) ? row : tr;

                        }
                        else
                        {
                            mydata.mergedRowNum = 1;
                        }
                    }

                    list.Add(mydata);
                }

                var q =
     from p in list
     group p by p.name into g
     select new
    KeyValue()
     {
         Key = g.Key,
         Value = g.Sum(p => p.mergedRowNum)

     };
                var max = q.Select(s => s.Value).Max(m => m);
                var dat = from f in q
                          where f.Value < max
                          select f.Key;

                var change = from f in list
                             where dat.Contains(f.name)
                             select f;
                foreach (var it in change)
                {
                    if (it.mergedRowNum < 2)
                    {
                        throw new System.Exception("我没有遇到这要的情况");
                    }
                    it.mergedRowNum = max;

                }

                data.Add(item, new DataValue() { Count = max, Data = list });
            }

            return data;//
        }
        /// <summary>
        /// 根据id获取行号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static int GetRowNum(string id)
        {
            if (id.Contains("_UNIT_"))
            {
                var ids = id.Split('_');
                if (ids.Length == 5)
                {
                    return int.Parse(ids[4]);
                }
                else
                {
                    throw new System.Exception("id中没有行号" + id);

                }
            }
            else
            {
                var ids = id.Split('_');
                if (ids.Length == 4)
                {
                    return int.Parse(ids[3]);
                }
                else
                {
                    throw new System.Exception("id中没有行号" + id);

                }
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
                    if ((item.Name == "input")&&(item.Attributes["type"] != null)&& (item.Attributes["type"].Value == "hidden"))
                    {
                        continue;
                    }
                    try
                    {
                        ids.Add(item.Id, item.XPath);
                    }
                    catch (System.Exception ex)
                    {
                        if (item.Attributes["name"] == null)
                        {
                            errors += item.Attributes["name"].Value;
                        }
                        errors += item.XPath + ex.Message + "|" + item.Id;

                    }

                }
                if (item.Name == "input")
                {
                    if (item.Attributes["type"] == null)
                    {
                        errors += item.XPath + "|type没有" + item.Id;
                    }
                    else if ((item.Attributes["type"].Value != "hidden") && item.Attributes["name"] == null)
                    {
                        errors += item.XPath + "|name没有" + item.Id;
                    }


                }
                else if (item.Name == "select")
                {
                    if (item.Attributes["name"] == null)
                    {
                        errors += item.XPath + "|selectname没有" + item.Id;
                    }
                }

                if (item.Attributes["name"] != null)
                {
                    if (!item.Id.Contains(item.Attributes["name"].Value))
                    {
                        errors += item.XPath + "|name和id不一致" + item.Attributes["name"].Value + "|" + item.Id;
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
