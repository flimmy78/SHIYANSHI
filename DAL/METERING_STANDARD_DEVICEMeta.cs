using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(METERING_STANDARD_DEVICEMetadata))]//使用METERING_STANDARD_DEVICEMetadata对METERING_STANDARD_DEVICE进行数据验证
    public partial class METERING_STANDARD_DEVICE 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "承接实验室")]
        public string UNDERTAKE_LABORATORYIDOld { get; set; }
        
        [Display(Name = "预备方案")]
        public string PREPARE_SCHEMEID { get; set; }
        [Display(Name = "预备方案")]
        public string PREPARE_SCHEMEIDOld { get; set; }
        
        #endregion

    }
    public partial class METERING_STANDARD_DEVICEMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "计量标准名称", Order = 2)]
			public object NAME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "测量范围", Order = 3)]
			public object TEST_RANGE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "出厂编号", Order = 4)]
			public object FACTORY_NUM { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "类别", Order = 5)]
			public object CATEGORY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 6)]
			public object STATUS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "承接实验室", Order = 7)]
			public object UNDERTAKE_LABORATORYID { get; set; }

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
 

