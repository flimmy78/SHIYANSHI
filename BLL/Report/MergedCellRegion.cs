using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.Report
{
    public class MergedCellRegion
    {
        /// <summary>
        /// 模板中所有的合并的单元格
        /// </summary>
        List<CellRangeAddress> returnList = new List<CellRangeAddress>();
        List<int> DeleteRowList = new List<int>();
        /// <summary>
        ///  获取合并区域信息
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public List<CellRangeAddress> GetMergedCellRegion(ISheet sheet)
        {

            int mergedRegionCellCount = sheet.NumMergedRegions;
            List<CellRangeAddress> cellList = new List<CellRangeAddress>();

            for (int i = 0; i < mergedRegionCellCount; i++)
            {
                cellList.Add(sheet.GetMergedRegion(i).Copy());
            }


            return cellList;
        }
        /// <summary>
        /// 获取合并单元格的坐标范围
        /// </summary>
        /// <param name="sheet">sheet</param>
        /// <param name="columnIndex"></param>
        /// <param name="rowIndex"></param> 
        /// <returns>合并单元格的范围</returns>
        public CellRangeAddress getMergedRegionCell(ISheet sheet, int columnIndex, int rowIndex)
        {
            List<CellRangeAddress> result  =returnList;
            return (from c in result
                    where columnIndex >= c.FirstColumn && columnIndex <= c.LastColumn && rowIndex >= c.FirstRow && rowIndex <= c.LastRow
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// 复制行格式并插入指定行数(返回动态区域)
        /// </summary>
        /// <param name="sheet_Source">源sheet</param>
        /// <param name="sheet_Destination">目标sheet</param>
        /// <param name="rowIndex_Source">源行号</param>
        /// <param name="rowIndex_Destination">目标行号</param>
        /// <param name="insertCount">插入行数</param>
        /// <param name="IsCopyContent">是否拷贝内容</param>
        /// <param name="rowInfoList">需要替换的动态模板数据</param>
        /// <param name="allSpecialCharacters">特殊字符配置信息</param>
        /// <param name="DongTaiShuJuList">需要替换的动态数据</param>   
        /// <param name="IsNullShow">动态空数据是否显示/</param>
        private Dictionary<string, CellRangeAddress> CopyRow_1(ISheet sheet_Source, ISheet sheet_Destination, int rowIndex_Source,
            int rowIndex_Destination, int insertCount)
        {
            //key：//第几行_第几列 
            Dictionary<string, CellRangeAddress> result = new Dictionary<string, CellRangeAddress>();
            string key = "";//第几行_第几列 
            int colCount = 0;
            IRow row_Source = sheet_Source.GetRow(rowIndex_Source);
            int sourceCellCount = row_Source.Cells.Count;
            if (insertCount <= 0)
            {
                insertCount = 1;
            }
            //1. 批量移动行,清空插入区域
            sheet_Destination.ShiftRows(rowIndex_Destination, //开始行
                             sheet_Destination.LastRowNum, //结束行
                             insertCount, //插入行总数
                             true,        //是否复制行高
                             false        //是否重置行高
                             );

            int startMergeCell = -1; //记录每行的合并单元格起始位置
            //int endMergeCell = -1;//记录每行的合并单元结束位置     
            //给目标行正式处理格式及插入多少行数据       
            for (int i = rowIndex_Destination; i < rowIndex_Destination + insertCount; i++)
            {
                startMergeCell = -1;
                IRow targetRow = null;
                ICell sourceCell = null;
                ICell targetCell = null;

                targetRow = sheet_Destination.CreateRow(i);
                targetRow.Height = row_Source.Height;//复制行高 
                //每行单元格处理               
                for (int m = row_Source.FirstCellNum; m < row_Source.LastCellNum; m++)
                {
                    if (m < 57 && m < row_Source.Cells.Count)
                    {
                        sourceCell = row_Source.GetCell(m);
                        row_Source.Cells[m].SetCellType(CellType.String);
                        if (m + 1 != row_Source.LastCellNum && m < row_Source.Cells.Count - 1)
                        {
                            row_Source.Cells[m + 1].SetCellType(CellType.String);
                        }
                        if (sourceCell == null)
                            continue;
                        targetCell = targetRow.CreateCell(m);
                        targetCell.CellStyle = sourceCell.CellStyle;//赋值单元格格式
                        targetCell.SetCellType(sourceCell.CellType);

                        //列合并，以下为复制模板行的单元格合并格式                    
                        #region 新合并方式                   
                        if (sourceCell.IsMergedCell)
                        {
                            CellRangeAddress cellAddress = getMergedRegionCell(sheet_Source, m, rowIndex_Source);
                            if (cellAddress != null && cellAddress.LastColumn > startMergeCell && (cellAddress.LastRow > cellAddress.FirstRow || cellAddress.LastColumn > cellAddress.FirstColumn))
                            {
                                if (rowIndex_Source == cellAddress.LastRow)
                                {
                                    sheet_Destination.AddMergedRegion(new CellRangeAddress(i - (cellAddress.LastRow - cellAddress.FirstRow), i, cellAddress.FirstColumn, cellAddress.LastColumn));
                                    startMergeCell = cellAddress.LastColumn + 1;
                                    if (m == 0)
                                    {
                                        colCount = 1;
                                    }
                                    else
                                    {
                                        colCount++;
                                    }
                                    key = (i - (cellAddress.LastRow - cellAddress.FirstRow)).ToString() + "_" + colCount.ToString();//第几行_第几列 
                                                                                                                                    //result.Add(new CellRangeAddress(i - (cellAddress.LastRow - cellAddress.FirstRow), i, cellAddress.FirstColumn, cellAddress.LastColumn));
                                    result.Add(key, new CellRangeAddress(i - (cellAddress.LastRow - cellAddress.FirstRow), i, cellAddress.FirstColumn, cellAddress.LastColumn));
                                }
                                if (rowIndex_Source == cellAddress.FirstRow)
                                {
                                   // targetRow.Cells[m].SetCellValue(value);

                                }
                            }

                        }
                        else
                        {
                            //colIndex++;
                            //result.Add(new CellRangeAddress(targetRow.RowNum, targetRow.RowNum, m, m));
                            if (m == 0)
                            {
                                colCount = 1;
                            }
                            else
                            {
                                colCount++;
                            }
                            key = targetRow.RowNum.ToString() + "_" + colCount.ToString();//第几行_第几列 
                            result.Add(key, new CellRangeAddress(targetRow.RowNum, targetRow.RowNum, m, m));

                           // targetRow.Cells[m].SetCellValue(value);

                        }
                        #endregion
                    }
                }
            }
            return result;
        }


    }
}
