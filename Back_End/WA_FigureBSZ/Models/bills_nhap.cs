using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class bills_nhap
    {
        public int id { get; set; }

        public int? id_ncc { get; set; }

        public int id_nhanvien { get; set; }

        public DateTime? date_order { get; set; }

        public double? tong_tien { get; set; }

        public string thanh_toan { get; set; }

        public string note { get; set; }
    }
}
