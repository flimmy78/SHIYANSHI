using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(VQIJULINGQU2Metadata))]
    public partial class VQIJULINGQU2 : IBaseEntity
    {

        #region 自定义属性

        #endregion

    }
    public class VQIJULINGQU2Metadata
    {
        [Display(Name = "ID", Order = 1)]
        public object ID { get; set; }

        [Display(Name = "器具名称", Order = 2)]
        public object APPLIANCE_NAME { get; set; }

        [Display(Name = "型号", Order = 3)]
        public object VERSION { get; set; }

        [Display(Name = "出厂编号", Order = 4)]
        public object FACTORY_NUM { get; set; }

        [Display(Name = "数量", Order = 5)]
        public object NUM { get; set; }

        [Display(Name = "附件", Order = 6)]
        public object ATTACHMENT { get; set; }

        [Display(Name = "承接实验室", Order = 7)]
        public object NAME { get; set; }

        [Display(Name = "器具接收", Order = 8)]
        public object APPLIANCE_RECIVE { get; set; }

        [Display(Name = "证书编号", Order = 9)]
        public object REPORTNUMBER { get; set; }

        [Display(Name = "备注", Order = 10)]
        public object REMARKS { get; set; }

        [Display(Name = "委托单id", Order = 11)]
        public object ORDER_TASK_INFORMATIONID { get; set; }

        [Display(Name = "器具领取状态", Order = 12)]
        public object APPLIANCECOLLECTIONSATE { get; set; }

        [Display(Name = "报告领取状态", Order = 13)]
        public object REPORTTORECEVESTATE { get; set; }

        [Display(Name = "预备方案id", Order = 14)]
        public object PREPARE_SCHEMEID { get; set; }
    }


}

