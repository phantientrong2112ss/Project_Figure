using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class bills_ban
    {
        public int id { get; set; }

        public int? id_kh { get; set; }

        public DateTime? date_order { get; set; }

        public double? tong_tien { get; set; }

        public string payment { get; set; }

    
        public string status { get; set; }

        public string note { get; set; }
    }
}
