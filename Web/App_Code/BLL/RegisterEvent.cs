using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WeiXinSDK.Message;

/// <summary>
/// 注册微信公众号注册事件处理程序
/// </summary>
public class RegisterEvent
{
    public RegisterEvent()
    {
        //点击菜单拉取消息时的事件推送
        WeiXinSDK.MyFunc<EventClickMsg, ReplyBaseMsg> clickhandler = ClickHandler;
        WeiXinSDK.WeiXin.RegisterEventHandler<EventClickMsg>(clickhandler);

        //用户未关注时，扫描二维码进行关注后的事件推送
        WeiXinSDK.MyFunc<EventUserScanMsg, ReplyBaseMsg> scanhandler = ScanHandler;
        WeiXinSDK.WeiXin.RegisterEventHandler<EventUserScanMsg>(scanhandler);

        //用户已关注时扫描二维码的事件推送
        WeiXinSDK.MyFunc<EventFansScanMsg, ReplyBaseMsg> fansscanhandler = FansScanHandler;
        WeiXinSDK.WeiXin.RegisterEventHandler<EventFansScanMsg>(fansscanhandler);


        //普通关注事件
        WeiXinSDK.MyFunc<EventAttendMsg, ReplyBaseMsg> attendhandler = AttendHandler;
        WeiXinSDK.WeiXin.RegisterEventHandler<EventAttendMsg>(attendhandler);


        //取消关注事件
        WeiXinSDK.MyFunc<EventUnattendMsg, ReplyBaseMsg> unattendhandler = UnattendHandler;
        WeiXinSDK.WeiXin.RegisterEventHandler<EventUnattendMsg>(unattendhandler);

        //订单付款通知
        WeiXinSDK.MyFunc<EventMerchantOrderMsg, ReplyBaseMsg> merchantorderhandler = MerchantOrderHandler;
        WeiXinSDK.WeiXin.RegisterEventHandler<EventMerchantOrderMsg>(merchantorderhandler);

        //领取卡券通知
        WeiXinSDK.MyFunc<EventUserGetCardMsg, ReplyBaseMsg> getcardhandler = GetCardHandler;
        WeiXinSDK.WeiXin.RegisterEventHandler<EventUserGetCardMsg>(getcardhandler);

        //删除卡券通知
        WeiXinSDK.MyFunc<EventUserDelCardMsg, ReplyBaseMsg> delcardhandler = DelCardHandler;
        WeiXinSDK.WeiXin.RegisterEventHandler<EventUserDelCardMsg>(delcardhandler);

        //核销卡券通知
        WeiXinSDK.MyFunc<EventUserConsumeCardMsg, ReplyBaseMsg> consumecardhandler = ConsumeCardHandler;
        WeiXinSDK.WeiXin.RegisterEventHandler<EventUserConsumeCardMsg>(consumecardhandler);

        ////多客服接入
        //WeiXinSDK.MyFunc<EventKfCreateSession, ReplyBaseMsg> ffcreatesessionhandler = KfCreateSessionHandler;
        //WeiXinSDK.WeiXin.RegisterEventHandler<EventKfCreateSession>(ffcreatesessionhandler);

        ////多客服关闭
        //WeiXinSDK.MyFunc<EventKfCloseSession, ReplyBaseMsg> kfclosesessionhandler = KfCloseSessionHandler;
        //WeiXinSDK.WeiXin.RegisterEventHandler<EventKfCloseSession>(kfclosesessionhandler);

        ////多客服转接
        //WeiXinSDK.MyFunc<EventKfSwitchSession, ReplyBaseMsg> kfswitchsessionhandler = KfSwitchSessionHandler;
        //WeiXinSDK.WeiXin.RegisterEventHandler<EventKfSwitchSession>(kfswitchsessionhandler);
    }


