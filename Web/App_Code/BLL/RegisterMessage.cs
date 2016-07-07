using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiXinSDK.Message;

/// <summary>
/// 注册微信公众号注册消息处理程序
/// </summary>
public class RegisterMessage
{
    public RegisterMessage()
    {

        //发送消息时的事件推送
        WeiXinSDK.MyFunc<RecTextMsg, ReplyBaseMsg> texthandler = TextHandler;
        WeiXinSDK.WeiXin.RegisterMsgHandler<RecTextMsg>(texthandler);

    }

    /// <summary>
    /// 文本消息
    /// </summary>
    public ReplyBaseMsg TextHandler(RecTextMsg msg)
    {
        CHelper.WriteLog("文本消息接收", "开始");

        ReplyTransferMsg replymsg = new ReplyTransferMsg();

        SendTextMsg sTextMsg = new SendTextMsg();
        if (msg.Content == "moe")
        {
            sTextMsg.text = new SendTextMsg.Text() { content = "首次关注奖励 <a href='http://weixin.52softs.com/Activity.aspx'>领取</a>" };
        }
        //sTextMsg.touser = msg.FromUserName;
        //sTextMsg.text = new SendTextMsg.Text() { content = "正在为您接入客服..." };
        WeiXinSDK.WeiXin.SendMsg(sTextMsg);

        //replymsg.Content = "客服消息转发";
        return replymsg;
    }
}