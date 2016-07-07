<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Luckdraw.aspx.cs" Inherits="Luckdraw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script language="JavaScript" type="text/JavaScript">
      <!--
        alert("活动已结束，稍后会放上填写收获地址入口，请中奖者填写收货信息，最后感谢参与此次活动");
        window.location = "http://viewer.maka.im/pcviewer/RJ3BUAEG?DSCKID=55f2c955-5bc4-4dfb-8353-78651258cfe7&DSTIMESTAMP=1465131817117";
      -->
    </script>
    <meta charset="gb2312"/>
    <title>萌宅族抽奖</title>
    <meta name="viewport" content="width=device-width" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"/>
    <script src="js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="js/Rotate.js"></script>
    <style>
        body, div, dl, dt, dd, ul, ol, li, h1, h2, h3, h4, h5, h6, pre, form, fieldset, input, textarea, p, blockquote, th, td
        {
            padding: 0;
            margin: 0;
        }
        
        fieldset, img
        {
            border: 0;
        }
        address, caption, cite, code, dfn, em, strong, th, var
        {
            font-weight: normal;
            font-style: normal;
        }
        ol, ul, li
        {
            list-style: none;
        }
        caption, th
        {
            text-align: left;
        }
        h1, h2, h3, h4, h5, h6
        {
            font-weight: normal;
            font-size: 100%;
        }
        q:before, q:after
        {
            content: ?;
        }
        abbr, acronym
        {
            border: 0;
        }
        .clear
        {
            clear: both;
        }
        input
        {
            -webkit-transition: box-shadow 0.30s ease-in-out;
            -moz-transition: box-shadow 0.30s ease-in-out;
        }
        input:focus
        {
            outline: none;
            border: #87C6F9 1px solid;
            box-shadow: 0 0 8px rgba(103, 166, 217, 1);
        }
        a
        {
            text-decoration: none;
            color: #999;
        }
        p
        {
            line-height: 24px;
        }
        body
        {
            margin: 0px;
            padding: 0 0 50px 0;
            font-size: 0.75em;
            color: #333333;
            font-family: "Microsoft Yahei";
            background: #fff;
        }
        @media screen and (min-width: 1000px)
        {
            body
            {
                width: 600px;
                margin: 0 auto;
            }
        }
        .lotteryBg
        {
            width: 320px;
            height: 320px;
            margin: -50px auto 0 auto;
            background: url(images/lotteryBg.png) no-repeat center center;
            background-size: 100%;
            position: relative;
            overflow: hidden;
        }
        #run
        {
            width: 100px;
            height: 140px;
            position: absolute;
            left: 50%;
            top: 50%;
            margin-left: -52px;
            margin-top: -77px;
            z-index: 1;
            transform: rotate(0deg);
            -ms-transform: rotate(0deg);
        }
        #inner
        {
            width: 75px;
            height: 75px;
            background: url(images/btn_start.png) no-repeat;
            border: none;
            outline: none;
            position: absolute;
            left: 50%;
            top: 50%;
            background-size: 100%;
            margin-left: -40px;
            margin-top: -44px;
            z-index: 2;
            cursor: pointer;
        }
        .cj_txt
        {
            font-size: 14px;
            color: #ff0;
            padding: 0 5%;
            line-height: 28px;
            background: url(images/hb.png) no-repeat center center;
            background-size: 80%;
        }
    </style>
</head>
<body style="background: #56247d;">
    <form id="form1" runat="server">
    <img src="images/cj_top1.jpg" width="100%" />
    <section class="lotteryMain">
	<div class="lotteryBg">
         <img src="images/lotteryBg.png" width="95%" style="position:absolute; z-index:-1"/>
    	<img id="run" src="images/start.png" width="100" />
        <input id="inner" type="button" value="" />
    </div>
  </section>
  
    <img src="images/line.png" width="100%" style="display: inline-block; margin: 10px auto;" />
    <div class="cj_txt">
        <p>
            抽奖说明：</p>
        <p>
            1.每天可以抽奖2次，分享到朋友圈或者发送给朋友可以额外获得1次抽奖机会<br />
            2.活动时间为2016年6月9日至2016年6月19日<br />
            3.积分可用来兑换各种萌物(后续开放)<br />
            4.抽到实物奖品后会以邮寄的方式寄出<br />
            4.本次抽奖活动最终解释权归属萌宅族</p>
    </div>
     
    </form>
</body>
<script src="jssdk/jweixin-1.0.0.js" type="text/javascript"></script>
<script type="text/javascript">
    wx.config({
        debug: false,
        appId: '<%=appId %>',
        timestamp: <%=timestamp %>,
        nonceStr: '<%=nonceStr %>',
        signature: '<%=signature %>',
        jsApiList: [
        'checkJsApi',
        'onMenuShareTimeline',
        'onMenuShareAppMessage',
        'onMenuShareQQ',
        'onMenuShareWeibo',
        'scanQRCode'
        ]
    });
    function shareCallBack() { 
        // 用户确认分享后执行的回调函数
        $.ajax({
            url: "Handler/NewsHandler.ashx",
            data: {
                act: "share",
                openid: "<%=openid %>"
            },
            cache:false,
            success: function (result) {
                var data = $.parseJSON(result);
                if (data.errcode == 0) {
                    alert("分享成功");
                    $("#inner").attr('disabled', false).css("cursor", "pointer");
                }
                else{
                    alert(result);
                    $("#inner").attr('disabled', true).css("cursor", "pointer");
                }
            }
        });
    }
    wx.ready(function () {
        var shareData = {
            title: "萌宅族抽奖",
            desc: "百分百中奖,分享此页面给朋友,朋友扫描二维码并关注,既能多抽一次哦~",
            link: "<%=shareurl%>",
            imgUrl: '<%=newsPic%>',
            success: shareCallBack
        };

        // 2. 分享接口
        // 2.1 “分享给朋友”
        wx.onMenuShareAppMessage(shareData);
        // 2.2 “分享到朋友圈”
        wx.onMenuShareTimeline(shareData);
        // 2.3 “分享到QQ”
        wx.onMenuShareQQ(shareData);
        // 2.4 “分享到微博”
        wx.onMenuShareWeibo(shareData);
    });

    wx.error(function (res) {
        alert(res.errMsg);
    });
</script>

<script>

    $(function () {
            $("#inner").click(function () {
                $("#inner").attr('disabled', true).css("cursor", "default");
                lottery();
            });
            $("#run").css("-webkit-transform", "rotate(180deg)");
    });
    function lottery() {
        $.ajax({
            type: 'get',
            url: 'Handler/PrizeHandler.ashx?code=' + '<%=code %>',
            cache: false,
            error: function () { return false; },
            success: function (obj) {
                obj = $.parseJSON(obj);
                if (obj.iserror == false) {
                    $("#run").rotate({
                        duration: 3000, //转动时间 
                        angle: 0, //默认角度
                        animateTo: 360 * 6 + obj.rotate, //转动角度 
                        easing: $.easing.easeOutSine,
                        callback: function () {
                            alert("恭喜你获得" + obj.results);
                            $("#inner").attr('disabled', false).css("cursor", "pointer");
                        }
                    });
                }
                else {
                    alert(obj.results);
                }
            }
        });
    };
    wx.error(function (res) {
        alert(res.errMsg);
    });
</script>
</html>