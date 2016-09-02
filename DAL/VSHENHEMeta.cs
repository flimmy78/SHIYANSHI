using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VSHENHEMetadata))]
    public partial class VSHENHE : IBaseEntity
    {

        #region 自定义属性

        #endregion

    }
    public class VSHENHEMetadata
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

        [Display(Name = "证书类别", Order = 9)]
        public object CERTIFICATE_CATEGORY { get; set; }

        [Display(Name = "资质授权", Order = 10)]
        public object QUALIFICATIONS { get; set; }

        [Display(Name = "总结论说明", Order = 11)]
        public object CONCLUSION_EXPLAIN { get; set; }

        [Display(Name = "总结论", Order = 12)]
        public object CONCLUSION { get; set; }

        [Display(Name = "审核结论", Order = 13)]
        public object ISAGGREY { get; set; }

        [Display(Name = "报告类型", Order = 13)]
        public object PACKAGETYPE { get; set; }

    }


}

