using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(THREE_PHASE_UNCERTAINTYMetadata))]//使用THREE_PHASE_UNCERTAINTYMetadata对THREE_PHASE_UNCERTAINTY进行数据验证
    public partial class THREE_PHASE_UNCERTAINTY 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "规程表检定项目")]
        public string RULEIDOld { get; set; }
        
        #endregion

    }
    public partial class THREE_PHASE_UNCERTAINTYMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "读取小数位数", Order = 2)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? DIGIT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "U1", Order = 3)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? DEGREE1 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "U2", Order = 4)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? DEGREE2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "U3", Order = 5)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? DEGREE3 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "规程表检定项目", Order = 6)]
			public object RULEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 7)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 8)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 9)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 10)]
			public object UPDATEPERSON { get; set; }


    }
}
 

