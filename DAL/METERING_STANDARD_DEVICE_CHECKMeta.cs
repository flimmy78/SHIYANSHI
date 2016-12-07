using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(METERING_STANDARD_DEVICE_CHECKMetadata))]//使用METERING_STANDARD_DEVICE_CHECKMetadata对METERING_STANDARD_DEVICE_CHECK进行数据验证
    public partial class METERING_STANDARD_DEVICE_CHECK 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "标准装置/计量标准器信息")]
        public string METERING_STANDARD_DEVICEIDOld { get; set; }
        
        #endregion

    }
    public partial class METERING_STANDARD_DEVICE_CHECKMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "证书编号", Order = 2)]
			public object CERTIFICATE_NUM { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "检定日期/校准日期", Order = 3)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? CHECK_DATE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "有效期至", Order = 4)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? VALID_TO { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "标准装置/计量标准器信息", Order = 5)]
			public object METERING_STANDARD_DEVICEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 6)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 7)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 8)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 9)]
			public object UPDATEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "证书发放单位", Order = 10)]
        public object CERTIFICATEUNIT { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "组别", Order = 11)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? GROUPS { get; set; }
    }
}
 

