<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="admin_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理后台</title>
    <link href="css/grobal.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 9]><script src="js/html5.js"></script><![endif]-->
    <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="js/index.js"></script>
    <!--[if lt IE 7]>
<script src="js/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
    <script type="text/javascript">
       DD_belatedPNG.fix('div,img, li,a,h1');
    </script>
<![endif]-->
</head>
<body class="blue">
    <div class="start_box_bg">
    </div>
    <div class="start_box">
    </div>
    <header>
	<div id="north">
      <div id="north_left">
         <!--<img src="images/product.png" align="absmiddle">--> <span style="font-size:32px; font-family:Microsoft YaHei; padding-left:20px;">旗忠驾校管理后台</span>
      </div>
      <div id="north_right">
        <!--<div id="datetime"><div id="time_area">14:21</div><div id="date" title="2013年6月20日">6月20日星期四</div> <div id="mdate" title="农历 五月十三">农历五月十三</div>--></div>
        
         <!-- 天气预报 -->
         
         
         </div>
      </div>
   </div>
   <div id="taskbar">
      <div id="taskbar_left">
         <a href="javascript:;" id="start_menu"></a>
         <div class="top_menu">
         	<div class="top_c">
            	<div class="character">
                	<img src="images/1.gif" width="38" /><span><%=Session["myname"]%></span>
                </div>
                <div class="log_console">
                      <a class="logout" href="logout.aspx"  title="注销"></a>
                      <a class="exit" href="logout.aspx" title="退出"></a>
                </div>
            </div>
         	<div class="menu_left">
            	<ul>
                	<li><a href="#"><img src="images/menu/1vote.gif" />设置</a></li>
                    <li><a ><img src="images/menu/1vote.gif" />企业管理</a></li>
                    <li><a href="#"><img src="images/menu/1vote.gif" />人事管理设置</a></li>
                </ul>
            </div>
            <div class="menu_right">
            	<ul>
                	<li><a href="#">个人信息设置</a>
                    	<ul>
                        	<li><a href="javascript:;">修改登录密码</a></li>
                            <li><a href="javascript:;">登录昵称修改</a></li>
                            <li><a href="javascript:;">查看基本信息</a></li>
                        </ul>
                    </li>
                </ul>
                <ul>
                	<li color="red"><a href="javascript:;" rel="mail.aspx" title="企业设置">企业设置</a></li>
                    <li color="orange"><a href="javascript:;" rel="bus_info.aspx" title="企业信息">企业信息</a></li>
                </ul>
                <ul></ul>
            </div>
         </div>
      </div>
      <div id="taskbar_center" style="width: 817px;">
         <div id="tabs_left_scroll" style="display: none;"></div>
         <div id="tabs_container" style="width: 756px;">
             <div id="tabs_portal_0" class="selected">
             <a href="javascript:;" color="blue" class="tab">个人桌面</a><a href="javascript:;" class="close"></a>
            
             </div>
             <!--<div id="tabs_portal_4"><a href="javascript:;" class="tab">个人桌面</a><a href="javascript:;" class="close"></a>
             </div>-->

         </div>
         <div id="tabs_right_scroll" style="display: none;"></div>
      </div>
    
   </div>
   <div id="overlay_startmenu"></div>

<div id="funcbar">
      <div id="funcbar_left"></div>
      <div id="funcbar_right">
        <!-- <div class="search">
            <div class="search-body">
               <div class="search-input"><input id="keyword" type="text" value="" class="ui-autocomplete-input"></div>
               <div id="search_clear" class="search-clear" style="display:none;" onclick="document.getElementById('keyword').value = '';this.style.display = 'none';"></div>
            </div>
         </div>-->
      </div>
   </div>
