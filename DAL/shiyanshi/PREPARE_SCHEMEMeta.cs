using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    public partial class PREPARE_SCHEME
    {

        #region 自定义属性，即由数据实体扩展的实体
        [Display(Name = "判断值")]
        public string SHPI { get; set; }
        #endregion

    }
}


