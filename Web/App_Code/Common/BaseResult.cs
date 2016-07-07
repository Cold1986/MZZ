using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///BaseResult 的摘要说明
/// </summary>
public class BaseResult
{
    public int ErrCode = 0;
    public string ErrMsg = "";
    public bool IsError = false;
    public object Result = null;
}