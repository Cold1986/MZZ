<%@ Application Language="C#" %>

<script runat="server">

    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        ////article_detail.aspx?id=1 TO article_1.aspx
        //string oldString = @"(.*)/article_(\d+)\.aspx";
        //string newString = @"article_detail.aspx?id=$2";
        //System.Text.RegularExpressions.Regex oReg = new System.Text.RegularExpressions.Regex(oldString);
        //if (oReg.IsMatch(Request.Url.ToString()))
        //{
        //    string ReWriteUrl = oReg.Replace(Request.Url.ToString(), newString);
        //    HttpContext.Current.RewritePath(ReWriteUrl);
        //}
        //oReg = null;

        //string oldUrl = HttpContext.Current.Request.RawUrl;
        //string pattern = @"/([^/]+?).html$";
        //string replace = "/default.aspx?q=$1";
        //if (Regex.IsMatch(oldUrl, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled))
        //{
        //    string newUrl = Regex.Replace(oldUrl, pattern, replace, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        //    this.Context.RewritePath(newUrl);
        //}
    }
    
    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码
        ReFreshThread rf = new ReFreshThread();

        //在应用程序启动时运行的代码

        //从配置文件读取公众号信息
        AppInfo appinfo = AppInfo.GetGetAppInfo();
        //设置全局appId和appSecret,一般只用在应用程序启动时调用一次即可
        WeiXinSDK.WeiXin.ConfigGlobalCredential(appinfo.appid, appinfo.secret);
        //注册事件处理程序
        new RegisterEvent();
        //注册消息处理程序
        new RegisterMessage();

        // 刷新
        //ReFreshThread rf = new ReFreshThread();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码
        if (null != ReFreshThread.schedulerThread)
        {
            ReFreshThread.schedulerThread.Abort();
        }
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码
        Exception objErr = Server.GetLastError().GetBaseException();
        CHelper.WriteLog("发生未处理异常", objErr.Message + "       " + objErr.StackTrace);
    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }
       
</script>
