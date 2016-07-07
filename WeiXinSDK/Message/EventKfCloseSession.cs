using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXinSDK.Message
{
    public class EventKfCloseSession : EventBaseMsg
    {
        public EventKfCloseSession();

        public override string Event { get; }
        public string KfAccount { get; set; }
    }
}
