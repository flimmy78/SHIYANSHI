using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    public partial class METERING_STANDARD_DEVICE_CHECKShow
    {
        public METERING_STANDARD_DEVICE_CHECKShow()
        {

        }
        public string ID { get; set; }
        public string CERTIFICATEUNIT { get; set; }        
        public string CERTIFICATE_NUM { get; set; }
        public Nullable<System.DateTime> CHECK_DATE { get; set; }
        public Nullable<System.DateTime> VALID_TO { get; set; }
        public string METERING_STANDARD_DEVICEID { get; set; }
        public Nullable<System.DateTime> CREATETIME { get; set; }
        public string CREATEPERSON { get; set; }
        public Nullable<System.DateTime> UPDATETIME { get; set; }
        public string UPDATEPERSON { get; set; }
    }
}
