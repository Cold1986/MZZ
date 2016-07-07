using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using WeiXinSDK.Helpers;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;

namespace WeiXinSDK.Pay
{
    /// <summary>
    /// 微信现金红包接口
    /// http://pay.weixin.qq.com/wiki/doc/api/cash_coupon.php?chapter=13_6
    /// </summary>
    public class WxHbPayAPI
    {
        /// <summary>
        /// 获取微信现金红包信息接口
        /// 是否需要证书:需要。 
        /// http://pay.weixin.qq.com/wiki/doc/api/cash_coupon.php?chapter=13_6
        /// 使用说明 
        /// 用于商户对已发放的红包进行查询红包的具体信息，可支持普通红包和裂变包。
        /// </summary>
        /// <param name="nonce_str">(必填) String(32) 随机字符串,不长于32位</param>
        /// <param name="mch_billno">(必填) String(28) 商户发放红包的商户订单号</param>
        /// <param name="mch_id">(必填) String(32) 微信支付分配的商户号</param>
        /// <param name="appid">(必填) String(32) 微信分配的公众账号ID</param>
        /// <param name="bill_type">(必填) String(32) 订单类型  例子：MCHT ，通过商户订单号获取红包信息。</param>
        /// <param name="partnerKey">API密钥</param>
        /// <param name="cert_path">秘钥路径</param>
        /// <param name="cert_password">秘钥密码</param>
        /// <returns>返回xml字符串，格式参见：http://pay.weixin.qq.com/wiki/doc/api/cash_coupon.php?chapter=13_6 </returns>
        public static string GetHbInfo(string nonce_str, string mch_billno, string mch_id, string appid,
            string bill_type, string partnerKey, string cert_path, string cert_password)
        {
            try
            {
                var stringADict = new Dictionary<string, string>();
                stringADict.Add("nonce_str", nonce_str);
                stringADict.Add("mch_billno", mch_billno);
                stringADict.Add("mch_id", mch_id);
                stringADict.Add("appid", appid);
                stringADict.Add("bill_type", bill_type);

                var sign = WxPayAPI.Sign(stringADict, partnerKey);//生成签名字符串
                var postdata = PayUtil.GeneralPostdata(stringADict, sign);
                var url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/gethbinfo";

                // 要注意的这是这个编码方式，还有内容的Xml内容的编码方式
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                byte[] data = encoding.GetBytes(postdata);

                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

                //X509Certificate cer = new X509Certificate(cert_path, cert_password);
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                X509Certificate cer = new X509Certificate(cert_path, cert_password);

                #region 该部分是关键，若没有该部分则在IIS下会报 CA证书出错
                X509Certificate2 certificate = new X509Certificate2(cert_path, cert_password);
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadWrite);
                store.Remove(certificate);   //可省略
                store.Add(certificate);
                store.Close();

                #endregion

                HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
                webrequest.ClientCertificates.Add(cer);
                webrequest.Method = "post";
                webrequest.ContentLength = data.Length;


                Stream outstream = webrequest.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Flush();
                outstream.Close();


                HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
                Stream instream = webreponse.GetResponseStream();
                string resp = string.Empty;
                using (StreamReader reader = new StreamReader(instream))
                {
                    resp = reader.ReadToEnd();
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// http://pay.weixin.qq.com/wiki/doc/api/cash_coupon.php?chapter=13_5
        /// 1.应用场景:向指定微信用户的openid发放指定金额红包
        ///是否需要证书:需要。
        ///<param name="nonce_str">(必填) String(32) 随机字符串,不长于32位</param>
        ///<param name="mch_billno">(必填) String(32) 商户订单号（每个订单号必须唯一）组成： mch_id+yyyymmdd+10位一天内不能重复的数字。</param>
        ///<param name="mch_id">(必填) String(32) 微信支付分配的商户号</param>
        ///<param name="sub_mch_id"> String(32) 微信支付分配的子商户号，受理模式下必填</param>
        /// <param name="wxappid">(必填) String(32) 商户appid</param>
        /// <param name="nick_name">(必填) String(32) 提供方名称</param>
        /// <param name="send_name">(必填) String(32) 红包发送者名称</param>
        /// <param name="re_openid">(必填) String(32) 接受收红包的用户 用户在wxappid下的openid</param>
        /// <param name="total_amount">(必填) int 付款金额，单位分</param>
        /// <param name="min_value">(必填) int 最小红包金额，单位分</param>
        /// <param name="max_value">(必填) int 最大红包金额，单位分</param>
        /// <param name="total_num">(必填) int 红包发放总人数</param>
        /// <param name="wishing">(必填) String(128) 红包祝福语</param>
        /// <param name="client_ip">(必填) String(15) 调用接口的机器Ip地址</param>
        /// <param name="act_name">(必填) String(32) 活动名称</param>
        /// <param name="remark">(必填) String(256) 备注信息</param>
        /// <param name="logo_imgurl"> String(128) 商户logo的url</param>
        /// <param name="share_content"> String(256) 分享文案</param>
        /// <param name="share_url"> String(128) 分享链接</param>
        /// <param name="share_imgurl"> String(128) 分享的图片url</param>
        /// <param name="partnerKey">API密钥</param>
        /// <param name="cert_path">秘钥路径</param>
        /// <param name="cert_password">秘钥密码</param>
        /// <returns>返回xml字符串，格式参见：http://pay.weixin.qq.com/wiki/doc/api/cash_coupon.php?chapter=13_5 </returns>
        public static string SendRedPack(string nonce_str, string mch_billno, string mch_id,
                                     string sub_mch_id, string wxappid, string nick_name, string send_name,
                                     string re_openid, int total_amount, int min_value, int max_value,
                                     int total_num, string wishing, string client_ip, string act_name,
                                     string remark, string logo_imgurl, string share_content, string share_url,
                                     string share_imgurl, string partnerKey, string cert_path, string cert_password)
        {
            try
            {
                var stringADict = new Dictionary<string, string>();
                stringADict.Add("nonce_str", nonce_str);
                stringADict.Add("mch_billno", mch_billno);
                stringADict.Add("mch_id", mch_id);
                stringADict.Add("sub_mch_id", sub_mch_id);
                stringADict.Add("wxappid", wxappid);
                stringADict.Add("nick_name", nick_name);
                stringADict.Add("send_name", send_name);
                stringADict.Add("re_openid", re_openid);
                stringADict.Add("total_amount", total_amount.ToString());
                stringADict.Add("min_value", min_value.ToString());
                stringADict.Add("max_value", max_value.ToString());
                stringADict.Add("total_num", total_num.ToString());
                stringADict.Add("wishing", wishing.ToString());
                stringADict.Add("client_ip", client_ip);
                stringADict.Add("act_name", act_name);
                stringADict.Add("remark", remark);
                stringADict.Add("logo_imgurl", logo_imgurl);
                stringADict.Add("share_content", share_content);
                stringADict.Add("share_url", share_url);
                stringADict.Add("share_imgurl", share_imgurl);

                var sign = WxPayAPI.Sign(stringADict, partnerKey);//生成签名字符串
                var postdata = PayUtil.GeneralPostdata(stringADict, sign);
                var url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack";

                // 要注意的这是这个编码方式，还有内容的Xml内容的编码方式
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                byte[] data = encoding.GetBytes(postdata);

                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                //X509Certificate cer = new X509Certificate(cert_path, cert_password);
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                X509Certificate cer = new X509Certificate(cert_path, cert_password);

                #region 该部分是关键，若没有该部分则在IIS下会报 CA证书出错
                X509Certificate2 certificate = new X509Certificate2(cert_path, cert_password);
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadWrite);
                store.Remove(certificate);   //可省略
                store.Add(certificate);
                store.Close();

                #endregion

                HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
                webrequest.ClientCertificates.Add(cer);
                webrequest.Method = "post";
                webrequest.ContentLength = data.Length;


                Stream outstream = webrequest.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Flush();
                outstream.Close();

                HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
                Stream instream = webreponse.GetResponseStream();
                string resp = string.Empty;
                using (StreamReader reader = new StreamReader(instream))
                {
                    resp = reader.ReadToEnd();
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == SslPolicyErrors.None)
                return true;
            return false;
        }
    }
}
