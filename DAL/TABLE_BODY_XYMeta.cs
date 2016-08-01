using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(TABLE_BODY_XYMetadata))]//使用TABLE_BODY_XYMetadata对TABLE_BODY_XY进行数据验证
    public partial class TABLE_BODY_XY 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "检测项格式")]
        public string TEST_ITEM_FORMATIDOld { get; set; }
        
        #endregion

    }
    public partial class TABLE_BODY_XYMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "X", Order = 2)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? X { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "Y", Order = 3)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? Y { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "类型", Order = 4)]
			public object CATEGORY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "默认值", Order = 5)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? DEFAULT_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "合并Y值", Order = 6)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? MERGE_Y { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "检测项格式", Order = 7)]
			public object TEST_ITEM_FORMATID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 8)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 9)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 10)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 11)]
			public object UPDATEPERSON { get; set; }


    }
}
 

