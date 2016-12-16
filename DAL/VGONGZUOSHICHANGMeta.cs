using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VGONGZUOSHICHANGMetadata))]
    public partial class VGONGZUOSHICHANG : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class VGONGZUOSHICHANGMetadata
    {
			[Display(Name = "ID", Order = 1)]
			public object ID { get; set; }

			[Display(Name = "委托单号", Order = 2)]
			public object WEITUODANWEI { get; set; }

			[Display(Name = "所属单位", Order = 3)]
			public object SUOSHUDANWEI { get; set; }

			[Display(Name = "证书单位", Order = 4)]
			public object ZHENGSHUDANWEI { get; set; }

			[Display(Name = "受理单位", Order = 5)]
			public object SHOULIDANWEI { get; set; }

			[Display(Name = "器具名称", Order = 6)]
			public object QIJUMINGCHENG { get; set; }

			[Display(Name = "生产厂家", Order = 7)]
			public object SHENGCHANCHANGJIA { get; set; }

			[Display(Name = "器具型号", Order = 8)]
			public object QIJUXINGHAO { get; set; }

			[Display(Name = "器具规格", Order = 9)]
			public object QIJUGUIGE { get; set; }

			[Display(Name = "出厂编号", Order = 10)]
			public object CHUCHANGBIANHAO { get; set; }

			[Display(Name = "数量", Order = 11)]
			public object SHULIANG { get; set; }

			[Display(Name = "证书/报告编号", Order = 12)]
			public object ZHENGSHUBAOGAOBIANHAO { get; set; }

			[Display(Name = "实验室", Order = 13)]
			public object SHIYANSHI { get; set; }

			[Display(Name = "检定/校准员", Order = 14)]
			public object JIANDINGXIAOZHUNYUAN { get; set; }

			[Display(Name = "核验员", Order = 15)]
			public object HEYANYUAN { get; set; }

			[Display(Name = "委托日期", Order = 16)]
			public object WEITUORIQI { get; set; }

			[Display(Name = "实验室接收时间", Order = 17)]
			public object SHIYANSHIJIESHOUSHIJIAN { get; set; }

			[Display(Name = "检定完成日期", Order = 18)]
			public object JIANDINGWANCHENGRIQI { get; set; }

			[Display(Name = "审核日期", Order = 19)]
			public object SHENHERIQI { get; set; }

			[Display(Name = "批准日期", Order = 20)]
			public object PIZHUNRIQI { get; set; }

			[Display(Name = "待领取时长", Order = 21)]
			public object DAILINGQUSHICHANG { get; set; }

			[Display(Name = "检定时长", Order = 22)]
			public object JIANDINGSHICHANG { get; set; }

			[Display(Name = "审核时长", Order = 23)]
			public object SHENHESHICHANG { get; set; }

			[Display(Name = "批准时长", Order = 24)]
			public object PIZHUNSHICHANG { get; set; }

			[Display(Name = "总时长", Order = 25)]
			public object ZONGSHICHANG { get; set; }

			[Display(Name = "备注", Order = 26)]
			public object BEIZHU { get; set; }


    }


}

