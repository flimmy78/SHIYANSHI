using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(CROSS_VOLTAGE_CURRENTMetadata))]//使用CROSS_VOLTAGE_CURRENTMetadata对CROSS_VOLTAGE_CURRENT进行数据验证
    public partial class CROSS_VOLTAGE_CURRENT 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "交采头")]
        public string CROSS_HEADIDOld { get; set; }
        
        #endregion

    }
    public partial class CROSS_VOLTAGE_CURRENTMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "测量点", Order = 2)]
			public object TEST_POINT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "测量点单位", Order = 3)]
			public object TEST_POINT_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准值A", Order = 4)]
			public object STANDARD_VALUE_A { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准值A单位", Order = 5)]
			public object STANDARD_VALUE_A_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准值B", Order = 6)]
			public object STANDARD_VALUE_B { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准值B单位", Order = 7)]
			public object STANDARD_VALUE_B_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准值C", Order = 8)]
			public object STANDARD_VALUE_C { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准值C单位", Order = 9)]
			public object STANDARD_VALUE_C_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值A", Order = 10)]
			public object DISPLAY_A_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值A单位", Order = 11)]
			public object DISPLAY_VALUE_A_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值B", Order = 12)]
			public object DISPLAY_B_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值B单位", Order = 13)]
			public object DISPLAY_VALUE_B_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值C", Order = 14)]
			public object DISPLAY_C_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值C单位", Order = 15)]
			public object DISPLAY_VALUE_C_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "不确定度", Order = 16)]
			public object UNCERTAINTY_DEGREE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 17)]
			public object PREPARE_SCHEMEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "交采头", Order = 18)]
			public object CROSS_HEADID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 19)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 20)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 21)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 22)]
			public object UPDATEPERSON { get; set; }


    }
}
 

