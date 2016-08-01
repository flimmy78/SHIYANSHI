using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(COMPANYMetadata))]//使用COMPANYMetadata对COMPANY进行数据验证
    public partial class COMPANY 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "上级单位")]
        public string PARENTIDOld { get; set; }
        
        #endregion

    }
    public partial class COMPANYMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "单位名称", Order = 2)]
			public object COMPANYNAME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "单位地址", Order = 3)]
			public object COMPANYADDRES { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "邮政编码", Order = 4)]
			public object POSTCODE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "联系人", Order = 5)]
			public object CONTACTS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "联系电话", Order = 6)]
			public object CONTACTSNUMBER { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "传真", Order = 7)]
			public object FAX { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "上级单位", Order = 8)]
			public object PARENTID { get; set; }

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
 

