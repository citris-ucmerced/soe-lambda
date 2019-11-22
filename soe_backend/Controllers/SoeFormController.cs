using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Newtonsoft.Json.Linq;

namespace soe_backend.Controllers
{
    [Route("api/[controller]")]
    public class SoeFormController : Controller
    {
        private const string bucketName = "soe-form-data";
        private const string keyName = "*** object key ***";
        
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest1;
        private static IAmazonS3 client;

        public SoeFormController()
        {
            client = new AmazonS3Client(bucketRegion);
        }

        [HttpGet]
        public string GetForm()
        {
            // Get most recent form from S3 bucket, parse and return as JSON
            return "Form Data From S3";
        }

        [HttpPost]
        public JObject PostFormData([FromBody] JObject data)
        {
            // Get exisitng soe-form-data csv and append new 
            return data;
        }
    }
}
