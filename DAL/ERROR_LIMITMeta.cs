using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(ERROR_LIMITMetadata))]//使用ERROR_LIMITMetadata对ERROR_LIMIT进行数据验证
    public partial class ERROR_LIMIT 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class ERROR_LIMITMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "器具准确度等级", Order = 2)]
			public object ACCURACY_GRADE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "误差限值", Order = 3)]
			public object LIMIT_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "类别", Order = 4)]
			public object CATEGORY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 5)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 6)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 7)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 8)]
			public object UPDATEPERSON { get; set; }


    }
}
 

