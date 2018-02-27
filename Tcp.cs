using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace EasyConnection
{
    class Tcp
    {
        private static string Clean(string var) //Cleans the empty space from the buffer.
        {
            string returnValue = "";
            returnValue = var.Trim('\0');

            return returnValue;
        }

        private static void Send(string toSend, Socket client) //Sends byte to a socket
        {
            string command = toSend;
            byte[] buffer = new byte[command.Length];
            buffer = Encoding.ASCII.GetBytes(command);
            client.Send(buffer, 0, command.Length, SocketFlags.None);
        }
    }
}
