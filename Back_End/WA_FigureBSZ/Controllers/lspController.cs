using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WA_FigureBSZ.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WA_FigureBSZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class lspController : ControllerBase
    {
        HandleLSP db;
        public lspController(IConfiguration configuration)
        {
            string t = configuration["ConnectionStrings:DefaultConnection"];
            db = new HandleLSP(t);
        }
        string msg = string.Empty;
        // GET: api/<lspController>
        [HttpGet]
        //[Route("Getalllsp")]
        public List<loai_sp> Get()
        {
            List<loai_sp> list = db.GAAGI(0,"getall");
            return list;
        }
       
        // GET api/<lspController>/5
        [HttpGet("{id}")]
        public List<loai_sp> Get(int id)
        {
            List<loai_sp> list = db.GAAGI(id, "getid");
            return list;
        }

        // POST api/<lspController>
        [HttpPost]
        //[Authorize]
        //[Route("Create")]
        public void Post([FromBody] loai_sp loai)
        {
            //try
            //{
                 db.CUD(loai, "insert");
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}

        }

        // PUT api/<lspController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] loai_sp loai)
        {
            //try
            //{
                loai.id = id;
                db.CUD(loai, "update");
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
        }

        // DELETE api/<lspController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //try
            //{
                loai_sp loai = new loai_sp();
                loai.id = id;
                loai.tenloai = "";
                db.CUD(loai, "delete");

                //return db.CUD(loai, "delete");
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
        }






        //public List<loai_sp> Get()
        //{
        //    loai_sp loai = new loai_sp();
        //    string type = "getall";
        //    //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][1] != DBNull.Value)
        //    //{
        //    //    strReturn = Convert.ToString(ds.Tables[0].Rows[0][1]);
        //    //}
        //    DataSet ds = db.GAGTlsp(loai, out msg,type);
        //    List<loai_sp> list = new List<loai_sp>();
        //    if (ds != null)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            list.Add(new loai_sp
        //            {
        //                id = Convert.ToInt32(dr["id"]),
        //                tenloai = dr["tenloai"].ToString(),
        //                Delet = dr["delet"].ToString()
        //            });
        //        }
        //    };
        //    return list;
        //}
    }
}
