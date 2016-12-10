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
            this.ALLOWABLE_ERRORShow = new HashSet<ALLOWABLE_ERRORShow>();
            this.METERING_STANDARD_DEVICE_CHECKShow = new HashSet<METERING_STANDARD_DEVICE_CHECKShow>();
            this.UNCERTAINTYTABLEShow = new HashSet<UNCERTAINTYTABLEShow>();
        }
        public string ID { get; set; }
        public string NAME { get; set; }
        public string TEST_RANGE { get; set; }
        public string FACTORY_NUM { get; set; }
        public string CATEGORY { get; set; }
        public string STATUS { get; set; }
        public string UNDERTAKE_LABORATORYID { get; set; }
        public Nullable<System.DateTime> CREATETIME { get; set; }
        public string CREATEPERSON { get; set; }
        public Nullable<System.DateTime> UPDATETIME { get; set; }
        public string UPDATEPERSON { get; set; }
        public string XINGHAO { get; set; }
        public string THESUPERIOR { get; set; }
        public string IS { get; set; }
        public virtual ICollection<ALLOWABLE_ERRORShow> ALLOWABLE_ERRORShow { get; set; }

        public virtual ICollection<METERING_STANDARD_DEVICE_CHECKShow> METERING_STANDARD_DEVICE_CHECKShow { get; set; }

        public virtual ICollection<UNCERTAINTYTABLEShow> UNCERTAINTYTABLEShow { get; set; }
    }
}
