using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaPhe.Data
{
    public class InventoryMovements
    {
        public int MovementID { get; set; }

        public string MaNL { get; set; } = null!;
        public decimal ChangeQty { get; set; }

        public string? MovementType { get; set; }
        public string? RefMaHD { get; set; }

        public DateTime? CreatedAt { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; } = null!;
        public virtual HoaDon? HoaDon { get; set; }
    }
}
