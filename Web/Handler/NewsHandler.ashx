<%@ WebHandler Language="C#" Class="NewsHandler" %>

using System;
using System.Web;
using System.Web.SessionState;

public class NewsHandler : IHttpHandler, IRequiresSessionState
{
    
    ReturnCode RetCode = new ReturnCode();
    MZZ.Model.tb_user userModel = null;
    
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //1、身份认证
        ServiceModel.UserInfo userinfo = ServiceBiz.UserInfoRule.CheckLogin();
        if (userinfo == null || userinfo.TableName != EnumLibrary.EnumLoginType.User)
        {
            RetCode.errcode = -1;
            RetCode.errmsg = "未登录";
            context.Response.Write(WeiXinSDK.Util.ToJson(RetCode));
            return;
        }
        userModel = userinfo.Entity as MZZ.Model.tb_user;
        
        string act = context.Request["act"];
        if (string.IsNullOrEmpty(act))
        {
            RetCode.errcode = -1;
            RetCode.errmsg = "参数act不能为空";
            context.Response.Write(WeiXinSDK.Util.ToJson(RetCode));
            return;
        }
        switch (act)
        {
            case "share":
                context.Response.Write(Share(context));
                break;
            default:
                RetCode.errcode = -1;
                RetCode.errmsg = "参数act错误";
                context.Response.Write(WeiXinSDK.Util.ToJson(RetCode));
                break;
        }
    }

    /// <summary>
    /// 发送用户确认模板消息
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public string Share(HttpContext context)
    {
        try
        {
            ServiceModel.UserInfo userinfo = ServiceBiz.UserInfoRule.CheckLogin();
            MZZ.Model.tb_user userModel = userinfo.Entity as MZZ.Model.tb_user;
            string openid = userModel.user_openid;
            if (string.IsNullOrEmpty(openid))
            {
                RetCode.errcode = -1;
                RetCode.errmsg = "参数错误";
                return WeiXinSDK.Util.ToJson(RetCode);
            }
            MZZ.BLL.tb_activity activityBLL = new MZZ.BLL.tb_activity();
            MZZ.Model.tb_activity activityModel = new MZZ.Model.tb_activity();
            var rotorList = activityBLL.GetList("to_days(activity_times)=to_days(now()) and activity_openid='" + openid + "' and activity_reason='分享抽奖'");
            if (rotorList.Tables[0].DefaultView.Count == 0)
            {
                activityModel.activity_openid = openid;
                activityModel.activity_reason = WebHelp.GB2312ToUTF8("分享抽奖");
                activityModel.activity_hyid = 0;
                activityModel.activity_num = 0;
                activityModel.activity_calculate = 0;
                activityModel.activity_state = 1;
                activityModel.activity_times = Convert.ToDateTime(System.DateTime.Now);
                activityBLL.Add(activityModel);
                RetCode.errcode = 0;
                RetCode.errmsg = "ok";
                return WeiXinSDK.Util.ToJson(RetCode);
            }
            //else if (rotorList.Tables[0].DefaultView.Count > 0)
            //{
            //    RetCode.errcode = 0;
            //    RetCode.errmsg = "ok";
            //    return WeiXinSDK.Util.ToJson(RetCode);
            //}
            else
            {
                RetCode.errcode = -1;
                RetCode.errmsg = "insert error";
                return WeiXinSDK.Util.ToJson(RetCode);
            }
        }
        catch (Exception ex)
        {
            CHelper.WriteLog("ex：", ex.ToString());
            RetCode.errcode = -1;
            RetCode.errmsg = "error";
            return WeiXinSDK.Util.ToJson(RetCode);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}