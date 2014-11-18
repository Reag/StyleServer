using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

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

        Socket listensocket = new Socket(soctype, protype); //Create Socket

        IPAddress hostIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork); //Get our IP
        IPEndPoint ep = new IPEndPoint(hostIP, 50053); //create our end point
        System.Console.WriteLine("Creating a "+ protype.ToString() +" socket for " + hostIP + " on port 50053.");  //display IP
        listensocket.Bind(ep);  //Bind

        byte[] bytes = new byte[256];
        bool inBuffer;

        for (; true; )    //Main Network Listen Loop
        {
            inBuffer = true;
            try
            {
                listensocket.Receive(bytes);  //recive
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
                inBuffer = false;
            }
            if(inBuffer && isValidMessage(bytes))     //Check contents
            {
                System.Console.WriteLine("Valid Message containing: " + Encoding.UTF8.GetString(bytes, 0, bytes.Length));
                handleMessage(bytes);
            }   
            bytes = new byte[256];        //Clear message
        }
     

        System.Console.WriteLine("Press to Advance!");
        System.Console.In.Read();
        }


        public bool isValidMessage(byte[] bytes)
        {
            String message = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            if(true)
                return true;
           // System.Console.WriteLine("Invalid Message " + message);
            //return false;
        }

        public bool handleMessage(byte[] bytes) //handles the message, creates a thread, and returns true if no errors occur
        {
            try //attempt to make a new thread
            {
                MessageHandler msgh = new MessageHandler(bytes);
                Thread messageHandle = new Thread(msgh.Start); //Start Listening on  a new thread 
                messageHandle.Start(); //begin browsing the message
            } catch (Exception e)  //if we fail to create the thread, we do this:
            {
                System.Console.WriteLine(e.ToString());
            }

            return false;
        }

    }
}
