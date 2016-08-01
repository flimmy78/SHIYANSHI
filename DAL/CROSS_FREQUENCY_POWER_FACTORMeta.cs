using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(CROSS_FREQUENCY_POWER_FACTORMetadata))]//使用CROSS_FREQUENCY_POWER_FACTORMetadata对CROSS_FREQUENCY_POWER_FACTOR进行数据验证
    public partial class CROSS_FREQUENCY_POWER_FACTOR 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "交采头")]
        public string CROSS_HEADIDOld { get; set; }
        
        #endregion

    }
    public partial class CROSS_FREQUENCY_POWER_FACTORMetadata
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
			[Display(Name = "标准值", Order = 4)]
			public object STANDARD_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准值单位", Order = 5)]
			public object STANDARD_VALUE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值", Order = 6)]
			public object DISPLAY_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "显示值单位", Order = 7)]
			public object DISPLAY_VALUE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "不确定度", Order = 8)]
			public object UNCERTAINTY_DEGREE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "交采头", Order = 9)]
			public object CROSS_HEADID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 10)]
			public object PREPARE_SCHEMEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 11)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 12)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 13)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 14)]
			public object UPDATEPERSON { get; set; }


    }
}
 

