using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///ReturnCode 的摘要说明
/// </summary>

[Serializable]
public class ReturnCode
{
    public int errcode { get; set; }
    public string errmsg { get; set; }
    public object content { get; set; }
    public override string ToString()
    {
        return "{ \"errcode\":" + errcode + ",\"errmsg\":\"" + errmsg + "\"}";
    }
}