using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(UNCERTAINTY2_HZMetadata))]//使用UNCERTAINTY2_HZMetadata对UNCERTAINTY2_HZ进行数据验证
    public partial class UNCERTAINTY2_HZ 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "规程检定项目")]
        public string RULEIDOld { get; set; }
        
        #endregion

    }
    public partial class UNCERTAINTY2_HZMetadata
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
			[Display(Name = "频率min", Order = 4)]
			public object MIN_FREQUENCY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "频率min单位", Order = 5)]
			public object MIN_FREQUENCY_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "频率max", Order = 6)]
			public object MAX_FREQUENCY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "频率max单位", Order = 7)]
			public object MAX_FREQUENCY_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "指标1", Order = 8)]
			public object INDEX1 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "指标1单位", Order = 9)]
			public object INDEX1_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "指标2", Order = 10)]
			public object INDEX2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "指标2单位", Order = 11)]
			public object INDEX2_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "规程检定项目", Order = 12)]
			public object RULEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 13)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 14)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 15)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 16)]
			public object UPDATEPERSON { get; set; }


    }
}
 

