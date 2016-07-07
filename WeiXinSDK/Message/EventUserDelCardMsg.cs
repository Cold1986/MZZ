
namespace WeiXinSDK.Message
{
    /// <summary>
    /// 删除卡券事件
    /// </summary>
    public class EventUserDelCardMsg : EventBaseMsg
    {
        public override string Event
        {
            get { return "user_del_card"; }
        }

        /// <summary>
        /// 卡券ID。
        /// </summary>
        public string CardId { get; set; }


        /// <summary>
        /// code 序列号。自定义code 及非自定义code的卡券被领取后都支持事件推送。
        /// </summary>
        public string UserCardCode { get; set; }
    }
}
