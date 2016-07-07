using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiXinSDK.Card
{
    /*
    微信卡包api SDK V1.0
    !!README!!：
    base_info的构造函数的参数是必填字段，有set接口的可选字段。
    针对某一种卡的必填字段（参照文档）仍然需要手动set（比如团购券Groupon的deal_detail），通过card.get_card()拿到card的实体对象来set。
    ToJson就能直接转换为符合规则的json。
    Signature是方便生成签名的类，具体用法见示例。
    注意填写的参数是int还是string或者bool?或者自定义class。
    更具体用法见最后示例test，各种细节以最新文档为准。
    */
    public class Sku
    {
        /// <summary>
        /// 库存数量。
        /// </summary>
        public int quantity { get; set; }
    }
    public class DateInfo
    {
        /// <summary>
        /// 使用时间的类型。 1：固定日期区间，2：固定时长（自领取后按天算）
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 固定日期区间专用，表示起用时间。
        /// </summary>
        public long? begin_timestamp { get; set; }

        /// <summary>
        /// 固定日期区间专用，表示结束时间。
        /// </summary>
        public long? end_timestamp { get; set; }

        /// <summary>
        /// 固定时长专用，表示自领取后多少天内有效。（单位为天）
        /// </summary>
        public int? fixed_term { get; set; }

        /// <summary>
        /// 固定时长专用，表示自领取后多少天开始生效。（单位为天）
        /// </summary>
        public int? fixed_begin_term { get; set; }
    };
    public class BaseInfo
    {
        /// <summary>
        /// card_id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 卡券的商户logo
        /// </summary>
        public string logo_url { get; set; }

        /// <summary>
        /// code 码展示类型  1、"CODE_TYPE_TEXT"，文本 
        ///                 2、"CODE_TYPE_BARCODE"，一维码    
        ///                 3、"CODE_TYPE_QRCODE"，二维码
        /// </summary>
        public string code_type { get; set; }

        /// <summary>
        /// 商品名字
        /// </summary>
        public string brand_name { get; set; }

        /// <summary>
        /// 券名
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 券颜色。色彩规范标注值对应的色值。如#3373bb
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// 使用提醒。（一句话描述，展示在首页）
        /// </summary>
        public string notice { get; set; }

        /// <summary>
        /// 客服电话。
        /// </summary>
        public string service_phone { get; set; }

        /// <summary>
        /// 使用说明。长文本描述，可以分行。
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 每人使用次数限制。
        /// </summary>
        public int? use_limit { get; set; }

        /// <summary>
        /// 每人最大领取次数。
        /// </summary>
        public int? get_limit { get; set; }

        /// <summary>
        /// 是否自定义code 码。
        /// </summary>
        public bool? use_custom_code { get; set; }

        /// <summary>
        /// 是否指定用户领取。
        /// </summary>
        public bool? bind_openid { get; set; }

        /// <summary>
        /// 领取卡券原生页面是否可分享，填写true 或false，true 代表可分享。默认可分享。
        /// </summary>
        public bool? can_share { get; set; }

        /// <summary>
        /// 卡券是否可转赠，填写true 或false,true 代表可转赠。默认可转赠。
        /// </summary>
        public bool? can_give_friend { get; set; }

        /// <summary>
        /// 门店位置ID。
        /// </summary>
        public List<int> location_id_list { get; set; }

        /// <summary>
        /// 使用日期，有效期的信息。
        /// </summary>
        public DateInfo date_info { get; set; }

        /// <summary>
        /// 商品信息。
        /// </summary>
        public Sku sku { get; set; }

        /// <summary>
        /// 商户自定义cell 名称.。
        /// </summary>
        public int? url_name_type { get; set; }

        /// <summary>
        /// 商户自定义url 地址，支持卡券页内跳转。
        /// </summary>
        public string custom_url { get; set; }

        /// <summary>
        /// 第三方来源名，例如同程旅游、格瓦拉
        /// </summary>
        public string source { get; set; }

        /// <summary>
        /// “CARD_STATUS_NOT_VERIFY”,待审核“CARD_STATUS_VERIFY_FALL”,审核失败“CARD_STATUS_VERIFY_OK”，
        /// 通过审核“CARD_STATUS_USER_DELETE”，卡券被用户删除“CARD_STATUS_USER_DISPATCH ”，在公众平台投放过的卡券
        /// </summary>
        public string status { get; set; }
    };
    public class CardBase
    {
        public BaseInfo base_info { get; set; }
    };

    public class GeneralCoupon : CardBase
    {
        /// <summary>
        /// 描述文本
        /// </summary>
        public string default_detail { get; set; }
    };
    public class Groupon : CardBase
    {
        /// <summary>
        /// 团购券专用，团购详情
        /// </summary>
        public string deal_detail { get; set; }
    };
    public class Discount : CardBase
    {
        /// <summary>
        /// 折扣券专用，表示打折额度（百分比）。填 30就是七折。
        /// </summary>
        public int discount { get; set; }
    };
    public class Gift : CardBase
    {
        /// <summary>
        /// 礼品券专用，表示礼品名字。
        /// </summary>
        public string gift { get; set; }
    };
    public class Cash : CardBase
    {
        /// <summary>
        /// 代金券专用，表示起用金额（单位为分）
        /// </summary>
        public int least_cost { get; set; }

        /// <summary>
        /// 代金券专用，表示减免金额（单位为分）
        /// </summary>
        public int reduce_cost { get; set; }
    };
    public class MemberCard : CardBase
    {
        /// <summary>
        /// 是否支持积分， 填写 true 或 false，如填写true，积分相关字段均为必填。 填写 false， 积分字段无需填写。储值字段处理方式相同。
        /// </summary>
        public bool? supply_bonus { get; set; }

        /// <summary>
        /// 是否支持储值， 填写 true 或 false。
        /// </summary>
        public bool? supply_balance { get; set; }

        /// <summary>
        /// 积分清零规则
        /// </summary>
        public string bonus_cleared { get; set; }

        /// <summary>
        /// 积分规则
        /// </summary>
        public string bonus_rules { get; set; }

        /// <summary>
        /// 储值说明
        /// </summary>
        public string balance_rules { get; set; }

        /// <summary>
        /// 特权说明
        /// </summary>
        public string prerogative { get; set; }

        /// <summary>
        /// 绑定旧卡的 url，与“activate_url”字段二选一必填。
        /// </summary>
        public string bind_old_card_url { get; set; }

        /// <summary>
        /// 激活会员卡的url，与“bind_old_card_url” 字段二选一必填。
        /// </summary>
        public string activate_url { get; set; }

        /// <summary>
        /// true 为用户点击进入会员卡时是否推送事件。
        /// </summary>
        public string need_push_on_view { get; set; }

    };
    public class ScenicTicket : CardBase
    {
        /// <summary>
        /// 票类型，例如平日全票，套票等。
        /// </summary>
        public string ticket_class { get; set; }

        /// <summary>
        /// 导览图url
        /// </summary>
        public string guide_url { get; set; }
    };
    public class MovieTicket : CardBase
    {
        /// <summary>
        /// 电影票详情
        /// </summary>
        public string detail { get; set; }
    };

    public class BoardingPassCard : CardBase
    {
        /// <summary>
        /// 起点，上限为18 个汉字。
        /// </summary>
        public string from { get; set; }

        /// <summary>
        /// 终点，上限为18 个汉字。
        /// </summary>
        public string to { get; set; }

        /// <summary>
        /// 航班
        /// </summary>
        public string flight { get; set; }

        /// <summary>
        /// 起飞时间，上限为 17个汉字。
        /// </summary>
        public long? departure_time { get; set; }

        /// <summary>
        /// 降落时间，上限为 17个汉字。
        /// </summary>
        public long? landing_time { get; set; }

        /// <summary>
        /// 在线值机的链接
        /// </summary>
        public string check_in_url { get; set; }

        /// <summary>
        /// 登机口。如发生登机口变更，建议商家实时调用该接口变更。
        /// </summary>
        public string gate { get; set; }

        /// <summary>
        /// 登机时间，只显示“时分”不显示日期，按时间戳格式填写。如发生登机时间变更，
        /// 建议商家实时调用该接口变更。
        /// </summary>
        public long? boarding_time { get; set; }

        /// <summary>
        /// 机型，上限为8 个汉字
        /// </summary>
        public string air_model { get; set; }
    };

    /// <summary>
    /// 红包
    /// </summary>
    public class LuckyMoney : CardBase
    {
    }

    /// <summary>
    /// 会议
    /// </summary>
    public class MeetingTicket : CardBase
    {
        /// <summary>
        /// 会议详情
        /// </summary>
        public string meeting_detail { get; set; }

        /// <summary>
        /// 会场导览图
        /// </summary>
        public string map_url { get; set; }
    }


    public class Card       //工厂
    {  
        /// <summary>
        /// 卡券类型
        /// </summary>
        public string card_type { get; set; }

        public GeneralCoupon general_coupon { get; set; }

        public Groupon groupon { get; set; }
        public Discount discount { get; set; }
        public Gift gift { get; set; }
        public Cash cash { get; set; }
        public MemberCard member_card { get; set; }
        public ScenicTicket scenic_ticket { get; set; }
        public MovieTicket movie_ticket { get; set; }

        public CardBase get_card()
        {
            switch (this.card_type)
            {
                case "GENERAL_COUPON":
                    return this.general_coupon;
                case "GROUPON":
                    return this.groupon;
                case "DISCOUNT":
                    return this.discount;
                case "GIFT":
                    return this.gift;
                case "CASH":
                    return this.cash;
                case "MEMBER_CARD":
                    return this.member_card;
                case "SCENIC_TICKET":
                    return this.scenic_ticket;
                case "MOVIE_TICKET":
                    return this.movie_ticket;
                default:
                    throw new Exception("GetCard Error");
            }
        }
        public string toJson()
        {
            return "{ \"card\":" + WeiXinSDK.Util.ToJson(this) + "}";
        }
    }

    public class CardReturn : ReturnCode
    {
        public Card card { get; set; }
    }
}