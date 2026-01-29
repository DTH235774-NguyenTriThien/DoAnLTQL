using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanCaPhe.Data
{
    public class CaLam
    {
        public int MaCa { get; set; }

        public string? TenCa { get; set; }

        public TimeSpan? GioBatDau { get; set; }
        public TimeSpan? GioKetThuc { get; set; }

        public virtual ObservableCollectionListSource<ChamCong> ChamCong { get; } = new();
    }
}
