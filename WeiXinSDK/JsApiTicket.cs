
namespace WeiXinSDK
{
    /// <summary>
    /// jsapi_ticket 
    /// </summary>
    public class JsApiTicket : ReturnCode
    {
        public string ticket { get; set; }
        public int expires_in { get; set; }
    }
}
