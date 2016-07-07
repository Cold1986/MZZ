using System;
namespace WeiXinSDK.Message
{
    /// <summary>
    /// 消息转发到多客服
    /// </summary>
    public class ReplyTransferMsg : ReplyTextMsg
    {
        public override string MsgType
        {
            get { return "transfer_customer_service"; }
        }
    }
}
