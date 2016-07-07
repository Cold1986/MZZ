using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Xml;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using ServiceModel;
using EnumLibrary;
using ServiceBiz;

public partial class admin_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo userinfo = UserInfoRule.CheckLogin();
        if (userinfo == null || userinfo.TableName != EnumLoginType.Admin)
        {
            Response.Redirect("default.aspx");
            return;
        }
    }
}
