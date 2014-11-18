using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleServer
{
    class MessageHandler /* This class is the work horse of the actual message. It browses the message and calls the relevant methods */
    {
        byte[] bytes;

        public MessageHandler(byte[] bytess)
        {
            bytes = bytess;
        }
        public void Start()
        {
            String str = System.Text.Encoding.UTF8.GetString(bytes);
            if(str.Contains("Name:"))  //what do we do if we have the Name:
            {
                bool stringError = false;
                int startchar = "Name:".Length + str.IndexOf("Name:"); //setup offset of first occurence
                if(startchar < 5) //if this string doesnt occur
                {
                    stringError=true;
                }
                int endchar = str.IndexOf("*",startchar); //find kill character
                if(endchar < 0 || endchar < startchar) //if the end character doesnt occur
                {
                    stringError=true;
                }
                if(!stringError)
                {
                    Console.WriteLine(startchar);  //debug
                    Console.WriteLine(endchar);    //debug
                    Console.WriteLine(str.Substring(startchar, endchar-startchar)); //Find the marked name
                }
            }
        }
    }
}
