using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VRUKUMetadata))]
    public partial class VRUKU : IBaseEntity
    {

        #region 自定义属性

        #endregion

    }
    public class VRUKUMetadata
    {
        [Display(Name = "ID", Order = 1)]
        public object ID { get; set; }

        [Display(Name = "报告编号", Order = 2)]
        public object REPORTNUMBER { get; set; }

        [Display(Name = "委托单号", Order = 3)]
        public object ORDER_NUMBER { get; set; }

        [Display(Name = "器具名称", Order = 4)]
        public object APPLIANCE_NAME { get; set; }

        [Display(Name = "型号", Order = 5)]
        public object VERSION { get; set; }

        [Display(Name = "出厂编号", Order = 6)]
        public object FACTORY_NUM { get; set; }

        [Display(Name = "证书单位", Order = 7)]
        public object CERTIFICATE_ENTERPRISE { get; set; }

        [Display(Name = "客户特殊要求", Order = 8)]
        public object CUSTOMER_SPECIFIC_REQUIREMENTS { get; set; }

        [Display(Name = "器具所在实验室", Order = 9)]
        public object NAME { get; set; }

        [Display(Name = "器具状态", Order = 10)]
        public object ORDER_STATUS { get; set; }

        [Display(Name = "入库说明", Order = 11)]
        public object STORAGEINSTRUCTIONS { get; set; }

        [Display(Name = "实验室", Order = 12)]
        public object UNDERTAKE_LABORATORYID { get; set; }

        [Display(Name = "批准日期", Order = 13)]
        public object APPROVALDATE { get; set; }

        [Display(Name = "入库状态", Order = 14)]
        public object STORAGEINSTRUCTI_STATU { get; set; }

        [Display(Name = "报告状态", Order = 15)]
        public object REPORTSTATUS { get; set; }

        [Display(Name = "报告状态值", Order = 16)]
        public object REPORTSTATUSZI { get; set; }

        [Display(Name = "器具状态值", Order = 17)]
        public object EQUIPMENT_STATUS_VALUUMN { get; set; }


    }


}

