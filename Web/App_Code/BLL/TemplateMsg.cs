using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///TemplateMsg 的摘要说明
/// </summary>
public class TemplateMsg
{
    #region 发送模板消息

    /// <summary>
    /// 订单支付成功通知
    /// </summary>
    public void BuySuccess(string OpenId, string top, string dateTime, string productName, string money, string orderid, string orderno)
    {
        string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + WeiXinSDK.WeiXin.GetAccessToken();
        object postdata = new
        {
            touser = OpenId,
            template_id = "-0PQ_t9t3bc7EuJW6mLibXwGbENtcHnnnCGK1TZ4Jio",
            url = "http://wx.zsnanyang.com/userdd.aspx",
            topcolor = "#FF0000",
            data = new
            {
                first = new
                {
                    value = top,
                    color = "#0A0A0A"
                },
                keyword1 = new
                {
                    value = dateTime,
                    color = "#0A0A0A"
                },
                keyword2 = new
                {
                    value = productName,
                    color = "#0A0A0A"
                },
                keyword3 = new
                {
                    value = money,
                    color = "#0A0A0A"
                },
                keyword4 = new
                {
                    value = orderid,
                    color = "#0A0A0A"
                },
                keyword5 = new
                {
                    value = orderno,
                    color = "#0A0A0A"
                },
                remark = new
                {
                    value = "感谢您的支付，我们将尽快联系您。",
                    color = "#0A0A0A"
                }
            }
        };
        string postStr = WeiXinSDK.Util.ToJson(postdata);
        ReadJson.GetJsonByData(posturl, postStr);
    }

    /// <summary>
    /// //免费券使用成功通知  EXYqprWXe5Fg9bdSdGo_MijsIqJC0L8jDc-X59JuSME
    /// </summary>
    /// <param name="OpenId"></param>
    /// <param name="orderno"></param>
    /// <param name="amount"></param>
    public void UserCardSuccess(string OpenId, string code, string money, string time)
    {
        return;
        string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + WeiXinSDK.WeiXin.GetAccessToken();
        object postdata = new
        {
            touser = OpenId,
            template_id = "EXYqprWXe5Fg9bdSdGo_MijsIqJC0L8jDc-X59JuSME",
            url = "http://wx.ptshx.cn/n_ticket.aspx",
            topcolor = "#FF0000",
            data = new
            {
                first = new
                {
                    value = "您好，您已成功使用免费券！",
                    color = "#0A0A0A"
                },
                keyword1 = new
                {
                    value = code,
                    color = "#0A0A0A"
                },
                keyword2 = new
                {
                    value = money,
                    color = "#0A0A0A"
                },
                keyword3 = new
                {
                    value = time,
                    color = "#0A0A0A"
                },
                remark = new
                {
                    value = "感谢您的使用。",
                    color = "#0A0A0A"
                }
            }
        };
        string postStr = WeiXinSDK.Util.ToJson(postdata);
        ReadJson.GetJsonByData(posturl, postStr);
    }


    /// <summary>
    /// //礼品领取成功提醒  X0ZvIMkxaXpl5qU3gmuWnsHrEHJw7Zkf93vuTAv3fx4
    /// </summary>
    /// <param name="OpenId"></param>
    /// <param name="orderno"></param>
    /// <param name="amount"></param>
    public void SubscribeGift(string OpenId, string nickname, string productname, string expDate)
    {
        return;
        string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + WeiXinSDK.WeiXin.GetAccessToken();
        object postdata = new
        {
            touser = OpenId,
            template_id = "X0ZvIMkxaXpl5qU3gmuWnsHrEHJw7Zkf93vuTAv3fx4",
            url = "http://wx.ptshx.cn/n_ticket.aspx",
            topcolor = "#FF0000",
            data = new
            {
                first = new
                {
                    value = "您已成功领取礼品券",
                    color = "#0A0A0A"
                },
                keyword1 = new
                {
                    value = nickname,
                    color = "#0A0A0A"
                },
                keyword2 = new
                {
                    value = productname,
                    color = "#0A0A0A"
                },
                keyword3 = new
                {
                    value = expDate,
                    color = "#0A0A0A"
                },
                keyword4 = new
                {
                    value = "关注有礼",
                    color = "#0A0A0A"
                },
                remark = new
                {
                    value = "如有疑问，请联系商家",
                    color = "#0A0A0A"
                }
            }
        };
        string postStr = WeiXinSDK.Util.ToJson(postdata);
        ReadJson.GetJsonByData(posturl, postStr);
    }


