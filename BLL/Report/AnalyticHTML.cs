using System.Collections.Generic;
using System.Linq;
namespace Langben.Report
{
    /// <summary>
    /// 解析HTML文件
    /// </summary>
    public class AnalyticHTML
    {
        public static HtmlAgilityPack.HtmlDocument docBuQueDingDu = new HtmlAgilityPack.HtmlDocument();
        /// <summary>
        /// 不确定解析
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static BuDueDingDu GetBuDueDingDu(string url)
        {
            BuDueDingDu buDueDingDu = new BuDueDingDu();
            docBuQueDingDu.Load(url);

            string xpath = @"//select[@tag='only']";
            var allselected = docBuQueDingDu.DocumentNode.SelectNodes(xpath);

            foreach (var b in allselected)
            {
                var node = b.ChildNodes
                                    .Where(w => (w.Name == "option" && w.Attributes["selected"] != null) ? (w.Name == "option" && w.Attributes["selected"] != null) : (w.Name == "option"))
                                    .Select(s => s.Attributes["value"].Value).First();

                if (node != null)
                {
                    if (b.Attributes["id"].Value == "pdDDL")
                    { 
                        buDueDingDu.pdDDL = node;
                    }
                    else if (b.Attributes["id"].Value == "ddlSelectD")
                    {
                        buDueDingDu.ddlSelectD = node;
                    }

                }                 
            }

            var xpathA = @"//input[@tag='only']";
            var A = docBuQueDingDu.DocumentNode.SelectNodes(xpathA);
            foreach (var item in A)
            {
                if (item.Attributes["id"].Value == "pdText")
                {
                    buDueDingDu.pdText = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "txtBuQueDingA")
                {
                    buDueDingDu.txtBuQueDingA = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "txtValue")
                {
                    buDueDingDu.txtValue = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "A_1_1")
                {
                    buDueDingDu.A_1_1 = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "A_1_2")
                {
                    buDueDingDu.A_1_2 = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "A_1_3")
                {
                    buDueDingDu.A_1_3 = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "A_1_4")
                {
                    buDueDingDu.A_1_4 = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "A_1_5")
                {
                    buDueDingDu.A_1_5 = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "A_2_1")
                {
                    buDueDingDu.A_2_1 = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "A_2_2")
                {
                    buDueDingDu.A_2_2 = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "A_2_3")
                {
                    buDueDingDu.A_2_3 = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "A_2_4")
                {
                    buDueDingDu.A_2_4 = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "A_2_5")
                {
                    buDueDingDu.A_2_5 = item.Attributes["value"].Value;
                }

                else if (item.Attributes["id"].Value == "txtBuQueDingB")
                {
                    buDueDingDu.txtBuQueDingB = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "txtValueB")
                {
                    buDueDingDu.txtValueB = item.Attributes["value"].Value;
                }




                else if (item.Attributes["id"].Value == "txtBuQueDingC")
                {
                    buDueDingDu.txtBuQueDingC = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "txtvalueD")
                {
                    buDueDingDu.txtvalueD = item.Attributes["value"].Value;
                }
                else if (item.Attributes["id"].Value == "txtValueE")
                {
                    buDueDingDu.txtValueE = item.Attributes["value"].Value;
                }
            }
            Dictionary<string, int> head = new Dictionary<string, int>();
            head.Add("pingding1", 1);
            head.Add("pingding2", 2);
            head.Add("pingding3", 3);
            double i = 0;
            var xpathpingding = @"//ul[@tag='pingding']//input[@type='text'] | //ul[@tag='pingding']//select";
            var pingding = docBuQueDingDu.DocumentNode.SelectNodes(xpathpingding);
            if (pingding == null)
            {

            }
            else
            {


                List<MYData> list = new List<MYData>();
                foreach (var b in pingding)
                {
                    i++;
                    MYData mydata = new MYData();
                    mydata.id = b.Attributes["id"].Value;
                    mydata.name = b.Attributes["name"].Value;
                    mydata.columnNum = head[mydata.name];
                    mydata.rowNum = int.Parse(System.Math.Ceiling((i / 3)).ToString());
                    if (b.Name == "input")
                    {
                        if (b.Attributes["value"] != null)
                        {
                            mydata.value = b.Attributes["value"].Value;

                        }

                    }
                    else if (b.Name == "select")
                    {
                        var node = b.ChildNodes
                                       .Where(w => (w.Name == "option" && w.Attributes["selected"] != null)? (w.Name == "option" && w.Attributes["selected"] != null) : (w.Name == "option"))
                                       .Select(s => s.Attributes["value"].Value).First();
                         
                        if (node != null)
                        {
                            mydata.value = node;
                        }
                        else
                        {
                              
                        }
                         

                    }
                    list.Add(mydata);
                }
                buDueDingDu.pingding = list;

            }
             
            return buDueDingDu;
        }


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
                         ////未来是要删掉的
                         //string xpath2 = @"//table[@id='tongdao_2']/tbody//table";
                         //var thead2 = doc.DocumentNode.SelectNodes(xpath2);
                         //if (thead2 == null)
                         //{

