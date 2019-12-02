using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzerLibrary {

    public class Echo : ICMP {

        public Echo (){

            Type = 0x08;
            Code = 0x00;
            Checksum = 0;

            Buffer.BlockCopy(BitConverter.GetBytes(Type), 0, Message, 0, 1);
            Buffer.BlockCopy(BitConverter.GetBytes(Code), 0, Message, 1, 1);

            byte[] data = Encoding.ASCII.GetBytes("test packet");
            Buffer.BlockCopy(BitConverter.GetBytes(Checksum), 0, Message, 2, 2);
            Buffer.BlockCopy(data, 0, Message, 4, data.Length);
            MessageSize = data.Length + 3;

            Checksum = GetCheckSum();            
        }
    }
}
