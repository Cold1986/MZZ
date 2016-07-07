using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXinSDK.Message
{
    public class EventKfCreateSession : EventBaseMsg
    {
        public EventKfCreateSession();

        public override string Event { get; }
        public string KfAccount { get; set; }
    }
}
