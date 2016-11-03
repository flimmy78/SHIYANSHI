using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VXIANGQINGMetadata))]
    public partial class VXIANGQING : IBaseEntity
    {
        
        #region 自定义属性

        #endregion

    }
    public class VXIANGQINGMetadata
    {
			[Display(Name = "排序", Order = 1)]
			public object ID { get; set; }

			[Display(Name = "器具明细ID", Order = 2)]
			public object DD { get; set; }

			[Display(Name = "委托单ID", Order = 3)]
			public object ORDER_TASK_INFORMATIONID { get; set; }

			[Display(Name = "器具名称", Order = 4)]
			public object APPLIANCE_NAME { get; set; }

			//[Display(Name = "报告编号", Order = 5)]
			//public object REPORTNUMBER { get; set; }

			[Display(Name = "器具领取状态", Order = 6)]
			public object STATE { get; set; }

			[Display(Name = "器具领取单", Order = 7)]
			public object RECEIVEINS { get; set; }

			[Display(Name = "领取人", Order = 8)]
			public object CREATEPERSON { get; set; }

			[Display(Name = "领取时间", Order = 9)]
			public object CREATETIME { get; set; }


    }


}

