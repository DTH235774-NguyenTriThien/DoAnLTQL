using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Data
{
    public class ChiTietHoaDon
    {
        public int ChiTietID { get; set; }

        public string MaHD { get; set; } = null!;
        public string MaSP { get; set; } = null!;

        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal? ThanhTien { get; set; }
        public string? GhiChu { get; set; }

        public virtual HoaDon HoaDon { get; set; } = null!;
        public virtual SanPham SanPham { get; set; } = null!;
    }
}