</header>
    <div id="center">
        <div class="mainnav">
            <div class="slide_nav">
                <table cellpadding="0" cellspacing="0" border="0" align="center">
                    <tr>
                        <td class="slide_left">
                        </td>
                        <td>
                            <a href="#" class="chosen"></a><a href="#"></a>
                        </td>
                        <td class="slide_right">
                        </td>
                    </tr>
                </table>
            </div>
            <div class="slide_menulist">
                <div class="slide_box">
                    <ul>
                        <li color="deepblue"><a href="javascript:;" rel="user_list.aspx" title="会员管理">
                            <img src="images/nav/diary.png" /></a> <a href="javascript:;" title="会员管理" rel="user_list.aspx"
                                class="menufont"><span>会员管理</span> </a></li>
                        
                        <li color="orange"><a href="javascript:;" rel="order_list.aspx" title="微信订单">
                            <img src="images/nav/diary.png" /></a> <a href="javascript:;" title="微信订单" rel="order_list.aspx"
                                class="menufont"><span>微信订单</span> </a></li>
                        <li color="orange"><a href="javascript:;" rel="ll_list.aspx" title="流量订单">
                            <img src="images/nav/diary.png" /></a> <a href="javascript:;" title="流量订单" rel="ll_list.aspx"
                                class="menufont"><span>流量订单</span> </a></li>
                        <li color="orange"><a href="javascript:;" rel="article_list.aspx" title="文章管理">
                            <img src="images/nav/diary.png" /></a> <a href="javascript:;" title="文章管理" rel="article_list.aspx"
                                class="menufont"><span>文章管理</span> </a></li>
                        <li color="orange"><a href="javascript:;" rel="MenuEventNews.aspx" title="图文消息管理">
                            <img src="images/nav/diary.png" /></a> <a href="javascript:;" title="图文消息管理" rel="MenuEventNews.aspx"
                                class="menufont"><span>图文消息管理</span> </a></li>
                    </ul>
                    <ul>
                        <li color="orange"><a href="javascript:;" rel="admin_list.aspx" title="权限管理">
                            <img src="images/nav/diary.png" /></a> <a href="javascript:;" title="权限管理" rel="admin_list.aspx"
                                class="menufont"><span>权限管理</span> </a></li>
                        <li color="orange"><a href="javascript:;" rel="log_list.aspx" title="日志管理">
                            <img src="images/nav/diary.png" /></a> <a href="javascript:;" title="日志管理" rel="log_list.aspx"
                                class="menufont"><span>日志管理</span> </a></li>
                        <li color="orange"><a href="javascript:;" rel="psw.aspx" title="修改密码">
                            <img src="images/nav/diary.png" /></a> <a href="javascript:;" title="修改密码" rel="psw.aspx"
                                class="menufont"><span>修改密码</span> </a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div id="south">
        <table>
            <tr>
                <%--<td class="left"><div id="online_link" onClick="ViewOnlineUser()">在线<span id="user_count">2</span>人</div></td>--%>
                <td class="left">
                    <div id="new_sms">
                    </div>
                    <span id="new_sms_sound" style="width: 1px; height: 1px;"></span>
                </td>
                <td class="center">
                    <marquee direction="left" scrollamount="1" scrolldelay="1" onmouseover="this.stop()"
                        onmouseout="this.start()">
                    <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                	<%#Eval("text")%>
                    </ItemTemplate>
                    </asp:Repeater>
                </marquee>
                </td>
                <td style="cursor: hand;" class="right">
                </td>
                <td class="right">
                    <div class="mail_box">
                        <h1>
                            <span>信息记录</span></h1>
                        <ul>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <li><a href="javascript:;" rel="supplier_notice.aspx?id=<%#Eval("id")%>"><span><b>
                                        <%#Eval("title")%></b><%# Convert.ToDateTime(Eval("times")).ToString("yyyy-MM-dd")%></span><%#Eval("title")%></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <div class="mail_close">
                            <a href="#">关闭</a>
                        </div>
                    </div>
                    <a href="#" id="message"></a><a href="javascript:;" id="mail"></a>
                </td>
            </tr>
        </table>
    </div>
    <div class="mail_c">
        <h1>
            <a href="#" class="mail_c_close"></a><span></span>
        </h1>
        <iframe frameborder="0" width="550" height="342"></iframe>
    </div>
</body>
</html>
