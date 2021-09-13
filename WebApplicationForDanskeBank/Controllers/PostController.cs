using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationForDanskeBank.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        // GET: api/<controller>
        //[HttpPost("[controller]/[action]")]
        [HttpPost("[action]")]
        [Consumes("multipart/form-data")]
        public ActionResult UploadFile(IFormFile Files, string param)
        {

            long size = Files.Length;
            var tempPath = Path.GetTempFileName();
            string file_Extension = Path.GetExtension(Files.FileName);
           // var isValidFile = FileValidation.FileUploadValidation(Files);
            //if (isValidFile.data)
            //{
                string filename = Guid.NewGuid() + "" + file_Extension;
                return null;

            //}
            //else
            //{
            //    return null;
            //}
        }
        public class FileValidation
        {
            public IFormFile File { get; set; }
            public string Param { get; set; }
        }
        

        // GET api/<controller>       
        [HttpGet("[action]")]
        public string Get()
        {
            
            StreamReader sr = new StreamReader("C:\\WebApplicationForDanskeBank\\Result.txt");
            string lines = sr.ReadToEnd();
            return lines;
        }

       
    }
}
