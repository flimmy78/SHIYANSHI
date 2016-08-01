using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(TRANSMITTER_POWER_FACTORMetadata))]//使用TRANSMITTER_POWER_FACTORMetadata对TRANSMITTER_POWER_FACTOR进行数据验证
    public partial class TRANSMITTER_POWER_FACTOR 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "变送器头")]
        public string TRANSMITTER_HEADIDOld { get; set; }
        
        #endregion

    }
    public partial class TRANSMITTER_POWER_FACTORMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "测试量", Order = 2)]
			public object TEST_QUANTITY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "等级", Order = 3)]
			public object GRADE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "测试点", Order = 4)]
			public object TEST_POINT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "测试点单位", Order = 5)]
			public object TEST_POINT_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "U", Order = 6)]
			public object U { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "U单位", Order = 7)]
			public object U_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "A", Order = 8)]
			public object A { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "A单位", Order = 9)]
			public object A_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "二次输入标准值", Order = 10)]
			public object TWO_INPUT_STANDARD_VALUES { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "二次输入标准值单位", Order = 11)]
			public object TWO_INPUT_STANDARD_VALUES_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准输出值", Order = 12)]
			public object STANDARD_OUTPUT_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准输出值单位", Order = 13)]
			public object STANDARD_OUTPUT_VALUE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "实际输出值", Order = 14)]
			public object ACTUAL_OUTPUT_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "实际输出值单位", Order = 15)]
			public object ACTUAL_OUTPUT_VALUE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "引用误差", Order = 16)]
			public object REFERENCE_ERROR { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "引用误差单位", Order = 17)]
			public object REFERENCE_ERROR_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器头", Order = 18)]
			public object TRANSMITTER_HEADID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 19)]
			public object PREPARE_SCHEMEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 20)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 21)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 22)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 23)]
			public object UPDATEPERSON { get; set; }


    }
}
 

