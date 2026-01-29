using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Data
{
    public class BangLuong
    {
        public int MaLuong { get; set; }

        public string MaNV { get; set; } = null!;
        public int Thang { get; set; }
        public int Nam { get; set; }

        public decimal? TongGio { get; set; }
        public decimal? LuongThucTe { get; set; }
        public string? TrangThai { get; set; }
        public virtual NhanVien NhanVien { get; set; } = null!;
    }
}
