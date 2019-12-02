using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnalyzerLibrary;

namespace NetworkAnalyzer {

    public static class Ping {



        public static void PingMethod(NetworkDevice device) {


            //Echo request = new Echo();
            RouterSolicitation request = new RouterSolicitation();

            SendPacket.Send(request, "255.255.255.0");

            //throw new NotImplementedException();
            

        }


    }
}
