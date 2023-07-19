using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WA_FigureBSZ.Models;
using System.Data;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WA_FigureBSZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class spController : ControllerBase
    {
        HandleSP db;
        public spController(IConfiguration configuration)
        {
            string t = configuration["ConnectionStrings:DefaultConnection"];
            db = new HandleSP(t);
        }
        string msg = string.Empty;
        // GET: api/<spController>
        [HttpGet]
        //[Route("Getallsp")]

        public List<san_pham> Get()
        {
            List<san_pham> list = db.GAAGI(0, "getall");
            return list;
        }
        // GET api/<spController>/5
        [HttpGet("{id}")]
        public List<san_pham> Get(int id)
        {
            List<san_pham> list = db.GAAGI(id, "getid");
            return list;
        }
        //// GET api/<spController>/5
        [HttpGet("Getspoflsp/{id}")]
        public List<san_pham> Getspbyidlsp(int id)
        {
            san_pham loai = new san_pham();
            string type = "getsbyid";
            loai.id_loai_sp = id;
            DataSet ds = db.Gbidlsp(loai, out msg, type);
            List<san_pham> list = new List<san_pham>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new san_pham
                {
                    id = Convert.ToInt32(dr["id"]),
                    name = dr["name"].ToString(),
                    id_loai_sp = Convert.ToInt32(dr["id_loai_sp"]),
                    id_ncc = Convert.ToInt32(dr["id_ncc"]),
                    mota_sp = dr["mota_sp"].ToString(),
                    unit_price = Convert.ToInt32(dr["unit_price"]),
                    gia_km = Convert.ToInt32(dr["gia_km"]),
                    so_luong = Convert.ToInt32(dr["so_luong"]),
                    image = dr["image"].ToString(),
                    img2 = dr["img2"].ToString(),
                    img3 = dr["img3"].ToString(),
                    don_vi_tinh = dr["don_vi_tinh"].ToString(),
                    //Delet = Convert.ToInt32(dr["Delet"]),
                    newss = Convert.ToInt32(dr["newss"])

                });
            }
            return list;
        }

        // POST api/<spController>
        [HttpPost]
        public string Post([FromBody] san_pham sp)
        {
            try
            {
                return db.CUD(sp, "insert");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<spController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] san_pham sp)
        {
            try
            {
                sp.id = id;
                return db.CUD(sp, "update");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE api/<spController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                san_pham sp = new san_pham();
                sp.id = id;
                sp.name = "";
                sp.id_loai_sp = 0;
                sp.id_ncc = 0;
                sp.mota_sp = "";
                sp.unit_price = 0;
                sp.gia_km = 0;
                sp.so_luong = 0;
                sp.image = "";
                sp.img2 = "";
                sp.img3 = "";
                sp.don_vi_tinh = "";
                sp.newss = 0;
                return db.CUD(sp, "delete");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
