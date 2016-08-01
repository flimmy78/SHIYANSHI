using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(SCHEMEMetadata))]//使用SCHEMEMetadata对SCHEME进行数据验证
    public partial class SCHEME 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "承接实验室")]
        public string UNDERTAKE_LABORATORYIDOld { get; set; }
        
        #endregion

    }
    public partial class SCHEMEMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "方案名称", Order = 2)]
			public object NAME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "报告类别", Order = 3)]
			public object REPORT_CATEGORY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "证书类别", Order = 4)]
			public object CERTIFICATE_CATEGORY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 5)]
			public object STATUS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "是否发布", Order = 6)]
			public object ISPUBLISH { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "复制方案", Order = 7)]
			public object COPYID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "承接实验室", Order = 8)]
			public object UNDERTAKE_LABORATORYID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 9)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 10)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 11)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 12)]
			public object UPDATEPERSON { get; set; }


    }
}
 

