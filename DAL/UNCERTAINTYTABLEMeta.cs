using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(UNCERTAINTYTABLEMetadata))]//使用UNCERTAINTYTABLEMetadata对UNCERTAINTYTABLE进行数据验证
    public partial class UNCERTAINTYTABLE
    {

        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "标准装置/计量标准器信息ID")]
        public string METERING_STANDARD_DEVICEIDOld { get; set; }

        #endregion

    }
    public partial class UNCERTAINTYTABLEMetadata
    {
        [ScaffoldColumn(true)]
        [Display(Name = "备注", Order = 1)]
        public object NOTE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "指标2单位", Order = 2)]
        public object INDEX2UNIT { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "指标2", Order = 3)]
        public object INDEX2 { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "指标1单位", Order = 4)]
        public object INDEX1UNIT { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "指标1", Order = 5)]
        public object INDEX1 { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "频率止关系", Order = 29)]
        public object ENDRELATIONSHIPFREQUENCY { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "频率止单位", Order = 6)]
        public object ENDUNITFREQUENCY { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "频率范围止", Order = 7)]
        public object ENDFREQUENCY { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "频率起关系", Order = 8)]
        public object THERELATIONSHIPFREQUENCY { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "起单位频率", Order = 9)]
        public object THEUNITFREQUENCY { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "频率范围起", Order = 10)]
        public object THEFREQUENCY { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "止关系", Order = 11)]
        public object ENDRELATIONSHIP { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "止单位", Order = 12)]
        public object ENDUNIT { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "量程范围止", Order = 13)]
        public object ENDRANGESCOPE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "起关系", Order = 14)]
        public object THERELATIONSHIP { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "起单位", Order = 15)]
        public object THEUNIT { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "量程范围起", Order = 16)]
        public object THERANGESCOPE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "k值", Order = 17)]
        public object KVALE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "误差分布状况", Order = 18)]
        public object THEERRODISTRIBUTION { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "误差限单位", Order = 19)]
        public object ERRORLIMITUNIT { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "误差限", Order = 20)]
        public object ERRORLIMITS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "误差来源", Order = 21)]
        public object ERRORSOURCES { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "评定项", Order = 22)]
        public object ASSESSMENTITEM { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建时间", Order = 23)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建人", Order = 24)]
        public object CREATEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改时间", Order = 25)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UPDATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改人", Order = 26)]
        public object UPDATEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "标准装置/计量标准器信息ID", Order = 27)]
        public object METERING_STANDARD_DEVICEID { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "ID", Order = 28)]
        public object ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "组别", Order =29)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? GROUPS { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "不确定度ui", Order = 30)]
        public object UNCERTAINTYUI { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "类别", Order = 31)]
        public object CATEGORY { get; set; }
    }
}


