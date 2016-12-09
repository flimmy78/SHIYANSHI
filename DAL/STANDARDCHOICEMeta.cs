using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(STANDARDCHOICEMetadata))]//使用STANDARDCHOICEMetadata对STANDARDCHOICE进行数据验证
    public partial class STANDARDCHOICE 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "预备方案")]
        public string PREPARE_SCHEMEIDOld { get; set; }
        
        #endregion

    }
    public partial class STANDARDCHOICEMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "组别", Order = 2)]
			public object GROUPS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "类型", Order = 3)]
			public object TYPE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 4)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建者", Order = 5)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 6)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 7)]
			public object UPDATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 8)]
			public object PREPARE_SCHEMEID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "标准装置/计量标准器信息", Order = 9)]
        public object METERING_STANDARD_DEVICEID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "显示值", Order = 10)]
        public object NAMES { get; set; }
    }
}
 

