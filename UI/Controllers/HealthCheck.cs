using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKUI
{    
    public class HealthCheck : Controller
    {     
        [Route("/api/healthcheck")]
        [HttpGet]
        public string Get()
        {
            return $"Running {DateTime.Now.ToLongTimeString()}";
        }        
    }
}
