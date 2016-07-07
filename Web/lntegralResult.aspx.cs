using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lntegralResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = DbHelperMySQL.Query("SELECT tb_user.user_nick_name,tb_lntegral_users.address,tb_lntegral_users.cellphone,tb_lntegral_users.name,tb_lntegral_prize.lntegral_prize_name,tb_lntegral_users.createdate FROM tb_lntegral_users left join tb_user on tb_user.user_phone=tb_lntegral_users.openid left join tb_lntegral_prize on tb_lntegral_prize.lntegral_prize_id=tb_lntegral_users.prizeid order by tb_lntegral_users.createdate desc");
        DataTable tb = ds.Tables[0];
        this.GridView1.DataSource = tb;
        this.GridView1.DataBind();
    }
}