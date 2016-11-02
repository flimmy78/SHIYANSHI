using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Langben.Report
{
    /// <summary>
    /// 表格模板位置
    /// </summary>
    public class TableTemplateExt : TableTemplate
    {
        Dictionary<string, string> _CellList = null;
        /// <summary>
        /// 单元格信息
        /// </summary>
        public Dictionary<string, string> CellList
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
        private int _ColCount = 1;
        /// <summary>
        /// 模板中单元格所占列数
        /// </summary>
        [XmlElement("ColCount")]
        public int ColCount
        {
            get { return _ColCount; }
            set { _ColCount = value; }
        }
    }
}
