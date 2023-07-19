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
    public class dtbillbanController : ControllerBase
    {
        HandleBBDT db;
        public dtbillbanController(IConfiguration configuration)
        {
            string t = configuration["ConnectionStrings:DefaultConnection"];
            db = new HandleBBDT(t);
        }
        string msg = string.Empty;
        // GET: api/<dtbillbanController>
        [HttpGet]
        public List<bill_detail_ban> Get()
        {
            List<bill_detail_ban> list = db.GAAGI(0, "getall");
            return list;
        }

        // GET api/<dtbillbanController>/5
        [HttpGet("{id}")]
        public List<bill_detail_ban> Get(int id)
        {

            List<bill_detail_ban> list = db.GAAGI(id, "getid");
            return list;
        }

        [HttpGet("Getsdtbb/{id}")]
        public List<bill_detail_ban> Getdtbbb(int id)
        {
            bill_detail_ban loai = new bill_detail_ban();
            string type = "getsbyid";
            loai.id_bill_ban = id;
            DataSet ds = db.Gdtbbbyid(loai, out msg, type);
            List<bill_detail_ban> list = new List<bill_detail_ban>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new bill_detail_ban
                {
                    id = Convert.ToInt32(dr["id"]),
                    id_bill_ban = Convert.ToInt32(dr["id_bill_ban"]),
                    id_sp = Convert.ToInt32(dr["id_sp"]),
                    unit_prices = Convert.ToInt32(dr["unit_prices"]),
                    sl = Convert.ToInt32(dr["sl"]),
                    name = dr["name"].ToString(),
                    image = dr["image"].ToString()
                });
            }
            return list;
        }

        // POST api/<dtbillbanController>
        [HttpPost]
        public string Post([FromBody] bill_detail_ban bdb)
        {
            try
            {
                return db.CUD(bdb, "insert");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<dtbillbanController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] bill_detail_ban bdb)
        {
            try
            {
                bdb.id = id;
                return db.CUD(bdb, "update");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE api/<dtbillbanController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                bill_detail_ban bdb = new bill_detail_ban();
                bdb.id = id;
                bdb.id_bill_ban = 0;
                bdb.id_sp = 0;
                bdb.unit_prices = 0;
                bdb.sl = 0;
                return db.CUD(bdb, "delete");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
