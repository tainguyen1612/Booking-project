//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLKS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblNhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblNhanVien()
        {
            this.tblHoaDons = new HashSet<tblHoaDon>();
        }
    
        public int ma_nv { get; set; }
        public string ho_ten { get; set; }
        public Nullable<System.DateTime> ngay_sinh { get; set; }
        public string dia_chi { get; set; }
        public string sdt { get; set; }
        public string tai_khoan { get; set; }
        public string mat_khau { get; set; }
        public Nullable<int> ma_chuc_vu { get; set; }
    
        public virtual tblChucVu tblChucVu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHoaDon> tblHoaDons { get; set; }
    }
}
