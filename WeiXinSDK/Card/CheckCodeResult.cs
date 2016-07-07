
namespace WeiXinSDK
{
    /// <summary>
    /// 查询卡券code 的有效性 返回结果
    /// </summary>
    public class CheckCodeResult : ReturnCode
    {
        /// <summary>
        ///  用户OpenId
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        ///  卡券信息
        /// </summary>
        public CheckCodeTempClass card { get; set; }
    }

    public class CheckCodeTempClass
    {
        /// <summary>
        ///  卡券ID
        /// </summary>
        public string card_id { get; set; }

        /// <summary>
        ///  有效期 开始时间
        /// </summary>
        public long begin_time { get; set; }

        /// <summary>
        ///  有效期 结束时间
        /// </summary>
        public long end_time { get; set; }
    }
}