                //    return 0;//表头下没有行
                //}
                //else
                //{
                //    throw new System.Exception();
                //    return thead2.Count;
                //}

            }
            else
            {
                return thead.Count;
            }

        }
        /// <summary>
        /// 列头的名称
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetColName(HtmlAgilityPack.HtmlDocument doc)
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
        /// 获取表头中的所有的input和select标签的数据
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static Dictionary<int, List<MYDataHead>> GetHeadData(HtmlAgilityPack.HtmlDocument doc)
        {
            var data = new Dictionary<int, List<MYDataHead>>();

            //表头
            Dictionary<int, HtmlAgilityPack.HtmlNodeCollection> theadOfInputAndSelect = AnalyticHTML.GetTheadOfInputAndSelect(doc);
            //遍历通道
            foreach (var item in theadOfInputAndSelect.Keys)
            {
                HtmlAgilityPack.HtmlNodeCollection body = theadOfInputAndSelect[item];
                List<MYDataHead> list = new List<MYDataHead>();
                foreach (var b in body)
                {
                    MYDataHead mydata = new MYDataHead();
                    mydata.id = b.Attributes["id"].Value;
                    mydata.name = b.Attributes["name"].Value;

                    if (b.Name == "input")
                    {
                        if (b.Attributes["value"] != null)
                        {
                            mydata.value = b.Attributes["value"].Value;

                        }
                    }
                    else if (b.Name == "select")
                    {
                        var node = b.ChildNodes
                      .Where(w => (w.Name == "option" && w.Attributes["selected"] != null) ? (w.Name == "option" && w.Attributes["selected"] != null) : (w.Name == "option"))
                      .Select(s => s.Attributes["value"].Value).First();

                        if (node != null)
                        {
                            mydata.value = node;
                        }
                        else
                        {
                            mydata.value = node;
                        }


                    }
                    list.Add(mydata);
                }
                data.Add(item, list);
            }
            return data;

        }
        /// <summary>
        /// 获取表体中的所有的input和select标签的数据
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>按照通道+节点的方式返回</returns>
        public static Dictionary<int, DataValue> GetData(HtmlAgilityPack.HtmlDocument doc)
        {
            var data = new Dictionary<int, DataValue>();

            int trCount = GetTBodyOfTR(doc);//最外层有几行
            int tableCount = GetContainTable(doc);//内部包含几个table
            Dictionary<string, int> head = GetColName(doc);//列头的名称

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
                    if (b.Name == "input")
                    {
                        if (b.Attributes["value"] != null)
                        {
                            mydata.value = b.Attributes["value"].Value;

                        }


                    }
                    else if (b.Name == "select")
                    {
                        var node = b.ChildNodes
                                 .Where(w => (w.Name == "option" && w.Attributes["selected"] != null) ? (w.Name == "option" && w.Attributes["selected"] != null) : (w.Name == "option"))
                                 .Select(s => s.Attributes["value"].Value).First();

                        if (node != null)
                        {
                            mydata.value = node;
                        }

                    }

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

                if (tableCount > 0)
                {
                    //表格嵌套
                    var change = from f in list
                                 where dat.Contains(f.name)
                                 select f;
                    foreach (var it in change)
                    {
                        if (it.mergedRowNum > 1)
                        {
                            throw new System.Exception("我没有遇到这要的情况");
                        }
                        it.mergedRowNum = max;

                    }
                }
                else
                {
                    if (dat != null && dat.Count() > 0)
                    {
                        throw new System.Exception("估计要出错，因为所有列的行数不一样");
                    }
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
        /// 获取表头中的所有的input和select标签 此处有一个bug,如果通道1表头没有数据,就使用2通道
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
                    if (i == 1)
                    {
                        continue;
                    }
                    return theadOfInputAndSelect;
                }
                else
                {

                    if (theadOfInputAndSelect.Count != i - 1)
                    {
                        theadOfInputAndSelect.Add(i - 1, thead);
                    }
                    else
                    {
                        theadOfInputAndSelect.Add(i, thead);
                    }
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
                    if (i == 1)
                    {
                        continue;
                    }
                    return theadOfInputAndSelect;
                }
                else
                {

                    if (theadOfInputAndSelect.Count != i - 1)
                    {
                        theadOfInputAndSelect.Add(i - 1, thead);
                    }
                    else
                    {
                        theadOfInputAndSelect.Add(i, thead);
                    }
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
        /// <summary>
        /// 测试的时候使用
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
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
                    if ((item.Name == "input") && (item.Attributes["type"] != null) && (item.Attributes["type"].Value == "hidden"))
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
