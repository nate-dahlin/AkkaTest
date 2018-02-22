using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaTest.Messages
{
    public class ResponseDelayed
    {
        public ResponseDelayed(string response)
        {
            Response = response;
        }

        public string Response { get; private set; }
    }
}
