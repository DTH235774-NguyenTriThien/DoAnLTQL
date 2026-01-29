using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Data
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; } = null!;
        public string MatKhauHash { get; set; } = null!;

        public string? Role { get; set; }
        public string? MaNV { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual NhanVien? NhanVien { get; set; }
    }
}
