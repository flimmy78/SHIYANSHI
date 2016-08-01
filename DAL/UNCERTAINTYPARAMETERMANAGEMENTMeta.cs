using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(UNCERTAINTYPARAMETERMANAGEMENTMetadata))]//使用UNCERTAINTYPARAMETERMANAGEMENTMetadata对UNCERTAINTYPARAMETERMANAGEMENT进行数据验证
    public partial class UNCERTAINTYPARAMETERMANAGEMENT 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "规程")]
        public string RULEIDOld { get; set; }
        
        #endregion

    }
    public partial class UNCERTAINTYPARAMETERMANAGEMENTMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "误差来源", Order = 2)]
			public object SOURCEOFERROR { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "误差限值", Order = 3)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? LIMIT_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "误差分布状况", Order = 4)]
			public object ERRORDISTRIBUTION { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "k", Order = 5)]
			public object k { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "不确定度", Order = 6)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? UNCERTAINTYDEGREE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 7)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 8)]
			public object UPDATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 9)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 10)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "规程", Order = 11)]
			public object RULEID { get; set; }


    }
}
 

