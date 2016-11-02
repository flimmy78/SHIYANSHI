using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(APPLIANCE_LABORATORYMetadata))]//使用APPLIANCE_LABORATORYMetadata对APPLIANCE_LABORATORY进行数据验证
    public partial class APPLIANCE_LABORATORY
    {

        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "承接实验室")]
        public string UNDERTAKE_LABORATORYIDOld { get; set; }

        [Display(Name = "器具明细信息")]
        public string APPLIANCE_DETAIL_INFORMATIOIDOld { get; set; }

        [Display(Name = "预备方案")]
        public string PREPARE_SCHEMEIDOld { get; set; }

        #endregion

    }
    public partial class APPLIANCE_LABORATORYMetadata
    {
        [ScaffoldColumn(false)]
        [Display(Name = "主键", Order = 1)]
        public object ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "承接实验室", Order = 2)]
        public object UNDERTAKE_LABORATORYID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "器具明细信息", Order = 3)]
        public object APPLIANCE_DETAIL_INFORMATIONID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "预备方案", Order = 4)]
        public object PREPARE_SCHEMEID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "领取人", Order = 5)]
        public object RECEIVEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "领取时间", Order = 6)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? RECEIVETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "退回人", Order = 7)]
        public object BACKPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "退回时间", Order = 8)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? BACKTIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "分配人", Order = 9)]
        public object DISTRIBUTIONPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "分配时间", Order = 10)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? DISTRIBUTIONTIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建人", Order = 11)]
        public object CREATEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建时间", Order = 12)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "是否领取", Order = 13)]
        public object ISRECEIVE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "器具状态值", Order = 14)]
        public object EQUIPMENT_STATUS_VALUUMN { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "退回说明", Order = 15)]
        public object RETURN_INSTRUCTIONS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "状态", Order = 16)]
        public object ORDER_STATUS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "回收编号", Order = 17)]
        public object RECYCLING { get; set; }
    }
}


