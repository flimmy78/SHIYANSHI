using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VZHENGSHULEIBEITONGJIFENXIMetadata))]
    public partial class VZHENGSHULEIBEITONGJIFENXI : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class VZHENGSHULEIBEITONGJIFENXIMetadata
    {
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[Display(Name = "所属单位", Order = 2)]
			public object SUOSHUDANWEI { get; set; }

			[Display(Name = "证书单位", Order = 3)]
			public object ZHENGSHUDANWEI { get; set; }

			[Display(Name = "受理单位", Order = 4)]
			public object SHOULIDANWEI { get; set; }

			[Display(Name = "批准结论", Order = 5)]
			public object PIZHUNJIELUN { get; set; }

			[Display(Name = "批准时间", Order = 6)]
			public object PIZHUNSHIJIAN { get; set; }

			[Display(Name = "授权/资质", Order = 7)]
			public object SHOUQUANZIZHI { get; set; }

			[Display(Name = "证书/报告类别", Order = 9)]
			public object ZHEGNSHUBAOGAOLEIBIE { get; set; }

			[Display(Name = "报告数量", Order = 10)]
			public object BAOGAOSHULIANG { get; set; }


    }


}

