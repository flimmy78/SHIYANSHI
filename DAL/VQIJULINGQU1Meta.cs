using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VQIJULINGQU1Metadata))]
    public partial class VQIJULINGQU1 : IBaseEntity
    {

        #region 自定义属性

        #endregion

    }
    public class VQIJULINGQU1Metadata
    {
        [Display(Name = "ID", Order = 1)]
        public object ID { get; set; }

        [Display(Name = "委托单号", Order = 2)]
        public object ORDER_NUMBER { get; set; }

        [Display(Name = "证书单位", Order = 3)]
        public object CERTIFICATE_ENTERPRISE { get; set; }

        [Display(Name = "客户特殊要求", Order = 4)]
        public object CUSTOMER_SPECIFIC_REQUIREMENTS { get; set; }

        [Display(Name = "送检时间段", Order = 5)]
        public object CREATETIME { get; set; }

        [Display(Name = "器具领取状态", Order = 6)]
        public object APPLIANCECOLLECTIONSATE { get; set; }

        [Display(Name = "报告领取状态", Order = 7)]
        public object REPORTTORECEVESTATE { get; set; }

        [Display(Name = "器具状态值", Order = 8)]
        public object EQUIPMENT_STATUS_VALUUMN { get; set; }

        [Display(Name = "报告状态值", Order = 9)]
        public object REPORTSTATUSZI { get; set; }
    }


}

