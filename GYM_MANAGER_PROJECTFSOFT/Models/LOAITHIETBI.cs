//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GYM_MANAGER_PROJECTFSOFT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LOAITHIETBI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAITHIETBI()
        {
            this.NHAPTHIETBI = new HashSet<NHAPTHIETBI>();
            this.THIETBI = new HashSet<THIETBI>();
        }
    
        public int MaLoaiThietBi { get; set; }
        public string TenLoaiThietBi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHAPTHIETBI> NHAPTHIETBI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THIETBI> THIETBI { get; set; }
    }
}
