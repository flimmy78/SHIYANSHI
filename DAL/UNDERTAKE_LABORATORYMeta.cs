using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(UNDERTAKE_LABORATORYMetadata))]//使用UNDERTAKE_LABORATORYMetadata对UNDERTAKE_LABORATORY进行数据验证
    public partial class UNDERTAKE_LABORATORY 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class UNDERTAKE_LABORATORYMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "承接实验室名称", Order = 2)]
			public object NAME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 3)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 4)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 5)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 6)]
			public object UPDATEPERSON { get; set; }


    }
}
 

