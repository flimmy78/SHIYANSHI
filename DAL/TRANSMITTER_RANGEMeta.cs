using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(TRANSMITTER_RANGEMetadata))]//使用TRANSMITTER_RANGEMetadata对TRANSMITTER_RANGE进行数据验证
    public partial class TRANSMITTER_RANGE 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class TRANSMITTER_RANGEMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "测试量", Order = 2)]
			public object TEST_QUANTITY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输入开始", Order = 3)]
			public object INPUT_START { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输入开始单位", Order = 4)]
			public object INPUT_START_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输入结束", Order = 5)]
			public object INPUT_END { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输入结束单位", Order = 6)]
			public object INPUT_END_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输出开始", Order = 7)]
			public object OUTPUT_START { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输出开始单位", Order = 8)]
			public object OUTPUT_START_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输出结束", Order = 9)]
			public object OUTPUT_END { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输出结束单位", Order = 10)]
			public object OUTPUT_END_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "顺序", Order = 11)]
			public object SORT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 12)]
			public object PREPARE_SCHEMEID { get; set; }

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
 

