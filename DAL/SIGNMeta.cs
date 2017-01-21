using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(SIGNMetadata))]//使用SIGNMetadata对SIGN进行数据验证
    public partial class SIGN 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "委托单ID")]
        public string ORDER_TASK_INFORMATIONIDOld { get; set; }
        
        #endregion

    }
    public partial class SIGNMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "图片", Order = 2)]
			public object PICTURE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "委托单ID", Order = 3)]
			public object ORDER_TASK_INFORMATIONID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "HTMLVALUE", Order = 4)]
			public object HTMLVALUE { get; set; }

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
 

