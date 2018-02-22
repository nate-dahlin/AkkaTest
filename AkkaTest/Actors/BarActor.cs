using Akka.Actor;
using AkkaTest.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaTest.Actors
{
    public class BarActor : ReceiveActor
    {
        public static Props Props()
        {
            return Akka.Actor.Props.Create(() => new BarActor());
        }
        public BarActor()
        {
            Receive<string>(m => OnReceiveString(m));
            Receive<DelayResponse>(m => OnReceiveDelayResponse(m));
        }

        private void OnReceiveDelayResponse(DelayResponse m)
        {
            var newMessage = new ResponseDelayed($"{m.Message}|||{Self.Path.Name} adding to the message");            
            
            Sender.Tell(newMessage);
        }

        private void OnReceiveString(string m)
        {
            var newMessage = $"{m}|||{Self.Path.Name} adding to the message";
            
            Sender.Tell(newMessage);            
        }
    }
}
