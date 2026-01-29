using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanCaPhe.Data
{
    public class NhanVien
    {
        public string MaNV { get; set; } = null!;
        public string? HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }

        public string? ChucVu { get; set; }
        public decimal? LuongCoBan { get; set; }
        public string? TrangThai { get; set; }

        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
        public virtual ObservableCollectionListSource<ChamCong> ChamCong { get; } = new();
        public virtual ObservableCollectionListSource<BangLuong> BangLuong { get; } = new();
        public virtual TaiKhoan? TaiKhoan { get; set; }
    }
}
