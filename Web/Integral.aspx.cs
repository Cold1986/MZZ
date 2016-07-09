using Maticsoft.DBUtility;
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
            Response.Redirect("Oauth.aspx?url=" + Server.UrlEncode(Request.Url.ToString()));
            return;
        }
        code = Request.QueryString["code"];
        MZZ.Model.tb_user userModel = userinfo.Entity as MZZ.Model.tb_user;
        openid = userModel.user_openid;
        hidopenid.Value = openid;

        var dt = UserInfoRule.GetUserInfo(openid);

        if (dt.Count > 0) //用户已存在
        {
            Hidintegral.InnerText = dt[0].user_integral.ToString();
        }

        newsPic = "http://" + Request.Url.Host + "/images/mengmeizi.jpg";
        shareurl = "http://" + Request.Url.Host + "/Integral.aspx";

        #region 奖品信息部分
        DataTable tb = IntegralPrizeRule.GetPirzeDataTableByBatch(1);
        this.Image1.ImageUrl = Convert.ToString(tb.Rows[0]["lntegral_prize_img"]);
        this.i1.InnerText = Convert.ToString(tb.Rows[0]["lntegral_prize_cost"]) + "P";
        this.i1n.InnerText = IntegralPrizeRule.GetRemainderNum(Convert.ToString(tb.Rows[0]["lntegral_prize_id"]), Convert.ToString(tb.Rows[0]["lntegral_prize_num"]));
        this.i1.Attributes.Add("prizeID", Convert.ToString(tb.Rows[0]["lntegral_prize_id"]));

        this.Image2.ImageUrl = Convert.ToString(tb.Rows[1]["lntegral_prize_img"]);
        this.i2.InnerText = Convert.ToString(tb.Rows[1]["lntegral_prize_cost"]) + "P";
        this.i2n.InnerText = IntegralPrizeRule.GetRemainderNum(Convert.ToString(tb.Rows[1]["lntegral_prize_id"]), Convert.ToString(tb.Rows[1]["lntegral_prize_num"]));
        this.i2.Attributes.Add("prizeID", Convert.ToString(tb.Rows[1]["lntegral_prize_id"]));

        this.Image3.ImageUrl = Convert.ToString(tb.Rows[2]["lntegral_prize_img"]);
        this.i3.InnerText = Convert.ToString(tb.Rows[2]["lntegral_prize_cost"]) + "P";
        this.i3n.InnerText = IntegralPrizeRule.GetRemainderNum(Convert.ToString(tb.Rows[2]["lntegral_prize_id"]), Convert.ToString(tb.Rows[2]["lntegral_prize_num"]));
        this.i3.Attributes.Add("prizeID", Convert.ToString(tb.Rows[2]["lntegral_prize_id"]));

        this.Image4.ImageUrl = Convert.ToString(tb.Rows[3]["lntegral_prize_img"]);
        this.i4.InnerText = Convert.ToString(tb.Rows[3]["lntegral_prize_cost"]) + "P";
        this.i4n.InnerText = IntegralPrizeRule.GetRemainderNum(Convert.ToString(tb.Rows[3]["lntegral_prize_id"]), Convert.ToString(tb.Rows[3]["lntegral_prize_num"]));
        this.i4.Attributes.Add("prizeID", Convert.ToString(tb.Rows[3]["lntegral_prize_id"]));

        this.Image0.ImageUrl = Convert.ToString(tb.Rows[4]["lntegral_prize_img"]);
        this.i0.InnerText = Convert.ToString(tb.Rows[4]["lntegral_prize_cost"]) + "P";
        this.i0.Attributes.Add("prizeID", Convert.ToString(tb.Rows[4]["lntegral_prize_id"]));
        this.i0n.InnerText = IntegralPrizeRule.GetRemainderNum(Convert.ToString(tb.Rows[4]["lntegral_prize_id"]), Convert.ToString(tb.Rows[4]["lntegral_prize_num"]));
        #endregion



        DataSet ds = DbHelperMySQL.Query("SELECT 1 FROM tb_lntegral_users left join tb_lntegral_prize on tb_lntegral_prize.lntegral_prize_id=tb_lntegral_users.prizeid where tb_lntegral_prize.lntegral_prize_status='1' and tb_lntegral_users.openid='" + openid + "'");
        tb = ds.Tables[0];
        if (tb.Rows.Count > 0)//本次活动已经兑换过
        {
            HidStatus.Value = "1";
        }
        else
        {
            MZZ.BLL.tb_lntegral_users bllIntegralUser = new MZZ.BLL.tb_lntegral_users();
            ds = bllIntegralUser.GetList("openid='" + openid + "' order by createdate desc");
            tb = ds.Tables[0];
            if (tb.Rows.Count > 0)
            {
                inputaddress.Text = Convert.ToString(tb.Rows[0]["address"]);
                inputname.Text = Convert.ToString(tb.Rows[0]["name"]);
                inputphone.Text = Convert.ToString(tb.Rows[0]["cellphone"]);
            }
        }

    }
}