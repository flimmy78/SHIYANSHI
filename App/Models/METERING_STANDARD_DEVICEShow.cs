using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    public partial class METERING_STANDARD_DEVICEShow
    {
        public METERING_STANDARD_DEVICEShow()
        {
            METERING_STANDARD_DEVICE_CHECKShow = new List<METERING_STANDARD_DEVICE_CHECKShow>();
            ALLOWABLE_ERRORShow = new List<ALLOWABLE_ERRORShow>();
        }
        public List<METERING_STANDARD_DEVICE_CHECKShow>METERING_STANDARD_DEVICE_CHECKShow { get; set; }
        public List<ALLOWABLE_ERRORShow> ALLOWABLE_ERRORShow { get; set; }
        public string ID { get; set; }
        public string NAME { get; set; }
        public string TEST_RANGE { get; set; }
        public string FACTORY_NUM { get; set; }
        public string XINGHAO { get; set; }
        public string THESUPERIOR { get; set; }
        public string CATEGORY { get; set; }      
        public string STATUS { get; set; }
        public string UNDERTAKE_LABORATORYID { get; set; }
        public Nullable<System.DateTime> CREATETIME { get; set; }
        public string CREATEPERSON { get; set; }
        public Nullable<System.DateTime> UPDATETIME { get; set; }
        public string UPDATEPERSON { get; set; }
    }
}
