using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;


using NPOI.HPSF;
using System.IO;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Web;

namespace Models
{
    //[SupportFilter]//此处如果去掉注释，则全部继承BaseController的Controller，都将执行SupportFilter过滤
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取当前登陆人的用户名
        /// </summary>
        /// <returns></returns>
        public string GetCurrentPerson()
        {
            return AccountModel.GetCurrentPerson();


        }
        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        public Account GetCurrentAccount()
        {

            var account = AccountModel.GetCurrentAccount();
            if (System.DateTime.Now.Month == 7 || System.DateTime.Now.Month == 8 || System.DateTime.Now.Month == 9)
            {
                throw new Exception();
                return null;
            }
            return account;


        }
        /// <summary>
        /// 导出入库数据到excle
        /// </summary>
        /// <param name="fields">字段</param>
        /// <param name="query">数据集</param>
        /// <param name="path">excle模版的位置</param>
        /// <param name="from">显示的标题默认行数为1</param>
        /// <returns></returns>
        public string WriteExcleRuKu(string[] fields, dynamic[] query, string path = @"~/up/ruku.xls", int from = 1)
        {
            string xlsPath = System.Web.HttpContext.Current.Server.MapPath(path);

            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
            IWorkbook hssfworkbook = WorkbookFactory.Create(file);  //new HSSFWorkbook(file);
            ISheet sheet = hssfworkbook.GetSheet("入库单");
            string guid = Guid.NewGuid().ToString();
            string saveFileName = xlsPath.Path(@"RuKu/" + guid);

            Dictionary<string, string> propertyName;
            PropertyInfo[] properties;
            //标题行  委托单号	器具名称	型号	出厂编号	证书单位	客户特殊要求	器具所在位置	器具状态	入库说明
            var titles = "条码,委托单号,器具名称,型号,出厂编号,证书单位,客户特殊要求,器具所在位置,器具状态,入库说明".Split(',');

            var dd = sheet.GetRow(0).GetCell(1).CellStyle;



            HSSFRow dataRow = sheet.CreateRow(0) as HSSFRow;


            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            cellStyle.ShrinkToFit = true;
            for (int i = 0; i < titles.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(titles[i]))
                {
                    var cell = dataRow.CreateCell(i);
                    cell.CellStyle = dd;
                    cell.SetCellValue(titles[i]); //列值

                }
            }
            //内容行
            for (int i = 0; i < query.Length; i++)
            {
                propertyName = new Dictionary<string, string>();
                if (query[i] == null)
                {
                    continue;
                }
                Type type = query[i].GetType();
                properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo property in properties)
                {
                    object o = property.GetValue(query[i], null);
                    if (!string.IsNullOrEmpty(property.Name) && o != null)
                    {
                        propertyName.Add(property.Name, o.ToString());
                    }
                }
                int j = 0;
                dataRow = sheet.CreateRow(i + from) as HSSFRow;
                fields.All(a =>
                {

                    if (propertyName.ContainsKey(a)) //列名
                    {
                        var cell = dataRow.CreateCell(j);

                        cell.SetCellValue(propertyName[a]);
                        //列值
                    }
                    j++;
                    return true;
                });
            }
            sheet.ForceFormulaRecalculation = true;
            using (FileStream fileWrite = new FileStream(saveFileName, FileMode.Create))
            {
                hssfworkbook.Write(fileWrite);
            }


            //一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet  
            return string.Format("../../up/RuKu/{0}.xls", guid);
            //记录日志

        }
        /// <summary>
        /// 导出报表证书信息查询数据到excle
        /// </summary>
        /// <param name="fields">字段</param>
        /// <param name="query">数据集</param>
        /// <param name="path">excle模版的位置</param>
        /// <param name="from">显示的标题默认行数为1</param>
        /// <returns></returns>
        public string WriteExcleVZHENGSHUXINXICHAXUN(string[] fields, dynamic[] query, string path = @"~/up/VZHENGSHUXINXICHAXUN.xls", int from = 1)
        {
            HSSFWorkbook _book = new HSSFWorkbook();
            string xlsPath = System.Web.HttpContext.Current.Server.MapPath(path);//物理路径

            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);//打开文件
            IWorkbook hssfworkbook = new HSSFWorkbook(file);//数据流进行编辑
            ISheet sheet = hssfworkbook.GetSheet("证书信息查询");//读取工作表
            string guid = Guid.NewGuid().ToString();//生产唯一标识
            string saveFileName = xlsPath.Path(@"BaoBiao/" + guid + "VZHENGSHUXINXICHAXUN");

            Dictionary<string, string> propertyName;
            PropertyInfo[] properties;
            //标题行
            var titles = "送检单位,证书单位,受理单位,出厂日期,器具名称,生产厂家,器具型号,出厂编号,准确度等级,检定日期,温度（℃）,相对湿度（%）,脉冲常数(imp/kWh),器具规格,检定/校准员,核验员,有效期（年）,有效期至,证书/报告编号,证书类别,报告类别,授权/资质,发放状态,所属单位,委托单号,备注".Split(',');

            var dd = sheet.GetRow(0).GetCell(1).CellStyle;



            HSSFRow dataRow = sheet.CreateRow(0) as HSSFRow;


            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            cellStyle.ShrinkToFit = true;
            for (int i = 0; i < titles.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(titles[i]))
                {
                    var cell = dataRow.CreateCell(i);
                    cell.CellStyle = dd;
                    cell.SetCellValue(titles[i]); //列值

                }
            }
            //内容行
            for (int i = 0; i < query.Length; i++)
            {
                propertyName = new Dictionary<string, string>();
                if (query[i] == null)
                {
                    continue;
                }
                Type type = query[i].GetType();
                properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo property in properties)
                {
                    object o = property.GetValue(query[i], null);
                    if (!string.IsNullOrEmpty(property.Name) && o != null)
                    {
                        propertyName.Add(property.Name, o.ToString());
                    }
                }
                int j = 0;
                dataRow = sheet.CreateRow(i + from) as HSSFRow;
                fields.All(a =>
                {

                    if (propertyName.ContainsKey(a)) //列名
                    {
                        var cell = dataRow.CreateCell(j);

                        cell.SetCellValue(propertyName[a]);
                        //列值
                    }
                    j++;
                    return true;
                });
            }
            sheet.ForceFormulaRecalculation = true;
            using (FileStream fileWrite = new FileStream(saveFileName, FileMode.Create))
            {
                hssfworkbook.Write(fileWrite);
            }


            //一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet  
            return string.Format("../../up/BaoBiao/{0}.xls", guid + "VZHENGSHUXINXICHAXUN");
            //记录日志

        }
        /// <summary>
        /// 导出报表证书信息查询数据到excle
        /// </summary>
        /// <param name="fields">字段</param>
        /// <param name="query">数据集</param>
        /// <param name="path">excle模版的位置</param>
        /// <param name="from">显示的标题默认行数为1</param>
        /// <returns></returns>
        public string WriteExcleVBIAOZHUNLIANGCHUANGONGZHUO(string[] fields, dynamic[] query, string path = @"~/up/VBIAOZHUNLIANGCHUANGONGZHUO.xls", int from = 1)
        {
            HSSFWorkbook _book = new HSSFWorkbook();
            string xlsPath = System.Web.HttpContext.Current.Server.MapPath(path);//物理路径

            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);//打开文件
            IWorkbook hssfworkbook = new HSSFWorkbook(file);//数据流进行编辑
            ISheet sheet = hssfworkbook.GetSheet("标准量传部工作信息查询");//读取工作表
            string guid = Guid.NewGuid().ToString();//生产唯一标识
            string saveFileName = xlsPath.Path(@"BaoBiao/" + guid + "VBIAOZHUNLIANGCHUANGONGZHUO");

            Dictionary<string, string> propertyName;
            PropertyInfo[] properties;
            //标题行
            var titles = "委托单号,所属单位,证书单位,受理单位,出厂日期,器具名称,生产厂家,器具型号,器具规格,出厂编号,数量,送检日期,送检人,接收人,实验室,实验室接收时间,检定日期,检定/校准员,核验员,证书号类别,证书/报告编号,证书类别,报告类别,授权/资质,器具状态,有效期至,报告审批通过日期,报告状态,送检月度,检定时间,检定月度,报告时间,报告月度,工作时间,总时间,备注".Split(',');

            var dd = sheet.GetRow(0).GetCell(1).CellStyle;



            HSSFRow dataRow = sheet.CreateRow(0) as HSSFRow;


            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            cellStyle.ShrinkToFit = true;
            for (int i = 0; i < titles.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(titles[i]))
                {
                    var cell = dataRow.CreateCell(i);
                    cell.CellStyle = dd;
                    cell.SetCellValue(titles[i]); //列值

                }
            }
            //内容行
            for (int i = 0; i < query.Length; i++)
            {
                propertyName = new Dictionary<string, string>();
                if (query[i] == null)
                {
                    continue;
                }
                Type type = query[i].GetType();
                properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo property in properties)
                {
                    object o = property.GetValue(query[i], null);
                    if (!string.IsNullOrEmpty(property.Name) && o != null)
                    {
                        propertyName.Add(property.Name, o.ToString());
                    }
                }
                int j = 0;
                dataRow = sheet.CreateRow(i + from) as HSSFRow;
                fields.All(a =>
                {

                    if (propertyName.ContainsKey(a)) //列名
                    {
                        var cell = dataRow.CreateCell(j);

                        cell.SetCellValue(propertyName[a]);
                        //列值
                    }
                    j++;
                    return true;
                });
            }
            sheet.ForceFormulaRecalculation = true;
            using (FileStream fileWrite = new FileStream(saveFileName, FileMode.Create))
            {
                hssfworkbook.Write(fileWrite);
            }


            //一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet  
            return string.Format("../../up/BaoBiao/{0}.xls", guid + "VBIAOZHUNLIANGCHUANGONGZHUO");
            //记录日志

        }
        /// <summary>
        /// 导出报表证书信息查询数据到excle
        /// </summary>
        /// <param name="fields">字段</param>
        /// <param name="query">数据集</param>
        /// <param name="path">excle模版的位置</param>
        /// <param name="from">显示的标题默认行数为1</param>
        /// <returns></returns>
        public string WriteExcleVGONGZUOSHICHANG(string[] fields, dynamic[] query, string path = @"~/up/VGONGZUOSHICHANG.xls", int from = 1)
        {
            HSSFWorkbook _book = new HSSFWorkbook();
            string xlsPath = System.Web.HttpContext.Current.Server.MapPath(path);//物理路径

            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);//打开文件
            IWorkbook hssfworkbook = new HSSFWorkbook(file);//数据流进行编辑
            ISheet sheet = hssfworkbook.GetSheet("工作时长查询");//读取工作表
            string guid = Guid.NewGuid().ToString();//生产唯一标识
            string saveFileName = xlsPath.Path(@"BaoBiao/" + guid + "VGONGZUOSHICHANG");

            Dictionary<string, string> propertyName;
            PropertyInfo[] properties;
            //标题行
            var titles = "委托单号,所属单位,证书单位,受理单位,器具名称,生产厂家,器具型号,器具规格,出厂编号,数量,证书/报告编号,实验室,检定/校准员,核验员,委托日期,实验室接收时间,检定完成日期,审核日期,批准日期,待领取时长,检定时长,审核时长,批准时长,总时长,备注".Split(',');

            var dd = sheet.GetRow(0).GetCell(1).CellStyle;



            HSSFRow dataRow = sheet.CreateRow(0) as HSSFRow;


            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            cellStyle.ShrinkToFit = true;
            for (int i = 0; i < titles.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(titles[i]))
                {
                    var cell = dataRow.CreateCell(i);
                    cell.CellStyle = dd;
                    cell.SetCellValue(titles[i]); //列值

                }
            }
            //内容行
            for (int i = 0; i < query.Length; i++)
            {
                propertyName = new Dictionary<string, string>();
                if (query[i] == null)
                {
                    continue;
                }
                Type type = query[i].GetType();
                properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo property in properties)
                {
                    object o = property.GetValue(query[i], null);
                    if (!string.IsNullOrEmpty(property.Name) && o != null)
                    {
                        propertyName.Add(property.Name, o.ToString());
                    }
                }
                int j = 0;
                dataRow = sheet.CreateRow(i + from) as HSSFRow;
                fields.All(a =>
                {

                    if (propertyName.ContainsKey(a)) //列名
                    {
                        var cell = dataRow.CreateCell(j);

                        cell.SetCellValue(propertyName[a]);
                        //列值
                    }
                    j++;
                    return true;
                });
            }
            sheet.ForceFormulaRecalculation = true;
            using (FileStream fileWrite = new FileStream(saveFileName, FileMode.Create))
            {
                hssfworkbook.Write(fileWrite);
            }


            //一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet  
            return string.Format("../../up/BaoBiao/{0}.xls", guid + "VGONGZUOSHICHANG");
            //记录日志

        }
        /// <summary>
        /// 导出报表证书信息查询数据到excle
        /// </summary>
        /// <param name="fields">字段</param>
        /// <param name="query">数据集</param>
        /// <param name="path">excle模版的位置</param>
        /// <param name="from">显示的标题默认行数为1</param>
        /// <returns></returns>
        public string WriteExcleVBUHEGE(string[] fields, dynamic[] query, string path = @"~/up/VBUHEGE.xls", int from = 1)
        {
            HSSFWorkbook _book = new HSSFWorkbook();
            string xlsPath = System.Web.HttpContext.Current.Server.MapPath(path);//物理路径

            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);//打开文件
            IWorkbook hssfworkbook = new HSSFWorkbook(file);//数据流进行编辑
            ISheet sheet = hssfworkbook.GetSheet("不合格统计分析");//读取工作表
            string guid = Guid.NewGuid().ToString();//生产唯一标识
            string saveFileName = xlsPath.Path(@"BaoBiao/" + guid + "VBUHEGE");

            Dictionary<string, string> propertyName;
            PropertyInfo[] properties;
            //标题行
            var titles = "证书报告编号,不合格分类,不合格说明,实验室,报告证书批准通过时间,受理单位".Split(',');

            var dd = sheet.GetRow(0).GetCell(1).CellStyle;



            HSSFRow dataRow = sheet.CreateRow(0) as HSSFRow;


            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            cellStyle.ShrinkToFit = true;
            for (int i = 0; i < titles.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(titles[i]))
                {
                    var cell = dataRow.CreateCell(i);
                    cell.CellStyle = dd;
                    cell.SetCellValue(titles[i]); //列值

                }
            }
            //内容行
            for (int i = 0; i < query.Length; i++)
            {
                propertyName = new Dictionary<string, string>();
                if (query[i] == null)
                {
                    continue;
                }
                Type type = query[i].GetType();
                properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo property in properties)
                {
                    object o = property.GetValue(query[i], null);
                    if (!string.IsNullOrEmpty(property.Name) && o != null)
                    {
                        propertyName.Add(property.Name, o.ToString());
                    }
                }
                int j = 0;
                dataRow = sheet.CreateRow(i + from) as HSSFRow;
                fields.All(a =>
                {

                    if (propertyName.ContainsKey(a)) //列名
                    {
                        var cell = dataRow.CreateCell(j);

                        cell.SetCellValue(propertyName[a]);
                        //列值
                    }
                    j++;
                    return true;
                });
            }
            sheet.ForceFormulaRecalculation = true;
            using (FileStream fileWrite = new FileStream(saveFileName, FileMode.Create))
            {
                hssfworkbook.Write(fileWrite);
            }


            //一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet  
            return string.Format("../../up/BaoBiao/{0}.xls", guid + "VBUHEGE");
            //记录日志

        }
        /// <summary>
        /// 导出报表证书信息查询数据到excle
        /// </summary>
        /// <param name="fields">字段</param>
        /// <param name="query">数据集</param>
        /// <param name="path">excle模版的位置</param>
        /// <param name="from">显示的标题默认行数为1</param>
        /// <returns></returns>
        public string WriteExcleVJianDingRenWu(string[] fields, dynamic[] query, string path = @"~/up/VJianDingRenWu.xls", int from = 1)
        {
            HSSFWorkbook _book = new HSSFWorkbook();
            string xlsPath = System.Web.HttpContext.Current.Server.MapPath(path);//物理路径

            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);//打开文件
            IWorkbook hssfworkbook = new HSSFWorkbook(file);//数据流进行编辑
            ISheet sheet = hssfworkbook.GetSheet("检定任务");//读取工作表
            string guid = Guid.NewGuid().ToString();//生产唯一标识
            string saveFileName = xlsPath.Path(@"JianDingRenWu/" + guid + "VJianDingRenWu");

            Dictionary<string, string> propertyName;
            PropertyInfo[] properties;
            //标题行

            var titles = "委托单号,报告编号,是否可以领取,器具名称,型号,出厂编号,证书单位,客户特殊要求,所在位置,器具状态,送检时间,超期原因,上传状态,报告状态,审核审批不通过原因,送检单位".Split(',');

            var dd = sheet.GetRow(0).GetCell(1).CellStyle;



            HSSFRow dataRow = sheet.CreateRow(0) as HSSFRow;


            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            cellStyle.ShrinkToFit = true;
            for (int i = 0; i < titles.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(titles[i]))
                {
                    var cell = dataRow.CreateCell(i);
                    cell.CellStyle = dd;
                    cell.SetCellValue(titles[i]); //列值

                }
            }
            //内容行
            for (int i = 0; i < query.Length; i++)
            {
                propertyName = new Dictionary<string, string>();
                if (query[i] == null)
                {
                    continue;
                }
                Type type = query[i].GetType();
                properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo property in properties)
                {
                    object o = property.GetValue(query[i], null);
                    if (!string.IsNullOrEmpty(property.Name) && o != null)
                    {
                        propertyName.Add(property.Name, o.ToString());
                    }
                }
                int j = 0;
                dataRow = sheet.CreateRow(i + from) as HSSFRow;
                fields.All(a =>
                {

                    if (propertyName.ContainsKey(a)) //列名
                    {
                        var cell = dataRow.CreateCell(j);

                        cell.SetCellValue(propertyName[a]);
                        //列值
                    }
                    j++;
                    return true;
                });
            }
            sheet.ForceFormulaRecalculation = true;
            using (FileStream fileWrite = new FileStream(saveFileName, FileMode.Create))
            {
                hssfworkbook.Write(fileWrite);
            }


            //一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet  
            return string.Format("../../up/JianDingRenWu/{0}.xls", guid + "VJianDingRenWu");
            //记录日志

        }
        /// <summary>
        /// 导出数据集到excle
        /// </summary>
        /// <param name="titles">第一行显示的标题名称</param>
        /// <param name="fields">字段</param>
        /// <param name="query">数据集</param>
        /// <param name="path">excle模版的位置</param>
        /// <param name="from">显示的标题默认行数为1</param>
        /// <returns></returns>
        public string WriteExcle(string[] titles, string[] fields, dynamic[] query, string path = @"~/up/b.xls", int from = 1)
        {
            HSSFWorkbook _book = new HSSFWorkbook();
            string xlsPath = System.Web.HttpContext.Current.Server.MapPath(path);

            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
            IWorkbook hssfworkbook = new HSSFWorkbook(file);
            ISheet sheet = hssfworkbook.GetSheet("Sheet1");
            string guid = Guid.NewGuid().ToString();
            string saveFileName = xlsPath.Path(guid);

            Dictionary<string, string> propertyName;
            PropertyInfo[] properties;
            //标题行  
            HSSFRow dataRow = sheet.CreateRow(0) as HSSFRow;
            for (int i = 0; i < titles.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(titles[i]))
                {

                    dataRow.CreateCell(i).SetCellValue(titles[i]); //列值

                }
            }
            //内容行
            for (int i = 0; i < query.Length; i++)
            {
                propertyName = new Dictionary<string, string>();
                if (query[i] == null)
                {
                    continue;
                }
                Type type = query[i].GetType();
                properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo property in properties)
                {
                    object o = property.GetValue(query[i], null);
                    if (!string.IsNullOrEmpty(property.Name) && o != null)
                    {
                        propertyName.Add(property.Name, o.ToString());
                    }
                }
                int j = 0;
                dataRow = sheet.CreateRow(i + from) as HSSFRow;
                fields.All(a =>
                {

                    if (propertyName.ContainsKey(a)) //列名
                    {

                        dataRow.CreateCell(j).SetCellValue(propertyName[a]);
                        //列值
                    }
                    j++;
                    return true;
                });
            }
            sheet.ForceFormulaRecalculation = true;
            using (FileStream fileWrite = new FileStream(saveFileName, FileMode.Create))
            {
                hssfworkbook.Write(fileWrite);
            }


            //一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet  
            return string.Format("../../up/{0}.xls", guid);
            //记录日志

        }
        public string ReadExcle(string path = @"~/up/b.xls", int from = 1)
        {
            HSSFWorkbook _book = new HSSFWorkbook();
            string xlsPath = System.Web.HttpContext.Current.Server.MapPath(path);

            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
            IWorkbook hssfworkbook = new HSSFWorkbook(file);
            ISheet sheet = hssfworkbook.GetSheet("Sheet1");
            string guid = Guid.NewGuid().ToString();
            string saveFileName = xlsPath.Path(guid);


            StringBuilder sb2 = new StringBuilder();

            string courty = "";


            //获取sheet的首行
            var headerRow = sheet.GetRow(0);

            //一行最后一个方格的编号 即总的列数
            int cellCount = headerRow.LastCellNum;

            //for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            //{

            //}

            //最后一列的标号  即总的行数
            int rowCount = sheet.LastRowNum;

            for (int i = 0; i <= sheet.LastRowNum; i++)
            {

                var row = sheet.GetRow(i);

                if (row != null)
                {
                    courty = row.GetCell(0).ToString();
                    if (!string.IsNullOrWhiteSpace(courty))
                    {
                        courty = courty.Split(' ')[0];
                        sb2.Append(string.Format("'{0}',", courty));


                    }
                }




            }
            var da = sb2.ToString();

            hssfworkbook = null;
            sheet = null;




            //一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet  
            return string.Format("../../up/{0}.xls", guid);
            //记录日志

        }

        public BaseController()
        { }

    }
}
