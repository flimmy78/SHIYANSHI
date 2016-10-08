using System.Collections.Generic;
using System.Web.Mvc;
using Langben.BLL;
using Langben.IBLL;
using Common;

namespace Models
{
    public class SysPersonModels
    {  
        /// <summary>
        /// 获取字段，首选默认，MyTexts做为value值
        /// 谢承忠添加（器具登记页面单位绑定）
        /// </summary>
        /// <returns></returns>
        public static SelectList GetMyName()
        {
            ISysPersonBLL compay = new SysPersonBLL();
            ValidationErrors ve = new ValidationErrors();
            BaseController bc = new BaseController();
            Common.Account account = bc.GetCurrentAccount();
            return new SelectList(compay.GetMyName(ref ve, account.UNDERTAKE_LABORATORYName), "MyName", "MyName");
        }
    }
}

