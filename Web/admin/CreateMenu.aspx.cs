using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnumLibrary;
using ServiceBiz;
using ServiceModel;
using WeiXinSDK.Menu;

public partial class admin_CreateMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserInfo userinfo = UserInfoRule.CheckLogin();
            if (userinfo == null || userinfo.TableName != EnumLoginType.Admin)
            {
                Response.Redirect("default.aspx");
                return;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CustomMenu cmenu = CreateMenu1();
        JsonStr.Text = cmenu.GetJSON();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        WeiXinSDK.ReturnCode code = WeiXinSDK.WeiXin.CreateMenu(JsonStr.Text);
        if (code != null && code.errcode == 0)
        {
            WebMessageBox.Show("创建成功！");
        }
        else if (code != null)
        {
            WebMessageBox.Show("创建失败！errcode:" + code.errcode + ",errmsg:" + code.errmsg);
        }
    }

    CustomMenu CreateMenu1()
    {
        MultiButton btn1 = new MultiButton();//菜单一
        btn1.name = "关于旗忠";

        ClickButton btn10 = new ClickButton();
        btn10.name = "最新通知";
        btn10.key = "最新通知";

        ViewButton btn11 = new ViewButton();
        btn11.name = "旗忠微站";
        btn11.url = "http://wap.qi-zhong.com";

        ViewButton btn12 = new ViewButton();
        btn12.name = "驾校介绍";
        btn12.url = "http://wx.qi-zhong.com/about.aspx";

        ViewButton btn13 = new ViewButton();
        btn13.name = "报名价格表";
        btn13.url = "http://wx.qi-zhong.com/train.aspx";

        ViewButton btn14 = new ViewButton();
        btn14.name = "联系方式";
        btn14.url = "http://wx.qi-zhong.com/contact.aspx";

        btn1.AddClickButton(btn10);
        btn1.AddViewButton(btn11);
        btn1.AddViewButton(btn12);
        btn1.AddViewButton(btn13);
        btn1.AddViewButton(btn14);


        ViewButton btn2 = new ViewButton();//菜单二
        btn2.name = "预约学车";
        btn2.url = "http://117.74.136.117:7000/logging/LoginUser.aspx?trainUnitCode=R0007-00";


        MultiButton btn3 = new MultiButton();//菜单三
        btn3.name = "我的专区";

        ViewButton btn31 = new ViewButton();
        btn31.name = "报名优惠";
        btn31.url = "http://wx.qi-zhong.com/activity.aspx";

        ViewButton btn32 = new ViewButton();
        btn32.name = "个人中心";
        btn32.url = "http://wx.qi-zhong.com/Default.aspx";

        ClickButton btn33 = new ClickButton();
        btn33.name = "流量领取";
        btn33.key = "Menu_LiuLiang";

        btn3.AddViewButton(btn31);
        btn3.AddViewButton(btn32);
        btn3.AddClickButton(btn33);

        CustomMenu cmenu = new CustomMenu();
        cmenu.AddMulitButton(btn1);
        cmenu.AddViewButton(btn2);
        cmenu.AddMulitButton(btn3);

        return cmenu;
    }
}