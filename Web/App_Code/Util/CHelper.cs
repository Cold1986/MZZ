using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

public class CHelper
{
    /// <summary>
    /// unix时间转换为datetime
    /// </summary>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    public static DateTime UnixTimeToTime(long timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = long.Parse(timeStamp + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);
        return dtStart.Add(toNow);
    }

    /// <summary>
    /// datetime转换为unixtime
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static long TimeToUnixTime(System.DateTime time)
    {
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        return (long)(time - startTime).TotalSeconds;
    }

    static string filepath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log\\";
    /// <summary>
    /// 写日志(用于跟踪)
    /// </summary>
    public static void WriteLog(string LogName, string LogMsg)
    {
        string filename = DateTime.Now.ToString("yyyyMMdd") + ".txt";

        string temp = filepath + filename;
        if (!Directory.Exists(filepath))
            Directory.CreateDirectory(filepath);
        StreamWriter sr = null;
        try
        {
            if (!File.Exists(temp))
            {
                sr = File.CreateText(temp);
            }
            else
            {
                sr = File.AppendText(temp);
            }
            sr.WriteLine(DateTime.Now + "\t" + LogName + ":\t" + LogMsg + "\n");
        }
        catch
        {
        }
        finally
        {
            if (sr != null)
                sr.Close();
        }
    }

    public static string CreateCode(int size = 6)
    {
        string code = "";
        Random rd = new Random();
        for (int i = 0; i < size; i++)
        {
            code += (rd.Next(10)).ToString();
        }

        return code;
    }

    //url里有key的值，就替换为value,没有的话就追加.
    public static string BuildUrl(string url, string ParamText, string ParamValue)
    {
        Regex reg = new Regex(string.Format("{0}=[^&]*", ParamText), RegexOptions.IgnoreCase);
        Regex reg1 = new Regex("[&]{2,}", RegexOptions.IgnoreCase);
        string _url = reg.Replace(url, "");
        //_url = reg1.Replace(_url, "");
        if (_url.IndexOf("?") == -1)
            _url += string.Format("?{0}={1}", ParamText, ParamValue);//?
        else
            _url += string.Format("&{0}={1}", ParamText, ParamValue);//&
        _url = reg1.Replace(_url, "&");
        _url = _url.Replace("?&", "?");
        return _url;
    }

    public static string GetClientIP()
    {
        string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (null == result || result == String.Empty)
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        if (null == result || result == String.Empty)
        {
            result = HttpContext.Current.Request.UserHostAddress;
        }
        return result;
    }

    public static string RemoveHTML(object _Htmlstring)
    {
        string Htmlstring = _Htmlstring.ToString();
        //删除脚本   
        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //删除HTML   
        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

        Htmlstring.Replace("<", "");
        Htmlstring.Replace(">", "");
        Htmlstring.Replace("\r\n", "");
        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

        return Htmlstring;
    }

    //截取固定长度字符串加...
    public static string SubStrDot(object sString, int nLeng)
    {
        string sNewStr;
        try
        {
            sNewStr = sString.ToString();
        }
        catch
        {
            sNewStr = "";
        }

        if (sNewStr.Length <= nLeng)
        {
            return sNewStr;
        }
        sNewStr = sNewStr.Substring(0, nLeng);
        sNewStr = sNewStr + "...";
        return sNewStr;
    }
}
