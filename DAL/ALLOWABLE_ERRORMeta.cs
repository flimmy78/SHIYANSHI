using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(ALLOWABLE_ERRORMetadata))]//使用ALLOWABLE_ERRORMetadata对ALLOWABLE_ERROR进行数据验证
    public partial class ALLOWABLE_ERROR 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "计量标准")]
        public string METERING_STANDARD_DEVICEIDOld { get; set; }
        
        #endregion

    }
    public partial class ALLOWABLE_ERRORMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "值", Order = 2)]
			public object VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "单位", Order = 3)]
			public object UNIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "计量标准", Order = 4)]
			public object METERING_STANDARD_DEVICEID { get; set; }

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
 

