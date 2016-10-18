using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Langben.DAL
{

    [MetadataType(typeof(VRULEMetadata))]//使用VRULEMetadata对RULE进行数据验证
    public partial class VRULE
    {

        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "承接实验室")]
        public string UNDERTAKE_LABORATORYIDOld { get; set; }

        [Display(Name = "检定项目父节点")]
        public string PARENTIDOld { get; set; }

        #endregion

    }
    public partial class VRULEMetadata
    {
        [ScaffoldColumn(false)]
        [Display(Name = "主键", Order = 1)]
        public object ID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "别名", Order = 2)]
        public object NAMEOTHER { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "名称", Order = 3)]
        public object NAME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "方案菜单", Order = 4)]
        public object SCHEME_MENU { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "顺序", Order = 5)]
        [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
        public int? SORT { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "是否有不确定度", Order = 6)]
        public object IS_UNCERTAINTY { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "不确定度菜单", Order = 7)]
        public object UNCERTAINTY_MENU { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "承接实验室", Order = 8)]
        public object UNDERTAKE_LABORATORYID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "录入格式", Order = 9)]
        public object INPUTSTATE { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "检定项目父节点", Order = 10)]
        public object PARENTID { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建时间", Order = 11)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? CREATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "创建人", Order = 12)]
        public object CREATEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改时间", Order = 13)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime, ErrorMessage = "时间格式不正确")]
        public DateTime? UPDATETIME { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "修改人", Order = 14)]
        public object UPDATEPERSON { get; set; }

        [ScaffoldColumn(true)]
        [Display(Name = "方案ID", Order = 16)]
        public object SCHEMEID { get; set; }
        

    }
}
