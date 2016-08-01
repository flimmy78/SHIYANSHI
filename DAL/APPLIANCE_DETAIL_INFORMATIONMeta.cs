using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(APPLIANCE_DETAIL_INFORMATIONMetadata))]//使用APPLIANCE_DETAIL_INFORMATIONMetadata对APPLIANCE_DETAIL_INFORMATION进行数据验证
    public partial class APPLIANCE_DETAIL_INFORMATION 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "委托单")]
        public string ORDER_TASK_INFORMATIONIDOld { get; set; }
        
        #endregion

    }
    public partial class APPLIANCE_DETAIL_INFORMATIONMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "条形码", Order = 2)]
			public object BAR_CODE_NUM { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "器具名称", Order = 3)]
			public object APPLIANCE_NAME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "型号", Order = 4)]
			public object MODEL { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "规格", Order = 5)]
			public object FORMAT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "出厂编号", Order = 6)]
			public object FACTORY_NUM { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "数量", Order = 7)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? NUM { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "附件", Order = 8)]
			public object ATTACHMENT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "外观状态", Order = 9)]
			public object APPEARANCE_STATUS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "制造单位", Order = 10)]
			public object MAKE_ORGANIZATION { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "备注", Order = 11)]
			public object REMARKS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "要求截止时间", Order = 12)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? END_PLAN_DATE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "委托单", Order = 13)]
			public object ORDER_TASK_INFORMATIONID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 14)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 15)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 16)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 17)]
			public object UPDATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "器具接收", Order = 18)]
			public object APPLIANCE_RECIVE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "器具进度", Order = 19)]
			public object APPLIANCE_PROGRESS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 20)]
			public object ORDER_STATUS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "是否超期", Order = 21)]
			public object ISOVERDUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "超期原因", Order = 22)]
			public object OVERDUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "入库说明", Order = 23)]
			public object STORAGEINSTRUCTIONS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "入库状态", Order = 24)]
			public object STORAGEINSTRUCTI_STATU { get; set; }


    }
}
 

