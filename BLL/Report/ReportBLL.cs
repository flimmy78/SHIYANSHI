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
//using Microsoft.Office.Interop.Word;

namespace Langben.Report
{
    /// <summary>
    /// 报告业务逻辑
    /// </summary>
    public partial class ReportBLL
    {
        /// <summary>
        /// 模板中所有的合并的单元格
        /// </summary>
        Dictionary<string, List<CellRangeAddress>> returnList = new Dictionary<string, List<CellRangeAddress>>();
        List<int> DeleteRowList = new List<int>();
        /// <summary>
        ///  获取合并区域信息
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private Dictionary<string, List<CellRangeAddress>> GetMergedCellRegion(ISheet sheet)
        {
            if (!returnList.ContainsKey(sheet.SheetName))
            {
                int mergedRegionCellCount = sheet.NumMergedRegions;
                List<CellRangeAddress> cellList = new List<CellRangeAddress>();

                for (int i = 0; i < mergedRegionCellCount; i++)
                {
                    cellList.Add(sheet.GetMergedRegion(i));
                }
                returnList.Add(sheet.SheetName, cellList);

            }


            return returnList;
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
            List<CellRangeAddress> result = null;
            if (!returnList.ContainsKey(sheet.SheetName))
            {
                GetMergedCellRegion(sheet);

            }
            result = returnList[sheet.SheetName];
            return (from c in result
                    where columnIndex >= c.FirstColumn && columnIndex <= c.LastColumn && rowIndex >= c.FirstRow && rowIndex <= c.LastRow
                    select c).FirstOrDefault();

        }

