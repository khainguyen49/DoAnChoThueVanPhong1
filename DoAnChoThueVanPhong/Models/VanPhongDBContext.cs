namespace DoAnChoThueVanPhong.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VanPhongDBContext : DbContext
    {
        public VanPhongDBContext()
            : base("name=ChuoiKN")
        {
        }

        public virtual DbSet<tbl_ChiTietHopDong> tbl_ChiTietHopDong { get; set; }
        public virtual DbSet<tbl_ChucVu> tbl_ChucVu { get; set; }
        public virtual DbSet<tbl_HoaDon> tbl_HoaDon { get; set; }
        public virtual DbSet<tbl_HopDong> tbl_HopDong { get; set; }
        public virtual DbSet<tbl_KhachHang> tbl_KhachHang { get; set; }
        public virtual DbSet<tbl_NhanVien> tbl_NhanVien { get; set; }
        public virtual DbSet<tbl_TaiKhoan> tbl_TaiKhoan { get; set; }
        public virtual DbSet<tbl_VanPhong> tbl_VanPhong { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_ChiTietHopDong>()
                .Property(e => e.MaChiTiet)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ChiTietHopDong>()
                .Property(e => e.MaVanPhong)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ChiTietHopDong>()
                .Property(e => e.MaHopDong)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ChucVu>()
                .Property(e => e.MaChucVu)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ChucVu>()
                .HasMany(e => e.tbl_NhanVien)
                .WithRequired(e => e.tbl_ChucVu)
                .HasForeignKey(e => e.MaChucVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_ChucVu>()
                .HasMany(e => e.tbl_NhanVien1)
                .WithRequired(e => e.tbl_ChucVu1)
                .HasForeignKey(e => e.MaChucVu);

            modelBuilder.Entity<tbl_HoaDon>()
                .Property(e => e.MaHoaDon)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HoaDon>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HoaDon>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HoaDon>()
                .Property(e => e.MaHopDong)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HopDong>()
                .Property(e => e.MaHopDong)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HopDong>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HopDong>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HopDong>()
                .Property(e => e.MaVanPhong)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HopDong>()
                .HasMany(e => e.tbl_ChiTietHopDong)
                .WithRequired(e => e.tbl_HopDong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_KhachHang>()
                .Property(e => e.MaKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_KhachHang>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_KhachHang>()
                .HasMany(e => e.tbl_HopDong)
                .WithRequired(e => e.tbl_KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_NhanVien>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_NhanVien>()
                .Property(e => e.MaChucVu)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_NhanVien>()
                .HasMany(e => e.tbl_HoaDon)
                .WithRequired(e => e.tbl_NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_NhanVien>()
                .HasMany(e => e.tbl_HopDong)
                .WithRequired(e => e.tbl_NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TaiKhoan>()
                .Property(e => e.Quyen)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TaiKhoan>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_VanPhong>()
                .Property(e => e.MaVanPhong)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_VanPhong>()
                .HasMany(e => e.tbl_ChiTietHopDong)
                .WithRequired(e => e.tbl_VanPhong)
                .HasForeignKey(e => e.MaVanPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_VanPhong>()
                .HasMany(e => e.tbl_ChiTietHopDong1)
                .WithRequired(e => e.tbl_VanPhong1)
                .HasForeignKey(e => e.MaVanPhong);
        }
    }
}
