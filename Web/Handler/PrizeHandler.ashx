<%@ WebHandler Language="C#" Class="PrizeHandler" %>

using System;
using System.Web;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Activities.Statements;
using System.Transactions;

public class PrizeHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public int status = 0;
    public int activityid = 0;

    public void ProcessRequest(HttpContext context)
    {
        ServiceModel.UserInfo userinfo = ServiceBiz.UserInfoRule.CheckLogin();
        MZZ.Model.tb_user userModel = userinfo.Entity as MZZ.Model.tb_user;
        string openid = userModel.user_openid;
        //string openid = "oNWDuvlYvwliYCQg1isnXUlCCzyg";
        context.Response.ContentType = "text/plain";

        if (userinfo == null || userinfo.TableName != EnumLibrary.EnumLoginType.User)
        {
            var result = new { iserror = true, results = "您还没有登录呢！" };
            context.Response.Write(WeiXinSDK.Util.ToJson(result));
            return;
        }

        MZZ.BLL.tb_code codeBLL = new MZZ.BLL.tb_code();
        MZZ.BLL.tb_activity activityBLL = new MZZ.BLL.tb_activity();
        MZZ.Model.tb_activity activityModel = new MZZ.Model.tb_activity();
        var rotorList = activityBLL.GetList("to_days(activity_times)=to_days(now()) and activity_openid='" + openid + "' and activity_reason='分享抽奖' and activity_state=1");
        if (rotorList.Tables[0].DefaultView.Count == 0)
        {
            var maxList = activityBLL.GetModelList("to_days(activity_times)=to_days(now()) and activity_openid='" + openid + "' and activity_reason='抽奖'");
            if (maxList.Count >= 2)
            {
                var result = new { iserror = true, results = "您的抽奖次数已经用完了！" };
                context.Response.Write(WeiXinSDK.Util.ToJson(result));
                return;
            }
        }
        else
        {
            activityid = Convert.ToInt32(rotorList.Tables[0].Rows[0]["activity_id"]);
            status = Convert.ToInt32(rotorList.Tables[0].Rows[0]["activity_state"]);
        }
        //MZZ.Model.users userModel = userinfo.Entity as MZZ.Model.users;

        //string code = context.Request["code"];
        //if (string.IsNullOrEmpty(code))
        //{
        //    var result = new { iserror = true, results = "请用微信扫描抽奖二维码进入该页面" };
        //    context.Response.Write(WeiXinSDK.Util.ToJson(result));
        //    return;
        //}

        //var codeModelList = codeBLL.GetModelList("Code='" + code + "'");
        //if (codeModelList.Count == 0)
        //{
        //    var result = new { iserror = true, results = "请用微信扫描抽奖二维码进入该页面" };
        //    context.Response.Write(WeiXinSDK.Util.ToJson(result));
        //    return;
        //}
        //if (codeModelList[0].Status == 10)
        //{
        //    var result = new { iserror = true, results = "您的抽奖次数已经用完了！" };
        //    context.Response.Write(WeiXinSDK.Util.ToJson(result));
        //    return;
        //}
        TransactionOptions transactionOption = new TransactionOptions();
        //设置事务隔离级别
        transactionOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
        // 设置事务超时时间为60秒
        transactionOption.Timeout = new TimeSpan(0, 0, 60);
        using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope(TransactionScopeOption.Required, transactionOption))
        {
            try
            {
                MZZ.Model.tb_code codeModelList = new MZZ.Model.tb_code();
                MZZ.BLL.tb_prizes prizeBLL = new MZZ.BLL.tb_prizes();
                var prizeList = prizeBLL.GetModelList("");
                if (prizeList.Count > 0)
                {
                    prizeList = prizeList.OrderBy(a => Convert.ToInt32(a.prizes_probability)).ToList();
                    var last = prizeList.LastOrDefault();
                    int max = 0;
                    if (last != null)
                    {
                        max = Convert.ToInt32(last.prizes_probability);
                    }
                    int angle = 0;
                    string resultStr = "";
                    int random = 0;
                    int random1 = new Random().Next(0, max);
                    int random2 = new Random().Next(0, max);
                    random = random1 + random2;
                    if (random > max)
                    {
                        random = max;
                    }
                    foreach (var prize in prizeList)
                    {
                        if (random <= Convert.ToInt32(prize.prizes_probability) && prize.prizes_quantity > 0)
                        {
                            angle = Convert.ToInt32(prize.prizes_angle);
                            resultStr = prize.prizes_prize_name;
                            prize.prizes_quantity = prize.prizes_quantity - 1;
                            prizeBLL.Update(prize);

                            MZZ.BLL.tb_user userBLL = new MZZ.BLL.tb_user();
                            if (prize.prizes_prize_name == "积分")
                            {
                                userModel.user_integral = userModel.user_integral + 20;
                                userBLL.Update(userModel);
                                resultStr = "" + prize.prizes_prize_name + ",积分兑换页面将于7月开启";
                            }
                            codeModelList.code_openid = openid;
                            codeModelList.code_code = "";
                            codeModelList.code_main_img = "";
                            codeModelList.code_remark = "";
                            codeModelList.code_create_time = Convert.ToDateTime(System.DateTime.Now);
                            codeModelList.code_userid = 1;
                            codeModelList.code_prizeid = prize.prizes_id;
                            codeModelList.code_prize_name = WebHelp.GB2312ToUTF8(prize.prizes_prize_name);
                            codeBLL.Add(codeModelList);

                            var activityfxModel = activityBLL.GetModel(activityid);
                            if (activityfxModel != null)
                            {
                                activityfxModel.activity_state = 0;
                                activityBLL.Update(activityfxModel);
                            }

                            activityModel.activity_openid = openid;
                            activityModel.activity_reason = WebHelp.GB2312ToUTF8("抽奖");
                            activityModel.activity_hyid = 0;
                            activityModel.activity_num = 0;
                            activityModel.activity_calculate = 0;
                            activityModel.activity_state = 1;
                            activityModel.activity_times = Convert.ToDateTime(System.DateTime.Now);
                            activityBLL.Add(activityModel);
                            scope.Complete();
                            break;
                        }
                    }
                    var result = new { iserror = false, isHasChance = true, rotate = angle, results = resultStr };
                    context.Response.Write(WeiXinSDK.Util.ToJson(result));
                }
                else
                {
                    var result = new { iserror = true, results = "管理员还没有添加奖品哦！" };
                    context.Response.Write(WeiXinSDK.Util.ToJson(result));
                }
            }
            catch (Exception ex)
            {
                var result = new { iserror = true, results = "系统内部异常！" };
                context.Response.Write(WeiXinSDK.Util.ToJson(result));
            }
            finally
            {
                scope.Dispose();
            }
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