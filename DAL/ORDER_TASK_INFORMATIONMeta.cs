using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(ORDER_TASK_INFORMATIONMetadata))]//使用ORDER_TASK_INFORMATIONMetadata对ORDER_TASK_INFORMATION进行数据验证
    public partial class ORDER_TASK_INFORMATION
    {

        #region 自定义属性，即由数据实体扩展的实体
        public bool isNewRecord { get; set; }
        #endregion

    }
    public partial class ORDER_TASK_INFORMATIONMetadata
    {
        [ScaffoldColumn(false)]
        [Display(Name = "主键", Order = 1)]
        public object ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "委托单号", Order = 2)]
        public object ORDER_NUMBER { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "受理单位", Order = 3)]
        public object ACCEPT_ORGNIZATION { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "送检单位", Order = 4)]
        public object INSPECTION_ENTERPRISE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "送检单位地址", Order = 5)]
        public object INSPECTION_ENTERPRISE_ADDRESS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "送检单位邮编", Order = 6)]
        public object INSPECTION_ENTERPRISE_POST { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "送检单位联系人", Order = 7)]
        public object CONTACTS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "送检单位电话", Order = 8)]
        public object CONTACT_PHONE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "送检单位传真", Order = 9)]
        public object FAX { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "证书单位", Order = 10)]
        public object CERTIFICATE_ENTERPRISE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "证书单位地址", Order = 11)]
        public object CERTIFICATE_ENTERPRISE_ADDRESS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "证书单位邮编", Order = 12)]
        public object CERTIFICATE_ENTERPRISE_POST { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "证书单位联系人", Order = 13)]
        public object CONTACTS2 { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "证书单位电话", Order = 14)]
        public object CONTACT_PHONE2 { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "证书单位传真", Order = 15)]
        public object FAX2 { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "客户特殊要求", Order = 16)]
        public object CUSTOMER_SPECIFIC_REQUIREMENTS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "状态", Order = 17)]
        public object ORDER_STATUS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "登记时间", Order = 18)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "登记人", Order = 19)]
        public object CREATEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改时间", Order = 20)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UPDATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改人", Order = 21)]
        public object UPDATEPERSON { get; set; }


    }
}


