using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VJIANDINGRENWUMetadata))]
    public partial class VJIANDINGRENWU : IBaseEntity
    {

        #region 自定义属性
  
        #endregion

    }
    public class VJIANDINGRENWUMetadata
    {
        [Display(Name = "ID", Order = 1)]
        public object ID { get; set; }

        [Display(Name = "委托单号", Order = 2)]
        public object ORDER_NUMBER { get; set; }

        [Display(Name = "器具名称", Order = 3)]
        public object APPLIANCE_NAME { get; set; }

        [Display(Name = "型号", Order = 4)]
        public object VERSION { get; set; }

        [Display(Name = "出厂编号", Order = 5)]
        public object FACTORY_NUM { get; set; }

        [Display(Name = "证书单位", Order = 6)]
        public object CERTIFICATE_ENTERPRISE { get; set; }

        [Display(Name = "客户特殊要求", Order = 7)]
        public object CUSTOMER_SPECIFIC_REQUIREMENTS { get; set; }

        [Display(Name = "器具状态", Order = 8)]
        public object ORDER_STATUS { get; set; }

        [Display(Name = "送检时间", Order = 9)]
        public object CREATETIME { get; set; }

        [Display(Name = "器具进度", Order = 10)]
        public object APPLIANCE_PROGRESS { get; set; }

        [Display(Name = "超期原因", Order = 11)]
        public object OVERDUE { get; set; }

        [Display(Name = "上传状态", Order = 12)]
        public object STATE { get; set; }

        [Display(Name = "报告状态", Order = 13)]
        public object REPORTSTATUS { get; set; }

        [Display(Name = "审核审批不通过原因", Order = 14)]
        public object APPROVAL { get; set; }

        [Display(Name = "送检单位", Order = 15)]
        public object INSPECTION_ENTERPRISE { get; set; }

        [Display(Name = "是否超期", Order = 16)]
        public object ISOVERDUE { get; set; }

        [Display(Name = "器具状态值", Order = 17)]
        public object EQUIPMENT_STATUS_VALUUMN { get; set; }

        [Display(Name = "所在实验室", Order = 18)]
        public object NAME { get; set; }

        [Display(Name = "修改时间", Order = 19)]
        public object UPDATETIME { get; set; }

    }


}

