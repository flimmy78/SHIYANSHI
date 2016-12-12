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
			[Display(Name = "准确度等级", Order = 2)]
			public object THEACCURACYLEVEL { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "不确定度K值", Order = 3)]
			public object THEUNCERTAINTYVALUEK { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "不确定度指数值", Order = 4)]
			public object THEUNCERTAINTYNDEXL { get; set; }

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

        [ScaffoldColumn(true)]
        [Display(Name = "不确定度数值", Order = 9)]
        public object THEUNCERTAINTYVALUE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "不确定度", Order = 10)]
        public object THEUNCERTAINTY { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "最大允许误差数值", Order = 11)]
        public object MAXVALUE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "最大允许误差类别", Order = 12)]
        public object MAXCATEGORIES { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "计量标准器id", Order = 13)]
        public object METERING_STANDARD_DEVICEID { get; set; }
        
        [ScaffoldColumn(true)]
        [Display(Name = "组别", Order = 14)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? GROUPS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "类别", Order = 15)]
        public object CATEGORY { get; set; }
    }
}
 

