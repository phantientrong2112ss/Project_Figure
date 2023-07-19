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
    public class tkController : ControllerBase
    {
        HandleTK db;
        public tkController(IConfiguration configuration)
        {
            string t = configuration["ConnectionStrings:DefaultConnection"];
            db = new HandleTK(t);
        }
        string msg = string.Empty;
        // GET: api/<tkController>
        [HttpGet]
        public List<user> Get()
        {
            List<user> list = db.GAAGI(0, "getall");
            return list;
        }

        // GET api/<tkController>/5
        [HttpGet("{id}")]
        public List<user> Get(int id)
        {
            List<user> list = db.GAAGI(id, "getid");
            return list;
        }
        // POST api/<tkController>
        [HttpPost]
        public string Post([FromBody] user us)
        {
            try
            {
                return db.CUD(us, "insert");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // PUT api/<tkController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] user us)
        {
            try
            {
                us.id = id;
                return db.CUD(us, "update");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/<tkController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                user us = new user();
                us.id = id;
                us.full_name = "";
                us.users_name = "";
                us.email = "";
                us.password = "";
                us.phone = "";
                us.address = "";
                us.image = "";
                //us.Delet = 0;
                us.remember_token = "";
                return db.CUD(us, "delete");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
