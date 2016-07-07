using System;
using System.Text.RegularExpressions;

public class RegexUtil
{
    private RegexUtil() { }

    private static RegexUtil instance = null;
    /// <summary>
    /// 静态实例化单体模式
    /// 保证应用程序操作某一全局对象，让其保持一致而产生的对象
    /// </summary>
    /// <returns></returns>
    public static RegexUtil GetInstance()
    {
        if (RegexUtil.instance == null)
        {
            RegexUtil.instance = new RegexUtil();
        }
        return RegexUtil.instance;
    }

    /// <summary>
    /// 判断输入的字符串只包含汉字
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsChineseCh(string input)
    {
        return IsMatch(@"^[\u4e00-\u9fa5]+$", input);
    }

    /// <summary>
    /// 匹配3位或4位区号的电话号码，其中区号可以用小括号括起来，
    /// 也可以不用，区号与本地号间可以用连字号或空格间隔，
    /// 也可以没有间隔
    /// \(0\d{2}\)[- ]?\d{8}|0\d{2}[- ]?\d{8}|\(0\d{3}\)[- ]?\d{7}|0\d{3}[- ]?\d{7}
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsPhone(string input)
    {
        string pattern = "^\\(0\\d{2}\\)[- ]?\\d{8}$|^0\\d{2}[- ]?\\d{8}$|^\\(0\\d{3}\\)[- ]?\\d{7}$|^0\\d{3}[- ]?\\d{7}$";
        return IsMatch(pattern, input);
    }

    /// <summary>
    /// 判断输入的字符串是否是一个合法的手机号
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsMobilePhone(string input)
    {
        return IsMatch(@"^1[3|4|5|8]\d{9}$", input);
    }

    /// <summary>
    /// 判断输入的字符串只包含数字
    /// 可以匹配整数和浮点数
    /// ^-?\d+$|^(-?\d+)(\.\d+)?$
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsNumber(string input)
    {
        string pattern = "^-?\\d+$|^(-?\\d+)(\\.\\d+)?$";
        return IsMatch(pattern, input);
    }

    /// <summary>
    /// 匹配非负整数
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsNotNagtive(string input)
    {
        return IsMatch(@"^\d+$", input);
    }
    /// <summary>
    /// 匹配正整数
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsUint(string input)
    {
        return IsMatch(@"^[0-9]*[1-9][0-9]*$", input);
    }

    /// <summary>
    /// 判断输入的字符串字包含英文字母
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsEnglisCh(string input)
    {
        return IsMatch(@"^[A-Za-z]+$", input);
    }

    /// <summary>
    /// 判断输入的字符串是否是一个合法的Email地址
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsEmail(string input)
    {
        string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        return IsMatch(pattern, input);
    }

    /// <summary>
    /// 判断输入的字符串是否只包含数字和英文字母
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsNumAndEnCh(string input)
    {
        return IsMatch(@"^[A-Za-z0-9]+$", input);
    }

    /// <summary>
    /// 判断输入的字符串是否是一个超链接
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsURL(string input)
    {
        string pattern = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
        return IsMatch(pattern, input);
    }

