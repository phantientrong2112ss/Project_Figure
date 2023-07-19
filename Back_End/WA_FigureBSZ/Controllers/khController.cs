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
    public class khController : ControllerBase
    {
        HandleKH db;
        public khController(IConfiguration configuration)
        {
            string t = configuration["ConnectionStrings:DefaultConnection"];
            db = new HandleKH(t);
        }
        string msg = string.Empty;
        // GET: api/<khController>
        [HttpGet]
        public List<khach_hang> Get()
        {
            List<khach_hang> list = db.GAAGI(0, "getall");
            return list;
        }

        // GET api/<khController>/5
        [HttpGet("{id}")]
        public List<khach_hang> Get(int id)
        {
            List<khach_hang> list = db.GAAGI(id, "getid");
            return list;
        }

        // POST api/<khController>
        [HttpPost]
        public string Post([FromBody] khach_hang kh)
        {
            try
            {
                return db.CUD(kh, "insert");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<khController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] khach_hang kh)
        {
            try
            {
                kh.id = id;
                return db.CUD(kh, "update");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE api/<khController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                khach_hang kh = new khach_hang();
                kh.id = id;
                kh.ten_kh = "";
                kh.email = "";
                kh.dia_chi = "";
                kh.sdt = "";
                return db.CUD(kh, "delete");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
