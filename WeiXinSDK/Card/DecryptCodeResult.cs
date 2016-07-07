
namespace WeiXinSDK
{
    /// <summary>
    /// 解码接口返回结果
    /// </summary>
    public class DecryptCodeResult : ReturnCode
    {
        /// <summary>
        ///  卡券真实序列号
        /// </summary>
        public string code { get; set; }
    }
}
