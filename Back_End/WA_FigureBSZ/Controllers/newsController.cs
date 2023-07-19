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
    public class newsController : ControllerBase
    {
        HandleNews db;
        public newsController(IConfiguration configuration)
        {
            string t = configuration["ConnectionStrings:DefaultConnection"];
            db = new HandleNews(t);
        }
        string msg = string.Empty;
        // GET: api/<newsController>
        [HttpGet]
        public List<news> Get()
        {
            List<news> list = db.GAAGI(0, "getall");
            return list;
        }

        // GET api/<newsController>/5
        [HttpGet("{id}")]
        public List<news> Get(int id)
        {
            List<news> list = db.GAAGI(id, "getid");
            return list;
        }

        // POST api/<newsController>
        [HttpPost]
        public string Post([FromBody] news nn)
        {
            try
            {
                return db.CUD(nn, "insert");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT api/<newsController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] news nn)
        {
            try
            {
                nn.id_new = id;
                return db.CUD(nn, "update");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/<newsController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                news loai = new news();
                loai.id_new = id;
                loai.title = "";
                loai.content = "";
                loai.image = "";
                return db.CUD(loai, "delete");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
