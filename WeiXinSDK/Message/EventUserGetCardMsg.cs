using System;
using System.Collections.Generic;
using System.Text;

namespace WeiXinSDK.Message
{
    public class EventUserGetCardMsg : EventBaseMsg
    {
        public override string Event
        {
            get { return "user_get_card"; }
        }

        /// <summary>
        /// 赠送方账号（一个OpenID），"IsGiveByFriend”为1 时填写该参数。
        /// </summary>
        public string FriendUserName { get; set; }

        /// <summary>
        /// 卡券ID
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 是否为转赠，1 代表是，0 代表否。
        /// </summary>
        public byte IsGiveByFriend { get; set; }

        /// <summary>
        /// code 序列号。自定义code 及非自定义code的卡券被领取后都支持事件推送。
        /// </summary>
        public string UserCardCode { get; set; }

        /// <summary>
        /// 领取场景值，用于领取渠道数据统计。
        /// 可在生成二维码接口及添加JS API 接口中自定义该字段的整型值。
        /// </summary>
        public string OuterId { get; set; }
    }
}
