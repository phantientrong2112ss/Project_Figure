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
    public class nccController : ControllerBase
    {
        HandleNCC db;
        public nccController(IConfiguration configuration)
        {
            string t = configuration["ConnectionStrings:DefaultConnection"];
            db = new HandleNCC(t);
        }
        string msg = string.Empty;
        // GET: api/<nccController>
        [HttpGet]
        public List<nha_cung_cap> Get()
        {
            List<nha_cung_cap> list = db.GAAGI(0, "getall");
            return list;
        }
        // GET api/<nccController>/5
        [HttpGet("{id}")]
        public List<nha_cung_cap> Get(int id)
        {
            List<nha_cung_cap> list = db.GAAGI(id, "getid");
            return list;
        }

        // POST api/<nccController>
        [HttpPost]
        public string Post([FromBody] nha_cung_cap ncc)
        {
            try
            {
                return db.CUD(ncc, "insert");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<nccController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] nha_cung_cap ncc)
        {
            try
            {
                ncc.id = id;
                return db.CUD(ncc, "update");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE api/<nccController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                nha_cung_cap ncc = new nha_cung_cap();
                ncc.id = id;
                ncc.ten_ncc = "";
                ncc.diachi_ncc = "";
                ncc.email = "";
                ncc.sdt = "";
                return db.CUD(ncc, "delete");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
