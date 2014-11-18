using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleServer
{
    class MessageHandler /* This class is the workhorse of the actual message. It browses the message and calls the relevant methods */
    {
        byte[] bytes;

        public MessageHandler(byte[] bytess)
        {
            bytes = bytess;
        }
        public void Start()
        {

        }
    }
}
