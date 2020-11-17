namespace DoAnChoThueVanPhong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_TaiKhoan
    {
        [Key]
        [StringLength(20)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNhanVien { get; set; }

        [Required]
        [StringLength(20)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(10)]
        public string Quyen { get; set; }

        [StringLength(10)]
        public string MaNhanVien { get; set; }

        public virtual tbl_NhanVien tbl_NhanVien { get; set; }
    }
}
