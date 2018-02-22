using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaTest.Messages
{
    public class GetFooChildren
    {
        public static GetFooChildren Instance = new GetFooChildren();

        private GetFooChildren() { }
    }
}
