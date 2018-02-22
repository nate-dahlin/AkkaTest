using Akka.Actor;
using AkkaTest.Controllers;
using AkkaTest.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AkkaTest.Actors
{
    public class FooCoordinatorActor : ReceiveActor
    {
        public static Props Props()
        {
            return Akka.Actor.Props.Create(() => new FooCoordinatorActor());
        }

        public FooCoordinatorActor()
        {
            Receive<string>(m => OnReceiveString(m));
            Receive<DelayResponse>(m => OnReceiveDelayResponse(m));
            Receive<GetFooChildren>(_ => OnReceiveGetFooChildren());
        }

        private void OnReceiveDelayResponse(DelayResponse m)
        {
            var actor = CreateChild();            

            Context.System.Scheduler.ScheduleTellOnce(TimeSpan.FromSeconds(2),
                              actor,
                              m, Sender);            
        }

        private void OnReceiveGetFooChildren()
        {
            var children = Context.GetChildren().Select(c => c.Path.Name).ToList();
            Sender.Tell(children);
        }

        private void OnReceiveString(string m)
        {
            var actor = CreateChild();
            actor.Forward(m); //when forwarding a message you dont change it
        }

        private IActorRef CreateChild()
        {
            return Context.ActorOf(FooActor.Props(), $"fooActor-{Guid.NewGuid()}"); //names of Actors must be unique
        }
    }
}
