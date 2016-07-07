using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonLibs;
using EnumLibrary;
using ServiceBiz;
using ServiceModel;

public partial class Luckdraw : AbstractPage
{ 
    public string code = "";
    public string openid = "";
    public string newsPic, newsTitle, newsText, newsDj;
    public string qrcode, shareurl, sharetext;
    LogHelper _log = new LogHelper("LuckdrawLog");

    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo userinfo = UserInfoRule.CheckLogin();
        if (userinfo == null || userinfo.TableName != EnumLoginType.User)
        {
            _log.WriteLog("页面跳转，Oauth.aspx?url=" + Server.UrlEncode(Request.Url.ToString()));
            Response.Redirect("Oauth.aspx?url=" + Server.UrlEncode(Request.Url.ToString()));
            return;
        }
        code = Request.QueryString["code"];
        MZZ.Model.tb_user userModel = userinfo.Entity as MZZ.Model.tb_user;
        openid = userModel.user_openid;
        bool subscribe = userModel.user_sub_scribe;
        _log.WriteLog("subscribe:" + subscribe.ToString());
        if (subscribe != true)
        {
            WebMessageBox.AdminShow("请先关注", "http://viewer.maka.im/pcviewer/RJ3BUAEG?DSCKID=55f2c955-5bc4-4dfb-8353-78651258cfe7&DSTIMESTAMP=1465131817117");
        }
        else
        {
            newsPic = "http://" + Request.Url.Host + "/images/mengmeizi.jpg";
            newsText = "";
            newsDj = "";
            //shareurl = "http://" + Request.Url.Host + "/Luckdraw.aspx?openid=" + openid;
            shareurl = "http://viewer.maka.im/pcviewer/RJ3BUAEG?DSCKID=55f2c955-5bc4-4dfb-8353-78651258cfe7&DSTIMESTAMP=1465131817117";
            qrcode = "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + userModel.user_qr_code;
            sharetext = CHelper.SubStrDot(CHelper.RemoveHTML(newsText), 25);
        }
    }
}