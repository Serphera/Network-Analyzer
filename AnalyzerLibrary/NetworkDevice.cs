using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzerLibrary {

    public class NetworkDevice {


        string Name { get; set; }
        string IP { get; set; }

        bool EditorStatus { get; set; }

        bool Status {
            get { return Status; }
            set {

                Status = value;
                DateTime currentTime = DateTime.Now;
                Uptime = Uptime + (currentTime - LastChecked);
                LastChecked = currentTime;
            }
        }

        TimeSpan Uptime { get; set; }

        private DateTime LastChecked;


        public NetworkDevice (string name, string ip) {

            Name = name;
            IP = ip;            
        }

    }
}
