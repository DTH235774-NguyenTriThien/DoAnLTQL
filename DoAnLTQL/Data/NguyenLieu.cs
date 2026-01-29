using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanCaPhe.Data
{
    public class NguyenLieu
    {
        public string MaNL { get; set; } = null!;
        public string? TenNL { get; set; }
        public string? DonVi { get; set; }

        public decimal? SoLuongTon { get; set; }

        // Navigation
        public virtual ObservableCollectionListSource<CongThuc> CongThuc { get; } = new();
        public virtual ObservableCollectionListSource<InventoryMovements> InventoryMovements { get; } = new();
    }
}
