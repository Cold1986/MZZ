using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// NumHelper 的摘要说明
/// </summary>
public class NumHelper
{
    public NumHelper()
    {
    }

    /// <summary>
    /// 保留两位小数
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string CentToDollarStr(object num)
    {
        double rnum = 0;
        if (num == null)
        {
            return "0";
        }
        double.TryParse(num.ToString(), out rnum);

        return String.Format("{0:F}", rnum / 100);
    }

    /// <summary>
    /// 保留两位小数
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static double CentToDollar(object num)
    {
        double rnum = 0;
        if (num == null)
        {
            return 0;
        }
        double.TryParse(num.ToString(), out rnum);

        return Math.Round(rnum / 100, 2);
    }


    /// <summary>
    /// 元转分
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static int DollarToCent(object num)
    {
        double rnum = 0;
        if (num == null)
        {
            return 0;
        }
        Double.TryParse(num.ToString(), out rnum);

        return Convert.ToInt32(Math.Round(rnum * 100, 0));
    }
}