using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WA_FigureBSZ.Models
{
    public class user
    {
        public int id { get; set; }

    
        public string full_name { get; set; }

        public string users_name { get; set; }


        public string email { get; set; }

        public string password { get; set; }

 
        public string phone { get; set; }


        public string address { get; set; }

        public string image { get; set; }
        public int capquyen { get; set; }

        public string remember_token { get; set; }
    }
}
