using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(TRANSMITTER_HEADMetadata))]//使用TRANSMITTER_HEADMetadata对TRANSMITTER_HEAD进行数据验证
    public partial class TRANSMITTER_HEAD 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class TRANSMITTER_HEADMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "类型", Order = 2)]
			public object 类型 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输入开始", Order = 3)]
			public object 变送器输入开始 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输入开始单位", Order = 4)]
			public object 变送器输入开始单位 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输入结束", Order = 5)]
			public object 变送器输入结束 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "变送器输入结束单位", Order = 6)]
			public object 变送器输入结束单位 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "通道", Order = 7)]
			public object 通道 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "Un", Order = 8)]
			public object Un { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "Un单位", Order = 9)]
			public object Un单位 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "In", Order = 10)]
			public object In { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "In单位", Order = 11)]
			public object In单位 { get; set; }

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
 

