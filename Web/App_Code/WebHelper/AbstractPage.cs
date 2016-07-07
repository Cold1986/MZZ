using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AbstractPage 的摘要说明
/// </summary>
public class AbstractPage : System.Web.UI.Page
{
    public string appId, nonceStr, signature, url, timestamp;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            appId = AppInfo.GetGetAppInfo().appid;
            timestamp = DateTime.Now.Ticks.ToString().Substring(0, 10);
            nonceStr = Guid.NewGuid().ToString().Substring(0, 16);
            url = Request.Url.ToString().Split('#')[0].Replace(":801", "");
            string jsapi_ticket = WeiXinSDK.WeiXinJSSDK.GetJsapiTicket();
            signature = WeiXinSDK.WeiXinJSSDK.GetJsSdkSignature(nonceStr, jsapi_ticket, timestamp.ToString(), url);

            CustomMethod();
        }
    }

    /// <summary>
    /// 供子类重载差异化代码
    /// </summary>
    protected virtual void CustomMethod()
    {
        
    }
}