using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VSHIYANSHIGONGZUOLIANGMetadata))]
    public partial class VSHIYANSHIGONGZUOLIANG : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class VSHIYANSHIGONGZUOLIANGMetadata
    {
			[Display(Name = "实验室", Order = 1)]
			public object ID { get; set; }

			[Display(Name = "委托数量", Order = 2)]
			public object WEITUODAN { get; set; }

			[Display(Name = "检定完成数量", Order = 3)]
			public object JIANDINGWANCHENG { get; set; }

			[Display(Name = "设备故障数量", Order = 4)]
			public object SHEBEIGUZHANG { get; set; }

			[Display(Name = "批准通过数量", Order = 5)]
			public object PIZHUNTONGGUO { get; set; }

			[Display(Name = "合格报告数量", Order = 6)]
			public object HEGE { get; set; }

			[Display(Name = "不合格报告数量", Order = 7)]
			public object BUHEGE { get; set; }

			[Display(Name = "超期数量", Order = 8)]
			public object CHAOQI { get; set; }


    }


}

