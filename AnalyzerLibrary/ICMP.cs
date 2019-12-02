using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzerLibrary {

    public class ICMP {

        public byte Type;
        public byte Code;
        public UInt16 Checksum;
        public int MessageSize;
        public byte[] Message = new byte[32];

        public ICMP() {}

        // For recieving
        public ICMP(byte[] data, int size) {

            Type = data[20];
            Code = data[21];
            Checksum = BitConverter.ToUInt16(data, 22);
            MessageSize = size - 24;
            Buffer.BlockCopy(data, 24, Message, 0, MessageSize);
        }


        // For Recieving
        public byte[] GetBytes() {

            byte[] data = new byte[MessageSize + 9];
            Buffer.BlockCopy(BitConverter.GetBytes(Type), 0, data, 0, 1);
            Buffer.BlockCopy(BitConverter.GetBytes(Code), 0, data, 1, 1);
            Buffer.BlockCopy(BitConverter.GetBytes(Checksum), 0, data, 2, 2);
            Buffer.BlockCopy(data, 0, Message, 4, data.Length);

            return data;
        }

        public ushort GetCheckSum() {

            UInt16 sum = 0;

            if (Message.Length > 0) {

                var bits = new BitArray(Message);
                var data = new byte[bits.Length / 8];
                
                bits.CopyTo(data, 0);
                sum = BitConverter.ToUInt16(data, 0);
                sum += (ushort)(sum >> 16);

                try {
                    return (ushort)~sum;
                }
                catch (OverflowException) {
                    
                    throw;
                }
                
            }
            else {

                throw new 
                    Exception("Message has not been constructed!");
            }
        }

    }
}
