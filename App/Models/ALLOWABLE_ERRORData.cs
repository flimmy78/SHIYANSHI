using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    public partial class ALLOWABLE_ERRORData
    {
        public string ID { get; set; }
        public string CERTIFICATE_NUM { get; set; }
        public string VALID_TO { get; set; }
        public string MAXCATEGORIES { get; set; }
        public Nullable<decimal> GROUPS { get; set; }
    }
}
