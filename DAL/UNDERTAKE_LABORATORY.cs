//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Langben.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class UNDERTAKE_LABORATORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UNDERTAKE_LABORATORY()
        {
            this.METERING_STANDARD_DEVICE = new HashSet<METERING_STANDARD_DEVICE>();
            this.SCHEME = new HashSet<SCHEME>();
        }
    
        public string ID { get; set; }
        public string NAME { get; set; }
        public Nullable<System.DateTime> CREATETIME { get; set; }
        public string CREATEPERSON { get; set; }
        public Nullable<System.DateTime> UPDATETIME { get; set; }
        public string UPDATEPERSON { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<METERING_STANDARD_DEVICE> METERING_STANDARD_DEVICE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHEME> SCHEME { get; set; }
    }
}
