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
    public class ReportBLL
    {

        /// <summary>
        /// 导出模板信息设置（根据输入格式设置）
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, TableTemplateExt> GetTableTemplateDic()
        {
            Dictionary<string, TableTemplateExt> result = new Dictionary<string, TableTemplateExt>();
            TableTemplates temp = null;
            if (ReportStatic.TableTemplateXml != null && ReportStatic.TableTemplateXml.Trim() != "")
            {
                temp = TableTemplates.XmlCovertObj(ReportStatic.TableTemplateXml);
            }
            if (temp != null && temp.TableTemplateList != null && temp.TableTemplateList.Count > 0)
            {
                TableTemplateExt tExt = null;
                foreach (TableTemplate t in temp.TableTemplateList)
                {
                    tExt = new TableTemplateExt();
                    tExt.Cells = t.Cells;
                    tExt.ConclusionRowIndex = t.ConclusionRowIndex-1;
                    tExt.DataRowIndex = t.DataRowIndex-1;
                    //tExt.InpputState = t.InpputState;
                    tExt.InpputStateStr = t.InpputStateStr;
                    tExt.Remark = t.Remark;
                    tExt.RemarkRowIndex = t.RemarkRowIndex-1;
                    tExt.TitleRowCount = t.TitleRowCount-1;
                    tExt.TitleRowIndex = t.TitleRowIndex-1;
                    if (!result.ContainsKey(tExt.InpputStateStr))
                    {
                        Dictionary<string, string> CellList = null;
                        if (tExt.Cells != null && tExt.Cells.Count > 0)
                        {
                            CellList = new Dictionary<string, string>();
                            foreach (Cell c in tExt.Cells)
                            {
                                if (!CellList.ContainsKey(c.Code))
                                {

                                    CellList.Add(c.Code, (c.ColIndex-1).ToString()+"_"+c.ColCount.ToString());
                                }
                            }
                            tExt.CellList = CellList;
                        }
                        result.Add(t.InpputStateStr, tExt);
                    }
                }
            }
            return result;

        }


        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="ID">预备方案ID</param>
        /// <returns></returns>
        public bool ExportOriginalRecord(string ID, out string Message)
        {
            IBLL.IPREPARE_SCHEMEBLL m_BLL = new PREPARE_SCHEMEBLL();
            PREPARE_SCHEME entity = m_BLL.GetById(ID);
            string saveFileName = "";
            if (entity != null)
            {                
                string xlsPath = ReportStatic.YuanShiJiLuJianDingPath;
                if (entity.CERTIFICATE_CATEGORY == ZhengShuLeiBieEnums.校准.ToString())
                {                    
                    xlsPath = ReportStatic.YuanShiJiLuXiaoZhunPath;
                }
                HSSFWorkbook _book = new HSSFWorkbook();
                FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
                IWorkbook hssfworkbook = new HSSFWorkbook(file);
               
                //设置封皮
                SetFengPi(hssfworkbook, entity);              

                //设置数据
                SetShuJu(hssfworkbook, entity);

                saveFileName = "../up/Report/" + entity.CERTIFICATE_CATEGORY + "_" + Result.GetNewId() + ".xls";
                string saveFileNamePath = System.Web.HttpContext.Current.Server.MapPath(saveFileName);                
                using (FileStream fileWrite = new FileStream(saveFileNamePath, FileMode.Create))
                {
                    hssfworkbook.Write(fileWrite);
                }
                
                Message = saveFileName;
                return true;
            }            
            Message = "未找到预备方案ID为【" + ID + "】的数据";
            return false;
        }
        /// <summary>
        /// 设置封皮信息
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <param name="entity"></param>
        private void SetFengPi(IWorkbook hssfworkbook, PREPARE_SCHEME entity)
        {
            string sheetName_Source = "原始记录封皮模板";
            string sheetName_Destination = "原始记录封皮";
            ISheet sheet_Source = hssfworkbook.GetSheet(sheetName_Source);
            ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);
            int RowIndex = 0;
            #region 封皮
            //单元格从0开始
            //准确度等级
            sheet_Destination.GetRow(11).GetCell(7).SetCellValue(entity.ACCURACY_GRADE);
            //额定频率
            if (entity.RATED_FREQUENCY == null || entity.RATED_FREQUENCY.Trim() == "")
            {
                sheet_Destination.GetRow(11).GetCell(19).SetCellValue("");
                sheet_Destination.GetRow(11).GetCell(23).SetCellValue("");
                sheet_Destination.GetRow(11).GetCell(23).CellStyle.BorderBottom = BorderStyle.None;//底部边框去掉                    
            }
            else
            {
                sheet_Destination.GetRow(11).GetCell(23).SetCellValue(entity.RATED_FREQUENCY);
            }
            //脉冲常数
            if (entity.PULSE_CONSTANT == null || entity.PULSE_CONSTANT.Trim() == "")
            {
                HideRow(sheet_Destination, 12, 1);
            }
            else
            {
                sheet_Destination.GetRow(12).GetCell(7).SetCellValue(entity.PULSE_CONSTANT);
            }

            if (entity.APPLIANCE_LABORATORY != null && entity.APPLIANCE_LABORATORY.Count > 0)
            {
                IAPPLIANCE_DETAIL_INFORMATIONBLL infBll = new APPLIANCE_DETAIL_INFORMATIONBLL();
                APPLIANCE_DETAIL_INFORMATION infEntity = infBll.GetById(entity.APPLIANCE_LABORATORY.FirstOrDefault().APPLIANCE_DETAIL_INFORMATIONID);
                if (infEntity != null)
                {
                    //器具名称
                    if (infEntity.APPLIANCE_NAME != null && infEntity.APPLIANCE_NAME.Trim() != "")
                    {
                        sheet_Destination.GetRow(9).GetCell(7).SetCellValue(infEntity.APPLIANCE_NAME);
                    }
                    else
                    {
                        sheet_Destination.GetRow(9).GetCell(7).SetCellValue("/");
                    }
                    //器具型号
                    if (infEntity.VERSION != null && infEntity.VERSION.Trim() != "")
                    {
                        sheet_Destination.GetRow(9).GetCell(23).SetCellValue(infEntity.VERSION);
                    }
                    else
                    {
                        sheet_Destination.GetRow(9).GetCell(23).SetCellValue("/");
                    }
                    //器具规格
                    if (infEntity.FORMAT != null && infEntity.FORMAT.Trim() != "")
                    {
                        sheet_Destination.GetRow(10).GetCell(7).SetCellValue(infEntity.FORMAT);
                    }
                    else
                    {
                        sheet_Destination.GetRow(10).GetCell(7).SetCellValue("/");
                    }
                    //出厂编号
                    if (infEntity.FACTORY_NUM != null && infEntity.FACTORY_NUM.Trim() != "")
                    {
                        sheet_Destination.GetRow(10).GetCell(23).SetCellValue(infEntity.FACTORY_NUM);
                    }
                    else
                    {
                        sheet_Destination.GetRow(10).GetCell(23).SetCellValue("/");
                    }
                    //生产厂家
                    if (infEntity.MAKE_ORGANIZATION != null && infEntity.MAKE_ORGANIZATION.Trim() != "")
                    {
                        sheet_Destination.GetRow(13).GetCell(7).SetCellValue(infEntity.MAKE_ORGANIZATION);
                    }
                    else
                    {
                        sheet_Destination.GetRow(13).GetCell(7).SetCellValue("/");
                    }
                    IORDER_TASK_INFORMATIONBLL taskBll = new ORDER_TASK_INFORMATIONBLL();
                    ORDER_TASK_INFORMATION taskEntity = taskBll.GetById(infEntity.ORDER_TASK_INFORMATIONID);
                    if (taskEntity != null)
                    {
                        //委托单位        
                        if (taskEntity.INSPECTION_ENTERPRISE != null && taskEntity.INSPECTION_ENTERPRISE.Trim() != "")
                        {
                            sheet_Destination.GetRow(6).GetCell(5).SetCellValue(taskEntity.INSPECTION_ENTERPRISE);
                        }
                        else
                        {
                            sheet_Destination.GetRow(6).GetCell(5).SetCellValue("/");
                        }
                    }
                }
            }

            #region 检定所依据技术文件（代号、名称）
            IVRULEBLL rBll = new VRULEBLL();
            List<VRULE> rList = rBll.GetBySCHEMEID(entity.SCHEMEID);
            if (rList != null && rList.Count > 0)
            {
                IRow GCTemplateRow = sheet_Destination.GetRow(16);//获取源格式行
                int GCTemplateIndex = 16;//规程模板行号
                if (rList.Count > 1)
                {
                    int RowCount = rList.Count - 1;                   
                    CopyRow(sheet_Destination, GCTemplateIndex + 1, GCTemplateIndex, RowCount, false);
                }
                RowIndex = 16;
                foreach (VRULE rEntity in rList)
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(2).SetCellValue(rEntity.NAME);
                    RowIndex++;
                }
            }
            #endregion
            //温度
            RowIndex++;
            if (entity.TEMPERATURE != null && entity.TEMPERATURE.Trim() != "")
            {
                sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(entity.TEMPERATURE);
            }
            else
            {
                sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue("/");
            }
            //相对湿度
            if (entity.HUMIDITY != null && entity.HUMIDITY.Trim() != "")
            {
                sheet_Destination.GetRow(RowIndex).GetCell(18).SetCellValue(entity.HUMIDITY);
            }
            else
            {
                sheet_Destination.GetRow(RowIndex).GetCell(18).SetCellValue("/");
            }

            RowIndex = RowIndex + 2;
            //检定地点
            if (entity.CHECK_PLACE != null && entity.CHECK_PLACE.Trim() != "")
            {
                sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CHECK_PLACE);
            }
            else
            {
                sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue("/");
            }

            RowIndex++;
            //检定员
            if (entity.CHECKERID != null && entity.CHECKERID.Trim() != "")
            {
                sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CHECKERID);
            }
            else
            {
                sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue("/");
            }
            //核验员
            if (entity.DETECTERID != null && entity.DETECTERID.Trim() != "")
            {
                sheet_Destination.GetRow(RowIndex).GetCell(23).SetCellValue(entity.DETECTERID);
            }
            else
            {
                sheet_Destination.GetRow(RowIndex).GetCell(23).SetCellValue("/");
            }
            RowIndex++;
            //检定日期
            if (entity.CALIBRATION_DATE.HasValue)
            {
                sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CALIBRATION_DATE.Value.ToString("yyyy年MM月dd日"));
            }
            else
            {
                sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue("/");
            }
            //有效期
            if (entity.VALIDITY_PERIOD.HasValue)
            {
                sheet_Destination.GetRow(RowIndex).GetCell(23).SetCellValue(entity.VALIDITY_PERIOD.Value.ToString("yyyy年MM月dd日"));
            }
            else
            {
                sheet_Destination.GetRow(RowIndex).GetCell(23).SetCellValue("/");
            }
            RowIndex = RowIndex + 2;
            if (entity.CERTIFICATE_CATEGORY == ZhengShuLeiBieEnums.校准.ToString())
            {
                //校准说明   
                RowIndex = RowIndex + 1;
                if (entity.CONCLUSION_EXPLAIN == null || entity.CONCLUSION_EXPLAIN.Trim() == "")
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue("/");
                }
                else
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CONCLUSION_EXPLAIN);
                }

            }
            else
            {
                //检定结论   
                if (entity.CONCLUSION_EXPLAIN == null || entity.CONCLUSION_EXPLAIN.Trim() == "")
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue("/");
                }
                else
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CONCLUSION);
                }
                RowIndex++;
                //检定说明  
                if (entity.CONCLUSION_EXPLAIN == null || entity.CONCLUSION_EXPLAIN.Trim() == "")
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue("/");
                }
                else
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CONCLUSION_EXPLAIN);
                }
            }
            #region 暂时没有数据，不做
            ////检定所使用的计量标准装置
            ////HideRow(sheet, RowIndex, 6);
            //RowIndex = RowIndex + 6;



            ////检定所使用的主要计量器具
            ////HideRow(sheet, RowIndex, 6);
            //RowIndex = RowIndex + 6;
            ////比对和匝比试验使用的中间试品
            ////HideRow(sheet, RowIndex, 6);
            //RowIndex = RowIndex + 6;
            ////空白
            //RowIndex = RowIndex + 8;
            #endregion
            #endregion
            //设置页面页脚
            SetHeaderAndFooter(sheet_Destination, entity);
            sheet_Destination.ForceFormulaRecalculation = true;
        }

        /// <summary>
        /// 设置数据信息
        /// </summary>
        /// <param name="hssfworkbook">工作文件</param>
        private void SetShuJu(IWorkbook hssfworkbook, PREPARE_SCHEME entity)
        {
            int RowIndex = 1;
            int JWTemplateIndex = 0;//规程标题获取源格式行   
            int ruleTitleTemplateIndex = 1;//检测项目名称
                    
            string sheetName_Source = "原始记录数据模板";
            string sheetName_Destination = "原始记录数据";
            string sheetName_ZiFuSource = "字符显示样式";

            ISheet sheet_Source = hssfworkbook.GetSheet(sheetName_Source);
            ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);        
            ISheet sheet_ZiFuSource = hssfworkbook.GetSheet(sheetName_ZiFuSource);

            #region 检测项目            
            if (entity.QUALIFIED_UNQUALIFIED_TEST_ITE != null &&
                entity.QUALIFIED_UNQUALIFIED_TEST_ITE.Count > 0)
            {
                Dictionary<string, TableTemplateExt> TableTemplateDic = GetTableTemplateDic();

                entity.QUALIFIED_UNQUALIFIED_TEST_ITE = entity.QUALIFIED_UNQUALIFIED_TEST_ITE.OrderBy(p => p.SORT).ToList();
                int i = 1;
                foreach (QUALIFIED_UNQUALIFIED_TEST_ITE iEntity in entity.QUALIFIED_UNQUALIFIED_TEST_ITE)
                {
                    #region 检测项目标题
                    CopyRow(sheet_Source, sheet_Destination, ruleTitleTemplateIndex, RowIndex, 1, false);
                    string celStr = i.ToString() + "、";

                    if (iEntity.RULENAME != null && iEntity.RULENAME.Trim() != "")
                    {
                        celStr = celStr + iEntity.RULENAME.Trim() + "：";
                    }
                    if (iEntity.CONCLUSION != null && iEntity.CONCLUSION.Trim() != "")
                    {
                        celStr = celStr + iEntity.CONCLUSION.Trim();
                    }
                    sheet_Destination.GetRow(RowIndex).GetCell(0).SetCellValue(celStr);
                    #endregion

                    #region 检测项目表格
                    RowIndex++;                    
                    if (TableTemplateDic != null && TableTemplateDic.ContainsKey(iEntity.INPUTSTATE))
                    {
                        TableTemplateExt temp = TableTemplateDic[iEntity.INPUTSTATE];                       

                        //解析html表格数据                           
                        RowIndex = paserData(iEntity.HTMLVALUE, sheet_Source, sheet_Destination, RowIndex, temp);
                        

                        //表格注
                        if (iEntity.REMARK != null && iEntity.REMARK.Trim() != "")
                        {
                            CopyRow(sheet_Source, sheet_Destination, temp.RemarkRowIndex, RowIndex, 1, true);
                            sheet_Destination.GetRow(RowIndex).GetCell(0).SetCellValue("注：" + iEntity.REMARK);
                            RowIndex++;
                        }

                        //表格结论
                        if (iEntity.CONCLUSION != null && iEntity.CONCLUSION.Trim() != "")
                        {
                            CopyRow(sheet_Source, sheet_Destination, temp.ConclusionRowIndex, RowIndex, 1, true);
                            sheet_Destination.GetRow(RowIndex).GetCell(0).SetCellValue("结论：" + iEntity.CONCLUSION);
                            RowIndex++;
                        }
                    }
                    if (sheet_Destination.LastRowNum <= RowIndex)
                    {
                        CopyRow(sheet_Destination, sheet_Destination, 0, RowIndex, 1, true);
                    }
                    #endregion
                    RowIndex++;
                    i++;

                }
            }
            #endregion
            //结尾             
            CopyRow(sheet_Source, sheet_Destination, JWTemplateIndex, RowIndex, 1, true);
            //设置页面页脚
            SetHeaderAndFooter(sheet_Destination, entity);
            sheet_Destination.ForceFormulaRecalculation = true;
        }
        /// <summary>
        /// 设置页眉页脚
        /// </summary>
        /// <param name="sheet_Destination">目标sheet</param>
        /// <param name="entity">预备方案</param>
        private void SetHeaderAndFooter(ISheet sheet_Destination, PREPARE_SCHEME entity)
        {
            //页眉
            if (entity.REPORTNUMBER != null && entity.REPORTNUMBER.Trim() != "")
            {
                sheet_Destination.Header.Left = "原始记录编号：" + entity.REPORTNUMBER;
            }
            else
            {
                sheet_Destination.Header.Left = "原始记录编号：";
            }
            //页脚
            if (entity.CERTIFICATE_CATEGORY == ZhengShuLeiBieEnums.校准.ToString() && entity.CNAS == ShiFouCNAS.Yes.ToString() && entity.REPORTNUMBER != null && entity.REPORTNUMBER.Trim() != "")
            {
                sheet_Destination.Footer.Left = entity.REPORTNUMBER;
            }
        }
        #region 复制行
        /// <summary>
        /// 复制行格式并插入指定行数
        /// </summary>
        /// <param name="sheet_Source">源sheet</param>
        /// <param name="sheet_Destination">目标sheet</param>
        /// <param name="rowIndex_Source">源行号</param>
        /// <param name="rowIndex_Destination">目标行号</param>
        /// <param name="insertCount">插入行数</param>
        /// <param name="IsCopyContent">是否拷贝内容</param>
        /// <param name="DongTaiShuJuList">需要替换的动态数据</param>
        private void CopyRow(ISheet sheet_Source, ISheet sheet_Destination, int rowIndex_Source, int rowIndex_Destination, int insertCount, bool IsCopyContent = false,List<string> DongTaiShuJuList=null)
        {
            IRow row_Source = sheet_Source.GetRow(rowIndex_Source);
            int sourceCellCount = row_Source.Cells.Count;

            //1. 批量移动行,清空插入区域
            sheet_Destination.ShiftRows(rowIndex_Destination, //开始行
                             sheet_Destination.LastRowNum, //结束行
                             insertCount, //插入行总数
                             true,        //是否复制行高
                             false        //是否重置行高
                             );

            int startMergeCell = -1; //记录每行的合并单元格起始位置
            int endMergeCell = -1;//记录每行的合并单元结束位置
            bool IsHaveDongTaiShuJu = false;//是否有动态数据
            if(DongTaiShuJuList!=null && DongTaiShuJuList.Count>0)
            {
                IsHaveDongTaiShuJu = true;
            }
            int DongTaiShuJuIndex = 0;//动态数据索引
            for (int i = rowIndex_Destination; i < rowIndex_Destination + insertCount; i++)
            {
                IRow targetRow = null;
                ICell sourceCell = null;
                ICell targetCell = null;

                targetRow = sheet_Destination.CreateRow(i);
                targetRow.Height = row_Source.Height;//复制行高                
                for (int m = row_Source.FirstCellNum; m < row_Source.LastCellNum; m++)
                {
                    sourceCell = row_Source.GetCell(m);
                    if (sourceCell == null)
                        continue;
                    targetCell = targetRow.CreateCell(m);
                    targetCell.CellStyle = sourceCell.CellStyle;//赋值单元格格式
                    targetCell.SetCellType(sourceCell.CellType);

                    //以下为复制模板行的单元格合并格式
                    if (sourceCell.IsMergedCell)
                    {
                        if (startMergeCell < 0 || sourceCell.CellStyle.BorderLeft != BorderStyle.None || sourceCell.StringCellValue!="")
                        {
                            startMergeCell = m;
                        }
                        if (m + 1 == sourceCellCount || sourceCell.CellStyle.BorderRight != BorderStyle.None || row_Source.Cells[m+1].StringCellValue!="")
                        {
                            endMergeCell = m;
                        }
                        if (startMergeCell < endMergeCell)
                        {
                            sheet_Destination.AddMergedRegion(new CellRangeAddress(i, i, startMergeCell, endMergeCell));
                            if (IsCopyContent)
                            {
                                string value = row_Source.Cells[startMergeCell].StringCellValue;
                                if (IsHaveDongTaiShuJu)
                                {
                                    value = string.Format(value, DongTaiShuJuList[DongTaiShuJuIndex]);
                                    DongTaiShuJuIndex++;
                                }
                                targetRow.Cells[startMergeCell].SetCellValue(value);                                
                                //targetRow.Cells[startMergeCell].SetCellValue(row_Source.Cells[startMergeCell].StringCellValue);
                            }
                        }
                    }
                    else
                    {
                        if (startMergeCell >= 0)
                        {
                            sheet_Destination.AddMergedRegion(new CellRangeAddress(i, i, startMergeCell, m - 1));
                            if (IsCopyContent)
                            {
                                string value = row_Source.Cells[startMergeCell].StringCellValue;
                                if (IsHaveDongTaiShuJu)
                                {
                                    value = string.Format(value, DongTaiShuJuList[DongTaiShuJuIndex]);
                                    DongTaiShuJuIndex++;
                                }
                                targetRow.Cells[startMergeCell].SetCellValue(value);
                                
                            }
                            startMergeCell = -1;
                        }
                    }
                }
            }
        }
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

        #endregion 
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
        private void HideRow(ISheet sheet, int startRowIndex, int rowCount)
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
        /// <param name="nodeList">节点(按输入框)</param>
        /// <param name="sheet_Source">源sheet</param>
        /// <param name="sheet_Destination">目标sheet</param>
        /// <param name="rowIndex_Source">源行号</param>
        /// <param name="rowIndex_Destination">目标开始行号</param>
        /// <param name="rowIndex">最大行号</param>
        /// <returns></returns>
        private Dictionary<string, int> SetRowIndex(NodeList nodeList, ISheet sheet_Source, ISheet sheet_Destination, int rowIndex_Source, int rowIndex_Destination, out int rowIndex)
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
                    if (Id != null && Id.ToString().Trim() != "" && Name != null && Name.ToString().Trim() != "")
                    {
                        Id = Id.ToString().Trim().Replace(Name.ToString().Trim(), "");
                        if (Id.ToString() != "" && Id.ToString().Split('_').Length >= 4 && !dic.ContainsKey(Id.ToString()))
                        {
                            dic.Add(Id.ToString(), rowIndex_Destination);
                            CopyRow(sheet_Source, sheet_Destination, rowIndex_Source, rowIndex_Destination, 1, false);
                            rowIndex_Destination++;

                        }
                    }
                }
            }
            rowIndex = rowIndex_Destination;
            return dic;
        }
        /// <summary>
        /// 设置行号，同时插入行
        /// </summary>
        /// <param name="nodeList"></param>
        /// <returns></returns>
        private Dictionary<string, int> SetRowIndex1(NodeList nodeList, ISheet sheet, int startRowIndex, int sourceRowIndex, out int rowIndex)
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
                    if (Id != null && Id.ToString().Trim() != "" && Name != null && Name.ToString().Trim() != "")
                    {
                        Id = Id.ToString().Trim().Replace(Name.ToString().Trim(), "");
                        if (Id.ToString() != "" && Id.ToString().Split('_').Length >= 4 && !dic.ContainsKey(Id.ToString()))
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
        /// 获取表头下拉框值，如果没有下拉框直接返回空字符串
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        private string GetHearderValue(INode node, out bool IsEnd)
        {
            IsEnd = false;
            string value = "";
            ITag tag = getTag(node);
            if (tag != null)
            {
                if (tag.GetAttribute("$<TAGNAME>$") == "option" && tag.GetAttribute("SELECTED") == "selected")
                {
                    IsEnd = true;
                    value = tag.GetAttribute("VALUE");
                    return value;
                }
                //子节点  
                if (tag.Children != null && tag.Children.Count > 0 && IsEnd == false)
                {
                    for (int j = 0; j < tag.Children.Count; j++)
                    {
                        if (IsEnd == false)
                        {
                            value = GetHearderValue(tag.Children[j], out IsEnd);
                        }
                    }
                }
                //兄弟节点 
                if (IsEnd == false)
                {
                    INode siblingNode = tag.NextSibling;
                    while (siblingNode != null)
                    {
                        value = GetHearderValue(siblingNode, out IsEnd);
                        siblingNode = siblingNode.NextSibling;
                    }
                }
            }
            return value;
        }
        /// <summary>
        /// 解析html，然后行号
        /// </summary>
        /// <param name="html">html</param>
        /// <param name="sheet_Source">源sheet</param>
        /// <param name="sheet_Destination">目标sheet</param>
        /// <param name="rowIndex_Destination">目标开始行号</param>
        /// <param name="temp">模板行号单元对象</param>
        /// <returns></returns>
        private int paserData(string html, ISheet sheet_Source, ISheet sheet_Destination, int rowIndex_Destination, TableTemplateExt temp)
        {
            #region 将hmtl转换程文本框及下拉框对象
            Lexer lexer_Input = new Lexer(html);//必须定义多个，否则第二个获取不到数据
            Parser parser_Input = new Parser(lexer_Input);
            Lexer lexer_Option = new Lexer(html);
            Parser parser_Option = new Parser(lexer_Option);
            NodeFilter filter_Input = new TagNameFilter("input");
            NodeFilter filter_Option = new TagNameFilter("OPTION");
            NodeList nodeList_Input = parser_Input.Parse(filter_Input);
            NodeList nodeList_Option = parser_Option.Parse(filter_Option);

            Lexer lexer_Thead = new Lexer(html);
            Parser parser_Thead = new Parser(lexer_Thead);
            NodeFilter filter_Thead = new TagNameFilter("thead");
            NodeList nodeList_Thead = parser_Thead.Parse(filter_Thead);

            Dictionary<int, List<string>> headerDic = null;
            Dictionary<int, NodeList> InputDic = null;
            Dictionary<int, NodeList> OptionDic = null;

            //表头 
            headerDic = GetHeaderDic(nodeList_Thead);
            #region 数据
            if (headerDic != null && headerDic.Count > 0)
            {
                // 数据文本                
                InputDic = GetDataDic(nodeList_Input);
                // 数据下拉框                
                OptionDic = GetDataDic(nodeList_Option);

            }
            #endregion

            #endregion            
            int rowIndex = paserData(sheet_Source, sheet_Destination, rowIndex_Destination, temp, headerDic, InputDic, OptionDic);
            return rowIndex;

        }
        /// <summary>
        /// 设置表格
        /// </summary>
        /// <param name="sheet_Source">源sheet</param>
        /// <param name="sheet_Destination">目标sheet</param>
        /// <param name="rowIndex_Destination">目标开始行号</param>
        /// <param name="temp">模板信息</param>
        /// <param name="headerDic">表头</param>
        /// <param name="InputDic">文本框</param>
        /// <param name="OptionDic">下拉框</param>
        /// <returns></returns>
        private int paserData(ISheet sheet_Source, ISheet sheet_Destination, int rowIndex_Destination,
            TableTemplateExt temp, Dictionary<int, List<string>> headerDic,
            Dictionary<int, NodeList> InputDic, Dictionary<int, NodeList> OptionDic)
        {
            int rowIndex = rowIndex_Destination;
            //int startIndex = rowIndex_Destination;//一个通道开始行
            //int endIndex = rowIndex_Destination;//一个通道结束行
            foreach (int key in headerDic.Keys)
            {
                //startIndex = rowIndex_Destination;//一个通道开始行                
                //画表头
                CopyRow(sheet_Source, sheet_Destination, temp.TitleRowIndex, rowIndex_Destination, 1, true,headerDic[key]);
                rowIndex_Destination++;
                if (InputDic.ContainsKey(key))
                {
                    NodeList nodeList_Input = InputDic[key];
                    Dictionary<string, int> dic = SetRowIndex(nodeList_Input, sheet_Source, sheet_Destination, temp.DataRowIndex, rowIndex_Destination, out rowIndex);
                    rowIndex_Destination = rowIndex;
                    //endIndex = rowIndex_Destination;//一个通道结束行

                    if (dic != null && dic.Count > 0)
                    {
                        object Id = string.Empty;
                        object Name = string.Empty;
                        object Value = string.Empty;

                        #region 输出文本框内容
                        for (int j = 0; j < nodeList_Input.Count; j++)
                        {
                            int MergedRowCount = 1;//合并行数
                            ITag tag = getTag(nodeList_Input[j]);
                            if (tag != null)
                            {
                                ITag parentTag = getTag(tag.Parent);
                                if (parentTag != null && parentTag.GetAttribute("$<TAGNAME>$") == "td" && parentTag.GetAttribute("ROWSPAN")!=null)
                                {
                                    MergedRowCount = Convert.ToInt32(parentTag.GetAttribute("ROWSPAN"));
                                }  
                                else
                                {
                                    MergedRowCount = 1;
                                }                              
                            }

                            Id = tag.GetAttribute("ID");
                            Name = tag.GetAttribute("name");
                            Value = tag.GetAttribute("VALUE");
                            if(Value==null || Value.ToString().Trim()=="")
                            {
                                Value = "/";
                            }
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
                                        if (temp.CellList != null && temp.CellList.ContainsKey(Name.ToString()))
                                        {
                                            string  val = temp.CellList[Name.ToString()];
                                            int cellIndex = Convert.ToInt32(val.Split('_')[0]);
                                            int cellCount= Convert.ToInt32(val.Split('_')[1]);
                                            if (MergedRowCount > 1)
                                            {
                                                sheet_Destination.AddMergedRegion(new CellRangeAddress(dic[Id.ToString()], dic[Id.ToString()] + MergedRowCount-1, cellIndex, cellIndex+cellCount-1));
                                                //sheet_Destination.AddMergedRegion(new CellRangeAddress(3,5, 0, 4));
                                            }
                                            sheet_Destination.GetRow(dic[Id.ToString()]).GetCell((int)cellIndex).SetCellValue(Value.ToString());
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }

                            }
                        }
                        #endregion

                        #region 输出下拉框内容
                        NodeList nodeList_Option = OptionDic[key];
                        for (int j = 0; j < nodeList_Option.Count; j++)
                        {
                            int MergedRowCount = 1;//合并行数
                            ITag tag = getTag(nodeList_Option[j]);
                            if (tag != null)
                            {
                                ITag parentTag = getTag(tag.Parent.Parent);                               
                                if (parentTag != null && parentTag.GetAttribute("$<TAGNAME>$") == "td" && parentTag.GetAttribute("ROWSPAN") != null)
                                {
                                    MergedRowCount = Convert.ToInt32(parentTag.GetAttribute("ROWSPAN"));
                                }
                                else
                                {
                                    MergedRowCount = 1;
                                }
                            }

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
                                    if (!dic.ContainsKey(Id.ToString()) && dic.ContainsKey(Id.ToString() + "_0"))
                                    {
                                        Id = Id.ToString() + "_0";
                                    }
                                    if (dic.ContainsKey(Id.ToString()))
                                    {
                                        try
                                        {
                                            if (temp.CellList != null && temp.CellList.ContainsKey(Name.ToString()))
                                            {
                                                string val = temp.CellList[Name.ToString()];
                                                int cellIndex = Convert.ToInt32(val.Split('_')[0]);
                                                int cellCount = Convert.ToInt32(val.Split('_')[1]);
                                                if (MergedRowCount > 1)
                                                {
                                                    sheet_Destination.AddMergedRegion(new CellRangeAddress(dic[Id.ToString()], dic[Id.ToString()] + MergedRowCount-1, cellIndex, cellIndex+cellCount-1));
                                                    //sheet_Destination.AddMergedRegion(new CellRangeAddress(3,5, 0, 4));
                                                }
                                                //int cellIndex = temp.CellList[Name.ToString()];
                                                sheet_Destination.GetRow(dic[Id.ToString()]).GetCell((int)cellIndex).SetCellValue(Value.ToString());
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        #region 合并单元格
                        //for(int j=0;j<sheet_Destination.)
                        //for (int i = startIndex; i <= endIndex; i++)
                        //{
                        //        //LastCellNum
                        //    //sheet_Destination.AddMergedRegion(new CellRangeAddress(i, i, startMergeCell, m - 1));
                        //}
                        #endregion 
                    }


                }
            }

            return rowIndex_Destination;
        }
        /// <summary>
        /// 获取表头信息
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, List<string>> GetHeaderDic(NodeList nodeList)
        {
            Dictionary<int, List<string>> headerDic = new Dictionary<int, List<string>>();
            #region 表头           

            if (nodeList != null && nodeList.Count > 1)
            {
                headerDic = new Dictionary<int, List<string>>();
                for (int i = 1; i < nodeList.Count; i++)
                {
                    int key = 0;
                    ITag tag = getTag(nodeList[i]);
                    TableHeader[] headerList = ((Winista.Text.HtmlParser.Tags.TableRow)((Winista.Text.HtmlParser.Nodes.AbstractNode)((Winista.Text.HtmlParser.Nodes.AbstractNode)tag).NextSibling).NextSibling).Headers;
                    if (nodeList[i] != null && nodeList[i].Parent != null)
                    {
                        ITag tagHeader = getTag(nodeList[i].Parent);
                        object obj = tagHeader.GetAttribute("id");
                        if (obj != null)
                        {
                            string id = obj.ToString().Trim().Split('_')[obj.ToString().Trim().Split('_').Length - 1];
                            try
                            {
                                key = int.Parse(id);
                            }
                            catch (Exception ex)
                            {
                                key = 0;
                            }

                        }
                    }
                    if (headerList != null && headerList.Count() > 0)
                    {
                        List<string> hList = new List<string>();
                        foreach (TableHeader header in headerList)
                        {
                            bool IsEnd = false;
                            var headerValue = GetHearderValue(header, out IsEnd);
                            hList.Add(headerValue);
                        }
                        if (!headerDic.ContainsKey(key))
                        {
                            headerDic.Add(key, hList);
                        }

                    }
                }
            }
            #endregion
            return headerDic;
        }
        /// <summary>
        /// 获取数据信息
        /// </summary>
        /// <param name="nodeList"></param>
        /// <returns></returns>
        private Dictionary<int, NodeList> GetDataDic(NodeList nodeList)
        {
            Dictionary<int, NodeList> dic = new Dictionary<int, NodeList>();
            if (nodeList != null && nodeList.Count > 0)
            {
                for (int i = 0; i < nodeList.Count; i++)
                {
                    int tongdaoId = GetTongDaoID(nodeList[i]);
                    if (tongdaoId != -1)
                    {
                        if (!dic.ContainsKey(tongdaoId))
                        {
                            dic.Add(tongdaoId, new NodeList());
                        }
                        dic[tongdaoId].Add(nodeList[i]);
                    }
                }
            }
            return dic;
        }
        /// <summary>
        /// 获取通道ID
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int GetTongDaoID(INode node)
        {
            ITag tag = getTag(node);
            object Id = string.Empty;
            object Name = string.Empty;
            if (tag.GetAttribute("$<TAGNAME>$") == "input")
            {

                Id = tag.GetAttribute("ID");
                Name = tag.GetAttribute("name");
            }
            else
            {
                if ((((Winista.Text.HtmlParser.Nodes.TagNode)tag.Parent).Attributes["NAME"] != null &&
((Winista.Text.HtmlParser.Nodes.TagNode)tag.Parent).Attributes["NAME"].ToString() != "K"
&& tag.GetAttribute("SELECTED") == "selected"))
                {
                    Id = ((Winista.Text.HtmlParser.Nodes.TagNode)tag.Parent).Attributes["ID"];
                    Name = ((Winista.Text.HtmlParser.Nodes.TagNode)tag.Parent).Attributes["NAME"];

                }
                else
                {
                    return -1;
                }
            }
            if (Id != null && Id.ToString().Trim() != "" && Name != null && Name.ToString().Trim() != "")
            {
                string[] ids = Id.ToString().Trim().Replace(Name.ToString().Trim(), "").Split('_');
                if (ids.Length > 1)
                {
                    try
                    {
                        return int.Parse(ids[1]);
                    }
                    catch
                    {
                        return 0;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }

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
        private int paserData1(NodeList nodeList_Input, NodeList nodeList_Option, ISheet sheet, int startRowIndex, int sourceRowIndex)
        {
            int rowIndex = startRowIndex;
            Dictionary<string, int> dic = SetRowIndex1(nodeList_Input, sheet, startRowIndex, sourceRowIndex, out rowIndex);
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
                }
                #endregion 

            }
            return rowIndex;

        }
        #endregion 
    }
}
