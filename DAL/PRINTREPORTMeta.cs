using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(PRINTREPORTMetadata))]//使用PRINTREPORTMetadata对PRINTREPORT进行数据验证
    public partial class PRINTREPORT 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "预备方案")]
        public string PREPARE_SCHEMEIDOld { get; set; }
        
        #endregion

    }
    public partial class PRINTREPORTMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "次数", Order = 2)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? GETNUMBER { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "打印时间", Order = 3)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "打印者", Order = 4)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 5)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 6)]
			public object UPDATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 7)]
			public object PREPARE_SCHEMEID { get; set; }


    }
}
 

