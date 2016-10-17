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

namespace Langben.App.Controllers
{
    /// <summary>
    /// 预备方案
    /// </summary>
    public class PREPARE_SCHEMEController : BaseController
    {

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
        public ActionResult Edit(string ID="")
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
                vList= vBLL.GetByPREPARE_SCHEMEID(entity.ID);
                result.vtest_ite = new PagedList<VTEST_ITE>(vList,1,int.MaxValue);
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
                result.Message = Suggestion.UpdateFail + "未找到预备方案ID为【"+ID+"】的数据";
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
                sheet.GetRow(11).GetCell(23).SetCellValue(entity.RATED_FREQUENCY);
                //脉冲常数
                sheet.GetRow(12).GetCell(7).SetCellValue(entity.PULSE_CONSTANT);               

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
                    IRow OldRow = sheet.GetRow(16);//获取源格式行
                    if (rList.Count > 1)
                    {
                        int RowCount = rList.Count - 1;
                        RowIndex++;
                        InsertRow(sheet, 17, RowCount, OldRow);
                    }
                    RowIndex = 16;
                    foreach (VRULE rEntity in rList)
                    {
                        sheet.GetRow(RowIndex).GetCell(2).SetCellValue(rEntity.NAME);
                        RowIndex++;
                    }
                }
                #endregion 

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
        /// <summary>
        /// 插入行
        /// </summary>
        /// <param name="Sheet">指定操作的Sheet</param>
        /// <param name="StartIndex">指定在第几行指入（插入行的位置）</param>
        /// <param name="RowCount">指定要插入多少行</param>
        /// <param name="OldRow">源单元格格式的行</param>
        private void InsertRow(ISheet Sheet, int StartIndex, int RowCount, IRow OldRow)
        {
            #region 批量移动行
            Sheet.ShiftRows(
                StartIndex,                     //--开始行
                Sheet.LastRowNum,               //--结束行
                RowCount,                       //--移动大小(行数)--往下移动
                true,                           //是否复制行高
                false//,                        //是否重置行高
                     //true                     //是否移动批注
            );
            #endregion

            #region 对批量移动后空出的空行插，创建相应的行，并以插入行的上一行为格式源(即：插入行-1的那一行)
            for (int i = StartIndex; i < RowCount + StartIndex - 1; i++)
            {
                IRow targetRow = null;
                ICell sourceCell = null;
                ICell targetCell = null;

                targetRow = Sheet.CreateRow(i + 1);

                for (int m = OldRow.FirstCellNum; m < OldRow.LastCellNum; m++)
                {
                    sourceCell = OldRow.GetCell(m);
                    if (sourceCell == null)
                        continue;
                    targetCell = targetRow.CreateCell(m);

                    //targetCell..Encoding = sourceCell.Encoding;
                    targetCell.CellStyle = sourceCell.CellStyle;
                    targetCell.SetCellType(sourceCell.CellType);
                }
                //CopyRow(sourceRow, targetRow);
                //Util.CopyRow(sheet, sourceRow, targetRow);
            }

            IRow firstTargetRow = Sheet.GetRow(StartIndex);
            ICell firstSourceCell = null;
            ICell firstTargetCell = null;

            for (int m = OldRow.FirstCellNum; m < OldRow.LastCellNum; m++)
            {
                firstSourceCell = OldRow.GetCell(m);
                if (firstSourceCell == null)
                    continue;
                firstTargetCell = firstTargetRow.CreateCell(m);

                //firstTargetCell.Encoding = firstSourceCell.Encoding;
                firstTargetCell.CellStyle = firstSourceCell.CellStyle;
                firstTargetCell.SetCellType(firstSourceCell.CellType);
            }
            #endregion
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


