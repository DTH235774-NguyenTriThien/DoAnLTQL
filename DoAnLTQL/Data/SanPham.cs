using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanCaPhe.Data
{
    public class SanPham
    {
        public string MaSP { get; set; } = null!;
        public string TenSP { get; set; } = null!;
        public string? LoaiSP { get; set; }

        public decimal DonGia { get; set; }
        public string? TrangThai { get; set; }
        public string? ImagePath { get; set; }

        public virtual ObservableCollectionListSource<ChiTietHoaDon> ChiTietHoaDon { get; } = new();
        public virtual ObservableCollectionListSource<CongThuc> CongThuc { get; } = new();
    }
}
