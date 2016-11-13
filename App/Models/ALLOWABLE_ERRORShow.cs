using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    public partial class ALLOWABLE_ERRORShow
    {
        public ALLOWABLE_ERRORShow()
        {

        }
        public string ID { get; set; }
        public string VALUE { get; set; }
        public string UNIT { get; set; }
        public string METERING_STANDARD_DEVICEID { get; set; }
        public Nullable<System.DateTime> CREATETIME { get; set; }
        public string CREATEPERSON { get; set; }
        public Nullable<System.DateTime> UPDATETIME { get; set; }
        public string UPDATEPERSON { get; set; }
    }
}