    /// <summary>
    /// 点击菜单拉取消息时的事件推送 
    /// </summary>
    public ReplyBaseMsg ClickHandler(EventClickMsg msg)
    {

        CHelper.WriteLog("msg", msg.EventKey);
        if (msg.EventKey == "checkin")
        {
            ReplyTextMsg replymsg = new ReplyTextMsg();
            DateTime nowDate = DateTime.Now;
            string openid = msg.FromUserName;
            DataSet ds = DbHelperMySQL.Query("select * from tb_signin where openid='" + openid + "' and year(createdtime)=" + nowDate.Year.ToString() + " and month(createdtime)=" + nowDate.Month.ToString() + " and day(createdtime)=" + nowDate.Day.ToString() + " and type='checkin'");
            DataTable tb = ds.Tables[0];
            if (tb.Rows.Count == 0)
            {
                DbHelperMySQL.ExecuteSql("update tb_user set user_integral=user_integral+5  where user_phone='" + openid + "'");
                DbHelperMySQL.ExecuteSql("INSERT INTO tb_signin(openid, type,createdtime) VALUES('" + openid + "','checkin',current_timestamp)");
                replymsg.Content = "签到成功，谢谢";
            }
            else
            {

                replymsg.Content = "您今天已经签到过了，请明天再来。";

            }
            return replymsg;
        }
        //JieEn.BLL.WxMenu menuBLL = new JieEn.BLL.WxMenu();
        //JieEn.Model.WxMenu menuModel = menuBLL.GetModelList("MenuType='Click' And MenuKeyOrUrl='" + msg.EventKey + "'").FirstOrDefault();
        //if (menuModel == null)
        //{
        //    return ReplyEmptyMsg.Instance;
        //}
        //else
        //{
        //    try
        //    {
        //ReplyTextMsg replymsg = new ReplyTextMsg();

        //switch (msg.EventKey)
        //{
        //    //case "就餐预订":
        //    //    replymsg.Content = "订餐热线：05808227777";
        //    //    return replymsg;
        //    //case "活动介绍":
        //    //    replymsg.Content = "暂无优惠活动，敬请关注最新公众号通知。";
        //    //    return replymsg;
        //    //case "领取优惠券":
        //    ////JieEn.BLL.User userBLL = new JieEn.BLL.User();
        //    ////var userModel = userBLL.GetModel(msg.FromUserName);
        //    ////SendCard sendCard = new SendCard();
        //    ////if (userModel != null && sendCard.SendFirstCard(userModel.ID))
        //    ////{
        //    ////    replymsg.Content = "领取成功，<a href='http://wx.zsnanyang.com/ticket.aspx'>点击查看</a>";
        //    ////}
        //    ////else
        //    ////{
        //    ////    replymsg.Content = sendCard.ErrMsg == "" ? "领取失败。" : sendCard.ErrMsg;
        //    ////}
        //    ////return replymsg;
        //    //default:
        //    //    ReplyNewsMsg rNewsMsg = WeiXinSDK.Util.JsonTo<ReplyNewsMsg>(menuModel.Menu_xml);
        //    //    return rNewsMsg;
        //}
        //}
        //catch
        //{
        return ReplyEmptyMsg.Instance;
        //}
        //}
    }
    /// <summary>
    /// 用户未关注时，扫描二维码进行关注后的事件推送
    /// 1.带参数二维码
    /// 2.非带参数二维码
    /// </summary>
    public ReplyBaseMsg ScanHandler(EventUserScanMsg msg)
    {
        //更新用户信息
        if (msg.EventKey.IndexOf("qrscene_") >= 0)//带参数二维码
        {
            new WxUser().InsertOrUpdateUsers(msg.FromUserName, msg.EventKey.Substring(8));
        }
        else//非带参数二维码
        {
            new WxUser().InsertOrUpdateUsers(msg.FromUserName, null);
        }

        ReplyTextMsg replymsg = new ReplyTextMsg();
        replymsg.Content = @"欢迎关注萌宅族!萌物控？周边狂热？二次元中毒？中二毕业？急需回血？求小伙伴？想当现充？绅士福利？一大波你想要的萌货和宅品更多好玩等你来发现~更多新功能陆续添加中! ";
        return replymsg;
    }

