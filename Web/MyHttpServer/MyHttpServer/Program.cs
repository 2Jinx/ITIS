﻿using System.Net;
using System.Text;

namespace MyHttpServer
{
    class Program
    {
        static async Task Main()
        {
            Server server = new Server("battle.net");       // <- Тут необходимо ввести название
                                                            // html странички (google, battle.net)
            server.Start();
        }
    }
}
