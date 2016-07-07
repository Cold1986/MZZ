using System;
using System.Collections.Generic;
using System.Text;

namespace WeiXinSDK.Message
{
    public class EventCardPassCheckMsg : EventBaseMsg
    {
        public override string Event
        {
            get { return "card_pass_check"; }
        }

        /// <summary>
        /// 卡券ID
        /// </summary>
        public string CardId { get; set; }
    }
}
