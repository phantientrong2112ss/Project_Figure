using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class bill_detail_nhap
    {
        public int id { get; set; }

        public int id_bill_nhap { get; set; }

        public int id_sp { get; set; }

        public int sl { get; set; }

        public string don_vi { get; set; }

        public string name { get; set; }

        public string image { get; set; }
        
        public int unit_price { get; set; }
    }
}
