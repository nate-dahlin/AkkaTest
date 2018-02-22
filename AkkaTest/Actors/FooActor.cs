using Akka.Actor;
using AkkaTest.Controllers;
using AkkaTest.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaTest.Actors
{
    public class FooActor : ReceiveActor
    {
        public static Props Props()
        {
            return Akka.Actor.Props.Create(() => new FooActor());
        }

        private IActorRef barActor; //This could be passed in by Props but wanted ActorSelection since that is what our real app does
        public FooActor()
        {
            Receive<string>(m => OnReceiveString(m));
            Receive<DelayResponse>(m => OnReceiveDelayResponse(m));
            
            barActor = Context.System.ActorSelection($"user/bar").ResolveOne(TimeSpan.FromSeconds(10)).Result;
        }

        private void OnReceiveDelayResponse(DelayResponse m)
        {
            var newMessage = new DelayResponse($"{m.Message}|||{Self.Path.Name} adding to the message");
            
            barActor.Tell(newMessage, Sender); //passing along Sender so the reply goes back to the MVC controller
            Self.Tell(PoisonPill.Instance); //this tells itself a message to shutdown so this instance of the actor is removed
        }

        private void OnReceiveString(string m)
        {            
            var newMessage = $"{m}|||{Self.Path.Name} adding to the message";

            barActor.Tell(newMessage, Sender); //passing along Sender so the reply goes back to the MVC controller

            Self.Tell(PoisonPill.Instance); //this tells itself a message to shutdown so this instance of the actor is removed
        }        
    }
}
