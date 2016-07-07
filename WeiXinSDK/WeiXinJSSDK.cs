using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXinSDK
{
    public class WeiXinJSSDK
    {
        /// <summary>
        /// 公众号用于调用微信JS接口的临时票据
        /// </summary>
        /// <param name="appid">应用ID</param>
        /// <param name="secret">开发者凭据</param>
        /// <returns></returns>
        public static string GetJsapiTicket(string appId, string appSecret)
        {
            //正常情况下jsapi_ticket有效期为7200秒,这里使用缓存设置短于这个时间即可
            string jsapi_ticket = MemoryCacheHelper.GetCacheItem<string>("jsapi_ticket", delegate()
            {
                string access_token = WeiXin.GetAccessToken(appId, appSecret);
                string data = Util.HttpGet2("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + access_token + "&type=jsapi");
                JsApiTicket ticket = Util.JsonTo<JsApiTicket>(data);
                return ticket.ticket;
            },
                new TimeSpan(0, 0, 600)//300秒过期
                , DateTime.Now.AddSeconds(600)
            );

            return jsapi_ticket;
        }
        public static string GetJsapiTicket()
        {
            WeiXin.CheckGlobalCredential();
            return GetJsapiTicket(WeiXin.AppID, WeiXin.AppSecret);
        }

        /// <summary>
        /// JS-SDK 检验signature
        /// </summary>
        /// <param name="signature">微信加密签名</param>
        /// <param name="noncestr">随机数</param>
        /// <param name="jsapi_ticket">公众号用于调用微信JS接口的临时票据</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="url">调用JS接口页面的完整URL</param>
        /// <returns></returns>
        public static bool JsSdkCheckSignature(string signature, string noncestr, string jsapi_ticket, string timestamp, string url)
        {
            if (string.IsNullOrEmpty(signature)) return false;
            List<string> tmpList = new List<string>(4);
            tmpList.Add("noncestr=" + noncestr);
            tmpList.Add("jsapi_ticket=" + jsapi_ticket);
            tmpList.Add("timestamp=" + timestamp);
            tmpList.Add("url=" + url);
            tmpList.Sort();
            var tmpStr = string.Join("&", tmpList.ToArray());
            string strResult = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            return signature.Equals(strResult, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// 获取 JS-SDK 签名
        /// </summary>
        /// <param name="noncestr">随机数</param>
        /// <param name="jsapi_ticket">公众号用于调用微信JS接口的临时票据</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="url">调用JS接口页面的完整URL</param>
        /// <returns>signature 微信加密签名</returns>
        public static string GetJsSdkSignature(string noncestr, string jsapi_ticket, string timestamp, string url)
        {
            List<string> tmpList = new List<string>(4);
            tmpList.Add("noncestr=" + noncestr);
            tmpList.Add("jsapi_ticket=" + jsapi_ticket);
            tmpList.Add("timestamp=" + timestamp);
            tmpList.Add("url=" + url);
            tmpList.Sort();
            var tmpStr = string.Join("&", tmpList.ToArray());

            string strResult = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1").ToLower();
            return strResult;
        }
    }
}
