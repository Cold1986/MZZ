
namespace WeiXinSDK.Message
{
    /// <summary>
    /// 
    /// </summary>
    public enum MyEventType
    {
        Attend,
        Click,
        View,
        FansScan,
        Location,
        Unattend,
        UserScan,
        MASSSENDJOBFINISH,//群发结束通知
        MerchantOrder,//订单付款通知
        CardPassCheck,//卡券审核成功通知
        CardNotPassCheck,//卡券审核失败通知
        UserGetCard, //领取卡券通知
        UserDelCard, //删除卡券通知
        UserConsumeCard //核销卡券通知
    }
}
