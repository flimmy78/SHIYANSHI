using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    public partial class APPLIANCE_DETAIL_INFORMATIONShow
    {
        public APPLIANCE_DETAIL_INFORMATIONShow()
        {
            APPLIANCE_LABORATORYShow = new APPLIANCE_LABORATORYShow();
        }
        public string ID { get; set; }
        public string BAR_CODE_NUM { get; set; }
        public string APPLIANCE_NAME { get; set; }
        public string VERSION { get; set; }
        public string FORMAT { get; set; }
        public string FACTORY_NUM { get; set; }
        public Nullable<decimal> NUM { get; set; }
        public string ATTACHMENT { get; set; }
        public string APPEARANCE_STATUS { get; set; }
        public string MAKE_ORGANIZATION { get; set; }
        public string REMARKS { get; set; }
        public Nullable<System.DateTime> END_PLAN_DATE { get; set; }
        public string ORDER_TASK_INFORMATIONID { get; set; }
        public Nullable<System.DateTime> CREATETIME { get; set; }
        public string CREATEPERSON { get; set; }
        public Nullable<System.DateTime> UPDATETIME { get; set; }
        public string UPDATEPERSON { get; set; }
        public string APPLIANCE_RECIVE { get; set; }
        public string APPLIANCE_PROGRESS { get; set; }
        public string ORDER_STATUS { get; set; }
        public string ISOVERDUE { get; set; }
        public string OVERDUE { get; set; }
        public string STORAGEINSTRUCTIONS { get; set; }
        public string STORAGEINSTRUCTI_STATU { get; set; }
        public string EQUIPMENT_STATUS_VALUUMN { get; set; }
        public string RETURN_INSTRUCTIONS { get; set; }
        public string UNDERTAKE_LABORATORYIDString { get; set; }
        //器具领取
        public string APPLIANCECOLLECTIONSATE { get; set; }
        //报告领取
        public string REPORTTORECEVESTATE { get; set; }
        public APPLIANCE_LABORATORYShow APPLIANCE_LABORATORYShow { get; set; }
        public string ORDER_STATUS_NAME { get; set; }//记入退回实验室
        public string TIQURIQI { get; set; }//提前日期
        //  public virtual ORDER_TASK_INFORMATIONShow ORDER_TASK_INFORMATION { get; set; }
    }
}
