using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace StyleServer
{
    class ServerSocket
    {

        public SocketType soctype;
        public ProtocolType protype;
       
        //Constructor
        public ServerSocket(SocketType stype, ProtocolType ptype)
        {
            //Create test socket

            soctype = stype;
            protype = ptype;

        }

        public void printError(Exception e)
        {
            System.Console.WriteLine(e.ToString());
            System.Console.In.Read();
        }
        public void StartListening()
        {

            try
            {

                Socket listensocket = new Socket(soctype, protype); //Create Socket

                IPAddress hostIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork); //Get our IP
                IPEndPoint ep = new IPEndPoint(hostIP, 50053); //create our end point
                System.Console.WriteLine(hostIP);  //display IP
                //  System.Console.In.Read();  //Hold for input
                listensocket.Bind(ep);  //Bind


                //     byte[] bytesend = new byte[256];
                //     System.Buffer.BlockCopy("Test".ToCharArray(), 0, bytesend, 0, "Test".Length);
                //    Socket sendsock = new Socket(soctype, protype); //test send socket


                byte[] bytes = new byte[256];



                for (; true; )
                {
                    // sendsock.SendTo(bytesend, ep);
                    listensocket.Receive(bytes);  //recive
                    Console.WriteLine(Encoding.UTF8.GetString(bytes));
                    bytes = new byte[256];
                }
            }
            catch (Exception e)
            {
                printError(e);
            }

            System.Console.WriteLine("Press to Advance!");
            System.Console.In.Read();
        }
    }
}
