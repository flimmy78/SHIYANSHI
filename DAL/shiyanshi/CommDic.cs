using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Langben.DAL.shiyanshi
{
    /// <summary>
    /// 公共数据字典
    /// </summary>
    public class CommDic
    {
        /// <summary>
        /// 规程数据字典
        /// </summary>
        public static Dictionary<string, string> RuleDic
        {
            get
            {
                Dictionary<string, string> _RuleDic = new Dictionary<string, string>();
                _RuleDic.Add("38-1987", "JJG(航天) 38-1987 直流标准电流源检定规程");
                return _RuleDic;
            }
        }

        /// <summary>
        /// 导出模板信息设置（根据输入格式设置）
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, TableTemplateExt> TableTemplateDic()
        {
            Dictionary<string, TableTemplateExt> result = new Dictionary<string, TableTemplateExt>();
            TableTemplates temp = GetTableTemplates();
            if (temp != null && temp.TableTemplateList != null && temp.TableTemplateList.Count > 0)
            {
                TableTemplateExt tExt = null;
                foreach (TableTemplate t in temp.TableTemplateList)
                {                  
                    tExt = new shiyanshi.TableTemplateExt();
                    tExt.Cells = t.Cells;
                    tExt.ConclusionRowIndex = t.ConclusionRowIndex;
                    tExt.DataRowIndex = t.DataRowIndex;
                    //tExt.InpputState = t.InpputState;
                    tExt.InpputStateStr = t.InpputStateStr;
                    tExt.Remark = t.Remark;
                    tExt.RemarkRowIndex = t.RemarkRowIndex;
                    tExt.TitleRowCount = t.TitleRowCount;
                    tExt.TitleRowIndex = t.TitleRowIndex;
                    if (!result.ContainsKey(tExt.InpputStateStr))
                    {
                        Dictionary<string, int> CellList = null;
                        if (tExt.Cells != null && tExt.Cells.Count > 0)
                        {
                            CellList = new Dictionary<string, int>();
                            foreach(Cell c in tExt.Cells)
                            {
                                if(!CellList.ContainsKey(c.Code))
                                {
                                    CellList.Add(c.Code, c.ColIndex);
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
        /// 获取模板设置xml数据
        /// </summary>
        /// <returns></returns>
        public TableTemplates GetTableTemplates()
        {
            TableTemplates result = null;
            if (ConfigurationManager.AppSettings["TableTemplateXmlUrl"] != null)
            {              
                string url = ConfigurationManager.AppSettings["TableTemplateXmlUrl"].ToString().Trim();
                string str = Common.DirFile.ReadFile(url);                
                result = TableTemplates.XmlCovertObj(str);
            }
            return result;

        }
    }
    /// <summary>
    /// 表格模板位置
    /// </summary>
    public class TableTemplateExt:TableTemplate
    {
        Dictionary<string, int> _CellList = null;
        /// <summary>
        /// 单元格信息
        /// </summary>
        public Dictionary<string, int> CellList
        {
            get { return _CellList; }
            set { _CellList = value; }
        }
    }
    [XmlRoot("TableTemplates")]
    public class TableTemplates : ObjConvert<TableTemplates>
    {        
        /// <summary>
        /// 
        /// </summary>
        [XmlArray("TableTemplateList")]
        [XmlArrayItem("TableTemplate")]
        public List<TableTemplate> TableTemplateList
        {
            get;
            set;
        }        
    }   
    /// <summary>
    /// 表格模板位置
    /// </summary>
    [XmlRoot("TableTemplate")]
    public class TableTemplate
    {
        private InputStateEnums _InpputState = InputStateEnums.ZhiLiuDianLiuShuChu;
        /// <summary>
        /// 输入格式
        /// </summary>
        public InputStateEnums InpputState
        {
            get
            {
                _InpputState = InputStateEnums.ZhiLiuDianLiuShuChu;
                try
                {
                    _InpputState = (InputStateEnums)Enum.Parse(typeof(InputStateEnums), InpputStateStr);
                }
                catch
                {

                    _InpputState = InputStateEnums.ZhiLiuDianLiuShuChu;
                }
                return _InpputState;
            }          
        }
        /// <summary>
        /// 输入格式字符串
        /// </summary>
        [XmlElement("InpputState")]
        public string InpputStateStr
        {
            get;
            set;
        }
        private int _TitleRowIndex = 0;
        /// <summary>
        /// 标头模板行号
        /// </summary>
        [XmlElement("TitleRowIndex")]
        public int TitleRowIndex
        {
            get { return _TitleRowIndex; }
            set { _TitleRowIndex = value; }            
        }
        private int _TitleRowCount = 1;
        /// <summary>
        /// 标头行数
        /// </summary>
        [XmlElement("TitleRowCount")]
        public int TitleRowCount
        {
            get { return _TitleRowCount; }
            set { _TitleRowCount = value; }            
        }
        private int _DataRowIndx = -1;
        /// <summary>
        /// 数据模板行号
        /// </summary>
        [XmlElement("DataRowIndex")]
        public int DataRowIndex
        {
            get { return _DataRowIndx; }
            set { _DataRowIndx = value; }            

        }
        private int _RemarkRowIndx = -1;
        /// <summary>
        /// 备注模板行号
        /// </summary>
        [XmlElement("RemarkRowIndex")]
        public int RemarkRowIndex
        {
            get { return _RemarkRowIndx; }
            set { _RemarkRowIndx = value; }            
        }
        private int _ConclusionRowIndx = -1;
        /// <summary>
        /// 结论模板行号
        /// </summary>
        [XmlElement("ConclusionRowIndex")]
        public int ConclusionRowIndex
        {
            get { return _ConclusionRowIndx; }
            set { _ConclusionRowIndx = value; }            
        }

        /// <summary>
        /// 备注说明
        /// </summary>
        [XmlElement("Remark")]
        public string Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 单元格信息
        /// </summary>
        [XmlArray("CellList")]
        [XmlArrayItem("Cell")]
        public List<Cell> Cells
        {
            get;
            set;
        }
    }
    [XmlRoot("Cell")]
    public class Cell
    {
        /// <summary>
        /// 字段代码与模板中设置的字段保持一致
        /// </summary>
        [XmlElement("Code")]
        public string Code
        {
            get;
            set;
        }
        /// <summary>
        /// 字段名称含义
        /// </summary>
        [XmlElement("Name")]
        public string Name
        {
            get;
            set;
        }
        private int _ColIndex = -1;
        /// <summary>
        /// 模板中单元格列号
        /// </summary>
        [XmlElement("ColIndex")]
        public int ColIndex
        {
            get { return _ColIndex; }
            set { _ColIndex = value; }
        }
    }
     
}
