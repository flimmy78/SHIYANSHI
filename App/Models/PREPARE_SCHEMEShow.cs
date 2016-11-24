using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    public partial class PREPARE_SCHEMEShow
    {
        public PREPARE_SCHEMEShow()
        {
            APPLIANCE_DETAIL_INFORMATIONShows = new APPLIANCE_DETAIL_INFORMATIONShow();
            METERING_STANDARD_DEVICEShow = new List<METERING_STANDARD_DEVICEShow>();
        }
        public string SCHEMENAME { get; set; }
        public APPLIANCE_DETAIL_INFORMATIONShow APPLIANCE_DETAIL_INFORMATIONShows { get; set; }
        public List<METERING_STANDARD_DEVICEShow> METERING_STANDARD_DEVICEShow { get; set; }
        public string ID { get; set; }
        public string REPORT_CATEGORY { get; set; }
        public string CERTIFICATE_CATEGORY { get; set; }
        public string CNAS { get; set; }
        public string CONTROL_NUMBER { get; set; }
        public string CERTIFICATION_AUTHORITY { get; set; }
        public string QUALIFICATIONS { get; set; }
        public string TEMPERATURE { get; set; }
        public string HUMIDITY { get; set; }
        public string CHECK_PLACE { get; set; }
        public string CHECKERID { get; set; }
        public string DETECTERID { get; set; }
        public string APPROVALID { get; set; }
        public Nullable<System.DateTime> CALIBRATION_DATE { get; set; }
        public string CONCLUSION { get; set; }
        public string CONCLUSION_EXPLAIN { get; set; }
        public Nullable<System.DateTime> VALIDITY_PERIOD { get; set; }
        public string CALIBRATION_INSTRUCTIONS { get; set; }
        public string ACCURACY_GRADE { get; set; }
        public string RATED_FREQUENCY { get; set; }
        public string PULSE_CONSTANT { get; set; }
        public string EXTERNAL_RESITANCE_VALUE { get; set; }
        public string SCHEMEID { get; set; }
        public Nullable<System.DateTime> CREATETIME { get; set; }
        public string CREATEPERSON { get; set; }
        public Nullable<System.DateTime> UPDATETIME { get; set; }
        public string UPDATEPERSON { get; set; }
        public string AUDITOPINION { get; set; }
        public Nullable<System.DateTime> AUDITTIME { get; set; }
        public string AUDITTEPERSON { get; set; }
        public string ISAGGREY { get; set; }
        public string APPROVAL { get; set; }
        public Nullable<System.DateTime> APPROVALDATE { get; set; }
        public string APPROVALEPERSON { get; set; }
        public string APPROVALISAGGREY { get; set; }
        public string PRINTSTATUS { get; set; }
        public string ISBACK { get; set; }
        public string REPORTNUMBER { get; set; }
        public string REPORTSTATUS { get; set; }
        public string REPORTSTATUSZI { get; set; }
        public Nullable<decimal> SERIALNUMBER { get; set; }
        public string YEARS { get; set; }
        public string PACKAGETYPE { get; set; }
        public string OTHER { get; set; }
        public string METERING_STANDARD_DEVICEID { get; set; }
    }
}
