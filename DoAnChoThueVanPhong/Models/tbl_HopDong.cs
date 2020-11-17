namespace DoAnChoThueVanPhong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_HopDong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_HopDong()
        {
            tbl_ChiTietHopDong = new HashSet<tbl_ChiTietHopDong>();
            tbl_HoaDon = new HashSet<tbl_HoaDon>();
        }

        [Key]
        [StringLength(15)]
        public string MaHopDong { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKhachHang { get; set; }

        [Required]
        [StringLength(15)]
        public string MaVanPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        public double TienCoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime ThoiGianThue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ChiTietHopDong> tbl_ChiTietHopDong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_HoaDon> tbl_HoaDon { get; set; }

        public virtual tbl_KhachHang tbl_KhachHang { get; set; }

        public virtual tbl_NhanVien tbl_NhanVien { get; set; }
    }
}
