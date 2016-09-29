using System.Collections.Generic;
using System.Web.Mvc;
using Langben.BLL;
using Langben.IBLL;
namespace  Models
{
    public class COMPANYModels
    {  
        /// <summary>
        /// 获取字段，首选默认，MyTexts做为value值
        /// 谢承忠添加（器具登记页面单位绑定）
        /// </summary>
        /// <returns></returns>
        public static SelectList GetCOMPANY()
        {
            ICOMPANYHander compay = new SysCOMPANY();
            return new SelectList(compay.GetCOMPANY(), "COMPANYNAME", "COMPANYNAME");

        }
    }
}

