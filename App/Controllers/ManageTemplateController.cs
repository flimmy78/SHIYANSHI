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
    /// 方案模板
    /// </summary>
    [HandleError]
    public class ManageTemplateController : BaseController
    {
        /// <summary>
        /// 控制面板页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();

        }
        public ActionResult Add()
        {

            return View();

        }
        public ActionResult Test(string duoTongDao= "show")
        {
            ViewBag.DuoTongDao = duoTongDao;//如果想显示“增加通道”按钮，就为show，否则为hidden

            return View();

        }
    }
         
}

