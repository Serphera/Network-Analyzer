using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzerLibrary {

    public class RouterSolicitation : ICMP {

        public RouterSolicitation() {

            Type = 0x10;
            Code = 0x00;
            Checksum = 0;

            Buffer.BlockCopy(BitConverter.GetBytes(Type), 0, Message, 0, 1);
            Buffer.BlockCopy(BitConverter.GetBytes(Code), 0, Message, 1, 1);
            Buffer.BlockCopy(BitConverter.GetBytes(Checksum), 0, Message, 2, 2);

            Checksum = GetCheckSum();
        }


    }
}
