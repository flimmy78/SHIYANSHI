using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VZHENGSHUXINXICHAXUNMetadata))]
    public partial class VZHENGSHUXINXICHAXUN : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class VZHENGSHUXINXICHAXUNMetadata
    {
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[Display(Name = "送检单位", Order = 2)]
			public object SONGJIANDANWEI { get; set; }

			[Display(Name = "证书单位", Order = 3)]
			public object ZHENGSHUDANWEI { get; set; }

			[Display(Name = "受理单位", Order = 4)]
			public object SHOULIDANWEI { get; set; }

			[Display(Name = "出厂日期", Order = 5)]
			public object CHUCHANGRIQI { get; set; }

			[Display(Name = "器具名称", Order = 6)]
			public object QIJUMINGCHENG { get; set; }

			[Display(Name = "生产厂家", Order = 7)]
			public object SHENGCHANCHANGJIA { get; set; }

			[Display(Name = "器具型号", Order = 8)]
			public object QIJUXINGHAO { get; set; }

			[Display(Name = "出厂编号", Order = 9)]
			public object CHUCHANGBIANHAO { get; set; }

			[Display(Name = "准确度等级", Order = 10)]
			public object ZHUNQUEDUDENGJI { get; set; }

			[Display(Name = "检定日期", Order = 11)]
			public object JIANDINGRIQI { get; set; }

			[Display(Name = "温度（℃）", Order = 12)]
			public object WENDU { get; set; }

			[Display(Name = "相对湿度（%）", Order = 13)]
			public object XIANGDUISHIDU { get; set; }

			[Display(Name = "脉冲常数(imp/kWh)", Order = 14)]
			public object MOCHONGCHANGSHU { get; set; }

			[Display(Name = "器具规格", Order = 15)]
			public object QIJUGUIGE { get; set; }

			[Display(Name = "检定/校准员", Order = 16)]
			public object JIANDINGXIAOZHUNYUAN { get; set; }

			[Display(Name = "核验员", Order = 17)]
			public object HEYANYUAN { get; set; }

			[Display(Name = "有效期（年）", Order = 18)]
			public object YOUXIAOQI { get; set; }

			[Display(Name = "有效期至", Order = 19)]
			public object YOUXIAOQIZHI { get; set; }

			[Display(Name = "证书/报告编号", Order = 20)]
			public object ZHENGSHUBAOGAOBIANHAO { get; set; }

			[Display(Name = "证书类别", Order = 21)]
			public object ZHENGSHULEIBIE { get; set; }

			[Display(Name = "报告类别", Order = 22)]
			public object BAOGAOLEIBIE { get; set; }

			[Display(Name = "授权/资质", Order = 23)]
			public object SHOUQUANZIZHI { get; set; }

			[Display(Name = "发放状态", Order = 24)]
			public object FAFANGZHUANGTAI { get; set; }

			[Display(Name = "所属单位", Order = 25)]
			public object SUOSHUDANWEI { get; set; }

			[Display(Name = "委托单号", Order = 26)]
			public object WEITUODANWEI { get; set; }

			[Display(Name = "备注", Order = 27)]
			public object BEIZHU { get; set; }


    }


}

