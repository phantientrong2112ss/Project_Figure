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
    public class billbanController : ControllerBase
    {

        HandleBB db;
        public billbanController(IConfiguration configuration)
        {
            string t = configuration["ConnectionStrings:DefaultConnection"];
            db = new HandleBB(t);
        }
        string msg = string.Empty;
        // GET: api/<billbanController>
        [HttpGet]
        public List<bills_ban> Get()
        {
            List<bills_ban> list = db.GAAGI(0, "getall");
            return list;
        }
        [HttpGet("Getcurrentid")]
        public int Getcurrentid()
        {
            int crid=1;
            DataSet ds = db.Gidcbb(out msg);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    crid = Convert.ToInt32(dr["Column1"]);

                };
            };
            return crid;
        }
        // GET api/<billbanController>/5
        [HttpGet("{id}")]
        public List<bills_ban> Get(int id)
        {
            List<bills_ban> list = db.GAAGI(id, "getid");
            return list;
        }
        // POST api/<billbanController>
        [HttpPost]
        public string Post([FromBody] bills_ban bb)
        {
            try
            {
                return db.CUD(bb, "insert");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<billbanController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] bills_ban bb)
        {
            try
            {
                bb.id = id;
                return db.CUD(bb, "update");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE api/<billbanController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                bills_ban bb = new bills_ban();
                bb.id = id;
                bb.id_kh = 0;
                bb.date_order = DateTime.Parse("1989-10-04");
                bb.tong_tien = 0;
                bb.payment = "";
                bb.status = "";
                bb.note = "";
                return db.CUD(bb, "delete");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
