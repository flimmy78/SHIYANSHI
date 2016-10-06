using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;
namespace Langben.App.Models
{
    public class VTEST_ITE_YuBei
    {
        /// <summary>
        /// 预备方案检测项目信息
        /// </summary>
        public PagedList<DAL.VTEST_ITE> vtest_ite { get; set; }
        /// <summary>
        /// 预备方案
        /// </summary>
        public DAL.PREPARE_SCHEME prepare_scheme{ get; set; }
    }
}