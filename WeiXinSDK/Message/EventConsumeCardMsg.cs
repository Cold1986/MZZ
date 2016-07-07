
namespace WeiXinSDK.Message
{
    /// <summary>
    /// 卡券核销事件
    /// </summary>
    public class EventConsumeCardMsg : EventBaseMsg
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
        /// 商户自定义code 值。非自定code 推送为空串。
        /// </summary>
        public string UserCardCode { get; set; }
    }
}
