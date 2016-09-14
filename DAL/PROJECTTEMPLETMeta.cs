using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(PROJECTTEMPLETMetadata))]//使用PROJECTTEMPLETMetadata对PROJECTTEMPLET进行数据验证
    public partial class PROJECTTEMPLET 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "规程")]
        public string RULEIDOld { get; set; }
        
        [Display(Name = "方案")]
        public string SCHEMEIDOld { get; set; }
        
        #endregion

    }
    public partial class PROJECTTEMPLETMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "规程", Order = 2)]
			public object RULEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "方案", Order = 3)]
			public object SCHEMEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "HTMLVALUE", Order = 4)]
			public object HTMLVALUE { get; set; }

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
 

