using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(FILE_UPLOADERMetadata))]//使用FILE_UPLOADERMetadata对FILE_UPLOADER进行数据验证
    public partial class FILE_UPLOADER 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "预备方案")]
        public string PREPARE_SCHEMEIDOld { get; set; }
        
        #endregion

    }
    public partial class FILE_UPLOADERMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "名称", Order = 2)]
			public object NAME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "路径", Order = 3)]
			public object PATH { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "全路径", Order = 4)]
			public object FULLPATH { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "后缀", Order = 5)]
			public object SUFFIX { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "大小", Order = 6)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? SIZE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "备注", Order = 7)]
			public object REMARK { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录名称2", Order = 8)]
			public object NAME2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录路径2", Order = 9)]
			public object PATH2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录全路径2", Order = 10)]
			public object FULLPATH2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录后缀2", Order = 11)]
			public object SUFFIX2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录大小2", Order = 12)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? SIZE2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录备注2", Order = 13)]
			public object REMARK2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "原始记录状态2", Order = 14)]
			public object STATE2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 15)]
			public object STATE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 16)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 17)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "结论", Order = 18)]
			public object CONCLUSION { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 19)]
			public object PREPARE_SCHEMEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 20)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 21)]
			public object UPDATEPERSON { get; set; }


    }
}
 

