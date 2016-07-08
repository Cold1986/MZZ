using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs
{
    public class DictionaryHelper
    {
        public static string Get(Dictionary<string, string> dict, FormatType formatType, string code)
        {
            if (formatType == FormatType.GetKey)
                return dict.FirstOrDefault(d => d.Value == code).Key;
            else
                return dict.FirstOrDefault(d => d.Key == code).Value;
        }
    }


    /// <summary>
    /// dictionary 获取key,value枚举
    /// </summary>
    public enum FormatType
    {
        GetKey,
        GetValue
    }
}
