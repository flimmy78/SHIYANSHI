using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(QUALIFIED_UNQUALIFIED_TEST_ITEMetadata))]//使用QUALIFIED_UNQUALIFIED_TEST_ITEMetadata对QUALIFIED_UNQUALIFIED_TEST_ITE进行数据验证
    public partial class QUALIFIED_UNQUALIFIED_TEST_ITE 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "预备方案")]
        public string PREPARE_SCHEMEIDOld { get; set; }
        
        #endregion

    }
    public partial class QUALIFIED_UNQUALIFIED_TEST_ITEMetadata
    {
        [ScaffoldColumn(false)]
        [Display(Name = "主键", Order = 1)]
        public object ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "结论", Order = 2)]
        public object CONCLUSION { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "预备方案", Order = 3)]
        public object PREPARE_SCHEMEID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "检定项目编号", Order = 4)]
        public object RULEID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "检定项目名称", Order = 5)]
        [StringLength(200, ErrorMessage = "长度不可超过200")]
        public object RULENAME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "检定项目拼接名称", Order = 6)]
        [StringLength(2000, ErrorMessage = "长度不可超过2000")]
        public object RULENJOINAME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "HTMLVALUE", Order = 7)]
        public object HTMLVALUE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "注释", Order = 8)]
        public object REMARK { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建时间", Order = 9)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建人", Order = 10)]
        public object CREATEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改时间", Order = 11)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UPDATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改人", Order = 12)]
        public object UPDATEPERSON { get; set; }


    }
}
 

