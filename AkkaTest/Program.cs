using Akka.Actor;
using AkkaTest.Actors;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AkkaTest
{
    class Program
    {
        static void Main(string[] args)
        {            
            var url = "http://+:12345";

            using (var actorSystem = ActorSystem.Create("CoolSystem"))
            {                
                var app = WebHost.CreateDefaultBuilder(args)
                    .ConfigureServices((services) =>
                    {
                        var sa = new SystemActors()
                        {
                            HealthCheckActor = actorSystem.ActorOf(HealthCheckActor.Props(), "healthCheck"),
                            FooCoordinatorActor = actorSystem.ActorOf(FooCoordinatorActor.Props(), "fooCoordinator"),
                            BarActor = actorSystem.ActorOf(BarActor.Props(), "bar")
                        };
                        services.AddSingleton(sa);
                    })
                    .UseStartup<Startup>()
                    .UseUrls(url)
                    .Build();

                app.Run();               
            }
        }
    }
}
