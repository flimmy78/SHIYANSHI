using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(DC_VOLTAGE_CURRENT_MEASUREMetadata))]//使用DC_VOLTAGE_CURRENT_MEASUREMetadata对DC_VOLTAGE_CURRENT_MEASURE进行数据验证
    public partial class DC_VOLTAGE_CURRENT_MEASURE 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "表整体")]
        public string OVERALL_TABLEIDOld { get; set; }
        
        #endregion

    }
    public partial class DC_VOLTAGE_CURRENT_MEASUREMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "量程", Order = 2)]
			public object RANGE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "量程单位", Order = 3)]
			public object RANGE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准值", Order = 4)]
			public object STANDARD_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准值单位", Order = 5)]
			public object STANDARD_VALUE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值正", Order = 6)]
			public object DISPLAY_VALUE_POSITIVE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值正单位", Order = 7)]
			public object DISPLAY_VALUE_POSITIVE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值负", Order = 8)]
			public object DISPLAY_VALUE_NEGATIVE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值负单位", Order = 9)]
			public object DISPLAY_VALUE_NEGATIVE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "相对误差正", Order = 10)]
			public object RELATIVE_ERROR_POSITIVE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "相对误差正单位", Order = 11)]
			public object RELATIVE_ERROR_POSITIVE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "相对误差负", Order = 12)]
			public object RELATIVE_ERROR_NEGATIVE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "相对误差负单位", Order = 13)]
			public object RELATIVE_ERROR_NEGATIVE_UNIT { get; set; }

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
			[Display(Name = "指标2单位", Order = 18)]
			public object INDEX2_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "分辨力", Order = 19)]
			public object RESOLUTION { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 20)]
			public object STATUS { get; set; }

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
 

