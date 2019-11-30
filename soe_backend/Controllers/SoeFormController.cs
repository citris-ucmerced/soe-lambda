using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Newtonsoft.Json.Linq;
using System.IO;


namespace soe_backend.Controllers
{
    [Route("api/[controller]")]
    public class SoeFormController : Controller
    {
        [HttpGet]
        public async Task<string> GetForm()
        {
            try
            {
                SQLHandler.ExecuteQuery("SELECT * FROM dbo.Forms");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return "GetForm";
        }

        [HttpPost]
        public async Task<JObject> PostFormData([FromBody] JObject data)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return data;
        }
    }
}