using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    public partial class ORDER_TASK_INFORMATIONShow
    {
        public ORDER_TASK_INFORMATIONShow()
        {
            APPLIANCE_DETAIL_INFORMATIONShows = new List<APPLIANCE_DETAIL_INFORMATIONShow>();
        }
        public List<APPLIANCE_DETAIL_INFORMATIONShow> APPLIANCE_DETAIL_INFORMATIONShows { get; set; }
        public string ID { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string ACCEPT_ORGNIZATION { get; set; }
        public string INSPECTION_ENTERPRISE { get; set; }
        public string INSPECTION_ENTERPRISE_ADDRESS { get; set; }
        public string INSPECTION_ENTERPRISE_POST { get; set; }
        public string CONTACTS { get; set; }
        public string CONTACT_PHONE { get; set; }
        public string FAX { get; set; }
        public string CERTIFICATE_ENTERPRISE { get; set; }
        public string CERTIFICATE_ENTERPRISE_ADDRESS { get; set; }
        public string CERTIFICATE_ENTERPRISE_POST { get; set; }
        public string CONTACTS2 { get; set; }
        public string CONTACT_PHONE2 { get; set; }
        public string FAX2 { get; set; }
        public string CUSTOMER_SPECIFIC_REQUIREMENTS { get; set; }
        public string ORDER_STATUS { get; set; }
        public Nullable<System.DateTime> CREATETIME { get; set; }
        public string CREATEPERSON { get; set; }
        public Nullable<System.DateTime> UPDATETIME { get; set; }
        public string UPDATEPERSON { get; set; }       
    }
}
