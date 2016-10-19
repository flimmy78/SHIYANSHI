using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using Langben.App.Models;
using Webdiyer.WebControls.Mvc;
using System.IO;
using Langben.IBLL;
using NPOI.HSSF.UserModel;
using Langben.DAL.shiyanshi;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Filters;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 预备方案
    /// </summary>
    public class PREPARE_SCHEMEController : BaseController
    {
        IList<int> start = new List<int>();

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexSef()
        {

            return View();
        }

        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Details(string id)
        {
            ViewBag.Id = id;
            return View();

        }

        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
        {

            return View();
        }

        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">预备方案主键</param>
        /// <param name="SCHEMEID">方案ID</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Edit(string ID = "")
        {
            Langben.App.Models.VTEST_ITE_YuBei result = new Models.VTEST_ITE_YuBei();
            ViewBag.ID = ID;
            ViewBag.SCHEMEID = "";
            DAL.PREPARE_SCHEME entity = m_BLL.GetById(ID);
            List<VTEST_ITE> vList = null;
            if (entity != null)
            {
                result.prepare_scheme = entity;
                ViewBag.ID = entity.ID;
                ViewBag.SCHEMEID = entity.SCHEMEID;
                IBLL.IVTEST_ITEBLL vBLL = new VTEST_ITEBLL();
                vList = vBLL.GetByPREPARE_SCHEMEID(entity.ID);
                result.vtest_ite = new PagedList<VTEST_ITE>(vList, 1, int.MaxValue);
            }
            else
            {
                entity = new PREPARE_SCHEME();
                result.prepare_scheme = entity;
            }
            return View(result);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="ID">预备方案编号</param>
        /// <param name="CONCLUSION">总结论</param>
        /// <param name="CONCLUSION_EXPLAIN">结论说明</param>
        /// <param name="VALIDITY_PERIOD">有效期</param>
        /// <returns></returns>
        public ActionResult Save(string ID, string CONCLUSION, string CONCLUSION_EXPLAIN, string VALIDITY_PERIOD)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            PREPARE_SCHEME entity = m_BLL.GetById(ID);
            if (entity != null)
            {
                entity.CONCLUSION = CONCLUSION;
                entity.CONCLUSION_EXPLAIN = CONCLUSION_EXPLAIN;
                try
                {
                    entity.VALIDITY_PERIOD = Convert.ToDateTime(VALIDITY_PERIOD);
                }
                catch
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + "有效期格式错误";
                    return Json(result); //提示插入失败
                }
                string currentPerson = GetCurrentPerson();
                entity.UPDATETIME = DateTime.Now;
                entity.UPDATEPERSON = currentPerson;

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，检定项目模板的Id为" + entity.ID, "检定项目模板"
                        );//写入日志 
                    result.Code = Common.ClientCode.Succeed;
                    //result.Message = Suggestion.UpdateSucceed;
                    result.Message = entity.ID;
                    return Json(result); //提示创建成功
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，检定项目模板，" + returnValue, "检定项目模板"
                        );//写入日志                      
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return Json(result); //提示插入失败
                }

            }
            else
            {
                result.Code = Common.ClientCode.Fail;
                result.Message = Suggestion.UpdateFail + "未找到预备方案ID为【" + ID + "】的数据";
                return Json(result); //提示插入失败
            }



        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="ID">预备方案ID</param>
        /// <returns></returns>
        public ActionResult ExportOriginalRecord(string ID)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            PREPARE_SCHEME entity = m_BLL.GetById(ID);
            string saveFileName = "";
            if (entity != null)
            {
                int RowIndex = 0;
                string templatePath = "../Template/原始记录-检定.xls";
                string sheetName = "原始记录封皮及数据";
                if (entity.CERTIFICATE_CATEGORY == ZhengShuLeiBieEnums.校准.ToString())
                {
                    templatePath = "../Template/原始记录-校准.xls";
                }

                HSSFWorkbook _book = new HSSFWorkbook();
                string xlsPath = System.Web.HttpContext.Current.Server.MapPath(templatePath);

                FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
                IWorkbook hssfworkbook = new HSSFWorkbook(file);
                ISheet sheet = hssfworkbook.GetSheet(sheetName);
                //单元格从0开始
                //准确度等级
                sheet.GetRow(11).GetCell(7).SetCellValue(entity.ACCURACY_GRADE);
                //额定频率
                if (entity.RATED_FREQUENCY == null || entity.RATED_FREQUENCY.Trim()=="")
                {
                    sheet.GetRow(11).GetCell(19).SetCellValue("");
                    sheet.GetRow(11).GetCell(23).SetCellValue("");
                }
                else
                {
                    sheet.GetRow(11).GetCell(23).SetCellValue(entity.RATED_FREQUENCY);
                }
                //脉冲常数
                if (entity.PULSE_CONSTANT == null || entity.PULSE_CONSTANT.Trim() == "")
                {
                    HideRow(sheet, 12, 1);
                }
                else
                {
                    sheet.GetRow(12).GetCell(7).SetCellValue(entity.PULSE_CONSTANT);
                }

                if (entity.APPLIANCE_LABORATORY != null && entity.APPLIANCE_LABORATORY.Count > 0)
                {
                    IAPPLIANCE_DETAIL_INFORMATIONBLL infBll = new APPLIANCE_DETAIL_INFORMATIONBLL();
                    APPLIANCE_DETAIL_INFORMATION infEntity = infBll.GetById(entity.APPLIANCE_LABORATORY.FirstOrDefault().APPLIANCE_DETAIL_INFORMATIONID);
                    if (infEntity != null)
                    {
                        //器具名称
                        sheet.GetRow(9).GetCell(7).SetCellValue(infEntity.APPLIANCE_NAME);
                        //器具型号
                        sheet.GetRow(9).GetCell(23).SetCellValue(infEntity.VERSION);
                        //器具规格
                        sheet.GetRow(10).GetCell(7).SetCellValue(infEntity.FORMAT);
                        //出厂编号
                        sheet.GetRow(10).GetCell(23).SetCellValue(infEntity.FACTORY_NUM);
                        //生产厂家
                        sheet.GetRow(13).GetCell(7).SetCellValue(infEntity.MAKE_ORGANIZATION);

                        IORDER_TASK_INFORMATIONBLL taskBll = new ORDER_TASK_INFORMATIONBLL();
                        ORDER_TASK_INFORMATION taskEntity = taskBll.GetById(infEntity.ORDER_TASK_INFORMATIONID);
                        if (taskEntity != null)
                        {
                            //委托单位                            
                            sheet.GetRow(6).GetCell(5).SetCellValue(taskEntity.INSPECTION_ENTERPRISE);
                        }
                    }
                }

                #region 检定所依据技术文件（代号、名称）
                IVRULEBLL rBll = new VRULEBLL();
                //List<RULE> rList = rBll.GetFirstModelBySCHEMEID(entity.SCHEMEID);
                List<VRULE> rList = rBll.GetBySCHEMEID(entity.SCHEMEID);
                if (rList != null && rList.Count > 0)
                {
                    IRow GCTemplateRow = sheet.GetRow(16);//获取源格式行
                    int GCTemplateIndex = 16;//规程模板行号
                    if (rList.Count > 1)
                    {
                        int RowCount = rList.Count - 1;                        
                        //InsertRow(sheet, 17, RowCount, GCTemplateRow);
                        CopyRow(sheet, GCTemplateIndex+1, GCTemplateIndex, RowCount,false);
                    }
                    RowIndex = 16;
                    foreach (VRULE rEntity in rList)
                    {
                        sheet.GetRow(RowIndex).GetCell(2).SetCellValue(rEntity.NAME);
                        RowIndex++;
                    }
                }
                #endregion 
                //温度
                RowIndex++;
                sheet.GetRow(RowIndex).GetCell(5).SetCellValue(entity.TEMPERATURE);
                //相对湿度
                sheet.GetRow(RowIndex).GetCell(18).SetCellValue(entity.HUMIDITY);

                RowIndex = RowIndex + 2;
                //检定地点
                sheet.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CHECK_PLACE);

                RowIndex++;
                //检定员
                sheet.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CHECKERID);
                //核验员
                sheet.GetRow(RowIndex).GetCell(23).SetCellValue(entity.DETECTERID);
                RowIndex++;
                //检定日期
                if (entity.CALIBRATION_DATE.HasValue)
                {
                    sheet.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CALIBRATION_DATE.Value.ToString("yyyy年MM月dd日"));
                }
                //有效期
                if (entity.VALIDITY_PERIOD.HasValue)
                {
                    sheet.GetRow(RowIndex).GetCell(23).SetCellValue(entity.VALIDITY_PERIOD.Value.ToString("yyyy年MM月dd日"));
                }
                RowIndex = RowIndex + 2;
                //检定结论          
                sheet.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CONCLUSION);
                RowIndex++;
                //检定说明  
                if (entity.CONCLUSION_EXPLAIN == null || entity.CONCLUSION_EXPLAIN.Trim() == "")
                {
                    sheet.GetRow(RowIndex).GetCell(5).SetCellValue("/");
                }
                else
                {
                    sheet.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CONCLUSION_EXPLAIN);
                }
                #region 暂时没有数据，不做
                //检定所使用的计量标准装置
                //HideRow(sheet, RowIndex, 6);
                RowIndex = RowIndex + 6;



                //检定所使用的主要计量器具
                //HideRow(sheet, RowIndex, 6);
                RowIndex = RowIndex + 6;
                //比对和匝比试验使用的中间试品
                //HideRow(sheet, RowIndex, 6);
                RowIndex = RowIndex + 6;
                //空白
                RowIndex = RowIndex + 8;
                #endregion
                #region 检测项目
                
                //RowIndex = RowIndex+2;
                //直流电流输出模板
                RowIndex++;
                int JCXRowIndex = RowIndex;
                int BTTemplateIndex = RowIndex ;//规程标题获取源格式行
                RowIndex = RowIndex + 2;
                int ZLDLSCTBTTemplateIndex = RowIndex;//直流电流输出表格表头获取源格式行
                RowIndex++;
                int ZLDLSCTNRTemplateIndex = RowIndex;//直流电流输出表格内容获取源格式行
                RowIndex ++;
                int ZLDLSCTZTemplateIndex = RowIndex;//直流电流表格注获取源格式行
                RowIndex++;
                int ZLDLSCTJLTemplateIndex = RowIndex;//直流电流表格结论获取源格式行
                //结尾
                RowIndex = RowIndex + 2;
                int JWTemplateIndex = RowIndex;//结尾模板源格式行 

                RowIndex++;
                

                if (entity.QUALIFIED_UNQUALIFIED_TEST_ITE != null &&
                    entity.QUALIFIED_UNQUALIFIED_TEST_ITE.Count > 0)
                {
                    entity.QUALIFIED_UNQUALIFIED_TEST_ITE = entity.QUALIFIED_UNQUALIFIED_TEST_ITE.OrderBy(p=>p.SORT).ToList();
                    int i = 1;                   
                    foreach (QUALIFIED_UNQUALIFIED_TEST_ITE iEntity in entity.QUALIFIED_UNQUALIFIED_TEST_ITE)
                    {

                        //InsertRow(sheet, RowIndex, 1, BTTemplate);
                        CopyRow(sheet, RowIndex, BTTemplateIndex, 1, true);
                        string celStr = i.ToString() + "、";

                        if (iEntity.RULENAME != null && iEntity.RULENAME.Trim() != "")
                        {
                            celStr = celStr + iEntity.RULENAME.Trim() + "：";
                        }
                        if (iEntity.CONCLUSION != null && iEntity.CONCLUSION.Trim() != "")
                        {
                            celStr = celStr + iEntity.CONCLUSION.Trim();
                        }
                        sheet.GetRow(RowIndex).GetCell(0).SetCellValue(celStr);
                        if (iEntity.INPUTSTATE == InputStateEnums.ZhiLiuDianLiuShuChu.ToString())
                        {
                            RowIndex++;
                            //InsertRow(sheet, RowIndex, 1, ZLDLSCTBTemplate);
                            //sheet.CopyRow(ZLDLSCTBTIndex, RowIndex);
                            CopyRow(sheet, RowIndex, ZLDLSCTBTTemplateIndex, 1,true);
                            
                            //RowIndex++;

                            //Winista.Text.HtmlParser.Parser parser = new Winista.Text.HtmlParser.Parser(new Winista.Text.HtmlParser.Lex.Lexer("HtmlString"));
                            //iEntity.HTMLVALUE

                            #region 解析html
                            Lexer lexer_Input = new Lexer(iEntity.HTMLVALUE);//必须定义多个，否则第二个获取不到数据
                            Parser parser_Input = new Parser(lexer_Input);
                            Lexer lexer_Option = new Lexer(iEntity.HTMLVALUE);
                            Parser parser_Option = new Parser(lexer_Option);
                            //NodeFilter filter = new NodeClassFilter(typeof(Winista.Text.HtmlParser.Tags.Div));
                            NodeFilter filter_Input = new TagNameFilter("input");
                            NodeFilter filter_Option = new TagNameFilter("OPTION");                          

                           
                            NodeList nodeList_Input = parser_Input.Parse(filter_Input);
                            NodeList nodeList_Option = parser_Option.Parse(filter_Option);

                            RowIndex=paserData(nodeList_Input, nodeList_Option, sheet, RowIndex, ZLDLSCTNRTemplateIndex);
                            RowIndex++;                            
                            #endregion


                            //InsertRow(sheet, RowIndex, 1, ZLDLSCTZTemplate);
                            //sheet.CopyRow(ZLDLSCTZIndex, RowIndex);
                            CopyRow(sheet, RowIndex, ZLDLSCTZTemplateIndex, 1, true);
                            if (iEntity.REMARK != null)
                            {

                                sheet.GetRow(RowIndex).GetCell(0).SetCellValue("注：" + iEntity.REMARK);
                            }
                            else
                            {
                                sheet.GetRow(RowIndex).GetCell(0).SetCellValue("注：");
                            }
                            RowIndex++;
                            //InsertRow(sheet, RowIndex, 1, ZLDLSCTJLTemplate);
                            //sheet.CopyRow(ZLDLSCTJLIndex, RowIndex);
                            CopyRow(sheet, RowIndex, ZLDLSCTJLTemplateIndex, 1, true);
                            if (iEntity.CONCLUSION != null)
                            {
                                sheet.GetRow(RowIndex).GetCell(0).SetCellValue("结论：" + iEntity.CONCLUSION);
                            }
                            else
                            {
                                sheet.GetRow(RowIndex).GetCell(0).SetCellValue("结论：");
                            }


                        }
                        RowIndex = RowIndex + 2;
                        i++;

                    }
                }
                #endregion

                //结尾             
                CopyRow(sheet, RowIndex, JWTemplateIndex, 1,true);
                HideRow(sheet, JCXRowIndex, 8);
                //页眉
                if (entity.CONTROL_NUMBER != null && entity.CONTROL_NUMBER.Trim() != "")
                {
                    sheet.Header.Left = "                " + entity.CONTROL_NUMBER;
                }
                //页脚
                if (entity.CERTIFICATE_CATEGORY == ZhengShuLeiBieEnums.校准.ToString() && entity.CNAS== ShiFouCNAS.Yes.ToString() && entity.CONTROL_NUMBER!=null && entity.CONTROL_NUMBER.Trim()!="")
                {
                    sheet.Footer.Left = entity.CONTROL_NUMBER;
                }


                    saveFileName = "../up/Report/" + entity.CERTIFICATE_CATEGORY + "_" + Result.GetNewId() + ".xls";
                string saveFileNamePath = System.Web.HttpContext.Current.Server.MapPath(saveFileName);
                sheet.ForceFormulaRecalculation = true;
                using (FileStream fileWrite = new FileStream(saveFileNamePath, FileMode.Create))
                {
                    hssfworkbook.Write(fileWrite);
                }
                //一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet              

                result.Code = Common.ClientCode.Succeed;
                result.Message = saveFileName;
                return Json(result); //提示插入失败
            }
            result.Code = Common.ClientCode.Fail;
            result.Message = Suggestion.UpdateFail + "未找到预备方案ID为【" + ID + "】的数据";
            return Json(result); //提示插入失败
        }

        #region 解析html
        private ITag getTag(INode node)
        {
            if (node == null)
                return null;
            return node is ITag ? node as ITag : null;
        }
        /// <summary>
        /// 隐藏行
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="startRowIndex">开始行号</param>
        /// <param name="rowCount">行数</param>
        private void HideRow(ISheet sheet, int startRowIndex,int rowCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                IRow sourceRow = sheet.GetRow(startRowIndex);
                sourceRow.Height = 0;
                startRowIndex++;
            }
        }
        /// <summary>
        /// 设置行号，同时插入行
        /// </summary>
        /// <param name="nodeList"></param>
        /// <returns></returns>
        private Dictionary<string,int> SetRowIndex(NodeList nodeList, ISheet sheet, int startRowIndex, int sourceRowIndex,out int rowIndex)
        {            
            Dictionary<string, int> dic = new Dictionary<string, int>();

            if (nodeList.Count > 0)
            {
                object Id = string.Empty;
                object Name = string.Empty;
                for (int j = 0; j < nodeList.Count; j++)
                {
                    ITag tag = getTag(nodeList[j]);
                    Id = tag.GetAttribute("ID");
                    Name = tag.GetAttribute("name");
                    if(Id!=null && Id.ToString().Trim()!="" && Name!=null && Name.ToString().Trim()!="")
                    {
                        Id = Id.ToString().Trim().Replace(Name.ToString().Trim(), "");
                        if(Id.ToString()!="" && Id.ToString().Split('_').Length>=4  && !dic.ContainsKey(Id.ToString()))
                        {
                            startRowIndex++;
                            dic.Add(Id.ToString(), startRowIndex);
                            CopyRow(sheet, startRowIndex, sourceRowIndex, 1, true);
                            
                        }
                    }
                }                
            }
            rowIndex = startRowIndex;
            return dic;         
        }
        /// <summary>
        /// 解析html，然后行号
        /// </summary>
        /// <param name="nodeList_Input">文本框</param>
        /// <param name="nodeList_Option">下拉框</param>
        /// <param name="sheet"></param>
        /// <param name="startRowIndex">复制开始行号</param>
        /// <param name="sourceRowIndex">复制源行号</param>
        /// <returns></returns>
        private int paserData(NodeList nodeList_Input, NodeList nodeList_Option, ISheet sheet, int startRowIndex, int sourceRowIndex)
        {
            int rowIndex = startRowIndex;
            Dictionary<string, int> dic = SetRowIndex(nodeList_Input, sheet, startRowIndex, sourceRowIndex,out rowIndex);
            if (dic != null && dic.Count > 0)
            {
                object Id = string.Empty;
                object Name = string.Empty;
                object Value = string.Empty;

                #region 输出文本框内容
                for (int j = 0; j < nodeList_Input.Count; j++)
                {
                    ITag tag = getTag(nodeList_Input[j]);
                    Id = tag.GetAttribute("ID");
                    Name = tag.GetAttribute("name");
                    Value = tag.GetAttribute("VALUE");
                    if (Id != null && Id.ToString().Trim() != "" && Name != null && Name.ToString().Trim() != "")
                    {
                        Id = Id.ToString().Trim().Replace(Name.ToString().Trim(), "");
                        if (!dic.ContainsKey(Id.ToString()) && dic.ContainsKey(Id.ToString() + "_0"))
                        {
                            Id = Id.ToString() + "_0";
                        }
                        if (dic.ContainsKey(Id.ToString()))
                        {
                            try
                            {
                                ZhiLiuDianLiuShuChuEnum colIndex = (ZhiLiuDianLiuShuChuEnum)Enum.Parse(typeof(ZhiLiuDianLiuShuChuEnum), Name.ToString().Trim());
                                sheet.GetRow(dic[Id.ToString()]).GetCell((int)colIndex).SetCellValue(Value.ToString());
                            }
                            catch (Exception ex)
                            { }
                        }

                    }
                }
                #endregion 

                #region 输出下拉框内容
                for (int j = 0; j < nodeList_Option.Count; j++)
                {
                    ITag tag = getTag(nodeList_Option[j]);

                    if ((((Winista.Text.HtmlParser.Nodes.TagNode)tag.Parent).Attributes["NAME"] != null &&
               ((Winista.Text.HtmlParser.Nodes.TagNode)tag.Parent).Attributes["NAME"].ToString() != "K"
               && tag.GetAttribute("SELECTED") == "selected"))
                    {
                        Id = ((Winista.Text.HtmlParser.Nodes.TagNode)tag.Parent).Attributes["ID"];
                        Name = ((Winista.Text.HtmlParser.Nodes.TagNode)tag.Parent).Attributes["NAME"];
                        Value = tag.GetAttribute("VALUE");
                        if (Id != null && Id.ToString().Trim() != "" && Name != null && Name.ToString().Trim() != "")
                        {
                            Id = Id.ToString().Trim().Replace(Name.ToString().Trim(), "");
                            if(!dic.ContainsKey(Id.ToString()) && dic.ContainsKey(Id.ToString() + "_0"))
                            {
                                Id = Id.ToString() + "_0";
                            }
                            if (dic.ContainsKey(Id.ToString()))
                            {
                                try
                                {
                                    ZhiLiuDianLiuShuChuEnum colIndex = (ZhiLiuDianLiuShuChuEnum)Enum.Parse(typeof(ZhiLiuDianLiuShuChuEnum), Name.ToString().Trim());
                                    sheet.GetRow(dic[Id.ToString()]).GetCell((int)colIndex).SetCellValue(Value.ToString());
                                }
                                catch (Exception ex)
                                { }
                            }
                        }
                    }
                }
                #endregion 

            }
            return rowIndex;

        }
        #endregion 

        /// <summary>
        /// 复制行格式并插入指定行数
        /// </summary>
        /// <param name="sheet">当前sheet</param>
        /// <param name="startRowIndex">起始行位置</param>
        /// <param name="sourceRowIndex">模板行位置</param>
        /// <param name="insertCount">插入行数</param>
        /// <param name="IsCopyContent">是否复制内容</param>
        private void CopyRow(ISheet sheet, int startRowIndex, int sourceRowIndex, int insertCount, bool IsCopyContent = false)
        {
            IRow sourceRow = sheet.GetRow(sourceRowIndex);
            int sourceCellCount = sourceRow.Cells.Count;

            //1. 批量移动行,清空插入区域
            sheet.ShiftRows(startRowIndex, //开始行
                             sheet.LastRowNum, //结束行
                             insertCount, //插入行总数
                             true,        //是否复制行高
                             false        //是否重置行高
                             );

            int startMergeCell = -1; //记录每行的合并单元格起始位置
            for (int i = startRowIndex; i < startRowIndex + insertCount; i++)
            {
                IRow targetRow = null;
                ICell sourceCell = null;
                ICell targetCell = null;

                targetRow = sheet.CreateRow(i);
                targetRow.Height = sourceRow.Height;//复制行高

                for (int m = sourceRow.FirstCellNum; m < sourceRow.LastCellNum; m++)
                {
                    sourceCell = sourceRow.GetCell(m);
                    if (sourceCell == null)
                        continue;
                    targetCell = targetRow.CreateCell(m);
                    targetCell.CellStyle = sourceCell.CellStyle;//赋值单元格格式
                    targetCell.SetCellType(sourceCell.CellType);

                    //以下为复制模板行的单元格合并格式
                    if (sourceCell.IsMergedCell)
                    {
                        if (startMergeCell <= 0)
                            startMergeCell = m;
                        else if (startMergeCell > 0 && sourceCellCount == m + 1)
                        {
                            sheet.AddMergedRegion(new CellRangeAddress(i, i, startMergeCell, m));
                            startMergeCell = -1;
                        }
                    }
                    else
                    {
                        if (startMergeCell >= 0)
                        {
                            sheet.AddMergedRegion(new CellRangeAddress(i, i, startMergeCell, m - 1));
                            startMergeCell = -1;
                        }
                    }
                }
                if (IsCopyContent)
                {
                    sheet.CopyRow(sourceRowIndex, targetRow.RowNum);
                }
            }
            if (IsCopyContent)
            {
                #region 移除
                int StartIndex = startRowIndex + insertCount;
                int EndIndex = StartIndex + insertCount;
                for (int i = StartIndex; i <= EndIndex; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null)
                    {
                        continue;
                    }
                    sheet.RemoveRow(row);
                }

                #endregion
            }
        }
IBLL.IPREPARE_SCHEMEBLL m_BLL;
        ValidationErrors validationErrors = new ValidationErrors();
        public PREPARE_SCHEMEController()
                    : this(new PREPARE_SCHEMEBLL()) { }

        public PREPARE_SCHEMEController(PREPARE_SCHEMEBLL bll)
        {
            m_BLL = bll;
        }

    }
}


