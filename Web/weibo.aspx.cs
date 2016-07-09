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
using System.Data;
using Maticsoft.DBUtility;
using System.Text;

public partial class weibo : AbstractPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo userinfo = UserInfoRule.CheckLogin();
        if (userinfo == null || userinfo.TableName != EnumLoginType.User)
        {
       
            Response.Redirect("Oauth.aspx?url=" + Server.UrlEncode(Request.Url.ToString()));
            return;
        }
        MZZ.Model.tb_user userModel = userinfo.Entity as MZZ.Model.tb_user;
        //WeiXinSDK.UserInfo userinfo = WeiXinSDK.WeiXin.GetUserInfo("oNWDuvklEeTEwoLB7l66dNXwF4yc", WeiXinSDK.LangType.zh_CN);

        this.Label1.Text = HttpUtility.UrlDecode( userModel.user_nick_name, Encoding.GetEncoding("GB2312"));

        //string tttttttt= HttpUtility.UrlEncode(userinfo.nickname, Encoding.UTF8);

        //DbHelperMySQL.ExecuteSql("INSERT INTO tb_weibo(openid) VALUES('" + tttttttt + "')");
        //DataSet ds = DbHelperMySQL.Query("SELECT * FROM moeotaku.tb_weibo");
        //DataTable tb = ds.Tables[0];
        //string ddd= HttpUtility.UrlDecode(tb.Rows[0]["openid"].ToString(), Encoding.UTF8);
        //this.Label1.Text = ddd;
    }
}