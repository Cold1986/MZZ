using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class weixin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.HttpMethod.ToUpper() == "POST")
        {
            if (CheckSignature())
            {
                WeiXinSDK.Message.ReplyBaseMsg replymsg = WeiXinSDK.WeiXin.ReplyMsg();//处理用户消息和事件
                CHelper.WriteLog("发送消息", replymsg.GetXML());
                Response.Write(replymsg.GetXML());
                Response.End();
            }
            else
            {
                CHelper.WriteLog("非法请求", "不是从微信服务器发起的Post请求");
                Response.Write("非法请求");
            }
        }
        else
        {
            CHelper.WriteLog("首次设置微信公众号服务器URL", "");
            Valid();
        }
    }

    //本函数只在首次配置时运行
    private void Valid()
    {
        string echoStr = HttpContext.Current.Request.QueryString["echoStr"];
        if (CheckSignature())
        {
            if (!string.IsNullOrEmpty(echoStr))
            {
                Response.Write(echoStr);
                Response.End();
            }
        }
        else
        {
            Response.Write("");
            Response.End();
        }
    }

    //验证消息的真实性
    public bool CheckSignature()
    {
        AppInfo appinfo = AppInfo.GetGetAppInfo();
        string token = appinfo.token;
        string signature = HttpContext.Current.Request.QueryString["signature"];
        string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
        string nonce = HttpContext.Current.Request.QueryString["nonce"];

        if (WeiXinSDK.WeiXin.CheckSignature(signature, timestamp, nonce, token))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}