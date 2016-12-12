using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    public partial class ALLOWABLE_ERRORShow
    {
        public string ID { get; set; }
        public string THEACCURACYLEVEL { get; set; }
        public string THEUNCERTAINTYVALUEK { get; set; }
        public string METERING_STANDARD_DEVICEID { get; set; }
        public Nullable<System.DateTime> CREATETIME { get; set; }
        public string CREATEPERSON { get; set; }
        public Nullable<System.DateTime> UPDATETIME { get; set; }
        public string UPDATEPERSON { get; set; }
        public string THEUNCERTAINTYNDEXL { get; set; }
        public string THEUNCERTAINTYVALUE { get; set; }
        public string THEUNCERTAINTY { get; set; }
        public string MAXVALUE { get; set; }
        public string MAXCATEGORIES { get; set; }
        public Nullable<decimal> GROUPS { get; set; }
        public string CATEGORY { get; set; }
    }
}
