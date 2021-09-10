using System;
using System.IO;
using System.Net.Sockets;

namespace EchoClientSimple
{
    class Program
    {
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
                TcpClient socket = new TcpClient("localhost", 7); //initializing client
                NetworkStream ns = socket.GetStream(); //processes the data received and sent. Must be separated into reader & writer
                StreamReader reader = new StreamReader(ns);
                StreamWriter writer = new StreamWriter(ns);

                writer.WriteLine(message);
                writer.Flush();


                string response = reader.ReadLine();
                Console.WriteLine("server sent: " + response);
                socket.Close();
            }
            
            






        }
    }
}
