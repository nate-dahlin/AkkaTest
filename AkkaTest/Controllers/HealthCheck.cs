using Akka.Actor;
using AkkaTest.Actors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaTest.Controllers
{    
    public class HealthCheck : Controller
    {
        private SystemActors _systemActors;

        public HealthCheck(SystemActors systemActors)
        {
            _systemActors = systemActors;
        }

        [Route("/api/healthcheck")]
        [HttpGet]
        public string Get()
        {
            return $"Running {DateTime.Now.ToLongTimeString()}";
        }

        [Route("/api/healthcheck/{message}")]
        [HttpGet]        
        public string GetWithActor(string message)
        {
            var response = _systemActors.HealthCheckActor.Ask<string>(message).Result;

            return response;
        }
    }
}
