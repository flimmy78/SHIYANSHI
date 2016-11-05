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
        [XmlElement("RuleID")]
        public string RuleID
        {
            get;
            set;
        }
        /// <summary>
        /// 是否有二级标题
        /// </summary>
        public bool IsHaveSecondTitle
        {
            get
            {
                if(SecondTitleList!=null && SecondTitleList.Count>0 && SecondTitleList.Count(p=>p.RowIndex>=0)>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 是否有表格表头
        /// </summary>
        public bool IsHaveTableTitle
        {
            get
            {
                if (TableTitleList != null && TableTitleList.Count > 0 && TableTitleList.Count(p => p.RowIndex >= 0) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private int _DataRowIndx = -1;
        /// <summary>
        /// 数据模板行号
        /// </summary>
        [XmlElement("DataRowIndex")]
        public int DataRowIndex
        {
            get { return _DataRowIndx-1; }
            set { _DataRowIndx = value; }

        }
        private int _RemarkRowIndx = -1;
        /// <summary>
        /// 备注模板行号
        /// </summary>
        [XmlElement("RemarkRowIndex")]
        public int RemarkRowIndex
        {
            get { return _RemarkRowIndx-1; }
            set { _RemarkRowIndx = value; }
        }
        private int _ConclusionRowIndx = -1;
        /// <summary>
        /// 结论模板行号
        /// </summary>
        [XmlElement("ConclusionRowIndex")]
        public int ConclusionRowIndex
        {
            get { return _ConclusionRowIndx-1; }
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
        /// <summary>
        /// 二级标题，有就配置，没有该节点可不配置
        /// </summary>
        [XmlArray("SecondTitleList")]
        [XmlArrayItem("RowInfo")]
        public List<RowInfo> SecondTitleList
        {
            get;
            set;
        }
        /// <summary>
        /// 二级标题，有就配置，没有该节点可不配置
        /// </summary>
        [XmlArray("TableTitleList")]
        [XmlArrayItem("RowInfo")]
        public List<RowInfo> TableTitleList
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 表格表头每行信息，每行一个
    /// </summary>
    [XmlRoot("RowInfo")]
    public class RowInfo
    {

        private int _RowIndex = -1;
        /// <summary>
        /// 表格表头行号
        /// </summary>
        [XmlElement("RowIndex")]
        public int RowIndex
        {
            get { return _RowIndex - 1; }
            set { _RowIndex = value; }
        }
        /// <summary>
        /// 表格表头改行动态数据的单元给列号，多个用,分割例如：4,6如果没有动态数据可以不填
        /// </summary>
        [XmlElement("CellIndexs")]
        public string CellIndexs
        {
            get;
            set;
        }
        List<int> _CellIndexList = null;
        /// <summary>
        /// 表格表头改行动态数据的单元给列号
        /// </summary>
        public List<int> CellIndexList
        {
            get
            {
                if (CellIndexs != null && CellIndexs.Trim() != "")
                {
                    foreach (string s in CellIndexs.Trim().Split(','))
                    {
                        if (s != null && s.Trim() != "")
                        {
                            int index = -1;
                            if (Int32.TryParse(s.Trim(), out index))
                            {
                                index = index - 1;
                                if (_CellIndexList == null)
                                {
                                    _CellIndexList = new List<int>();
                                }
                                if (!_CellIndexList.Contains(index))
                                {
                                    _CellIndexList.Add(index);
                                }

                            }
                        }
                    }
                }
                return _CellIndexList;
            }
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
            get { return _ColIndex-1; }
            set { _ColIndex = value; }
        }
        private int _ColCount = 1;
        /// <summary>
        /// 模板中单元格所占列数
        /// </summary>
        [XmlElement("ColCount")]
        public int ColCount
        {
            get { return _ColCount-1; }
            set { _ColCount = value; }
        }
    }
}
