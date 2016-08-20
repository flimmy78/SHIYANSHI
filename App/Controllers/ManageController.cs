using System.Linq;
using System.Web.Mvc;

using Langben.DAL;
using Langben.App.Models;
using Langben.BLL;
using System.Drawing;
using System;
using System.Drawing.Imaging;
using Common;
using Langben.IBLL;
using Models;
namespace Langben.App.Controllers
{
    /// <summary>
    /// 用户账户信息
    /// </summary>
    [HandleError]
    public class ManageController : BaseController
    {
        /// <summary>
        /// 控制面板页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();

        }
    }
         
}

