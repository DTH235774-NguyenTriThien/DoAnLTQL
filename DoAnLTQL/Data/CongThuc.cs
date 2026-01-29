using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Data
{
    public class CongThuc
    {
        public int MaCT { get; set; }

        public string MaSP { get; set; } = null!;
        public string MaNL { get; set; } = null!;

        public decimal SoLuong { get; set; }
        public virtual SanPham SanPham { get; set; } = null!;
        public virtual NguyenLieu NguyenLieu { get; set; } = null!;
    }
}