        /// <summary>
        /// 获取特殊字符配置信息
        /// </summary>
        /// <returns></returns>
        public SpecialCharacters GetSpecialCharacters()
        {
            SpecialCharacters result = null;
            if (ReportStatic.SpecialCharacterXml != null && ReportStatic.SpecialCharacterXml.Trim() != "")
            {
                result = SpecialCharacters.XmlCovertObj(ReportStatic.SpecialCharacterXml);
            }
            return result;
        }
        /// <summary>
        /// 获取所有报告配置信息
        /// </summary>
        /// <param name="type">报告类型</param>
        /// <returns></returns>
        public TableTemplates GetTableTemplates(ExportType type = ExportType.OriginalRecord_JianDing)
        {
            TableTemplates result = null;
            if (ReportStatic.TableTemplateXml != null && ReportStatic.TableTemplateXml.Trim() != "")
            {
                switch (type)
                {
                    case ExportType.OriginalRecord_JianDing:
                    case ExportType.OriginalRecord_XiaoZhun:
                        result = TableTemplates.XmlCovertObj(ReportStatic.TableTemplateXml);
                        break;
                    case ExportType.Report_JianDing:
                        result = TableTemplates.XmlCovertObj(ReportStatic.TableTemplate_JianDingXml);
                        break;
                    case ExportType.Report_XiaoZhun:
                        result = TableTemplates.XmlCovertObj(ReportStatic.TableTemplate_JiaoZhunXml);
                        break;
                    case ExportType.Report_XiaoZhun_CNAS:
                        result = TableTemplates.XmlCovertObj(ReportStatic.TableTemplate_JiaoZhunXml);
                        break;
                    default:
                        result = TableTemplates.XmlCovertObj(ReportStatic.TableTemplateXml);
                        break;

                }

            }
            return result;
        }
        /// <summary>
        ///  /// <summary>
        /// 以上传附件的形式添加记录签名位置
        /// </summary>
        /// <param name="ID">预备方案ID</param>
        /// <param name="err">返回错误信息</param>
        /// <returns></returns>
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool UpdateFuJianRemark(string ID, out string err)
        {
            string errMsg = "";
            bool BaoGao = UpdateFuJianRemark_BaoGao(ID, out errMsg);
            err = errMsg;
            bool YuanShiJiLu = UpdateFuJianRemark2_YuanShiJiLu(ID, out errMsg);
            err += errMsg;
            if (BaoGao && YuanShiJiLu)
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// 以上传附件的形式添加报告记录，设置报告中批准人、核验员、检定员\校准员位置
        /// </summary>
        /// <param name="ID">预备方案ID</param>
        /// <param name="err">返回错误信息</param>
        /// <returns></returns>
        public bool UpdateFuJianRemark_BaoGao(string ID, out string err)
        {
            err = "";
            try
            {
                ValidationErrors validationErrors = new ValidationErrors();
                IBLL.IFILE_UPLOADERBLL fBll = new BLL.FILE_UPLOADERBLL();
                FILE_UPLOADER fEntity = fBll.GetEntityByPREPARE_SCHEMEID(ID);
                if (fEntity == null)
                {
                    err = "未找到附件表数据";
                    return false;
                }
                IBLL.IPREPARE_SCHEMEBLL m_BLL = new PREPARE_SCHEMEBLL();
                PREPARE_SCHEME entity = m_BLL.GetById(ID);

                if (entity == null)
                {
                    err = "未找到预备方案数据" + ID;
                    return false;
                }
                string xlsPath = fEntity.FULLPATH;
                if (!System.IO.File.Exists(xlsPath))
                {
                    err = "未找附件" + xlsPath;
                    return false;
                }
                if (fEntity.SUFFIX == null || (fEntity.SUFFIX.Trim() != ".xls" && fEntity.SUFFIX.Trim() != "xls"))
                {
                    err = "附件后缀不是.xls";
                    return false;
                }

                FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.ReadWrite);
                IWorkbook hssfworkbook = new HSSFWorkbook(file);

                string sheetName_Destination = "第二页";//查找CNAS
                ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);
                int rowIndex = -1;
                if (sheet_Destination != null)
                {
                    for (int i = 0; i <= sheet_Destination.LastRowNum; i++)
                    {
                        if (sheet_Destination.GetRow(i).Cells[2].StringCellValue == "校准员：")
                        {
                            rowIndex = i;
                            break;
                        }
                    }
                }
                if (rowIndex >= 0)//CNAS
                {
                    string fRemark = "";//批准人行号_批准人列号|核验员行号_核验员列号|检定员/校准员行号_检定员/校准员列号                   
                    fRemark = "26_18|" + rowIndex.ToString() + "_15|" + rowIndex.ToString() + "_5";
                    fEntity.REMARK = fRemark;
                }
                else//非CNAS
                {
                    //批准人行号_批准人列号|核验员行号_核验员列号|检定员/校准员行号_检定员/校准员列号  
                    fEntity.REMARK = "33_13|35_13|37_13";//添加签名位置
                }

                if (fBll.Edit(ref validationErrors, fEntity))
                {
                    return true;
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        string err1 = "";
                        validationErrors.All(a =>
                        {
                            err1 += a.ErrorMessage;
                            return true;
                        });
                        err = err1;
                    }

                    return false;
                }


            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;

            }
        }
        /// <summary>
        /// 以上传附件的形式添加原始记录，设置原始报告中检定员、核验员位置
        /// </summary>
        /// <param name="ID">预备方案ID</param>
        /// <param name="err">返回错误信息</param>
        /// <returns></returns>
        public bool UpdateFuJianRemark2_YuanShiJiLu(string ID, out string err)
        {
            err = "";
            try
            {
                ValidationErrors validationErrors = new ValidationErrors();
                IBLL.IFILE_UPLOADERBLL fBll = new BLL.FILE_UPLOADERBLL();
                FILE_UPLOADER fEntity = fBll.GetEntityByPREPARE_SCHEMEID(ID);
                if (fEntity == null)
                {
                    err = "未找到附件表数据";
                    return false;
                }
                IBLL.IPREPARE_SCHEMEBLL m_BLL = new PREPARE_SCHEMEBLL();
                PREPARE_SCHEME entity = m_BLL.GetById(ID);

                if (entity == null)
                {
                    err = "未找到预备方案数据" + ID;
                    return false;
                }
                string xlsPath = fEntity.FULLPATH2;
                if (!System.IO.File.Exists(xlsPath))
                {
                    err = "未找附件" + xlsPath;
                    return false;
                }
                if (fEntity.SUFFIX2 == null || (fEntity.SUFFIX2.Trim() != ".xls" && fEntity.SUFFIX2.Trim() != "xls"))
                {
                    err = "附件后缀不是.xls";
                    return false;
                }
                FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.ReadWrite);
                IWorkbook hssfworkbook = new HSSFWorkbook(file);

                string sheetName_Destination = "封皮";
                ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);
                int rowIndex = -1;
                for (int i = 0; i <= sheet_Destination.LastRowNum; i++)
                {
                    if (sheet_Destination.GetRow(i).Cells[0].StringCellValue == "检定员：" || sheet_Destination.GetRow(i).Cells[0].StringCellValue == "校准员：")
                    {
                        rowIndex = i;
                        break;
                    }
                }
                if (rowIndex >= 0)
                {
                    string fRemark = "";//用于记录检定员/校准员行号_检定员/校准员列号|核验员行号_核验员列号;
                    fRemark = rowIndex.ToString() + "_5|" + rowIndex.ToString() + "_23";
                    fEntity.REMARK2 = fRemark;

                    if (fBll.Edit(ref validationErrors, fEntity))
                    {
                        return true;
                    }
                    else
                    {
                        if (validationErrors != null && validationErrors.Count > 0)
                        {
                            string err1 = "";
                            validationErrors.All(a =>
                            {
                                err1 += a.ErrorMessage;
                                return true;
                            });
                            err = err1;
                        }

                        return false;
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;

            }


        }
        /// <summary>
        /// 添加签名
        /// </summary>
        /// <param name="ID">预备方案ID</param>
        ///<param name="REPORTSTATUS">报告状态</param>
        ///<param name="err">错误信息</param>
        public bool AddQianMing(string ID, string REPORTSTATUS, out string err)
        {
            err = "";

            try
            {
                if (string.IsNullOrWhiteSpace(ID))
                {
                    err = "请输入预备方案ID";
                    return false;
                }

                ValidationErrors validationErrors = new ValidationErrors();
                IBLL.IFILE_UPLOADERBLL fBll = new BLL.FILE_UPLOADERBLL();
                FILE_UPLOADER fEntity = fBll.GetEntityByPREPARE_SCHEMEID(ID);
                if (fEntity == null)
                {
                    err = "未找到附件表数据";
                    return false;
                }
                IBLL.IPREPARE_SCHEMEBLL m_BLL = new PREPARE_SCHEMEBLL();
                PREPARE_SCHEME entity = m_BLL.GetById(ID);

                if (entity == null)
                {
                    err = "未找到预备方案数据" + ID;
                    return false;
                }
                Dictionary<string, SysPerson> picList = GetPerson(entity);

                ExportType type = GetExportType(entity, "Report");

                AddQianMing_YuanShiJiLu(entity, picList, fEntity, REPORTSTATUS);//更新原始记录签名

                AddQianMing_BaoGao(entity, picList, fEntity, type, REPORTSTATUS);//更新报告签名
                //AddQianMing_Word(entity, picList, fEntity, type);//更新Word签名
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }


        }
        ///// <summary>
        ///// Word签名
        ///// </summary>
        ///// <param name="entity">预备方案对象</param>
        ///// <param name="hssfworkbook">exel</param>
        ///// <param name="picList">操作人信息集合</param>
        ///// <param name="fEntity">附件对象</param>
        ///// <returns></returns>
        //public void AddQianMing_Word(PREPARE_SCHEME entity, Dictionary<string, SysPerson> picList, FILE_UPLOADER fEntity, ExportType type)
        //{

        //    string filePath = @"F:\Projects\国家电网实验室项目\Doc\报告\电测所20110508003压降报-1.doc";//Word地址            
        //    string picPath = @"F:\Projects\国家电网实验室项目\NewCode\App\up\image\11.png";//签名图片地址

        //    if (fEntity.SUFFIX == null || (fEntity.SUFFIX.Trim() != ".doc" && fEntity.SUFFIX.Trim() != "doc" && fEntity.SUFFIX.Trim()!=".docx" && fEntity.SUFFIX.Trim()!="docx"))
        //    {
        //        //err = "附件后缀不是.doc\.docx";
        //        return;
        //    }

        //    object Nothing = System.Reflection.Missing.Value;
        //    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        //    Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
        //    object Obj_FileName = filePath;
        //    object Visible = false;
        //    object ReadOnly = false;
        //    object missing = System.Reflection.Missing.Value;           
        //    try
        //    {
        //        //打开文件
        //        doc = app.Documents.Open(ref Obj_FileName, ref missing, ref ReadOnly, ref missing,
        //            ref missing, ref missing, ref missing, ref missing,
        //            ref missing, ref missing, ref missing, ref Visible,
        //            ref missing, ref missing, ref missing,
        //            ref missing);
        //        doc.Activate();

        //        //--判断word文件是否存在·不存在则略过插入。
        //        if (!System.IO.File.Exists(filePath))
        //        {
        //            return;
        //        }


        //        foreach (Microsoft.Office.Interop.Word.Bookmark bm in doc.Bookmarks)
        //        {
        //            if (bm.Name == "批准签字处")
        //            {
        //                bm.Select();
        //                //要插入的图片文件
        //                app.Selection.InlineShapes.AddPicture(picPath, ref missing, ref missing, ref missing);
        //                doc.Application.ActiveDocument.InlineShapes[1].Width = (float)140; // 图片宽度 
        //                doc.Application.ActiveDocument.InlineShapes[1].Height = (float)30; // 图片高度                            
        //            }
        //            else if(bm.Name == "批准签字处")
        //            {
        //                bm.Select();
        //                //要插入的图片文件
        //                app.Selection.InlineShapes.AddPicture(picPath, ref missing, ref missing, ref missing);
        //                doc.Application.ActiveDocument.InlineShapes[1].Width = (float)140; // 图片宽度 
        //                doc.Application.ActiveDocument.InlineShapes[1].Height = (float)30; // 图片高度    
        //            }
        //            else if(bm.Name == "批准签字处")
        //            {
        //                bm.Select();
        //                //要插入的图片文件
        //                app.Selection.InlineShapes.AddPicture(picPath, ref missing, ref missing, ref missing);
        //                doc.Application.ActiveDocument.InlineShapes[1].Width = (float)140; // 图片宽度 
        //                doc.Application.ActiveDocument.InlineShapes[1].Height = (float)30; // 图片高度    
        //            }

        //        }              
        //        doc.Save();


        //    }
        //    catch (Exception mage)
        //    {
        //        //写入系统日志
        //        /*暂略*/
        //    }
        //    finally
        //    {

        //        /*--- C# 读写Word ：提示将 Word 用作自动化服务器时提示保存 Normal.dot (解决方案之1)   ----*/
        //        /////使用 Quit 方法的 SaveChanges 参数，如下所示： 
        //        ////object SaveOption, OriginalFormat, RouteDocument;
        //        ////SaveOption = Word.WdSaveOptions.wdPromptToSaveChanges;
        //        ////OriginalFormat = Word.WdOriginalFormat.wdPromptUser;
        //        ////RouteDocument = Missing.Value;
        //        ////if (wa != null)
        //        ////{
        //        ////    wa.Quit(ref SaveOption, ref OriginalFormat, ref RouteDocument);
        //        ////    wa = null;
        //        ////}

        //        /*--- C# 读写Word ：提示将 Word 用作自动化服务器时提示保存 Normal.dot (解决方案之2)   ----*/
        //        ///// wdApp2.Quit 方法的调用语句之前，添加以下行：
        //        app.NormalTemplate.Saved = true;


        //        //关闭网页doc
        //        doc.Close(ref Nothing, ref Nothing, ref Nothing);
        //        if (doc != null)
        //        {
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
        //            doc = null;
        //        }
        //        //关闭wordApp
        //        app.Quit(ref Nothing, ref Nothing, ref Nothing);
        //        if (app != null)
        //        {
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        //            app = null;
        //        }
        //        //释放word进程
        //        GC.Collect();
        //    }
        //}
        /// <summary>
        /// 报告添加签名（需要图片签名）
        /// </summary>
        /// <param name="entity">预备方案对象</param>
        /// <param name="hssfworkbook">exel</param>
        /// <param name="picList">操作人信息集合</param>
        /// <param name="fEntity">附件对象</param>
        /// <param name="type">报告类型</param>
        /// <param name="REPORTSTATUS">报告状态</param>
        public void AddQianMing_BaoGao(PREPARE_SCHEME entity, Dictionary<string, SysPerson> picList, FILE_UPLOADER fEntity, ExportType type, string REPORTSTATUS)
        {
            string xlsPath = fEntity.FULLPATH;

            if (!System.IO.File.Exists(xlsPath))
            {
                return;
            }

            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.ReadWrite);
            IWorkbook hssfworkbook = new HSSFWorkbook(file);
            ISheet sheet_Destination2 = null;

            string sheetName_Destination = "封皮";
            string sheetName_Destination2 = "第二页";
            if ((entity.CONCLUSION == "不合格" || fEntity.CONCLUSION == "不合格") && type == ExportType.Report_JianDing)//不合格只有通知书封皮，上传的结论存在附件 FILE_UPLOADER中了，非上传存在预备方案PREPARE_SCHEME中 2017.3.23
            {
                sheetName_Destination = "通知书封皮";
            }
            else if (type == ExportType.Report_XiaoZhun_CNAS)//CNAS只有第二页
            {
                sheetName_Destination2 = "第二页";
                sheet_Destination2 = hssfworkbook.GetSheet(sheetName_Destination2);
            }
            ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);


            #region 批准人
            string picPath = "";
            byte[] bytes = null;
            if (fEntity.Row_PiZhunRen != -1 && fEntity.Col_PiZhunRen != -1)
            {
                if (!string.IsNullOrWhiteSpace(entity.APPROVALEPERSON))
                {
                    if (picList != null && picList.ContainsKey(entity.APPROVALEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.APPROVALEPERSON].HDpic))
                    {
                        picPath = System.Web.HttpContext.Current.Server.MapPath(picList[entity.APPROVALEPERSON].HDpic);
                        if (System.IO.File.Exists(picPath) && REPORTSTATUS == Common.REPORTSTATUS.已批准.ToString())//只有批准同意后才添加图片签名，其他时候都只是改名字 2017.3.22
                        {

                            bytes = System.IO.File.ReadAllBytes(picPath);
                            int pictureIdx = hssfworkbook.AddPicture(bytes, PictureType.PNG);
                            IDrawing patriarch = sheet_Destination.CreateDrawingPatriarch();
                            IClientAnchor anchor = null;
                            if (type == ExportType.Report_XiaoZhun_CNAS)
                            {
                                anchor = new HSSFClientAnchor(55, 20, 250, 250, fEntity.Col_PiZhunRen, fEntity.Row_PiZhunRen, fEntity.Col_PiZhunRen + 8, fEntity.Row_PiZhunRen);
                            }
                            else
                            {
                                anchor = new HSSFClientAnchor(160, 160, 160, 160, fEntity.Col_PiZhunRen, fEntity.Row_PiZhunRen, fEntity.Col_PiZhunRen + 3, fEntity.Row_PiZhunRen + 1);
                            }
                            IPicture pict = patriarch.CreatePicture(anchor, pictureIdx);
                            //pict.Resize();
                            sheet_Destination.GetRow(fEntity.Row_PiZhunRen).GetCell(fEntity.Col_PiZhunRen).SetCellValue("");
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(picList[entity.APPROVALEPERSON].MyName))
                            {
                                sheet_Destination.GetRow(fEntity.Row_PiZhunRen).GetCell(fEntity.Col_PiZhunRen).SetCellValue(picList[entity.APPROVALEPERSON].MyName);
                            }
                            else
                            {
                                sheet_Destination.GetRow(fEntity.Row_PiZhunRen).GetCell(fEntity.Col_PiZhunRen).SetCellValue(entity.APPROVALEPERSON);
                            }
                        }

                    }
                    else if (picList != null && picList.ContainsKey(entity.APPROVALEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.APPROVALEPERSON].MyName))
                    {
                        sheet_Destination.GetRow(fEntity.Row_PiZhunRen).GetCell(fEntity.Col_PiZhunRen).SetCellValue(picList[entity.APPROVALEPERSON].MyName);
                    }
                    else
                    {
                        sheet_Destination.GetRow(fEntity.Row_PiZhunRen).GetCell(fEntity.Col_PiZhunRen).SetCellValue(entity.APPROVALEPERSON);
                    }
                }
                else
                {
                    sheet_Destination.GetRow(fEntity.Row_PiZhunRen).GetCell(fEntity.Col_PiZhunRen).SetCellValue("/");
                }
            }

            #endregion

            if (type == ExportType.Report_XiaoZhun_CNAS)
            {
                sheet_Destination = sheet_Destination2;
            }
            #region 核验员
            if (fEntity.Row_HeYanYuan != -1 && fEntity.Col_HeYanYuan != -1)
            {
                if (!string.IsNullOrWhiteSpace(entity.AUDITTEPERSON))
                {
                    if (picList != null && picList.ContainsKey(entity.AUDITTEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.AUDITTEPERSON].HDpic))
                    {
                        picPath = System.Web.HttpContext.Current.Server.MapPath(picList[entity.AUDITTEPERSON].HDpic);
                        if (System.IO.File.Exists(picPath) && REPORTSTATUS == Common.REPORTSTATUS.已批准.ToString())//只有批准同意后才添加图片签名，其他时候都只是改名字 2017.3.22
                        {
                            bytes = System.IO.File.ReadAllBytes(picPath);
                            int pictureIdx = hssfworkbook.AddPicture(bytes, PictureType.PNG);
                            IDrawing patriarch = sheet_Destination.CreateDrawingPatriarch();
                            IClientAnchor anchor = null;
                            if (type == ExportType.Report_XiaoZhun_CNAS)
                            {
                                anchor = new HSSFClientAnchor(50, 50, 200, 200, fEntity.Col_HeYanYuan, fEntity.Row_HeYanYuan, fEntity.Col_HeYanYuan + 4, fEntity.Row_HeYanYuan);
                            }
                            else
                            {
                                anchor = new HSSFClientAnchor(160, 160, 160, 160, fEntity.Col_HeYanYuan, fEntity.Row_HeYanYuan, fEntity.Col_HeYanYuan + 3, fEntity.Row_HeYanYuan + 1);
                            }
                            IPicture pict = patriarch.CreatePicture(anchor, pictureIdx);
                            //pict.Resize();
                            sheet_Destination.GetRow(fEntity.Row_HeYanYuan).GetCell(fEntity.Col_HeYanYuan).SetCellValue("");
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(picList[entity.AUDITTEPERSON].MyName))
                            {
                                sheet_Destination.GetRow(fEntity.Row_HeYanYuan).GetCell(fEntity.Col_HeYanYuan).SetCellValue(picList[entity.AUDITTEPERSON].MyName);
                            }
                            else
                            {
                                sheet_Destination.GetRow(fEntity.Row_HeYanYuan).GetCell(fEntity.Col_HeYanYuan).SetCellValue(entity.AUDITTEPERSON);
                            }
                        }

                    }
                    else if (picList != null && picList.ContainsKey(entity.AUDITTEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.AUDITTEPERSON].MyName))
                    {
                        sheet_Destination.GetRow(fEntity.Row_HeYanYuan).GetCell(fEntity.Col_HeYanYuan).SetCellValue(picList[entity.AUDITTEPERSON].MyName);
                    }
                    else
                    {
                        sheet_Destination.GetRow(fEntity.Row_HeYanYuan).GetCell(fEntity.Col_HeYanYuan).SetCellValue(entity.AUDITTEPERSON);
                    }
                }
                else
                {
                    sheet_Destination.GetRow(fEntity.Row_HeYanYuan).GetCell(fEntity.Col_HeYanYuan).SetCellValue("/");
                }

            }
            #endregion

            #region 检定员/校准员
            if (fEntity.Row_JianDingYuan != -1 && fEntity.Col_JianDingYuan != -1)
            {
                if (!string.IsNullOrWhiteSpace(entity.CREATEPERSON))
                {
                    #region 由于检定员/校准员改为存的是真实姓名，刘腾飞要求改为取名字相同的第一个人，风险如果真实名字有多个的情况下有可能签名显示会不对 2017.3.23
                    if (picList != null && picList.Count > 0 && picList.Values.FirstOrDefault(p => p.MyName == entity.CREATEPERSON) != null)
                    {
                        entity.CREATEPERSON = picList.Values.FirstOrDefault(p => p.MyName == entity.CREATEPERSON).Name;
                    }
                    #endregion 
                    if (picList != null && picList.ContainsKey(entity.CREATEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.CREATEPERSON].HDpic))
                    {
                        picPath = System.Web.HttpContext.Current.Server.MapPath(picList[entity.CREATEPERSON].HDpic);
                        if (System.IO.File.Exists(picPath) && REPORTSTATUS == Common.REPORTSTATUS.已批准.ToString())//只有批准同意后才添加图片签名，其他时候都只是改名字 2017.3.22
                        {
                            bytes = System.IO.File.ReadAllBytes(picPath);
                            int pictureIdx = hssfworkbook.AddPicture(bytes, PictureType.PNG);
                            IDrawing patriarch = sheet_Destination.CreateDrawingPatriarch();
                            IClientAnchor anchor = null;
                            if (type == ExportType.Report_XiaoZhun_CNAS)
                            {
                                anchor = new HSSFClientAnchor(50, 50, 200, 200, fEntity.Col_JianDingYuan, fEntity.Row_JianDingYuan, fEntity.Col_JianDingYuan + 4, fEntity.Row_JianDingYuan);
                            }
                            else
                            {
                                anchor = new HSSFClientAnchor(160, 160, 160, 160, fEntity.Col_JianDingYuan, fEntity.Row_JianDingYuan, fEntity.Col_JianDingYuan + 3, fEntity.Row_JianDingYuan + 1);
                            }
                            IPicture pict = patriarch.CreatePicture(anchor, pictureIdx);
                            //pict.Resize();
                            sheet_Destination.GetRow(fEntity.Row_JianDingYuan).GetCell(fEntity.Col_JianDingYuan).SetCellValue("");
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(picList[entity.CREATEPERSON].MyName))
                            {
                                sheet_Destination.GetRow(fEntity.Row_JianDingYuan).GetCell(fEntity.Col_JianDingYuan).SetCellValue(picList[entity.CREATEPERSON].MyName);
                            }
                            else
                            {
                                sheet_Destination.GetRow(fEntity.Row_JianDingYuan).GetCell(fEntity.Col_JianDingYuan).SetCellValue(entity.CREATEPERSON);
                            }
                        }

                    }
                    else if (picList != null && picList.ContainsKey(entity.CREATEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.CREATEPERSON].MyName))
                    {
                        sheet_Destination.GetRow(fEntity.Row_JianDingYuan).GetCell(fEntity.Col_JianDingYuan).SetCellValue(picList[entity.CREATEPERSON].MyName);
                    }
                    else
                    {
                        sheet_Destination.GetRow(fEntity.Row_JianDingYuan).GetCell(fEntity.Col_JianDingYuan).SetCellValue(entity.CREATEPERSON);
                    }
                }
                else
                {
                    sheet_Destination.GetRow(fEntity.Row_JianDingYuan).GetCell(fEntity.Col_JianDingYuan).SetCellValue("/");
                }
            }
            #endregion

            using (FileStream fileWrite = new FileStream(xlsPath, FileMode.Create))
            {
                hssfworkbook.Write(fileWrite);
            }

        }
        /// <summary>
        /// 原始记录添加签名（只是更新相关人员名字，并不需要图片签名），改为需要图片签名
        /// </summary>
        /// <param name="entity">预备方案对象</param>
        /// <param name="hssfworkbook">exel</param>
        /// <param name="picList">操作人信息集合</param>
        /// <param name="fEntity">附件对象</param>
        /// <param name="REPORTSTATUS">报告状态</param>
        public void AddQianMing_YuanShiJiLu(PREPARE_SCHEME entity, Dictionary<string, SysPerson> picList, FILE_UPLOADER fEntity, string REPORTSTATUS)
        {
            string xlsPath = fEntity.FULLPATH2;

            if (!System.IO.File.Exists(xlsPath))
            {
                return;
            }
            FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.ReadWrite);
            IWorkbook hssfworkbook = new HSSFWorkbook(file);

            string sheetName_Destination = "封皮";
            ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);

            #region 检定员/校准员
            string picPath = "";
            byte[] bytes = null;
            if (fEntity.Row_JianDingYuan_YuanShiJiLu != -1 && fEntity.Col_JianDingYuan_YuanShiJiLu != -1)
            {
                if (!string.IsNullOrWhiteSpace(entity.CREATEPERSON))
                {
                    //if (picList != null && picList.ContainsKey(entity.CREATEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.CREATEPERSON].MyName))
                    //{
                    //    sheet_Destination.GetRow(fEntity.Row_JianDingYuan_YuanShiJiLu).GetCell(fEntity.Col_JianDingYuan_YuanShiJiLu).SetCellValue(picList[entity.CREATEPERSON].MyName);
                    //}
                    //else
                    //{
                    //    sheet_Destination.GetRow(fEntity.Row_JianDingYuan_YuanShiJiLu).GetCell(fEntity.Col_JianDingYuan_YuanShiJiLu).SetCellValue(entity.CREATEPERSON);
                    //}
                    #region 由于检定员/校准员改为存的是真实姓名，刘腾飞要求改为取名字相同的第一个人，风险存在如果真实名字有多个的情况下有可能签名显示会不对 2017.3.23
                    if (picList != null && picList.Count > 0 && picList.Values.FirstOrDefault(p => p.MyName == entity.CREATEPERSON) != null)
                    {
                        entity.CREATEPERSON = picList.Values.FirstOrDefault(p => p.MyName == entity.CREATEPERSON).Name;
                    }
                    #endregion 

                    if (picList != null && picList.ContainsKey(entity.CREATEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.CREATEPERSON].HDpic))
                    {
                        picPath = System.Web.HttpContext.Current.Server.MapPath(picList[entity.CREATEPERSON].HDpic);
                        if (System.IO.File.Exists(picPath) && REPORTSTATUS == Common.REPORTSTATUS.已批准.ToString())//只有批准同意后才添加图片签名，其他时候都只是改名字 2017.3.22
                        {
                            bytes = System.IO.File.ReadAllBytes(picPath);
                            int pictureIdx = hssfworkbook.AddPicture(bytes, PictureType.PNG);
                            IDrawing patriarch = sheet_Destination.CreateDrawingPatriarch();
                            IClientAnchor anchor = new HSSFClientAnchor(50, 50, 200, 200, fEntity.Col_JianDingYuan_YuanShiJiLu, fEntity.Row_JianDingYuan_YuanShiJiLu, fEntity.Col_JianDingYuan_YuanShiJiLu + 7, fEntity.Row_JianDingYuan_YuanShiJiLu);
                            IPicture pict = patriarch.CreatePicture(anchor, pictureIdx);
                            //pict.Resize();
                            sheet_Destination.GetRow(fEntity.Row_JianDingYuan_YuanShiJiLu).GetCell(fEntity.Col_JianDingYuan_YuanShiJiLu).SetCellValue("");
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(picList[entity.CREATEPERSON].MyName))
                            {
                                sheet_Destination.GetRow(fEntity.Row_JianDingYuan_YuanShiJiLu).GetCell(fEntity.Col_JianDingYuan_YuanShiJiLu).SetCellValue(picList[entity.CREATEPERSON].MyName);
                            }
                            else
                            {
                                sheet_Destination.GetRow(fEntity.Row_JianDingYuan_YuanShiJiLu).GetCell(fEntity.Col_JianDingYuan_YuanShiJiLu).SetCellValue(entity.CREATEPERSON);
                            }
                        }

                    }
                    else if (picList != null && picList.ContainsKey(entity.CREATEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.CREATEPERSON].MyName))
                    {
                        sheet_Destination.GetRow(fEntity.Row_JianDingYuan_YuanShiJiLu).GetCell(fEntity.Col_JianDingYuan_YuanShiJiLu).SetCellValue(picList[entity.CREATEPERSON].MyName);
                    }
                    else
                    {
                        sheet_Destination.GetRow(fEntity.Row_JianDingYuan_YuanShiJiLu).GetCell(fEntity.Col_JianDingYuan_YuanShiJiLu).SetCellValue(entity.CREATEPERSON);
                    }
                }
                else
                {
                    sheet_Destination.GetRow(fEntity.Row_JianDingYuan_YuanShiJiLu).GetCell(fEntity.Col_JianDingYuan_YuanShiJiLu).SetCellValue("/");
                }
            }
            #endregion


            #region 核验员
            if (fEntity.Row_HeYanYuan_YuanShiJiLu != -1 && fEntity.Col_HeYanYuan_YuanShiJiLu != -1)
            {
                if (!string.IsNullOrWhiteSpace(entity.AUDITTEPERSON))
                {
                    //if (picList != null && picList.ContainsKey(entity.AUDITTEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.AUDITTEPERSON].MyName))
                    //{
                    //    sheet_Destination.GetRow(fEntity.Row_HeYanYuan_YuanShiJiLu).GetCell(fEntity.Col_HeYanYuan_YuanShiJiLu).SetCellValue(picList[entity.AUDITTEPERSON].MyName);
                    //}
                    //else
                    //{
                    //    sheet_Destination.GetRow(fEntity.Row_HeYanYuan_YuanShiJiLu).GetCell(fEntity.Col_HeYanYuan_YuanShiJiLu).SetCellValue(entity.AUDITTEPERSON);
                    //}
                    if (picList != null && picList.ContainsKey(entity.AUDITTEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.AUDITTEPERSON].HDpic))
                    {
                        picPath = System.Web.HttpContext.Current.Server.MapPath(picList[entity.AUDITTEPERSON].HDpic);
                        if (System.IO.File.Exists(picPath) && REPORTSTATUS == Common.REPORTSTATUS.已批准.ToString())//只有批准同意后才添加图片签名，其他时候都只是改名字 2017.3.22
                        {
                            bytes = System.IO.File.ReadAllBytes(picPath);
                            int pictureIdx = hssfworkbook.AddPicture(bytes, PictureType.PNG);
                            IDrawing patriarch = sheet_Destination.CreateDrawingPatriarch();
                            IClientAnchor anchor = new HSSFClientAnchor(50, 50, 200, 200, fEntity.Col_HeYanYuan_YuanShiJiLu, fEntity.Row_HeYanYuan_YuanShiJiLu, fEntity.Col_HeYanYuan_YuanShiJiLu + 7, fEntity.Row_HeYanYuan_YuanShiJiLu);
                            IPicture pict = patriarch.CreatePicture(anchor, pictureIdx);
                            //pict.Resize();
                            sheet_Destination.GetRow(fEntity.Row_HeYanYuan_YuanShiJiLu).GetCell(fEntity.Col_HeYanYuan_YuanShiJiLu).SetCellValue("");
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(picList[entity.AUDITTEPERSON].MyName))
                            {
                                sheet_Destination.GetRow(fEntity.Row_HeYanYuan_YuanShiJiLu).GetCell(fEntity.Col_HeYanYuan_YuanShiJiLu).SetCellValue(picList[entity.AUDITTEPERSON].MyName);
                            }
                            else
                            {
                                sheet_Destination.GetRow(fEntity.Row_HeYanYuan_YuanShiJiLu).GetCell(fEntity.Col_HeYanYuan_YuanShiJiLu).SetCellValue(entity.AUDITTEPERSON);
                            }
                        }

                    }
                    else if (picList != null && picList.ContainsKey(entity.AUDITTEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.AUDITTEPERSON].MyName))
                    {
                        sheet_Destination.GetRow(fEntity.Row_HeYanYuan_YuanShiJiLu).GetCell(fEntity.Col_HeYanYuan_YuanShiJiLu).SetCellValue(picList[entity.AUDITTEPERSON].MyName);
                    }
                    else
                    {
                        sheet_Destination.GetRow(fEntity.Row_HeYanYuan_YuanShiJiLu).GetCell(fEntity.Col_HeYanYuan_YuanShiJiLu).SetCellValue(entity.AUDITTEPERSON);
                    }
                }
                else
                {
                    sheet_Destination.GetRow(fEntity.Row_HeYanYuan_YuanShiJiLu).GetCell(fEntity.Col_HeYanYuan_YuanShiJiLu).SetCellValue("/");
                }

            }

            #endregion
            using (FileStream fileWrite = new FileStream(xlsPath, FileMode.Create))
            {
                hssfworkbook.Write(fileWrite);
            }

        }

        /// <summary>
        /// 保存报告，存储到附件表
        /// </summary>
        /// <param name="rEntity">附件对象</param>
        /// <param name="type">报告类型</param>
        /// <returns></returns>
        public bool SaveFuJian(FILE_UPLOADER rEntity, ExportType type)
        {
            if (rEntity == null || string.IsNullOrWhiteSpace(rEntity.PREPARE_SCHEMEID) || rEntity.PREPARE_SCHEMEID.Trim() == "")
            {
                return false;
            }
            ValidationErrors validationErrors = new ValidationErrors();
            FILE_UPLOADERBLL fBll = new FILE_UPLOADERBLL();
            FILE_UPLOADER Entity = fBll.GetEntityByPREPARE_SCHEMEID(rEntity.PREPARE_SCHEMEID);
            if (Entity == null)
            {
                return fBll.Create(ref validationErrors, rEntity);
            }
            else
            {
                switch (type)
                {
                    case ExportType.OriginalRecord_JianDing:
                    case ExportType.OriginalRecord_XiaoZhun:
                        Entity.PATH2 = rEntity.PATH2;
                        Entity.FULLPATH2 = rEntity.FULLPATH2;
                        Entity.NAME2 = rEntity.NAME2;
                        Entity.SUFFIX2 = rEntity.SUFFIX2;
                        Entity.STATE2 = rEntity.STATE2;
                        Entity.REMARK2 = rEntity.REMARK2;
                        Entity.CONCLUSION = rEntity.CONCLUSION;
                        Entity.UPDATEPERSON = rEntity.CREATEPERSON;
                        Entity.UPDATETIME = DateTime.Now;
                        break;
                    case ExportType.Report_JianDing:
                    case ExportType.Report_XiaoZhun:
                    case ExportType.Report_XiaoZhun_CNAS:
                        Entity.PATH = rEntity.PATH;
                        Entity.FULLPATH = rEntity.FULLPATH;
                        Entity.NAME = rEntity.NAME;
                        Entity.SUFFIX = rEntity.SUFFIX;
                        Entity.STATE = rEntity.STATE;
                        Entity.REMARK = rEntity.REMARK;
                        Entity.CONCLUSION = rEntity.CONCLUSION;
                        Entity.UPDATEPERSON = rEntity.CREATEPERSON;
                        Entity.UPDATETIME = DateTime.Now;
                        break;
                }
                return fBll.Edit(ref validationErrors, Entity);

            }
        }
        /// <summary>
        /// 导出报告Excel
        /// </summary>
        /// <param name="ID">预备方案ID</param>
        /// <param name="Person">操作人</param>
        /// <param name="Message">返回消息</param>
        /// <param name="fEntity">返回附件实体</param>
        /// <returns></returns>
        public bool ExportReport(string ID, string Person, out string Message, out FILE_UPLOADER fEntity)
        {
            fEntity = new FILE_UPLOADER();
            IBLL.IPREPARE_SCHEMEBLL m_BLL = new PREPARE_SCHEMEBLL();
            PREPARE_SCHEME entity = m_BLL.GetById(ID);
            string saveFileName = "";
            if (entity != null)
            {
                ExportType type = GetExportType(entity, "Report");
                string xlsPath = GetTemplatePath(type);


                HSSFWorkbook _book = new HSSFWorkbook();
                FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
                IWorkbook hssfworkbook = new HSSFWorkbook(file);

                //设置封皮
                string fRemark = "";//用于记录批准人行号_批准人列号|核验员行号_核验员列号|检定员/校准员行号_检定员/校准员列号                
                if (type == ExportType.Report_JianDing)
                {
                    SetFengPi_BaoGaoJianDing(hssfworkbook, entity, out fRemark);
                }
                else
                {
                    SetFengPi_BaoGaoXiaoZhun(hssfworkbook, entity, out fRemark, type);
                }
                //第二页数据
                SetSecond_BaoGao(hssfworkbook, entity, ref fRemark, type);

                //设置数据
                SetShuJu(hssfworkbook, entity, type);

                //隐藏不需要的sheet
                HiddenSheet(hssfworkbook, type, false, entity.CONCLUSION);

                string fileName = SetFileName(type);
                //saveFileName = "../up/Report/" + entity.CERTIFICATE_CATEGORY + "_" + Result.GetNewId() + ".xls";
                saveFileName = "/up/Report/" + fileName + ".xls";
                string saveFileNamePath = System.Web.HttpContext.Current.Server.MapPath(saveFileName);
                using (FileStream fileWrite = new FileStream(saveFileNamePath, FileMode.Create))
                {
                    hssfworkbook.Write(fileWrite);
                }
                Message = "../up/Report/" + fileName + ".xls";
                //if (IsSavePath)
                //{

                //FILE_UPLOADERBLL fBll = new FILE_UPLOADERBLL();
                //FILE_UPLOADER fEntity = new FILE_UPLOADER();                  

                fEntity.CONCLUSION = entity.CONCLUSION;
                fEntity.CREATETIME = DateTime.Now;
                fEntity.PATH = saveFileName;
                fEntity.FULLPATH = saveFileNamePath;
                fEntity.NAME = fileName;
                fEntity.SUFFIX = ".xls";
                fEntity.PREPARE_SCHEMEID = entity.ID;
                fEntity.STATE = "已上传";
                fEntity.CREATEPERSON = Person;
                fEntity.ID = Result.GetNewId();
                fEntity.REMARK = fRemark;
                //ValidationErrors validationErrors = new ValidationErrors();
                //fBll.Create(ref validationErrors, fEntity);
                //}
                FILE_UPLOADER ffEntity = fEntity;
                SaveFuJian(ffEntity, type);//将发送审核记录报告地址改为点生成报告保存报告地址

                return true;
            }
            Message = "未找到预备方案ID为【" + ID + "】的数据";
            return false;
        }
        /// <summary>
        /// 获取报告模板路径
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetTemplatePath(ExportType type = ExportType.OriginalRecord_JianDing)
        {
            string result = ReportStatic.YuanShiJiLuJianDingPath;
            switch (type)
            {
                case ExportType.OriginalRecord_JianDing:
                    result = ReportStatic.YuanShiJiLuJianDingPath;
                    break;
                case ExportType.OriginalRecord_XiaoZhun:
                    result = ReportStatic.YuanShiJiLuXiaoZhunPath;
                    break;
                case ExportType.Report_JianDing:
                    result = ReportStatic.BaoGaoJianDingPath;
                    break;
                case ExportType.Report_XiaoZhun:
                    result = ReportStatic.BaoGaoXiaoZhunPath;
                    break;
                case ExportType.Report_XiaoZhun_CNAS:
                    result = ReportStatic.BaoGaoXiaoZhunCNASPath;
                    break;
            }
            return result;

        }
        /// <summary>
        /// 设置文件名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string SetFileName(ExportType type = ExportType.OriginalRecord_JianDing)
        {
            string result = "jiandingyuanshijilu";
            switch (type)
            {
                case ExportType.OriginalRecord_JianDing:
                    result = "jiandingyuanshijilu";
                    break;
                case ExportType.OriginalRecord_XiaoZhun:
                    result = "jiaozhunyuanshijilu";
                    break;
                case ExportType.Report_JianDing:
                    result = "jiandingbaogao";
                    break;
                case ExportType.Report_XiaoZhun:
                    result = "jiaozhunbaogao";
                    break;
                case ExportType.Report_XiaoZhun_CNAS:
                    result = "CNAS";
                    break;
            }
            result = result + Result.GetNewId();
            return result;
        }
        /// <summary>
        /// 获取报告类型
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="type">Report：报告、OriginalRecord：原始记录</param>
        /// <returns></returns>
        private ExportType GetExportType(PREPARE_SCHEME entity, string type = "Report")
        {
            ExportType result = ExportType.Report_JianDing;
            if (type == "Report")
            {
                if (entity.CERTIFICATE_CATEGORY == ZhengShuLeiBieEnums.校准.ToString())
                {
                    if (entity.CNAS != null && entity.CNAS.Trim() == ShiFouCNAS.Yes.ToString())
                    {
                        result = ExportType.Report_XiaoZhun_CNAS;
                    }
                    else
                    {
                        result = ExportType.Report_XiaoZhun;
                    }
                }
                else
                {
                    result = ExportType.Report_JianDing;
                }
            }
            else
            {
                if (entity.CERTIFICATE_CATEGORY == ZhengShuLeiBieEnums.校准.ToString())
                {
                    result = ExportType.OriginalRecord_XiaoZhun;
                }
                else
                {
                    result = ExportType.OriginalRecord_JianDing;
                }
            }
            return result;
        }
        /// <summary>
        /// 设置校准CNAS报告封皮信息
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <param name="entity"></param>    
        /// <param name="fRemark">签名位置</param>
        private void SetFengPi_BaoGaoXiaoZhun_CNAS(IWorkbook hssfworkbook, PREPARE_SCHEME entity, out string fRemark)
        {
            fRemark = "";
            string sheetName_Destination = "封皮";
            ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);

            #region 封皮
            //单元格从0开始
            //证书编号
            sheet_Destination.GetRow(12).GetCell(18).SetCellValue(entity.REPORTNUMBER);
            if (entity.APPLIANCE_LABORATORY != null && entity.APPLIANCE_LABORATORY.Count > 0)
            {
                IAPPLIANCE_DETAIL_INFORMATIONBLL infBll = new APPLIANCE_DETAIL_INFORMATIONBLL();
                APPLIANCE_DETAIL_INFORMATION infEntity = infBll.GetById(entity.APPLIANCE_LABORATORY.FirstOrDefault().APPLIANCE_DETAIL_INFORMATIONID);
                if (infEntity != null)
                {
                    //器具名称
                    if (infEntity.APPLIANCE_NAME != null && infEntity.APPLIANCE_NAME.Trim() != "")
                    {
                        sheet_Destination.GetRow(14).GetCell(18).SetCellValue(infEntity.APPLIANCE_NAME);
                    }
                    else
                    {
                        sheet_Destination.GetRow(14).GetCell(18).SetCellValue("/");
                    }
                    //型 号/规 格(有型号显示型号，没有显示规格)
                    if (infEntity.VERSION != null && infEntity.VERSION.Trim() != "")//器具型号
                    {
                        sheet_Destination.GetRow(16).GetCell(18).SetCellValue(infEntity.VERSION);
                    }
                    else if (infEntity.APPLIANCE_NAME != null && infEntity.APPLIANCE_NAME.Trim() != "")//计量器具名称
                    {
                        sheet_Destination.GetRow(16).GetCell(18).SetCellValue(infEntity.APPLIANCE_NAME);
                    }
                    else
                    {
                        sheet_Destination.GetRow(16).GetCell(18).SetCellValue("/");
                    }
                    //生产厂家/制 造 单 位
                    if (infEntity.MAKE_ORGANIZATION != null && infEntity.MAKE_ORGANIZATION.Trim() != "")
                    {
                        sheet_Destination.GetRow(18).GetCell(18).SetCellValue(infEntity.MAKE_ORGANIZATION);
                    }
                    else
                    {
                        sheet_Destination.GetRow(18).GetCell(18).SetCellValue("/");
                    }
                    IORDER_TASK_INFORMATIONBLL taskBll = new ORDER_TASK_INFORMATIONBLL();
                    ORDER_TASK_INFORMATION taskEntity = taskBll.GetById(infEntity.ORDER_TASK_INFORMATIONID);
                    if (taskEntity != null)
                    {
                        //委托单位 /送 检 单 位  (改为证书单位）     
                        if (taskEntity.CERTIFICATE_ENTERPRISE != null && taskEntity.CERTIFICATE_ENTERPRISE.Trim() != "")
                        {
                            sheet_Destination.GetRow(20).GetCell(18).SetCellValue(taskEntity.CERTIFICATE_ENTERPRISE);
                        }
                        else
                        {
                            sheet_Destination.GetRow(20).GetCell(18).SetCellValue("/");
                        }
                        //证书单位地址
                        if (taskEntity.CERTIFICATE_ENTERPRISE_ADDRESS != null && taskEntity.CERTIFICATE_ENTERPRISE_ADDRESS.Trim() != "")
                        {
                            sheet_Destination.GetRow(22).GetCell(18).SetCellValue(taskEntity.CERTIFICATE_ENTERPRISE_ADDRESS);
                        }
                        else
                        {
                            sheet_Destination.GetRow(22).GetCell(18).SetCellValue("/");
                        }
                    }
                    else
                    {
                        //委托单位 /送 检 单 位  (改为证书单位）     
                        sheet_Destination.GetRow(20).GetCell(18).SetCellValue("/");
                        //证书单位地址
                        sheet_Destination.GetRow(22).GetCell(18).SetCellValue("/");
                    }
                }
            }

            //检定日期\校 准 日 期
            if (entity.CALIBRATION_DATE.HasValue)
            {
                sheet_Destination.GetRow(24).GetCell(18).SetCellValue(entity.CALIBRATION_DATE.Value.ToString("yyyy年MM月dd日"));
            }
            else
            {
                sheet_Destination.GetRow(24).GetCell(18).SetCellValue("/");
            }

            Dictionary<string, SysPerson> picList = GetPerson(entity);
            //批 准 人(改为审批人)
            if (entity.APPROVALEPERSON == null || entity.APPROVALEPERSON.Trim() == "")
            {
                sheet_Destination.GetRow(26).GetCell(18).SetCellValue("/");
            }
            else
            {
                if (picList != null && picList.ContainsKey(entity.APPROVALEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.APPROVALEPERSON].MyName))
                {
                    sheet_Destination.GetRow(26).GetCell(18).SetCellValue(picList[entity.APPROVALEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(26).GetCell(18).SetCellValue(entity.APPROVALEPERSON);
                }
            }
            fRemark = "26_18";


            #endregion

            sheet_Destination.ForceFormulaRecalculation = true;
        }
        /// <summary>
        /// 设置校准报告封皮信息
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <param name="entity"></param>
        /// <param name="type">报告类型</param>
        private void SetFengPi_BaoGaoXiaoZhun(IWorkbook hssfworkbook, PREPARE_SCHEME entity, out string fRemark, ExportType type = ExportType.Report_XiaoZhun)
        {
            fRemark = "";
            if (type == ExportType.Report_XiaoZhun_CNAS)
            {
                SetFengPi_BaoGaoXiaoZhun_CNAS(hssfworkbook, entity, out fRemark);
                return;//待修改成Word
            }
            string sheetName_Destination = "封皮";
            ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);
            #region 封皮
            //单元格从0开始
            //证书编号
            sheet_Destination.GetRow(12).GetCell(9).SetCellValue(entity.REPORTNUMBER);
            if (entity.APPLIANCE_LABORATORY != null && entity.APPLIANCE_LABORATORY.Count > 0)
            {
                IAPPLIANCE_DETAIL_INFORMATIONBLL infBll = new APPLIANCE_DETAIL_INFORMATIONBLL();
                APPLIANCE_DETAIL_INFORMATION infEntity = infBll.GetById(entity.APPLIANCE_LABORATORY.FirstOrDefault().APPLIANCE_DETAIL_INFORMATIONID);
                if (infEntity != null)
                {
                    //器具名称
                    if (infEntity.APPLIANCE_NAME != null && infEntity.APPLIANCE_NAME.Trim() != "")
                    {
                        sheet_Destination.GetRow(17).GetCell(7).SetCellValue(infEntity.APPLIANCE_NAME);
                    }
                    else
                    {
                        sheet_Destination.GetRow(17).GetCell(7).SetCellValue("/");
                    }
                    //型 号/规 格(有型号显示型号，没有显示规格)
                    if (infEntity.VERSION != null && infEntity.VERSION.Trim() != "")//器具型号
                    {
                        sheet_Destination.GetRow(19).GetCell(7).SetCellValue(infEntity.VERSION);
                    }
                    else if (infEntity.APPLIANCE_NAME != null && infEntity.APPLIANCE_NAME.Trim() != "")//计量器具名称
                    {
                        sheet_Destination.GetRow(19).GetCell(7).SetCellValue(infEntity.APPLIANCE_NAME);
                    }
                    else
                    {
                        sheet_Destination.GetRow(19).GetCell(7).SetCellValue("/");
                    }

                    //出厂编号
                    if (infEntity.FACTORY_NUM != null && infEntity.FACTORY_NUM.Trim() != "")
                    {
                        sheet_Destination.GetRow(21).GetCell(7).SetCellValue(infEntity.FACTORY_NUM);
                    }
                    else
                    {
                        sheet_Destination.GetRow(21).GetCell(7).SetCellValue("/");
                    }
                    //生产厂家/制 造 单 位
                    if (infEntity.MAKE_ORGANIZATION != null && infEntity.MAKE_ORGANIZATION.Trim() != "")
                    {
                        sheet_Destination.GetRow(23).GetCell(7).SetCellValue(infEntity.MAKE_ORGANIZATION);
                    }
                    else
                    {
                        sheet_Destination.GetRow(23).GetCell(7).SetCellValue("/");
                    }
                    IORDER_TASK_INFORMATIONBLL taskBll = new ORDER_TASK_INFORMATIONBLL();
                    ORDER_TASK_INFORMATION taskEntity = taskBll.GetById(infEntity.ORDER_TASK_INFORMATIONID);
                    if (taskEntity != null)
                    {
                        //受理单位
                        if (taskEntity.ACCEPT_ORGNIZATION != null && taskEntity.ACCEPT_ORGNIZATION.Trim() != "")
                        {
                            sheet_Destination.GetRow(3).GetCell(0).SetCellValue(taskEntity.ACCEPT_ORGNIZATION);
                        }
                        //委托单位 /送 检 单 位  (改为证书单位）     
                        if (taskEntity.CERTIFICATE_ENTERPRISE != null && taskEntity.CERTIFICATE_ENTERPRISE.Trim() != "")
                        {
                            sheet_Destination.GetRow(15).GetCell(7).SetCellValue(taskEntity.CERTIFICATE_ENTERPRISE);
                        }
                        else
                        {
                            sheet_Destination.GetRow(15).GetCell(7).SetCellValue("/");
                        }
                        //受理单位信息
                        SetShouLiDangWeiXinXi(sheet_Destination, taskEntity.ACCEPT_ORGNIZATION);
                    }
                }
            }

            Dictionary<string, SysPerson> picList = GetPerson(entity);
            //批 准 人(改为审批人)
            if (entity.APPROVALEPERSON == null || entity.APPROVALEPERSON.Trim() == "")
            {
                sheet_Destination.GetRow(33).GetCell(13).SetCellValue("/");
            }
            else
            {
                if (picList != null && picList.ContainsKey(entity.APPROVALEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.APPROVALEPERSON].MyName))
                {
                    sheet_Destination.GetRow(33).GetCell(13).SetCellValue(picList[entity.APPROVALEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(33).GetCell(13).SetCellValue(entity.APPROVALEPERSON);
                }
            }
            fRemark = "33_13";
            //核验员（改成审核人）
            if (entity.AUDITTEPERSON != null && entity.AUDITTEPERSON.Trim() != "")
            {
                if (picList != null && picList.ContainsKey(entity.AUDITTEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.AUDITTEPERSON].MyName))
                {
                    sheet_Destination.GetRow(35).GetCell(13).SetCellValue(picList[entity.AUDITTEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(35).GetCell(13).SetCellValue(entity.AUDITTEPERSON);
                }
            }
            else
            {
                sheet_Destination.GetRow(35).GetCell(13).SetCellValue("/");
            }
            fRemark += "|35_13";

            //检定员（改为创建人）
            if (entity.CREATEPERSON != null && entity.CREATEPERSON.Trim() != "")
            {
                if (picList != null && picList.ContainsKey(entity.CREATEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.CREATEPERSON].MyName))
                {
                    sheet_Destination.GetRow(37).GetCell(13).SetCellValue(picList[entity.CREATEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(37).GetCell(13).SetCellValue(entity.CREATEPERSON);
                }
            }
            else
            {
                sheet_Destination.GetRow(37).GetCell(13).SetCellValue("/");
            }
            fRemark += "|37_13";
            //检定日期\校 准 日 期
            if (entity.CALIBRATION_DATE.HasValue)
            {
                sheet_Destination.GetRow(42).GetCell(9).SetCellValue(entity.CALIBRATION_DATE.Value.ToString("yyyy年MM月dd日"));
            }
            else
            {
                sheet_Destination.GetRow(42).GetCell(9).SetCellValue("/");
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

            sheet_Destination.ForceFormulaRecalculation = true;
        }
        /// <summary>
        /// 设置检定报告通知书封皮信息
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <param name="entity"></param>
        private void SetFengPi_BaoGaoJianDing_TongZhiShu(IWorkbook hssfworkbook, PREPARE_SCHEME entity, out string fRemark)
        {
            fRemark = "";
            string sheetName_Destination = "通知书封皮";
            ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);
            #region 封皮
            //单元格从0开始
            //证书编号
            sheet_Destination.GetRow(12).GetCell(9).SetCellValue(entity.REPORTNUMBER);
            if (entity.APPLIANCE_LABORATORY != null && entity.APPLIANCE_LABORATORY.Count > 0)
            {
                IAPPLIANCE_DETAIL_INFORMATIONBLL infBll = new APPLIANCE_DETAIL_INFORMATIONBLL();
                APPLIANCE_DETAIL_INFORMATION infEntity = infBll.GetById(entity.APPLIANCE_LABORATORY.FirstOrDefault().APPLIANCE_DETAIL_INFORMATIONID);
                if (infEntity != null)
                {
                    //器具名称
                    if (infEntity.APPLIANCE_NAME != null && infEntity.APPLIANCE_NAME.Trim() != "")
                    {
                        sheet_Destination.GetRow(17).GetCell(7).SetCellValue(infEntity.APPLIANCE_NAME);
                    }
                    else
                    {
                        sheet_Destination.GetRow(17).GetCell(7).SetCellValue("/");
                    }
                    //型 号/规 格(有型号显示型号，没有显示规格)
                    if (infEntity.VERSION != null && infEntity.VERSION.Trim() != "")//器具型号
                    {
                        sheet_Destination.GetRow(19).GetCell(7).SetCellValue(infEntity.VERSION);
                    }
                    else if (infEntity.APPLIANCE_NAME != null && infEntity.APPLIANCE_NAME.Trim() != "")//计量器具名称
                    {
                        sheet_Destination.GetRow(19).GetCell(7).SetCellValue(infEntity.APPLIANCE_NAME);
                    }
                    else
                    {
                        sheet_Destination.GetRow(19).GetCell(7).SetCellValue("/");
                    }

                    //出厂编号
                    if (infEntity.FACTORY_NUM != null && infEntity.FACTORY_NUM.Trim() != "")
                    {
                        sheet_Destination.GetRow(21).GetCell(7).SetCellValue(infEntity.FACTORY_NUM);
                    }
                    else
                    {
                        sheet_Destination.GetRow(21).GetCell(7).SetCellValue("/");
                    }
                    //生产厂家/制 造 单 位
                    if (infEntity.MAKE_ORGANIZATION != null && infEntity.MAKE_ORGANIZATION.Trim() != "")
                    {
                        sheet_Destination.GetRow(23).GetCell(7).SetCellValue(infEntity.MAKE_ORGANIZATION);
                    }
                    else
                    {
                        sheet_Destination.GetRow(23).GetCell(7).SetCellValue("/");
                    }
                    IORDER_TASK_INFORMATIONBLL taskBll = new ORDER_TASK_INFORMATIONBLL();
                    ORDER_TASK_INFORMATION taskEntity = taskBll.GetById(infEntity.ORDER_TASK_INFORMATIONID);
                    if (taskEntity != null)
                    {
                        ////证书单位
                        //if (taskEntity.CERTIFICATE_ENTERPRISE != null && taskEntity.CERTIFICATE_ENTERPRISE.Trim() != "")
                        //{
                        //    sheet_Destination.GetRow(3).GetCell(0).SetCellValue(taskEntity.CERTIFICATE_ENTERPRISE);
                        //}
                        //受理单位
                        if (taskEntity.ACCEPT_ORGNIZATION != null && taskEntity.ACCEPT_ORGNIZATION.Trim() != "")
                        {
                            sheet_Destination.GetRow(3).GetCell(0).SetCellValue(taskEntity.ACCEPT_ORGNIZATION);
                        }
                        //委托单位 /送 检 单 位  (改为证书单位)     
                        if (taskEntity.CERTIFICATE_ENTERPRISE != null && taskEntity.CERTIFICATE_ENTERPRISE.Trim() != "")
                        {
                            sheet_Destination.GetRow(15).GetCell(7).SetCellValue(taskEntity.CERTIFICATE_ENTERPRISE);
                        }
                        else
                        {
                            sheet_Destination.GetRow(15).GetCell(7).SetCellValue("/");
                        }
                        //受理单位信息
                        SetShouLiDangWeiXinXi(sheet_Destination, taskEntity.ACCEPT_ORGNIZATION);
                    }
                }
            }

            #region 检 定 依 据 当规程2个以上时，该处没有“检定依据”隐藏该行，该位置直接显示“检定结论”
            //检定所依据技术文件（代号、名称）
            IVRULEBLL rBll = new VRULEBLL();
            List<VRULE> rList = rBll.GetBySCHEMEID(entity.SCHEMEID);
            if (rList != null && rList.Count == 1)//一个规程
            {
                sheet_Destination.GetRow(25).GetCell(7).SetCellValue(rList[0].NAME);
            }
            else
            {
                HideRow(sheet_Destination, 25, 2);
            }
            #endregion

            //检定结论   
            if (entity.CALIBRATION_INSTRUCTIONS == null || entity.CALIBRATION_INSTRUCTIONS.Trim() == "")
            {
                sheet_Destination.GetRow(27).GetCell(7).SetCellValue("/");
            }
            else
            {
                sheet_Destination.GetRow(27).GetCell(7).SetCellValue(entity.CALIBRATION_INSTRUCTIONS);
            }
            Dictionary<string, SysPerson> picList = GetPerson(entity);
            //批 准 人(改为审批人)
            if (entity.APPROVALEPERSON == null || entity.APPROVALEPERSON.Trim() == "")
            {
                sheet_Destination.GetRow(33).GetCell(13).SetCellValue("/");
            }
            else
            {
                if (picList != null && picList.ContainsKey(entity.APPROVALEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.APPROVALEPERSON].MyName))
                {
                    sheet_Destination.GetRow(33).GetCell(13).SetCellValue(picList[entity.APPROVALEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(33).GetCell(13).SetCellValue(entity.APPROVALEPERSON);
                }
            }

            fRemark = "33_13";

            //核验员（改成审核人）
            if (entity.AUDITTEPERSON != null && entity.AUDITTEPERSON.Trim() != "")
            {
                if (picList != null && picList.ContainsKey(entity.AUDITTEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.AUDITTEPERSON].MyName))
                {
                    sheet_Destination.GetRow(35).GetCell(13).SetCellValue(picList[entity.AUDITTEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(35).GetCell(13).SetCellValue(entity.AUDITTEPERSON);
                }
            }
            else
            {
                sheet_Destination.GetRow(35).GetCell(13).SetCellValue("/");
            }

            fRemark += "|35_13";

            //检定员（改为创建人）
            if (entity.CREATEPERSON != null && entity.CREATEPERSON.Trim() != "")
            {
                if (picList != null && picList.ContainsKey(entity.CREATEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.CREATEPERSON].MyName))
                {
                    sheet_Destination.GetRow(37).GetCell(13).SetCellValue(picList[entity.CREATEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(37).GetCell(13).SetCellValue(entity.CREATEPERSON);
                }
            }
            else
            {
                sheet_Destination.GetRow(37).GetCell(13).SetCellValue("/");
            }

            fRemark += "|37_13";
            //检定日期
            if (entity.CALIBRATION_DATE.HasValue)
            {
                sheet_Destination.GetRow(42).GetCell(9).SetCellValue(entity.CALIBRATION_DATE.Value.ToString("yyyy年MM月dd日"));
            }
            else
            {
                sheet_Destination.GetRow(42).GetCell(9).SetCellValue("/");
            }
            ////有效期，通知书不要有效期
            //if (entity.VALIDITY_PERIOD.HasValue && entity.CALIBRATION_DATE.HasValue)
            //{
            //    //sheet_Destination.GetRow(43).GetCell(9).SetCellValue(entity.VALIDITY_PERIOD.Value.ToString("yyyy年MM月dd日"));                
            //    sheet_Destination.GetRow(43).GetCell(9).SetCellValue(entity.CALIBRATION_DATE.Value.AddYears(entity.VALIDITY_PERIOD.Value).ToString("yyyy年MM月dd日"));
            //}
            //else
            //{
            //    sheet_Destination.GetRow(43).GetCell(9).SetCellValue("/");
            //}
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

            sheet_Destination.ForceFormulaRecalculation = true;
        }
        /// <summary>
        /// 设置报告第二页信息
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <param name="entity"></param>
        /// <param name="fRemark">签名位置</param>
        /// <param name="type">报告类型</param>
        private void SetSecond_BaoGao(IWorkbook hssfworkbook, PREPARE_SCHEME entity, ref string fRemark, ExportType type = ExportType.OriginalRecord_JianDing)
        {
            //fRemark = "";
            string sheetName_Destination = "第二页";
            ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);
            #region 第二页
            //单元格从0开始
            //资质说明
            if (entity.QUALIFICATIONS != null && entity.QUALIFICATIONS.Trim() != "")
            {
                sheet_Destination.GetRow(3).GetCell(2).SetCellValue(entity.QUALIFICATIONS);
            }
            else
            {
                sheet_Destination.GetRow(3).GetCell(2).SetCellValue("/");
            }

            //温度
            if (entity.TEMPERATURE != null && entity.TEMPERATURE.Trim() != "")
            {
                sheet_Destination.GetRow(5).GetCell(6).SetCellValue(entity.TEMPERATURE + "℃");
            }
            else
            {
                sheet_Destination.GetRow(5).GetCell(5).SetCellValue("/");
            }
            //相对湿度
            if (entity.HUMIDITY != null && entity.HUMIDITY.Trim() != "")
            {
                sheet_Destination.GetRow(5).GetCell(20).SetCellValue(entity.HUMIDITY + "%");
            }
            else
            {
                sheet_Destination.GetRow(5).GetCell(20).SetCellValue("/");
            }

            //检定地点
            if (entity.CHECK_PLACE != null && entity.CHECK_PLACE.Trim() != "")
            {
                sheet_Destination.GetRow(6).GetCell(6).SetCellValue(entity.CHECK_PLACE);
            }
            else
            {
                sheet_Destination.GetRow(6).GetCell(6).SetCellValue("/");
            }
            //其他
            if (entity.OTHER != null && entity.OTHER.Trim() != "")
            {
                sheet_Destination.GetRow(6).GetCell(20).SetCellValue(entity.OTHER);
            }
            else
            {
                sheet_Destination.GetRow(6).GetCell(20).SetCellValue("/");
            }
            #region 检 定 依 据 多个时:顺序显示，一行一个，仅一个时：“依据的技术文件”部分不显示，直接显示下边
            //检定所依据技术文件（代号、名称）
            IVRULEBLL rBll = new VRULEBLL();
            List<VRULE> rList = rBll.GetBySCHEMEID(entity.SCHEMEID);
            int RowIndex = 0;
            if (rList != null && (rList.Count > 1 || type == ExportType.Report_XiaoZhun || type == ExportType.Report_XiaoZhun_CNAS))//检定报告两个以上规程，校准报告无论多少都展示
            {

                IRow GCTemplateRow = sheet_Destination.GetRow(8);//获取源格式行
                int GCTemplateIndex = 8;//规程模板行号   
                RowIndex = 8;
                CopyRow(sheet_Destination, GCTemplateIndex + 1, GCTemplateIndex, rList.Count - 1, false);
                foreach (VRULE r in rList)
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(2).SetCellValue(r.NAME);
                    RowIndex++;
                }
            }
            else
            {
                HideRow(sheet_Destination, 7, 2);
                RowIndex = 9;
            }
            #endregion
            //RowIndex++;
            //各类装置
            SetZhuangZhis(hssfworkbook, sheet_Destination, ref RowIndex, entity, type);
            #region 校准说明            
            RowIndex++;
            if (entity.CONCLUSION_EXPLAIN == null || entity.CONCLUSION_EXPLAIN.Trim() == "")
            {
                sheet_Destination.GetRow(RowIndex).GetCell(2).SetCellValue("/");
            }
            else
            {
                sheet_Destination.GetRow(RowIndex).GetCell(2).SetCellValue(entity.CONCLUSION_EXPLAIN);
            }
            #endregion

            if (type == ExportType.Report_XiaoZhun_CNAS)
            {
                RowIndex = RowIndex + 7;

                AccountBLL aBll = new BLL.AccountBLL();
                List<string> personName = new List<string>();
                //批 准 人(改为审批人)2017.1.21
                personName.Add(entity.APPROVALEPERSON);
                //核验员（改成审核人）2017.1.21
                personName.Add(entity.AUDITTEPERSON);
                //检定员（改为创建人）2017.1.21
                personName.Add(entity.CREATEPERSON);
                Dictionary<string, SysPerson> picList = aBll.GetPictureByName(personName);

                //检定员\校准员               
                if (entity.CREATEPERSON != null && entity.CREATEPERSON.Trim() != "")
                {
                    //if (picList != null && picList.Count > 0 && picList.ContainsKey[entity.CREATEPERSON]&& picList[entity.CREATEPERSON].MyName != null && picList[entity.CREATEPERSON].MyName.Trim() != "")
                    //{
                    //    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(picList[entity.CREATEPERSON].MyName);
                    //}
                    //else
                    //{
                    //    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CREATEPERSON);
                    //}
                    //由于检定员/校准员改为存的是真实姓名直接取就可以 2017.3.23
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CREATEPERSON);
                }
                else
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue("/");
                }

                //核验员
                if (entity.AUDITTEPERSON != null && entity.AUDITTEPERSON.Trim() != "")
                {
                    if (picList != null && picList.Count > 0 && picList[entity.AUDITTEPERSON] != null && picList[entity.AUDITTEPERSON].MyName != null && picList[entity.AUDITTEPERSON].MyName.Trim() != "")
                    {
                        sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(picList[entity.AUDITTEPERSON].MyName);
                    }
                    else
                    {
                        sheet_Destination.GetRow(RowIndex).GetCell(15).SetCellValue(entity.AUDITTEPERSON);
                    }
                }
                else
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(15).SetCellValue("/");
                }
                //fRemark = "";//批 准 人,在首页上
                fRemark += "|" + RowIndex.ToString() + "_15";//核 验 员
                fRemark += "|" + RowIndex.ToString() + "_5";//检 定 员
            }
            #endregion

            //设置页面页脚
            SetHeaderAndFooter(sheet_Destination, entity, type);
            sheet_Destination.ForceFormulaRecalculation = true;
        }
        /// <summary>
        /// 设置检定报告封皮信息
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <param name="entity"></param>
        private void SetFengPi_BaoGaoJianDing(IWorkbook hssfworkbook, PREPARE_SCHEME entity, out string fRemark)
        {
            fRemark = "";
            if (entity.CONCLUSION == "不合格")//不合格只有通知书封皮
            {
                SetFengPi_BaoGaoJianDing_TongZhiShu(hssfworkbook, entity, out fRemark);
                return;
            }

            string sheetName_Destination = "封皮";
            ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);
            #region 封皮
            //单元格从0开始
            //证书编号
            sheet_Destination.GetRow(12).GetCell(9).SetCellValue(entity.REPORTNUMBER);
            if (entity.APPLIANCE_LABORATORY != null && entity.APPLIANCE_LABORATORY.Count > 0)
            {
                IAPPLIANCE_DETAIL_INFORMATIONBLL infBll = new APPLIANCE_DETAIL_INFORMATIONBLL();
                APPLIANCE_DETAIL_INFORMATION infEntity = infBll.GetById(entity.APPLIANCE_LABORATORY.FirstOrDefault().APPLIANCE_DETAIL_INFORMATIONID);
                if (infEntity != null)
                {
                    //器具名称
                    if (infEntity.APPLIANCE_NAME != null && infEntity.APPLIANCE_NAME.Trim() != "")
                    {
                        sheet_Destination.GetRow(17).GetCell(7).SetCellValue(infEntity.APPLIANCE_NAME);
                    }
                    else
                    {
                        sheet_Destination.GetRow(17).GetCell(7).SetCellValue("/");
                    }
                    //型 号/规 格(有型号显示型号，没有显示规格)
                    if (infEntity.VERSION != null && infEntity.VERSION.Trim() != "")//器具型号
                    {
                        sheet_Destination.GetRow(19).GetCell(7).SetCellValue(infEntity.VERSION);
                    }
                    else if (infEntity.APPLIANCE_NAME != null && infEntity.APPLIANCE_NAME.Trim() != "")//计量器具名称
                    {
                        sheet_Destination.GetRow(19).GetCell(7).SetCellValue(infEntity.APPLIANCE_NAME);
                    }
                    else
                    {
                        sheet_Destination.GetRow(19).GetCell(7).SetCellValue("/");
                    }

                    //出厂编号
                    if (infEntity.FACTORY_NUM != null && infEntity.FACTORY_NUM.Trim() != "")
                    {
                        sheet_Destination.GetRow(21).GetCell(7).SetCellValue(infEntity.FACTORY_NUM);
                    }
                    else
                    {
                        sheet_Destination.GetRow(21).GetCell(7).SetCellValue("/");
                    }
                    //生产厂家/制 造 单 位
                    if (infEntity.MAKE_ORGANIZATION != null && infEntity.MAKE_ORGANIZATION.Trim() != "")
                    {
                        sheet_Destination.GetRow(23).GetCell(7).SetCellValue(infEntity.MAKE_ORGANIZATION);
                    }
                    else
                    {
                        sheet_Destination.GetRow(23).GetCell(7).SetCellValue("/");
                    }
                    IORDER_TASK_INFORMATIONBLL taskBll = new ORDER_TASK_INFORMATIONBLL();
                    ORDER_TASK_INFORMATION taskEntity = taskBll.GetById(infEntity.ORDER_TASK_INFORMATIONID);
                    if (taskEntity != null)
                    {
                        //受理单位
                        if (taskEntity.ACCEPT_ORGNIZATION != null && taskEntity.ACCEPT_ORGNIZATION.Trim() != "")
                        {
                            sheet_Destination.GetRow(3).GetCell(0).SetCellValue(taskEntity.ACCEPT_ORGNIZATION);
                        }
                        //委托单位 /送 检 单 位 （改为证书单位）    
                        if (taskEntity.CERTIFICATE_ENTERPRISE != null && taskEntity.CERTIFICATE_ENTERPRISE.Trim() != "")
                        {
                            sheet_Destination.GetRow(15).GetCell(7).SetCellValue(taskEntity.CERTIFICATE_ENTERPRISE);
                        }
                        else
                        {
                            sheet_Destination.GetRow(15).GetCell(7).SetCellValue("/");
                        }
                        //受理单位信息
                        SetShouLiDangWeiXinXi(sheet_Destination, taskEntity.ACCEPT_ORGNIZATION);
                    }
                }
            }

            #region 检 定 依 据 当规程2个以上时，该处没有“检定依据”隐藏该行，该位置直接显示“检定结论”
            //检定所依据技术文件（代号、名称）
            IVRULEBLL rBll = new VRULEBLL();
            List<VRULE> rList = rBll.GetBySCHEMEID(entity.SCHEMEID);
            if (rList != null && rList.Count == 1)//一个规程
            {
                sheet_Destination.GetRow(25).GetCell(7).SetCellValue(rList[0].NAME);
            }
            else
            {
                HideRow(sheet_Destination, 25, 2);
            }
            #endregion

            //检定结论   
            if (entity.CALIBRATION_INSTRUCTIONS == null || entity.CALIBRATION_INSTRUCTIONS.Trim() == "")
            {
                sheet_Destination.GetRow(27).GetCell(7).SetCellValue("/");
            }
            else
            {
                sheet_Destination.GetRow(27).GetCell(7).SetCellValue(entity.CALIBRATION_INSTRUCTIONS);
            }
            Dictionary<string, SysPerson> picList = GetPerson(entity);
            //批 准 人(改为审批人)
            if (entity.APPROVALEPERSON == null || entity.APPROVALEPERSON.Trim() == "")
            {
                sheet_Destination.GetRow(33).GetCell(13).SetCellValue("/");
            }
            else
            {
                if (picList != null && picList.ContainsKey(entity.APPROVALEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.APPROVALEPERSON].MyName))
                {
                    sheet_Destination.GetRow(33).GetCell(13).SetCellValue(picList[entity.APPROVALEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(33).GetCell(13).SetCellValue(entity.APPROVALEPERSON);
                }
            }
            fRemark = "33_13";
            //核验员（改成审核人）
            if (entity.AUDITTEPERSON != null && entity.AUDITTEPERSON.Trim() != "")
            {
                if (picList != null && picList.ContainsKey(entity.AUDITTEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.AUDITTEPERSON].MyName))
                {
                    sheet_Destination.GetRow(35).GetCell(13).SetCellValue(picList[entity.AUDITTEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(35).GetCell(13).SetCellValue(entity.AUDITTEPERSON);
                }
            }
            else
            {
                sheet_Destination.GetRow(35).GetCell(13).SetCellValue("/");
            }
            fRemark += "|35_13";
            //检定员（改为创建人）
            if (entity.CREATEPERSON != null && entity.CREATEPERSON.Trim() != "")
            {
                if (picList != null && picList.ContainsKey(entity.CREATEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.CREATEPERSON].MyName))
                {
                    sheet_Destination.GetRow(37).GetCell(13).SetCellValue(picList[entity.CREATEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(37).GetCell(13).SetCellValue(entity.CREATEPERSON);
                }
            }
            else
            {
                sheet_Destination.GetRow(37).GetCell(13).SetCellValue("/");
            }
            fRemark += "|37_13";
            //检定日期
            if (entity.CALIBRATION_DATE.HasValue)
            {
                sheet_Destination.GetRow(42).GetCell(9).SetCellValue(entity.CALIBRATION_DATE.Value.ToString("yyyy年MM月dd日"));
            }
            else
            {
                sheet_Destination.GetRow(42).GetCell(9).SetCellValue("/");
            }
            //有效期
            //if (entity.VALIDITY_PERIOD.HasValue && entity.CALIBRATION_DATE.HasValue)
            //{
            //    //sheet_Destination.GetRow(43).GetCell(9).SetCellValue(entity.VALIDITY_PERIOD.Value.ToString("yyyy年MM月dd日"));
            //    sheet_Destination.GetRow(43).GetCell(9).SetCellValue(entity.CALIBRATION_DATE.Value.AddYears((int)entity.VALIDITY_PERIOD.Value).AddDays(-1).ToString("yyyy年MM月dd日"));
            //}
            if (entity.VALIDITYEND.HasValue)//有效期改为直接取数据库值
            {
                sheet_Destination.GetRow(43).GetCell(9).SetCellValue(entity.VALIDITYEND.Value.ToString("yyyy年MM月dd日"));

            }
            else
            {
                sheet_Destination.GetRow(43).GetCell(9).SetCellValue("/");
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
            sheet_Destination.ForceFormulaRecalculation = true;
        }
        /// <summary>
        /// 受理单位信息
        /// </summary>
        /// <param name="sheet_Destination">目标sheet</param>
        /// <param name="ShouLiDangWei">受理单位名称</param>       
        private void SetShouLiDangWeiXinXi(ISheet sheet_Destination, string ShouLiDangWei)
        {

            ShouLiDangWeiXinXi model = GetShouLiDangWeiXinXi(ShouLiDangWei);
            //地址
            sheet_Destination.GetRow(46).GetCell(2).SetCellValue(model.dizhi);
            //邮编
            sheet_Destination.GetRow(46).GetCell(14).SetCellValue(model.youbian);
            //电话
            sheet_Destination.GetRow(47).GetCell(2).SetCellValue(model.dianhua);
            //传真
            sheet_Destination.GetRow(47).GetCell(14).SetCellValue(model.chuanzhen);
        }
        /// <summary>
        /// 获取受理单位信息
        /// </summary>
        /// <param name="ShouLiDangWei">受理单元名称</param>
        /// <returns></returns>
        private ShouLiDangWeiXinXi GetShouLiDangWeiXinXi(string ShouLiDangWei)
        {
            ShouLiDangWeiXinXi result = new ShouLiDangWeiXinXi();
            //地址
            result.dizhi = "地址：北京市西城区复兴门外地藏庵南巷1号";
            //邮编
            result.youbian = "邮编：100045";
            //电话
            result.dianhua = "电话：010-88071523";
            //传真
            result.chuanzhen = "传真：010-88071504";
            if (ShouLiDangWei != null && ShouLiDangWei.Trim() != "" && ShouLiDangWei.Trim() == "冀北电力有限公司计量中心")
            {
                result.dizhi = "地址：北京市昌平区回龙观镇二拨子村";
                result.youbian = "邮编：102208";
                result.dianhua = "电话：010-56585812";
                result.chuanzhen = "传真：010-56585804";

            }
            return result;
        }

        /// <summary>
        /// 导出原始记录Excel
        /// </summary>
        /// <param name="ID">预备方案ID</param>
        /// <param name="Person">操作人</param>
        /// <param name="Message">返回消息</param>
        /// <param name="fEntity">返回附件实体</param>
        /// <returns></returns>
        public bool ExportOriginalRecord(string ID, string Person, out string Message, out FILE_UPLOADER fEntity)
        {
            fEntity = new FILE_UPLOADER();
            IBLL.IPREPARE_SCHEMEBLL m_BLL = new PREPARE_SCHEMEBLL();
            PREPARE_SCHEME entity = m_BLL.GetById(ID);
            string saveFileName = "";
            if (entity != null)
            {
                ExportType type = GetExportType(entity, "ExportOriginal");
                //string xlsPath = ReportStatic.YuanShiJiLuJianDingPath;
                //if (entity.CERTIFICATE_CATEGORY == ZhengShuLeiBieEnums.校准.ToString())
                //{
                //    xlsPath = ReportStatic.YuanShiJiLuXiaoZhunPath;
                //}
                string xlsPath = GetTemplatePath(type);
                //HSSFWorkbook _book = new HSSFWorkbook();
                FileStream file = new FileStream(xlsPath, FileMode.Open, FileAccess.Read);
                IWorkbook hssfworkbook = new HSSFWorkbook(file);
                //设置封皮                
                string fRemark = "";//用于记录检定员/校准员行号_检定员/校准员列号|核验员行号_核验员列号
                //设置封皮               
                SetFengPi(hssfworkbook, entity, out fRemark, type);

                //设置不确定度
                bool IsIsHaveBuQueDingDu = SetBuQueDingDu(hssfworkbook, entity, type);

                //设置数据
                SetShuJu(hssfworkbook, entity, type, IsIsHaveBuQueDingDu);

               

                //隐藏不需要的sheet
                HiddenSheet(hssfworkbook, type, IsIsHaveBuQueDingDu, entity.CONCLUSION);

                //saveFileName = "../up/Report/" + entity.CERTIFICATE_CATEGORY + "_" + Result.GetNewId() + ".xls";                
                string fileName = SetFileName(type);
                saveFileName = "/up/Report/" + fileName + ".xls";

                string saveFileNamePath = System.Web.HttpContext.Current.Server.MapPath(saveFileName);
                using (FileStream fileWrite = new FileStream(saveFileNamePath, FileMode.Create))
                {
                    hssfworkbook.Write(fileWrite);
                }
                Message = "../up/Report/" + fileName + ".xls";
                fEntity.CONCLUSION = entity.CONCLUSION;
                fEntity.CREATETIME = DateTime.Now;
                fEntity.PATH2 = saveFileName;
                fEntity.FULLPATH2 = saveFileNamePath;
                fEntity.NAME2 = fileName;
                fEntity.SUFFIX2 = ".xls";
                fEntity.PREPARE_SCHEMEID = entity.ID;
                fEntity.STATE2 = "已上传";
                fEntity.CREATEPERSON = Person;
                fEntity.ID = Result.GetNewId();
                fEntity.REMARK2 = fRemark;
                //ValidationErrors validationErrors = new ValidationErrors();
                //fBll.Create(ref validationErrors, fEntity);  
                FILE_UPLOADER ffEntity = fEntity;
                SaveFuJian(ffEntity, type);//将发送审核记录报告地址改为点生成原始记录保存原始记录地址
                return true;
            }
            Message = "未找到预备方案ID为【" + ID + "】的数据";
            return false;
        }
        /// <summary>
        /// 隐藏不需要的sheet(模板需要隐藏)
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <param name="type"></param
        /// <param name="IsHaveBuQueDingDu">是否有不确定度</param
        /// <param name="CONCLUSION">总结论</param>
        private void HiddenSheet(IWorkbook hssfworkbook, ExportType type, bool IsHaveBuQueDingDu = true, string CONCLUSION = "合格")
        {
            int s = 0;
            switch (type)
            {
                case ExportType.OriginalRecord_JianDing:
                case ExportType.OriginalRecord_XiaoZhun:
                    if (IsHaveBuQueDingDu == false)
                    {
                        s= 2;
                       // hssfworkbook.RemoveSheetAt(2);//不确定度,没有不确定度需要隐藏该sheet
                    }
                    else
                    {
                        s = 3;
                    }
                    while (s!= hssfworkbook.NumberOfSheets)
                    {
                        hssfworkbook.RemoveSheetAt(s);//封皮模板
                    }
                    //for (int i =s; i < hssfworkbook.NumberOfSheets; i++)
                    //{
                    //    hssfworkbook.RemoveSheetAt(s);//封皮模板
                    //}
                    //hssfworkbook.RemoveSheetAt(3);//封皮模板
                    //hssfworkbook.RemoveSheetAt(4);//数据模板
                  //  hssfworkbook.RemoveSheetAt(5);//不确定度模板
                    break;


                case ExportType.Report_JianDing:
                    if (CONCLUSION == "合格")
                    {
                         
                        hssfworkbook.SetSheetHidden(1, SheetState.VeryHidden);//调用这个方法就行了。
                        //hssfworkbook.RemoveSheetAt(1);//通知书
                    }
                    else
                    {
                        hssfworkbook.SetSheetHidden(0, SheetState.VeryHidden);//调用这个方法就行了。
                       // hssfworkbook.RemoveSheetAt(0);//封皮
                    }
                    while (4 != hssfworkbook.NumberOfSheets)
                    {
                        hssfworkbook.RemoveSheetAt(4);//封皮模板
                    }
                    //hssfworkbook.RemoveSheetAt(4);//第二页模板
                    //hssfworkbook.RemoveSheetAt(5);//数据模板                
                    break;
                case ExportType.Report_XiaoZhun:
                    while (3 != hssfworkbook.NumberOfSheets)
                    {
                        hssfworkbook.RemoveSheetAt(3);//封皮模板
                    }
                    //hssfworkbook.RemoveSheetAt(3);//第二页模板
                    //hssfworkbook.RemoveSheetAt(4);//数据模板
                    break;
                case ExportType.Report_XiaoZhun_CNAS:
                    while (3 != hssfworkbook.NumberOfSheets)
                    {
                        hssfworkbook.RemoveSheetAt(3);//封皮模板
                    }
                    //hssfworkbook.RemoveSheetAt(3);//第二页模板
                    //hssfworkbook.RemoveSheetAt(4);//数据模板
                    break;
            }
            hssfworkbook.FirstVisibleTab = 0;//在做RemoveSheetAt()后，设置第一个可视的表单，保证总有一个表单Sheet是可视的。
        }

        /// <summary>
        /// 设置不确定度(返回是否有不确定计算过程)
        /// </summary>
        /// <param name="hssfworkbook">workbook</param>
        /// <param name="entity"></param>
        /// <param name="type"></param>        
        private bool SetBuQueDingDu(IWorkbook hssfworkbook, PREPARE_SCHEME entity, ExportType type = ExportType.OriginalRecord_JianDing)
        {
            if (type == ExportType.OriginalRecord_JianDing || type == ExportType.OriginalRecord_XiaoZhun)
            {
                int ruleCount = 0;
                string sheetName_Source = "不确定度模板";
                string sheetName_Destination = "不确定度";
                ISheet sheet_Source = hssfworkbook.GetSheet(sheetName_Source);
                ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);

                int rowIndex_Destination = 1;

                #region 检测项目            
                if (entity.QUALIFIED_UNQUALIFIED_TEST_ITE != null &&
                    entity.QUALIFIED_UNQUALIFIED_TEST_ITE.Count > 0)
                {
                    SpecialCharacters allSpecialCharacters = GetSpecialCharacters();
                    entity.QUALIFIED_UNQUALIFIED_TEST_ITE = entity.QUALIFIED_UNQUALIFIED_TEST_ITE.OrderBy(p => p.SORT).ToList();

                   

                    foreach (QUALIFIED_UNQUALIFIED_TEST_ITE iEntity in entity.QUALIFIED_UNQUALIFIED_TEST_ITE)
                    {

                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(iEntity.HTMLVALUE);
                        Dictionary<int, List<BuDueDingDu>> buQueDingDuDic = AnalyticHTML.GetBuDueDingDu(doc);
                        if (buQueDingDuDic != null && buQueDingDuDic.Count > 0)
                        {
                            foreach (List<BuDueDingDu> buQueDingDus in buQueDingDuDic.Values)
                            {
                                foreach (BuDueDingDu buQueDingDu in buQueDingDus)
                                {
                                    if (buQueDingDu == null)
                                    {
                                        continue;
                                    }
                                    if (ruleCount != 0)
                                    {
                                        int yuShu = rowIndex_Destination % 30;
                                        if (yuShu == 0)
                                        {
                                            rowIndex_Destination++;
                                        }
                                        else
                                        {
                                            CopyRow_1(sheet_Source, sheet_Destination, 2, rowIndex_Destination + 1, (30 - yuShu), true, null, allSpecialCharacters, null);
                                            rowIndex_Destination = rowIndex_Destination + (30 - yuShu) + 1;
                                        }
                                    }
                                    #region 不确定度的评定 
                                    ruleCount++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 0, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue(ruleCount.ToString() + "." + iEntity.RULENAME + "不确定度的评定");
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(35).SetCellValue(buQueDingDu.pdDDL);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(41).SetCellValue(buQueDingDu.pdText);
                                    rowIndex_Destination++;
                                    #endregion

                                    #region 评定点                               
                                    int pingdingIndex = 1;
                                    if (buQueDingDu.pingding != null && buQueDingDu.pingding.Count > 0)
                                    {
                                        #region 原评定点
                                        //while (buQueDingDu.pingding != null && buQueDingDu.pingding.Count > 0)
                                        //{
                                        //    Dictionary<string, CellRangeAddress> cellAddressList = CopyRow_1(sheet_Source, sheet_Destination, 1, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                        //    int cIndex = 1;
                                        //    string pingDing2 = "";//第二项数据
                                        //    if (cellAddressList != null && cellAddressList.Count > 0)
                                        //    {
                                        //        foreach (CellRangeAddress c in cellAddressList.Values)
                                        //        {
                                        //            MYData d = buQueDingDu.pingding.FirstOrDefault();
                                        //            if (cIndex == 1 && pingdingIndex == 1)//第一行第一个数
                                        //            {
                                        //                sheet_Destination.GetRow(rowIndex_Destination).GetCell(c.FirstColumn).SetCellValue("评定点：");
                                        //            }
                                        //            else if (cIndex == 1)//除第一行外的第一个数
                                        //            {
                                        //                sheet_Destination.GetRow(rowIndex_Destination).GetCell(c.FirstColumn).SetCellValue("");
                                        //            }
                                        //            else
                                        //            {
                                        //                sheet_Destination.GetRow(rowIndex_Destination).GetCell(c.FirstColumn).SetCellValue(d.value);
                                        //                buQueDingDu.pingding.Remove(d);
                                        //            }
                                        //            if (cIndex == 2)
                                        //            {
                                        //                pingDing2 = d.value;
                                        //            }
                                        //            cIndex++;
                                        //        }
                                        //        if (pingDing2 == null || pingDing2.Trim() == "")//评定点第一项如果未输入整行隐藏
                                        //        {
                                        //            HideRow(sheet_Destination, rowIndex_Destination, 1);
                                        //        }
                                        //        else
                                        //        {
                                        //            pingdingIndex++;
                                        //        }
                                        //    }
                                        //    rowIndex_Destination++;

                                        //}
                                        #endregion

                                        #region 将评定点合并到一个单元格                                        
                                        while (buQueDingDu.pingding != null && buQueDingDu.pingding.Count > 0 && buQueDingDu.pingding.Count >= 3)
                                        {

                                            string pingDingValue = "";
                                            for (int i = 0; i < 3; i++)
                                            {
                                                MYData d = buQueDingDu.pingding.FirstOrDefault();
                                                pingDingValue += d.value == null ? "" : d.value;
                                                buQueDingDu.pingding.Remove(d);
                                            }
                                            if (pingDingValue != null && pingDingValue.Trim() != "")
                                            {
                                                Dictionary<string, CellRangeAddress> cellAddressList = CopyRow_1(sheet_Source, sheet_Destination, 1, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                                if (pingdingIndex == 1)//第一行第一个数
                                                {
                                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue("评定点：");

                                                }
                                                else
                                                {
                                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue("");
                                                }
                                                sheet_Destination.GetRow(rowIndex_Destination).GetCell(7).SetCellValue(pingDingValue);
                                                pingdingIndex++;
                                                rowIndex_Destination++;

                                            }

                                        }                                    
                                        

                                        #endregion
                                    }
                                    #endregion

                                    #region 不确定度的A类评定
                                    CopyRow_1(sheet_Source, sheet_Destination, 2, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 3, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 4, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);

                                    HSSFRichTextString value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, buQueDingDu.ddlUA);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue(value);

                                    value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, buQueDingDu.txtBuQueDingA);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(5).SetCellValue(value);

                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 5, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 6, rowIndex_Destination, 1, false, null, allSpecialCharacters, null);
                                    #region 空值显示/
                                    if (string.IsNullOrWhiteSpace(buQueDingDu.A_1_1) || buQueDingDu.A_1_1.Trim() == "")
                                    {
                                        buQueDingDu.A_1_1 = "/";
                                    }
                                    if (string.IsNullOrWhiteSpace(buQueDingDu.A_1_2) || buQueDingDu.A_1_2.Trim() == "")
                                    {
                                        buQueDingDu.A_1_2 = "/";
                                    }
                                    if (string.IsNullOrWhiteSpace(buQueDingDu.A_1_3) || buQueDingDu.A_1_3.Trim() == "")
                                    {
                                        buQueDingDu.A_1_3 = "/";
                                    }
                                    if (string.IsNullOrWhiteSpace(buQueDingDu.A_1_4) || buQueDingDu.A_1_4.Trim() == "")
                                    {
                                        buQueDingDu.A_1_4 = "/";
                                    }
                                    if (string.IsNullOrWhiteSpace(buQueDingDu.A_1_5) || buQueDingDu.A_1_5.Trim() == "")
                                    {
                                        buQueDingDu.A_1_5 = "/";
                                    }


                                    if (string.IsNullOrWhiteSpace(buQueDingDu.A_2_1) || buQueDingDu.A_2_1.Trim() == "")
                                    {
                                        buQueDingDu.A_2_1 = "/";
                                    }
                                    if (string.IsNullOrWhiteSpace(buQueDingDu.A_2_2) || buQueDingDu.A_2_2.Trim() == "")
                                    {
                                        buQueDingDu.A_2_2 = "/";
                                    }
                                    if (string.IsNullOrWhiteSpace(buQueDingDu.A_2_3) || buQueDingDu.A_2_3.Trim() == "")
                                    {
                                        buQueDingDu.A_2_3 = "/";
                                    }
                                    if (string.IsNullOrWhiteSpace(buQueDingDu.A_2_4) || buQueDingDu.A_2_4.Trim() == "")
                                    {
                                        buQueDingDu.A_2_4 = "/";
                                    }
                                    if (string.IsNullOrWhiteSpace(buQueDingDu.A_2_5) || buQueDingDu.A_2_5.Trim() == "")
                                    {
                                        buQueDingDu.A_2_5 = "/";
                                    }
                                    #endregion 
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue(buQueDingDu.A_1_1);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(12).SetCellValue(buQueDingDu.A_1_2);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(23).SetCellValue(buQueDingDu.A_1_3);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(34).SetCellValue(buQueDingDu.A_1_4);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(45).SetCellValue(buQueDingDu.A_1_5);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 7, rowIndex_Destination, 1, false, null, allSpecialCharacters, null);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue(buQueDingDu.A_2_1);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(12).SetCellValue(buQueDingDu.A_2_2);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(23).SetCellValue(buQueDingDu.A_2_3);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(34).SetCellValue(buQueDingDu.A_2_4);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(45).SetCellValue(buQueDingDu.A_2_5);
                                    rowIndex_Destination++;
                                    #endregion

                                    #region 不确定度的B类评定
                                    CopyRow_1(sheet_Source, sheet_Destination, 2, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 9, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 10, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);

                                    value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, buQueDingDu.ddlUB);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue(value);

                                    value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, buQueDingDu.txtBuQueDingB);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(5).SetCellValue(value);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 11, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    rowIndex_Destination++;
                                    if (buQueDingDu.buDueDingDuB != null && buQueDingDu.buDueDingDuB.Count > 0)
                                    {

                                        while (buQueDingDu.buDueDingDuB != null && buQueDingDu.buDueDingDuB.Count > 0)
                                        {
                                            Dictionary<string, CellRangeAddress> cellAddressList = CopyRow_1(sheet_Source, sheet_Destination, 12, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                            if (cellAddressList != null && cellAddressList.Count > 0)
                                            {
                                                foreach (CellRangeAddress c in cellAddressList.Values)
                                                {
                                                    MYData d = buQueDingDu.buDueDingDuB.FirstOrDefault();
                                                    if ((string.IsNullOrWhiteSpace(d.value) || d.value.Trim() == "" || d.value == "null") && d.name != "sourceNum"
                                                        && d.name != "B_WuChaXian_UNIT" && d.name != "B_Ui_UNIT")
                                                    {
                                                        d.value = "/";
                                                    }
                                                    value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, d.value);

                                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(c.FirstColumn).SetCellValue(value);
                                                    buQueDingDu.buDueDingDuB.Remove(d);
                                                }
                                            }
                                            rowIndex_Destination++;

                                        }
                                    }
                                    #endregion

                                    #region 合成不确定度评定Uc
                                    CopyRow_1(sheet_Source, sheet_Destination, 2, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 14, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 15, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);

                                    value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, buQueDingDu.ddlUC);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue(value);

                                    value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, buQueDingDu.txtBuQueDingC);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(5).SetCellValue(value);
                                    rowIndex_Destination++;
                                    #endregion

                                    #region 扩展不确定度评定
                                    CopyRow_1(sheet_Source, sheet_Destination, 2, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 17, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(20).SetCellValue(buQueDingDu.ddlSelectD);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 18, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);

                                    value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, buQueDingDu.ddlUrel);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue(value);

                                    value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, buQueDingDu.txtvalueD);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(5).SetCellValue(value);
                                    rowIndex_Destination++;
                                    #endregion

                                    #region 测量结果报告
                                    CopyRow_1(sheet_Source, sheet_Destination, 2, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 20, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    rowIndex_Destination++;
                                    CopyRow_1(sheet_Source, sheet_Destination, 21, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);

                                    value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, buQueDingDu.txtValueE);
                                    sheet_Destination.GetRow(rowIndex_Destination).GetCell(11).SetCellValue(value);

                                    //sheet_Destination.GetRow(rowIndex_Destination).GetCell(11).CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00E+00");
                                    //sheet_Destination.GetRow(rowIndex_Destination).GetCell(11).CellStyle.Alignment = HorizontalAlignment.Left;



                                    //rowIndex_Destination++;
                                    #endregion

                                    //int yuShu = rowIndex_Destination % 30;
                                    //if (yuShu == 0)
                                    //{
                                    //    //CopyRow_1(sheet_Source, sheet_Destination, 1, rowIndex_Destination, 1, true, null, allSpecialCharacters, null);
                                    //    rowIndex_Destination++;
                                    //}
                                    //else
                                    //{
                                    //    CopyRow_1(sheet_Source, sheet_Destination, 2, rowIndex_Destination+1, (30 - yuShu), true, null, allSpecialCharacters, null);
                                    //    rowIndex_Destination = rowIndex_Destination + (30 - yuShu) + 1;
                                    //}
                                }
                            }
                        }



                    }
                }
                #endregion

                if (ruleCount > 0)//如果不确定过程一个都没有需要隐藏不确定sheet
                {
                   
                   
                    int JWTemplateIndex = 0;//结尾格式                      
                    sheetName_Source = "数据模板";                  
                    sheet_Source = hssfworkbook.GetSheet(sheetName_Source);
                    rowIndex_Destination++;
                    //插入一行空行
                    CopyRow_1(sheet_Source, sheet_Destination, 2, rowIndex_Destination, 1, true, null, null, null);
                    rowIndex_Destination++;
                    //结尾 有不确定度将结尾打到不确定度页                   
                    CopyRow(sheet_Source, sheet_Destination, JWTemplateIndex, rowIndex_Destination, 1, true);
                   

                    //设置页面页脚
                    SetHeaderAndFooter(sheet_Destination, entity);
                    sheet_Destination.ForceFormulaRecalculation = true;
                    return true;
                }
            }
            return false;

        }
        /// <summary>
        /// 设置原始记录封皮信息
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <param name="entity"></param>
        /// <param name="type"></param>
        /// <param name="fRemark"></param>
        private void SetFengPi(IWorkbook hssfworkbook, PREPARE_SCHEME entity, out string fRemark, ExportType type = ExportType.OriginalRecord_JianDing)
        {
            fRemark = "";
            string sheetName_Source = "封皮模板";
            string sheetName_Destination = "封皮";
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
                sheet_Destination.GetRow(11).GetCell(23).SetCellValue(entity.RATED_FREQUENCY + "Hz");
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
                        //委托单位（证书单位）        
                        //if (taskEntity.INSPECTION_ENTERPRISE != null && taskEntity.INSPECTION_ENTERPRISE.Trim() != "")
                        //{
                        //    sheet_Destination.GetRow(6).GetCell(5).SetCellValue(taskEntity.INSPECTION_ENTERPRISE);
                        //}
                        if (taskEntity.CERTIFICATE_ENTERPRISE != null && taskEntity.CERTIFICATE_ENTERPRISE.Trim() != "")
                        {
                            sheet_Destination.GetRow(6).GetCell(5).SetCellValue(taskEntity.CERTIFICATE_ENTERPRISE);
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
            Dictionary<string, SysPerson> picList = GetPerson(entity);

            //检定员(改为创建人)
            if (entity.CREATEPERSON != null && entity.CREATEPERSON.Trim() != "")
            {
                if (picList != null && picList.ContainsKey(entity.CREATEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.CREATEPERSON].MyName))
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(picList[entity.CREATEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CREATEPERSON);
                }
            }
            else
            {
                sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue("/");
            }
            fRemark = RowIndex.ToString() + "_5";

            //核验员（改成审核人）
            if (entity.AUDITTEPERSON != null && entity.AUDITTEPERSON.Trim() != "")
            {

                if (picList != null && picList.ContainsKey(entity.AUDITTEPERSON) && !string.IsNullOrWhiteSpace(picList[entity.AUDITTEPERSON].MyName))
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(23).SetCellValue(picList[entity.AUDITTEPERSON].MyName);
                }
                else
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(23).SetCellValue(entity.AUDITTEPERSON);
                }
            }
            else
            {
                sheet_Destination.GetRow(RowIndex).GetCell(23).SetCellValue("/");
            }
            fRemark += "|" + RowIndex.ToString() + "_23";
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
            if (type == ExportType.OriginalRecord_JianDing)//检定需要打印有效期
            {
                if (entity.VALIDITY_PERIOD.HasValue)
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(23).SetCellValue(entity.VALIDITY_PERIOD.Value.ToString() + "年");
                    //sheet_Destination.GetRow(RowIndex).GetCell(23).SetCellValue(entity.VALIDITY_PERIOD.Value.ToString("yyyy年MM月dd日"));
                }
                else
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(23).SetCellValue("/");
                }
            }
            else//校准去掉有效期
            {
                sheet_Destination.GetRow(RowIndex).GetCell(19).SetCellValue("");
                sheet_Destination.GetRow(RowIndex).GetCell(23).SetCellValue("");

                //有效期底部线去掉                         
                ICellStyle style = hssfworkbook.CreateCellStyle();
                style.BorderTop = BorderStyle.None;
                for (int col = 23; col < 31; col++)
                {
                    ICell targetCell = sheet_Destination.GetRow(RowIndex).GetCell(col);
                    targetCell.CellStyle = style;
                }

            }
            //RowIndex = RowIndex + 2;
            //if (entity.CERTIFICATE_CATEGORY == ZhengShuLeiBieEnums.校准.ToString())
            if (type == ExportType.OriginalRecord_XiaoZhun)
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
                RowIndex = RowIndex + 2;
                if (entity.CALIBRATION_INSTRUCTIONS == null || entity.CALIBRATION_INSTRUCTIONS.Trim() == "")
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue("/");
                }
                else
                {
                    sheet_Destination.GetRow(RowIndex).GetCell(5).SetCellValue(entity.CALIBRATION_INSTRUCTIONS);
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
                RowIndex++;
            }
            RowIndex++;
            //各类装置
            SetZhuangZhis(hssfworkbook, sheet_Destination, ref RowIndex, entity, type);
            #endregion
            //设置页面页脚
            SetHeaderAndFooter(sheet_Destination, entity, type);
            sheet_Destination.ForceFormulaRecalculation = true;
        }
        /// <summary>
        /// 获取封皮批准人、核验员、检定员信息
        /// </summary>
        /// <param name="entity">预备方案对象</param>
        /// <returns></returns>
        private Dictionary<string, SysPerson> GetPerson(PREPARE_SCHEME entity)
        {
            if (entity == null)
            {
                return null;
            }
            List<string> personName = new List<string>();
            AccountBLL aBll = new BLL.AccountBLL();
            //批 准 人(改为审批人)2017.1.21
            personName.Add(entity.APPROVALEPERSON);
            //核验员（改成审核人）2017.1.21
            personName.Add(entity.AUDITTEPERSON);
            //检定员（改为创建人）2017.1.21
            personName.Add(entity.CREATEPERSON);
            Dictionary<string, SysPerson> picList = aBll.GetPictureByName(personName);
            return picList;

        }
        /// <summary>
        /// 设置标准装置/计量标准器信息
        /// </summary>
        /// <param name="sheet_Source">源sheet</param>
        /// <param name="sheet_Destination">目标sheet</param>
        /// <param name="rowIndex_Destination">目标行号</param>
        /// <param name="PREPARE_SCHEMEID">预备方案ID</param>
        /// <param name="type">报告类型</param>
        private void SetZhuangZhis(IWorkbook hssfworkbook, ISheet sheet_Destination, ref int rowIndex_Destination, PREPARE_SCHEME entity, ExportType type)
        {
            //int rowIndex = rowIndex_Destination;
            //标准装置
            int rowIndex_Source_ZhuangZhi = 29;
            //计量器具
            int rowIndex_Source_QiJu = 32;
            //中间试品
            int rowIndex_Source_ShiPin = 35;
            string sheetName_Source = "封皮模板";
            switch (type)
            {
                case ExportType.OriginalRecord_JianDing:
                case ExportType.OriginalRecord_XiaoZhun:
                    sheetName_Source = "封皮模板";
                    rowIndex_Source_ZhuangZhi = 29;
                    rowIndex_Source_QiJu = 32;
                    rowIndex_Source_ShiPin = 35;
                    break;
                case ExportType.Report_JianDing:
                case ExportType.Report_XiaoZhun:
                case ExportType.Report_XiaoZhun_CNAS:
                    sheetName_Source = "第二页模板";
                    rowIndex_Source_ZhuangZhi = 11;
                    rowIndex_Source_QiJu = 14;
                    rowIndex_Source_ShiPin = 17;
                    break;
            }
            ISheet sheet_Source = hssfworkbook.GetSheet(sheetName_Source);
            IMETERING_STANDARD_DEVICEBLL bll = new METERING_STANDARD_DEVICEBLL();
            List<METERING_STANDARD_DEVICE> list = bll.GetPREPARE_SCHEME(entity.ID);
            //List<METERING_STANDARD_DEVICE> list =    bll.GetAll();//测试
            //if (entity.METERING_STANDARD_DEVICE != null)            
            //{
            //List<METERING_STANDARD_DEVICE> list = entity.METERING_STANDARD_DEVICE.ToList();

            if (list != null && list.Count > 0)
            {
                //空三行
                //CopyRow(sheet_Source, sheet_Destination, 2, rowIndex_Destination, 3, true);
                //rowIndex_Destination = rowIndex_Destination + 3;

                //标准装置
                List<METERING_STANDARD_DEVICE> listZhuanZhi = list.FindAll(p => p.CATEGORY == "标准装置");
                SetZhuangZhi(sheet_Source, sheet_Destination, rowIndex_Source_ZhuangZhi, ref rowIndex_Destination, CATEGORYType.标准装置, listZhuanZhi);
                //标准器
                List<METERING_STANDARD_DEVICE> listQiJu = list.FindAll(p => p.CATEGORY == "标准器");
                SetZhuangZhi(sheet_Source, sheet_Destination, rowIndex_Source_QiJu, ref rowIndex_Destination, CATEGORYType.标准器, listQiJu);
                //中间试品
                List<METERING_STANDARD_DEVICE> listShiPin = list.FindAll(p => p.CATEGORY == "中间试品");
                SetZhuangZhi(sheet_Source, sheet_Destination, rowIndex_Source_ShiPin, ref rowIndex_Destination, CATEGORYType.中间试品, listShiPin);
            }
            //}

        }
        /// <summary>
        /// 设置标准装置/计量标准器信息
        /// </summary>
        /// <param name="sheet_Source">源sheet</param>
        /// <param name="sheet_Destination">目标sheet</param>
        /// <param name="rowIndex_Source">源行号</param>
        /// <param name="rowIndex_Destination">目标行号</param>
        /// <param name="type">装置类型</param>
        /// <param name="listZhuanZhi">装置实体</param>
        private void SetZhuangZhi(ISheet sheet_Source, ISheet sheet_Destination, int rowIndex_Source, ref int rowIndex_Destination, CATEGORYType type = CATEGORYType.标准装置, List<METERING_STANDARD_DEVICE> listZhuanZhi = null)
        {
            try
            {


                if (listZhuanZhi != null && listZhuanZhi.Count > 0)
                {
                    //标题
                    CopyRow(sheet_Source, sheet_Destination, rowIndex_Source, rowIndex_Destination, 1, true);
                    rowIndex_Source++;
                    rowIndex_Destination++;
                    //表头
                    CopyRow(sheet_Source, sheet_Destination, rowIndex_Source, rowIndex_Destination, 1, true);
                    rowIndex_Source++;
                    rowIndex_Destination++;

                    #region 数据
                    foreach (METERING_STANDARD_DEVICE item in listZhuanZhi)
                    {
                        CopyRow(sheet_Source, sheet_Destination, rowIndex_Source, rowIndex_Destination, 1, false);

                        int row_SourceHeight = sheet_Source.GetRow(rowIndex_Source).Height;//源行高
                        int maxRowCount = 1;//最大换行数用来控制行高

                        //名称
                        sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue(item.NAME);
                        if (type == CATEGORYType.标准装置)
                        {

                            //测量范围
                            if (!string.IsNullOrWhiteSpace(item.TEST_RANGE))
                            {
                                maxRowCount = item.TEST_RANGE.Split(';').Length;
                                item.TEST_RANGE = item.TEST_RANGE.Replace(";", Environment.NewLine);
                                sheet_Destination.GetRow(rowIndex_Destination).GetCell(7).SetCellValue(item.TEST_RANGE);
                            }

                        }
                        else
                        {
                            //型号
                            sheet_Destination.GetRow(rowIndex_Destination).GetCell(7).SetCellValue(item.XINGHAO);
                            //编号
                            sheet_Destination.GetRow(rowIndex_Destination).GetCell(10).SetCellValue(item.FACTORY_NUM);
                        }

                        #region 不确定度/准确度等级/最大允许误差
                        //不确定度/准确度等级/最大允许误差
                        List<ALLOWABLE_ERROR> aList = item.ALLOWABLE_ERROR.ToList();
                        if (aList != null && aList.Count > 0)
                        {
                            //rowIndex_Source++;
                            string aValue = "";
                            foreach (ALLOWABLE_ERROR aItem in aList)
                            {
                                if (!string.IsNullOrWhiteSpace(aItem.THEACCURACYLEVEL))
                                {

                                    aValue += aItem.THEACCURACYLEVEL + "|,";
                                }
                                else if (!string.IsNullOrWhiteSpace(aItem.MAXCATEGORIES) || !string.IsNullOrWhiteSpace(aItem.MAXVALUE))
                                {

                                    aValue += aItem.MAXCATEGORIES + aItem.MAXVALUE + "|,";
                                }
                                else if (!string.IsNullOrWhiteSpace(aItem.THEUNCERTAINTY) || !string.IsNullOrWhiteSpace(aItem.THEUNCERTAINTYVALUE) || !string.IsNullOrWhiteSpace(aItem.THEUNCERTAINTYNDEXL) || !string.IsNullOrWhiteSpace(aItem.THEUNCERTAINTYVALUEK))
                                {

                                    // aValue += aItem.THEUNCERTAINTY + aItem.THEUNCERTAINTYVALUE + aItem.THEUNCERTAINTYNDEXL +"|"+ aItem.THEUNCERTAINTYVALUEK + ",";
                                    aValue += aItem.THEUNCERTAINTY + aItem.THEUNCERTAINTYVALUE + aItem.THEUNCERTAINTYNDEXL + "|,";
                                }

                            }
                            if (!string.IsNullOrEmpty(aValue) && aValue.Trim() != "")
                            {
                                if (aValue.IndexOf("|,") > 0)
                                {
                                    aValue = aValue.Trim().Remove(aValue.Trim().Length - 2);
                                }
                                else
                                {
                                    aValue = aValue.Trim().Remove(aValue.Trim().Length - 1);
                                }

                                //aValue = aValue.Replace(",", Environment.NewLine);
                                if (maxRowCount < aValue.Split(',').Length)
                                {
                                    maxRowCount = aValue.Split(',').Length;
                                }
                                //aValue = aValue.Replace(",", Environment.NewLine);
                                HSSFRichTextString value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, null, aValue);
                                sheet_Destination.GetRow(rowIndex_Destination).GetCell(13).SetCellValue(value);
                            }
                            else
                            {
                                sheet_Destination.GetRow(rowIndex_Destination).GetCell(13).SetCellValue(aValue);
                            }
                        }
                        #endregion

                        #region 证书编号 有效期至
                        List<METERING_STANDARD_DEVICE_CHECK> mList = item.METERING_STANDARD_DEVICE_CHECK.ToList();
                        if (mList != null && mList.Count > 0)
                        {
                            string cValue = "";//证书编号
                            string vValue = "";//有效期
                            foreach (METERING_STANDARD_DEVICE_CHECK mItem in mList)
                            {
                                if (mItem != null && !string.IsNullOrEmpty(mItem.CERTIFICATE_NUM) && mItem.CERTIFICATE_NUM.Trim() != "")
                                {
                                    cValue += mItem.CERTIFICATE_NUM + ",";
                                }
                                if (mItem != null && mItem.VALID_TO.HasValue)
                                {
                                    vValue += mItem.VALID_TO.Value.ToString("yyyy/MM/dd") + ",";
                                }

                            }
                            if (!string.IsNullOrEmpty(cValue) && cValue.Trim() != "")
                            {
                                if (maxRowCount < cValue.Split(',').Length)
                                {
                                    maxRowCount = cValue.Split(',').Length;
                                }
                                cValue = cValue.Trim().Remove(cValue.Trim().Length - 1);
                                cValue = cValue.Replace(",", Environment.NewLine);
                            }
                            if (!string.IsNullOrEmpty(vValue) && vValue.Trim() != "")
                            {
                                if (maxRowCount < vValue.Split(',').Length)
                                {
                                    maxRowCount = vValue.Split(',').Length;
                                }
                                vValue = vValue.Trim().Remove(vValue.Trim().Length - 1);
                                vValue = vValue.Replace(",", Environment.NewLine);
                            }
                            sheet_Destination.GetRow(rowIndex_Destination).GetCell(20).SetCellValue(cValue);
                            sheet_Destination.GetRow(rowIndex_Destination).GetCell(27).SetCellValue(vValue);

                            //重新设置行高
                            sheet_Destination.GetRow(rowIndex_Destination).Height = (short)(row_SourceHeight * maxRowCount);
                        }
                        #endregion
                        rowIndex_Destination++;
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                ExceptionsHander.WriteExceptions(ex);
                throw;
            }
        }

        /// <summary>
        /// 设置数据信息
        /// </summary>
        /// <param name="hssfworkbook">工作文件</param>
        /// <param name="entity">预备方案对象</param>
        /// <param name="type">导出类型</param>
        /// <param name="IsIsHaveBuQueDingDu">是否有不确定，无不确定度需要打印结尾最后一行，否则不需要打印结尾最后一行（只有原始记录才有不确定度）</param>
        private void SetShuJu(IWorkbook hssfworkbook, PREPARE_SCHEME entity, ExportType type = ExportType.OriginalRecord_JianDing,bool IsIsHaveBuQueDingDu = false)
        {
            List<VTEST_ITE> vList = null;
            if (entity != null)
            {
                IBLL.IVTEST_ITEBLL vBLL = new VTEST_ITEBLL();
                vList = vBLL.GetByPREPARE_SCHEMEID(entity.ID);
            }
            int RowIndex = 1;
            if (type == ExportType.Report_JianDing || type == ExportType.Report_XiaoZhun || type == ExportType.Report_XiaoZhun_CNAS)
            {
                RowIndex = 2;
            }
            int JWTemplateIndex = 0;//结尾格式   
            int ruleTitleTemplateIndex = 1;//检测项目名称
            string sheetName_Source = "数据模板";
            string sheetName_Destination = "数据";
            ISheet sheet_Source = hssfworkbook.GetSheet(sheetName_Source);
            ISheet sheet_Destination = hssfworkbook.GetSheet(sheetName_Destination);
            bool IsHaveHideData = false;//是否有隐藏数据 解决缺少线问题 
            #region 检测项目            
            if (vList != null && vList.Count > 0)
            {

                TableTemplates allTableTemplates = GetTableTemplates(type);
                SpecialCharacters allSpecialCharacters = GetSpecialCharacters();


                entity.QUALIFIED_UNQUALIFIED_TEST_ITE = entity.QUALIFIED_UNQUALIFIED_TEST_ITE.OrderBy(p => p.SORT).ToList();
                int i = 1;
                string SameRuleName = "";
                List<string> SameRuleNameList = GetSameRuleName();
                QUALIFIED_UNQUALIFIED_TEST_ITE iEntity = null;
                foreach (VTEST_ITE iVTEST_ITE in vList)
                {
                    //if (string.IsNullOrWhiteSpace(iVTEST_ITE.PARENTID))//一级检测项不打印
                    //{
                    //    continue;
                    //}

                    //if (iVTEST_ITE.PARENTID != "982-2003_6")
                    //{
                    //    continue;
                    //}
                    //if (iVTEST_ITE.RULEID != "1264-2010_3_1")
                    //{
                    //    continue;
                    //}
                    //if (iVTEST_ITE.RULEID== "1085-2013_6_2" || iVTEST_ITE.RULEID == "1085 -2013_8" || iVTEST_ITE.RULEID == "1085-2013_9" || iVTEST_ITE.RULEID == "1085-2013_10")
                    //{
                    //    continue;
                    //}
                    //if (iVTEST_ITE.RULEID != "622-1997_4" &&  iVTEST_ITE.RULEID != "1005-2005_4" )
                    //{
                    //    continue;
                    //}
                    //if (iVTEST_ITE.RULEID != "1264-2010_3_1")
                    //{
                    //    continue;
                    //}
                    //1085-2013_7电能标准偏差估计值报告不打印
                    if ((type == ExportType.Report_JianDing || type == ExportType.Report_XiaoZhun || type == ExportType.Report_XiaoZhun_CNAS) && iVTEST_ITE.RULEID == "1085-2013_7")
                    {
                        continue;
                    }
                    if (entity.QUALIFIED_UNQUALIFIED_TEST_ITE != null && entity.QUALIFIED_UNQUALIFIED_TEST_ITE.Count > 0 && entity.QUALIFIED_UNQUALIFIED_TEST_ITE.FirstOrDefault(p => p.RULEID == iVTEST_ITE.RULEID) != null)
                    {
                        iEntity = entity.QUALIFIED_UNQUALIFIED_TEST_ITE.FirstOrDefault(p => p.RULEID == iVTEST_ITE.RULEID);
                    }
                    else
                    {
                        iEntity = null;
                    }

                    if (string.IsNullOrWhiteSpace(iVTEST_ITE.PARENTID) && iEntity == null)//一级检测项并且未做不打印
                    {
                        continue;
                    }

                    bool IsBiaoGe = true;//是否画表格

                    #region 检测项目标题     
                    //相同检测项只展示一个标题  

                    bool IsSameRuleName = false;

                    if(type== ExportType.Report_JianDing && (iVTEST_ITE.RULEID== "169-2010_4_2" || iVTEST_ITE.RULEID== "169-2010_4_3"))//检定报告中检测项不打印
                    {
                        continue;
                    }

                    if (((SameRuleNameList != null && SameRuleNameList.Count > 0 && SameRuleNameList.FirstOrDefault(p => p == iVTEST_ITE.NAME) != null)
                        || (iVTEST_ITE.NAME == "基本误差" && iVTEST_ITE.PARENTID == "166-1993_3")
                        || (iVTEST_ITE.NAME == "基本误差" && iVTEST_ITE.PARENTID == "125-2004_9")
                        || (iVTEST_ITE.NAME == "基本误差" && iVTEST_ITE.PARENTID == "1072-2011_6")
                       || (iVTEST_ITE.NAME == "基本误差" && iVTEST_ITE.PARENTID == "1072-2011_6")
                        || (iVTEST_ITE.NAME == "示值误差" && iVTEST_ITE.PARENTID == "982-2003_6")//示值误差982-2003_6
                        )
                        && SameRuleName == iVTEST_ITE.NAME)
                    {

                        IsSameRuleName = true;
                    }
                    string msg = string.Empty;
                    if (iEntity != null && type == ExportType.Report_JianDing)//处理检定报告 是否出表格
                    {
                       
                        IsBiaoGe = IsBiaoGeByDengJi(iEntity, ref msg);
                    }

                    if (IsSameRuleName==false)
                    {
                        string celStr = i.ToString() + "、";

                        if (iVTEST_ITE.NAME != null && iVTEST_ITE.NAME.Trim() != "")
                        {
                            celStr = celStr + iVTEST_ITE.NAME.Trim() + "：";
                        }
                        //结论,只有非表格的才需要打结论
                        if (iEntity != null && (iVTEST_ITE.INPUTSTATE == InputStateEnums.HGBHG.ToString() || iVTEST_ITE.INPUTSTATE == InputStateEnums.WBK.ToString()) && iEntity.CONCLUSION != null && iEntity.CONCLUSION.Trim() != "")
                        {
                            celStr = celStr + iEntity.CONCLUSION.Trim();
                        }
                        else if (iEntity != null && type == ExportType.Report_JianDing && entity.CONCLUSION == "合格")//处理检定报告 总结论是合格 ，如果不合格都出数据，不出合格不合格
                        {
                            //string msg = string.Empty;
                            //IsBiaoGe = IsBiaoGeByDengJi(iEntity, ref msg);
                            if (!IsBiaoGe && (msg != null && msg.Trim() != ""))
                            {
                                celStr = celStr + msg;
                            }
                            //else
                            //{
                            //    celStr = celStr + "/";
                            //}

                        }
                        else if (iEntity != null && type == ExportType.Report_JianDing && entity.CONCLUSION == "不合格")//处理检定报告 总结论是合格 ，如果不合格都出数据，不出合格不合格
                        {
                            //string msg = string.Empty;
                            IsBiaoGe = true;// IsBiaoGeByDengJi(iEntity, ref msg);
                            if (!IsBiaoGe && (msg != null && msg.Trim() != ""))
                            {
                                celStr = celStr + msg;
                            }
                            //else
                            //{
                            //    celStr = celStr + "/";
                            //}

                        }
                        else if (iEntity == null)
                        {
                            celStr = celStr + "/";
                        }                      

                        CopyRow(sheet_Source, sheet_Destination, ruleTitleTemplateIndex, RowIndex, 1, false);

                        sheet_Destination.GetRow(RowIndex).GetCell(0).SetCellValue(celStr);
                        RowIndex++;
                        IsHaveHideData = false;
                        i++;
                    }

                    ////相同检测项只展示一个标题  
                    //bool IsSameRuleName = false;
                    //if (((SameRuleNameList != null && SameRuleNameList.Count > 0 && SameRuleNameList.FirstOrDefault(p => p == iVTEST_ITE.NAME) != null)
                    //    || (iVTEST_ITE.NAME == "基本误差" && iVTEST_ITE.PARENTID == "166-1993_3")
                    //    || (iVTEST_ITE.NAME == "基本误差" && iVTEST_ITE.PARENTID == "125-2004_9")
                    //    || (iVTEST_ITE.NAME == "基本误差" && iVTEST_ITE.PARENTID == "1072-2011_6")
                    //   || (iVTEST_ITE.NAME == "基本误差" && iVTEST_ITE.PARENTID == "1072-2011_6")
                    //    || (iVTEST_ITE.NAME == "示值误差" && iVTEST_ITE.PARENTID == "982-2003_6")//示值误差982-2003_6
                    //    )
                    //    && SameRuleName == iVTEST_ITE.NAME)
                    //{
                    //    // HideRow(sheet_Destination, RowIndex - 2, 2);

                    //    //DeleteRow(sheet_Destination, RowIndex);
                    //    //RowIndex--;
                    //    //DeleteRow(sheet_Destination, RowIndex - 2);
                    //    //DeleteRow(sheet_Destination, RowIndex - 2);
                    //    //RowIndex = RowIndex - 2;

                    //    DeleteRow(sheet_Destination, RowIndex - 1);
                    //    RowIndex = RowIndex - 1;

                    //    IsSameRuleName = true;
                    //}
                    //else
                    //{                        
                    //    IsHaveHideData = false;
                    //    i++;
                    //}

                    #endregion

                    #region 检测项目表格                   


                    if (iEntity != null
                        && allTableTemplates != null && allTableTemplates.TableTemplateList != null && allTableTemplates.TableTemplateList.Count > 0 && allTableTemplates.TableTemplateList.FirstOrDefault(p => p.RuleID == iEntity.RULEID) != null && IsBiaoGe)
                    {
                        #region s化整
                        SHuaZhengRule SHuaZhengRules = ReportStatic.SHuaZhengRules();
                        QUALIFIED_UNQUALIFIED_TEST_ITE iEntity_DianNengBiaoZhunPianChaGuZhiJiSuan = null;
                        if (SHuaZhengRules != null && SHuaZhengRules.DianNengBiaoZhunPianChaGuZhiJiSuan != null && SHuaZhengRules.DianNengBiaoZhunPianChaGuZhiJiSuan.Trim() != "" && SHuaZhengRules.PingHengFuZaiShiYouGongDianNengWuCha != null && SHuaZhengRules.PingHengFuZaiShiYouGongDianNengWuCha.Count > 0 && SHuaZhengRules.PingHengFuZaiShiYouGongDianNengWuCha.FirstOrDefault(p => p == iEntity.RULEID) != null)
                        {
                            iEntity_DianNengBiaoZhunPianChaGuZhiJiSuan = entity.QUALIFIED_UNQUALIFIED_TEST_ITE.FirstOrDefault(p => p.RULEID == SHuaZhengRules.DianNengBiaoZhunPianChaGuZhiJiSuan);
                        }
                        #endregion 

                        TableTemplate temp = allTableTemplates.TableTemplateList.FirstOrDefault(p => p.RuleID == iEntity.RULEID);
                        //解析html表格数据    
                        //int RowIndexT = RowIndex;                       
                        RowIndex = paserData_1(iEntity, IsSameRuleName, sheet_Source, sheet_Destination, RowIndex, temp, ref IsHaveHideData, allSpecialCharacters, type, iEntity_DianNengBiaoZhunPianChaGuZhiJiSuan);
                        RowIndex++;
                        //if (SameRuleNameList != null && SameRuleNameList.Count > 0 && SameRuleNameList.FirstOrDefault(p => p == iVTEST_ITE.NAME) != null && SameRuleName == iVTEST_ITE.NAME)

                        //{
                        //    //为了相同项表格底部没有线                     
                        //    SetBorderTop(hssfworkbook, sheet_Destination, RowIndexT);
                        //}


                        ////为了表格底部没有线
                        //CopyRow(sheet_Source, sheet_Destination, 3, RowIndex, 1, true);
                        //HideRow(sheet_Destination, RowIndex, 1);                        
                        //RowIndex++;

                        ////表格注
                        //if (iEntity.REMARK != null && iEntity.REMARK.Trim() != "")
                        //{
                        //    CopyRow(sheet_Source, sheet_Destination, temp.RemarkRowIndex, RowIndex, 1, true);
                        //    sheet_Destination.GetRow(RowIndex).GetCell(0).SetCellValue("注：" + iEntity.REMARK);
                        //    RowIndex++;
                        //}

                        ////表格结论
                        //if (iEntity.CONCLUSION != null && iEntity.CONCLUSION.Trim() != "")
                        //{
                        //    CopyRow(sheet_Source, sheet_Destination, temp.ConclusionRowIndex, RowIndex, 1, true);
                        //    sheet_Destination.GetRow(RowIndex).GetCell(0).SetCellValue("结论：" + iEntity.CONCLUSION);
                        //    RowIndex++;
                        //}                      

                        ////为了表格底部没有线
                        //CopyRow(sheet_Source, sheet_Destination, 4, RowIndex, 1, true);

                    }
                    else
                    {

                        if (IsSameRuleName == false)
                        {                            //增加一行空行
                            CopyRow(sheet_Source, sheet_Destination, 5, RowIndex, 1, true);
                            RowIndex++;
                        }
                    }

                    SameRuleName = iVTEST_ITE.NAME;

                    #endregion
                    //i++;

                }
            }



            #endregion
            //结尾 是否有不确定，无不确定度需要打印结尾最后一行，否则不需要打印结尾最后一行（只有原始记录才有不确定度）
            if (IsIsHaveBuQueDingDu == false)
            {                            
                CopyRow(sheet_Source, sheet_Destination, JWTemplateIndex, RowIndex, 1, true);
            }
            //删除所有无用行数据
            DeleteAllRow(sheet_Destination);
            //设置页面页脚
            SetHeaderAndFooter(sheet_Destination, entity, type);




            sheet_Destination.ForceFormulaRecalculation = true;
        }
        /// <summary>
        /// 删除所有没用的行，解决线问题
        /// </summary>
        private void DeleteAllRow(ISheet sheet)
        {
            if (DeleteRowList != null && DeleteRowList.Count > 0)
            {
                DeleteRowList = DeleteRowList.Distinct().ToList();
                int count = 0;
                for (int i = 0; i < DeleteRowList.Count; i++)
                {
                    DeleteRow(sheet, DeleteRowList[i] - count);
                    count++;
                }
            }
        }
        /// <summary>
        /// S化整合并数据
        /// </summary>
        /// <param name="dataDic_PingHengFuZaiShiYouGongDianNengWuCha">平衡负载时有功电能误差</param>
        /// <param name="dataDic_DianNengBiaoZhunPianChaGuZhiJiSuan">电能标准偏差估计值</param>
        private Dictionary<int, DataValue> SHuaZhengHeBing(Dictionary<int, DataValue> dataDic_PingHengFuZaiShiYouGongDianNengWuCha, Dictionary<int, DataValue> dataDic_DianNengBiaoZhunPianChaGuZhiJiSuan)
        {
            //相线及测量模式、量程(Un、Ib)、功率因数cosφ与电能标准偏差估计值中的前6项目完全一致，同时Ib(%) = 100对应上，取引用中的s化整(%)
            if (dataDic_PingHengFuZaiShiYouGongDianNengWuCha != null && dataDic_PingHengFuZaiShiYouGongDianNengWuCha.Count > 0)
            {
                Dictionary<string, List<string>> SHuaZhengNamesDic = ReportStatic.SHuaZhengNames();

                List<SHuaZhengData> pList = new List<Report.SHuaZhengData>();//平衡负载时有功电能误差比较数据
                List<SHuaZhengData> dList = new List<Report.SHuaZhengData>();//电能标准偏差估计值比较数据

                #region 平衡负载时有功电能误差比较数据处理
                foreach (int pKey in dataDic_PingHengFuZaiShiYouGongDianNengWuCha.Keys)
                {

                    DataValue PingHengFuZaiShiYouGongDianNengWuCha = dataDic_PingHengFuZaiShiYouGongDianNengWuCha[pKey];
                    if (PingHengFuZaiShiYouGongDianNengWuCha != null && PingHengFuZaiShiYouGongDianNengWuCha.Data != null && PingHengFuZaiShiYouGongDianNengWuCha.Data.Count > 0)
                    {

                        if (SHuaZhengNamesDic != null && SHuaZhengNamesDic.Count > 0 && SHuaZhengNamesDic.ContainsKey("P"))
                        {

                            SHuaZhengData pItem = new SHuaZhengData();


                            foreach (string name in SHuaZhengNamesDic["P"])
                            {
                                int index = -2;
                                while (index != -1 && index < PingHengFuZaiShiYouGongDianNengWuCha.Data.Count)
                                {
                                    index = PingHengFuZaiShiYouGongDianNengWuCha.Data.FindIndex(index == -2 ? 0 : index + 1, p => p.name == name);
                                    if (index >= 0)
                                    {
                                        pItem = new SHuaZhengData();
                                        pItem.index = index;
                                        pItem.name = name;
                                        pItem.id = PingHengFuZaiShiYouGongDianNengWuCha.Data[index].id;
                                        pItem.values = PingHengFuZaiShiYouGongDianNengWuCha.Data[index].value;
                                        pItem.tongtao = pKey;
                                        pList.Add(pItem);
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region 电能标准偏差估计值比较数据

                if (dataDic_DianNengBiaoZhunPianChaGuZhiJiSuan != null && dataDic_DianNengBiaoZhunPianChaGuZhiJiSuan.Count > 0)
                {
                    foreach (int dKey in dataDic_DianNengBiaoZhunPianChaGuZhiJiSuan.Keys)
                    {

                        DataValue DianNengBiaoZhunPianChaGuZhiJiSuan = dataDic_DianNengBiaoZhunPianChaGuZhiJiSuan[dKey];
                        if (DianNengBiaoZhunPianChaGuZhiJiSuan != null && DianNengBiaoZhunPianChaGuZhiJiSuan.Data != null && DianNengBiaoZhunPianChaGuZhiJiSuan.Data.Count > 0)
                        {
                            SHuaZhengData dItem = new SHuaZhengData();
                            foreach (string name in SHuaZhengNamesDic["D"])
                            {
                                int index = -2;
                                while (index != -1 && index < DianNengBiaoZhunPianChaGuZhiJiSuan.Data.Count)
                                {
                                    index = DianNengBiaoZhunPianChaGuZhiJiSuan.Data.FindIndex(index == -2 ? 0 : index + 1, p => p.name == name);
                                    if (index >= 0)
                                    {
                                        dItem = new SHuaZhengData();
                                        dItem.index = index;
                                        dItem.name = name;
                                        dItem.id = DianNengBiaoZhunPianChaGuZhiJiSuan.Data[index].id;
                                        dItem.values = DianNengBiaoZhunPianChaGuZhiJiSuan.Data[index].value;
                                        dItem.tongtao = dKey;
                                        dList.Add(dItem);
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion


                #region 开始对比
                if (pList != null && pList.Count > 0)
                {
                    //List<SHuaZheng> pDataList = new List<SHuaZheng>();
                    List<SHuaZheng> dDataList = new List<SHuaZheng>();

                    List<SHuaZhengData> ppList = pList.Where(p => p.name == "JISUANWUCHA").ToList();

                    #region 电能标准偏差估计值
                    if (dList != null && dList.Count > 0)
                    {
                        List<SHuaZhengData> ddList = dList.Where(p => p.name == "READVALUE").ToList();

                        if (ddList != null && ddList.Count > 0)
                        {

                            SHuaZheng dData = new SHuaZheng();
                            foreach (SHuaZhengData ddItem in ddList)
                            {
                                dData = new SHuaZheng();

                                //功率因素
                                SHuaZhengData dREADVALUE = dList.LastOrDefault(p => p.name == "READVALUE" && p.index <= ddItem.index);
                                if (dREADVALUE != null)
                                {
                                    dData.READVALUE = dREADVALUE.values;
                                }
                                else
                                {
                                    dData.READVALUE = "";
                                }
                                //量程Ib值
                                SHuaZhengData dOUTPUTVAL1 = dList.LastOrDefault(p => p.name == "OUTPUTVAL1" && p.index <= ddItem.index);
                                if (dOUTPUTVAL1 != null)
                                {
                                    dData.OUTPUTVAL1 = dOUTPUTVAL1.values;
                                }
                                else
                                {
                                    dData.OUTPUTVAL1 = "";
                                }
                                //量程Ib单位
                                SHuaZhengData dOUTPUTVAL1_UNIT = dList.LastOrDefault(p => p.name == "OUTPUTVAL1_UNIT" && p.index <= ddItem.index);
                                if (dOUTPUTVAL1_UNIT != null)
                                {
                                    dData.OUTPUTVAL1_UNIT = dOUTPUTVAL1_UNIT.values;
                                }
                                else
                                {
                                    dData.OUTPUTVAL1_UNIT = "";
                                }
                                //量程Un值
                                SHuaZhengData dOUTPUTVALUE = dList.LastOrDefault(p => p.name == "OUTPUTVALUE" && p.index <= ddItem.index);
                                if (dOUTPUTVALUE != null)
                                {
                                    dData.OUTPUTVALUE = dOUTPUTVALUE.values;
                                }
                                else
                                {
                                    dData.OUTPUTVALUE = "";
                                }
                                //量程Un单位
                                SHuaZhengData dOUTPUTVALUE_UNIT = dList.LastOrDefault(p => p.name == "OUTPUTVALUE_UNIT" && p.index <= ddItem.index);
                                if (dOUTPUTVALUE_UNIT != null)
                                {
                                    dData.OUTPUTVALUE_UNIT = dOUTPUTVALUE_UNIT.values;
                                }
                                else
                                {
                                    dData.OUTPUTVALUE_UNIT = "";
                                }
                                //相线及测量模式
                                SHuaZhengData dRANGE = dList.LastOrDefault(p => p.name == "RANGE" && p.index <= ddItem.index);
                                if (dRANGE != null)
                                {
                                    dData.RANGE = dRANGE.values;
                                }
                                else
                                {
                                    dData.RANGE = "";
                                }
                                //相线及测量模式
                                SHuaZhengData dJISUANWUCHA1 = dList.FirstOrDefault(p => p.name == "JISUANWUCHA1" && p.index > ddItem.index);
                                if (dRANGE != null)
                                {
                                    dData.JISUANWUCHA1 = dJISUANWUCHA1.values;
                                }
                                else
                                {
                                    dData.JISUANWUCHA1 = "";
                                }
                                dDataList.Add(dData);

                            }
                        }
                    }
                    #endregion 


                    if (ppList != null && ppList.Count > 0)
                    {
                        MYData item = new MYData();
                        SHuaZheng pData = new SHuaZheng();

                        int count = 0;
                        foreach (SHuaZhengData ppItem in ppList)
                        {
                            pData = new SHuaZheng();
                            item = new MYData();
                            item.name = "JISUANWUCHA1";
                            item.id = "JISUANWUCHA1" + ppItem.id.Replace(ppItem.id, "");
                            item.mergedRowNum = 1;
                            item.value = "";

                            #region 平衡负载时有功电能误差
                            if (dList == null || dList.Count == 0)
                            {
                                dataDic_PingHengFuZaiShiYouGongDianNengWuCha[ppItem.tongtao].Data.Insert(ppItem.index + count, item);
                                count++;
                                continue;
                            }

                            //Ib(%)
                            //SHuaZhengData ACTUALVALUE = pList.LastOrDefault(p => p.name == "ACTUALVALUE" && p.values == "100" && p.index < ppItem.index);
                            SHuaZhengData ACTUALVALUE = pList.LastOrDefault(p => p.name == "ACTUALVALUE" && p.index < ppItem.index);
                            if (ACTUALVALUE == null || ACTUALVALUE.values != "100")
                            {
                                dataDic_PingHengFuZaiShiYouGongDianNengWuCha[ppItem.tongtao].Data.Insert(ppItem.index + count, item);
                                count++;
                                continue;
                            }
                            pData.ACTUALVALUE = ACTUALVALUE.values;
                            //功率因素
                            SHuaZhengData READVALUE = pList.LastOrDefault(p => p.name == "READVALUE" && p.index < ppItem.index);
                            if (READVALUE == null || (READVALUE.values.Trim() != "1.0" && READVALUE.values.Trim() != "0.5L"))
                            {
                                dataDic_PingHengFuZaiShiYouGongDianNengWuCha[ppItem.tongtao].Data.Insert(ppItem.index + count, item);
                                count++;
                                continue;
                            }
                            pData.READVALUE = READVALUE.values;
                            //量程Ib值
                            SHuaZhengData OUTPUTVAL1 = pList.LastOrDefault(p => p.name == "OUTPUTVAL1" && p.index < ppItem.index);
                            if (OUTPUTVAL1 != null)
                            {
                                pData.OUTPUTVAL1 = OUTPUTVAL1.values;
                            }
                            else
                            {
                                pData.OUTPUTVAL1 = "";
                            }
                            //量程Ib单位
                            SHuaZhengData OUTPUTVAL1_UNIT = pList.LastOrDefault(p => p.name == "OUTPUTVAL1_UNIT" && p.index < ppItem.index);
                            if (OUTPUTVAL1_UNIT != null)
                            {
                                pData.OUTPUTVAL1_UNIT = OUTPUTVAL1_UNIT.values;
                            }
                            else
                            {
                                pData.OUTPUTVAL1_UNIT = "";
                            }
                            //量程Un值
                            SHuaZhengData OUTPUTVALUE = pList.LastOrDefault(p => p.name == "OUTPUTVALUE" && p.index < ppItem.index);
                            if (OUTPUTVALUE != null)
                            {
                                pData.OUTPUTVALUE = OUTPUTVALUE.values;
                            }
                            else
                            {
                                pData.OUTPUTVALUE = "";
                            }
                            //量程Un单位
                            SHuaZhengData OUTPUTVALUE_UNIT = pList.LastOrDefault(p => p.name == "OUTPUTVALUE_UNIT" && p.index < ppItem.index);
                            if (OUTPUTVALUE_UNIT != null)
                            {
                                pData.OUTPUTVALUE_UNIT = OUTPUTVALUE_UNIT.values;
                            }
                            else
                            {
                                pData.OUTPUTVALUE_UNIT = "";
                            }
                            //相线及测量模式
                            SHuaZhengData RANGE = pList.LastOrDefault(p => p.name == "RANGE" && p.index < ppItem.index);
                            if (RANGE != null)
                            {
                                pData.RANGE = RANGE.values;
                            }
                            else
                            {
                                pData.RANGE = "";
                            }
                            //相线及测量模式、量程(Un、Ib)、功率因数cosφ与电能标准偏差估计值中的前6项目完全一致，同时Ib(%) = 100对应上，取引用中的s化整(%)
                            if (dDataList != null && dDataList.Count > 0)
                            {
                                SHuaZheng dp = dDataList.FirstOrDefault(p => p.OUTPUTVAL1 == pData.OUTPUTVAL1 && p.OUTPUTVAL1_UNIT == pData.OUTPUTVAL1_UNIT &&
                             p.OUTPUTVALUE == pData.OUTPUTVALUE && p.OUTPUTVALUE_UNIT == pData.OUTPUTVALUE_UNIT && p.RANGE == pData.RANGE && p.READVALUE == pData.READVALUE);
                                if (dp != null)
                                {
                                    item.value = dp.JISUANWUCHA1;
                                }
                            }
                            dataDic_PingHengFuZaiShiYouGongDianNengWuCha[ppItem.tongtao].Data.Insert(ppItem.index + count, item);
                            count++;
                            continue;
                            //pDataList.Add(pData);
                            #endregion


                        }
                    }
                }
                #endregion
            }



            return dataDic_PingHengFuZaiShiYouGongDianNengWuCha;

        }
        /// <summary>
        /// 根据等级判断是否是表格
        /// </summary>
        /// <param name="iEntity">检测项信息</param>
        /// <param name="msg">返回合格不合格信息</param>
        /// <returns></returns>
        private bool IsBiaoGeByDengJi(QUALIFIED_UNQUALIFIED_TEST_ITE iEntity, ref string msg)
        {
            bool result = true;
            msg = string.Empty;

            List<Rule_DengJi> rList = ReportStatic.Rule_DengJiList();
            if (iEntity != null && rList != null && rList.Count > 0 && rList.FirstOrDefault(p => p.RuleID == iEntity.RULEID) != null)
            {
                Rule_DengJi rItem = rList.FirstOrDefault(p => p.RuleID == iEntity.RULEID);

                #region 获取到合格不合格级等级数据
                bool statestandard = false;//是否找到合格不合格
                bool zhunquedingdudengji = false;//是否找到等级
                string statestandardValue = string.Empty;//合格不合格值
                string zhunquedingdudengjiValue = string.Empty;//等级值
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(iEntity.HTMLVALUE);
                Dictionary<int, List<MYDataHead>> headDic = AnalyticHTML.GetHeadData(doc);//表头
                if (headDic != null && headDic.Count > 0)
                {
                    MYDataHead data = new MYDataHead();
                    foreach (List<MYDataHead> items in headDic.Values)
                    {
                        if (items != null && items.Count > 0)
                        {
                            if (statestandard == false)
                            {
                                data = items.FirstOrDefault(p => p.name == "statestandard");
                                if (data != null)
                                {
                                    statestandardValue = data.value;
                                    statestandard = true;
                                }
                            }

                            if (zhunquedingdudengji == false)
                            {
                                data = items.FirstOrDefault(p => p.name == "zhidingwucha");
                                if (data != null)
                                {
                                    zhunquedingdudengjiValue = data.value;
                                    zhunquedingdudengji = true;
                                }
                            }
                            if (statestandard && zhunquedingdudengji)
                            {
                                break;
                            }
                        }
                    }
                }
                #endregion

                double zhunquedingdudengjiValueNum = 0;
                if (double.TryParse(zhunquedingdudengjiValue, out zhunquedingdudengjiValueNum))
                {
                    if (zhunquedingdudengjiValueNum >= rItem.DengJi)
                    {
                        //
                        if (rItem.IsXuYaoHeGe == false)
                        {
                            result = false;
                        }
                        else
                        {
                            if (statestandardValue != null && statestandardValue.Trim() == "合格")
                            {
                                result = false;
                            }
                        }
                        if (result == false)
                        {
                            msg = statestandardValue.Trim();
                        }

                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 画表格顶部线
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <param name="sheet_Destination"></param>
        /// <param name="RowIndex">需要划线的行号</param>
        private void SetBorderTop(IWorkbook hssfworkbook, ISheet sheet_Destination, int RowIndex)
        {
            //为了相同项表格底部没有线                           
            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.BorderTop = BorderStyle.Thin;

            IRow targetRow = sheet_Destination.GetRow(RowIndex);
            ICell targetCell = null;
            //每行单元格处理               
            for (int m = targetRow.FirstCellNum; m < targetRow.LastCellNum; m++)
            {
                if (m < 57)
                {
                    targetCell = targetRow.GetCell(m);
                    targetCell.CellStyle = style;//样式                                  
                }
            }
        }
        ///// <summary>
        ///// 移除单元格底部线（用于解决校准原始记录有效期底部线去掉）
        ///// </summary>
        ///// <param name="hssfworkbook"></param>
        ///// <param name="sheet_Destination"></param>
        ///// <param name="targetCell">需要移除线的单元格</param>
        //private void RemoveBorder(IWorkbook hssfworkbook, ISheet sheet_Destination, ICell targetCell)
        //{
        //    //为了相同项表格底部没有线                           
        //    ICellStyle style = hssfworkbook.CreateCellStyle();
        //    style.BorderTop = BorderStyle.None;

        //    //IRow targetRow = sheet_Destination.GetRow(RowIndex);
        //    //ICell targetCell = null;
        //    //每行单元格处理               
        //    for (int m = targetRow.FirstCellNum; m < targetRow.LastCellNum; m++)
        //    {
        //        if (m < 57)
        //        {
        //            targetCell = targetRow.GetCell(m);
        //            targetCell.CellStyle = style;//样式                                  
        //        }
        //    }
        //}
        /// <summary>
        /// 设置页眉页脚
        /// </summary>
        /// <param name="sheet_Destination">目标sheet</param>
        /// <param name="entity">预备方案</param>
        private void SetHeaderAndFooter(ISheet sheet_Destination, PREPARE_SCHEME entity, ExportType type = ExportType.OriginalRecord_JianDing)
        {
            string REPORTNUMBER = entity.REPORTNUMBER;
            //页眉
            string header = "&9原始记录编号：";
            if (type != ExportType.OriginalRecord_JianDing && type != ExportType.OriginalRecord_XiaoZhun)
            {
                header = "&9证书编号：";
            }
            else if (REPORTNUMBER != null && REPORTNUMBER.Trim() != "")
            {
                int index = entity.REPORTNUMBER.IndexOf("-");
                REPORTNUMBER = REPORTNUMBER.Split('-')[0] + "原始" + REPORTNUMBER.Substring(index);
            }
            if (REPORTNUMBER != null && REPORTNUMBER.Trim() != "")
            {
                sheet_Destination.Header.Left = header + REPORTNUMBER;
            }
            else
            {
                sheet_Destination.Header.Left = header;

            }
            //页脚控制编号(只有类型为校准的CNAS原始记录才要这个编号，其他的都不要)
            if (type == ExportType.OriginalRecord_XiaoZhun && entity.CERTIFICATE_CATEGORY == ZhengShuLeiBieEnums.校准.ToString() && entity.CNAS == ShiFouCNAS.Yes.ToString() && entity.CONTROL_NUMBER != null && entity.CONTROL_NUMBER.Trim() != "")
            {
                //if (REPORTNUMBER != null && REPORTNUMBER.Trim() != "")
                //{
                sheet_Destination.Footer.Left = entity.CONTROL_NUMBER;
                //}
            }//刘清霞解决页眉问题
            //sheet_Destination.SetMargin(MarginType.RightMargin, (double)0.5);
            //sheet_Destination.SetMargin(MarginType.TopMargin, (double)0.4);
            //sheet_Destination.SetMargin(MarginType.LeftMargin, (double)0.4);
            sheet_Destination.SetMargin(MarginType.BottomMargin, (double)0.35);
            //sheet_Destination.SetMargin(MarginType.HeaderMargin, (double)0.4);
            sheet_Destination.SetMargin(MarginType.FooterMargin, (double)0.2);
            sheet_Destination.RepeatingRows = new CellRangeAddress(0, 0, 0, 57);

        }
        #region 复制行


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
        private Dictionary<string, CellRangeAddress> CopyRow_1(ISheet sheet_Source, ISheet sheet_Destination, int rowIndex_Source, int rowIndex_Destination, int insertCount, bool IsCopyContent, List<RowInfo> rowInfoList, SpecialCharacters allSpecialCharacters, List<MYDataHead> DongTaiShuJuList, bool IsNullShow = false)
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
                                if (IsCopyContent && rowIndex_Source == cellAddress.FirstRow)
                                {
                                    HSSFRichTextString value = GetDongTaiShuJu(DongTaiShuJuList, rowInfoList, row_Source.Cells[m], targetRow.Cells[m], allSpecialCharacters, IsNullShow);
                                    targetRow.Cells[m].SetCellValue(value);

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
                            if (IsCopyContent)
                            {
                                HSSFRichTextString value = GetDongTaiShuJu(DongTaiShuJuList, rowInfoList, row_Source.Cells[m], targetRow.Cells[m], allSpecialCharacters, IsNullShow);
                                targetRow.Cells[m].SetCellValue(value);
                            }
                        }
                        #endregion
                    }
                }
            }
            return result;
        }




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
        /// <param name="rowInfoList">需要替换的动态数据位置</param>
        /// <param name="allSpecialCharacters">特殊字符配置信息</param>
        private void CopyRow(ISheet sheet_Source, ISheet sheet_Destination, int rowIndex_Source, int rowIndex_Destination, int insertCount, bool IsCopyContent = false, Dictionary<string, string> DongTaiShuJuList = null, List<RowInfo> rowInfoList = null, SpecialCharacters allSpecialCharacters = null, List<Cell> CellsTemplate = null)
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
            //给目标行正式处理格式及插入多少行数据       
            for (int i = rowIndex_Destination; i < rowIndex_Destination + insertCount; i++)
            {
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
                        #region 原合并方式
                        //if (sourceCell.IsMergedCell)
                        //{
                        //    //起始位置
                        //    if (startMergeCell < 0 || sourceCell.CellStyle.BorderLeft != BorderStyle.None || sourceCell.StringCellValue != "")
                        //    {
                        //        startMergeCell = m;
                        //    }
                        //    //结束位置
                        //    if (m + 1 == sourceCellCount || sourceCell.CellStyle.BorderRight != BorderStyle.None
                        //        || row_Source.Cells[m + 1].StringCellValue != "" || row_Source.Cells[m + 1].IsMergedCell == false
                        //        || (CellsTemplate != null && CellsTemplate.Count > 0 && CellsTemplate.FirstOrDefault(p => p.ColIndex == startMergeCell && p.ColCount == (m - startMergeCell)) != null))
                        //    {
                        //        endMergeCell = m;
                        //    }

                        //    if (startMergeCell < endMergeCell)
                        //    {
                        //        //int firstRow, int lastRow, int firstCol, int lastCol
                        //        sheet_Destination.AddMergedRegion(new CellRangeAddress(i, i, startMergeCell, endMergeCell));
                        //        //CellRangeAddress cellAddress = getMergedRegionCell(m, i);
                        //        //if (cellAddress != null)
                        //        //{
                        //        //    sheet_Destination.AddMergedRegion(new CellRangeAddress(i, cellAddress.LastRow-cellAddress.FirstRow+i, cellAddress.FirstColumn, cellAddress.LastColumn));
                        //        //}
                        //        //else
                        //        //{
                        //        //    sheet_Destination.AddMergedRegion(new CellRangeAddress(i, i, startMergeCell, endMergeCell));
                        //        //}


                        //        if (IsCopyContent)
                        //        {
                        //            HSSFRichTextString value = GetDongTaiShuJu(DongTaiShuJuList, rowInfoList, row_Source.Cells[startMergeCell], targetRow.Cells[startMergeCell], allSpecialCharacters);
                        //            targetRow.Cells[startMergeCell].SetCellValue(value);
                        //            startMergeCell = -1;

                        //        }
                        //    }
                        //}
                        //else
                        //{                       
                        //    if (IsCopyContent)
                        //    {

                        //        HSSFRichTextString value = GetDongTaiShuJu(DongTaiShuJuList, rowInfoList, row_Source.Cells[m], targetRow.Cells[m], allSpecialCharacters);
                        //        targetRow.Cells[m].SetCellValue(value);

                        //    }
                        //    startMergeCell = -1;                       
                        //}
                        #endregion
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
                                }
                                if (IsCopyContent && rowIndex_Source == cellAddress.FirstRow)
                                {
                                    HSSFRichTextString value = GetDongTaiShuJu(DongTaiShuJuList, rowInfoList, row_Source.Cells[m], targetRow.Cells[m], allSpecialCharacters);
                                    targetRow.Cells[m].SetCellValue(value);
                                }
                            }

                        }
                        else
                        {
                            if (IsCopyContent)
                            {
                                HSSFRichTextString value = GetDongTaiShuJu(DongTaiShuJuList, rowInfoList, row_Source.Cells[m], targetRow.Cells[m], allSpecialCharacters);
                                targetRow.Cells[m].SetCellValue(value);
                            }
                        }
                        #endregion
                    }
                }
            }
        }

        /// <summary>
        /// 获取单元格数据及动态数据组合
        /// </summary>
        /// <param name="DongTaiShuJuList">动态数据值</param>
        /// <param name="rowInfoList">动态数据位置</param>
        /// <param name="sourceCell">单元格</param>
        /// <param name="targetCell">目标单元格</param>
        /// <param name="allSpecialCharacters">特殊字符配置信息</param>
        /// <param name="IsNullShow">动态空数据是否显示/</param>
        /// <returns></returns>
        private HSSFRichTextString GetDongTaiShuJu(List<MYDataHead> DongTaiShuJuList = null, List<RowInfo> rowInfoList = null, ICell sourceCell = null, ICell targetCell = null, SpecialCharacters allSpecialCharacters = null, bool IsNullShow = false)
        {
            HSSFWorkbook workbook = null;
            if (targetCell != null && targetCell.Sheet != null && targetCell.Sheet.Workbook != null)
            {
                workbook = (HSSFWorkbook)targetCell.Sheet.Workbook;
            }
            HSSFRichTextString result = null;
            if (sourceCell == null)
            {
                return new HSSFRichTextString("");
            }

            int speStartIndex = sourceCell.StringCellValue.IndexOf("{0}");//动态字符位置
            string value = "";
            string SpecialStr = "";

            int notItalicStartIndex = -1;//非斜体开始位置
            int notItalicEndIndex = -1;//非斜体结束位置
            //有动态数据
            if (speStartIndex >= 0 && DongTaiShuJuList != null && DongTaiShuJuList.Count > 0 && rowInfoList != null && rowInfoList.Count > 0 &&
                rowInfoList.FirstOrDefault().Cells != null)
            {
                while (DongTaiShuJuList != null && DongTaiShuJuList.Count > 0 && rowInfoList.FirstOrDefault().Cells.FirstOrDefault(p => p.Code == DongTaiShuJuList.FirstOrDefault().name) == null)
                {
                    DongTaiShuJuList.RemoveAt(0);
                }
                if (DongTaiShuJuList != null && DongTaiShuJuList.Count > 0)
                {

                    value = string.Format(sourceCell.StringCellValue, DongTaiShuJuList.FirstOrDefault().value).Trim();

                    if (IsNullShow && (string.IsNullOrEmpty(value) || value.Trim() == ""))
                    {
                        value = "/";
                        SpecialStr = "/";
                    }
                    else
                    {
                        SpecialStr = DongTaiShuJuList.FirstOrDefault().value;
                    }
                    DongTaiShuJuList.RemoveAt(0);
                }
                else
                {
                    value = string.Format(sourceCell.StringCellValue, "").Trim();
                    speStartIndex = 0;
                    SpecialStr = value;
                }
            }
            //无动态数据
            else
            {
                value = string.Format(sourceCell.StringCellValue, "").Trim();
                speStartIndex = 0;
                SpecialStr = value;
            }
            if (value != null && value.Trim() != "" && value.Trim().ToUpper().IndexOf("U(K") >= 0)
            {
                speStartIndex = value.Trim().ToUpper().IndexOf("U(K");
                SpecialStr = "U(K";

                notItalicStartIndex = speStartIndex + 1;//非斜体开始位置
                notItalicEndIndex = speStartIndex + 2;//非斜体结束位置
            }
            if (value != null && value.Trim() != "" && value.Trim().ToUpper().IndexOf("U(%)(k") >= 0)
            {
                speStartIndex = value.Trim().ToUpper().IndexOf("U(%)(k");
                SpecialStr = "U(%)(k";

                notItalicStartIndex = speStartIndex + 1;//非斜体开始位置
                notItalicEndIndex = speStartIndex + 2;//非斜体结束位置
            }

            else if (value != null && value.Trim() != "" && value.Trim().ToUpper().IndexOf("UI") >= 0)
            {
                speStartIndex = value.Trim().ToUpper().IndexOf("UI");
                SpecialStr = "UI";
            }
            else if (value.ToUpper().IndexOf("UREL(K=") >= 0)
            {
                speStartIndex = value.Trim().ToUpper().IndexOf("UREL(K=");
                SpecialStr = "UREL(K=";

                notItalicStartIndex = speStartIndex + 4;//非斜体开始位置
                notItalicEndIndex = speStartIndex + 5;//非斜体结束位置    

            }
            else if (value.ToUpper().IndexOf("δx1".ToUpper()) >= 0)
            {
                speStartIndex = value.Trim().ToUpper().IndexOf("δx1".ToUpper());
                SpecialStr = "δx1";
            }
            else if (value.ToUpper().IndexOf("δx2".ToUpper()) >= 0)
            {
                speStartIndex = value.Trim().ToUpper().IndexOf("δx2".ToUpper());
                SpecialStr = "δx2";
            }
            else if (value.ToUpper().IndexOf("δx".ToUpper()) >= 0)
            {
                speStartIndex = value.Trim().ToUpper().IndexOf("δx".ToUpper());
                SpecialStr = "δx";
            }
            else if (value.ToUpper().IndexOf("δn".ToUpper()) >= 0)
            {
                speStartIndex = value.Trim().ToUpper().IndexOf("δn".ToUpper());
                SpecialStr = "δn";
            }
            //#region 设置上标
            //#region 处理*10
            //if (value.IndexOf("*10") > 0 || value.IndexOf("×10") > 0)
            //{
            //    //value = value.Replace(",", Environment.NewLine);
            //    //result = new HSSFRichTextString(value.Trim().Replace("|", ""));

            //    string[] vArray = value.Trim().Split('|');
            //    int length = 0;
            //    int startIndex = 0;
            //    int endIndex = 0;
            //    foreach (string v in vArray)
            //    {

            //        if (v.IndexOf("*10") >= 0 || value.IndexOf("×10") > 0)
            //        {
            //            if (v.IndexOf("*10") >= 0)
            //            {
            //                startIndex = length + v.IndexOf("*10") + 3;
            //            }
            //            else
            //            {
            //                startIndex = length + v.IndexOf("×10") + 3;
            //            }
            //            endIndex = length + v.Length;
            //            HSSFFont superscript = (HSSFFont)workbook.CreateFont();
            //            superscript.TypeOffset = FontSuperScript.Super;//上标
            //            superscript.FontName = "宋体";
            //            result.ApplyFont(startIndex, endIndex, superscript);
            //        }
            //        length = length + v.Length;

            //    }
            //}
            //#endregion
            //#endregion

            //处理特殊字符下标上标斜体
            result = new HSSFRichTextString(value);

            #region 设置上标
            #region 处理*10
            if (value.IndexOf("*10") > 0 || value.IndexOf("×10") > 0)
            {
                //value = value.Replace(",", Environment.NewLine);
                //result = new HSSFRichTextString(value.Trim().Replace("|", ""));

                string[] vArray = value.Trim().Split('|');
                int length = 0;
                int startIndex = 0;
                int endIndex = 0;
                foreach (string v in vArray)
                {

                    if (v.IndexOf("*10") >= 0 || value.IndexOf("×10") > 0)
                    {
                        if (v.IndexOf("*10") >= 0)
                        {
                            startIndex = length + v.IndexOf("*10") + 3;
                        }
                        else
                        {
                            startIndex = length + v.IndexOf("×10") + 3;
                        }
                        if (v.LastIndexOf(")") == v.Length - 1)
                        {
                            endIndex = length + v.Length - 1;
                        }
                        else
                        {
                            endIndex = length + v.Length;
                        }

                        HSSFFont superscript = (HSSFFont)workbook.CreateFont();
                        superscript.TypeOffset = FontSuperScript.Super;//上标
                        superscript.FontName = "宋体";
                        result.ApplyFont(startIndex, endIndex, superscript);
                    }
                    length = length + v.Length;

                }
            }
            #endregion
            #endregion

            if (!string.IsNullOrEmpty(SpecialStr) && SpecialStr.Trim() != "" && speStartIndex >= 0)

            {
                //特殊字符是否配置
                if (workbook != null && allSpecialCharacters != null && allSpecialCharacters.SpecialCharacterList != null &&
                        allSpecialCharacters.SpecialCharacterList.Count > 0 &&
                        allSpecialCharacters.SpecialCharacterList.FirstOrDefault(p => p.Code.Trim().ToUpper() == SpecialStr.Trim().ToUpper()) != null)
                {
                    SpecialCharacter spec = allSpecialCharacters.SpecialCharacterList.FirstOrDefault(p => p.Code.Trim().ToUpper() == SpecialStr.Trim().ToUpper());
                    #region 将字符设置成斜体

                    HSSFFont normalFont = (HSSFFont)workbook.CreateFont();
                    normalFont.IsItalic = true;
                    if (spec.Code.Trim() == "cosφ")
                    {
                        normalFont.FontName = "Times New Roman";
                    }
                    else
                    {
                        normalFont.FontName = "宋体";
                    }
                    int startIndex = speStartIndex;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    int endIndex = speStartIndex + spec.Code.Trim().Length - spec.SubscriptLastCount;
                    if (endIndex < 0)
                    {
                        endIndex = 0;
                    }
                    if (SpecialStr == "UREL(K=")//特殊处理
                    {
                        endIndex = speStartIndex + spec.Code.Trim().Length;
                    }

                    result.ApplyFont(startIndex, endIndex, normalFont);
                    #endregion

                    #region 设置非斜体
                    if (notItalicStartIndex >= 0 && notItalicEndIndex >= 0)
                    {
                        HSSFFont notItalicFont = (HSSFFont)workbook.CreateFont();
                        notItalicFont.IsItalic = false;
                        notItalicFont.FontName = "宋体";

                        result.ApplyFont(notItalicStartIndex, notItalicEndIndex, notItalicFont);

                    }

                    #endregion 

                    #region 设置下标
                    if (spec.SubscriptLastCount > 0)
                    {
                        //result = new HSSFRichTextString(value);
                        // superscript = (HSSFFont)workbook.CreateFont();
                        //superscript.TypeOffset = FontSuperScript.Super;//上标
                        //superscript.Color = HSSFColor.RED.index;

                        HSSFFont subscript = (HSSFFont)workbook.CreateFont();
                        subscript.TypeOffset = FontSuperScript.Sub; //下标  
                        //subscript.IsItalic = true;
                        subscript.FontName = "宋体";
                        //subscript.Color = HSSFColor.Red.Index;
                        //HSSFFont normalFont = (HSSFFont)workbook.CreateFont();
                        if (SpecialStr == "UREL(K=")//特殊处理
                        {
                            startIndex = speStartIndex + 1;
                            endIndex = speStartIndex + 4;
                        }
                        else
                        {
                            startIndex = speStartIndex + spec.Code.Trim().Length - spec.SubscriptLastCount;
                            if (startIndex < 0)
                            {
                                startIndex = 0;
                            }
                            endIndex = speStartIndex + spec.Code.Trim().Length;
                            if (endIndex < 0)
                            {
                                endIndex = 0;
                            }
                        }
                        result.ApplyFont(startIndex, endIndex, subscript);
                    }
                    #endregion

                }
                //return result;
            }
            else
            {
                result = new HSSFRichTextString(string.Format(sourceCell.StringCellValue, ""));
            }
            return result;
        }


        /// <summary>
        /// 获取单元格数据及动态数据组合
        /// </summary>
        /// <param name="DongTaiShuJuList">动态数据值</param>
        /// <param name="rowInfoList">动态数据位置</param>
        /// <param name="sourceCell">单元格</param>
        /// <param name="targetCell">目标单元格</param>
        /// <param name="allSpecialCharacters">特殊字符配置信息</param>
        /// <returns></returns>
        private HSSFRichTextString GetDongTaiShuJu(Dictionary<string, string> DongTaiShuJuList = null, List<RowInfo> rowInfoList = null, ICell sourceCell = null, ICell targetCell = null, SpecialCharacters allSpecialCharacters = null)
        {

            HSSFWorkbook workbook = null;
            if (targetCell != null && targetCell.Sheet != null && targetCell.Sheet.Workbook != null)
            {
                workbook = (HSSFWorkbook)targetCell.Sheet.Workbook;
            }
            HSSFRichTextString result = null;
            if (sourceCell == null)
            {
                return new HSSFRichTextString("");
            }
            string key = "";
            //xml是否配置了信息
            //< Cell >

            //                < !--字段代码与模板中设置的字段保持一致-- >

            //                < Code > sssss </ Code >

            //                < !--字段名称含义-- >

            //                < Name > 显示值 </ Name >

            //                < !--模板中单元格开始列号-- >

            //                < ColIndex > 21 </ ColIndex >

            //                < !--所占列数-- >

            //                < ColCount > 13 </ ColCount >

            //            </ Cell >
            if (rowInfoList != null && rowInfoList.Count > 0 && rowInfoList.FirstOrDefault(p => p.RowIndex == sourceCell.RowIndex && p.Cells != null && p.Cells.Count > 0) != null)
            {
                RowInfo r = rowInfoList.FirstOrDefault(p => p.RowIndex == sourceCell.RowIndex && p.Cells != null && p.Cells.Count > 0);
                if (r != null)
                {
                    Cell c = r.Cells.FirstOrDefault(p => p.ColIndex == sourceCell.ColumnIndex);
                    if (c != null && DongTaiShuJuList.ContainsKey(c.Code))
                    {
                        key = c.Code;
                    }
                }
            }
            int speStartIndex = sourceCell.StringCellValue.IndexOf("{0}");//动态字符位置
            string value = "";
            string SpecialStr = "";
            //有动态数据
            if (key != null && key.Trim() != "")
            {
                value = string.Format(sourceCell.StringCellValue, DongTaiShuJuList[key]).Trim();
                SpecialStr = DongTaiShuJuList[key];
            }
            //无动态数据
            else
            {
                value = string.Format(sourceCell.StringCellValue, "").Trim();
                speStartIndex = 0;
                SpecialStr = value;
            }
            if (value != null && value.Trim() != "" && value.Trim().ToUpper().IndexOf("U(K") >= 0)
            {
                speStartIndex = value.Trim().ToUpper().IndexOf("U(K");
                SpecialStr = "U(K";
            }
            //处理特殊字符下标上标斜体
            result = new HSSFRichTextString(value);

            if (!string.IsNullOrEmpty(SpecialStr) && SpecialStr.Trim() != "" && speStartIndex >= 0)
            {
                //特殊字符是否配置
                if (workbook != null && allSpecialCharacters != null && allSpecialCharacters.SpecialCharacterList != null &&
                        allSpecialCharacters.SpecialCharacterList.Count > 0 &&
                        allSpecialCharacters.SpecialCharacterList.FirstOrDefault(p => p.Code.Trim().ToUpper() == SpecialStr.Trim().ToUpper()) != null)
                {
                    SpecialCharacter spec = allSpecialCharacters.SpecialCharacterList.FirstOrDefault(p => p.Code.Trim().ToUpper() == SpecialStr.Trim().ToUpper());
                    #region 将字符设置成斜体

                    HSSFFont normalFont = (HSSFFont)workbook.CreateFont();
                    normalFont.IsItalic = true;
                    normalFont.FontName = "宋体";
                    int startIndex = speStartIndex;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    int endIndex = speStartIndex + spec.Code.Trim().Length - spec.SubscriptLastCount;
                    if (endIndex < 0)
                    {
                        endIndex = 0;
                    }
                    result.ApplyFont(startIndex, endIndex, normalFont);
                    #endregion

                    #region 设置下标
                    if (spec.SubscriptLastCount > 0)
                    {
                        //result = new HSSFRichTextString(value);
                        // superscript = (HSSFFont)workbook.CreateFont();
                        //superscript.TypeOffset = FontSuperScript.Super;//上标
                        //superscript.Color = HSSFColor.RED.index;

                        HSSFFont subscript = (HSSFFont)workbook.CreateFont();
                        subscript.TypeOffset = FontSuperScript.Sub; //下标  
                        //subscript.IsItalic = true;
                        subscript.FontName = "宋体";
                        //subscript.Color = HSSFColor.Red.Index;
                        //HSSFFont normalFont = (HSSFFont)workbook.CreateFont();
                        startIndex = speStartIndex + spec.Code.Trim().Length - spec.SubscriptLastCount;
                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        endIndex = speStartIndex + spec.Code.Trim().Length;
                        if (endIndex < 0)
                        {
                            endIndex = 0;
                        }
                        result.ApplyFont(startIndex, endIndex, subscript);
                    }
                    #endregion

                }
                if (!string.IsNullOrEmpty(key) && key.Trim() != "" && DongTaiShuJuList != null)
                {
                    DongTaiShuJuList.Remove(key);
                }
                return result;
            }

            return new HSSFRichTextString(string.Format(sourceCell.StringCellValue, ""));
        }
        /// <summary>
        /// 设置下标\斜体\宋体
        /// </summary>
        /// <param name="workbook">工作文件</param>
        /// <param name="allSpecialCharacters">特殊字符配置信息</param>
        /// <param name="value">特殊字符</param>
        /// <param name="remarkIndexList">备注特殊字符索引信息,非备注不用传</param>
        /// <returns></returns>
        private HSSFRichTextString SetSub(HSSFWorkbook workbook = null, SpecialCharacters allSpecialCharacters = null, string value = "", List<SpecialCharacter_Index> remarkIndexList = null)
        {
            if (value == null)
            {
                value = "";
            }
            HSSFRichTextString result = new HSSFRichTextString(value.Trim());
            if (workbook != null && value != null && value.Trim() != "")
            {
                #region 处理第一位为斜体字符
                List<string> firstList = ReportStatic.FirstSpecialCharacter();
                if (firstList != null && firstList.FirstOrDefault(p => p.ToUpper() == value.Trim().ToUpper()) != null)
                {
                    #region 设置单元格字大小

                    HSSFFont normalFont1 = (HSSFFont)workbook.CreateFont();
                    //normalFont1.IsItalic = true;
                    normalFont1.FontName = "宋体";
                    normalFont1.FontHeightInPoints = 10;// 设置字体大小           
                    result.ApplyFont(0, value.Trim().Length, normalFont1);
                    #endregion 
                    #region 将字符设置成斜体

                    HSSFFont normalFont = (HSSFFont)workbook.CreateFont();
                    normalFont.IsItalic = true;
                    normalFont.FontName = "宋体";
                    //normalFont.FontHeightInPoints = 10;// 设置字体大小                 
                    int startIndex = 0;
                    int endIndex = 1;
                    result.ApplyFont(startIndex, endIndex, normalFont);
                    #endregion
                }
                #endregion

                #region 处理备注特殊信息
                if (remarkIndexList != null && remarkIndexList.Count > 0)
                {
                    foreach (SpecialCharacter_Index remark in remarkIndexList)
                    {
                        #region 将字符设置成斜体

                        HSSFFont normalFont = (HSSFFont)workbook.CreateFont();
                        normalFont.IsItalic = true;
                        normalFont.FontName = "宋体";
                        int startIndex = remark.StartIndex;
                        int endIndex = remark.StartIndex + remark.Code.Trim().Length;
                        result.ApplyFont(startIndex, endIndex, normalFont);
                        #endregion

                        #region 设置下标
                        if (remark.SubCount > 0)
                        {
                            //result = new HSSFRichTextString(value);
                            // superscript = (HSSFFont)workbook.CreateFont();
                            //superscript.TypeOffset = FontSuperScript.Super;//上标
                            //superscript.Color = HSSFColor.RED.index;

                            HSSFFont subscript = (HSSFFont)workbook.CreateFont();
                            subscript.TypeOffset = FontSuperScript.Sub; //下标  
                            //subscript.IsItalic = true;
                            subscript.FontName = "宋体";
                            //subscript.Color = HSSFColor.Red.Index;
                            //HSSFFont normalFont = (HSSFFont)workbook.CreateFont();
                            startIndex = startIndex + remark.Code.Trim().Length - remark.SubCount;
                            if (startIndex < 0)
                            {
                                startIndex = 0;
                            }
                            //endIndex = remark.Code.Trim().Length;
                            //if (endIndex < 0)
                            //{
                            //    endIndex = 0;
                            //}
                            result.ApplyFont(startIndex, endIndex, subscript);
                        }
                        #endregion
                    }
                }
                #endregion 
                if (value.IndexOf("|,") >= 0)
                {
                    value = value.Replace(",", Environment.NewLine);
                    result = new HSSFRichTextString(value.Trim().Replace("|", ""));

                }

                #region 处理标准装置中的特殊字符（斜体）

                List<string> XieLTiList = GetXieTiList();
                if (XieLTiList != null && XieLTiList.Count > 0)
                {
                    foreach (string xt in XieLTiList)
                    {
                        if (value.ToUpper().IndexOf(xt.ToUpper()) >= 0)
                        {

                            string[] vArray = value.Trim().Split('|');
                            int length = 0;
                            int startIndex = 0;
                            int endIndex = 0;
                            foreach (string v in vArray)
                            {

                                if (v.ToUpper().IndexOf(xt) >= 0)
                                {
                                    startIndex = length + v.ToUpper().IndexOf(xt);
                                    endIndex = startIndex + xt.Length;
                                    HSSFFont superscriptX = (HSSFFont)workbook.CreateFont();
                                    superscriptX.IsItalic = true;
                                    superscriptX.FontName = "宋体";
                                    result.ApplyFont(startIndex, endIndex, superscriptX);
                                    if (xt.ToUpper() == "UREL")
                                    {

                                        HSSFFont subscriptX = (HSSFFont)workbook.CreateFont();
                                        subscriptX.TypeOffset = FontSuperScript.Sub; //下标                                     
                                        subscriptX.FontName = "宋体";
                                        result.ApplyFont(startIndex + 1, endIndex, subscriptX);
                                    }
                                }
                                length = length + v.Length;

                            }
                        }

                    }
                }
                #endregion

                #region 设置上标
                #region 处理*10
                if (value.IndexOf("*10") > 0 || value.IndexOf("×10") > 0)
                {
                    //value = value.Replace(",", Environment.NewLine);
                    //result = new HSSFRichTextString(value.Trim().Replace("|", ""));

                    string[] vArray = value.Trim().Split('|');
                    int length = 0;
                    int startIndex = 0;
                    int endIndex = 0;
                    foreach (string v in vArray)
                    {

                        if (v.IndexOf("*10") >= 0 || value.IndexOf("×10") > 0)
                        {
                            if (v.IndexOf("*10") >= 0)
                            {
                                startIndex = length + v.IndexOf("*10") + 3;
                            }
                            else
                            {
                                startIndex = length + v.IndexOf("×10") + 3;
                            }
                            endIndex = length + v.Length;
                            HSSFFont superscript = (HSSFFont)workbook.CreateFont();
                            superscript.TypeOffset = FontSuperScript.Super;//上标
                            superscript.FontName = "宋体";
                            result.ApplyFont(startIndex, endIndex, superscript);
                        }
                        length = length + v.Length;

                    }
                }
                #endregion
                #endregion

                if (allSpecialCharacters != null && allSpecialCharacters.SpecialCharacterList != null &&
                    allSpecialCharacters.SpecialCharacterList.Count > 0 &&
                    allSpecialCharacters.SpecialCharacterList.FirstOrDefault(p => p.Code.Trim().ToUpper() == value.Trim().ToUpper()) != null)
                {
                    SpecialCharacter spec = allSpecialCharacters.SpecialCharacterList.FirstOrDefault(p => p.Code.Trim().ToUpper() == value.Trim().ToUpper());
                    #region 将字符设置成斜体

                    HSSFFont normalFont = (HSSFFont)workbook.CreateFont();
                    normalFont.IsItalic = true;
                    normalFont.FontName = "宋体";
                    List<string> FontHeightInPoints10List = ReportStatic.SpecialCharacterFontHeightInPoints10();
                    if (FontHeightInPoints10List != null && FontHeightInPoints10List.FirstOrDefault(p => p == value.Trim()) != null)
                    {
                        normalFont.FontHeightInPoints = 10;// 设置字体大小
                    }
                    int startIndex = 0;
                    int endIndex = spec.Code.Trim().Length;
                    if (endIndex < 0)
                    {
                        endIndex = 0;
                    }
                    result.ApplyFont(startIndex, endIndex, normalFont);
                    #endregion

                    #region 设置下标
                    if (spec.SubscriptLastCount > 0)
                    {
                        //result = new HSSFRichTextString(value);
                        // superscript = (HSSFFont)workbook.CreateFont();
                        //superscript.TypeOffset = FontSuperScript.Super;//上标
                        //superscript.Color = HSSFColor.RED.index;

                        HSSFFont subscript = (HSSFFont)workbook.CreateFont();
                        subscript.TypeOffset = FontSuperScript.Sub; //下标  
                        //subscript.IsItalic = true;
                        subscript.FontName = "宋体";
                        //subscript.Color = HSSFColor.Red.Index;
                        //HSSFFont normalFont = (HSSFFont)workbook.CreateFont();
                        startIndex = spec.Code.Trim().Length - spec.SubscriptLastCount;
                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        endIndex = spec.Code.Trim().Length;
                        if (endIndex < 0)
                        {
                            endIndex = 0;
                        }
                        result.ApplyFont(startIndex, endIndex, subscript);
                    }
                    #endregion
                }
            }
            return result;

        }


        /// <summary>
        /// 获取单元格数据及动态数据组合
        /// </summary>
        /// <param name="DongTaiShuJuList">动态数据值</param>
        /// <param name="rowInfoList">动态数据位置</param>.
        /// <param name="sourceCell">单元格</param> 
        /// <returns></returns>
        private string GetDongTaiShuJu(List<string> DongTaiShuJuList = null, List<RowInfo> rowInfoList = null, ICell sourceCell = null)
        {
            if (sourceCell == null)
            {
                return "";
            }
            if (DongTaiShuJuList == null || DongTaiShuJuList.Count == 0)
            {
                return string.Format(sourceCell.StringCellValue, "");
            }
            if (rowInfoList == null || rowInfoList.Count == 0)
            {
                return string.Format(sourceCell.StringCellValue, "");
            }

            if (rowInfoList.FirstOrDefault(p => p.RowIndex == sourceCell.RowIndex && p.Cells != null && p.Cells.Count > 0) != null)
            {
                RowInfo r = rowInfoList.FirstOrDefault(p => p.RowIndex == sourceCell.RowIndex && p.Cells != null && p.Cells.Count > 0);
                if (r.Cells.Count(p => p.ColIndex == sourceCell.ColumnIndex) > 0)
                {
                    string value = string.Format(sourceCell.StringCellValue, DongTaiShuJuList[0]);
                    DongTaiShuJuList.RemoveAt(0);
                    return value;
                }
            }
            return string.Format(sourceCell.StringCellValue, "");
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
                    if (m < 57)
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
        private bool RemoveState1(List<RowInfo> temp, string code = "state1")
        {
            foreach (var f in temp)
            {
                foreach (var c in f.Cells)
                {
                    if (c.Code == code)
                    {
                        f.Cells.Remove(c);
                        return true;
                    }
                }
            }
            return true;
        }
        #endregion
        /// <summary>
        /// 设置表格
        /// </summary>
        /// <param name="html"></param>
        /// <param name="sheet_Source">源sheet</param>     
        /// <param name="sheet_Destination">目标sheet</param>
        /// <param name="rowIndex_Destination">目标开始行号</param>
        /// <param name="temp">模板信息</param>                 
        /// <param name="allSpecialCharacters">特殊字符配置信息</param>
        /// <param name="iEntity_DianNengBiaoZhunPianChaGuZhiJiSuan">电能标准偏差估计值检测项（为了解决s化整问题）</param>
        /// <returns></returns>
        private int paserData_1(QUALIFIED_UNQUALIFIED_TEST_ITE iEntity, bool IsSameRuleName, ISheet sheet_Source, ISheet sheet_Destination, int rowIndex_Destination, TableTemplate temp, ref bool isHaveHideData, SpecialCharacters allSpecialCharacters = null, ExportType type = ExportType.OriginalRecord_JianDing, QUALIFIED_UNQUALIFIED_TEST_ITE iEntity_DianNengBiaoZhunPianChaGuZhiJiSuan = null)
        {
            //isHaveHideData = false;
            bool IsHaveHideData1 = isHaveHideData;
            int RowIndexT = rowIndex_Destination;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(iEntity.HTMLVALUE);
            Dictionary<int, DataValue> dataDic = AnalyticHTML.GetData(doc);//数据

            #region s化整
            if (iEntity_DianNengBiaoZhunPianChaGuZhiJiSuan != null)
            {
                HtmlAgilityPack.HtmlDocument doc_DianNengBiaoZhunPianChaGuZhiJiSuan = new HtmlAgilityPack.HtmlDocument();
                doc_DianNengBiaoZhunPianChaGuZhiJiSuan.LoadHtml(iEntity_DianNengBiaoZhunPianChaGuZhiJiSuan.HTMLVALUE);
                Dictionary<int, DataValue> dataDic_DianNengBiaoZhunPianChaGuZhiJiSuan = AnalyticHTML.GetData(doc_DianNengBiaoZhunPianChaGuZhiJiSuan);//数据
                dataDic = SHuaZhengHeBing(dataDic, dataDic_DianNengBiaoZhunPianChaGuZhiJiSuan);
            }
            #endregion

            #region 处理空数据行删除
            //if (dataDic!=null && dataDic.Count>0 && temp != null && temp.Cells!=null && temp.Cells.Count>0 && temp.Cells.Count(p => p.IsHideRowNull == "Y") == 1)
            //{
            //    string hideCode =  temp.Cells.FirstOrDefault(p => p.IsHideRowNull == "Y").Code;
            //    bool IsEnd = false;
            //    foreach (int tongDaoID in dataDic.Keys)
            //    {
            //        if (dataDic[tongDaoID] != null && dataDic[tongDaoID].Count > 0)
            //        {
            //            DataValue d = dataDic[tongDaoID];

            //            if (d != null && d.Count > 0)
            //            {
            //                while (!IsEnd)
            //                {
            //                    foreach (Cell c in temp.Cells)
            //                    {
            //                        if (c.Code != null && c.Code.Trim() != "" && d.Data.FirstOrDefault(p=>p.name==)
            //                        {

            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }


            //}
            #endregion

            Dictionary<int, List<MYDataHead>> headDic = AnalyticHTML.GetHeadData(doc);//表头           
            Dictionary<int, List<MYDataHead>> footDic = AnalyticHTML.GetFootData(doc);//表尾

            #region 处理1075-2001_3_2最大基本误差整个页面只有一个,取第一个ACTUALVALUE，并且行数为通道行数
            //if (iEntity.RULEID == "1075-2001_3_2")
            //{
            //    if (dataDic != null && dataDic.Count > 0)
            //    {
            //        foreach (DataValue d in dataDic.Values)
            //        {
            //            if (d != null && d.Data != null && d.Data.Count > 0)
            //            {
            //                List<MYData> cData = d.Data.FindAll(p => p.name == "ACTUALVALUE");
            //                MYData mdd = null;
            //                List<MYData> removeList = new List<MYData>();
            //                int indexCount = 1;
            //                if (cData != null && cData.Count > 0)
            //                {
            //                    foreach (MYData md in cData)
            //                    {
            //                        if (indexCount == 1)
            //                        {
            //                            mdd = md;
            //                            mdd.mergedRowNum = d.Count;
            //                        }
            //                        else
            //                        {

            //                            removeList.Add(md);

            //                        }
            //                        indexCount++;
            //                    }
            //                    foreach (MYData md in removeList)
            //                    {
            //                        d.Data.Remove(md);
            //                    }
            //                }

            //            }
            //        }
            //    }
            //}
            #endregion 

            #region 处理没有表头的数据
            if (headDic == null || headDic.Count == 0)
            {
                headDic = new Dictionary<int, List<MYDataHead>>();
                if (dataDic != null && dataDic.Count > 0)
                {
                    foreach (int key in dataDic.Keys)
                    {
                        if (!headDic.ContainsKey(key))
                        {
                            headDic.Add(key, null);
                        }
                    }
                }
                if (footDic != null && footDic.Count > 0)
                {
                    foreach (int key in footDic.Keys)
                    {

                        if (!headDic.ContainsKey(key))
                        {
                            headDic.Add(key, null);
                        }
                    }
                }
            }
            #endregion 
            HeadValue buDueDingDu_DiBu = null;//底部不确定度
            if (type != ExportType.Report_JianDing)//除了检定报告不打底部不确定度，其他都打
            {
                buDueDingDu_DiBu = AnalyticHTML.GetBuDueDingDu_DiBu(doc);//底部不确定度
            }

            //if (iEntity.RULEID == "1085-2013_8" || iEntity.RULEID == "1085-2013_9" || iEntity.RULEID == "1085-2013_10")
            //{
            //   // continue;
            //}
            #region 处理单元格合并数据
            if (temp != null && temp.Cells != null && temp.Cells.Count > 0 && dataDic != null && dataDic.Count > 0)
            {
                #region 处理下一行数据为空需要单元格合并数据
                List<Cell> cList = temp.Cells.FindAll(p => p.IsMergeNullValue == "Y");
                if (cList != null && cList.Count > 0)
                {
                    foreach (Cell c in cList)
                    {
                        foreach (DataValue d in dataDic.Values)
                        {
                            if (d != null && d.Data != null && d.Data.Count > 0)
                            {
                                List<MYData> cData = d.Data.FindAll(p => p.name == c.Code);

                                MYData mdd = null;
                                List<MYData> removeList = new List<MYData>();
                                int indexCount = 1;
                                if (cData != null && cData.Count > 0)
                                {
                                    foreach (MYData md in cData)
                                    {
                                        if (indexCount == 1)
                                        {
                                            mdd = md;
                                        }
                                        else
                                        {
                                            if (md != null && !string.IsNullOrWhiteSpace(md.value))
                                            {
                                                mdd = md;
                                                mdd.mergedRowNum = md.mergedRowNum;
                                            }
                                            else if (md != null && string.IsNullOrWhiteSpace(md.value))
                                            {
                                                mdd.mergedRowNum = mdd.mergedRowNum + md.mergedRowNum;
                                                removeList.Add(md);
                                            }
                                        }
                                        indexCount++;
                                    }
                                    foreach (MYData md in removeList)
                                    {
                                        d.Data.Remove(md);
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region 处理下一行数据相同需要单元格合并数据
                cList = temp.Cells.FindAll(p => p.IsMergeSameValue == "Y");
                if (cList != null && cList.Count > 0)
                {
                    foreach (Cell c in cList)
                    {
                        foreach (DataValue d in dataDic.Values)
                        {
                            if (d != null && d.Data != null && d.Data.Count > 0)
                            {
                                List<MYData> cData = d.Data.FindAll(p => p.name == c.Code);

                                MYData mdd = null;
                                List<MYData> removeList = new List<MYData>();
                                int indexCount = 1;
                                if (cData != null && cData.Count > 0)
                                {
                                    foreach (MYData md in cData)
                                    {
                                        if (indexCount == 1)
                                        {
                                            mdd = md;
                                        }
                                        else
                                        {
                                            if (md != null && md.value != mdd.value)
                                            {
                                                mdd = md;
                                                mdd.mergedRowNum = md.mergedRowNum;
                                            }
                                            else if (md != null && md.value == mdd.value)
                                            {
                                                mdd.mergedRowNum = mdd.mergedRowNum + md.mergedRowNum;
                                                removeList.Add(md);
                                            }
                                        }
                                        indexCount++;
                                    }
                                    foreach (MYData md in removeList)
                                    {
                                        d.Data.Remove(md);
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion 

            }
            #endregion 

            int rowIndex = rowIndex_Destination;

            int headCount = 0;

            //循环通道
            if (headDic != null && headDic.Count > 0)
            {
                foreach (int tongDaoID in headDic.Keys)
                {
                    headCount++;
                    #region 画表头
                    #region 画格子 同时填充数据                   

                    if (temp != null && temp.TableTitleList != null && temp.TableTitleList.Count > 0 && temp.TableTitleList != null)
                    {
                        RowInfo t = temp.TableTitleList.FirstOrDefault();
                        if (t.RowIndex >= 0)
                        {
                            //数据与创建行同时进行 
                            for (int k = 0; k < t.RowNumber; k++)
                            {
                                if (iEntity.RULEID == "166-1993_3_4" && headCount > 1 && k == 0)//166-1993_3_4多个通道，只有第一个通道有二级标题
                                {
                                    continue;
                                }
                                else if (iEntity.RULEID == "125-2004_9_1" && headCount > 1 && k == 0)//125-2004_9_1多个通道，只有第一个通道有二级标题
                                {
                                    RemoveState1(temp.TableTitleList);


                                    continue;
                                }
                                else if (iEntity.RULEID == "169-2010_6_2" && headCount > 1 && k == 0)//多个通道，只有第一个通道有二级标题
                                {
                                    // RemoveState1(temp.TableTitleList);


                                    continue;
                                }
                                else if (iEntity.RULEID == "169-2010_6_1" && headCount > 1 && k == 0)//多个通道，只有第一个通道有二级标题
                                {
                                    // RemoveState1(temp.TableTitleList);


                                    continue;
                                }
                                else if (iEntity.RULEID == "1072-2011_6_1" && headCount > 1 && k == 0)//多个通道，只有第一个通道有二级标题
                                {
                                    RemoveState1(temp.TableTitleList);
                                    continue;
                                }
                                else if (iEntity.RULEID == "1072-2011_6_2" && headCount > 1 && k == 0)//多个通道，只有第一个通道有二级标题
                                {
                                    RemoveState1(temp.TableTitleList);
                                    continue;
                                }
                                else if (iEntity.RULEID == "125-2004_9_2" && headCount > 1 && k == 0)//多个通道，只有第一个通道有二级标题
                                {
                                    RemoveState1(temp.TableTitleList);
                                    continue;
                                }
                                else if (iEntity.RULEID == "125-2004_9_3" && headCount > 1 && k == 0)//多个通道，只有第一个通道有二级标题
                                {
                                    RemoveState1(temp.TableTitleList, "state");
                                    continue;
                                }
                                else
                                {
                                    //解决有的表头为空时需要显示/
                                    if (iEntity.RULEID == "125-2004_9_1" || iEntity.RULEID == "982-2003_6_1" ||
                                        iEntity.RULEID == "982-2003_6_2" || iEntity.RULEID == "1072-2011_6_1" ||
                                        iEntity.RULEID == "166-1993_3_4" || iEntity.RULEID== "124-2005_3")
                                    {
                                        CopyRow_1(sheet_Source, sheet_Destination, t.RowIndex + k, rowIndex_Destination, 1, true, temp.TableTitleList, allSpecialCharacters, headDic[tongDaoID], true);
                                    }
                                    else
                                    {
                                        CopyRow_1(sheet_Source, sheet_Destination, t.RowIndex + k, rowIndex_Destination, 1, true, temp.TableTitleList, allSpecialCharacters, headDic[tongDaoID]);
                                    }
                                    rowIndex_Destination++;
                                }
                                if (IsHaveHideData1 && k == 0 && iEntity.RULEID != "982-2003_6_2")
                                {
                                    //SetBorderTop(sheet_Destination.Workbook, sheet_Destination, rowIndex_Destination - 1);
                                    SetBorderTop(sheet_Destination.Workbook, sheet_Destination, rowIndex_Destination - 2);
                                }


                            }
                        }
                    }

                    #endregion
                    #endregion
                    #region 画数据部分
                    int startRowIndex = rowIndex_Destination;
                    if (dataDic != null && dataDic.ContainsKey(tongDaoID) && dataDic[tongDaoID] != null && dataDic[tongDaoID].Count > 0 && dataDic[tongDaoID].Data != null && dataDic[tongDaoID].Data.Count > 0 && temp.DataRowIndex >= 0)
                    {

                        #region 画数据  
                        #region 画格子                                              
                        Dictionary<string, CellRangeAddress> cellAddressList = CopyRow_1(sheet_Source, sheet_Destination, temp.DataRowIndex, rowIndex_Destination, dataDic[tongDaoID].Count, true, null, allSpecialCharacters, null);
                        rowIndex_Destination = rowIndex_Destination + dataDic[tongDaoID].Count;
                        #endregion
                        #region 填充数据

                        foreach (MYData d in dataDic[tongDaoID].Data)
                        {
                            if (cellAddressList == null || cellAddressList.Count == 0)
                            {
                                break;
                            }
                            if (temp.Cells.Count(p => p.Code == d.name) > 0)//配置中存在说明需要打印
                            {
                                //如果模板中有数据表示固定数据，否则是动态数据，固定数据跳过
                                string key = cellAddressList.Keys.FirstOrDefault();
                                int colCount = Convert.ToInt32(key.Split('_')[1]);
                                CellRangeAddress c = cellAddressList[key];
                                string cValue = sheet_Destination.GetRow(c.FirstRow).GetCell(c.FirstColumn).StringCellValue;
                                while (!string.IsNullOrWhiteSpace(cValue))
                                {
                                    if (temp.Cells.Count >= colCount && temp.Cells[colCount - 1].IsMergeSameValue == "Y")//固定值是否需要合并
                                    {
                                        sheet_Destination.AddMergedRegion(new CellRangeAddress(c.FirstRow, c.FirstRow + dataDic[tongDaoID].Count - 1, c.FirstColumn, c.LastColumn));
                                        int ccCount = 0;
                                        for (int j = 0; j < dataDic[tongDaoID].Count; j++)//将已合并或者已使用的区域移除
                                        {

                                            KeyValuePair<string, CellRangeAddress> cc = cellAddressList.FirstOrDefault(p => p.Value.FirstColumn == c.FirstColumn && p.Value.LastColumn == c.LastColumn);
                                            if (!string.IsNullOrWhiteSpace(cc.Key) && cc.Value != null && cc.Value.FirstColumn == c.FirstColumn && cc.Value.LastColumn == c.LastColumn)
                                            {
                                                if (ccCount > 0)
                                                {
                                                    sheet_Destination.GetRow(cc.Value.FirstRow).GetCell(cc.Value.FirstColumn).SetCellValue(new HSSFRichTextString(""));
                                                }
                                                cellAddressList.Remove(cc.Key);
                                                ccCount++;
                                            }

                                        }

                                    }
                                    else
                                    {
                                        cellAddressList.Remove(key);
                                    }
                                    key = cellAddressList.Keys.FirstOrDefault();
                                    c = cellAddressList[key];
                                    cValue = sheet_Destination.GetRow(c.FirstRow).GetCell(c.FirstColumn).StringCellValue;
                                }
                                HSSFRichTextString value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, d.value);

                                if ((value == null || string.IsNullOrWhiteSpace(value.String)) && temp.Cells.FirstOrDefault(p => p.Code == d.name) != null && temp.Cells.FirstOrDefault(p => p.Code == d.name).IsHideRowNull == "Y")
                                {
                                    HideRow(sheet_Destination, c.FirstRow, 1);
                                    isHaveHideData = true;
                                    //DeleteRowList.Add(c.FirstRow);
                                }
                                else if ((value == null || string.IsNullOrWhiteSpace(value.String)) && d.name.IndexOf("_UNIT") < 0)
                                {
                                    value = new HSSFRichTextString("/");
                                }
                                sheet_Destination.GetRow(c.FirstRow).GetCell(c.FirstColumn).SetCellValue(value);
                                if (d.mergedRowNum > 1)//多行单元格合并
                                {
                                    //if ((iEntity.RULEID == "440-2008_10") ||
                                    //    (iEntity.RULEID == "1075-2001_3_1") ||
                                    //    (iEntity.RULEID == "169-2010_4_2") ||
                                    //    (iEntity.RULEID == "984-2004_2") ||
                                    //    (iEntity.RULEID == "1085-2013_6_1") ||
                                    //    (iEntity.RULEID == "169-2010_4_3") ||
                                    //    (iEntity.RULEID == "1264-2010_3_1"))//解决单元格无法合并问题，目前没找到原因
                                    //{
                                    for (int k = 0; k <= d.mergedRowNum * 3; k++)
                                    {
                                        sheet_Destination.AddMergedRegion(new CellRangeAddress(c.FirstRow, c.FirstRow + d.mergedRowNum - 1, c.FirstColumn, c.LastColumn));
                                    }
                                    //}
                                    //else
                                    //{
                                    //    sheet_Destination.AddMergedRegion(new CellRangeAddress(c.FirstRow, c.FirstRow + d.mergedRowNum - 1, c.FirstColumn, c.LastColumn));

                                    //}

                                }

                                for (int j = 0; j < d.mergedRowNum; j++)//将已合并或者已使用的区域移除
                                {
                                    KeyValuePair<string, CellRangeAddress> cc = cellAddressList.FirstOrDefault(p => p.Value.FirstColumn == c.FirstColumn && p.Value.LastColumn == c.LastColumn);
                                    if (!string.IsNullOrWhiteSpace(cc.Key) && cc.Value != null && cc.Value.FirstColumn == c.FirstColumn && cc.Value.LastColumn == c.LastColumn)
                                    {
                                        cellAddressList.Remove(cc.Key);
                                    }
                                }

                            }
                        }

                        #endregion
                        #endregion

                    }
                    #endregion

                    #region 画表尾
                    #region 画格子 同时填充数据                   

                    if (temp != null && temp.TableFooterList != null && temp.TableFooterList.Count > 0 && footDic != null && footDic.Count > 0)
                    {
                        RowInfo t = temp.TableFooterList.FirstOrDefault();
                        if (t.RowIndex >= 0)
                        {
                            //数据与创建行同时进行 
                            for (int k = 0; k < t.RowNumber; k++)
                            {
                                if (footDic.ContainsKey(tongDaoID))
                                {
                                    CopyRow_1(sheet_Source, sheet_Destination, t.RowIndex + k, rowIndex_Destination, 1, true, temp.TableFooterList, allSpecialCharacters, footDic[tongDaoID], true);

                                    rowIndex_Destination++;
                                }
                            }
                        }
                    }

                    #endregion
                    #endregion

                }

            }

            if (IsSameRuleName)
            {
                //为了相同项表格底部没有线   
                //if ((iEntity.RULEID!= "982-2003_6_2" && iEntity.RULEID != "169 -2010_6_2" && iEntity.RULEID != "169-2010_6_1" && iEntity.RULEID!= "169-2010_6_3" && iEntity.RULEID!= "169-2010_6_4" && type== ExportType.Report_JianDing) &&
                //    (iEntity.RULEID != "169-2010_4_2" && iEntity.RULEID != "169-2010_4_3" && iEntity.RULEID!= "169-2010_4_1" && type== ExportType.Report_JianDing))
                //{
                //    SetBorderTop(sheet_Destination.Workbook, sheet_Destination, RowIndexT);
                //}
            }

            #region 注、说明
            //为了表格底部没有线
            //CopyRow(sheet_Source, sheet_Destination, 3, rowIndex_Destination, 1, true);
            //HideRow(sheet_Destination, rowIndex_Destination, 1);
            //rowIndex_Destination++;

            //表格注
            string RemarkStr = string.Empty;
            List<SpecialCharacter_Index> sIndexList = ReportStatic.GetSpecialCharacter_Indexs(iEntity.RULEID, out RemarkStr);
            if (!string.IsNullOrWhiteSpace(RemarkStr) && temp.RemarkRowIndex >= 0)
            {
                CopyRow(sheet_Source, sheet_Destination, temp.RemarkRowIndex, rowIndex_Destination, 1, true);

                HSSFRichTextString value = SetSub((HSSFWorkbook)sheet_Destination.Workbook, allSpecialCharacters, RemarkStr, sIndexList);
                sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).CellStyle.WrapText = true;//自动换行
                sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue(value);
                rowIndex_Destination++;
            }
            else if (iEntity.REMARK != null && iEntity.REMARK.Trim() != "" && temp.RemarkRowIndex >= 0)
            {
                CopyRow(sheet_Source, sheet_Destination, temp.RemarkRowIndex, rowIndex_Destination, 1, true);

                sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue("注：" + iEntity.REMARK);
                rowIndex_Destination++;
            }

            //表格结论
            if (iEntity.CONCLUSION != null && iEntity.CONCLUSION.Trim() != "" && temp.ConclusionRowIndex >= 0)
            {
                CopyRow(sheet_Source, sheet_Destination, temp.ConclusionRowIndex, rowIndex_Destination, 1, true);
                sheet_Destination.GetRow(rowIndex_Destination).GetCell(0).SetCellValue("结论：" + iEntity.CONCLUSION);
                rowIndex_Destination++;
            }
            #endregion

            #region 底部不确定度

            if (buDueDingDu_DiBu != null && buDueDingDu_DiBu.Count > 0 && buDueDingDu_DiBu.Data != null && buDueDingDu_DiBu.Data.Count > 0)
            {
                List<RowInfo> rowInfoList = new List<RowInfo>();
                RowInfo r = new RowInfo();
                if (buDueDingDu_DiBu.Data.Count >= 0)
                {
                    r.Cells = new List<Cell>();
                    for (int i = 0; i < 3; i++)
                    {
                        Cell c = new Cell();
                        c.Code = buDueDingDu_DiBu.Data[i].name;
                        r.Cells.Add(c);
                    }
                    rowInfoList.Add(r);
                }
                //画底部不确定表格及填充数据
                for (int i = 0; i < buDueDingDu_DiBu.Count; i++)
                {
                    CopyRow_1(sheet_Source, sheet_Destination, 1368, rowIndex_Destination, 1, true, rowInfoList, allSpecialCharacters, buDueDingDu_DiBu.Data, true);
                    rowIndex_Destination = rowIndex_Destination + 1;
                }

            }

            #endregion

            //为了表格底部没有线           
            CopyRow(sheet_Source, sheet_Destination, 4, rowIndex_Destination, 1, true);

            if (iEntity.RULEID == "1085-2013_8" || iEntity.RULEID == "1085-2013_9" || iEntity.RULEID == "124-2005_3" || iEntity.RULEID == "169-2010_4_1" ||
                ((iEntity.RULEID == "440-2008_9" || iEntity.RULEID == "169-2010_4_2" || iEntity.RULEID == "169-2010_4_3" ||
                 iEntity.RULEID == "169-2010_5" || iEntity.RULEID == "169-2010_6_1" || iEntity.RULEID == "169-2010_6_2") && type == ExportType.Report_JianDing))
            {
                ICellStyle style = sheet_Destination.Workbook.CreateCellStyle();
                style.BorderBottom = BorderStyle.None;
                style.BorderTop = BorderStyle.None;
                for (int col = 0; col < 57; col++)
                {
                    ICell targetCell = sheet_Destination.GetRow(rowIndex_Destination).GetCell(col);
                    targetCell.CellStyle = style;
                }


            }
            else if (iEntity.RULEID == "169-2010_5")
            {

                ICellStyle style = sheet_Destination.Workbook.CreateCellStyle();
                style.BorderBottom = BorderStyle.None;
                style.BorderTop = BorderStyle.None;
                for (int col = 0; col < 57; col++)
                {
                    if ((col >= 0 && col <= 7) || (col >= 13 && col <= 20) || (col >= 26 && col <= 33) || (col >= 40 && col <= 47))
                    {
                        ICell targetCell = sheet_Destination.GetRow(rowIndex_Destination).GetCell(col);
                        targetCell.CellStyle = style;
                    }
                }
            }
            return rowIndex_Destination;
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
        /// 删除行
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="fowIndex">行号</param>        
        private void DeleteRow(ISheet sheet, int RowIndex)
        {
            IRow sourceRow = sheet.GetRow(RowIndex);
            sheet.RemoveRow(sourceRow);
            sheet.ShiftRows(RowIndex + 1, sheet.LastRowNum, -1);
        }

        /// <summary>
        /// 相同规则名称，需要合并只有展示一个标题
        /// </summary>
        /// <returns></returns>
        private List<string> GetSameRuleName()
        {
            List<string> result = new List<string>();
            result.Add("有功功率测量");
            result.Add("有功功率输出");
            result.Add("电能基本误差");
            result.Add("误差测量");
            result.Add("内附百分表");
            return result;

        }
        /// <summary>
        /// 获取斜体字符集,主要用于字符中含有多个的情况
        /// </summary>
        /// <returns></returns>
        private List<string> GetXieTiList()
        {
            List<string> result = new List<string>();
            result.Add("DCV");
            result.Add("ACV");
            result.Add("DCI");
            result.Add("ACI");
            result.Add("DCR");
            result.Add("UREL");
            return result;

        }


    }
}
