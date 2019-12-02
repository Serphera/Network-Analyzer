using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

using AnalyzerLibrary;

namespace NetworkAnalyzer {

    static class SendPacket {


        public static void Send(ICMP packet, string ip) {


            // TODO: Regex to check that it's a proper IP
            Socket host = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Raw,
                ProtocolType.Icmp);
            int recv;
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), 0);
            EndPoint ep = (EndPoint)iep;

            host.SetSocketOption(SocketOptionLevel.Socket, 
                SocketOptionName.ReceiveTimeout, 3000);

            host.SendTo(packet.GetBytes(), packet.MessageSize, SocketFlags.None, iep);

            Console.WriteLine(packet.Checksum + " ?");
            byte[] data = new byte[1024];

            try {

                
                recv = host.ReceiveFrom(data, ref ep);
            }
            catch (SocketException) {

                Console.WriteLine("No response from host");
                throw;
            }

            ICMP response = new ICMP(data, recv);
            Console.WriteLine(ep.ToString());
            Console.WriteLine("Type: {0}", response.Type);
            Console.WriteLine("Code: {0}", response.Code);

            return;
        }

    }
}
