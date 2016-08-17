using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(PREPARE_SCHEMEMetadata))]//使用PREPARE_SCHEMEMetadata对PREPARE_SCHEME进行数据验证
    public partial class PREPARE_SCHEME 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "方案")]
        public string SCHEMEIDOld { get; set; }
        
        [Display(Name = "标准装置/计量标准器信息")]
        public string METERING_STANDARD_DEVICEID { get; set; }
        [Display(Name = "标准装置/计量标准器信息")]
        public string METERING_STANDARD_DEVICEIDOld { get; set; }
        public string aa { get; set; }

        #endregion

    }
    public partial class PREPARE_SCHEMEMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object ID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "报告类别", Order = 2)]
			public object REPORT_CATEGORY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "证书类别", Order = 3)]
			public object CERTIFICATE_CATEGORY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "CNAS", Order = 4)]
			public object CNAS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "控制编号", Order = 5)]
			public object CONTROL_NUMBER { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "检定授权", Order = 6)]
			public object CERTIFICATION_AUTHORITY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "资质", Order = 7)]
			public object QUALIFICATIONS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "环境温度", Order = 8)]
			public object TEMPERATURE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "相对湿度", Order = 9)]
			public object HUMIDITY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "检定/校准地点", Order = 10)]
			public object CHECK_PLACE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "检定/校验员", Order = 11)]
			public object CHECKERID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "核验员", Order = 12)]
			public object DETECTERID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "批准员", Order = 13)]
			public object APPROVALID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "检定/校准日期", Order = 14)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? CALIBRATION_DATE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "总结论", Order = 15)]
			public object CONCLUSION { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "结论说明", Order = 16)]
			public object CONCLUSION_EXPLAIN { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "有效期", Order = 17)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? VALIDITY_PERIOD { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "校准说明", Order = 18)]
			public object CALIBRATION_INSTRUCTIONS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "准确度等级", Order = 19)]
			public object ACCURACY_GRADE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "额定频率", Order = 20)]
			public object RATED_FREQUENCY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "脉冲常数", Order = 21)]
			public object PULSE_CONSTANT { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "外接电阻值", Order = 22)]
			public object EXTERNAL_RESITANCE_VALUE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "方案", Order = 23)]
			public object SCHEMEID { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 24)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CREATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 25)]
			public object CREATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 26)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UPDATETIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 27)]
			public object UPDATEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "审核意见", Order = 28)]
			public object AUDITOPINION { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "审核时间", Order = 29)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? AUDITTIME { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "审核人", Order = 30)]
			public object AUDITTEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "同意", Order = 31)]
			public object ISAGGREY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "审批意见", Order = 32)]
			public object APPROVAL { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "审批时间", Order = 33)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? APPROVALDATE { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "审批人", Order = 34)]
			public object APPROVALEPERSON { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "审批同意", Order = 35)]
			public object APPROVALISAGGREY { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "打印状态", Order = 36)]
			public object PRINTSTATUS { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "是否回收", Order = 37)]
			public object ISBACK { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "报告编号", Order = 38)]
			public object REPORTNUMBER { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "报告状态", Order = 39)]
			public object REPORTSTATUS { get; set; }


    }
}
 

