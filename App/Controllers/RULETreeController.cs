using System;
using System.Linq;
using System.Collections.Generic;
using Langben.DAL;
using Langben.BLL;
using Common;
using System.Web.Mvc;
using Langben.App.Models;
using Models;
namespace Langben.App.Controllers
{
    /// <summary>
    /// 规程表树形结构
    /// </summary>
    public class RULETreeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取树形页面的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTree(string id = "数表三相")
        {
            List<SystemTree> listSystemTree = new List<SystemTree>();

            IBLL.IRULEBLL db = new RULEBLL();

            RULETreeNodeCollection tree = new RULETreeNodeCollection();

            var trees = db.GetAll().Where(w => w.UNDERTAKE_LABORATORYID.Contains(id)).OrderBy(o => o.ID);
            if (trees != null)
            {
                string parentId = Request["parentid"];//父节点编号
                if (string.IsNullOrWhiteSpace(parentId))
                {
                    tree.Bind(trees, null, ref listSystemTree);
                }
                else
                {
                    tree.Bind(trees, parentId, ref listSystemTree);
                }
            }
            var d = Json(listSystemTree, JsonRequestBehavior.AllowGet);
            return Json(listSystemTree, JsonRequestBehavior.AllowGet);
        }
    }
}


