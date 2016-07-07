using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiXinSDK.Card
{
    /// <summary>
    ///QrCard 的摘要说明
    /// </summary>
    public class QrCard
    {
        /// <summary>
        /// QR_CARD
        /// </summary>
        public string action_name = "QR_CARD";

        /// <summary>
        /// 卡券信息
        /// </summary>
        public ActionInfo action_info { get; set; }

        public class ActionInfo
        {
            /// <summary>
            /// 卡券参数信息
            /// </summary>
            public Card card { get; set; }

            public class Card
            {
                /// <summary>
                /// 卡券ID
                /// </summary>
                public string card_id { get; set; }

                /// <summary>
                /// 指定卡券code 码，只能被领一次。
                /// use_custom_code 字段为true 的卡券必须填写，非自定义code 不必填写。
                /// </summary>
                public string code { get; set; }

                /// <summary>
                /// 指定领取者的openid，只有该用户能领取。
                /// bind_openid 字段为true 的卡券必须填写，非自定义openid 不必填写。
                /// </summary>
                public string openid { get; set; }

                /// <summary>
                /// 指定二维码的有效时间，范围是60 ~ 1800 秒。不填默认为永久有效。
                /// </summary>
                public string expire_seconds { get; set; }

                /// <summary>
                /// 指定下发二维码，生成的二维码随机分配一个code，
                /// 领取后不可再次扫描。填写true 或false。默认false。
                /// </summary>
                public bool is_unique_code { get; set; }
            }
        }
    }
}