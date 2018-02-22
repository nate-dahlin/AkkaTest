using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace DKUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://*:12346")                
                .UseStartup<Startup>()
                .UseWebRoot("dist")
                .Build();

            host.Run();            
        }
    }
}
