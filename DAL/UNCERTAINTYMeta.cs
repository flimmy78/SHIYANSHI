using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(UNCERTAINTYMetadata))]//使用UNCERTAINTYMetadata对UNCERTAINTY进行数据验证
    public partial class UNCERTAINTY 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "规程检定项目")]
        public string RULEIDOld { get; set; }
        
        #endregion

    }
    public partial class UNCERTAINTYMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "量程", Order = 2)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? RANGE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "量程单位", Order = 3)]
			public object RANGE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "指标1", Order = 4)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? KPI_1 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "指标1单位", Order = 5)]
			public object KPI_1_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "指标2", Order = 6)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? KPI_2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "指标2单位", Order = 7)]
			public object KPI_2_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "规程检定项目", Order = 8)]
			public object RULEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 9)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 10)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 11)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 12)]
			public object UPDATEPERSON { get; set; }


    }
}
 

