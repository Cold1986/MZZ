using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ServiceModel;
using EnumLibrary;

public partial class OAuth : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = Request.QueryString["url"];
        if (url == null || url == "" || !RegexUtil.IsURL(Server.UrlDecode(url.Replace(":801", ""))))
        {
            url = "http://" + HttpContext.Current.Request.Url.Host
+ "/Default.aspx";
        }

        string redirect_uri = Server.UrlEncode("http://" + HttpContext.Current.Request.Url.Host
+ "/OAuth.aspx?url=" + Server.UrlEncode(url.Replace(":801", "")));//授权后重定向的回调链接地址
        string scope = "snsapi_base";//应用授权作用域，snsapi_base、snsapi_userinfo 
        //string state = "1";//重定向后会带上state参数，开发者可以填写a-zA-Z0-9的参数值

        string code = Request.QueryString["code"];
        string state = Request.QueryString["state"];

        if (string.IsNullOrEmpty(code))
        {
            string codeurl = WeiXinSDK.WeiXin.BuildWebCodeUrl(redirect_uri, scope, "1");

            CHelper.WriteLog("codeurl：", codeurl);

            //第一步：引导用户打开如下页面授权
            Response.Redirect(codeurl);
            return;
        }
        else
        {
            CHelper.WriteLog("code：", code);


            //第二步：通过code换取网页授权access_token
            WeiXinSDK.WebCredential wc = WeiXinSDK.WeiXin.GetWebAccessToken(code);

            CHelper.WriteLog("网页授权snsapi_base的access_token：", wc.access_token);


            //判断access_token是否有效
            if (wc.error == null || (wc.error.errcode == 0 && wc.error.errmsg == "ok"))
            {
                //有效
            }
            else
            {
                CHelper.WriteLog("网页授权access_token无效：", wc.access_token);

                //无效重新获取access_token
                wc = WeiXinSDK.WeiXin.GetWebAccessToken(code);
                if (wc.error == null || (wc.error.errcode == 0 && wc.error.errmsg == "ok"))
                {
                    //有效
                }
                else
                {
                    Response.Write("网页授权access_token无效: " + wc.error.ToString());
                    Response.End();
                }
            }

            //第三步：刷新access_token（如果需要）
            //wc = WeiXinSDK.WeiXin.GetWebAccessToken(code);
            CHelper.WriteLog("Oauth ,OpenId", wc.openid);

            MZZ.BLL.tb_user blluser = new MZZ.BLL.tb_user();
            var dt = blluser.GetModelList("user_openid = '" + wc.openid + "'");

            if (dt.Count > 0) //用户已存在
            {
                Session["hyid"] = dt[0].user_id;
                Session["nickname"] = dt[0].user_nick_name;
                Session["phone"] = dt[0].user_phone;
                CHelper.WriteLog("nickname", Session["nickname"].ToString());
                CHelper.WriteLog("phone", Session["phone"].ToString());
                MZZ.Model.tb_user userModel = dt[0];
                Session["UserInfo"] = new UserInfo()
                {
                    TableName = EnumLoginType.User,
                    Entity = userModel
                };

                CHelper.WriteLog("用户已存在", wc.openid);
            }
            else
            {
                if (state == "2")
                {
                    //第四步：拉取用户信息(需scope为 snsapi_userinfo)
                    WeiXinSDK.WebUserInfo useinfo = WeiXinSDK.WeiXin.GetWebUserInfo(wc.access_token, wc.openid, WeiXinSDK.LangType.zh_CN);

                    CHelper.WriteLog("用户不存在并拉取用户信息：", useinfo.openid);
                    new WxUser().InsertUpdateWebUsers(useinfo, null);

                    dt = blluser.GetModelList("user_openid = '" + useinfo.openid + "'");
                    if (dt.Count > 0) //用户已存在
                    {
                        MZZ.Model.tb_user userModel = dt[0];
                        Session["UserInfo"] = new UserInfo()
                        {
                            TableName = EnumLoginType.User,
                            Entity = userModel
                        };
                    }
                }
                else
                {
                    CHelper.WriteLog("用户不存在并获取网页授权snsapi_userinfo信息：", wc.openid);

                    //第二步：通过code换取网页授权access_token
                    scope = "snsapi_userinfo";
                    string codeurl = WeiXinSDK.WeiXin.BuildWebCodeUrl(redirect_uri, scope, "2");
                    Response.Redirect(codeurl);
                    return;
                }
            }
            CHelper.WriteLog("页面跳转", url);
            Response.Redirect(url);
        }
    }
}