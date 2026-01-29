using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanCaPhe.Data
{
    public class Ban
    {
        public int ID { get; set; }
        public string TenBan { get; set; } = null!;
        public string TrangThai { get; set; } = null!;

        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
    }
}