    /// <summary>
    /// 判断输入的字符串是否是表示一个IP地址
    /// </summary>
    /// <param name="input">被比较的字符串</param>
    /// <returns>是IP地址则为True</returns>
    public static bool IsIPv4(string input)
    {
        string[] IPs = input.Split('.');

        for (int i = 0; i < IPs.Length; i++)
        {
            if (!IsMatch(@"^\d+$", IPs[i]))
            {
                return false;
            }
            if (Convert.ToUInt16(IPs[i]) > 255)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 判断输入的字符串是否是合法的IPV6 地址
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsIPV6(string input)
    {
        string pattern = "";
        string temp = input;
        string[] strs = temp.Split(':');
        if (strs.Length > 8)
        {
            return false;
        }
        int count = RegexUtil.GetStringCount(input, "::");
        if (count > 1)
        {
            return false;
        }
        else if (count == 0)
        {
            pattern = @"^([\da-f]{1,4}:){7}[\da-f]{1,4}$";
            return IsMatch(pattern, input);
        }
        else
        {
            pattern = @"^([\da-f]{1,4}:){0,5}::([\da-f]{1,4}:){0,5}[\da-f]{1,4}$";
            return IsMatch(pattern, input);
        }
    }

    /// <summary>
    /// 判断输入的字符串是否是合法的身份证号
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsIdCard(string input)
    {
        string pattern = @"^((1[1-5])|(2[1-3])|(3[1-7])|(4[1-6])|(5[0-4])|(6[1-5])|71|(8[12])|91)\d{4}((19\d{2}(0[13-9]|1[012])(0[1-9]|[12]\d|30))|(19\d{2}(0[13578]|1[02])31)|(19\d{2}02(0[1-9]|1\d|2[0-8]))|(19([13579][26]|[2468][048]|0[48])0229))\d{3}(\d|X|x)?$";
        return IsMatch(pattern, input);
    }

    #region 正则的通用方法
    /// <summary>
    /// 计算字符串的字符长度，一个汉字字符将被计算为两个字符
    /// </summary>
    /// <param name="input">需要计算的字符串</param>
    /// <returns>返回字符串的长度</returns>
    public static int GetCount(string input)
    {
        return Regex.Replace(input, @"[\u4e00-\u9fa5/g]", "aa").Length;
    }

    /// <summary>
    /// 调用Regex中IsMatch函数实现一般的正则表达式匹配
    /// </summary>
    /// <param name="pattern">要匹配的正则表达式模式。</param>
    /// <param name="input">要搜索匹配项的字符串</param>
    /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false。</returns>
    public static bool IsMatch(string pattern, string input)
    {
        if (input == null || input == "") return false;
        Regex regex = new Regex(pattern);
        return regex.IsMatch(input);
    }

    /// <summary>
    /// 从输入字符串中的第一个字符开始，用替换字符串替换指定的正则表达式模式的所有匹配项。
    /// </summary>
    /// <param name="pattern">模式字符串</param>
    /// <param name="input">输入字符串</param>
    /// <param name="replacement">用于替换的字符串</param>
    /// <returns>返回被替换后的结果</returns>
    public static string Replace(string pattern, string input, string replacement)
    {
        Regex regex = new Regex(pattern);
        return regex.Replace(input, replacement);
    }

    /// <summary>
    /// 在由正则表达式模式定义的位置拆分输入字符串。
    /// </summary>
    /// <param name="pattern">模式字符串</param>
    /// <param name="input">输入字符串</param>
    /// <returns></returns>
    public static string[] Split(string pattern, string input)
    {
        Regex regex = new Regex(pattern);
        return regex.Split(input);
    }

    /* *******************************************************************
     * 1、通过“:”来分割字符串看得到的字符串数组长度是否小于等于8
     * 2、判断输入的IPV6字符串中是否有“::”。
     * 3、如果没有“::”采用 ^([\da-f]{1,4}:){7}[\da-f]{1,4}$ 来判断
     * 4、如果有“::” ，判断"::"是否止出现一次
     * 5、如果出现一次以上 返回false
     * 6、^([\da-f]{1,4}:){0,5}::([\da-f]{1,4}:){0,5}[\da-f]{1,4}$
     * ******************************************************************/
    /// <summary>
    /// 判断字符串compare 在 input字符串中出现的次数
    /// </summary>
    /// <param name="input">源字符串</param>
    /// <param name="compare">用于比较的字符串</param>
    /// <returns>字符串compare 在 input字符串中出现的次数</returns>
    private static int GetStringCount(string input, string compare)
    {
        int index = input.IndexOf(compare);
        if (index != -1)
        {
            return 1 + GetStringCount(input.Substring(index + compare.Length), compare);
        }
        else
        {
            return 0;
        }

    }
    #endregion

    /// <summary>  
    /// 验证身份证合理性  
    /// </summary>  
    /// <param name="Id"></param>  
    /// <returns></returns>  
    public static bool CheckIDCard(string idNumber)
    {
        if (idNumber.Length == 18)
        {
            bool check = CheckIDCard18(idNumber);
            return check;
        }
        else if (idNumber.Length == 15)
        {
            bool check = CheckIDCard15(idNumber);
            return check;
        }
        else
        {
            return false;
        }
    }


    /// <summary>  
    /// 18位身份证号码验证  
    /// </summary>  
    private static bool CheckIDCard18(string idNumber)
    {
        long n = 0;
        if (long.TryParse(idNumber.Remove(17), out n) == false
            || n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
        {
            return false;//数字验证  
        }
        string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
        if (address.IndexOf(idNumber.Remove(2)) == -1)
        {
            return false;//省份验证  
        }
        string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
        DateTime time = new DateTime();
        if (DateTime.TryParse(birth, out time) == false)
        {
            return false;//生日验证  
        }
        string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
        string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
        char[] Ai = idNumber.Remove(17).ToCharArray();
        int sum = 0;
        for (int i = 0; i < 17; i++)
        {
            sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
        }
        int y = -1;
        Math.DivRem(sum, 11, out y);
        if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())
        {
            return false;//校验码验证  
        }
        return true;//符合GB11643-1999标准  
    }


    /// <summary>  
    /// 16位身份证号码验证  
    /// </summary>  
    private static bool CheckIDCard15(string idNumber)
    {
        long n = 0;
        if (long.TryParse(idNumber, out n) == false || n < Math.Pow(10, 14))
        {
            return false;//数字验证  
        }
        string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
        if (address.IndexOf(idNumber.Remove(2)) == -1)
        {
            return false;//省份验证  
        }
        string birth = idNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");
        DateTime time = new DateTime();
        if (DateTime.TryParse(birth, out time) == false)
        {
            return false;//生日验证  
        }
        return true;
    }   
}