//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Latihan_LKS_Laundry_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public service()
        {
            this.detailpackages = new HashSet<detailpackage>();
            this.detailtransactions = new HashSet<detailtransaction>();
        }
    
        public int id_category { get; set; }
        public int id_unit { get; set; }
        public int id_service { get; set; }
        public string name_service { get; set; }
        public int price_unit_service { get; set; }
        public int estimation_duration_service { get; set; }
    
        public virtual category category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detailpackage> detailpackages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detailtransaction> detailtransactions { get; set; }
        public virtual unit unit { get; set; }
    }
}
