using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WA_FigureBSZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UIController : ControllerBase
    {
        // GET: api/<UIController>
        public static IWebHostEnvironment _environment;
        public UIController(IWebHostEnvironment environment) 
        {
            _environment = environment;
        }
        public class FileUIAPI
        {
            public IFormFile files { get; set; }
        }
        [HttpPost]
        //[FromForm]
        public async Task<string> ULA([FromForm] FileUIAPI obf)
        {
               
                if (obf.files.Length > 0)
                {
                    try
                    {
                        if (!Directory.Exists(_environment.WebRootPath + "\\uploadi\\"))
                        {
                            Directory.CreateDirectory(_environment.WebRootPath + "\\uploadi\\");
                        }
                        using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\uploadi\\" + obf.files.FileName))
                        {
                            obf.files.CopyTo(fileStream);
                            fileStream.Flush();
                            return "\\uploadi\\" + obf.files.FileName;
                        }
                    }

                    catch (Exception ex)
                    {

                        return ex.Message.ToString();
                    }
                }
                else
                    return "Failed";
            
        }
    }
}
