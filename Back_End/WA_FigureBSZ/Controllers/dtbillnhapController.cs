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
    public class dtbillnhapController : ControllerBase
    {
        HandleBNDT db;
        public dtbillnhapController(IConfiguration configuration)
        {
            string t = configuration["ConnectionStrings:DefaultConnection"];
            db = new HandleBNDT(t);
        }
        string msg = string.Empty;
        // GET: api/<dtbillnhapController>
        [HttpGet]
        public List<bill_detail_nhap> Get()
        {
            List<bill_detail_nhap> list = db.GAAGI(0, "getall");
            return list;
        }

        // GET api/<dtbillnhapController>/5
        [HttpGet("{id}")]
        public List<bill_detail_nhap> Get(int id)
        {
            List<bill_detail_nhap> list = db.GAAGI(id, "getid");
            return list;
        }

        [HttpGet("Getsdtbn/{id}")]
        public List<bill_detail_nhap> Getdtbnn(int id)
        {
            bill_detail_nhap loai = new bill_detail_nhap();
            string type = "getsbyid";
            loai.id_bill_nhap = id;
            DataSet ds = db.Gdtbnbyid(loai, out msg, type);
            List<bill_detail_nhap> list = new List<bill_detail_nhap>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new bill_detail_nhap
                {
                    id = Convert.ToInt32(dr["id"]),
                    id_bill_nhap = Convert.ToInt32(dr["id_bill_nhap"]),
                    id_sp = Convert.ToInt32(dr["id_sp"]),
                    sl = Convert.ToInt32(dr["sl"]),
                    don_vi = dr["don_vi"].ToString(),
                    name = dr["name"].ToString(),
                    image = dr["image"].ToString(),
                    unit_price= Convert.ToInt32(dr["unit_price"])
                });
            }
            return list;
        }
        // POST api/<dtbillnhapController>
        [HttpPost]
        public string Post([FromBody] bill_detail_nhap bdn)
        {
            try
            {
                return db.CUD(bdn, "insert");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<dtbillnhapController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] bill_detail_nhap bdn)
        {
            try
            {
                bdn.id = id;
                return db.CUD(bdn, "update");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE api/<dtbillnhapController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                bill_detail_nhap bdn = new bill_detail_nhap();
                bdn.id = id;
                bdn.id_bill_nhap = 0;
                bdn.id_sp = 0;
                bdn.sl = 0;
                bdn.don_vi = "";
                return db.CUD(bdn, "delete");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
