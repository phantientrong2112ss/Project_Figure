using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class san_pham
    {
        public int id { get; set; }
        public string name { get; set; }
        public int id_loai_sp { get; set; }
        public int id_ncc { get; set; }
        public string mota_sp { get; set; }
        public float unit_price { get; set; }
        public float gia_km { get; set; }
        public int so_luong { get; set; }
        public string image { get; set; }
        public string img2 { get; set; }
        public string img3 { get; set; }
        public string don_vi_tinh { get; set; }
        public int newss { get; set; }


    }
}
