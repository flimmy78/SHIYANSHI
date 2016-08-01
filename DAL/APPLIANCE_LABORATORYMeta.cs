using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(APPLIANCE_LABORATORYMetadata))]//使用APPLIANCE_LABORATORYMetadata对APPLIANCE_LABORATORY进行数据验证
    public partial class APPLIANCE_LABORATORY 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "承接实验室")]
        public string UNDERTAKE_LABORATORYIDOld { get; set; }
        
        [Display(Name = "器具明细信息")]
        public string APPLIANCE_DETAIL_INFORMATIOIDOld { get; set; }
        
        [Display(Name = "预备方案")]
        public string PREPARE_SCHEMEIDOld { get; set; }
        
        #endregion

    }
    public partial class APPLIANCE_LABORATORYMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "承接实验室", Order = 2)]
			public object UNDERTAKE_LABORATORYID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "器具明细信息", Order = 3)]
			public object APPLIANCE_DETAIL_INFORMATIOID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "预备方案", Order = 4)]
			public object PREPARE_SCHEMEID { get; set; }


    }
}
 

