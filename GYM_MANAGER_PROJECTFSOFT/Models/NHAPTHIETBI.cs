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
    
    public partial class NHAPTHIETBI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAPTHIETBI()
        {
            this.KHOTHIETBI = new HashSet<KHOTHIETBI>();
        }
    
        public int MaYeuCauNhap { get; set; }
        public string TenThietBi { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string HinhThietBi { get; set; }
        public Nullable<System.DateTime> NgayYeuCau { get; set; }
        public Nullable<int> MaTaiKhoan { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> MaLoaiThietBi { get; set; }
        public Nullable<bool> TrangThaiNhapThietBi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHOTHIETBI> KHOTHIETBI { get; set; }
        public virtual LOAITHIETBI LOAITHIETBI { get; set; }
        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
