using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VTEST_ITEMetadata))]
    public partial class VTEST_ITE : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    /// <summary>
    /// 预备方案检测项信息
    /// </summary>
    public class VTEST_ITEMetadata
    {
			[Display(Name = "预备方案ID", Order = 1)]
			public object PREPARE_SCHEMEID { get; set; }

			[Display(Name = "方案ID", Order = 2)]
			public object SCHEMEID { get; set; }

			[Display(Name = "检测项目ID", Order = 3)]
			public object RULEID { get; set; }

			[Display(Name = "录入格式", Order = 4)]
			public object INPUTSTATE { get; set; }

			[Display(Name = "别名", Order = 5)]
			public object NAMEOTHER { get; set; }

			[Display(Name = "名称", Order = 6)]
			public object NAME { get; set; }

			[Display(Name = "方案菜单", Order = 7)]
			public object SCHEME_MENU { get; set; }

			[Display(Name = "预备方案检测项目ID", Order = 8)]
			public object ID { get; set; }

			[Display(Name = "结论", Order = 9)]
			public object CONCLUSION { get; set; }

			[Display(Name = "HTMLVALUE", Order = 10)]
			public object HTMLVALUE { get; set; }

			[Display(Name = "注释", Order = 11)]
			public object REMARK { get; set; }

			[Display(Name = "是否完成", Order = 12)]
			public object ISCOMPLETE { get; set; }

            [Display(Name = "方案规程ID", Order = 13)]
            public object SCHEME_RULEID { get; set; }

            [Display(Name = "主键标识", Order = 14)]
            public object row_flag { get; set; }

            [ScaffoldColumn(true)]
            [Display(Name = "排序", Order = 15)]
            public object SORT { get; set; }

            [ScaffoldColumn(true)]
            [Display(Name = "检测项父类ID", Order = 15)]
            public object PARENTID { get; set; }
    }
}

