using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Configuration;


namespace QuanLyQuanCaPhe.Data
{
    public class QLCPDbContext : DbContext
    {
        public DbSet<Ban> Ban { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public DbSet<SanPham> SanPham { get; set; }

        public DbSet<CongThuc> CongThuc { get; set; }

        public DbSet<NguyenLieu> NguyenLieu { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                ConfigurationManager.ConnectionStrings["QLCafeConnection"].ConnectionString
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ban>(entity =>
            {
                entity.ToTable("Ban");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.TenBan)
                      .IsRequired()
                      .HasMaxLength(200)
                      .HasDefaultValue("Bàn mới");

                entity.Property(e => e.TrangThai)
                      .IsRequired()
                      .HasMaxLength(100)
                      .HasDefaultValue("Trống");
            });


            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.ToTable("HoaDon");

                entity.HasKey(e => e.MaHD);

                entity.Property(e => e.MaHD)
                      .HasColumnType("char(8)")
                      .IsRequired();

                entity.Property(e => e.NgayLap)
                      .HasDefaultValueSql("getdate()");

                entity.Property(e => e.MaNV)
                      .HasColumnType("char(6)")
                      .IsRequired();

                entity.Property(e => e.MaKH)
                      .HasColumnType("char(6)");

                entity.Property(e => e.TongTien)
                      .HasColumnType("decimal(12,2)")
                      .HasDefaultValue(0);

                entity.Property(e => e.GiamGia)
                      .HasColumnType("decimal(18,2)");

                entity.Property(e => e.TrangThai)
                      .HasMaxLength(40)
                      .HasDefaultValue("Chưa thanh toán");

                entity.Property(e => e.GhiChu)
                      .HasMaxLength(510);

                // FK -> Ban
                entity.HasOne(d => d.Ban)
                      .WithMany(p => p.HoaDon)
                      .HasForeignKey(d => d.idBan)
                      .OnDelete(DeleteBehavior.NoAction);

                // FK -> KhachHang
                entity.HasOne(d => d.KhachHang)
                      .WithMany(p => p.HoaDon)
                      .HasForeignKey(d => d.MaKH)
                      .OnDelete(DeleteBehavior.NoAction);

                // FK -> NhanVien
                entity.HasOne(d => d.NhanVien)
                      .WithMany(p => p.HoaDon)
                      .HasForeignKey(d => d.MaNV)
                      .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.ToTable("ChiTietHoaDon");

                entity.HasKey(e => e.ChiTietID);

                entity.Property(e => e.ChiTietID)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.MaHD)
                      .HasColumnType("char(8)")
                      .IsRequired();

                entity.Property(e => e.MaSP)
                      .HasColumnType("char(6)")
                      .IsRequired();

                entity.Property(e => e.SoLuong)
                      .IsRequired();

                entity.Property(e => e.DonGia)
                      .HasColumnType("decimal(12,2)")
                      .IsRequired();

                // ThanhTien là computed column (SQL tính)
                entity.Property(e => e.ThanhTien)
                      .HasColumnType("decimal(23,2)")
                      .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.GhiChu)
                      .HasMaxLength(200);

                // FK -> HoaDon
                entity.HasOne(d => d.HoaDon)
                      .WithMany(p => p.ChiTietHoaDon)
                      .HasForeignKey(d => d.MaHD)
                      .OnDelete(DeleteBehavior.NoAction);

                // FK -> SanPham
                entity.HasOne(d => d.SanPham)
                      .WithMany(p => p.ChiTietHoaDon)
                      .HasForeignKey(d => d.MaSP)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.ToTable("SanPham");

                entity.HasKey(e => e.MaSP);

                entity.Property(e => e.MaSP)
                      .HasColumnType("char(6)")
                      .IsRequired();

                entity.Property(e => e.TenSP)
                      .IsRequired()
                      .HasMaxLength(300);

                entity.Property(e => e.LoaiSP)
                      .HasMaxLength(100);

                entity.Property(e => e.DonGia)
                      .HasColumnType("decimal(12,2)")
                      .HasDefaultValue(0);

                entity.Property(e => e.TrangThai)
                      .HasMaxLength(40)
                      .HasDefaultValue("Còn bán");

                entity.Property(e => e.ImagePath)
                      .HasMaxLength(510);
            });

            modelBuilder.Entity<CongThuc>(entity =>
            {
                entity.ToTable("CongThuc");

                entity.HasKey(e => e.MaCT);

                entity.Property(e => e.MaCT)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.MaSP)
                      .HasColumnType("char(6)")
                      .IsRequired();

                entity.Property(e => e.MaNL)
                      .HasColumnType("char(6)")
                      .IsRequired();

                entity.Property(e => e.SoLuong)
                      .HasColumnType("decimal(12,3)")
                      .IsRequired();

                // FK -> SanPham
                entity.HasOne(d => d.SanPham)
                      .WithMany(p => p.CongThuc)
                      .HasForeignKey(d => d.MaSP)
                      .OnDelete(DeleteBehavior.NoAction);

                // FK -> NguyenLieu
                entity.HasOne(d => d.NguyenLieu)
                      .WithMany(p => p.CongThuc)
                      .HasForeignKey(d => d.MaNL)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<NguyenLieu>(entity =>
            {
                entity.ToTable("NguyenLieu");

                entity.HasKey(e => e.MaNL);

                entity.Property(e => e.MaNL)
                      .HasColumnType("char(6)")
                      .IsRequired();

                entity.Property(e => e.TenNL)
                      .HasMaxLength(300);

                entity.Property(e => e.DonVi)
                      .HasMaxLength(60);

                entity.Property(e => e.SoLuongTon)
                      .HasColumnType("decimal(12,3)")
                      .HasDefaultValue(0);
            });

            modelBuilder.Entity<InventoryMovements>(entity =>
            {
                entity.ToTable("InventoryMovements");

                entity.HasKey(e => e.MovementID);

                entity.Property(e => e.MovementID)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.MaNL)
                      .HasColumnType("char(6)")
                      .IsRequired();

                entity.Property(e => e.ChangeQty)
                      .HasColumnType("decimal(12,3)")
                      .IsRequired();

                entity.Property(e => e.MovementType)
                      .HasMaxLength(510);

                entity.Property(e => e.RefMaHD)
                      .HasColumnType("char(8)");

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("getdate()");

                // FK -> NguyenLieu (CASCADE)
                entity.HasOne(d => d.NguyenLieu)
                      .WithMany(p => p.InventoryMovements)
                      .HasForeignKey(d => d.MaNL)
                      .OnDelete(DeleteBehavior.Cascade);

                // FK -> HoaDon (NO ACTION)
                entity.HasOne(d => d.HoaDon)
                      .WithMany(p => p.InventoryMovements)
                      .HasForeignKey(d => d.RefMaHD)
                      .OnDelete(DeleteBehavior.NoAction);
            });


        }

    }
}
