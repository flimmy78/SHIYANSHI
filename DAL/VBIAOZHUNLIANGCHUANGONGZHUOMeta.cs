using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VBIAOZHUNLIANGCHUANGONGZHUOMetadata))]
    public partial class VBIAOZHUNLIANGCHUANGONGZHUO : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class VBIAOZHUNLIANGCHUANGONGZHUOMetadata
    {
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[Display(Name = "委托单号", Order = 2)]
			public object WEITUODANWEI { get; set; }

			[Display(Name = "所属单位", Order = 3)]
			public object SUOSHUDANWEI { get; set; }

			[Display(Name = "证书单位", Order = 4)]
			public object ZHENGSHUDANWEI { get; set; }

			[Display(Name = "送检单位", Order = 5)]
			public object SONGJIANDANWEI { get; set; }

			[Display(Name = "受理单位", Order = 6)]
			public object SHOULIDANWEI { get; set; }

			[Display(Name = "出厂日期", Order = 7)]
			public object CHUCHANGRIQI { get; set; }

			[Display(Name = "器具名称", Order = 8)]
			public object QIJUMINGCHENG { get; set; }

			[Display(Name = "生产厂家", Order = 9)]
			public object SHENGCHANCHANGJIA { get; set; }

			[Display(Name = "器具型号", Order = 10)]
			public object QIJUXINGHAO { get; set; }

			[Display(Name = "器具规格", Order = 11)]
			public object QIJUGUIGE { get; set; }

			[Display(Name = "出厂编号", Order = 12)]
			public object CHUCHANGBIANHAO { get; set; }

			[Display(Name = "数量", Order = 13)]
			public object SHULIANG { get; set; }

			[Display(Name = "送检日期", Order = 14)]
			public object SONGJIANRIQI { get; set; }

			[Display(Name = "送检人", Order = 15)]
			public object SONGJIANREN { get; set; }

			[Display(Name = "接收人", Order = 16)]
			public object JIESHOUREN { get; set; }

			[Display(Name = "实验室", Order = 17)]
			public object SHIYANSHI { get; set; }

			[Display(Name = "实验室接收时间", Order = 18)]
			public object SHIYANSHIJIESHOUSHIJIAN { get; set; }

			[Display(Name = "检定日期", Order = 19)]
			public object JIANDINGRIQI { get; set; }

			[Display(Name = "检定/校准员", Order = 20)]
			public object JIANDINGXIAOZHUNYUAN { get; set; }

			[Display(Name = "核验员", Order = 21)]
			public object HEYANYUAN { get; set; }

			[Display(Name = "证书号类别", Order = 22)]
			public object ZHENGSHUHAOLEIBIE { get; set; }

			[Display(Name = "证书/报告编号", Order = 23)]
			public object ZHENGSHUBAOGAOBIANHAO { get; set; }

			[Display(Name = "证书类别", Order = 24)]
			public object ZHENGSHULEIBIE { get; set; }

			[Display(Name = "报告类别", Order = 25)]
			public object BAOGAOLEIBIE { get; set; }

			[Display(Name = "授权/资质", Order = 26)]
			public object SHOUQUANZIZHI { get; set; }

			[Display(Name = "器具状态", Order = 27)]
			public object QIJUZHUANGTAI { get; set; }

			[Display(Name = "有效期至", Order = 28)]
			public object YOUXIAOQIZHI { get; set; }

			[Display(Name = "报告审批通过日期", Order = 29)]
			public object BAOGAOSHENPITONGGUORIQI { get; set; }

			[Display(Name = "报告状态", Order = 30)]
			public object MOCHONGCHANGSHU { get; set; }

			[Display(Name = "送检月度", Order = 31)]
			public object SONGJIANYUEDU { get; set; }

			[Display(Name = "检定时间", Order = 32)]
			public object JIANDINGSHIJIAN { get; set; }

			[Display(Name = "检定月度", Order = 33)]
			public object JIANDINGYUEDU { get; set; }

			[Display(Name = "报告时间", Order = 34)]
			public object BAOGAOSHIJIAN { get; set; }

			[Display(Name = "报告月度", Order = 35)]
			public object BAOGAOYUEDU { get; set; }

			[Display(Name = "工作时间", Order = 36)]
			public object GONHZUOSHIJIAN { get; set; }

			[Display(Name = "总时间", Order = 37)]
			public object ZONGSHIJIAN { get; set; }

			[Display(Name = "备注", Order = 38)]
			public object BEIZHU { get; set; }

        [Display(Name = "条形码", Order = 39)]
        public object TIAOXINGMA { get; set; }
    }


}

