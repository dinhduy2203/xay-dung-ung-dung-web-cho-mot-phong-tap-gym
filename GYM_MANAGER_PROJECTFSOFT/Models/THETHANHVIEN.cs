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
    
    public partial class THETHANHVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THETHANHVIEN()
        {
            this.THANHVIEN = new HashSet<THANHVIEN>();
        }
    
        public int MaTheThanhVien { get; set; }
        public string TenThe { get; set; }
        public string CodeThe { get; set; }
        public Nullable<int> MaDangKyGoiTap { get; set; }
        public Nullable<System.DateTime> NgayDangKy { get; set; }
        public Nullable<System.DateTime> NgayHetHan { get; set; }
        public Nullable<int> MaLoaiTheThanhVien { get; set; }
        public Nullable<System.DateTime> TamNgung { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual DANGKYGOITAP DANGKYGOITAP { get; set; }
        public virtual LOAITHETHANHVIEN LOAITHETHANHVIEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANHVIEN> THANHVIEN { get; set; }
    }
}
