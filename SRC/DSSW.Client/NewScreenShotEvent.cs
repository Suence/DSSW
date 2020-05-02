using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSSW.Client
{
    public class NewScreenShotEvent : PubSubEvent<string>
    {
        public string NewScreenShotPath { get; set; }
    }
}
