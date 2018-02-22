using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaTest.Messages
{
    public class DelayResponse
    {
        public DelayResponse(string message)
        {
            Message = message;
        }

        public string Message { get; } //these dont have a public setter since they are immutable
    }
}
