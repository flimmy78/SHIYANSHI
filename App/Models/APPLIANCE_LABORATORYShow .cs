using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    public partial class APPLIANCE_LABORATORYShow
    {
        public string ID { get; set; }
        public string UNDERTAKE_LABORATORYID { get; set; }
        public string APPLIANCE_DETAIL_INFORMATIONID { get; set; }
        public string PREPARE_SCHEMEID { get; set; }
        public string RECEIVEPERSON { get; set; }
        public Nullable<System.DateTime> RECEIVETIME { get; set; }
        public string BACKPERSON { get; set; }
        public Nullable<System.DateTime> BACKTIME { get; set; }
        public string DISTRIBUTIONPERSON { get; set; }
        public Nullable<System.DateTime> DISTRIBUTIONTIME { get; set; }
        public string CREATEPERSON { get; set; }
        public Nullable<System.DateTime> CREATETIME { get; set; }
        public string ORDER_STATUS { get; set; }
        public string EQUIPMENT_STATUS_VALUUMN { get; set; }
        public string RETURN_INSTRUCTIONS { get; set; }
        public string ISRECEIVE { get; set; }
    }
}
