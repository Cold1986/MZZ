using System;
using System.Collections.Generic;
using System.Text;

namespace WeiXinSDK.Message
{
    public class EventCardNotPassCheckMsg : EventBaseMsg
    {
        public override string Event
        {
            get { return "card_not_pass_check"; }
        }

        /// <summary>
        /// 卡券ID
        /// </summary>
        public string CardId { get; set; }
    }
}
