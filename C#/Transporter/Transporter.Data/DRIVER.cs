//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Transporter.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class DRIVER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DRIVER()
        {
            this.PAKAGE = new HashSet<PAKAGE>();
        }
    
        public decimal DRIVER_ID { get; set; }
        public string DNAME { get; set; }
        public string DADRESS { get; set; }
        public System.DateTime DBIRTH_DATE { get; set; }
        public string DLICENCE_PLATE { get; set; }
        public string DPHONE_NUM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAKAGE> PAKAGE { get; set; }
    }
}
