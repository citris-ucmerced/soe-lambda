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
        public string GetForm()
        {
            string sqlResult = "";
            try
            {
                sqlResult = SQLHandler.ExecuteQuery("SELECT * FROM dbo.Forms");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "Unable to execute query: " + ex;
            }
            return sqlResult;
        }

        [HttpPost]
        public string PostFormData([FromBody] string data)
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