using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaTest.Actors
{
    public class HealthCheckActor : ReceiveActor
    {
        public static Props Props()
        {
            return Akka.Actor.Props.Create(() => new HealthCheckActor());
        }

        public HealthCheckActor()
        {
            Receive<string>(m => Sender.Tell($"{m} from akka.net at {DateTime.Now.ToLongTimeString()}"));
        }
    }
}
