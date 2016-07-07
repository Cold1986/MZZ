<%@ WebHandler Language="C#" Class="SweepHandler" %>

using System;
using System.Web;

public class SweepHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string act = context.Request["act"];
        string openid = context.Request["openid"];
        string str = context.Request["str"];
        CHelper.WriteLog("str:", "" + str + "," + openid + "," + act + "");
        var result = new { iserror = true, results = str };
        context.Response.Write(WeiXinSDK.Util.ToJson(result));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}