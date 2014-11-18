using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Net.Sockets;
using StyleServer;



namespace StyleServer
{
    class ServerMain
    {
        static void Main(string[] args)
        {

            SocketType soctype = SocketType.Dgram;
            ProtocolType protype = ProtocolType.Udp;
            ServerSocket ssock = new ServerSocket(soctype,protype);//Create main listen socket

            Thread listenThread = new Thread(ssock.StartListening); //Start Listening on  a new thread 
            listenThread.Start(); 
            
            for(;true;)
            {
                Console.WriteLine("Hello!");
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
