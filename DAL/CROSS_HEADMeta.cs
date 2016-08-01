using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(CROSS_HEADMetadata))]//使用CROSS_HEADMetadata对CROSS_HEAD进行数据验证
    public partial class CROSS_HEAD 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class CROSS_HEADMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "类型", Order = 2)]
			public object TYPE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "数值", Order = 3)]
			public object VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "数值单位", Order = 4)]
			public object VALUE_UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "等级值", Order = 5)]
			public object GRADE_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 6)]
			public object PREPARE_SCHEMEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 7)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 8)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 9)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 10)]
			public object UPDATEPERSON { get; set; }


    }
}
 

