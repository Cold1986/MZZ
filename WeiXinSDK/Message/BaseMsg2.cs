using System;

namespace WeiXinSDK.Message
{
    
    public class BaseMsg2
    {
        /// <summary>
        /// 发送方帐号
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 消息标识
        /// </summary>
        public string MsgFlag { get; set; }
    }
}