    /// <summary>
    /// 用户已关注时扫描带参数二维码的事件推送 
    /// </summary>
    public ReplyBaseMsg FansScanHandler(EventFansScanMsg msg)
    {
        new WxUser().InsertOrUpdateUsers(msg.FromUserName, msg.EventKey);

        ReplyTextMsg replymsg = new ReplyTextMsg();
        replymsg.Content = @"欢迎关注萌宅族!萌物控？周边狂热？二次元中毒？中二毕业？急需回血？求小伙伴？想当现充？绅士福利？一大波你想要的萌货和宅品更多好玩等你来发现~更多新功能陆续添加中!";
        return replymsg;
    }

    /// <summary>
    /// 普通关注事件
    /// </summary>
    public ReplyBaseMsg AttendHandler(EventAttendMsg msg)
    {
        new WxUser().InsertOrUpdateUsers(msg.FromUserName, null);

        ReplyTextMsg replymsg = new ReplyTextMsg();
        replymsg.Content = @"欢迎关注萌宅族!萌物控？周边狂热？二次元中毒？中二毕业？急需回血？求小伙伴？想当现充？绅士福利？一大波你想要的萌货和宅品更多好玩等你来发现~更多新功能陆续添加中!";
        return replymsg;
    }


    /// <summary>
    /// 取消关注事件
    /// </summary>
    public ReplyBaseMsg UnattendHandler(EventUnattendMsg msg)
    {
        new WxUser().InsertOrUpdateUsers(msg.FromUserName, null);

        ReplyEmptyMsg replymsg = new ReplyEmptyMsg();
        return replymsg;
    }

    /// <summary>
    /// 订单付款通知
    /// </summary>
    public ReplyBaseMsg MerchantOrderHandler(EventMerchantOrderMsg msg)
    {
        return ReplyEmptyMsg.Instance;
    }

    /// <summary>
    /// 领取卡券通知
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public ReplyBaseMsg GetCardHandler(EventUserGetCardMsg msg)
    {
        return ReplyEmptyMsg.Instance;
    }

    /// <summary>
    /// 删除卡券通知
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public ReplyBaseMsg DelCardHandler(EventUserDelCardMsg msg)
    {
        return ReplyEmptyMsg.Instance;
    }

    /// <summary>
    /// 核销卡券通知
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public ReplyBaseMsg ConsumeCardHandler(EventUserConsumeCardMsg msg)
    {

        return ReplyEmptyMsg.Instance;
    }

    ///// <summary>
    ///// 多客服接入
    ///// </summary>
    ///// <param name="msg"></param>
    ///// <returns></returns>
    //public ReplyBaseMsg KfCreateSessionHandler(EventKfCreateSession msg)
    //{
    //    SendTextMsg sTextMsg = new SendTextMsg();
    //    sTextMsg.touser = msg.FromUserName;
    //    sTextMsg.text = new SendTextMsg.Text() { content = "您好，[" + msg.KfAccount + "]为您服务！" };
    //    WeiXinSDK.WeiXin.SendMsg(sTextMsg);

    //    return ReplyEmptyMsg.Instance;
    //}

    ///// <summary>
    ///// 多客服关闭
    ///// </summary>
    ///// <param name="msg"></param>
    ///// <returns></returns>
    //public ReplyBaseMsg KfCloseSessionHandler(EventKfCloseSession msg)
    //{
    //    SendTextMsg sTextMsg = new SendTextMsg();
    //    sTextMsg.touser = msg.FromUserName;
    //    sTextMsg.text = new SendTextMsg.Text() { content = "[" + msg.KfAccount + "]为您服务结束，祝您生活愉快！" };
    //    WeiXinSDK.WeiXin.SendMsg(sTextMsg);

    //    return ReplyEmptyMsg.Instance;
    //}

    ///// <summary>
    ///// 多客服转接
    ///// </summary>
    ///// <param name="msg"></param>
    ///// <returns></returns>
    //public ReplyBaseMsg KfSwitchSessionHandler(EventKfSwitchSession msg)
    //{
    //    SendTextMsg sTextMsg = new SendTextMsg();
    //    sTextMsg.touser = msg.FromUserName;
    //    sTextMsg.text = new SendTextMsg.Text() { content = "您好，正在为您转接至[" + msg.ToKfAccount + "]！" };
    //    WeiXinSDK.WeiXin.SendMsg(sTextMsg);

    //    return ReplyEmptyMsg.Instance;
    //}
}