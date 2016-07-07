using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Text;

/// <summary>
///WebHelp 的摘要说明
/// </summary>
public class WebHelp
{
    public static string HttpGet(string Url, string postDataStr)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
        request.Method = "GET";
        request.ContentType = "text/html;charset=UTF-8";

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream myResponseStream = response.GetResponseStream();
        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
        string retString = myStreamReader.ReadToEnd();
        myStreamReader.Close();
        myResponseStream.Close();

        return retString;
    }

    ////获取今天商品价格
    //public static double GetTodayPrice(object id, object price0, object price1, object price2, object price3, object price4, object price5, object price6)
    //{
    //    long iid = long.Parse(id.ToString());
    //    JieEn.BLL.PreferentialPrice bll = new JieEn.BLL.PreferentialPrice();
    //    var model = bll.GetModelList(string.Format("HotelId={0} and Holidays='{1}-{2}-{3}' ", iid, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).FirstOrDefault();
    //    if (model != null)
    //    {
    //        return NumHelper.CentToDollar(model.Price);
    //    }

    //    switch ((int)DateTime.Now.DayOfWeek)
    //    {
    //        case 0:
    //            return NumHelper.CentToDollar(price0);
    //        case 1:
    //            return NumHelper.CentToDollar(price1);
    //        case 2:
    //            return NumHelper.CentToDollar(price2);
    //        case 3:
    //            return NumHelper.CentToDollar(price3);
    //        case 4:
    //            return NumHelper.CentToDollar(price4);
    //        case 5:
    //            return NumHelper.CentToDollar(price5);
    //        case 6:
    //            return NumHelper.CentToDollar(price6);
    //    }
    //    return 0;
    //}

    ////获取今天商品价格
    //public static double GetTodayPrice(JieEn.Model.Hotel hotelModel)
    //{
    //    long iid = hotelModel.ID;
    //    JieEn.BLL.PreferentialPrice bll = new JieEn.BLL.PreferentialPrice();
    //    var model = bll.GetModelList(string.Format("HotelId={0} and Holidays='{1}-{2}-{3}' ", iid, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).FirstOrDefault();
    //    if (model != null)
    //    {
    //        return NumHelper.CentToDollar(model.Price);
    //    }

    //    switch ((int)DateTime.Now.DayOfWeek)
    //    {
    //        case 0:
    //            return NumHelper.CentToDollar(hotelModel.Price0);
    //        case 1:
    //            return NumHelper.CentToDollar(hotelModel.Price1);
    //        case 2:
    //            return NumHelper.CentToDollar(hotelModel.Price2);
    //        case 3:
    //            return NumHelper.CentToDollar(hotelModel.Price3);
    //        case 4:
    //            return NumHelper.CentToDollar(hotelModel.Price4);
    //        case 5:
    //            return NumHelper.CentToDollar(hotelModel.Price5);
    //        case 6:
    //            return NumHelper.CentToDollar(hotelModel.Price6);
    //    }
    //    return 0;
    //}


    ////获取某天的商品价格
    //public static double GetPriceOfDate(JieEn.Model.Hotel hotelModel, DateTime date)
    //{
    //    long iid = hotelModel.ID;
    //    JieEn.BLL.PreferentialPrice bll = new JieEn.BLL.PreferentialPrice();
    //    var model = bll.GetModelList(string.Format("HotelId={0} and Holidays='{1}-{2}-{3}' ", iid, date.Year, date.Month, date.Day)).FirstOrDefault();
    //    if (model != null)
    //    {
    //        return NumHelper.CentToDollar(model.Price);
    //    }

    //    switch ((int)date.DayOfWeek)
    //    {
    //        case 0:
    //            return NumHelper.CentToDollar(hotelModel.Price0);
    //        case 1:
    //            return NumHelper.CentToDollar(hotelModel.Price1);
    //        case 2:
    //            return NumHelper.CentToDollar(hotelModel.Price2);
    //        case 3:
    //            return NumHelper.CentToDollar(hotelModel.Price3);
    //        case 4:
    //            return NumHelper.CentToDollar(hotelModel.Price4);
    //        case 5:
    //            return NumHelper.CentToDollar(hotelModel.Price5);
    //        case 6:
    //            return NumHelper.CentToDollar(hotelModel.Price6);
    //    }
    //    return 0;
    //}

    //把string转换为int类型
    public static int ConvertStringToInt(string str)
    {
        int istr;
        try
        {
            istr = Convert.ToInt32(str);
            return istr;
        }
        catch
        {
            return -1;
        }
    }

    //把object转换为double的类型，钱（分转元）
    public static object ConvertObjectToMoney(object obj)
    {
        if (obj == DBNull.Value || obj == null || obj == "")
        {
            return "";
        }
        else
        {
            try
            {
                int money = Convert.ToInt32(obj);
                if (money == 0)
                    return "0.00";
                else
                    return (money / 100.00).ToString("f2");
            }
            catch
            {
                return "";
            }
        }
    }

    //把object转换为string的类型，钱（分转元）
    public static string ConvertObjectToString(object obj)
    {
        if (obj == DBNull.Value || obj == null || obj == "")
        {
            return "";
        }
        else
        {
            try
            {
                return Convert.ToString(obj);
            }
            catch
            {
                return "";
            }
        }
    }

    public static string HongBaoLink(object obj1, object obj2)
    {
        try
        {
            int id = Convert.ToInt32(obj1);
            string status = obj2.ToString();
            if (status == "0")//未发放
            {
                return "<a href='javascript:void(0)' onclick='setstatus(" + id + ",1)'>发放</a>";
            }
            else if (status == "1")//审核中
            {
                return "<a href='javascript:void(0)' onclick='setstatus(" + id + ",0)'>取消发放</a>";
            }
            else//发放中，已发放
            {
                return "";
            }
        }
        catch
        {
            return "";
        }
    }

    public static string HongBaoHongBao(object obj1, object obj2)
    {
        string str = "";
        if (obj1 != null && obj1 != "" && obj2 != null && obj2 != "")
        {
            str = obj1 + "—" + obj2;
        }
        else
        {
            str = "没有";
        }
        return str;
    }


    public static string OrderHongBao(object obj1, object obj2)
    {
        string str = "";
        if (obj1 != null && obj1 != "" && obj2 != null && obj2 != "")
        {
            str = obj1 + "—" + obj2;
        }
        else
        {
            str = "没有";
        }
        return str;
    }
    public static string HongBaoStatus(object status)
    {
        string str = "未知";
        string str1 = status.ToString();
        if (str1 == "1")
        {
            str = "未结算";
        }
        else if (str1 == "10")
        {
            str = "结算中";
        }
        else if (str1 == "20")
        {
            str = "已结算";
        }
        return str;
    }

    /// <summary>
    /// 订单状态
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public static string OrderStatus(object status)
    {
        string str = "未知";
        string str1 = status.ToString();
        if (status.ToString() == "1")
        {
            return "未发送红包";
        }
        else if (status.ToString() == "10")
        {
            return "已发送红包";
        }
        else if (status.ToString() == "20")
        {
            return "已完成";
        }
        return str;
    }


    //微信订单状态
    public static string WxOrderStatus(object status)
    {
        string str = "未知";
        string str1 = status.ToString();
        if (str1 == "2")
        {
            str = "待发货";
        }
        else if (str1 == "3")
        {
            str = "已发货";
        }
        else if (str1 == "5")
        {
            str = "已完成";
        }
        else if (str1 == "8")
        {
            str = "维权中";
        }
        return str;
    }

    //微信卡券状态
    /// <summary>
    /// “CARD_STATUS_NOT_VERIFY”,待审核
    /// “CARD_STATUS_VERIFY_FALL”,审核失败
    /// “CARD_STATUS_VERIFY_OK”， 通过审核
    /// “CARD_STATUS_USER_DELETE”，卡券被用户删除
    /// “CARD_STATUS_USER_DISPATCH ”，在公众平台投放过的卡券
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public static string WxCardStatus(object status)
    {
        string str = "未知";
        string str1 = status.ToString();
        if (str1 == "CARD_STATUS_NOT_VERIFY")
        {
            str = "待审核";
        }
        else if (str1 == "CARD_STATUS_VERIFY_FALL")
        {
            str = "审核失败";
        }
        else if (str1 == "CARD_STATUS_VERIFY_OK")
        {
            str = "通过审核";
        }
        else if (str1 == "CARD_STATUS_DELETE")
        {
            str = "已删除";
        }
        else if (str1 == "CARD_STATUS_USER_DISPATCH")
        {
            str = "已投放";
        }
        return str;
    }

    //微信订单卡券订单状态
    public static string WxOrderCardOrderStatus(object status)
    {
        string str = "未知";
        string str1 = status.ToString();
        if (str1 == "1")
        {
            str = "未生成";
        }
        else if (str1 == "10")
        {
            str = "已生成";
        }
        return str;
    }

    /**/
    /// <summary>
    /// 判断一个字符串是否为合法整数(不限制长度)
    /// </summary>
    /// <param name="pic">图片地址</param>
    /// <param name="size">0、46、64、96、132</param>
    /// <returns></returns>
    public static string ReplaceImgUrl(object pic, int size)
    {
        if (pic != null && pic != "")
        {
            string str = pic.ToString();
            int index = str.LastIndexOf("0");
            return str.Substring(0, index) + size;
        }
        else
        {
            return "";
        }
    }

    /**/
    /// <summary>
    /// 判断一个字符串是否为合法整数(不限制长度)
    /// </summary>
    /// <param name="s">字符串</param>
    /// <returns></returns>
    public static bool IsInteger(string s)
    {
        string pattern = @"^\d*$";
        return Regex.IsMatch(s, pattern);
    }
    /**/
    /// <summary>
    /// 判断一个字符串是否为合法数字(0-32整数)
    /// </summary>
    /// <param name="s">字符串</param>
    /// <returns></returns>
    public static bool IsNumber(string s)
    {
        return IsNumber(s, 32, 0);
    }
    /**/
    /// <summary>
    /// 判断一个字符串是否为合法数字(指定整数位数和小数位数)
    /// </summary>
    /// <param name="s">字符串</param>
    /// <param name="precision">整数位数</param>
    /// <param name="scale">小数位数</param>
    /// <returns></returns>
    public static bool IsNumber(string s, int precision, int scale)
    {
        if ((precision == 0) && (scale == 0))
        {
            return false;
        }
        string pattern = @"(^\d{1," + precision + "}";
        if (scale > 0)
        {
            pattern += @"\.\d{0," + scale + "}$)|" + pattern;
        }
        pattern += "$)";
        return Regex.IsMatch(s, pattern);
    }

    public static string GetDeliveryCompany(string code)
    {
        if (String.IsNullOrEmpty(code))
        {
            return "";
        }
        switch (code.ToLower())
        {
            case "fsearch_code":
                return "邮政EMS";
            case "002shentong":
                return "申通快递";
            case "066zhongtong":
                return "中通速递";
            case "056yuantong":
                return "圆通速递";
            case "042tiantian":
                return "天天快递";
            case "003shunfeng":
                return "顺丰速运";
            case "059yunda":
                return "韵达快运";
            case "064zhaijisong":
                return "宅急送";
            case "020huitong":
                return "汇通快运";
            case "zj001yixun":
                return "易迅快递";
            default:
                return "";
        }
    }

    /// <summary>
    /// 转换GB2312 的字符串为UTF8编码
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string GB2312ToUTF8(string str)
    {
        try
        {
            Encoding uft8 = Encoding.GetEncoding(65001);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            byte[] temp = gb2312.GetBytes(str);
            byte[] temp1 = Encoding.Convert(gb2312, uft8, temp);
            string result = uft8.GetString(temp1);
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}