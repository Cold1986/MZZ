using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Users 的摘要说明
/// </summary>
public class WxUser
{
    public bool GetUserList()
    {
        WeiXinSDK.Followers allFollower = new WeiXinSDK.Followers();
        //第一步：获取所有关注者列表
        allFollower = WeiXinSDK.WeiXin.GetAllFollowers();
        if (allFollower.error == null)
        {
            int count = allFollower.data.openid.Count;
            //第二步：将关注者列表的用户数据更新回数据库
            MZZ.BLL.tb_user userBLL = new MZZ.BLL.tb_user();
            try
            {
                List<string> openids = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    //获取用户数据
                    string openid = allFollower.data.openid[i];
                    openids.Add(openid);

                    WeiXinSDK.UserInfo userinfo = WeiXinSDK.WeiXin.GetUserInfo(openid, WeiXinSDK.LangType.zh_CN);

                    if (userinfo.error == null)
                    {
                        //添加或更新到用户表
                        InsertOrUpdateUsers(userinfo, null);
                    }
                }
                var usersList = userBLL.GetModelList("user_status>0");
                //更改用户状态为未关注
                for (int i = 0; i < usersList.Count; i++)
                {
                    if (!openids.Contains(usersList[i].user_openid))
                    {
                        usersList[i].user_sub_scribe = false;
                        userBLL.Update(usersList[i]);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //添加或更新用户
    public void InsertOrUpdateUsers(string openid, string uopenid)
    {
        WeiXinSDK.UserInfo userinfo = WeiXinSDK.WeiXin.GetUserInfo(openid, WeiXinSDK.LangType.zh_CN);

        if (userinfo.error == null)
        {
            //添加或更新到用户表
            InsertOrUpdateUsers(userinfo, uopenid);
        }
    }

    //添加或更新用户
    public void InsertOrUpdateUsers(WeiXinSDK.UserInfo userinfo, string uopenid)
    {
        try
        {
            //获取当前openid对应的商户及用户信息
            MZZ.BLL.tb_user userBLL = new MZZ.BLL.tb_user();
            var usersList = userBLL.GetModelList("user_openid='" + userinfo.openid + "'");

            MZZ.Model.tb_user usersModel = new MZZ.Model.tb_user();
            if (usersList.Count > 0)//更新
            {
                usersModel = usersList[0];
            }
            WeiXinSDK.QRCodeTicket ticket = WeiXinSDK.WeiXin.CreateQRCode2(userinfo.openid);
            if (!string.IsNullOrEmpty(uopenid) && string.IsNullOrEmpty(usersModel.user_up_openid))
            {

                MZZ.BLL.tb_user waiterBLL = new MZZ.BLL.tb_user();
                var waiterList = waiterBLL.GetModelList("user_openid='" + uopenid + "'");
                if (waiterList.Count > 0 && usersModel.user_openid != waiterList[0].user_openid)
                {
                    usersModel.user_uopenid_time = Convert.ToDateTime(DateTime.Now);
                    usersModel.user_up_openid = waiterList[0].user_openid;//设置上线
                }
            }

            if (userinfo.subscribe == 1)
            {
                usersModel.user_nick_name = WebHelp.GB2312ToUTF8(userinfo.nickname);
                usersModel.user_head_img_url = WebHelp.GB2312ToUTF8(userinfo.headimgurl);
                usersModel.user_sub_time = CHelper.UnixTimeToTime(userinfo.subscribe_time);
                usersModel.user_qr_code = ticket.ticket;
            }
            usersModel.user_sub_scribe = Convert.ToBoolean(userinfo.subscribe);
            if (usersList.Count > 0)//更新
            {
                userBLL.Update(usersModel);
            }
            else//添加
            {
                usersModel.user_qr_code = ticket.ticket;
                usersModel.user_phone = userinfo.openid;
                usersModel.user_openid = userinfo.openid;
                userBLL.Add(usersModel);
            }
        }
        catch (Exception ex)
        {
            CHelper.WriteLog("ex：", ex.ToString());
            throw ex;
            
        }
    }

    ///网页端添加用户表
    public void InsertUpdateWebUsers(WeiXinSDK.WebUserInfo userinfo, string uopenid)
    {
        try
        {
            MZZ.BLL.tb_user userBLL = new MZZ.BLL.tb_user();
            //获取用户信息
            WeiXinSDK.UserInfo userinfo2 = WeiXinSDK.WeiXin.GetUserInfo(userinfo.openid, WeiXinSDK.LangType.zh_CN);
            
            //获取当前openid对应的商户及用户信息
            var usersList = userBLL.GetModelList("user_openid='" + userinfo.openid + "'");

            MZZ.Model.tb_user usersModel = new MZZ.Model.tb_user();
            if (usersList.Count > 0)//更新
            {
                usersModel = usersList[0];
            }
            WeiXinSDK.QRCodeTicket ticket = WeiXinSDK.WeiXin.CreateQRCode2(userinfo.openid);
            if (!string.IsNullOrEmpty(uopenid) && string.IsNullOrEmpty(usersModel.user_up_openid))
            {
                MZZ.BLL.tb_user waiterBLL = new MZZ.BLL.tb_user();
                var waiterList = waiterBLL.GetModelList("user_openid='" + uopenid + "'");
                if (waiterList.Count > 0 && usersModel.user_openid != waiterList[0].user_openid)
                {
                    usersModel.user_uopenid_time = Convert.ToDateTime(DateTime.Now);
                    usersModel.user_up_openid = waiterList[0].user_openid;//设置上线
                }
            }

            if (userinfo2.subscribe == 1)
            {
                usersModel.user_sub_scribe = true;
                usersModel.user_nick_name = WebHelp.GB2312ToUTF8(userinfo2.nickname);
                usersModel.user_head_img_url = userinfo2.headimgurl;
                usersModel.user_sub_time = Convert.ToDateTime(DateTime.Now);
            }
            else
            {
                usersModel.user_sub_scribe = false;
                usersModel.user_nick_name = WebHelp.GB2312ToUTF8(userinfo.nickname);
                usersModel.user_head_img_url = userinfo.headimgurl;
                usersModel.user_qr_code = ticket.ticket;
                usersModel.user_sub_time = Convert.ToDateTime(DateTime.Now);
            }
            
            if (usersList.Count > 0)//更新
            {
                userBLL.Update(usersModel);
            }
            else
            {
                usersModel.user_qr_code = ticket.ticket;
                usersModel.user_phone = userinfo.openid;
                usersModel.user_openid = userinfo.openid;
                userBLL.Add(usersModel);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}