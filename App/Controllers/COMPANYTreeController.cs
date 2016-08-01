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
    /// 单位树形结构
    /// </summary>
    public class COMPANYTreeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取树形页面的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTree()
        {
            List<SystemTree> listSystemTree = new List<SystemTree>();
            
            IBLL.ICOMPANYBLL db = new COMPANYBLL();
         
            COMPANYTreeNodeCollection tree = new COMPANYTreeNodeCollection();

            var trees = db.GetAll().OrderBy(o => o.ID);
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
            return Json(listSystemTree, JsonRequestBehavior.AllowGet);
        }
    }
}


