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
    
    public partial class PAKAGE
    {
        public decimal PAKAGE_ID { get; set; }
        public string PSIZE { get; set; }
        public Nullable<decimal> PWEIGHT { get; set; }
        public Nullable<decimal> PSENDER_ID { get; set; }
        public Nullable<decimal> PRECEIVER_ID { get; set; }
        public Nullable<decimal> PDRIVER_ID { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual CUSTOMER CUSTOMER1 { get; set; }
        public virtual DRIVER DRIVER { get; set; }
    }
}