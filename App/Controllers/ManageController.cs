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
            Account account = GetCurrentAccount();
            var data = App.Codes.MenuCaching.GetMenu(ref account); //home.GetMenuByAccount(ref account);// 获取菜单
            ViewBag.PersonName = account.PersonName;
            if (!data.Contains("Appliance"))
            {
                ViewBag.Appliance = "disabled";
            }
            if (!data.Contains("VQIJULINGQU1"))
            {
                ViewBag.VQIJULINGQU1 = "disabled";
            }
            if (!data.Contains("VRUKU"))
            {
                ViewBag.VRUKU = "disabled";
            }
            if (!data.Contains("VJIANDINGRENWU"))
            {
                ViewBag.VJIANDINGRENWU = "disabled";
            }
            
            if (!data.Contains("SysPerson"))
            {
                ViewBag.SysPerson = "disabled";

            }
            return View();

        }
    }

}

