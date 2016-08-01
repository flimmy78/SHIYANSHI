using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(APPLIANCECOLLECTIONMetadata))]//使用APPLIANCECOLLECTIONMetadata对APPLIANCECOLLECTION进行数据验证
    public partial class APPLIANCECOLLECTION 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "器具明细")]
        public string APPLIANCE_DETAIL_INFORMATIONIDOld { get; set; }
        
        #endregion

    }
    public partial class APPLIANCECOLLECTIONMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "次数", Order = 2)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? GETNUMBER { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "领取时间", Order = 3)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "领取者", Order = 4)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 5)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 6)]
			public object UPDATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "器具明细", Order = 7)]
			public object APPLIANCE_DETAIL_INFORMATIONID { get; set; }


    }
}
 

