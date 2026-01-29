using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyQuanCaPhe.Migrations
{
    /// <inheritdoc />
    public partial class KhoiTaoCSDL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ban",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: "Bàn mới"),
                    TrangThai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "Trống")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ban", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CaLam",
                columns: table => new
                {
                    MaCa = table.Column<int>(type: "int", nullable: false),
                    TenCa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GioBatDau = table.Column<TimeSpan>(type: "time", nullable: true),
                    GioKetThuc = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaLam", x => x.MaCa);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "char(6)", nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DiemTichLuy = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "NguyenLieu",
                columns: table => new
                {
                    MaNL = table.Column<string>(type: "char(6)", nullable: false),
                    TenNL = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    SoLuongTon = table.Column<decimal>(type: "decimal(12,3)", nullable: true, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguyenLieu", x => x.MaNL);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "char(6)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LuongCoBan = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0m),
                    TrangThai = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, defaultValue: "Đang làm")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "char(6)", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LoaiSP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    TrangThai = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, defaultValue: "Còn bán"),
                    ImagePath = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MaSP);
                });

            migrationBuilder.CreateTable(
                name: "BangLuong",
                columns: table => new
                {
                    MaLuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<string>(type: "char(6)", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    TongGio = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m),
                    LuongThucTe = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0m),
                    TrangThai = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, defaultValue: "Chưa trả")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangLuong", x => x.MaLuong);
                    table.ForeignKey(
                        name: "FK_BangLuong_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "ChamCong",
                columns: table => new
                {
                    MaCham = table.Column<int>(type: "int", nullable: false),
                    MaNV = table.Column<string>(type: "char(6)", nullable: false),
                    MaCa = table.Column<int>(type: "int", nullable: true),
                    NgayLam = table.Column<DateTime>(type: "date", nullable: false),
                    ClockIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClockOut = table.Column<DateTime>(type: "datetime", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamCong", x => x.MaCham);
                    table.ForeignKey(
                        name: "FK_ChamCong_CaLam_MaCa",
                        column: x => x.MaCa,
                        principalTable: "CaLam",
                        principalColumn: "MaCa");
                    table.ForeignKey(
                        name: "FK_ChamCong_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "char(8)", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    MaNV = table.Column<string>(type: "char(6)", nullable: false),
                    MaKH = table.Column<string>(type: "char(6)", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(12,2)", nullable: true, defaultValue: 0m),
                    TrangThai = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, defaultValue: "Chưa thanh toán"),
                    GhiChu = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: true),
                    GiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    idBan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDon_Ban_idBan",
                        column: x => x.idBan,
                        principalTable: "Ban",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH");
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    TenDangNhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MatKhauHash = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, defaultValue: "Nhân viên"),
                    MaNV = table.Column<string>(type: "char(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.TenDangNhap);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "CongThuc",
                columns: table => new
                {
                    MaCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSP = table.Column<string>(type: "char(6)", nullable: false),
                    MaNL = table.Column<string>(type: "char(6)", nullable: false),
                    SoLuong = table.Column<decimal>(type: "decimal(12,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongThuc", x => x.MaCT);
                    table.ForeignKey(
                        name: "FK_CongThuc_NguyenLieu_MaNL",
                        column: x => x.MaNL,
                        principalTable: "NguyenLieu",
                        principalColumn: "MaNL");
                    table.ForeignKey(
                        name: "FK_CongThuc_SanPham_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    ChiTietID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHD = table.Column<string>(type: "char(8)", nullable: false),
                    MaSP = table.Column<string>(type: "char(6)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(23,2)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => x.ChiTietID);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HoaDon",
                        principalColumn: "MaHD");
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_SanPham_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateTable(
                name: "InventoryMovements",
                columns: table => new
                {
                    MovementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNL = table.Column<string>(type: "char(6)", nullable: false),
                    ChangeQty = table.Column<decimal>(type: "decimal(12,3)", nullable: false),
                    MovementType = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: true),
                    RefMaHD = table.Column<string>(type: "char(8)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMovements", x => x.MovementID);
                    table.ForeignKey(
                        name: "FK_InventoryMovements_HoaDon_RefMaHD",
                        column: x => x.RefMaHD,
                        principalTable: "HoaDon",
                        principalColumn: "MaHD");
                    table.ForeignKey(
                        name: "FK_InventoryMovements_NguyenLieu_MaNL",
                        column: x => x.MaNL,
                        principalTable: "NguyenLieu",
                        principalColumn: "MaNL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BangLuong_MaNV",
                table: "BangLuong",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_ChamCong_MaCa",
                table: "ChamCong",
                column: "MaCa");

            migrationBuilder.CreateIndex(
                name: "IX_ChamCong_MaNV",
                table: "ChamCong",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MaHD",
                table: "ChiTietHoaDon",
                column: "MaHD");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MaSP",
                table: "ChiTietHoaDon",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_CongThuc_MaNL",
                table: "CongThuc",
                column: "MaNL");

            migrationBuilder.CreateIndex(
                name: "IX_CongThuc_MaSP",
                table: "CongThuc",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_idBan",
                table: "HoaDon",
                column: "idBan");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKH",
                table: "HoaDon",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaNV",
                table: "HoaDon",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_MaNL",
                table: "InventoryMovements",
                column: "MaNL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovements_RefMaHD",
                table: "InventoryMovements",
                column: "RefMaHD");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_MaNV",
                table: "TaiKhoan",
                column: "MaNV",
                unique: true,
                filter: "[MaNV] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BangLuong");

            migrationBuilder.DropTable(
                name: "ChamCong");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "CongThuc");

            migrationBuilder.DropTable(
                name: "InventoryMovements");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "CaLam");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "NguyenLieu");

            migrationBuilder.DropTable(
                name: "Ban");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");
        }
    }
}
