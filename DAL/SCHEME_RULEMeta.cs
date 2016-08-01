using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(SCHEME_RULEMetadata))]//使用SCHEME_RULEMetadata对SCHEME_RULE进行数据验证
    public partial class SCHEME_RULE 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "规程")]
        public string RULEIDOld { get; set; }
        
        [Display(Name = "方案")]
        public string SCHEMEIDOld { get; set; }
        
        [Display(Name = "检测项格式")]
        public string TEST_ITEM_FORMATIDOld { get; set; }
        
        #endregion

    }
    public partial class SCHEME_RULEMetadata
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
			[Display(Name = "检测项格式", Order = 4)]
			public object TEST_ITEM_FORMATID { get; set; }


    }
}
 

