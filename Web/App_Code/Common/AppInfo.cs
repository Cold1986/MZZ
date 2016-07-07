using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
///GetAppInfo 的摘要说明
/// </summary>
public class AppInfo
{
    public string appid { get; set; }
    public string secret { get; set; }
    public string token { get; set; }
    public string URL { get; set; }
    public string EncodingAESKey { get; set; }

    //微信红包 
    public string mch_id { get; set; }
    public string cert_path { get; set; }//秘钥路径
    public string cart_password { get; set; }//秘钥密码
    public string PartnerKey { get; set; }

    public static AppInfo GetGetAppInfo()
    {
        AppInfo appinfo = new AppInfo();
        appinfo.appid = ConfigurationManager.AppSettings["appid"];
        appinfo.secret = ConfigurationManager.AppSettings["secret"];
        appinfo.token = ConfigurationManager.AppSettings["token"];
        appinfo.URL = ConfigurationManager.AppSettings["URL"];
        appinfo.EncodingAESKey = ConfigurationManager.AppSettings["EncodingAESKey"];

        appinfo.mch_id = ConfigurationManager.AppSettings["mch_id"];
        appinfo.cert_path = ConfigurationManager.AppSettings["cert_path"];
        appinfo.cart_password = ConfigurationManager.AppSettings["cart_password"];
        appinfo.PartnerKey = ConfigurationManager.AppSettings["PartnerKey"];
        return appinfo;
    }
}