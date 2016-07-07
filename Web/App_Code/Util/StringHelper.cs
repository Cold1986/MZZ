using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///StringHelper 的摘要说明
/// </summary>
public class StringHelper
{
    public static string SplitString(object obj)
    {
        if (obj != null)
        {
            string str = obj.ToString();
            char[] chr = str.ToCharArray();
            List<string> result = new List<string>();
            for (int i = 1; i <= chr.Length; i++)
            {
                if (i != 1 && i != chr.Length && i % 4 == 0)
                {
                    result.Add(chr[i-1] + "-");
                }
                else
                {
                    result.Add(chr[i-1].ToString());
                }
            }
            return string.Join("", result); ;
        }
        return "";
    }
}