using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static Dictionary<string,TableTemplate> TableTemplateDic
        {
            get
            {
                Dictionary<string, TableTemplate> result = new Dictionary<string, TableTemplate>();
                TableTemplate item = null;                
                #region 直流电流输出
                item = new TableTemplate();
                #region 单元格
                item.CellList = new Dictionary<string, int>();
                //量程
                item.CellList.Add("RANGE", 0);
                //量程单位
                item.CellList.Add("RANGE_UNIT", 2);
                //选用电阻阻值
                item.CellList.Add("RESISTANCE", 3);
                //输出示值
                item.CellList.Add("OUTPUT_VALUE", 7);
                //输出示值单位
                item.CellList.Add("OUTPUT_VALUE_UNIT", 11);
                //输出示值单位
                item.CellList.Add("READ_VALUE", 12);
                //输出示值单位
                item.CellList.Add("READ_VALUE_UNIT", 16);
                //输出实际值
                item.CellList.Add("ACTUAL_OUTPUT_VALUE", 17);
                //输出实际值单位
                item.CellList.Add("ACTUAL_OUTPUT_VALUE_UNIT", 21);
                //相对误差
                item.CellList.Add("RELATIVE_ERROR", 22);
                //校准结果的不确定度U(k=2)
                item.CellList.Add("UNCERTAINTY_DEGREE", 26);
                //校准结果的不确定度U(k=2)
                item.CellList.Add("UNCERTAINTY_DEGREE_UNIT", 30);
                #endregion 
                item.InpputState = InputStateEnums.ZhiLiuDianLiuShuChu;
                item.ConclusionRowIndx = 51;
                item.DataRowIndx = 49;
                item.RemarkRowIndx = 50;
                item.TitleRowIndx = 48;
                item.TitleRowCount = 1;
                if (!result.ContainsKey(item.InpputState.ToString()))
                {
                    result.Add(item.InpputState.ToString(), item);
                }
                #endregion
                return result;

            }
        }
    }
    /// <summary>
    /// 表格模板位置
    /// </summary>
    public class TableTemplate
    {
        private InputStateEnums _InpputState = InputStateEnums.ZhiLiuDianLiuShuChu;
        /// <summary>
        /// 输入格式
        /// </summary>
        public InputStateEnums InpputState
        {
            get { return _InpputState; }
            set { _InpputState = value; }
        }
        private int _TitleRowIndex = 0;
        /// <summary>
        /// 标头模板行号
        /// </summary>
        public int TitleRowIndx
        {
            get { return _TitleRowIndex; }
            set { _TitleRowIndex = value; }
        }
        private int _TitleRowCount = 1;
        /// <summary>
        /// 标头行数
        /// </summary>
        public int TitleRowCount
        {
            get { return _TitleRowCount; }
            set { _TitleRowCount = value; }
        }
        private int _DataRowIndx = -1;
        /// <summary>
        /// 数据模板行号
        /// </summary>
        public int DataRowIndx
        {
            get { return _DataRowIndx; }
            set { _DataRowIndx = value; }
        }
        private int _RemarkRowIndx = -1;
        /// <summary>
        /// 备注模板行号
        /// </summary>
        public int RemarkRowIndx
        {
            get { return _RemarkRowIndx; }
            set { _RemarkRowIndx = value; }
        }
        private int _ConclusionRowIndx = -1;
        /// <summary>
        /// 结论模板行号
        /// </summary>
        public int ConclusionRowIndx
        {
            get { return _ConclusionRowIndx; }
            set { _ConclusionRowIndx = value; }
        }
        Dictionary<string, int> _CellList = null;
        /// <summary>
        /// 单元格信息
        /// </summary>
        public Dictionary<string,int> CellList
        {
            get { return _CellList; }
            set { _CellList = value; }
        }
    }
     
}
