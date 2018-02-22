using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaTest.Actors
{
    public class SystemActors
    {
        public IActorRef HealthCheckActor = ActorRefs.Nobody;
        public IActorRef FooCoordinatorActor = ActorRefs.Nobody;
        public IActorRef BarActor = ActorRefs.Nobody;
    }
}


