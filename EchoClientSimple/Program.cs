using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;

namespace EchoClientSimple
{
    class Program
    {
        //SSL
        static bool leaveInnerStreamOpen = false;

        static void Main(string[] args)
        {
           
            Console.WriteLine("This is the client.");
            while (true)
            {
                bool condition = true;

                Console.WriteLine("Which message should be sent the server?");
                string message = Console.ReadLine();
                if(message == "exit")
                {
                    condition = false;
                }

                TcpClient socket = new TcpClient(/*("192.168.104.141")*/ "localhost", 7); //initializing client
                
                /* NetworkStream ns = socket.GetStream()*/; //processes the data received and sent. Must be separated into reader & writer

                //To use SSL
                Stream unsecureStream = socket.GetStream();
                SslStream sslStream = new SslStream(unsecureStream, leaveInnerStreamOpen);
                sslStream.AuthenticateAsClient("FakeServerName");

                StreamReader reader = new StreamReader(sslStream);
                StreamWriter writer = new StreamWriter(sslStream);

                writer.WriteLine(message);
                writer.Flush();


                string response = reader.ReadLine();
                Console.WriteLine("server sent: " + response);
                socket.Close();
            }
            
            






        }
    }
}
