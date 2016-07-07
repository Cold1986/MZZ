using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs;
using EnumLibrary;
using ServiceModel;

namespace ServiceBiz
{
    public class UserInfoRule
    {
        public static UserInfo CheckLogin()
        {
            try
            {
                UserInfo userInfo = SessionHelper.Get("UserInfo") as UserInfo;
                if (userInfo == null)
                {
                    return null;
                }
                else
                {
                    switch (userInfo.TableName)
                    {
                        case EnumLoginType.User:
                            MZZ.Model.tb_user usersEntity = userInfo.Entity as MZZ.Model.tb_user;
                            MZZ.BLL.tb_user usersBLL = new MZZ.BLL.tb_user();
                            MZZ.Model.tb_user usersModel = usersBLL.GetModel(usersEntity.user_id);
                            if (usersModel.user_id == usersEntity.user_id)
                            {
                                userInfo.Entity = usersModel;
                                return userInfo;
                            }
                            break;
                        //case LoginType.Admin:
                        //    MZZ.Model.admins adminEntity = userInfo.Entity as MZZ.Model.admins;
                        //    MZZ.BLL.admins adminBLL = new MZZ.BLL.admins();
                        //    MZZ.Model.admins adminModel = adminBLL.GetModel(adminEntity.id);
                        //    if (adminModel.id == adminEntity.id)
                        //    {
                        //        userInfo.Entity = adminModel;
                        //        return userInfo;
                        //    }
                        //    break;
                        default:
                            return null;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        //to do...
        /// <summary>
        /// 根据user_openid获取用户信息
        /// </summary>
        /// <param name="user_openid"></param>
        /// <returns></returns>
        public static List<MZZ.Model.tb_user> GetUserInfo(string user_openid)
        {
            return null;
        }
    }
}
