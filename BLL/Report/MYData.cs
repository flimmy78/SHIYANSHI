using System.Collections.Generic;

namespace Langben.Report
{
    
    public class MYDataHead
    {
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
    /// <summary>
    /// id name value hangshu(合并几行单元格) 通道 量程 行号 第几列
    /// </summary>
    public class MYData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        /// <summary>
        /// 合并几行单元格
        /// </summary>
        public int mergedRowNum { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        //public int rowNum { get; set; }
        /// <summary>
        /// 第几列
        /// </summary>
        public int columnNum { get; set; }
    }
}
