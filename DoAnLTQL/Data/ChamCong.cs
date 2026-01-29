using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Data
{
    public class ChamCong
    {
        public int MaCham { get; set; }

        public string MaNV { get; set; } = null!;
        public int? MaCa { get; set; }

        public DateTime NgayLam { get; set; }

        public DateTime? ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }

        public string? GhiChu { get; set; }

        public virtual NhanVien NhanVien { get; set; } = null!;
        public virtual CaLam? CaLam { get; set; }
    }
}
