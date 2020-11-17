namespace DoAnChoThueVanPhong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_HoaDon
    {
        [Key]
        [StringLength(20)]
        public string MaHoaDon { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhanVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        [Required]
        [StringLength(50)]
        public string NoiDung { get; set; }

        public double ThanhTien { get; set; }

        [StringLength(10)]
        public string MaKhachHang { get; set; }

        [StringLength(15)]
        public string MaHopDong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTra { get; set; }

        [StringLength(50)]
        public string HoTenKhach { get; set; }

        public double? GiaPhong { get; set; }

        public virtual tbl_NhanVien tbl_NhanVien { get; set; }

        public virtual tbl_HopDong tbl_HopDong { get; set; }
    }
}
