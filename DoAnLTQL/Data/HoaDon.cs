using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanCaPhe.Data
{
    public class HoaDon
    {
        public string MaHD { get; set; } = null!;
        public DateTime? NgayLap { get; set; }

        public string MaNV { get; set; } = null!;
        public string? MaKH { get; set; }

        public decimal? TongTien { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChu { get; set; }
        public decimal? GiamGia { get; set; }

        public int idBan { get; set; }
        public virtual Ban Ban { get; set; } = null!;
        public virtual KhachHang? KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; } = null!;

        public virtual ObservableCollectionListSource<ChiTietHoaDon> ChiTietHoaDon { get; } = new();
        public virtual ObservableCollectionListSource<InventoryMovements> InventoryMovements { get; } = new();
    }
}
