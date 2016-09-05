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
        public ActionResult Test(string duoTongDao = "show", string ua = "u", string xianshibiaozhun = "xianshi")
        {
            ViewBag.DuoTongDao = duoTongDao;//如果想显示“增加通道”按钮，就为show，否则为hidden

            /*
                                                        //如果下拉框想显示“V,MV,KV,mV,μV”按钮，就为u
                                            //如果下拉框想显示“A,KA,mA,μA,nA,pA”按钮，就为a
                                            //如果下拉框想显示“”按钮，就为
*/
            ViewBag.UA = ua;
            ViewBag.UA = xianshibiaozhun;//如果增加量程希望默认值赋给“显示值”，就为xianshi，如果增加量程希望默认值赋给“显示值”，就为biaozhun

            return View();

        }
    }

}

