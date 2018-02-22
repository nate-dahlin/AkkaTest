using Akka.Actor;
using AkkaTest.Actors;
using AkkaTest.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AkkaTest.Controllers
{
    public class FooBarController : Controller
    {
        private SystemActors _systemActors;

        public FooBarController(SystemActors systemActors)
        {
            _systemActors = systemActors;
        }

        [Route("/api/foobar/{message}")]
        [HttpGet]
        public string GetWithActor(string message)
        {
            var newMessage = $"MVC Contoller says: {message}";

            var response = _systemActors.FooCoordinatorActor.Ask<string>(newMessage).Result;

            return response;
        }

        [Route("/api/foobar/delay/{message}")]
        [HttpGet]
        public string GetWithActorDelayed(string message)
        {
            var newMessage = new DelayResponse($"MVC Contoller (with delay) says: {message}");

            var response = _systemActors.FooCoordinatorActor.Ask<ResponseDelayed>(newMessage).Result;

            return response.Response;
        }

        [Route("/api/foobar/children")]
        [HttpGet]
        public IActionResult GetChildren()
        {
            var response = _systemActors.FooCoordinatorActor.Ask<List<string>>(GetFooChildren.Instance).Result;

            //if Bar had children we could aggregate them here. For now Bar is a long lived actor though

            return new ObjectResult(response);
        }        
    }
}
