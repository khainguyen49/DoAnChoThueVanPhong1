namespace DoAnChoThueVanPhong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_VanPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_VanPhong()
        {
            tbl_ChiTietHopDong = new HashSet<tbl_ChiTietHopDong>();
            tbl_ChiTietHopDong1 = new HashSet<tbl_ChiTietHopDong>();
        }

        [Key]
        [StringLength(15)]
        public string MaVanPhong { get; set; }

        [Required]
        [StringLength(15)]
        public string TenVanPhong { get; set; }

        [Required]
        [StringLength(15)]
        public string TinhTrang { get; set; }

        public int Tang { get; set; }

        public double Gia { get; set; }

        [Required]
        [StringLength(10)]
        public string DVT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ChiTietHopDong> tbl_ChiTietHopDong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ChiTietHopDong> tbl_ChiTietHopDong1 { get; set; }
    }
}
