namespace DoAnChoThueVanPhong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ChiTietHopDong
    {
        [Key]
        [StringLength(10)]
        public string MaChiTiet { get; set; }

        [Required]
        [StringLength(15)]
        public string MaVanPhong { get; set; }

        [Required]
        [StringLength(15)]
        public string MaHopDong { get; set; }

        public double TienDatCoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        public virtual tbl_HopDong tbl_HopDong { get; set; }

        public virtual tbl_VanPhong tbl_VanPhong { get; set; }

        public virtual tbl_VanPhong tbl_VanPhong1 { get; set; }
    }
}
