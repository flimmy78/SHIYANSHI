using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    public partial class APPLIANCE_DETAIL_INFORMATION
    {

        #region 自定义属性，即由数据实体扩展的实体

        [Display(Name = "是否是新增的记录")]
        public bool isNewRecord { get; set; }

        #endregion

    }
   
}


