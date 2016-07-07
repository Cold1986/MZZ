
namespace WeiXinSDK.Message
{
    /// <summary>
    /// 核销卡券事件
    /// </summary>
    public class EventUserConsumeCardMsg : EventBaseMsg
    {
        public override string Event
        {
            get { return "user_consume_card"; }
        }

        /// <summary>
        /// 卡券ID。
        /// </summary>
        public string CardId { get; set; }


        /// <summary>
        /// code 序列号。自定义code 及非自定义code的卡券被领取后都支持事件推送。
        /// </summary>
        public string UserCardCode { get; set; }

        /// <summary>
        /// 核销来源。支持开发者统计API核销（FROM_API）、公众平台核销（FROM_MP）、
        ///     卡券商户助手核销（FROM_MOBILE_HELPER）（核销员微信号） 
        /// </summary>
        public string ConsumeSource { get; set; }
    }
}
