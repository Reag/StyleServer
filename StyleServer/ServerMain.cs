using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Net.Sockets;
using System.Net;
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
            

            //Test Socket for debug
            byte[] bytesend = new byte[256];
            Socket sendsock = new Socket(soctype, protype); //test send socket
            IPAddress hostIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork); //Get our IP
            IPEndPoint ep = new IPEndPoint(hostIP, 50053); //create our end point
            for(;true;)
            {
                String str = Console.In.ReadLine();
                bytesend = Encoding.ASCII.GetBytes(str);
                sendsock.SendTo(bytesend,ep);
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
