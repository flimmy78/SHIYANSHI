using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VBUHEGEMetadata))]
    public partial class VBUHEGE : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class VBUHEGEMetadata
    {
			[Display(Name = "ID", Order = 1)]
			public object ID { get; set; }

			[Display(Name = "证书报告编号", Order = 2)]
			public object ZHENGSHUBAOGAOBIANHAO { get; set; }

			[Display(Name = "不合格分类", Order = 3)]
			public object BUHEGEFENLEI { get; set; }

			[Display(Name = "不合格说明", Order = 4)]
			public object BUHEGESHUOMING { get; set; }

			[Display(Name = "实验室", Order = 5)]
			public object SHIYANSHI { get; set; }

			[Display(Name = "报告证书批准通过时间", Order = 6)]
			public object BAOGAOPIZHUNTONGGUOSHIJIAN { get; set; }

			[Display(Name = "受理单位", Order = 7)]
			public object SHOULIDANWEI { get; set; }


    }


}

