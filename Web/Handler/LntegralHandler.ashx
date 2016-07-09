<%@ WebHandler Language="C#" Class="LntegralHandler" %>

using System;
using System.Web;
using System.Data;
using Maticsoft.DBUtility;
using System.Web.SessionState;
using System.Text;
using MySql.Data.MySqlClient;
public class LntegralHandler : IHttpHandler, IRequiresSessionState
{
    ReturnCode RetCode = new ReturnCode();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";


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
            case "Lntegral":
                context.Response.Write(Lntegral(context));
                break;
            case "share":
                context.Response.Write(share(context));
                break;
            case "checkin":
                context.Response.Write(checkin(context));
                break;
            default:
                RetCode.errcode = -1;
                RetCode.errmsg = "参数act错误";
                context.Response.Write(WeiXinSDK.Util.ToJson(RetCode));
                break;
        }
    }
    public string Lntegral(HttpContext context)
    {
        try
        {

            string openid = context.Request["openid"];
            string prizeid = context.Request["prizeid"];
            string address = context.Request["address"];
            string name = context.Request["name"];
            string cellphone = context.Request["cellphone"];
            DataSet ds = DbHelperMySQL.Query("select * from tb_lntegral_prize where lntegral_prize_id=" + prizeid);
            DataTable tb = ds.Tables[0];
            string lntegral_prize_cost = Convert.ToString(tb.Rows[0]["lntegral_prize_cost"]);
            DbHelperMySQL.ExecuteSql("update tb_user set user_integral=user_integral-" + lntegral_prize_cost + " where user_phone='" + openid + "'");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO tb_lntegral_users(openid, prizeid,address,name,cellphone,createdate) VALUES( ");
            strSql.Append("@openid, @prizeid,@address,@name,@cellphone,current_timestamp)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@openid", MySqlDbType.VarChar,45),
                    new MySqlParameter("@prizeid", MySqlDbType.Int32,11),
                    new MySqlParameter("@address", MySqlDbType.VarChar,100),
                    new MySqlParameter("@name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@cellphone", MySqlDbType.VarChar,45)};
            parameters[0].Value = openid;
            parameters[1].Value = prizeid;
            parameters[2].Value = address;
            parameters[3].Value = name;
            parameters[4].Value = cellphone;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            CommonLibs.CacheHelper.RemoveAllCache("GetExchangeNum");
            RetCode.errcode = 0;
            RetCode.errmsg = "ok";
            return WeiXinSDK.Util.ToJson(RetCode);
        }
        catch (Exception ex)
        {
            CHelper.WriteLog("ex：", ex.ToString());
            RetCode.errcode = -1;
            RetCode.errmsg = "error";
            return WeiXinSDK.Util.ToJson(RetCode);
        }
    }

    public string checkin(HttpContext context)
    {
        string openid = context.Request["openid"];
        return addIntegral(openid, "checkin");
    }

    private string addIntegral(string openid, string type)
    {
        try
        {
            DateTime nowDate = DateTime.Now;
            DataSet ds = DbHelperMySQL.Query("select * from tb_signin where openid='" + openid + "' and year(createdtime)=" + nowDate.Year.ToString() + " and month(createdtime)=" + nowDate.Month.ToString() + " and day(createdtime)=" + nowDate.Day.ToString() + " and type='" + type + "'");
            DataTable tb = ds.Tables[0];
            if (tb.Rows.Count == 0)
            {
                if (type.ToLower() == "share")
                {
                    DbHelperMySQL.ExecuteSql("update tb_user set user_integral=user_integral+30  where user_phone='" + openid + "'");
                }
                else
                {
                    DbHelperMySQL.ExecuteSql("update tb_user set user_integral=user_integral+5  where user_phone='" + openid + "'");
                }
                DbHelperMySQL.ExecuteSql("INSERT INTO tb_signin(openid, type,createdtime) VALUES('" + openid + "','" + type + "',current_timestamp)");
                CommonLibs.CacheHelper.RemoveAllCache("UserInfo" + openid);
                RetCode.errcode = 0;
                RetCode.errmsg = "ok";
            }
            else
            {
                RetCode.errcode = 1;
                RetCode.errmsg = "done";

            }
            return WeiXinSDK.Util.ToJson(RetCode);
        }
        catch (Exception ex)
        {
            CHelper.WriteLog("ex：", ex.ToString());
            RetCode.errcode = -1;
            RetCode.errmsg = "error";
            return WeiXinSDK.Util.ToJson(RetCode);
        }
    }

    public string share(HttpContext context)
    {
        string openid = context.Request["openid"];
        return addIntegral(openid, "share");
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}