using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXinSDK.Message
{
    public class EventKfSwitchSession : EventBaseMsg
    {
        public EventKfSwitchSession();

        public override string Event { get; }
        public string FromKfAccount { get; set; }
        public string ToKfAccount { get; set; }
    }
}
