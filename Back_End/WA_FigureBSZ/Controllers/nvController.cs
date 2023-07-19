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
    public class nvController : ControllerBase
    {
        HandleNV db;
        public nvController(IConfiguration configuration)
        {
            string t = configuration["ConnectionStrings:DefaultConnection"];
            db = new HandleNV(t);
        }
        string msg = string.Empty;
        // GET: api/<nvController>
        [HttpGet]
        public List<nhan_vien> Get()
        {
            List<nhan_vien> list = db.GAAGI(0, "getall");
            return list;
        }

        // GET api/<nvController>/5
        [HttpGet("{id}")]
        public List<nhan_vien> Get(int id)
        {
            List<nhan_vien> list = db.GAAGI(id, "getid");
            return list;
        }

        // POST api/<nvController>
        [HttpPost]
        public string Post([FromBody] nhan_vien nv)
        {
            try
            {
                return db.CUD(nv, "insert");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<nvController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] nhan_vien nv)
        {
            try
            {
                nv.id = id;
                return db.CUD(nv, "update");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/<nvController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                nhan_vien nv = new nhan_vien();
                nv.id = id;
                nv.ten_nhanvien = "";
                nv.gioitinh = "";
                nv.ngaysinh = DateTime.Parse("1989-10-04");
                nv.quequan = "";
                nv.sdt = "";
                nv.email = "";
                nv.capbac = "";
                return db.CUD(nv, "delete");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