    /// <summary>
    /// 订单支付成功通知
    /// </summary>
    public void BuySuccess_Admin(string OpenId, string top, string dateTime, string productName, string money, string orderid, string orderno)
    {
        string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + WeiXinSDK.WeiXin.GetAccessToken();
        object postdata = new
        {
            touser = OpenId,
            template_id = "-0PQ_t9t3bc7EuJW6mLibXwGbENtcHnnnCGK1TZ4Jio",
            url = "http://wx.zsnanyang.com/orderlist.aspx",
            topcolor = "#FF0000",
            data = new
            {
                first = new
                {
                    value = top,
                    color = "#0A0A0A"
                },
                keyword1 = new
                {
                    value = dateTime,
                    color = "#0A0A0A"
                },
                keyword2 = new
                {
                    value = productName,
                    color = "#0A0A0A"
                },
                keyword3 = new
                {
                    value = money,
                    color = "#0A0A0A"
                },
                keyword4 = new
                {
                    value = orderid,
                    color = "#0A0A0A"
                },
                keyword5 = new
                {
                    value = orderno,
                    color = "#0A0A0A"
                },
                remark = new
                {
                    value = "感谢您的支付，我们将尽快联系您。",
                    color = "#0A0A0A"
                }
            }
        };
        string postStr = WeiXinSDK.Util.ToJson(postdata);
        ReadJson.GetJsonByData(posturl, postStr);
    }



    /// <summary>
    /// 订单支付成功通知(蛋糕)
    /// </summary>
    public void BuySuccess2(string OpenId, string top, string dateTime, string productName, string money, string orderid, string orderno)
    {
        string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + WeiXinSDK.WeiXin.GetAccessToken();
        object postdata = new
        {
            touser = OpenId,
            template_id = "-0PQ_t9t3bc7EuJW6mLibXwGbENtcHnnnCGK1TZ4Jio",
            url = "http://wx.zsnanyang.com/userddc.aspx",
            topcolor = "#FF0000",
            data = new
            {
                first = new
                {
                    value = top,
                    color = "#0A0A0A"
                },
                keyword1 = new
                {
                    value = dateTime,
                    color = "#0A0A0A"
                },
                keyword2 = new
                {
                    value = productName,
                    color = "#0A0A0A"
                },
                keyword3 = new
                {
                    value = money,
                    color = "#0A0A0A"
                },
                keyword4 = new
                {
                    value = orderid,
                    color = "#0A0A0A"
                },
                keyword5 = new
                {
                    value = orderno,
                    color = "#0A0A0A"
                },
                remark = new
                {
                    value = "感谢您的支付，我们将尽快联系您。",
                    color = "#0A0A0A"
                }
            }
        };
        string postStr = WeiXinSDK.Util.ToJson(postdata);
        ReadJson.GetJsonByData(posturl, postStr);
    }


    /// <summary>
    /// 订单支付成功通知(蛋糕)
    /// </summary>
    public void BuySuccess_Admin2(string OpenId, string top, string dateTime, string productName, string money, string orderid, string orderno)
    {
        string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + WeiXinSDK.WeiXin.GetAccessToken();
        object postdata = new
        {
            touser = OpenId,
            template_id = "-0PQ_t9t3bc7EuJW6mLibXwGbENtcHnnnCGK1TZ4Jio",
            url = "http://wx.zsnanyang.com/orderlistc.aspx",
            topcolor = "#FF0000",
            data = new
            {
                first = new
                {
                    value = top,
                    color = "#0A0A0A"
                },
                keyword1 = new
                {
                    value = dateTime,
                    color = "#0A0A0A"
                },
                keyword2 = new
                {
                    value = productName,
                    color = "#0A0A0A"
                },
                keyword3 = new
                {
                    value = money,
                    color = "#0A0A0A"
                },
                keyword4 = new
                {
                    value = orderid,
                    color = "#0A0A0A"
                },
                keyword5 = new
                {
                    value = orderno,
                    color = "#0A0A0A"
                },
                remark = new
                {
                    value = "感谢您的支付，我们将尽快联系您。",
                    color = "#0A0A0A"
                }
            }
        };
        string postStr = WeiXinSDK.Util.ToJson(postdata);
        ReadJson.GetJsonByData(posturl, postStr);
    }


