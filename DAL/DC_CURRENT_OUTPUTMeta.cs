using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(DC_CURRENT_OUTPUTMetadata))]//使用DC_CURRENT_OUTPUTMetadata对DC_CURRENT_OUTPUT进行数据验证
    public partial class DC_CURRENT_OUTPUT 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "表整体")]
        public string OVERALL_TABLEIDOld { get; set; }
        
        #endregion

    }
    public partial class DC_CURRENT_OUTPUTMetadata
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
			[Display(Name = "选用电阻阻值", Order = 4)]
			public object RESISTANCE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "选用电阻阻值单位", Order = 5)]
			public object RESISTANCE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "输出示值", Order = 6)]
			public object OUTPUT_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "输出示值单位", Order = 7)]
			public object OUTPUT_VALUE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "读数值", Order = 8)]
			public object READ_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "读数值单位", Order = 9)]
			public object READ_VALUE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "输出实际值", Order = 10)]
			public object ACTUAL_OUTPUT_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "输出实际值单位", Order = 11)]
			public object ACTUAL_OUTPUT_VALUE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "相对误差", Order = 12)]
			public object RELATIVE_ERROR { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "相对误差单位", Order = 13)]
			public object RELATIVE_ERROR_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "不确定度", Order = 14)]
			public object UNCERTAINTY_DEGREE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "不确定度单位", Order = 15)]
			public object UNCERTAINTY_DEGREE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "指标1", Order = 16)]
			public object INDEX1 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "指标2", Order = 17)]
			public object INDEX2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准电阻指标", Order = 18)]
			public object STANDARD_RESISTANCE_INDEX { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "分辨力", Order = 19)]
			public object RESOLUTION { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "参考量程", Order = 20)]
			public object REFERENCE_RANGE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 21)]
			public object PREPARE_SCHEMEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "表整体", Order = 22)]
			public object OVERALL_TABLEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 23)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 24)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 25)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 26)]
			public object UPDATEPERSON { get; set; }


    }
}
 

