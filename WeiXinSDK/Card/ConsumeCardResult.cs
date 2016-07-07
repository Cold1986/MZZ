
namespace WeiXinSDK
{
    /// <summary>
    /// 核销卡券返回结果
    /// </summary>
    public class ConsumeCardResult : ReturnCode
    {
        /// <summary>
        ///  卡券信息
        /// </summary>
        public ConsumeCardTempClass card { get; set; }

        /// <summary>
        ///  用户OpenId
        /// </summary>
        public string openid { get; set; }
    }

    public class ConsumeCardTempClass
    {
        /// <summary>
        ///  卡券信息
        /// </summary>
        public string card_id { get; set; }
    }
}