    /// <summary>
    /// 订单支付成功通知(早餐券)
    /// </summary>
    public void BuySuccess3(string OpenId, string top, string dateTime, string productName, string money, string orderid, string orderno)
    {
        string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + WeiXinSDK.WeiXin.GetAccessToken();
        object postdata = new
        {
            touser = OpenId,
            template_id = "-0PQ_t9t3bc7EuJW6mLibXwGbENtcHnnnCGK1TZ4Jio",
            url = "http://wx.zsnanyang.com/card.aspx",
            topcolor = "#FF0000",
            data = new
            {
                first = new
                {
                    value = top,
                    color = "#0A0A0A"
                },
                keyword1 = new
                {
                    value = dateTime,
                    color = "#0A0A0A"
                },
                keyword2 = new
                {
                    value = productName,
                    color = "#0A0A0A"
                },
                keyword3 = new
                {
                    value = money,
                    color = "#0A0A0A"
                },
                keyword4 = new
                {
                    value = orderid,
                    color = "#0A0A0A"
                },
                keyword5 = new
                {
                    value = orderno,
                    color = "#0A0A0A"
                },
                remark = new
                {
                    value = "感谢您的支付。",
                    color = "#0A0A0A"
                }
            }
        };
        string postStr = WeiXinSDK.Util.ToJson(postdata);
        ReadJson.GetJsonByData(posturl, postStr);
    }

    /// <summary>
    /// 订单支付成功通知(早餐券)
    /// </summary>
    public void BuySuccess_Admin3(string OpenId, string top, string dateTime, string productName, string money, string orderid, string orderno, long id)
    {
        string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + WeiXinSDK.WeiXin.GetAccessToken();
        object postdata = new
        {
            touser = OpenId,
            template_id = "-0PQ_t9t3bc7EuJW6mLibXwGbENtcHnnnCGK1TZ4Jio",
            topcolor = "#FF0000",
            url = "http://wx.zsnanyang.com/admin_card_order.aspx?id=" + id,
            data = new
            {
                first = new
                {
                    value = top,
                    color = "#0A0A0A"
                },
                keyword1 = new
                {
                    value = dateTime,
                    color = "#0A0A0A"
                },
                keyword2 = new
                {
                    value = productName,
                    color = "#0A0A0A"
                },
                keyword3 = new
                {
                    value = money,
                    color = "#0A0A0A"
                },
                keyword4 = new
                {
                    value = orderid,
                    color = "#0A0A0A"
                },
                keyword5 = new
                {
                    value = orderno,
                    color = "#0A0A0A"
                },
                remark = new
                {
                    value = "感谢您的支付。",
                    color = "#0A0A0A"
                }
            }
        };
        string postStr = WeiXinSDK.Util.ToJson(postdata);
        ReadJson.GetJsonByData(posturl, postStr);
    }


    /// <summary>
    /// 发送现金红包
    /// </summary>
    /// <param name="OpenId"></param>
    /// <param name="money"></param>
    public void SendHbMsg(string OpenId, string orderId, string nickname, string money)
    {
        string posturl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + WeiXinSDK.WeiXin.GetAccessToken();
        object postdata = new
        {
            touser = OpenId,
            template_id = "SochTa6Yt_Ir38s7Uk2FQr55-t-JhDv561eoExIGILw",
            topcolor = "#FF0000",
            data = new
            {
                first = new
                {
                    value = "恭喜您获得【" + nickname + "】的返现",
                    color = "#0A0A0A"
                },
                order = new
                {
                    value = orderId,
                    color = "#0A0A0A"
                },
                amount = new
                {
                    value = money + "元",
                    color = "#0A0A0A"
                },
                remark = new
                {
                    value = "请在24小时内领取，谢谢您的关注。",
                    color = "#0A0A0A"
                }
            }
        };
        string postStr = WeiXinSDK.Util.ToJson(postdata);
        ReadJson.GetJsonByData(posturl, postStr);
    }
    #endregion
}