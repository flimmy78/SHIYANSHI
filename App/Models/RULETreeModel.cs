using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Langben.DAL;
using Langben.BLL;
using System.Text;
using Models;
namespace Langben.App.Models
{
    /// <summary>
    /// ^ReplaceClassNAME^
    /// </summary>
    public class RULETreeNodeCollection
    {
        IEnumerable<RULE> listTree;
        public bool Bind(IEnumerable<RULE> entitys, string myPARENTID, ref List<SystemTree> myChildren)
        {
            if (null != myPARENTID)
                listTree = from o in entitys
                           where o.PARENTID == myPARENTID
                           orderby o.SORT
                           select o;//叶子节点            
            else
                listTree = from o in entitys
                           where o.PARENTID == null
                           orderby o.SORT
                           select o;//根目录

            if (listTree != null && listTree.Any())
            {//填充数据
                foreach (var item in listTree)
                {
                    SystemTree myTree = new SystemTree() { id = item.ID.GetString(), text = item.NAMEOTHER.GetString() };
                    
                    if (!string.IsNullOrWhiteSpace(item.INPUTSTATE))
                        myTree.inputState = item.INPUTSTATE;//
                    if (!string.IsNullOrWhiteSpace(item.SCHEME_MENU))
                        myTree.url = "/PROJECTTEMPLET/" + item.SCHEME_MENU;//

                    myChildren.Add(myTree);
                    if (Bind(entitys, item.ID, ref myTree.children))//递归调用
                    {
                        if (null != item.PARENTID)
                        {//根目录
                           // myTree.iconCls = "icon-ok";//如果包含此字符串，则点击查看全部
                            myTree.state = "open";//默认是打开还是关闭
                        }
                        else
                        {
                            myTree.state = "closed";
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }               
        }
    
    
    }
}


