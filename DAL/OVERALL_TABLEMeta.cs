using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(OVERALL_TABLEMetadata))]//使用OVERALL_TABLEMetadata对OVERALL_TABLE进行数据验证
    public partial class OVERALL_TABLE 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class OVERALL_TABLEMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "名称", Order = 2)]
			public object NAME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "结论", Order = 3)]
			public object CONCLUSION { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 4)]
			public object PREPARE_SCHEMEID { get; set; }

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
 

