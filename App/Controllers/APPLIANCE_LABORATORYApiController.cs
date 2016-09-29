using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using System.Web.Http;
using Langben.App.Models;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 器具明细信息_承接实验室
    /// </summary>
    public class APPLIANCE_LABORATORYApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<APPLIANCE_LABORATORY> queryData = m_BLL.GetByParam(null, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    UNDERTAKE_LABORATORYID = s.UNDERTAKE_LABORATORYIDOld
                    ,
                    APPLIANCE_DETAIL_INFORMATIOID = s.APPLIANCE_DETAIL_INFORMATIOIDOld
                    ,
                    PREPARE_SCHEMEID = s.PREPARE_SCHEMEIDOld


                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public APPLIANCE_LABORATORY Get(string id)
        {
            APPLIANCE_LABORATORY item = m_BLL.GetById(id);
            return item;
        }

        /// <summary>
        /// 判断是否能领取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public bool GetISRECEIVE(string id)
        {
            Common.Account account = GetCurrentAccount();
            bool IS = false;
            List<APPLIANCE_LABORATORY> list = m_BLL.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(id);
            foreach (var item in list)
            {
                if (item.UNDERTAKE_LABORATORYID == account.UNDERTAKE_LABORATORYName)
                {
                    if (item.ISRECEIVE == Common.ISRECEIVE.是.ToString())
                    {
                        IS = true;
                    }
                    else
                    {
                        IS = false;
                    }
                }
            }
            return IS;
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Post([FromBody]APPLIANCE_LABORATORY entity)
        {

            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {
                string currentPerson = GetCurrentPerson();
                // entity.CREATETIME = DateTime.Now;
                // entity.CREATEPERSON = currentPerson;

                entity.ID = Result.GetNewId();
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，器具明细信息_承接实验室的信息的Id为" + entity.ID, "器具明细信息_承接实验室"
                        );//写入日志 
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.InsertSucceed;
                    return result; //提示创建成功
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，器具明细信息_承接实验室的信息，" + returnValue, "器具明细信息_承接实验室"
                        );//写入日志                      
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.InsertFail + returnValue;
                    return result; //提示插入失败
                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            return result;
        }

        // PUT api/<controller>/5
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        public Common.ClientResult.Result Put([FromBody]APPLIANCE_LABORATORY entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                string currentPerson = GetCurrentPerson();
                // entity.UPDATETIME = DateTime.Now;
                // entity.UPDATEPERSON = currentPerson;

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具明细信息_承接实验室信息的Id为" + entity.ID, "器具明细信息_承接实验室"
                        );//写入日志                   
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.UpdateSucceed;
                    return result; //提示更新成功 
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，器具明细信息_承接实验室信息的Id为" + entity.ID + "," + returnValue, "器具明细信息_承接实验室"
                        );//写入日志   
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return result; //提示更新失败
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return result; //提示输入的数据的格式不对         
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>  
        public Common.ClientResult.Result Delete(string query)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            string returnValue = string.Empty;
            string[] deleteId = query.GetString().Split(',');
            if (deleteId != null && deleteId.Length > 0)
            {
                if (m_BLL.DeleteCollection(ref validationErrors, deleteId))
                {
                    LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，信息的Id为" + string.Join(",", deleteId), "消息"
                        );//删除成功，写入日志
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.DeleteSucceed;
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息"
                        );//删除失败，写入日志
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.DeleteFail + returnValue;
                }
            }
            return result;
        }


        /// <summary>
        /// 编辑集合（领取功能）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [HttpPost]
        public Common.ClientResult.Result LINGQU([FromBody]APPLIANCE_LABORATORY entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            string returnValue = string.Empty;
            string id = entity.APPLIANCE_DETAIL_INFORMATIONID.TrimEnd(',');
            string[] deleteId = id.Split(',');//截取id        
            if (deleteId != null && deleteId.Length > 0)
            {
                Common.Account account = GetCurrentAccount();

                //判断器具领取信息是否添加成功
                if (m_BLL.EditCollection(ref validationErrors, deleteId, account.UNDERTAKE_LABORATORYName) && m_BLL2.EditCollection(ref validationErrors, deleteId, account.UNDERTAKE_LABORATORYName))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具明细信息信息的Id为" + string.Join(",", deleteId), "器具明细信息");//写入日志                   
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.UpdateSucceed;
                    return result; //提示更新成功 
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，器具明细信息信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "器具明细信息");//写入日志   
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return result; //提示更新失败
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return result; //提示输入的数据的格式不对         
        }

        /// <summary>
        /// 退回保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [HttpPost]
        public Common.ClientResult.Result EditSENDBACK([FromBody]APPLIANCE_LABORATORY entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {   //数据校验
                List<APPLIANCE_LABORATORY> appory = m_BLL.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(entity.ID);
                Common.Account account = GetCurrentAccount();
                string currentPerson = GetCurrentPerson();
                entity.BACKTIME = DateTime.Now;
                entity.BACKPERSON = currentPerson;
                string returnValue = string.Empty;
                //通过前端传过来的值来判断枚举中属于什么值给器具状态值赋值        
                if (!string.IsNullOrEmpty(entity.ORDER_STATUS))
                {
                    if (Enum.IsDefined(typeof(Common.ORDER_STATUS), entity.ORDER_STATUS))
                    {
                        entity.EQUIPMENT_STATUS_VALUUMN = Enum.Parse(typeof(Common.ORDER_STATUS), entity.ORDER_STATUS).GetHashCode().ToString();
                    }
                }
                foreach (var item in appory)
                {
                    if (item.UNDERTAKE_LABORATORYID == account.UNDERTAKE_LABORATORYName)
                    {
                        //退回
                        if (entity.ORDER_STATUS == Common.ORDER_STATUS.已退回.ToString())
                        {
                            //获取委托单id
                            APPLIANCE_DETAIL_INFORMATION appl = m_BLL2.GetById(entity.ID);
                            appl.ORDER_TASK_INFORMATION.ORDER_STATUS = Common.ORDER_STATUS_INFORMATION.有退回.ToString();
                            m_BLL3.EditField(ref validationErrors, appl.ORDER_TASK_INFORMATION);
                        }
                        entity.ID = item.ID;
                        if (m_BLL.EditField(ref validationErrors, entity))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具明细信息信息的Id为" + entity.ID, "器具明细信息"
                                );//写入日志                   
                            result.Code = Common.ClientCode.Succeed;
                            result.Message = Suggestion.UpdateSucceed;
                            return result; //提示更新成功 
                        }
                        else
                        {
                            if (validationErrors != null && validationErrors.Count > 0)
                            {
                                validationErrors.All(a =>
                                {
                                    returnValue += a.ErrorMessage;
                                    return true;
                                });
                            }
                            LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，器具明细信息信息的Id为" + entity.ID + "," + returnValue, "器具明细信息"
                                );//写入日志   
                            result.Code = Common.ClientCode.Fail;
                            result.Message = Suggestion.UpdateFail + returnValue;
                            return result; //提示更新失败
                        }
                    }
                    result.Code = Common.ClientCode.FindNull;
                    result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
                }
            }
            return result; //提示输入的数据的格式不对                 
        }

        /// <summary>
        /// 编辑集合（入库功能）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        /// 
        [System.Web.Http.HttpPut]
        public Common.ClientResult.Result PutSTORAGEINSTRUCTI_STATU(string id)
        {
            Common.Account account = GetCurrentAccount();
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            string returnValue = string.Empty;
            string[] deleteId = id.GetString().Split(',');
            List<APPLIANCE_LABORATORY> listappory = m_BLL.GetByRefAPPLIANCE_DETAIL_INFORMATIOID(id);
            if (deleteId != null && deleteId.Length > 0)
            {
                foreach (var item in listappory)
                {
                    //数据校验
                    if (m_BLL.EditSTORAGEINSTRUCTI_STATU(ref validationErrors, deleteId)&&m_BLL2.EditSTORAGEINSTRUCTI_STATU(ref validationErrors, deleteId))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，器具明细信息信息的Id为" + string.Join(",", deleteId), "器具明细信息"
                            );//写入日志                   
                        result.Code = Common.ClientCode.Succeed;
                        result.Message = Suggestion.UpdateSucceed;
                        return result; //提示更新成功 
                    }
                    else
                    {
                        if (validationErrors != null && validationErrors.Count > 0)
                        {
                            validationErrors.All(a =>
                            {
                                returnValue += a.ErrorMessage;
                                return true;
                            });
                        }
                        LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，器具明细信息信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "器具明细信息"
                            );//写入日志   
                        result.Code = Common.ClientCode.Fail;
                        result.Message = Suggestion.UpdateFail + returnValue;
                        return result; //提示更新失败
                    }
                }
                result.Code = Common.ClientCode.FindNull;
                result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            }
            return result; //提示输入的数据的格式不对         
        }

        IBLL.IAPPLIANCE_LABORATORYBLL m_BLL;
        IBLL.IAPPLIANCE_DETAIL_INFORMATIONBLL m_BLL2;
        IBLL.IORDER_TASK_INFORMATIONBLL m_BLL3;

        ValidationErrors validationErrors = new ValidationErrors();

        public APPLIANCE_LABORATORYApiController()
            : this(new APPLIANCE_LABORATORYBLL(), new APPLIANCE_DETAIL_INFORMATIONBLL(), new ORDER_TASK_INFORMATIONBLL()) { }

        public APPLIANCE_LABORATORYApiController(APPLIANCE_LABORATORYBLL bll, APPLIANCE_DETAIL_INFORMATIONBLL bll2, ORDER_TASK_INFORMATIONBLL bll3)
        {
            m_BLL = bll;
            m_BLL2 = bll2;
            m_BLL3 = bll3;
        }

    }
}


