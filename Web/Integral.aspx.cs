﻿using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceModel;
using EnumLibrary;
using ServiceBiz;
using CommonLibs;

public partial class Integral : AbstractPage
{
    public string code, openid, newsPic, shareurl;
    LogHelper _log = new LogHelper("IntegralLog");

    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo userinfo = UserInfoRule.CheckLogin();
        if (userinfo == null || userinfo.TableName != EnumLoginType.User)
        {
            //_log.WriteLog("页面跳转,Oauth.aspx?url=" + Server.UrlEncode(Request.Url.ToString()));
            Response.Redirect("Oauth.aspx?url=" + Server.UrlEncode(Request.Url.ToString()));
            return;
        }
        code = Request.QueryString["code"];
        MZZ.Model.tb_user userModel = userinfo.Entity as MZZ.Model.tb_user;
        openid = userModel.user_openid;
        //_log.WriteLog("openid测试:" + openid);
        hidopenid.Value = openid;

        MZZ.BLL.tb_user blluser = new MZZ.BLL.tb_user();
        var dt = blluser.GetModelList("user_openid = '" + openid + "'");

        if (dt.Count > 0) //用户已存在
        {
            Hidintegral.InnerText = dt[0].user_integral.ToString();

            _log.WriteLog("用户积分:" + dt[0].user_integral.ToString());
        }

        DataSet ds = DbHelperMySQL.Query("select * from tb_lntegral_prize where lntegral_prize_status='1'");
        DataTable tb = ds.Tables[0];
        this.Image1.ImageUrl = Convert.ToString(tb.Rows[0]["lntegral_prize_img"]);
        this.i1.InnerText = Convert.ToString(tb.Rows[0]["lntegral_prize_cost"]) + "P";
        this.i1.Attributes.Add("prizeID", Convert.ToString(tb.Rows[0]["lntegral_prize_id"]));
        this.Image2.ImageUrl = Convert.ToString(tb.Rows[1]["lntegral_prize_img"]);
        this.i2.InnerText = Convert.ToString(tb.Rows[1]["lntegral_prize_cost"]) + "P";
        this.i2.Attributes.Add("prizeID", Convert.ToString(tb.Rows[1]["lntegral_prize_id"]));
        this.Image3.ImageUrl = Convert.ToString(tb.Rows[2]["lntegral_prize_img"]);
        this.i3.InnerText = Convert.ToString(tb.Rows[2]["lntegral_prize_cost"]) + "P";
        this.i3.Attributes.Add("prizeID", Convert.ToString(tb.Rows[2]["lntegral_prize_id"]));
        this.Image4.ImageUrl = Convert.ToString(tb.Rows[3]["lntegral_prize_img"]);
        this.i4.InnerText = Convert.ToString(tb.Rows[3]["lntegral_prize_cost"]) + "P";
        this.i4.Attributes.Add("prizeID", Convert.ToString(tb.Rows[3]["lntegral_prize_id"]));
        this.Image0.ImageUrl = Convert.ToString(tb.Rows[4]["lntegral_prize_img"]);
        this.i0.InnerText = Convert.ToString(tb.Rows[4]["lntegral_prize_cost"]) + "P";
        this.i0.Attributes.Add("prizeID", Convert.ToString(tb.Rows[4]["lntegral_prize_id"]));

        newsPic = "http://" + Request.Url.Host + "/images/mengmeizi.jpg";
        shareurl = "http://" + Request.Url.Host + "/Lntegral.aspx";



        ds = DbHelperMySQL.Query("SELECT * FROM tb_lntegral_users where openid='" + openid + "' order by createdate desc");
        tb = ds.Tables[0];
        if (tb.Rows.Count > 0)
        {
            inputaddress.Text = Convert.ToString(tb.Rows[0]["address"]);
            inputname.Text = Convert.ToString(tb.Rows[0]["name"]);
            inputphone.Text = Convert.ToString(tb.Rows[0]["cellphone"]);
        }

        ds = DbHelperMySQL.Query("SELECT * FROM tb_lntegral_users left join tb_lntegral_prize on tb_lntegral_prize.lntegral_prize_id=tb_lntegral_users.prizeid where tb_lntegral_prize.lntegral_prize_status='1' and tb_lntegral_users.openid='" + openid + "'");
        tb = ds.Tables[0];
        if (tb.Rows.Count > 0)
        {
            HidStatus.Value = "1";
        }

    }
}