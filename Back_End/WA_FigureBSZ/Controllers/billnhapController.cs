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
    public class billnhapController : ControllerBase
    {
        HandleBN db;
        public billnhapController(IConfiguration configuration)
        {
            string t = configuration["ConnectionStrings:DefaultConnection"];
            db = new HandleBN(t);
        }       
        // GET: api/<billnhapController>
        [HttpGet]
        public List<bills_nhap> Get()
        {
            List<bills_nhap> list = db.GAAGI(0, "getall");
            return list;
        }

        // GET api/<billnhapController>/5
        [HttpGet("{id}")]
        public List<bills_nhap> Get(int id)
        {
            List<bills_nhap> list = db.GAAGI(id, "getid");
            return list;
        }

        // POST api/<billnhapController>
        [HttpPost]
        public string Post([FromBody] bills_nhap bn)
        {
            try
            {
                return db.CUD(bn, "insert");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<billnhapController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] bills_nhap bn)
        {
            try
            {
                bn.id = id;
                return db.CUD(bn, "update");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/<billnhapController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                bills_nhap bn = new bills_nhap();
                bn.id = id;
                bn.id_ncc = 0;
                bn.id_nhanvien = 0;
                bn.date_order = DateTime.Parse("1989-10-04");
                bn.tong_tien = 0;
                bn.thanh_toan = "";
                bn.note = "";
                return db.CUD(bn, "delete");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
